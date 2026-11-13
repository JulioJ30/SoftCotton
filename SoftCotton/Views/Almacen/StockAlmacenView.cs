using SoftCotton.BusinessLogic;
using SoftCotton.Model.Almacen;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Almacen
{
    /// <summary>
    /// Reporte de stock por almacén con formato de Kardex (solo cantidades, sin precio):
    /// por almacén y producto, el saldo inicial y cada ingreso / salida del rango con el
    /// saldo acumulado al final de cada línea. La última línea de cada producto es su stock
    /// final. Estos movimientos no forman parte del Kardex contable.
    /// </summary>
    public partial class StockAlmacenView : FormularioAsync
    {
        private static readonly Color FondoGrupoAlterno = Color.FromArgb(246, 248, 251);
        private static readonly Color FondoSaldoInicial = Color.FromArgb(238, 242, 247);

        private readonly AlmacenBL _almacenBL = new AlmacenBL();
        private readonly MantenimientoBL _mantenimientoBL = new MantenimientoBL();
        private List<StockAlmacenKardex> _filas = new List<StockAlmacenKardex>();
        private DateTime _desdeConsultado;
        private DateTime _hastaConsultado;

        public StockAlmacenView()
        {
            InitializeComponent();
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            EstiloVisual.AplicarGrilla(dgvStock);
            // el color de fondo lo da el grupo (producto), no la fila alterna
            dgvStock.AlternatingRowsDefaultCellStyle.BackColor = EstiloVisual.Superficie;
            dgvStock.RowTemplate.Height = 26;

            EstiloVisual.ColumnaNumero(colIngreso);
            EstiloVisual.ColumnaNumero(colSalida);
            EstiloVisual.ColumnaNumero(colSaldo);
            EstiloVisual.ColumnaCentrada(colFecha);
            EstiloVisual.ColumnaCentrada(colNumero);
            colIngreso.DefaultCellStyle.ForeColor = EstiloVisual.Exito;
            colSalida.DefaultCellStyle.ForeColor = EstiloVisual.AlertaTexto;
            colSaldo.DefaultCellStyle.ForeColor = EstiloVisual.Primario;

            EstiloVisual.BotonPrimario(btnConsultar);
            EstiloVisual.BotonSecundario(btnExportar);

            lblProductosValor.ForeColor = EstiloVisual.Primario;
            lblUnidadesValor.ForeColor = EstiloVisual.Primario;
            lblMovimientosValor.ForeColor = EstiloVisual.Primario;
            pnlGrilla.Resize += (s, e) => CentrarSinDatos();
        }

        private async void StockAlmacenView_Load(object sender, EventArgs e)
        {
            dtpHasta.MaxDate = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            btnExportar.Enabled = false;

            bool ok = await EjecutarAsync(async ct =>
            {
                // se cargan en paralelo: almacenes (async) y niveles (método existente, síncrono)
                var tareaAlmacenes = _almacenBL.ListarAlmacenesAsync(ct);
                var tareaNiveles = Task.Run(() => _mantenimientoBL.Get16_NivelCBX(), ct);
                await Task.WhenAll(tareaAlmacenes, tareaNiveles);

                var almacenes = new List<OpcionCombo> { new OpcionCombo("", "Todos los almacenes") };
                almacenes.AddRange(tareaAlmacenes.Result.Select(a => new OpcionCombo(a.Codigo, a.Texto)));
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
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;
            if (desde > hasta)
            {
                ResponseMessage.Message("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "INFORMATION");
                dtpDesde.Focus();
                return;
            }

            string almacen = cbxAlmacen.SelectedValue as string;
            string nivel = cbxNivel.SelectedValue as string;
            string texto = txtBuscar.Text;

            await EjecutarAsync(async ct =>
            {
                _filas = await _almacenBL.ReporteStockAsync(almacen, desde, hasta, nivel, texto, ct);
                _desdeConsultado = desde;
                _hastaConsultado = hasta;
                dgvStock.DataSource = _filas;
                MostrarTotales();
            }, "Calculando stock...");
        }

        private void MostrarTotales()
        {
            var finales = _filas.Where(f => f.EsUltima).ToList();
            int productosConStock = finales.Count(f => f.Saldo != 0);
            decimal unidades = finales.Sum(f => f.Saldo);
            int movimientos = _filas.Count(f => !f.EsSaldoInicial);

            lblProductosValor.Text = productosConStock.ToString("N0");
            lblUnidadesValor.Text = unidades.ToString("N3");
            lblMovimientosValor.Text = movimientos.ToString("N0");

            tsslTotal.Text = string.Format("{0} productos  ·  {1} filas  ·  del {2:dd/MM/yyyy} al {3:dd/MM/yyyy}",
                finales.Count, _filas.Count, _desdeConsultado, _hastaConsultado);
            lblSinDatos.Visible = _filas.Count == 0;
            btnExportar.Enabled = _filas.Count > 0;
            CentrarSinDatos();
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

        // ------------------------------------------------------------------ exportación

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

            var filas = _filas.ToList();
            DateTime hasta = _hastaConsultado;

            bool ok = await EjecutarAsync(ct => ExportacionExcel.GenerarStockKardexAsync(ruta, filas, hasta, ct), "Generando Excel...");
            if (ok)
            {
                ExportacionExcel.PreguntarAbrir(ruta);
            }
        }

        // ------------------------------------------------------------------ presentación

        private static bool EsColumnaProducto(DataGridViewColumn columna)
        {
            string n = columna.Name;
            return n == "colAlmacen" || n == "colCodigo" || n == "colArticulo" || n == "colTalla" || n == "colColor" || n == "colUM";
        }

        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var fila = dgvStock.Rows[e.RowIndex].DataBoundItem as StockAlmacenKardex;
            if (fila == null)
            {
                return;
            }

            var columna = dgvStock.Columns[e.ColumnIndex];

            // como en el Kardex: los datos del producto solo en la primera fila del grupo
            if (EsColumnaProducto(columna))
            {
                if (!fila.EsPrimera)
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
                else
                {
                    e.CellStyle.Font = EstiloVisual.FuenteNegrita;
                }
            }

            // ingresos / salidas en cero se dejan en blanco para que se lea mejor
            if ((columna == colIngreso && fila.Ingreso == 0) || (columna == colSalida && fila.Salida == 0))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }

            Color fondo = fila.Grupo % 2 == 1 ? FondoGrupoAlterno : EstiloVisual.Superficie;
            if (fila.EsSaldoInicial && !EsColumnaProducto(columna))
            {
                fondo = FondoSaldoInicial;
                e.CellStyle.ForeColor = EstiloVisual.TextoSecundario;
                e.CellStyle.Font = EstiloVisual.FuenteNegrita;
            }
            e.CellStyle.BackColor = fondo;

            if (columna == colMovimiento && !fila.EsSaldoInicial)
            {
                e.CellStyle.ForeColor = fila.TipoFila == StockAlmacenKardex.FilaIngreso ? EstiloVisual.Exito : EstiloVisual.AlertaTexto;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }

            // stock final del producto (última fila del grupo)
            if (columna == colSaldo)
            {
                if (fila.EsUltima)
                {
                    e.CellStyle.Font = EstiloVisual.FuenteNegrita;
                    e.CellStyle.BackColor = Color.FromArgb(225, 236, 248);
                    dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Stock final al " + _hastaConsultado.ToString("dd/MM/yyyy");
                }
                if (fila.Saldo < 0)
                {
                    e.CellStyle.ForeColor = EstiloVisual.Peligro;
                }
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
