using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.Repository;
using Excel = Microsoft.Office.Interop.Excel;

namespace SoftCotton.Views.Maintenance
{
    public partial class LogRegistros : Form
    {
        public LogRegistros()
        {
            InitializeComponent();
        }

        private void LogRegistros_Load(object sender, EventArgs e)
        {
            List<TipoEntidad> tipoEntidads = new List<TipoEntidad>();
            tipoEntidads.Add(new TipoEntidad { Tipo = "grCab" ,Desc ="Guia"});
            tipoEntidads.Add(new TipoEntidad { Tipo = "facCab",Desc="Factura" });
            tipoEntidads.Add(new TipoEntidad { Tipo = "osCab", Desc = "Orden Servicio" });
            tipoEntidads.Add(new TipoEntidad { Tipo = "ocCab", Desc = "Orden Compra" });


            cboBusqueda.DataSource = tipoEntidads;
            cboBusqueda.ValueMember = "Tipo";
            cboBusqueda.DisplayMember = "Desc";


        }

        private void Busqueda()
        {
            MantenimientoRepository mantenimientoRepository = new MantenimientoRepository();

            string tipo = cboBusqueda.SelectedValue.ToString();
            string filtro = txtFiltro.Text.ToString();

            dgvDatos.DataSource = mantenimientoRepository.GetAuditorias(tipo,filtro);
        }

        private void Exportar()
        {
            try
            {
                // Crear aplicación de Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                // Encabezados
                for (int i = 0; i < dgvDatos.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvDatos.Columns[i].HeaderText;
                }

                // Datos
                for (int i = 0; i < dgvDatos.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvDatos.Columns.Count; j++)
                    {
                        if (dgvDatos.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvDatos.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                MessageBox.Show("Exportación a Excel completada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }
    }


    public class TipoEntidad
    {
        public string Tipo { get; set; }
        public string Desc { get; set; }

    }
}
