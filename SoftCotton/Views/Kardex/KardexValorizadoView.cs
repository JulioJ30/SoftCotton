using ClosedXML.Excel;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Kardex;
using SoftCotton.Model.Maintenance;
using SoftCotton.Reports.Kardex;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms; 


namespace SoftCotton.Views.Kardex
{
    public partial class KardexValorizadoView : Form
    {
        KardexBL _kardexBL;
        MantenimientoBL _mantenimientoBL;
        List<KardexValorizado> listaval;

        public KardexValorizadoView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            _kardexBL = new KardexBL();
        }

        private void KardexValorizadoView_Load(object sender, EventArgs e)
        {
            ListarNivelCBX();
            ListarCuenta();
        }

        public void ListarCuenta()
        {
            List<GetMant27_Cuentas> listaCuentas = _mantenimientoBL.Get27_Cuentas();
            List<GetMant27_Cuentas> comboCuentas = new List<GetMant27_Cuentas>();
            int row = 0;
            foreach (var item in listaCuentas)
            {
                row++;
                GetMant27_Cuentas obj = new GetMant27_Cuentas();
                if (row == 1)
                {
                    obj = new GetMant27_Cuentas();
                    obj.cuenta = "-- Elegir Todos --";
                    obj.codCuenta = "0";
                    comboCuentas.Add(obj);
                }
                obj = new GetMant27_Cuentas();
                obj.cuenta = ("(" + item.codCuenta + ")" + item.cuenta);
                obj.codCuenta = item.codCuenta;

                comboCuentas.Add(obj);
            }
            var bindingSource = new BindingSource();
            bindingSource.DataSource = comboCuentas;

            cmbCuenta.DisplayMember = "cuenta";
            cmbCuenta.ValueMember = "codCuenta";
            cmbCuenta.DataSource = bindingSource.DataSource;




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
            listaval = _kardexBL.uspGetMovimientoKardexValorizado(cbxNivel.SelectedValue.ToString(), cmbCuenta.SelectedValue.ToString(), txtGrupo.Text, txtTalla.Text, txtColor.Text, txtPeriodo.Text.Trim() );

            dgvListado.Rows.Clear();

            foreach (var item in listaval)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["orden"].Value = item.orden;
                dgvListado.Rows[index].Cells["tipo"].Value = item.tipo;
                dgvListado.Rows[index].Cells["cuo"].Value = item.cuo;
                dgvListado.Rows[index].Cells["tpo_opera"].Value = item.tpo_opera;


                dgvListado.Rows[index].Cells["cod"].Value = item.cod;
                dgvListado.Rows[index].Cells["Nombre_Articulo"].Value = item.Nombre_Articulo;
                dgvListado.Rows[index].Cells["color"].Value = item.color;
                dgvListado.Rows[index].Cells["Fecha_Guia"].Value = item.Fecha_Guia;
                dgvListado.Rows[index].Cells["serie"].Value = item.serie;
                dgvListado.Rows[index].Cells["numero"].Value = item.numero;
                dgvListado.Rows[index].Cells["codigo_Proveedor"].Value = item.codigo_Proveedor;
                dgvListado.Rows[index].Cells["razonSocial"].Value = item.razonSocial;
                dgvListado.Rows[index].Cells["serie_fact"].Value = item.serie_fact;
                dgvListado.Rows[index].Cells["Num_fact"].Value = item.Num_fact;
                dgvListado.Rows[index].Cells["Tipo_Moneda"].Value = item.Tipo_Moneda;
                dgvListado.Rows[index].Cells["codigo"].Value = item.codigo;
                dgvListado.Rows[index].Cells["UM"].Value = item.UM;
                dgvListado.Rows[index].Cells["PU"].Value = item.PU;
                dgvListado.Rows[index].Cells["fact_tipo"].Value = item.fact_tipo;
                dgvListado.Rows[index].Cells["mes"].Value = item.mes;
                dgvListado.Rows[index].Cells["tipoMovimiento"].Value = item.tipoMovimiento;
                dgvListado.Rows[index].Cells["cantidad"].Value = item.cantidadSolesE;

            }

