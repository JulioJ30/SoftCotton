using ClosedXML.Excel;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.Maintenance
{
    public partial class ReporteProductoView : Form
    {
        MantenimientoBL _mantenimientoBL;
        List<GetMantRpte2_Productos> lista;

        public ReporteProductoView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            lista = new List<GetMantRpte2_Productos>();
        }

        private void ReporteProductoView_Load(object sender, EventArgs e)
        {
            ListarNivelCBX();
        }

        public void ListarNivelCBX()
        {
            List<GetMant16_NivelCBX> cbxNivelList = _mantenimientoBL.Get16_NivelCBX();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxNivelList;

            cbxNivel.DisplayMember = "nivel";
            cbxNivel.ValueMember = "codNivel";
            cbxNivel.DataSource = bindingSource.DataSource;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lista = _mantenimientoBL.Get31_Productos(cbxNivel.SelectedValue.ToString(), txtGrupo.Text, txtTalla.Text, txtColor.Text);

            dgvListado.Rows.Clear();

            foreach (var item in lista)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["dgvTxtCodNivel"].Value = item.codNivel;
                dgvListado.Rows[index].Cells["dgvTxtNivel"].Value = item.nivel;
                dgvListado.Rows[index].Cells["dgvTxtCodGrupo"].Value = item.codGrupo;
                dgvListado.Rows[index].Cells["dgvTxtGrupo"].Value = item.grupo.Trim();
                dgvListado.Rows[index].Cells["dgvTxtCodTalla"].Value = item.codTalla;
                dgvListado.Rows[index].Cells["dgvTxtTalla"].Value = item.talla.Trim();
                dgvListado.Rows[index].Cells["dgvTxtCodColor"].Value = item.codColor.Trim();
                dgvListado.Rows[index].Cells["dgvTxtColor"].Value = item.color.Trim();

                dgvListado.Rows[index].Cells["dgvTxtCodProductoAlt"].Value = item.codGrupoAlt;

                dgvListado.Rows[index].Cells["dgvTxtStockReal"].Value = item.stockReal;
            }

            dgvListado.AutoResizeColumns();
            dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            if (dgvListado.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = @"C:\";
                sfd.Title = "Guardar Archivo Como";
                sfd.Filter = "Excel |*.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(sfd.FileName))
                    {
                        ExcelReportTitulo[] arrayTitulo = new ExcelReportTitulo[10];

                        arrayTitulo[0] = new ExcelReportTitulo() { titulo = "Cod. Nivel", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[1] = new ExcelReportTitulo() { titulo = "Nivel", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[2] = new ExcelReportTitulo() { titulo = "Cod. Grupo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[3] = new ExcelReportTitulo() { titulo = "Grupo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[4] = new ExcelReportTitulo() { titulo = "Cod. Talla", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[5] = new ExcelReportTitulo() { titulo = "Talla", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[6] = new ExcelReportTitulo() { titulo = "Cod. Color", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[7] = new ExcelReportTitulo() { titulo = "Color", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[8] = new ExcelReportTitulo() { titulo = "Cod. Producto Alternativo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[9] = new ExcelReportTitulo() { titulo = "Stock Real", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };

                        ExcelReport.GetExcelReport<GetMantRpte2_Productos>(sfd.FileName, arrayTitulo, lista);

                        ResponseMessage.Message("Reporte Exportado", "INFORMATION");
                    };
                }
            }
        }
    }
}
