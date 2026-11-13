using ClosedXML.Excel;
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
