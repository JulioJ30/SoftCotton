using SoftCotton.BusinessLogic;
using SoftCotton.Model.Almacen;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections;
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
    /// Registro de un ingreso o una salida de almacén.
    ///
    /// INGRESO: devuelve a un almacén stock DESPACHADO con guía de remisión. Se buscan las
    /// líneas de guía (salidas) con cantidad pendiente de ingresar; cada línea del detalle
    /// queda ligada a su línea de guía y no puede superar lo pendiente.
    ///
    /// SALIDA: despacha stock de un almacén. Solo se listan los productos con stock en ese
    /// almacén a la fecha (lo ingresado menos lo que ya salió).
    ///
    /// Búsqueda en segundo plano mientras se escribe (cancelando la anterior); al grabar,
    /// cabecera + detalle viajan en una sola llamada y una sola transacción.
    /// </summary>
    public partial class RegistroMovimientoAlmacenView : FormularioAsync
    {
        public enum Modo
        {
            Ingreso,
            Salida
        }

        private const int MaximoResultados = 500;

        private readonly Modo _modo;
        private readonly AlmacenBL _almacenBL = new AlmacenBL();
        private readonly MantenimientoBL _mantenimientoBL = new MantenimientoBL();
        private readonly List<AlmacenItem> _almacenes;
        private readonly string _almacenInicial;
        private readonly BindingList<MovimientoAlmacenLinea> _detalle = new BindingList<MovimientoAlmacenLinea>();
        private readonly HashSet<string> _clavesEnDetalle = new HashSet<string>();

        private CancellationTokenSource _ctsBusqueda;
        private bool _inicializando = true;
        private bool _cierreConfirmado;

        /// <summary>Id del movimiento grabado (cuando DialogResult = OK).</summary>
        public int IdMovimientoRegistrado { get; private set; }

        // Constructor sin parámetros requerido por el diseñador de Visual Studio
        public RegistroMovimientoAlmacenView()
            : this(Modo.Ingreso, new List<AlmacenItem>(), null)
        {
        }

        public RegistroMovimientoAlmacenView(Modo modo, List<AlmacenItem> almacenes, string codAlmacenInicial)
        {
            InitializeComponent();

            _modo = modo;
            _almacenes = almacenes ?? new List<AlmacenItem>();
            _almacenInicial = codAlmacenInicial;

            AplicarEstilos();

            dgvDetalle.DataSource = _detalle;
            _detalle.ListChanged += (s, e) => ActualizarResumen();
            splitContenido.Panel2.Resize += (s, e) => CentrarMensajeDetalleVacio();
        }

        private bool EsIngreso
        {
            get { return _modo == Modo.Ingreso; }
        }

        private AlmacenItem AlmacenSeleccionado
        {
            get { return cbxAlmacen.SelectedItem as AlmacenItem; }
        }

        // ================================================================== inicio

        private void AplicarEstilos()
        {
            EstiloVisual.AplicarGrilla(dgvBusqueda);
            EstiloVisual.AplicarGrilla(dgvDetalle, soloLectura: false);
            dgvBusqueda.MultiSelect = true;
            EstiloVisual.ColumnaNumero(colBDespachado);
            EstiloVisual.ColumnaNumero(colBIngresado);
            EstiloVisual.ColumnaNumero(colBDisponible);
            EstiloVisual.ColumnaCentrada(colBFechaGuia);
            EstiloVisual.ColumnaNumero(colDDisponible);
            EstiloVisual.ColumnaNumero(colDCantidad);
            colBDisponible.DefaultCellStyle.Font = EstiloVisual.FuenteNegrita;

            // columnas editables resaltadas
            var editable = Color.FromArgb(255, 251, 230);
            colDCantidad.DefaultCellStyle.BackColor = editable;
            colDComentario.DefaultCellStyle.BackColor = editable;
            colDCantidad.DefaultCellStyle.Font = EstiloVisual.FuenteNegrita;
            colDDisponible.DefaultCellStyle.ForeColor = EstiloVisual.TextoSecundario;

            colDQuitar.FlatStyle = FlatStyle.Flat;
            colDQuitar.DefaultCellStyle.ForeColor = EstiloVisual.Peligro;
            colDQuitar.DefaultCellStyle.SelectionForeColor = EstiloVisual.Peligro;

            EstiloVisual.BotonPrimario(btnGrabar);
            EstiloVisual.BotonSecundario(btnCancelar);
            EstiloVisual.BotonPrimario(btnAgregar);

            lnkCambiar.LinkColor = EstiloVisual.Primario;
            lblDetalleVacio.BackColor = EstiloVisual.Superficie;
        }

        /// <summary>Textos y columnas según sea ingreso o salida.</summary>
        private void ConfigurarModo()
        {
            if (EsIngreso)
            {
                Text = "Registro de ingreso a almacén";
                lblTitulo.Text = "Nuevo ingreso a almacén";
                lblSubtitulo.Text = "Devuelve a un almacén stock despachado con guía de remisión. Solo puede ingresar lo pendiente de cada línea de guía.";
                lblAlmacen.Text = "Entra a (almacén)";
                lblPaso1.Text = "1. Busque las guías despachadas";
                lblPaso2.Text = "2. Líneas a ingresar";
                colBDisponible.HeaderText = "Pendiente";
                colDDisponible.HeaderText = "Pendiente";
                toolTip.SetToolTip(txtBuscar, "Busca por N° de guía, destinatario, código, artículo o color mientras escribe (F3)");
            }
            else
            {
                Text = "Registro de salida de almacén";
                lblTitulo.Text = "Nueva salida de almacén";
                lblSubtitulo.Text = "Despacha stock de un almacén. Solo puede salir lo que ingresó a ese almacén.";
                lblAlmacen.Text = "Sale de (almacén)";
                lblPaso2.Text = "2. Productos a despachar";
                colBDisponible.HeaderText = "Stock";
                colDDisponible.HeaderText = "Stock";
                toolTip.SetToolTip(txtBuscar, "Busca por código, artículo o color mientras escribe (F3)");

                // sin guías: se ocultan los filtros y columnas de guía
                foreach (var columna in new DataGridViewColumn[] { colBGuia, colBFechaGuia, colBDestinatario, colBDespachado, colBIngresado, colDGuia })
                {
                    columna.Visible = false;
                }
                dtpGuiaDesde.Visible = false;
                dtpGuiaHasta.Visible = false;
                tlpBusqueda.ColumnStyles[0].Width = 0;
                tlpBusqueda.ColumnStyles[1].Width = 0;
            }
        }

        private async void RegistroMovimientoAlmacenView_Load(object sender, EventArgs e)
        {
            dtpFecha.MaxDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;
            dtpGuiaHasta.Value = DateTime.Today;
            dtpGuiaDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-2);

            ConfigurarModo();

            cbxAlmacen.DisplayMember = "Texto";
            cbxAlmacen.ValueMember = "Codigo";
            cbxAlmacen.DataSource = _almacenes;
            int indice = _almacenes.FindIndex(a => a.Codigo == _almacenInicial);
            cbxAlmacen.SelectedIndex = indice >= 0 ? indice : (_almacenes.Count > 0 ? 0 : -1);

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
            ActualizarPaso1();
            ActualizarResumen();
            CentrarMensajeDetalleVacio();
            Buscar();
            txtBuscar.Focus();
        }

        // ================================================================== cabecera

        private void ActualizarPaso1()
        {
            if (!EsIngreso)
            {
                lblPaso1.Text = "1. Busque productos con stock en " + (AlmacenSeleccionado != null ? AlmacenSeleccionado.Descripcion : "el almacén");
            }
        }

        private void cbxAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ActualizarPaso1();
            ActualizarResumen();
            if (!EsIngreso)
            {
                Buscar();
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!_inicializando && !EsIngreso)
            {
                ProgramarBusqueda();
            }
        }

        private void filtroGuia_ValueChanged(object sender, EventArgs e)
        {
            if (!_inicializando && EsIngreso)
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
                "El stock disponible depende del almacén y de la fecha.\n\n" +
                "Para cambiarlos se quitarán las " + _detalle.Count + " líneas del detalle. ¿Continuar?",
                "SoftCotton", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                _detalle.Clear();
                cbxAlmacen.Focus();
            }
        }

        /// <summary>
        /// En una salida, con productos en el detalle el almacén y la fecha quedan fijos (el
        /// stock disponible depende de ellos). En un ingreso lo pendiente es de la guía, así
        /// que se pueden cambiar libremente.
        /// </summary>
        private void BloquearCabecera()
        {
            bool bloquear = !EsIngreso && _detalle.Count > 0;
            dtpFecha.Enabled = !bloquear;
            cbxAlmacen.Enabled = !bloquear;
            lnkCambiar.Visible = bloquear;
        }

        // ================================================================== búsqueda

        private void cbxNivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ProgramarBusqueda();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Buscar();
            }
            else if (e.KeyCode == Keys.Down && dgvBusqueda.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                dgvBusqueda.Focus();
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
            Buscar();
        }

        private async void Buscar()
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
                string nivel = cbxNivel.SelectedValue as string;
                string texto = txtBuscar.Text;

                if (EsIngreso)
                {
                    DateTime desde = dtpGuiaDesde.Value.Date;
                    DateTime hasta = dtpGuiaHasta.Value.Date;
                    if (desde > hasta)
                    {
                        MostrarResultados(null, "La fecha 'desde' de las guías no puede ser mayor que la fecha 'hasta'.");
                        return;
                    }

                    lblEstadoBusqueda.Text = "Buscando guías despachadas...";
                    await EjecutarAsync(async ct =>
                    {
                        var lista = await _almacenBL.BuscarGuiasPendientesAsync(desde, hasta, nivel, texto, ct);
                        ct.ThrowIfCancellationRequested();

                        string estado;
                        if (lista.Count == 0)
                            estado = "No hay líneas de guía con saldo pendiente de ingresar para esta búsqueda.";
                        else if (lista.Count >= MaximoResultados)
                            estado = "Se muestran las primeras " + MaximoResultados + " líneas. Escriba para afinar la búsqueda.";
                        else
                            estado = lista.Count + (lista.Count == 1 ? " línea de guía pendiente" : " líneas de guía pendientes")
                                + " entre el " + desde.ToString("dd/MM/yyyy") + " y el " + hasta.ToString("dd/MM/yyyy");

                        MostrarResultados(lista, estado);
                    }, null, false, cts.Token);
                }
                else
                {
                    var almacen = AlmacenSeleccionado;
                    DateTime fecha = dtpFecha.Value.Date;
                    if (almacen == null)
                    {
                        MostrarResultados(null, "Seleccione el almacén.");
                        return;
                    }

                    lblEstadoBusqueda.Text = "Buscando en " + almacen.Descripcion + "...";
                    await EjecutarAsync(async ct =>
                    {
                        var lista = await _almacenBL.BuscarProductosConStockAsync(almacen.Codigo, fecha, nivel, texto, ct);
                        ct.ThrowIfCancellationRequested();

                        string estado;
                        if (lista.Count == 0)
                            estado = "No hay productos con stock en " + almacen.Descripcion + " para esta búsqueda. Solo puede salir lo ingresado a este almacén.";
                        else if (lista.Count >= MaximoResultados)
                            estado = "Se muestran los primeros " + MaximoResultados + " productos. Escriba para afinar la búsqueda.";
                        else
                            estado = lista.Count + (lista.Count == 1 ? " producto con stock" : " productos con stock") + " al " + fecha.ToString("dd/MM/yyyy");

                        MostrarResultados(lista, estado);
                    }, null, false, cts.Token);
                }
            }
            finally
            {
                Interlocked.CompareExchange(ref _ctsBusqueda, null, cts);
                cts.Dispose();
            }
        }

        private void MostrarResultados(IList lista, string estado)
        {
            dgvBusqueda.DataSource = lista;
            lblEstadoBusqueda.ForeColor = EstiloVisual.TextoSecundario;
            lblEstadoBusqueda.Text = estado;
        }

        // ================================================================== agregar

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AgregarSeleccionados();
            }
        }

        private void dgvBusqueda_KeyDown(object sender, KeyEventArgs e)
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

        private static MovimientoAlmacenLinea ALinea(object item)
        {
            var guia = item as GuiaDespachoPendiente;
            if (guia != null)
            {
                return MovimientoAlmacenLinea.DesdeGuia(guia);
            }

            var producto = item as ProductoStockAlmacen;
            return producto != null ? MovimientoAlmacenLinea.DesdeProducto(producto) : null;
        }

        private void AgregarSeleccionados()
        {
            var lineas = dgvBusqueda.SelectedRows
                .Cast<DataGridViewRow>()
                .OrderBy(r => r.Index)
                .Select(r => ALinea(r.DataBoundItem))
                .Where(l => l != null)
                .ToList();

            if (lineas.Count == 0 && dgvBusqueda.CurrentRow != null)
            {
                var actual = ALinea(dgvBusqueda.CurrentRow.DataBoundItem);
                if (actual != null)
                {
                    lineas.Add(actual);
                }
            }

            if (lineas.Count == 0)
            {
                ResponseMessage.Message("Seleccione una o más filas de la lista.", "INFORMATION");
                return;
            }

            int agregados = 0, repetidos = 0;
            foreach (var linea in lineas)
            {
                if (AgregarLinea(linea))
                    agregados++;
                else
                    repetidos++;
            }

            lblEstadoBusqueda.ForeColor = EstiloVisual.Exito;
            lblEstadoBusqueda.Text = "✓ " + agregados + (agregados == 1 ? " línea agregada" : " líneas agregadas")
                + (repetidos > 0 ? "  (" + repetidos + " ya estaba" + (repetidos == 1 ? "" : "n") + " en el detalle)" : "");

            if (_detalle.Count > 0)
            {
                dgvDetalle.FirstDisplayedScrollingRowIndex = _detalle.Count - 1;
            }
        }

        /// <returns>false si la línea ya estaba en el detalle.</returns>
        private bool AgregarLinea(MovimientoAlmacenLinea linea)
        {
            if (_clavesEnDetalle.Contains(linea.Clave))
            {
                return false;
            }

            _detalle.Add(linea);
            return true;
        }

        private void dgvBusqueda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var linea = ALinea(dgvBusqueda.Rows[e.RowIndex].DataBoundItem);
            if (linea != null && _clavesEnDetalle.Contains(linea.Clave))
            {
                e.CellStyle.ForeColor = EstiloVisual.Anulado;
                e.CellStyle.SelectionForeColor = EstiloVisual.Anulado;
                dgvBusqueda.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Ya está en el detalle";
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
            var linea = fila.DataBoundItem as MovimientoAlmacenLinea;
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
            else if (cantidad > linea.Disponible)
            {
                fila.ErrorText = "No puede superar " + (EsIngreso ? "lo pendiente de la guía" : "el stock del almacén")
                    + " (" + linea.Disponible.ToString("N3") + ").";
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

            int lineas = _detalle.Count;
            decimal unidades = _detalle.Sum(d => d.Cantidad);
            var almacen = AlmacenSeleccionado;

            if (lineas == 0)
            {
                lblResumen.Text = EsIngreso ? "Sin líneas de guía" : "Sin productos";
                lblResumen.ForeColor = EstiloVisual.TextoSecundario;
            }
            else
            {
                string guias = EsIngreso
                    ? "  ·  " + _detalle.Select(d => d.Guia).Distinct().Count() + " guía(s)"
                    : "";
                lblResumen.Text = string.Format("{0} {1}{2}  ·  {3:N3} unidades  ·  {4} {5}",
                    lineas,
                    lineas == 1 ? "línea" : "líneas",
                    guias,
                    unidades,
                    EsIngreso ? "entra a" : "sale de",
                    almacen != null ? almacen.NombreCorto : "?");
                lblResumen.ForeColor = EstiloVisual.Texto;
            }

            string titulo = EsIngreso ? "2. Líneas a ingresar" : "2. Productos a despachar";
            lblPaso2.Text = lineas == 0 ? titulo : titulo + " (" + lineas + ")";
            btnGrabar.Enabled = lineas > 0 && almacen != null;
            lblDetalleVacio.Visible = lineas == 0;
            BloquearCabecera();
            dgvBusqueda.Invalidate();
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

            var almacen = AlmacenSeleccionado;
            if (almacen == null)
            {
                ResponseMessage.Message("Seleccione el almacén.", "INFORMATION");
                return;
            }

            var registro = new MovimientoAlmacenRegistro
            {
                TipoMovimiento = EsIngreso ? MovimientoAlmacenCab.TipoIngreso : MovimientoAlmacenCab.TipoSalida,
                FechaMovimiento = dtpFecha.Value.Date,
                CodAlmacen = almacen.Codigo,
                Observacion = txtObservacion.Text,
                IdUsuario = UserApplication.ID_USUARIO,
                Detalle = _detalle.ToList()
            };

            var confirmacion = MessageBox.Show(
                string.Format("¿Registrar {0}?\n\n{1} {2}\nFecha: {3:dd/MM/yyyy}\n{4} líneas · {5:N3} unidades",
                    EsIngreso ? "el ingreso" : "la salida",
                    EsIngreso ? "Entra a:" : "Sale de:",
                    almacen.Descripcion, registro.FechaMovimiento,
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
                IdMovimientoRegistrado = respuesta.idResponse;
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
                    "Hay " + _detalle.Count + " líneas en el detalle que no se han grabado.\n¿Desea salir sin grabar?",
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

        private async void RegistroMovimientoAlmacenView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                e.SuppressKeyPress = true;
                await GrabarAsync();
            }
            else if (e.KeyCode == Keys.F3)
            {
                e.SuppressKeyPress = true;
                txtBuscar.Focus();
                txtBuscar.SelectAll();
            }
            else if (e.KeyCode == Keys.Escape && !dgvDetalle.IsCurrentCellInEditMode)
            {
                e.SuppressKeyPress = true;
                Close();
            }
        }
    }
}
