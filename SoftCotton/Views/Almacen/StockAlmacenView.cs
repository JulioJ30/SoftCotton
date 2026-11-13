using SoftCotton.BusinessLogic;
using SoftCotton.Model.Almacen;
using SoftCotton.Model.Maintenance;
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
    /// Reporte de stock por almacén (sobrantes ubicados fuera del almacén central).
    /// Desde aquí se puede devolver al central o mover a otro almacén las filas
    /// seleccionadas, abriendo el registro ya precargado.
    /// </summary>
    public partial class StockAlmacenView : FormularioAsync
    {
        private const string TodosSecundarios = "";

        private readonly AlmacenBL _almacenBL = new AlmacenBL();
        private readonly MantenimientoBL _mantenimientoBL = new MantenimientoBL();
        private List<AlmacenItem> _almacenes = new List<AlmacenItem>();
        private List<StockAlmacenReporte> _filas = new List<StockAlmacenReporte>();

        public StockAlmacenView()
        {
            InitializeComponent();
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            EstiloVisual.AplicarGrilla(dgvStock);
            dgvStock.MultiSelect = true;
            EstiloVisual.ColumnaNumero(colStock);
            EstiloVisual.ColumnaNumero(colStockCentral);
            EstiloVisual.ColumnaCentrada(colUltimoMovimiento);
            colStock.DefaultCellStyle.Font = EstiloVisual.FuenteNegrita;

            EstiloVisual.BotonPrimario(btnConsultar);
            EstiloVisual.BotonPrimario(btnDevolver);
            EstiloVisual.BotonSecundario(btnMover);
            EstiloVisual.BotonSecundario(btnExportar);

            lblProductosValor.ForeColor = EstiloVisual.Primario;
            lblUnidadesValor.ForeColor = EstiloVisual.Primario;
            pnlGrilla.Resize += (s, e) => CentrarSinDatos();
        }

        private async void StockAlmacenView_Load(object sender, EventArgs e)
        {
            dtpFechaCorte.MaxDate = DateTime.Today;
            dtpFechaCorte.Value = DateTime.Today;
            ActualizarAcciones();

            bool ok = await EjecutarAsync(async ct =>
            {
                // se cargan en paralelo: almacenes (async) y niveles (método existente, síncrono)
                var tareaAlmacenes = _almacenBL.ListarAlmacenesAsync(ct);
                var tareaNiveles = Task.Run(() => _mantenimientoBL.Get16_NivelCBX(), ct);
                await Task.WhenAll(tareaAlmacenes, tareaNiveles);

                _almacenes = tareaAlmacenes.Result;

                var almacenes = new List<OpcionCombo> { new OpcionCombo(TodosSecundarios, "Todos (sin el almacén central)") };
                almacenes.AddRange(_almacenes.Select(a => new OpcionCombo(a.Codigo, a.Texto)));
                cbxAlmacen.DisplayMember = "Texto";
                cbxAlmacen.ValueMember = "Valor";
                cbxAlmacen.DataSource = almacenes;

                var niveles = new List<OpcionCombo> { new OpcionCombo("", "Todos los niveles") };
                niveles.AddRange(tareaNiveles.Result.Select(n => new OpcionCombo(n.codNivel, n.codNivel + " - " + n.nivel)));
                cbxNivel.DisplayMember = "Texto";
                cbxNivel.ValueMember = "Valor";
                cbxNivel.DataSource = niveles;
            }, "Preparando...");

            if (ok)
            {
                await ConsultarAsync();
            }
        }

        // ------------------------------------------------------------------ consulta

        private async Task ConsultarAsync()
        {
            string almacen = cbxAlmacen.SelectedValue as string;
            string nivel = cbxNivel.SelectedValue as string;

            if (almacen == AlmacenItem.CodigoCentral && string.IsNullOrEmpty(nivel))
            {
                ResponseMessage.Message("El almacén central incluye todo el Kardex. Seleccione un nivel para consultarlo.", "INFORMATION");
                cbxNivel.Focus();
                return;
            }

            DateTime fecha = dtpFechaCorte.Value.Date;
            string texto = txtBuscar.Text;

            await EjecutarAsync(async ct =>
            {
                _filas = await _almacenBL.ReporteStockAsync(almacen, fecha, nivel, texto, ct);
                dgvStock.DataSource = _filas;
                MostrarTotales(fecha);
            }, "Calculando stock...");
        }

        private void MostrarTotales(DateTime fecha)
        {
            int alertas = _filas.Count(f => f.TieneAlerta);

            lblProductosValor.Text = _filas.Count.ToString("N0");
            lblUnidadesValor.Text = _filas.Sum(f => f.Stock).ToString("N3");
            lblAlertasValor.Text = alertas.ToString("N0");
            lblAlertasValor.ForeColor = alertas > 0 ? EstiloVisual.AlertaTexto : EstiloVisual.Exito;
            pnlTarjetaAlertas.BackColor = alertas > 0 ? EstiloVisual.Alerta : EstiloVisual.Superficie;
            tsslLeyenda.Visible = alertas > 0;

            tsslTotal.Text = (_filas.Count == 1 ? "1 fila" : _filas.Count + " filas") + "  ·  stock al " + fecha.ToString("dd/MM/yyyy");
            lblSinDatos.Visible = _filas.Count == 0;
            CentrarSinDatos();
            ActualizarAcciones();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            await ConsultarAsync();
        }

        private async void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await ConsultarAsync();
            }
        }

        // ------------------------------------------------------------------ acciones

        private List<StockAlmacenReporte> FilasSeleccionadas()
        {
            var filas = dgvStock.SelectedRows
                .Cast<DataGridViewRow>()
                .OrderBy(r => r.Index)
                .Select(r => r.DataBoundItem as StockAlmacenReporte)
                .Where(f => f != null)
                .ToList();

            if (filas.Count == 0 && dgvStock.CurrentRow != null && dgvStock.CurrentRow.DataBoundItem is StockAlmacenReporte)
            {
                filas.Add((StockAlmacenReporte)dgvStock.CurrentRow.DataBoundItem);
            }

            return filas;
        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarAcciones();
        }

        private void ActualizarAcciones()
        {
            var filas = FilasSeleccionadas();
            bool mismoAlmacen = filas.Count > 0 && filas.Select(f => f.CodAlmacen).Distinct().Count() == 1;
            bool desdeSecundario = mismoAlmacen && filas[0].CodAlmacen != AlmacenItem.CodigoCentral;
            bool conStock = filas.All(f => f.Stock > 0);

            btnDevolver.Enabled = desdeSecundario && conStock;
            btnMover.Enabled = mismoAlmacen && conStock;
            btnExportar.Enabled = _filas.Count > 0;

            lblAyudaAcciones.Text = filas.Count > 1 && !mismoAlmacen
                ? "Las filas seleccionadas son de distintos almacenes: seleccione filas de un solo almacén."
                : "Seleccione una o varias filas de un mismo almacén (Ctrl/Shift + clic).";
            lblAyudaAcciones.ForeColor = filas.Count > 1 && !mismoAlmacen ? EstiloVisual.AlertaTexto : EstiloVisual.TextoSecundario;
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            AbrirRegistro(RegistroTransferenciaAlmacenView.Modo.Devolucion);
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            AbrirRegistro(RegistroTransferenciaAlmacenView.Modo.Transferencia);
        }

        private async void AbrirRegistro(RegistroTransferenciaAlmacenView.Modo modo)
        {
            var filas = FilasSeleccionadas();
            if (filas.Count == 0 || Ocupado)
            {
                return;
            }

            string origen = filas[0].CodAlmacen;
            var lineas = filas.Select(TransferenciaAlmacenLinea.DesdeStock).ToList();

            using (var registro = new RegistroTransferenciaAlmacenView(modo, _almacenes, origen, lineas))
            {
                if (registro.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
            }

            await ConsultarAsync();
        }

        private async void btnExportar_Click(object sender, EventArgs e)
        {
            if (_filas.Count == 0)
            {
                return;
            }

            string ruta = ExportacionExcel.PedirRuta(this, "StockPorAlmacen");
            if (ruta == null)
            {
                return;
            }

            var filas = _filas.Select(f => new
            {
                Almacen = f.Almacen,
                Codigo = f.Codigo,
                Nivel = f.Nivel,
                Articulo = f.Articulo,
                Talla = f.Talla,
                Color = f.Color,
                UM = f.UM,
                Stock = f.Stock,
                StockCentral = f.StockCentral,
                UltimoMovimiento = f.FechaUltimoMovimiento.HasValue ? f.FechaUltimoMovimiento.Value.ToString("dd/MM/yyyy") : "",
                Observacion = f.TieneAlerta ? "Central negativo: registrar devolución" : ""
            }).ToList();

            var titulos = new[] { "Almacén", "Código", "Nivel", "Artículo", "Talla", "Color", "UM", "Stock", "Stock en central", "Último mov.", "Observación" };

            bool ok = await EjecutarAsync(ct => ExportacionExcel.GenerarAsync(ruta, titulos, filas, ct), "Generando Excel...");
            if (ok)
            {
                ExportacionExcel.PreguntarAbrir(ruta);
            }
        }

        // ------------------------------------------------------------------ presentación

        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var fila = dgvStock.Rows[e.RowIndex].DataBoundItem as StockAlmacenReporte;
            if (fila == null)
            {
                return;
            }

            if (fila.TieneAlerta)
            {
                e.CellStyle.BackColor = EstiloVisual.Alerta;
                if (dgvStock.Columns[e.ColumnIndex].Name == colStockCentral.Name)
                {
                    e.CellStyle.ForeColor = EstiloVisual.AlertaTexto;
                    e.CellStyle.Font = EstiloVisual.FuenteNegrita;
                    dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText =
                        "El central quedó negativo: este producto se despachó con guía sin registrar antes la devolución desde " + fila.Almacen + ".";
                }
            }
            else if (fila.Stock < 0 && dgvStock.Columns[e.ColumnIndex].Name == colStock.Name)
            {
                e.CellStyle.ForeColor = EstiloVisual.Peligro;
            }
        }

        private void CentrarSinDatos()
        {
            lblSinDatos.Location = new Point(
                Math.Max(0, (pnlGrilla.ClientSize.Width - lblSinDatos.Width) / 2),
                Math.Max(40, (pnlGrilla.ClientSize.Height - lblSinDatos.Height) / 2));
            lblSinDatos.BringToFront();
        }

        private async void StockAlmacenView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                await ConsultarAsync();
            }
        }
    }
}
