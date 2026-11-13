using SoftCotton.BusinessLogic;
using SoftCotton.Model.Almacen;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Almacen
{
    /// <summary>
    /// Listado de transferencias entre almacenes: consulta, alta (transferencia/devolución),
    /// anulación y exportación. El detalle de la transferencia seleccionada se carga en
    /// segundo plano; si el usuario cambia de fila antes de que termine, la consulta
    /// anterior se cancela.
    /// </summary>
    public partial class TransferenciaAlmacenView : FormularioAsync
    {
        private readonly AlmacenBL _almacenBL = new AlmacenBL();
        private List<AlmacenItem> _almacenes = new List<AlmacenItem>();
        private CancellationTokenSource _ctsDetalle;

        public TransferenciaAlmacenView()
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

            EstiloVisual.BotonPrimario(btnNuevaTransferencia);
            EstiloVisual.BotonSecundario(btnNuevaDevolucion);
            EstiloVisual.BotonPeligro(btnAnular);
            EstiloVisual.BotonSecundario(btnExportar);
            EstiloVisual.BotonPrimario(btnBuscar);

            lblCabeceraTitulo.ForeColor = EstiloVisual.Texto;
            lblDetalleTitulo.ForeColor = EstiloVisual.Texto;
            dgvCabecera.CellToolTipTextNeeded += dgvCabecera_CellToolTipTextNeeded;
        }

        private async void TransferenciaAlmacenView_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-2);
            dtpHasta.Value = DateTime.Today;

            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.DataSource = new List<OpcionCombo>
            {
                new OpcionCombo("", "Todos"),
                new OpcionCombo(TransferenciaAlmacenCab.EstadoActivo, "Activos"),
                new OpcionCombo(TransferenciaAlmacenCab.EstadoAnulado, "Anulados")
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

                await CargarTransferenciasAsync(ct, null);
            }, "Cargando transferencias...");
        }

        // ------------------------------------------------------------------ consulta

        private async Task CargarTransferenciasAsync(CancellationToken ct, int? seleccionarId)
        {
            int? idActual = seleccionarId ?? Seleccionada?.IdTransferencia;

            var lista = await _almacenBL.ListarTransferenciasAsync(
                dtpDesde.Value.Date,
                dtpHasta.Value.Date,
                cbxAlmacen.SelectedValue as string,
                cbxEstado.SelectedValue as string,
                txtBuscar.Text,
                ct);

            dgvCabecera.DataSource = lista;
            tsslTotal.Text = lista.Count == 1 ? "1 transferencia" : lista.Count + " transferencias";
            lblCabeceraTitulo.Text = lista.Count == 0
                ? "No hay transferencias con los filtros seleccionados"
                : "Transferencias registradas";

            if (idActual.HasValue)
            {
                foreach (DataGridViewRow fila in dgvCabecera.Rows)
                {
                    if (((TransferenciaAlmacenCab)fila.DataBoundItem).IdTransferencia == idActual.Value)
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

            await EjecutarAsync(ct => CargarTransferenciasAsync(ct, null), "Buscando...");
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

        private TransferenciaAlmacenCab Seleccionada
        {
            get { return dgvCabecera.CurrentRow?.DataBoundItem as TransferenciaAlmacenCab; }
        }

        private async void dgvCabecera_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarAcciones();

            var seleccion = Seleccionada;

            // cancela la carga anterior (si el usuario se mueve rápido entre filas)
            var cts = new CancellationTokenSource();
            Interlocked.Exchange(ref _ctsDetalle, cts)?.Cancel();

            if (seleccion == null)
            {
                MostrarDetalleVacio();
                LiberarTokenDetalle(cts);
                return;
            }

            lblDetalleTitulo.Text = "Detalle de la " + seleccion.TipoDescripcion.ToLower() + " N° " + seleccion.Numero + "  ·  cargando...";

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

        private Task<bool> CargarDetalleAsync(TransferenciaAlmacenCab seleccion, CancellationToken token)
        {
            return EjecutarAsync(async ct =>
            {
                var detalle = await _almacenBL.ListarDetalleAsync(seleccion.IdTransferencia, ct);

                // si mientras tanto el usuario seleccionó otra fila, se descarta
                if (!ReferenceEquals(Seleccionada, seleccion))
                {
                    return;
                }

                dgvDetalle.DataSource = detalle;
                lblDetalleTitulo.Text = string.Format("Detalle de la {0} N° {1}  ·  {2} → {3}{4}",
                    seleccion.TipoDescripcion.ToLower(),
                    seleccion.Numero,
                    seleccion.AlmacenOrigen,
                    seleccion.AlmacenDestino,
                    seleccion.EstaAnulada ? "  ·  ANULADA: " + seleccion.MotivoAnulacion : "");
            }, null, false, token);
        }

        private void MostrarDetalleVacio()
        {
            dgvDetalle.DataSource = null;
            lblDetalleTitulo.Text = "Seleccione una transferencia para ver su detalle";
        }

        private void ActualizarAcciones()
        {
            var seleccion = Seleccionada;
            btnAnular.Enabled = seleccion != null && !seleccion.EstaAnulada;
            btnExportar.Enabled = dgvCabecera.Rows.Count > 0;
        }

        // ------------------------------------------------------------------ registro

        private void btnNuevaTransferencia_Click(object sender, EventArgs e)
        {
            AbrirRegistro(RegistroTransferenciaAlmacenView.Modo.Transferencia);
        }

        private void btnNuevaDevolucion_Click(object sender, EventArgs e)
        {
            AbrirRegistro(RegistroTransferenciaAlmacenView.Modo.Devolucion);
        }

        private async void AbrirRegistro(RegistroTransferenciaAlmacenView.Modo modo)
        {
            if (Ocupado || _almacenes.Count == 0)
            {
                return;
            }

            int idNuevo;
            using (var registro = new RegistroTransferenciaAlmacenView(modo, _almacenes))
            {
                if (registro.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                idNuevo = registro.IdTransferenciaRegistrada;
            }

            // se asegura que el rango de fechas incluya lo recién registrado
            if (dtpHasta.Value.Date < DateTime.Today)
            {
                dtpHasta.Value = DateTime.Today;
            }

            await EjecutarAsync(ct => CargarTransferenciasAsync(ct, idNuevo), "Actualizando...");
        }

        // ------------------------------------------------------------------ anulación

        private async void btnAnular_Click(object sender, EventArgs e)
        {
            var seleccion = Seleccionada;
            if (seleccion == null || seleccion.EstaAnulada)
            {
                return;
            }

            string motivo = MotivoAnulacionDialog.Pedir(this,
                string.Format("Anular la {0} N° {1}", seleccion.TipoDescripcion.ToLower(), seleccion.Numero),
                string.Format("{0} → {1}  ·  {2} ítems  ·  {3:N3} unidades.\nEl movimiento dejará de mostrarse en el Kardex y en el stock por almacén.",
                    seleccion.AlmacenOrigen, seleccion.AlmacenDestino, seleccion.Items, seleccion.CantidadTotal));

            if (motivo == null)
            {
                return;
            }

            Response respuesta = null;
            bool ok = await EjecutarGrabacionAsync(async ct =>
            {
                respuesta = await _almacenBL.AnularAsync(seleccion.IdTransferencia, motivo, UserApplication.ID_USUARIO, ct);
            }, "Anulando...");

            if (!ok || respuesta == null)
            {
                return;
            }

            ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);

            if (respuesta.idResponse > 0)
            {
                await EjecutarAsync(ct => CargarTransferenciasAsync(ct, seleccion.IdTransferencia), "Actualizando...");
            }
        }

        // ------------------------------------------------------------------ exportación

        private async void btnExportar_Click(object sender, EventArgs e)
        {
            var lista = dgvCabecera.DataSource as List<TransferenciaAlmacenCab>;
            if (lista == null || lista.Count == 0)
            {
                return;
            }

            string ruta = ExportacionExcel.PedirRuta(this, "TransferenciasAlmacen");
            if (ruta == null)
            {
                return;
            }

            var filas = lista.Select(t => new
            {
                Numero = t.Numero,
                Tipo = t.TipoDescripcion,
                Fecha = t.FechaTransferencia.ToString("dd/MM/yyyy"),
                Origen = t.AlmacenOrigen,
                Destino = t.AlmacenDestino,
                Items = t.Items,
                Cantidad = t.CantidadTotal,
                Estado = t.EstadoDescripcion,
                RegistradoPor = t.UsuarioRegistro,
                RegistradoEl = t.FechaRegistro.ToString("dd/MM/yyyy HH:mm"),
                Observacion = t.Observacion,
                MotivoAnulacion = t.MotivoAnulacion
            }).ToList();

            var titulos = new[] { "N°", "Tipo", "Fecha", "Origen", "Destino", "Ítems", "Cantidad", "Estado", "Registrado por", "Registrado el", "Observación", "Motivo anulación" };

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

            var item = dgvCabecera.Rows[e.RowIndex].DataBoundItem as TransferenciaAlmacenCab;
            if (item == null)
            {
                return;
            }

            string columna = dgvCabecera.Columns[e.ColumnIndex].Name;

            if (item.EstaAnulada)
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
                e.CellStyle.ForeColor = item.EstaAnulada ? EstiloVisual.Peligro : EstiloVisual.Exito;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
            else if (columna == colTipo.Name && !item.EstaAnulada)
            {
                e.CellStyle.ForeColor = item.TipoTransferencia == TransferenciaAlmacenCab.TipoDevolucion
                    ? EstiloVisual.AlertaTexto
                    : EstiloVisual.Primario;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
        }

        private void dgvCabecera_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var item = dgvCabecera.Rows[e.RowIndex].DataBoundItem as TransferenciaAlmacenCab;
            if (item != null && item.EstaAnulada)
            {
                e.ToolTipText = string.Format("Anulada por {0} el {1:dd/MM/yyyy HH:mm}\nMotivo: {2}",
                    item.UsuarioAnulacion, item.FechaAnulacion, item.MotivoAnulacion);
            }
        }

        private async void TransferenciaAlmacenView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                await BuscarAsync();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                e.SuppressKeyPress = true;
                AbrirRegistro(RegistroTransferenciaAlmacenView.Modo.Transferencia);
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                e.SuppressKeyPress = true;
                AbrirRegistro(RegistroTransferenciaAlmacenView.Modo.Devolucion);
            }
        }

    }
}
