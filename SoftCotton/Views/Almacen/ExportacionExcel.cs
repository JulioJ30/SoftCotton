using ClosedXML.Excel;
using SoftCotton.Model.Almacen;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Almacen
{
    /// <summary>
    /// Exportación a Excel de las grillas del módulo, en segundo plano (Task.Run) para no
    /// congelar la interfaz mientras ClosedXML genera el archivo.
    /// </summary>
    internal static class ExportacionExcel
    {
        public static string PedirRuta(IWin32Window owner, string nombreSugerido)
        {
            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Libro de Excel (*.xlsx)|*.xlsx";
                dialogo.FileName = nombreSugerido + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";
                dialogo.OverwritePrompt = true;
                return dialogo.ShowDialog(owner) == DialogResult.OK ? dialogo.FileName : null;
            }
        }

        public static Task GenerarAsync<T>(string ruta, IEnumerable<string> titulos, List<T> filas, CancellationToken ct)
        {
            var encabezados = titulos.Select(t => new ExcelReportTitulo
            {
                titulo = t,
                backgroundColor = XLColor.FromArgb(31, 95, 158),
                foreColor = XLColor.White
            }).ToArray();

            return Task.Run(() => ExcelReport.GetExcelReport(ruta, encabezados, filas), ct);
        }

        /// <summary>
        /// Reporte de stock por almacén con formato de Kardex: las filas de cada producto
        /// (saldo inicial + movimientos) y, al final de cada producto, una fila STOCK FINAL
        /// con una línea separadora antes del siguiente producto.
        /// </summary>
        public static Task GenerarStockKardexAsync(string ruta, List<StockAlmacenKardex> filas, DateTime hasta, CancellationToken ct)
        {
            return Task.Run(() => GenerarStockKardex(ruta, filas, hasta), ct);
        }

        private static void GenerarStockKardex(string ruta, List<StockAlmacenKardex> filas, DateTime hasta)
        {
            var titulos = new[] { "Almacén", "Código", "Nivel", "Artículo", "Talla", "Color", "UM", "Fecha", "Movimiento", "N°",
                "Guía de origen", "Destinatario de la guía", "Observación", "Ingreso", "Salida", "Saldo" };
            const int colIngreso = 14, colSalida = 15, colSaldo = 16;
            int ultimaColumna = titulos.Length;

            var azul = XLColor.FromArgb(31, 95, 158);
            var fondoSaldoInicial = XLColor.FromArgb(238, 242, 247);
            var fondoStockFinal = XLColor.FromArgb(221, 235, 247);

            using (var libro = new XLWorkbook())
            {
                var hoja = libro.Worksheets.Add("Stock por almacén");

                for (int i = 0; i < titulos.Length; i++)
                {
                    hoja.Cell(1, i + 1).Value = titulos[i];
                }
                var encabezado = hoja.Range(1, 1, 1, ultimaColumna);
                encabezado.Style.Font.Bold = true;
                encabezado.Style.Font.FontColor = XLColor.White;
                encabezado.Style.Fill.BackgroundColor = azul;
                encabezado.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

                int r = 2;
                for (int i = 0; i < filas.Count; i++)
                {
                    var f = filas[i];

                    // datos del producto solo en la primera fila del producto (como en el Kardex)
                    if (f.EsPrimera)
                    {
                        hoja.Cell(r, 1).Value = f.Almacen ?? "";
                        hoja.Cell(r, 2).Value = f.Codigo ?? "";
                        hoja.Cell(r, 3).Value = f.Nivel ?? "";
                        hoja.Cell(r, 4).Value = f.Articulo ?? "";
                        hoja.Cell(r, 5).Value = f.Talla ?? "";
                        hoja.Cell(r, 6).Value = f.Color ?? "";
                        hoja.Cell(r, 7).Value = f.UM ?? "";
                        hoja.Range(r, 1, r, 7).Style.Font.Bold = true;
                    }

                    if (f.Fecha.HasValue)
                    {
                        hoja.Cell(r, 8).Value = f.Fecha.Value;
                        hoja.Cell(r, 8).Style.DateFormat.Format = "dd/MM/yyyy";
                    }
                    hoja.Cell(r, 9).Value = f.Movimiento ?? "";
                    hoja.Cell(r, 10).Value = f.Numero ?? "";
                    hoja.Cell(r, 11).Value = f.Guia ?? "";
                    hoja.Cell(r, 12).Value = f.Destinatario ?? "";
                    hoja.Cell(r, 13).Value = f.Observacion ?? "";
                    if (f.Ingreso != 0) hoja.Cell(r, colIngreso).Value = f.Ingreso;
                    if (f.Salida != 0) hoja.Cell(r, colSalida).Value = f.Salida;
                    hoja.Cell(r, colSaldo).Value = f.Saldo;

                    if (f.EsSaldoInicial)
                    {
                        var rango = hoja.Range(r, 8, r, ultimaColumna);
                        rango.Style.Fill.BackgroundColor = fondoSaldoInicial;
                        rango.Style.Font.Italic = true;
                    }
                    else
                    {
                        hoja.Cell(r, 9).Style.Font.FontColor = f.TipoFila == StockAlmacenKardex.FilaIngreso
                            ? XLColor.FromArgb(25, 135, 84)
                            : XLColor.FromArgb(133, 100, 4);
                    }
                    r++;

                    // fin del producto: fila STOCK FINAL + línea separadora
                    if (f.EsUltima)
                    {
                        hoja.Cell(r, 1).Value = "STOCK FINAL al " + hasta.ToString("dd/MM/yyyy") + "  ·  " + f.Codigo + "  " + f.Articulo
                            + (string.IsNullOrWhiteSpace(f.Color) ? "" : "  ·  " + f.Color);
                        hoja.Range(r, 1, r, colSaldo - 1).Merge();
                        hoja.Cell(r, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        hoja.Cell(r, colSaldo).Value = f.Saldo;

                        var rangoFinal = hoja.Range(r, 1, r, ultimaColumna);
                        rangoFinal.Style.Font.Bold = true;
                        rangoFinal.Style.Fill.BackgroundColor = fondoStockFinal;
                        rangoFinal.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        rangoFinal.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                        rangoFinal.Style.Border.BottomBorderColor = azul;
                        if (f.Saldo < 0)
                        {
                            hoja.Cell(r, colSaldo).Style.Font.FontColor = XLColor.FromArgb(192, 41, 41);
                        }
                        r++;
                    }
                }

                if (r > 2)
                {
                    hoja.Range(2, colIngreso, r - 1, colSaldo).Style.NumberFormat.Format = "#,##0.000";
                    hoja.Range(2, 10, r - 1, 11).Style.NumberFormat.Format = "@";
                }

                hoja.SheetView.FreezeRows(1);
                hoja.Columns(1, ultimaColumna).AdjustToContents();
                hoja.Column(4).Width = Math.Min(hoja.Column(4).Width, 60);
                hoja.Column(12).Width = Math.Min(hoja.Column(12).Width, 40);
                hoja.Column(13).Width = Math.Min(hoja.Column(13).Width, 40);

                libro.SaveAs(ruta);
            }
        }

        public static void PreguntarAbrir(string ruta)
        {
            if (MessageBox.Show("Archivo generado:\n" + ruta + "\n\n¿Desea abrirlo?", "SoftCotton",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Process.Start(ruta);
            }
            catch (Exception ex)
            {
                ResponseMessage.Message("No se pudo abrir el archivo: " + ex.Message, "WARNING");
            }
        }
    }
}
