using ClosedXML.Excel;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.PurchaseOrder
{
    public partial class ReporteOCView : Form
    {
        OrdenCompraBL _guiaOC;
        List<GetOC19_Reporte> lista;

        public ReporteOCView()
        {
            InitializeComponent();

            _guiaOC = new OrdenCompraBL();
            lista = new List<GetOC19_Reporte>();
        }

        private void ReporteOCView_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lista = _guiaOC.Get19_Reporte(dtpFechaInicio.Value.Date.ToString("yyyyMMdd"), 
                                          dtpFechaFin.Value.Date.ToString("yyyyMMdd"));

            dgvListado.Rows.Clear();

            foreach (var item in lista)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["dgvidEmpresa"].Value = item.idEmpresa;
                dgvListado.Rows[index].Cells["dgvidOC"].Value = item.idOC;
                dgvListado.Rows[index].Cells["dgvfechaEmision"].Value = item.fechaEmision;
                dgvListado.Rows[index].Cells["dgvfechaEntrega"].Value = item.fechaEntrega;
                dgvListado.Rows[index].Cells["dgvcodigoPC"].Value = item.codigoPC;
                dgvListado.Rows[index].Cells["dgvrazonsocial"].Value = item.razonsocial.Trim();
                dgvListado.Rows[index].Cells["dgvtipoMoneda"].Value = item.tipoMoneda;
                dgvListado.Rows[index].Cells["dgvtipoCompra"].Value = item.tipoCompra;
                dgvListado.Rows[index].Cells["dgvcondicion"].Value = item.condicion;
                dgvListado.Rows[index].Cells["dgvestadooc"].Value = item.estadooc;
                dgvListado.Rows[index].Cells["dgvusuCreacionReg"].Value = item.usuCreacionReg;
                dgvListado.Rows[index].Cells["dgvusuFechaReg"].Value = item.usuFechaReg;
                dgvListado.Rows[index].Cells["dgvobservacion"].Value = item.observacion;
                dgvListado.Rows[index].Cells["dgvcodNivel"].Value = item.codNivel;
                dgvListado.Rows[index].Cells["dgvcodGrupo"].Value = item.codGrupo;
                dgvListado.Rows[index].Cells["dgvcodTalla"].Value = item.codTalla;
                dgvListado.Rows[index].Cells["dgvcodColor"].Value = item.codColor;
                dgvListado.Rows[index].Cells["dgvcodProductoGeneral"].Value = item.codProductoGeneral;
                dgvListado.Rows[index].Cells["dgvproducto"].Value = item.producto;
                dgvListado.Rows[index].Cells["dgvcolor"].Value = item.color;
                dgvListado.Rows[index].Cells["dgvobs1"].Value = item.obs1;
                dgvListado.Rows[index].Cells["dgvobs2"].Value = item.obs2;
                dgvListado.Rows[index].Cells["dgvobs3"].Value = item.obs3;
                dgvListado.Rows[index].Cells["dgvobs4"].Value = item.obs4;
                dgvListado.Rows[index].Cells["dgvobs5"].Value = item.obs5;

                dgvListado.Rows[index].Cells["dgvcantidad"].Value = item.cantidad;
                dgvListado.Rows[index].Cells["dgvcodUM"].Value = item.codUM;
                dgvListado.Rows[index].Cells["dgvigv"].Value = item.igv;
                dgvListado.Rows[index].Cells["dgvprecioUnitario"].Value = item.precioUnitario;
                dgvListado.Rows[index].Cells["dgvtotal"].Value = item.total;
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
                        ExcelReportTitulo[] arrayTitulo = new ExcelReportTitulo[30];

                        arrayTitulo[0] = new ExcelReportTitulo() { titulo = "ID Empresa", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[1] = new ExcelReportTitulo() { titulo = "OC", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[2] = new ExcelReportTitulo() { titulo = "Fecha Emisión", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[3] = new ExcelReportTitulo() { titulo = "Fecha Entrega", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[4] = new ExcelReportTitulo() { titulo = "RUC", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[5] = new ExcelReportTitulo() { titulo = "Razon Social", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[6] = new ExcelReportTitulo() { titulo = "Moneda", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[7] = new ExcelReportTitulo() { titulo = "Tipo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[8] = new ExcelReportTitulo() { titulo = "Condición de Pago", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[9] = new ExcelReportTitulo() { titulo = "Estado OC", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[10] = new ExcelReportTitulo() { titulo = "Usuario Registro OC", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[11] = new ExcelReportTitulo() { titulo = "Fecha Registro OC", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[12] = new ExcelReportTitulo() { titulo = "Observacion", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        
                        arrayTitulo[13] = new ExcelReportTitulo() { titulo = "Cod. Nivel", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[14] = new ExcelReportTitulo() { titulo = "Cod. Grupo", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[15] = new ExcelReportTitulo() { titulo = "Cod. Talla", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[16] = new ExcelReportTitulo() { titulo = "Cod. Color", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[17] = new ExcelReportTitulo() { titulo = "Cod. Producto", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[18] = new ExcelReportTitulo() { titulo = "Producto", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[19] = new ExcelReportTitulo() { titulo = "Color", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[20] = new ExcelReportTitulo() { titulo = "Observacion 1", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[21] = new ExcelReportTitulo() { titulo = "Observacion 2", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[22] = new ExcelReportTitulo() { titulo = "Observacion 3", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[23] = new ExcelReportTitulo() { titulo = "Observacion 4", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[24] = new ExcelReportTitulo() { titulo = "Observacion 5", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[25] = new ExcelReportTitulo() { titulo = "Cantidad", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[26] = new ExcelReportTitulo() { titulo = "UM", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[27] = new ExcelReportTitulo() { titulo = "IGV", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[28] = new ExcelReportTitulo() { titulo = "Precio Unitario", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[29] = new ExcelReportTitulo() { titulo = "Total", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        
                        ExcelReport.GetExcelReport<GetOC19_Reporte>(sfd.FileName, arrayTitulo, lista);

                        ResponseMessage.Message("Reporte Exportado", "INFORMATION");
                    };
                }
            }
        }


    }
}