            dgvListado.AutoResizeColumns();
            dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                //sfd.InitialDirectory = @"C:\";
                sfd.Title = "Guardar Archivo Como";
                sfd.Filter = "Excel |*.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(sfd.FileName))
                    {
                        ExcelReportTitulo[] arrayTitulo = new ExcelReportTitulo[31];


                        arrayTitulo[0] = new ExcelReportTitulo() { titulo = "orden", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[1] = new ExcelReportTitulo() { titulo = "tipo", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[2] = new ExcelReportTitulo() { titulo = "cod", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[3] = new ExcelReportTitulo() { titulo = "Nombre_Articulo", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[4] = new ExcelReportTitulo() { titulo = "color", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };

                        arrayTitulo[5] = new ExcelReportTitulo() { titulo = "Numero Movimiento", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[6] = new ExcelReportTitulo() { titulo = "Tipo Operacíón", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };

                        arrayTitulo[7] = new ExcelReportTitulo() { titulo = "Fecha_Guia", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[8] = new ExcelReportTitulo() { titulo = "serie", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[9] = new ExcelReportTitulo() { titulo = "numero", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[10] = new ExcelReportTitulo() { titulo = "codigo_Proveedor", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[11] = new ExcelReportTitulo() { titulo = "razonSocial", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[12] = new ExcelReportTitulo() { titulo = "serie_fact", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[13] = new ExcelReportTitulo() { titulo = "Num_fact", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[14] = new ExcelReportTitulo() { titulo = "tipoCambio", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[15] = new ExcelReportTitulo() { titulo = "Tipo Moneda", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[16] = new ExcelReportTitulo() { titulo = "codigo", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[17] = new ExcelReportTitulo() { titulo = "UM", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[18] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[19] = new ExcelReportTitulo() { titulo = "fact_tipo", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[20] = new ExcelReportTitulo() { titulo = "mes", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[0] = new ExcelReportTitulo() { titulo = "cantidadOC", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White }; 
                        //arrayTitulo[0] = new ExcelReportTitulo() { titulo = "idEmpresa", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White }; 
                        arrayTitulo[21] = new ExcelReportTitulo() { titulo = "Entrada / Salida", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };

                        arrayTitulo[22] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[23] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[24] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };

                        arrayTitulo[25] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[26] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[27] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };

                        arrayTitulo[28] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[29] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[30] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };


                        //arrayTitulo[29] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[30] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[31] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[32] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[33] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[34] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };

                        string periodo = txtPeriodo.Text.Trim();
                        string nivel = cbxNivel.Text.Trim();    


                        ExcelReport.GetExcelReportKardexValorizado<KardexValorizado>(sfd.FileName, arrayTitulo, listaval,periodo,nivel);
                        ResponseMessage.Message("Reporte Exportado", "INFORMATION");
                    };
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rpt_KardexValorizadoNuevo reportViewerForm = new Rpt_KardexValorizadoNuevo();

            // PARAMETRO
            ReportParameter[] p = new ReportParameter[]
              {
                    new ReportParameter("Periodo", txtPeriodo.Text.Trim()),
                    new ReportParameter("CodigoExistencia", cbxNivel.Text.Trim()),
              };



            // DATA
            reportViewerForm.reportViewer1.LocalReport.DataSources.Clear();
            reportViewerForm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetRptKardex", listaval));

            // PARAMETRO
            reportViewerForm.reportViewer1.LocalReport.SetParameters(p);


            reportViewerForm.reportViewer1.ZoomPercent = 100;
            reportViewerForm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewerForm.reportViewer1.RefreshReport();


            reportViewerForm.ShowDialog();
        }
    }
}
