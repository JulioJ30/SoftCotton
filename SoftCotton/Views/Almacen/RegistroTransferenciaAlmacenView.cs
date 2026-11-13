using SoftCotton.BusinessLogic;
using SoftCotton.Model.Almacen;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Almacen
{
    /// <summary>
    /// Registro de una transferencia o devolución entre almacenes.
    ///
    /// Flujo: 1) tipo, fecha y almacenes; 2) buscar productos con stock en el origen
    /// (búsqueda en segundo plano mientras se escribe, cancelando la anterior);
    /// 3) agregar al detalle (se propone todo el disponible) y ajustar cantidades;
    /// 4) grabar: cabecera + detalle viajan en una sola llamada y una sola transacción.
    ///
    /// Mientras haya productos en el detalle, el tipo, la fecha y el origen quedan fijos
    /// (el disponible depende de ellos); "Cambiar origen / fecha" limpia el detalle.
    /// </summary>
    public partial class RegistroTransferenciaAlmacenView : FormularioAsync
    {
        public enum Modo
        {
            Transferencia,
            Devolucion
        }

        private const int MaximoResultados = 500;

        private readonly AlmacenBL _almacenBL = new AlmacenBL();
        private readonly MantenimientoBL _mantenimientoBL = new MantenimientoBL();
        private readonly List<AlmacenItem> _almacenes;
        private readonly BindingList<TransferenciaAlmacenLinea> _detalle = new BindingList<TransferenciaAlmacenLinea>();
        private readonly HashSet<string> _clavesEnDetalle = new HashSet<string>();
        private readonly string _origenInicial;
        private readonly List<TransferenciaAlmacenLinea> _lineasIniciales;

        private CancellationTokenSource _ctsBusqueda;
        private bool _inicializando = true;
        private bool _cierreConfirmado;

        /// <summary>Id de la transferencia grabada (cuando DialogResult = OK).</summary>
        public int IdTransferenciaRegistrada { get; private set; }

        // Constructor sin parámetros requerido por el diseñador de Visual Studio
        public RegistroTransferenciaAlmacenView()
            : this(Modo.Transferencia, new List<AlmacenItem>(), null, null)
        {
        }

        public RegistroTransferenciaAlmacenView(Modo modo, List<AlmacenItem> almacenes)
            : this(modo, almacenes, null, null)
        {
        }

        /// <summary>
        /// Abre el registro precargado (por ejemplo, "Devolver al central" desde el reporte de stock).
        /// </summary>
        public RegistroTransferenciaAlmacenView(Modo modo, List<AlmacenItem> almacenes, string codOrigen, IEnumerable<TransferenciaAlmacenLinea> lineas)
        {
            InitializeComponent();

            _almacenes = almacenes ?? new List<AlmacenItem>();
            _origenInicial = codOrigen;
            _lineasIniciales = lineas == null ? null : lineas.ToList();

            AplicarEstilos();

            rbDevolucion.Checked = modo == Modo.Devolucion;
            rbTransferencia.Checked = modo == Modo.Transferencia;

            dgvDetalle.DataSource = _detalle;
            _detalle.ListChanged += (s, e) => ActualizarResumen();
            splitContenido.Panel2.Resize += (s, e) => CentrarMensajeDetalleVacio();
        }

        private Modo ModoActual
        {
            get { return rbDevolucion.Checked ? Modo.Devolucion : Modo.Transferencia; }
        }

        private string CodOrigen
        {
            get { return cbxOrigen.SelectedValue as string; }
        }

        private string CodDestino
        {
            get { return cbxDestino.SelectedValue as string; }
        }

        private AlmacenItem AlmacenOrigen
        {
            get { return cbxOrigen.SelectedItem as AlmacenItem; }
        }

        private AlmacenItem AlmacenDestino
        {
            get { return cbxDestino.SelectedItem as AlmacenItem; }
        }

        // ================================================================== inicio

        private void AplicarEstilos()
        {
            EstiloVisual.AplicarGrilla(dgvProductos);
            EstiloVisual.AplicarGrilla(dgvDetalle, soloLectura: false);
            dgvProductos.MultiSelect = true;
            EstiloVisual.ColumnaNumero(colPStock);
            EstiloVisual.ColumnaNumero(colDDisponible);
            EstiloVisual.ColumnaNumero(colDCantidad);

            // columnas editables resaltadas
            var editable = Color.FromArgb(255, 251, 230);
            colDCantidad.DefaultCellStyle.BackColor = editable;
            colDComentario.DefaultCellStyle.BackColor = editable;
            colDCantidad.DefaultCellStyle.Font = EstiloVisual.FuenteNegrita;
            colDDisponible.DefaultCellStyle.ForeColor = EstiloVisual.TextoSecundario;

            colDQuitar.FlatStyle = FlatStyle.Flat;
            colDQuitar.DefaultCellStyle.ForeColor = EstiloVisual.Peligro;
            colDQuitar.DefaultCellStyle.SelectionForeColor = EstiloVisual.Peligro;

            foreach (var rb in new[] { rbTransferencia, rbDevolucion })
            {
                rb.FlatStyle = FlatStyle.Flat;
                rb.Font = EstiloVisual.FuenteNegrita;
                rb.Cursor = Cursors.Hand;
                rb.FlatAppearance.BorderColor = EstiloVisual.Primario;
                rb.FlatAppearance.CheckedBackColor = EstiloVisual.Primario;
                rb.FlatAppearance.MouseOverBackColor = Color.FromArgb(236, 242, 249);
            }

            EstiloVisual.BotonPrimario(btnGrabar);
            EstiloVisual.BotonSecundario(btnCancelar);
            EstiloVisual.BotonPrimario(btnAgregar);

            lnkCambiar.LinkColor = EstiloVisual.Primario;
            lblDetalleVacio.BackColor = EstiloVisual.Superficie;
        }

        private async void RegistroTransferenciaAlmacenView_Load(object sender, EventArgs e)
        {
            dtpFecha.MaxDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;

            ConfigurarModo();
            PintarTipo();

            if (_lineasIniciales != null)
            {
                foreach (var linea in _lineasIniciales)
                {
                    AgregarLinea(linea);
                }
            }

            await EjecutarAsync(async ct =>
            {
                List<GetMant16_NivelCBX> niveles = await Task.Run(() => _mantenimientoBL.Get16_NivelCBX(), ct);

                var opciones = new List<OpcionCombo> { new OpcionCombo("", "Todos los niveles") };
                opciones.AddRange(niveles.Select(n => new OpcionCombo(n.codNivel, n.codNivel + " - " + n.nivel)));
                cbxNivel.DisplayMember = "Texto";
                cbxNivel.ValueMember = "Valor";
                cbxNivel.DataSource = opciones;
            }, "Preparando...");

            _inicializando = false;
            ActualizarResumen();
            CentrarMensajeDetalleVacio();
            BuscarProductos();
            txtBuscarProducto.Focus();
        }

        // ================================================================== cabecera

        /// <summary>Llena origen/destino según el tipo de movimiento.</summary>
        private void ConfigurarModo()
        {
            bool devolucion = ModoActual == Modo.Devolucion;

            lblTitulo.Text = devolucion ? "Nueva devolución al almacén central" : "Nueva transferencia";
            lblSubtitulo.Text = devolucion
                ? "Regresa stock de un almacén al central (por ejemplo, antes de despacharlo con guía de remisión)."
                : "Mueve stock de un almacén a otro. El Kardex muestra la salida y el ingreso; el saldo total no cambia.";

            var origenes = devolucion
                ? _almacenes.Where(a => !a.EsCentral).ToList()
                : _almacenes.ToList();

            string origenPreferido = _origenInicial ?? CodOrigen ?? (devolucion ? null : AlmacenItem.CodigoCentral);

            cbxOrigen.DisplayMember = "Texto";
            cbxOrigen.ValueMember = "Codigo";
            cbxOrigen.DataSource = origenes;
            SeleccionarOFirst(cbxOrigen, origenes, origenPreferido);

            ActualizarDestinos();
        }

        private void ActualizarDestinos()
        {
            bool devolucion = ModoActual == Modo.Devolucion;
            string origen = CodOrigen;
            string destinoActual = CodDestino;

            // devolución: siempre al central. transferencia: a cualquier otro almacén que no
            // sea el central (eso sería una devolución) ni el mismo origen.
            var destinos = devolucion
                ? _almacenes.Where(a => a.EsCentral).ToList()
                : _almacenes.Where(a => !a.EsCentral && a.Codigo != origen).ToList();

            cbxDestino.DisplayMember = "Texto";
            cbxDestino.ValueMember = "Codigo";
            cbxDestino.DataSource = destinos;
            SeleccionarOFirst(cbxDestino, destinos, destinoActual);
            cbxDestino.Enabled = !devolucion && destinos.Count > 0;

            lblPaso1.Text = "1. Busque productos con stock en " + (AlmacenOrigen != null ? AlmacenOrigen.Descripcion : "el origen");
            ActualizarResumen();
        }

        private static void SeleccionarOFirst(ComboBox combo, List<AlmacenItem> lista, string codigo)
        {
            int indice = lista.FindIndex(a => a.Codigo == codigo);
            combo.SelectedIndex = indice >= 0 ? indice : (lista.Count > 0 ? 0 : -1);
        }

        private void rbTipo_CheckedChanged(object sender, EventArgs e)
        {
            PintarTipo();

            var rb = (RadioButton)sender;
            if (!rb.Checked || _inicializando)
            {
                return;
            }

            ConfigurarModo();
            BuscarProductos();
        }

        private void PintarTipo()
        {
            foreach (var rb in new[] { rbTransferencia, rbDevolucion })
            {
                rb.BackColor = rb.Checked ? EstiloVisual.Primario : EstiloVisual.Superficie;
                rb.ForeColor = rb.Checked ? Color.White : EstiloVisual.Primario;
            }
        }

        private void cbxOrigen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ActualizarDestinos();
            BuscarProductos();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!_inicializando)
            {
                ProgramarBusqueda();
            }
        }

        private void lnkCambiar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_detalle.Count == 0)
            {
                return;
            }

            var respuesta = MessageBox.Show(
                "El stock disponible depende del almacén de origen y de la fecha.\n\n" +
                "Para cambiarlos se quitarán los " + _detalle.Count + " productos del detalle. ¿Continuar?",
                "SoftCotton", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                _detalle.Clear();
                cbxOrigen.Focus();
            }
        }

        /// <summary>
        /// Con productos en el detalle, el tipo / fecha / origen quedan fijos.
        /// </summary>
        private void BloquearCabecera()
        {
            bool hayDetalle = _detalle.Count > 0;
            rbTransferencia.Enabled = !hayDetalle;
            rbDevolucion.Enabled = !hayDetalle;
            dtpFecha.Enabled = !hayDetalle;
            cbxOrigen.Enabled = !hayDetalle;
            lnkCambiar.Visible = hayDetalle;
        }

        // ================================================================== búsqueda

        private void cbxNivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            ProgramarBusqueda();
        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarProductos();
            }
            else if (e.KeyCode == Keys.Down && dgvProductos.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                dgvProductos.Focus();
            }
        }

        /// <summary>Espera a que el usuario deje de escribir antes de consultar.</summary>
        private void ProgramarBusqueda()
        {
            tmrBusqueda.Stop();
            tmrBusqueda.Start();
        }

        private void tmrBusqueda_Tick(object sender, EventArgs e)
        {
            tmrBusqueda.Stop();
            BuscarProductos();
        }

        private async void BuscarProductos()
        {
            tmrBusqueda.Stop();
            if (_inicializando)
            {
                return;
            }

            // se cancela cualquier búsqueda anterior que siga en curso
            var cts = new CancellationTokenSource();
            Interlocked.Exchange(ref _ctsBusqueda, cts)?.Cancel();

            try
            {
                var origen = AlmacenOrigen;
                string nivel = cbxNivel.SelectedValue as string;
                DateTime fecha = dtpFecha.Value.Date;
                string texto = txtBuscarProducto.Text;

                if (origen == null)
                {
                    MostrarResultados(null, "Seleccione el almacén de origen.");
                    return;
                }

                // el central es todo el Kardex: se pide el nivel para que la consulta sea ágil
                if (origen.EsCentral && string.IsNullOrEmpty(nivel))
                {
                    MostrarResultados(null, "Seleccione un nivel para ver el stock del almacén central.");
                    return;
                }

                lblEstadoBusqueda.ForeColor = EstiloVisual.TextoSecundario;
                lblEstadoBusqueda.Text = "Buscando en " + origen.Descripcion + "...";

                await EjecutarAsync(async ct =>
                {
                    var lista = await _almacenBL.BuscarProductosConStockAsync(origen.Codigo, fecha, nivel, texto, ct);
                    ct.ThrowIfCancellationRequested();

                    string estado;
                    if (lista.Count == 0)
                        estado = "No hay productos con stock en " + origen.Descripcion + " para esta búsqueda.";
                    else if (lista.Count >= MaximoResultados)
                        estado = "Se muestran los primeros " + MaximoResultados + " productos. Escriba para afinar la búsqueda.";
                    else
                        estado = lista.Count + (lista.Count == 1 ? " producto con stock" : " productos con stock") + " al " + fecha.ToString("dd/MM/yyyy");

                    MostrarResultados(lista, estado);
                }, null, false, cts.Token);
            }
            finally
            {
                Interlocked.CompareExchange(ref _ctsBusqueda, null, cts);
                cts.Dispose();
            }
        }

        private void MostrarResultados(List<ProductoStockAlmacen> lista, string estado)
        {
            dgvProductos.DataSource = lista;
            lblEstadoBusqueda.ForeColor = EstiloVisual.TextoSecundario;
            lblEstadoBusqueda.Text = estado;
        }

        // ================================================================== agregar

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AgregarSeleccionados();
            }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AgregarSeleccionados();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarSeleccionados();
        }

        private void AgregarSeleccionados()
        {
            var productos = dgvProductos.SelectedRows
                .Cast<DataGridViewRow>()
                .OrderBy(r => r.Index)
                .Select(r => r.DataBoundItem as ProductoStockAlmacen)
                .Where(p => p != null)
                .ToList();

            if (productos.Count == 0 && dgvProductos.CurrentRow != null)
            {
                var actual = dgvProductos.CurrentRow.DataBoundItem as ProductoStockAlmacen;
                if (actual != null)
                {
                    productos.Add(actual);
                }
            }

            if (productos.Count == 0)
            {
                ResponseMessage.Message("Seleccione uno o más productos de la lista.", "INFORMATION");
                return;
            }

            int agregados = 0, repetidos = 0;
            foreach (var producto in productos)
            {
                if (AgregarLinea(TransferenciaAlmacenLinea.DesdeProducto(producto)))
                    agregados++;
                else
                    repetidos++;
            }

            lblEstadoBusqueda.ForeColor = EstiloVisual.Exito;
            lblEstadoBusqueda.Text = "✓ " + agregados + (agregados == 1 ? " producto agregado" : " productos agregados")
                + (repetidos > 0 ? "  (" + repetidos + " ya estaba" + (repetidos == 1 ? "" : "n") + " en el detalle)" : "");

            if (_detalle.Count > 0)
            {
                var ultima = dgvDetalle.Rows[_detalle.Count - 1];
                dgvDetalle.FirstDisplayedScrollingRowIndex = ultima.Index;
            }
        }

        /// <returns>false si el producto ya estaba en el detalle.</returns>
        private bool AgregarLinea(TransferenciaAlmacenLinea linea)
        {
            if (_clavesEnDetalle.Contains(linea.Clave))
            {
                return false;
            }

            _detalle.Add(linea);
            return true;
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var producto = dgvProductos.Rows[e.RowIndex].DataBoundItem as ProductoStockAlmacen;
            if (producto != null && _clavesEnDetalle.Contains(TransferenciaAlmacenLinea.ClaveProducto(producto.codNivel, producto.codGrupo, producto.codTalla, producto.codColor)))
            {
                e.CellStyle.ForeColor = EstiloVisual.Anulado;
                e.CellStyle.SelectionForeColor = EstiloVisual.Anulado;
                dgvProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Ya está en el detalle";
            }
        }

        // ================================================================== detalle

        private void dgvDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDetalle.Columns[e.ColumnIndex].Name != colDCantidad.Name)
            {
                return;
            }

            var fila = dgvDetalle.Rows[e.RowIndex];
            var linea = fila.DataBoundItem as TransferenciaAlmacenLinea;
            if (linea == null)
            {
                return;
            }

            string texto = Convert.ToString(e.FormattedValue).Trim();
            decimal cantidad;
            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out cantidad)
                && !decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out cantidad))
            {
                fila.ErrorText = "Ingrese un número válido.";
                e.Cancel = true;
            }
            else if (cantidad <= 0)
            {
                fila.ErrorText = "La cantidad debe ser mayor a cero.";
                e.Cancel = true;
            }
            else if (cantidad > linea.StockDisponible)
            {
                fila.ErrorText = "No puede superar el disponible (" + linea.StockDisponible.ToString("N3") + ").";
                e.Cancel = true;
            }
            else if (decimal.Round(cantidad, 3) != cantidad)
            {
                fila.ErrorText = "Use como máximo 3 decimales.";
                e.Cancel = true;
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvDetalle.Rows[e.RowIndex].ErrorText = string.Empty;
            }
            ActualizarResumen();
        }

        private void dgvDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            if (e.RowIndex >= 0)
            {
                dgvDetalle.Rows[e.RowIndex].ErrorText = "Valor no válido.";
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalle.Columns[e.ColumnIndex].Name == colDQuitar.Name)
            {
                QuitarLinea(e.RowIndex);
            }
        }

        private void dgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && !dgvDetalle.IsCurrentCellInEditMode && dgvDetalle.CurrentRow != null)
            {
                e.SuppressKeyPress = true;
                QuitarLinea(dgvDetalle.CurrentRow.Index);
            }
        }

        private void QuitarLinea(int indice)
        {
            if (indice < 0 || indice >= _detalle.Count)
            {
                return;
            }

            dgvDetalle.CancelEdit();
            _detalle.RemoveAt(indice);
        }

        private void ActualizarResumen()
        {
            _clavesEnDetalle.Clear();
            foreach (var linea in _detalle)
            {
                _clavesEnDetalle.Add(linea.Clave);
            }

            int productos = _detalle.Count;
            decimal unidades = _detalle.Sum(d => d.Cantidad);

            if (productos == 0)
            {
                lblResumen.Text = "Sin productos";
                lblResumen.ForeColor = EstiloVisual.TextoSecundario;
            }
            else
            {
                lblResumen.Text = string.Format("{0} {1}  ·  {2:N3} unidades  ·  {3} → {4}",
                    productos,
                    productos == 1 ? "producto" : "productos",
                    unidades,
                    AlmacenOrigen != null ? AlmacenOrigen.tResumido ?? AlmacenOrigen.Descripcion : "?",
                    AlmacenDestino != null ? AlmacenDestino.tResumido ?? AlmacenDestino.Descripcion : "?");
                lblResumen.ForeColor = EstiloVisual.Texto;
            }

            lblPaso2.Text = productos == 0 ? "2. Productos a mover" : "2. Productos a mover (" + productos + ")";
            btnGrabar.Enabled = productos > 0 && CodDestino != null;
            lblDetalleVacio.Visible = productos == 0;
            BloquearCabecera();
            dgvProductos.Invalidate();
        }

        private void CentrarMensajeDetalleVacio()
        {
            var panel = splitContenido.Panel2;
            lblDetalleVacio.Width = Math.Max(200, Math.Min(420, panel.ClientSize.Width - 40));
            lblDetalleVacio.Location = new Point(
                (panel.ClientSize.Width - lblDetalleVacio.Width) / 2,
                Math.Max(lblPaso2.Bottom + 40, (panel.ClientSize.Height - lblDetalleVacio.Height) / 2));
            lblDetalleVacio.BringToFront();
        }

        // ================================================================== grabar

        private async void btnGrabar_Click(object sender, EventArgs e)
        {
            await GrabarAsync();
        }

        private async Task GrabarAsync()
        {
            if (Ocupado || !btnGrabar.Enabled)
            {
                return;
            }

            // confirma la edición en curso (dispara la validación de la celda)
            if (dgvDetalle.IsCurrentCellInEditMode && !dgvDetalle.EndEdit())
            {
                return;
            }

            var origen = AlmacenOrigen;
            var destino = AlmacenDestino;
            if (origen == null || destino == null)
            {
                ResponseMessage.Message("Seleccione el almacén de origen y el de destino.", "INFORMATION");
                return;
            }

            var registro = new TransferenciaAlmacenRegistro
            {
                FechaTransferencia = dtpFecha.Value.Date,
                CodAlmacenOrigen = origen.Codigo,
                CodAlmacenDestino = destino.Codigo,
                Observacion = txtObservacion.Text,
                IdUsuario = UserApplication.ID_USUARIO,
                Detalle = _detalle.ToList()
            };

            string tipo = ModoActual == Modo.Devolucion ? "la devolución" : "la transferencia";
            var confirmacion = MessageBox.Show(
                string.Format("¿Registrar {0}?\n\n{1} → {2}\nFecha: {3:dd/MM/yyyy}\n{4} productos · {5:N3} unidades",
                    tipo, origen.Descripcion, destino.Descripcion, registro.FechaTransferencia,
                    registro.Detalle.Count, registro.Detalle.Sum(d => d.Cantidad)),
                "SoftCotton", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            Response respuesta = null;
            bool ok = await EjecutarGrabacionAsync(async ct =>
            {
                respuesta = await _almacenBL.RegistrarAsync(registro, ct);
            }, "Grabando y validando stock...");

            if (!ok || respuesta == null)
            {
                return;
            }

            ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);

            if (respuesta.idResponse > 0)
            {
                IdTransferenciaRegistrada = respuesta.idResponse;
                _cierreConfirmado = true;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_cierreConfirmado && !Ocupado && e.CloseReason == CloseReason.UserClosing && _detalle.Count > 0)
            {
                var respuesta = MessageBox.Show(
                    "Hay " + _detalle.Count + " productos en el detalle que no se han grabado.\n¿Desea salir sin grabar?",
                    "SoftCotton", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (respuesta != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                _cierreConfirmado = true;
            }

            if (DialogResult != DialogResult.OK && !e.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }

            base.OnFormClosing(e);
        }

        private async void RegistroTransferenciaAlmacenView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                e.SuppressKeyPress = true;
                await GrabarAsync();
            }
            else if (e.KeyCode == Keys.F3)
            {
                e.SuppressKeyPress = true;
                txtBuscarProducto.Focus();
                txtBuscarProducto.SelectAll();
            }
            else if (e.KeyCode == Keys.Escape && !dgvDetalle.IsCurrentCellInEditMode)
            {
                e.SuppressKeyPress = true;
                Close();
            }
        }
    }
}
