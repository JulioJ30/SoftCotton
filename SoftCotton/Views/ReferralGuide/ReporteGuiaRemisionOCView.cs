using ClosedXML.Excel;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.ReferralGuide;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.ReferralGuide
{
    public partial class ReporteGuiaRemisionOCView : Form
    {
        GuiaRemisionBL _guiaRemision;
        List<GetGR6_RpteGROC> lista;

        public ReporteGuiaRemisionOCView()
        {
            InitializeComponent();

            _guiaRemision = new GuiaRemisionBL();
            lista = new List<GetGR6_RpteGROC>();
        }

        private void ReporteGuiaRemisionOCView_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            lista = _guiaRemision.Get6_RpteGROC(dtpFechaInicio.Value.Date.ToString("yyyyMMdd"), dtpFechaFin.Value.Date.ToString("yyyyMMdd"), txtCodProducto.Text);

            dgvListado.Rows.Clear();

            foreach (var item in lista)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["dgvTipo"].Value = item.tipo;
                dgvListado.Rows[index].Cells["dgvCodigo"].Value = item.codigo;
                dgvListado.Rows[index].Cells["dgvSecuencia"].Value = item.secuencia;
                dgvListado.Rows[index].Cells["dgvCodProducto"].Value = item.codProducto;
                dgvListado.Rows[index].Cells["dgvCodProductoAlt"].Value = item.codGrupoAlt;
                dgvListado.Rows[index].Cells["dgvCantidad"].Value = item.cantidad;
                dgvListado.Rows[index].Cells["dgvIgv"].Value = item.igv;
                dgvListado.Rows[index].Cells["dgvPrecioUnitario"].Value = item.precioUnitario;
                dgvListado.Rows[index].Cells["dgvCodigoPC"].Value = item.codigoPC;
                dgvListado.Rows[index].Cells["dgvRazonSocial"].Value = item.razonSocial;
                dgvListado.Rows[index].Cells["dgvObservacion"].Value = item.cobservacion;
                
                dgvListado.Rows[index].Cells["dgvGRgserie"].Value = item.gserie;
                dgvListado.Rows[index].Cells["dgvGRgnumero"].Value = item.gnumero;
                dgvListado.Rows[index].Cells["dgvGRgfechaInicioTraslado"].Value = item.gfechaInicioTraslado;
                dgvListado.Rows[index].Cells["dgvGRgdestCodigoPC"].Value = item.gdestCodigoPC;
                dgvListado.Rows[index].Cells["dgvGRgdestRazonSocial"].Value = item.gdestRazonSocial;
                dgvListado.Rows[index].Cells["dgvGRgtransCodigoPC"].Value = item.gtransCodigoPC;
                dgvListado.Rows[index].Cells["dgvGRgtransRazonSocial"].Value = item.gtransRazonSocial;
                dgvListado.Rows[index].Cells["dgvGRgtransMarca"].Value = item.gtransMarca;
                dgvListado.Rows[index].Cells["dgvGRgtransNumPlaca"].Value = item.gtransNumPlaca;
                dgvListado.Rows[index].Cells["dgvGRgtransNumLicConducir"].Value = item.gtransNumLicConducir;
                dgvListado.Rows[index].Cells["dgvGRgcodTipoCpte"].Value = item.gcodTipoCpte;
                dgvListado.Rows[index].Cells["dgvGRgtipoComprobante"].Value = item.gtipoComprobante;
                dgvListado.Rows[index].Cells["dgvGRgnumCptePago"].Value = item.gnumCptePago;
                dgvListado.Rows[index].Cells["dgvGRgsecuencia"].Value = item.gsecuencia;
                dgvListado.Rows[index].Cells["dgvCodCuenta"].Value = item.gcodCuenta;
                dgvListado.Rows[index].Cells["dgvGRgcantidadIngresada"].Value = item.gcantidadIngresada;
                dgvListado.Rows[index].Cells["dgvGRgpesoIngresado"].Value = item.gpesoIngresado;
                dgvListado.Rows[index].Cells["dgvGRgtipoMovimiento"].Value = item.gtipoMovimiento;
                dgvListado.Rows[index].Cells["dgvGRgPeriodo"].Value = item.gPeriodo;

                dgvListado.Rows[index].Cells["dgvFACfserie"].Value = item.fserie;
                dgvListado.Rows[index].Cells["dgvFACfnumero"].Value = item.fnumero;
                dgvListado.Rows[index].Cells["dgvFACffechaEmision"].Value = item.ffechaEmision;
                dgvListado.Rows[index].Cells["dgvFACfcodigoPC"].Value = item.fcodigoPC;
                dgvListado.Rows[index].Cells["dgvFACfrazonSocial"].Value = item.frazonSocial;
                dgvListado.Rows[index].Cells["dgvFACfsecuencia"].Value = item.fsecuencia;
                dgvListado.Rows[index].Cells["dgvFACfcodigo"].Value = item.fcodigo;

                dgvListado.Rows[index].Cells["dgvFACfdescripcion"].Value = item.fdescripcion;
                dgvListado.Rows[index].Cells["dgvFACftalla"].Value = item.ftalla;
                dgvListado.Rows[index].Cells["dgvFACfcolor"].Value = item.fcolor;

                dgvListado.Rows[index].Cells["dgvFACfcodUM"].Value = item.fcodUM;
                dgvListado.Rows[index].Cells["dgvFACfcantidad"].Value = item.fcantidad;
                dgvListado.Rows[index].Cells["dgvFACfigv"].Value = item.figv;
                dgvListado.Rows[index].Cells["dgvFACfprecioUnitario"].Value = item.fprecioUnitario;
                dgvListado.Rows[index].Cells["dgvFACftipoCambio"].Value = item.ftipoCambio;
                dgvListado.Rows[index].Cells["dgvFACftipoMoneda"].Value = item.ftipoMoneda;

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
                        ExcelReportTitulo[] arrayTitulo = new ExcelReportTitulo[50];

                        arrayTitulo[0] = new ExcelReportTitulo() { titulo = "Tipo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[1] = new ExcelReportTitulo() { titulo = "Codigo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[2] = new ExcelReportTitulo() { titulo = "Secuencia", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[3] = new ExcelReportTitulo() { titulo = "Cod. Producto", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[4] = new ExcelReportTitulo() { titulo = "Cod. Producto Alternativo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[5] = new ExcelReportTitulo() { titulo = "Cantidad", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[6] = new ExcelReportTitulo() { titulo = "IGV", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[7] = new ExcelReportTitulo() { titulo = "PrecioUnitario", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[8] = new ExcelReportTitulo() { titulo = "CodigoPC", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[9] = new ExcelReportTitulo() { titulo = "RazonSocial", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[10] = new ExcelReportTitulo() { titulo = "Observación", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };

                        arrayTitulo[11] = new ExcelReportTitulo() { titulo = "GR - Serie", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[12] = new ExcelReportTitulo() { titulo = "GR - Numero", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[13] = new ExcelReportTitulo() { titulo = "GR - Fecha Inicio Traslado", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[14] = new ExcelReportTitulo() { titulo = "GR - Destinatario RUC", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[15] = new ExcelReportTitulo() { titulo = "GR - Destinatario Razon Social", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[16] = new ExcelReportTitulo() { titulo = "GR - Transporte RUC", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[17] = new ExcelReportTitulo() { titulo = "GR - Transporte Razon Social", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[18] = new ExcelReportTitulo() { titulo = "GR - N° Partida", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[19] = new ExcelReportTitulo() { titulo = "GR - Marca", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[20] = new ExcelReportTitulo() { titulo = "GR - N°Placa", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[21] = new ExcelReportTitulo() { titulo = "GR - N° Licencia Conducir", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[22] = new ExcelReportTitulo() { titulo = "GR - Cod. Tipo Comprobante", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[23] = new ExcelReportTitulo() { titulo = "GR - Tipo Comprobante", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[24] = new ExcelReportTitulo() { titulo = "GR - N° Comprobante Pago", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[25] = new ExcelReportTitulo() { titulo = "GR - Secuencia", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[26] = new ExcelReportTitulo() { titulo = "GR - CtaContable", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[27] = new ExcelReportTitulo() { titulo = "GR - Cantidad Ingresada", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[28] = new ExcelReportTitulo() { titulo = "GR - Peso Ingresado", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[29] = new ExcelReportTitulo() { titulo = "GR - Tipo Movimiento", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };
                        arrayTitulo[30] = new ExcelReportTitulo() { titulo = "Periodo", backgroundColor = XLColor.LightGreen, foreColor = XLColor.Black };

                        arrayTitulo[31] = new ExcelReportTitulo() { titulo = "FACT - Serie", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[32] = new ExcelReportTitulo() { titulo = "FACT - Numero", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[33] = new ExcelReportTitulo() { titulo = "FACT - Fecha Emision", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[34] = new ExcelReportTitulo() { titulo = "FACT - Codigo Proveedor", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[35] = new ExcelReportTitulo() { titulo = "FACT - Razon Social", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[36] = new ExcelReportTitulo() { titulo = "FACT - Secuencia", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[37] = new ExcelReportTitulo() { titulo = "FACT - Codigo", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[38] = new ExcelReportTitulo() { titulo = "FACT - Descripcion", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[39] = new ExcelReportTitulo() { titulo = "FACT - Talla", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[40] = new ExcelReportTitulo() { titulo = "FACT - Color", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[41] = new ExcelReportTitulo() { titulo = "FACT - UM", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[42] = new ExcelReportTitulo() { titulo = "FACT - Cantidad", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[43] = new ExcelReportTitulo() { titulo = "FACT - IGV", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[44] = new ExcelReportTitulo() { titulo = "FACT - Precio Unitario", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[45] = new ExcelReportTitulo() { titulo = "FACT - Tipo Cambio", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };
                        arrayTitulo[46] = new ExcelReportTitulo() { titulo = "FACT - Tipo Moneda", backgroundColor = XLColor.LightCoral, foreColor = XLColor.Black };

                        arrayTitulo[47] = new ExcelReportTitulo() { titulo = "NC - Serie", backgroundColor = XLColor.LightCyan, foreColor = XLColor.Black };
                        arrayTitulo[48] = new ExcelReportTitulo() { titulo = "NC - Número", backgroundColor = XLColor.LightCyan, foreColor = XLColor.Black };
                        arrayTitulo[49] = new ExcelReportTitulo() { titulo = "NC - Observación", backgroundColor = XLColor.LightCyan, foreColor = XLColor.Black };

                        ExcelReport.GetExcelReport<GetGR6_RpteGROC>(sfd.FileName, arrayTitulo, lista);

                        ResponseMessage.Message("Reporte Exportado", "INFORMATION");
                    };
                }
            }

        }


    }
}
