using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.Reporting.WinForms;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Kardex;
using SoftCotton.Model.Maintenance;
using SoftCotton.Reports.Kardex;
using SoftCotton.Util;
using SoftCotton.Views.Maintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Kardex
{
    public partial class KardexElectronicoValorizadoView : Form
    {
        KardexBL _kardexBL;
        MantenimientoBL _mantenimientoBL = new MantenimientoBL();
        List<KardexElectronico> listaval;
        public KardexElectronicoValorizadoView()
        {
            InitializeComponent();
            _kardexBL = new KardexBL();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            listaval = _kardexBL.uspGetkardexElectronicovalorizado(
                cbxNivel.SelectedValue.ToString(),
                cmbCuenta.SelectedValue.ToString(),
                dtpDesde.Value.ToString("yyyyMMdd"), 
                dtpHasta.Value.ToString("yyyyMMdd"), 
                LblIdProducto.Text);

            dgvListado.Rows.Clear();

            foreach (var item in listaval)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["MATERIAL"].Value = item.MATERIAL;
                dgvListado.Rows[index].Cells["TPO_MATERIAL"].Value = item.TPO_MATERIAL;
                dgvListado.Rows[index].Cells["N_CUBSO"].Value = item.N_CUBSO;
                dgvListado.Rows[index].Cells["N_LOGISTICA"].Value = item.N_LOGISTICA;
                dgvListado.Rows[index].Cells["N_CONTAB"].Value = item.N_CONTAB;
                dgvListado.Rows[index].Cells["PERIODO"].Value = item.PERIODO;

                dgvListado.Rows[index].Cells["CUO"].Value = item.CUO;
                dgvListado.Rows[index].Cells["NUMERO_CORRELATIVO"].Value = item.NUMERO_CORRELATIVO;
                dgvListado.Rows[index].Cells["COD_ESTABLECIMIENTO"].Value = item.COD_ESTABLECIMIENTO;
                dgvListado.Rows[index].Cells["ESTABLEC"].Value = item.ESTABLEC;
                dgvListado.Rows[index].Cells["COD_CATALOGO"].Value = item.COD_CATALOGO;

                dgvListado.Rows[index].Cells["TIPO_EXISTENCIA"].Value = item.TIPO_EXISTENCIA;
                dgvListado.Rows[index].Cells["CODIGO_PROPIO_EXISTENCIA"].Value = item.CODIGO_PROPIO_EXISTENCIA;
                dgvListado.Rows[index].Cells["CATALOGO_UNICO_BIENES"].Value = item.CATALOGO_UNICO_BIENES;
                dgvListado.Rows[index].Cells["CODIGO_EXISTENCIA_UNSPSC"].Value = item.CODIGO_EXISTENCIA_UNSPSC;
                dgvListado.Rows[index].Cells["FECHA"].Value = item.FECHA;

                dgvListado.Rows[index].Cells["TIPO_DOC"].Value = item.TIPO_DOC;

                dgvListado.Rows[index].Cells["N_SERIE"].Value = item.N_SERIE;
                dgvListado.Rows[index].Cells["N_DOCUMENTO"].Value = item.N_DOCUMENTO;
                dgvListado.Rows[index].Cells["TPO_OPERA"].Value = item.TPO_OPERA;

                dgvListado.Rows[index].Cells["DESC_MATERIAL"].Value = item.DESC_MATERIAL;
                dgvListado.Rows[index].Cells["UNID_MED"].Value = item.UNID_MED;
                dgvListado.Rows[index].Cells["CODIGO_METODO_VAL"].Value = item.CODIGO_METODO_VAL;
                dgvListado.Rows[index].Cells["METODO_VAL"].Value = item.METODO_VAL;


                dgvListado.Rows[index].Cells["CANT_ENTRADA"].Value = item.CANT_ENTRADA;
                dgvListado.Rows[index].Cells["Costo_Unit_Entrada"].Value = item.Costo_Unit_Entrada;
                dgvListado.Rows[index].Cells["Costo_Total_Entrada"].Value = item.Costo_Total_Entrada;

                dgvListado.Rows[index].Cells["CANT_SALIDA"].Value = item.CANT_SALIDA;
                dgvListado.Rows[index].Cells["Costo_Unit_Salida"].Value = item.Costo_Unit_Salida;
                dgvListado.Rows[index].Cells["Costo_Total_Salida"].Value = item.Costo_Total_Salida;

                dgvListado.Rows[index].Cells["Cantidad_Final"].Value = item.Cantidad_Final;
                dgvListado.Rows[index].Cells["Costo_Unit_Final"].Value = item.Costo_Unit_Final;
                dgvListado.Rows[index].Cells["Costo_Total_Final"].Value = item.Costo_Total_Final;

                dgvListado.Rows[index].Cells["Est_Op"].Value = item.Est_Op;
      
            }

            dgvListado.AutoResizeColumns();
            dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnBuscarLista_Click(object sender, EventArgs e)
        {
            VariableGeneral._sEnter = false;
            BuscarArticulo frm = new BuscarArticulo();
            frm.ShowDialog();
            if (VariableGeneral._sEnter)
            {
                LblIdProducto.Text = VariableGeneral._sCodigo;
                LblProducto.Text = VariableGeneral._sDescr;
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListado.Rows.Count > 0) { }
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel Documents (*.xls)|*.xls";
                save.FileName = "Kardex Electronico Valorizado";
                dgvListado.SelectAll();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    dgvListado.GridToExcel(save.FileName);
                }
                else
                {
                    MessageBox.Show("No Hay Datos para Exportar", "Kardex Electronico Valorizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kardex Electronico Valorizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //List<KardexElectronico> listaProvClientesRpte = new List<KardexElectronico>();

            //if (listaval.Count > 0)
            //{

            //    foreach (var item in listaval)
            //    {
            //        listaProvClientesRpte.Add(new KardexElectronico()
            //        {
            //            MATERIAL = item.MATERIAL,
            //            TPO_MATERIAL = item.TPO_MATERIAL,
            //            DESC_MATERIAL = item.DESC_MATERIAL,
            //            UNID_MED = item.UNID_MED,
            //            METODO_VAL = item.METODO_VAL,
            //            COD_ESTABLECIMIENTO = item.COD_ESTABLECIMIENTO,
            //            ESTABLEC = item.ESTABLEC,
            //            FECHA = item.FECHA,
            //            COD_CATALOGO = item.COD_CATALOGO,
            //            N_CUBSO = item.N_CUBSO,
            //            TIPO_DOC = item.TIPO_DOC,
            //            N_SERIE = item.N_SERIE,
            //            N_DOCUMENTO = item.N_DOCUMENTO,
            //            N_LOGISTICA = item.N_LOGISTICA,

            //            N_CONTAB = item.N_CONTAB,
            //            TPO_OPERA = item.TPO_OPERA,

            //            CANT_ENTRADA = item.CANT_ENTRADA,
            //            Costo_Unit_Entrada = item.Costo_Unit_Entrada,
            //            Costo_Total_Entrada = item.Costo_Total_Entrada,

            //            CANT_SALIDA = item.CANT_SALIDA,
            //            Costo_Unit_Salida = item.Costo_Unit_Salida,
            //            Costo_Total_Salida = item.Costo_Total_Salida,

            //            Cantidad_Final = item.Cantidad_Final,
            //            Costo_Unit_Final = item.Costo_Unit_Final,
            //            Costo_Total_Final = item.Costo_Total_Final,

            //            Est_Op = item.Est_Op,                
            //        });
            //    }

            //    SaveFileDialog sfd = new SaveFileDialog();
            //    sfd.InitialDirectory = @"C:\";
            //    sfd.Title = "Guardar Archivo Como";
            //    sfd.Filter = "Excel |*.xlsx";

            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        if (!string.IsNullOrEmpty(sfd.FileName))
            //        {
            //            ExcelReportTitulo[] arrayTitulo = new ExcelReportTitulo[26];

            //            arrayTitulo[0] = new ExcelReportTitulo() { titulo = "Material", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[1] = new ExcelReportTitulo() { titulo = "Tpo.Material", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[2] = new ExcelReportTitulo() { titulo = "Desc.Material", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[3] = new ExcelReportTitulo() { titulo = "Unid.Med.", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[4] = new ExcelReportTitulo() { titulo = "Método Val", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[5] = new ExcelReportTitulo() { titulo = "Cod.Establecimiento", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[6] = new ExcelReportTitulo() { titulo = "Establec.", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[7] = new ExcelReportTitulo() { titulo = "Fecha", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[8] = new ExcelReportTitulo() { titulo = "Cod. Catálogo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };

            //            arrayTitulo[9] = new ExcelReportTitulo() { titulo = "N°CUBSO", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[10] = new ExcelReportTitulo() { titulo = "TIPO DOC.", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[11] = new ExcelReportTitulo() { titulo = "N°SERIE", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[12] = new ExcelReportTitulo() { titulo = "N°DOCUMENTO", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[13] = new ExcelReportTitulo() { titulo = "N° Logística", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };

            //            arrayTitulo[14] = new ExcelReportTitulo() { titulo = "N° Contab.", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[15] = new ExcelReportTitulo() { titulo = "Tpo.Opera.", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };

            //            arrayTitulo[16] = new ExcelReportTitulo() { titulo = "Cant.Entrada", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[17] = new ExcelReportTitulo() { titulo = "Costo Unit.Entrada", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[18] = new ExcelReportTitulo() { titulo = "Costo Total Entrada", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };

            //            arrayTitulo[19] = new ExcelReportTitulo() { titulo = "Cantidad Salida", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[20] = new ExcelReportTitulo() { titulo = "Costo Unit.Salida", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[21] = new ExcelReportTitulo() { titulo = "Costo Total Salida", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };

            //            arrayTitulo[22] = new ExcelReportTitulo() { titulo = "Cantidad Final", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[23] = new ExcelReportTitulo() { titulo = "Costo Unit.Final", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
            //            arrayTitulo[24] = new ExcelReportTitulo() { titulo = "Costo Total Final", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };

            //            arrayTitulo[25] = new ExcelReportTitulo() { titulo = "Est.Op", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };


            //            ExcelReport.GetExcelReport<KardexElectronico>(sfd.FileName, arrayTitulo, listaProvClientesRpte);

            //            ResponseMessage.Message("Reporte Exportado", "INFORMATION");
            //        }
            //    }

            //}
        }

        private void dgvListado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvListado.ClearSelection();
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            ExportarTxt();
        }

        private void ExportarTxt()
        {
            List<KardexElectronico> listaProvClientesRpte = new List<KardexElectronico>();

            //foreach (var item in listaval)
            //{
            //    listaProvClientesRpte.Add(new KardexElectronico()
            //    {
            //        PERIODO = item.PERIODO,
            //        CUO = item.CUO,
            //        NUMERO_CORRELATIVO = item.NUMERO_CORRELATIVO,
            //        COD_ESTABLECIMIENTO = item.COD_ESTABLECIMIENTO,
            //        COD_CATALOGO = item.COD_CATALOGO,
            //        TIPO_EXISTENCIA = item.TIPO_EXISTENCIA,
            //        CODIGO_PROPIO_EXISTENCIA = item.CODIGO_PROPIO_EXISTENCIA,
            //        CATALOGO_UNICO_BIENES = item.CATALOGO_UNICO_BIENES,
            //        CODIGO_EXISTENCIA_UNSPSC = item.CODIGO_EXISTENCIA_UNSPSC,
            //        FECHA = item.FECHA,
            //        TIPO_DOC = item.TIPO_DOC,
            //        N_SERIE = item.N_SERIE,
            //        N_DOCUMENTO = item.N_DOCUMENTO,                    
            //        TPO_OPERA = item.TPO_OPERA,
            //        DESC_MATERIAL = item.DESC_MATERIAL,
            //        UNID_MED = item.UNID_MED,
            //        CODIGO_METODO_VAL = item.CODIGO_METODO_VAL,
            //        CANT_ENTRADA = item.CANT_ENTRADA,
            //        Costo_Unit_Entrada = item.Costo_Unit_Entrada,
            //        Costo_Total_Entrada = item.Costo_Total_Entrada,
            //        CANT_SALIDA = item.CANT_SALIDA,
            //        Costo_Unit_Salida = item.Costo_Unit_Salida,
            //        Costo_Total_Salida = item.Costo_Total_Salida,
            //        Cantidad_Final = item.Cantidad_Final,
            //        Costo_Unit_Final = item.Costo_Unit_Final,
            //        Costo_Total_Final = item.Costo_Total_Final,
            //        Est_Op = item.Est_Op,
            //    });
            //}

            foreach (DataGridViewRow fila in dgvListado.Rows)
            {
                // Ignora la última fila en blanco si la DataGridView tiene AllowUserToAddRows establecido en true
                if (!fila.IsNewRow)
                {
                    KardexElectronico datos = new KardexElectronico();
                    // Suponiendo que las columnas de tu DataGridView son de tipo string
                    datos.PERIODO = fila.Cells["PERIODO"].Value.ToString();
                    datos.CUO = fila.Cells["CUO"].Value.ToString();
                    datos.NUMERO_CORRELATIVO = fila.Cells["NUMERO_CORRELATIVO"].Value.ToString();
                    datos.COD_ESTABLECIMIENTO = fila.Cells["COD_ESTABLECIMIENTO"].Value.ToString();
                    datos.COD_CATALOGO = fila.Cells["COD_CATALOGO"].Value.ToString();
                    datos.TIPO_EXISTENCIA = fila.Cells["TIPO_EXISTENCIA"].Value.ToString();
                    datos.CODIGO_PROPIO_EXISTENCIA = fila.Cells["CODIGO_PROPIO_EXISTENCIA"].Value.ToString();
                    datos.CATALOGO_UNICO_BIENES = fila.Cells["CATALOGO_UNICO_BIENES"].Value.ToString();
                    datos.CODIGO_EXISTENCIA_UNSPSC = fila.Cells["CODIGO_EXISTENCIA_UNSPSC"].Value.ToString();
                    datos.FECHA = Convert.ToDateTime(fila.Cells["FECHA"].Value.ToString());
                    datos.TIPO_DOC = fila.Cells["TIPO_DOC"].Value.ToString();
                    datos.N_SERIE = fila.Cells["N_SERIE"].Value.ToString();
                    datos.N_DOCUMENTO = fila.Cells["N_DOCUMENTO"].Value.ToString();
                    datos.TPO_OPERA = fila.Cells["TPO_OPERA"].Value.ToString();
                    datos.DESC_MATERIAL = fila.Cells["DESC_MATERIAL"].Value.ToString();
                    datos.UNID_MED = fila.Cells["UNID_MED"].Value.ToString();
                    datos.CODIGO_METODO_VAL = fila.Cells["CODIGO_METODO_VAL"].Value.ToString();
                    datos.CANT_ENTRADA = Convert.ToDouble(fila.Cells["CANT_ENTRADA"].Value.ToString());
                    datos.Costo_Unit_Entrada = Convert.ToDouble(fila.Cells["Costo_Unit_Entrada"].Value.ToString());
                    datos.Costo_Total_Entrada = Convert.ToDouble(fila.Cells["Costo_Total_Entrada"].Value.ToString());
                    datos.CANT_SALIDA = Convert.ToDouble(fila.Cells["CANT_SALIDA"].Value.ToString());
                    datos.Costo_Unit_Salida = Convert.ToDouble(fila.Cells["Costo_Unit_Salida"].Value.ToString());
                    datos.Costo_Total_Salida = Convert.ToDouble(fila.Cells["Costo_Total_Salida"].Value.ToString());
                    datos.Cantidad_Final = Convert.ToDouble(fila.Cells["Cantidad_Final"].Value.ToString());
                    datos.Costo_Unit_Final = Convert.ToDouble(fila.Cells["Costo_Unit_Final"].Value.ToString());
                    datos.Costo_Total_Final = Convert.ToDouble(fila.Cells["Costo_Total_Final"].Value.ToString());
                    datos.Est_Op = Convert.ToInt32(fila.Cells["Est_Op"].Value.ToString());
                    listaProvClientesRpte.Add(datos);
                }
            }



            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                saveFileDialog.Title = "Guardar archivo";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(rutaArchivo))
                    {
                        //string lineaX = $"PERIODO|CUO|NUMERO_CORRELATIVO|COD_ESTABLECIMIENTO|" +
                        //        $"COD_CATALOGO|TIPO_EXISTENCIA|CODIGO_PROPIO_EXISTENCIA|CATALOGO_UNICO_BIENES|" +
                        //        $"CODIGO_EXISTENCIA_UNSPSC|FECHA|TIPO_DOC|N_SERIE|N_DOCUMENTO|" +
                        //        $"TPO_OPERA|DESC_MATERIAL|UNID_MED|CODIGO_METODO_VAL|" +
                        //        $"CANT_ENTRADA|Costo_Unit_Entrada|Costo_Total_Entrada|" +
                        //        $"CANT_SALIDA|Costo_Unit_Salida|Costo_Total_Salida|" +
                        //        $"Cantidad_Final|Costo_Unit_Final|Costo_Total_Final|Est_Op";

                        //writer.WriteLine(lineaX);



                        foreach (KardexElectronico item in listaProvClientesRpte)
                        {
                            string fechaFormateada = item.FECHA.ToString("dd/MM/yyyy");

                            string linea = $"{item.PERIODO}|{item.CUO}|{item.NUMERO_CORRELATIVO}|{item.COD_ESTABLECIMIENTO}|" +
                                $"{item.COD_CATALOGO}|{item.TIPO_EXISTENCIA}|{item.CODIGO_PROPIO_EXISTENCIA}|{item.CATALOGO_UNICO_BIENES}|" +
                                $"{item.CODIGO_EXISTENCIA_UNSPSC}|{fechaFormateada}|{item.TIPO_DOC}|{item.N_SERIE}|{item.N_DOCUMENTO}|" +
                                $"{item.TPO_OPERA}|{item.DESC_MATERIAL}|{item.UNID_MED}|{item.CODIGO_METODO_VAL}|" +
                                $"{ConvertirFormato(item.CANT_ENTRADA.ToString("N2"))}|" +
                                $"{ConvertirFormato(item.Costo_Unit_Entrada.ToString("N2"))}|" +
                                $"{ConvertirFormato(item.Costo_Total_Entrada.ToString("N2"))}|" +
                                $"{ConvertirFormato(item.CANT_SALIDA.ToString("N2"))}|" +
                                $"{ConvertirFormato(item.Costo_Unit_Salida.ToString("N2"))}|" +
                                $"{ConvertirFormato(item.Costo_Total_Salida.ToString("N2"))}|" +
                                $"{ConvertirFormato(item.Cantidad_Final.ToString("N2"))}|" +
                                $"{ConvertirFormato(item.Costo_Unit_Final.ToString("N2"))}|" +
                                $"{ConvertirFormato(item.Costo_Total_Final.ToString("N2"))}|" +
                                $"{item.Est_Op}|";
                            writer.WriteLine(linea);
                        }
                    }
                    ResponseMessage.Message("Reporte Exportado", "INFORMATION");
                }
                else
                {
                    ResponseMessage.Message("l usuario canceló la operación de guardar el archivo.", "INFORMATION");
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Rpt_KardexValorizado reportViewerForm = new Rpt_KardexValorizado();


           // List<DocDJ> LIS = ObtenerListaItemDJ(2);
            reportViewerForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetRptKardex", listaval));

            reportViewerForm.reportViewer.ZoomPercent = 100;
            reportViewerForm.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            reportViewerForm.ShowDialog();
        }

        private void KardexElectronicoValorizadoView_Load(object sender, EventArgs e)
        {
            List<GetMant16_NivelCBX> cbxNivelList = _mantenimientoBL.Get16_NivelCBX();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxNivelList;

            cbxNivel.DisplayMember = "nivel";
            cbxNivel.ValueMember = "codNivel";
            cbxNivel.DataSource = bindingSource.DataSource;


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
            var bindingSources = new BindingSource();
            bindingSources.DataSource = comboCuentas;

            cmbCuenta.DisplayMember = "cuenta";
            cmbCuenta.ValueMember = "codCuenta";
            cmbCuenta.DataSource = bindingSources.DataSource;







        }
        public static string ConvertirFormato(string input)
        {
            return input.Replace(",", "");
        }
        private void btnNiveles_Click(object sender, EventArgs e)
        {
            VariableGeneral._sEnter = false;
            BuscarNiveles buscarNiveles = new BuscarNiveles();
            buscarNiveles.ShowDialog();
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            ExportarTxt();
        }

        private void btnImprimir_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
