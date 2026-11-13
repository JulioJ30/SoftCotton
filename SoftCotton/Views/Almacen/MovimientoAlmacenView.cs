using SoftCotton.BusinessLogic;
using SoftCotton.Model.Almacen;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Almacen
{
    /// <summary>
    /// Listado de ingresos y salidas de almacén: consulta, alta, anulación y exportación.
    ///   Ingreso: devolución a un almacén de lo despachado con guía de remisión.
    ///   Salida : despacho de lo que ingresó a ese almacén.
    /// El detalle del movimiento seleccionado se carga en segundo plano; si el usuario cambia
    /// de fila antes de que termine, la consulta anterior se cancela.
    /// </summary>
    public partial class MovimientoAlmacenView : FormularioAsync
    {
        private readonly AlmacenBL _almacenBL = new AlmacenBL();
        private List<AlmacenItem> _almacenes = new List<AlmacenItem>();
        private CancellationTokenSource _ctsDetalle;

        public MovimientoAlmacenView()
        {
            InitializeComponent();
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            EstiloVisual.AplicarGrilla(dgvCabecera);
            EstiloVisual.AplicarGrilla(dgvDetalle);
            EstiloVisual.ColumnaCentrada(colNumero);
            EstiloVisual.ColumnaCentrada(colItems);
            EstiloVisual.ColumnaCentrada(colEstado);
            EstiloVisual.ColumnaNumero(colCantidadTotal);
            EstiloVisual.ColumnaNumero(colDetCantidad);

            EstiloVisual.BotonPrimario(btnNuevoIngreso);
            EstiloVisual.BotonSecundario(btnNuevaSalida);
            EstiloVisual.BotonPeligro(btnAnular);
            EstiloVisual.BotonSecundario(btnExportar);
            EstiloVisual.BotonPrimario(btnBuscar);

            lblCabeceraTitulo.ForeColor = EstiloVisual.Texto;
            lblDetalleTitulo.ForeColor = EstiloVisual.Texto;
            dgvCabecera.CellToolTipTextNeeded += dgvCabecera_CellToolTipTextNeeded;
        }

        private async void MovimientoAlmacenView_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-2);
            dtpHasta.Value = DateTime.Today;

            cbxTipo.DisplayMember = "Texto";
            cbxTipo.ValueMember = "Valor";
            cbxTipo.DataSource = new List<OpcionCombo>
            {
                new OpcionCombo("", "Todos"),
                new OpcionCombo(MovimientoAlmacenCab.TipoIngreso, "Ingresos"),
                new OpcionCombo(MovimientoAlmacenCab.TipoSalida, "Salidas")
            };

            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.DataSource = new List<OpcionCombo>
            {
                new OpcionCombo("", "Todos"),
                new OpcionCombo(MovimientoAlmacenCab.EstadoActivo, "Activos"),
                new OpcionCombo(MovimientoAlmacenCab.EstadoAnulado, "Anulados")
            };

            MostrarDetalleVacio();

            await EjecutarAsync(async ct =>
            {
                _almacenes = await _almacenBL.ListarAlmacenesAsync(ct);

                var opciones = new List<OpcionCombo> { new OpcionCombo("", "Todos los almacenes") };
                opciones.AddRange(_almacenes.Select(a => new OpcionCombo(a.Codigo, a.Texto)));
                cbxAlmacen.DisplayMember = "Texto";
                cbxAlmacen.ValueMember = "Valor";
                cbxAlmacen.DataSource = opciones;

                await CargarMovimientosAsync(ct, null);
            }, "Cargando movimientos...");
        }

        // ------------------------------------------------------------------ consulta

        private async Task CargarMovimientosAsync(CancellationToken ct, int? seleccionarId)
        {
            int? idActual = seleccionarId ?? Seleccionado?.IdMovimiento;

            var lista = await _almacenBL.ListarMovimientosAsync(
                dtpDesde.Value.Date,
                dtpHasta.Value.Date,
                cbxAlmacen.SelectedValue as string,
                cbxTipo.SelectedValue as string,
                cbxEstado.SelectedValue as string,
                txtBuscar.Text,
                ct);

            dgvCabecera.DataSource = lista;
            tsslTotal.Text = lista.Count == 1 ? "1 movimiento" : lista.Count + " movimientos";
            lblCabeceraTitulo.Text = lista.Count == 0
                ? "No hay movimientos con los filtros seleccionados"
                : "Movimientos registrados";

            if (idActual.HasValue)
            {
                foreach (DataGridViewRow fila in dgvCabecera.Rows)
                {
                    if (((MovimientoAlmacenCab)fila.DataBoundItem).IdMovimiento == idActual.Value)
                    {
                        dgvCabecera.CurrentCell = fila.Cells[0];
                        break;
                    }
                }
            }

            if (lista.Count == 0)
            {
                MostrarDetalleVacio();
            }

            ActualizarAcciones();
        }

        private async Task BuscarAsync()
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                ResponseMessage.Message("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "INFORMATION");
                dtpDesde.Focus();
                return;
            }

            await EjecutarAsync(ct => CargarMovimientosAsync(ct, null), "Buscando...");
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await BuscarAsync();
        }

        private async void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await BuscarAsync();
            }
        }

        // ------------------------------------------------------------------ detalle

        private MovimientoAlmacenCab Seleccionado
        {
            get { return dgvCabecera.CurrentRow?.DataBoundItem as MovimientoAlmacenCab; }
        }

        private async void dgvCabecera_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarAcciones();

            var seleccion = Seleccionado;

            // cancela la carga anterior (si el usuario se mueve rápido entre filas)
            var cts = new CancellationTokenSource();
            Interlocked.Exchange(ref _ctsDetalle, cts)?.Cancel();

            if (seleccion == null)
            {
                MostrarDetalleVacio();
                LiberarTokenDetalle(cts);
                return;
            }

            lblDetalleTitulo.Text = "Detalle del " + Nombre(seleccion) + "  ·  cargando...";

            try
            {
                await CargarDetalleAsync(seleccion, cts.Token);
            }
            finally
            {
                LiberarTokenDetalle(cts);
            }
        }

        private void LiberarTokenDetalle(CancellationTokenSource cts)
        {
            Interlocked.CompareExchange(ref _ctsDetalle, null, cts);
            cts.Dispose();
        }

        private Task<bool> CargarDetalleAsync(MovimientoAlmacenCab seleccion, CancellationToken token)
        {
            return EjecutarAsync(async ct =>
            {
                var detalle = await _almacenBL.ListarDetalleAsync(seleccion.IdMovimiento, ct);

                // si mientras tanto el usuario seleccionó otra fila, se descarta
                if (!ReferenceEquals(Seleccionado, seleccion))
                {
                    return;
                }

                colDetGuia.Visible = seleccion.EsIngreso;
                colDetDestinatario.Visible = seleccion.EsIngreso;
                dgvDetalle.DataSource = detalle;
                lblDetalleTitulo.Text = string.Format("Detalle del {0}  ·  {1} {2}{3}",
                    Nombre(seleccion),
                    seleccion.EsIngreso ? "entra a" : "sale de",
                    seleccion.Almacen,
                    seleccion.EstaAnulado ? "  ·  ANULADO: " + seleccion.MotivoAnulacion : "");
            }, null, false, token);
        }

        private static string Nombre(MovimientoAlmacenCab movimiento)
        {
            return (movimiento.EsIngreso ? "ingreso" : "salida") + " N° " + movimiento.Numero;
        }

        private void MostrarDetalleVacio()
        {
            dgvDetalle.DataSource = null;
            lblDetalleTitulo.Text = "Seleccione un movimiento para ver su detalle";
        }

        private void ActualizarAcciones()
        {
            var seleccion = Seleccionado;
            btnAnular.Enabled = seleccion != null && !seleccion.EstaAnulado;
            btnExportar.Enabled = dgvCabecera.Rows.Count > 0;
        }

        // ------------------------------------------------------------------ registro

        private void btnNuevoIngreso_Click(object sender, EventArgs e)
        {
            AbrirRegistro(RegistroMovimientoAlmacenView.Modo.Ingreso);
        }

        private void btnNuevaSalida_Click(object sender, EventArgs e)
        {
            AbrirRegistro(RegistroMovimientoAlmacenView.Modo.Salida);
        }

        private async void AbrirRegistro(RegistroMovimientoAlmacenView.Modo modo)
        {
            if (Ocupado || _almacenes.Count == 0)
            {
                return;
            }

            string almacenFiltro = cbxAlmacen.SelectedValue as string;

            int idNuevo;
            using (var registro = new RegistroMovimientoAlmacenView(modo, _almacenes, almacenFiltro))
            {
                if (registro.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                idNuevo = registro.IdMovimientoRegistrado;
            }

            // se asegura que el rango de fechas incluya lo recién registrado
            if (dtpHasta.Value.Date < DateTime.Today)
            {
                dtpHasta.Value = DateTime.Today;
            }

            await EjecutarAsync(ct => CargarMovimientosAsync(ct, idNuevo), "Actualizando...");
        }

        // ------------------------------------------------------------------ anulación

        private async void btnAnular_Click(object sender, EventArgs e)
        {
            var seleccion = Seleccionado;
            if (seleccion == null || seleccion.EstaAnulado)
            {
                return;
            }

            string efecto = seleccion.EsIngreso
                ? "Ese stock dejará de estar en el almacén y la guía volverá a quedar pendiente de ingresar."
                : "Ese stock volverá a estar disponible en el almacén.";

            string motivo = MotivoAnulacionDialog.Pedir(this,
                "Anular el " + Nombre(seleccion),
                string.Format("{0}  ·  {1} ítems  ·  {2:N3} unidades.\n{3}",
                    seleccion.Almacen, seleccion.Items, seleccion.CantidadTotal, efecto));

            if (motivo == null)
            {
                return;
            }

            Response respuesta = null;
            bool ok = await EjecutarGrabacionAsync(async ct =>
            {
                respuesta = await _almacenBL.AnularAsync(seleccion.IdMovimiento, motivo, UserApplication.ID_USUARIO, ct);
            }, "Anulando...");

            if (!ok || respuesta == null)
            {
                return;
            }

            ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);

            if (respuesta.idResponse > 0)
            {
                await EjecutarAsync(ct => CargarMovimientosAsync(ct, seleccion.IdMovimiento), "Actualizando...");
            }
        }

        // ------------------------------------------------------------------ exportación

        private async void btnExportar_Click(object sender, EventArgs e)
        {
            var lista = dgvCabecera.DataSource as List<MovimientoAlmacenCab>;
            if (lista == null || lista.Count == 0)
            {
                return;
            }

            string ruta = ExportacionExcel.PedirRuta(this, "IngresosSalidasAlmacen");
            if (ruta == null)
            {
                return;
            }

            var filas = lista.Select(t => new
            {
                Numero = t.Numero,
                Tipo = t.TipoDescripcion,
                Fecha = t.FechaMovimiento.ToString("dd/MM/yyyy"),
                Almacen = t.Almacen,
                Guias = t.Guias,
                Items = t.Items,
                Cantidad = t.CantidadTotal,
                Estado = t.EstadoDescripcion,
                RegistradoPor = t.UsuarioRegistro,
                RegistradoEl = t.FechaRegistro.ToString("dd/MM/yyyy HH:mm"),
                Observacion = t.Observacion,
                MotivoAnulacion = t.MotivoAnulacion
            }).ToList();

            var titulos = new[] { "N°", "Tipo", "Fecha", "Almacén", "Guías de origen", "Ítems", "Cantidad", "Estado", "Registrado por", "Registrado el", "Observación", "Motivo anulación" };

            bool ok = await EjecutarAsync(ct => ExportacionExcel.GenerarAsync(ruta, titulos, filas, ct), "Generando Excel...");
            if (ok)
            {
                ExportacionExcel.PreguntarAbrir(ruta);
            }
        }

        // ------------------------------------------------------------------ presentación

        private void dgvCabecera_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var item = dgvCabecera.Rows[e.RowIndex].DataBoundItem as MovimientoAlmacenCab;
            if (item == null)
            {
                return;
            }

            string columna = dgvCabecera.Columns[e.ColumnIndex].Name;

            if (item.EstaAnulado)
            {
                e.CellStyle.ForeColor = EstiloVisual.Anulado;
                e.CellStyle.SelectionForeColor = EstiloVisual.Anulado;
                if (columna != colEstado.Name)
                {
                    e.CellStyle.Font = EstiloVisual.FuenteTachada;
                }
            }

            if (columna == colEstado.Name)
            {
                e.CellStyle.Font = EstiloVisual.FuenteNegrita;
                e.CellStyle.ForeColor = item.EstaAnulado ? EstiloVisual.Peligro : EstiloVisual.Exito;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
            else if (columna == colTipo.Name && !item.EstaAnulado)
            {
                e.CellStyle.Font = EstiloVisual.FuenteNegrita;
                e.CellStyle.ForeColor = item.EsIngreso ? EstiloVisual.Exito : EstiloVisual.AlertaTexto;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
        }

        private void dgvCabecera_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var item = dgvCabecera.Rows[e.RowIndex].DataBoundItem as MovimientoAlmacenCab;
            if (item != null && item.EstaAnulado)
            {
                e.ToolTipText = string.Format("Anulado por {0} el {1:dd/MM/yyyy HH:mm}\nMotivo: {2}",
                    item.UsuarioAnulacion, item.FechaAnulacion, item.MotivoAnulacion);
            }
        }

        private async void MovimientoAlmacenView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                await BuscarAsync();
            }
            else if (e.Control && e.KeyCode == Keys.I)
            {
                e.SuppressKeyPress = true;
                AbrirRegistro(RegistroMovimientoAlmacenView.Modo.Ingreso);
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                AbrirRegistro(RegistroMovimientoAlmacenView.Modo.Salida);
            }
        }
    }
}
