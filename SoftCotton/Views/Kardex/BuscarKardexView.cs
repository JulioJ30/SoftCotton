using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Kardex;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.Kardex
{
    public partial class BuscarKardexView : Form
    {
        KardexBL _kardexBL;
        MantenimientoBL _mantenimientoBL;
        List<KardexValorizadoPrincipal> listaval;

        public BuscarKardexView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            _kardexBL = new KardexBL();
        }

        private void BuscarKardexView_Load(object sender, EventArgs e)
        {
            ListarNivelCBX();
            ListarCuenta();
        }
        public void ListarCuenta() {
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
                obj.cuenta =  ("(" + item.codCuenta +")" + item.cuenta );
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

       
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            listaval = _kardexBL.uspGetMovimientoKardex(cbxNivel.SelectedValue.ToString(), cmbCuenta.SelectedValue.ToString(), txtGrupo.Text, txtTalla.Text, txtColor.Text, dtpFechaDesde.Value.ToString("yyyyMMdd"), dtpFechaHasta.Value.ToString("yyyyMMdd"));

            dgvListado.Rows.Clear();

            foreach (var item in listaval)
            {
                int index = dgvListado.Rows.Add();
            
                dgvListado.Rows[index].Cells["orden"].Value = item.orden; 
                dgvListado.Rows[index].Cells["tipo"].Value = item.tipo; 
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
                dgvListado.Rows[index].Cells["secuencia"].Value = item.Secuencia;


            }

            dgvListado.AutoResizeColumns();
            dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // 
            // SOLO SI ESTA DENTRO DE COSTURA Y CORTE
            string nivel = cbxNivel.SelectedValue.ToString();
            if (nivel == "06" || nivel == "07" )
            {
                dgvListado.Columns["PU"].ReadOnly = false; // Editable
            }
            else
            {
                dgvListado.Columns["PU"].ReadOnly = true; // Editable
            }

        }

        private void btnExcel_Click_1(object sender, EventArgs e)
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
                        ExcelReportTitulo[] arrayTitulo = new ExcelReportTitulo[29];


                        arrayTitulo[0] = new ExcelReportTitulo() { titulo = "orden", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[1] = new ExcelReportTitulo() { titulo = "tipo", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[2] = new ExcelReportTitulo() { titulo = "cod", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[3] = new ExcelReportTitulo() { titulo = "Nombre_Articulo", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[4] = new ExcelReportTitulo() { titulo = "color", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[5] = new ExcelReportTitulo() { titulo = "Fecha_Guia", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[6] = new ExcelReportTitulo() { titulo = "serie", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[7] = new ExcelReportTitulo() { titulo = "numero", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[8] = new ExcelReportTitulo() { titulo = "codigo_Proveedor", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[9] = new ExcelReportTitulo() { titulo = "razonSocial", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[10] = new ExcelReportTitulo() { titulo = "serie_fact", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[11] = new ExcelReportTitulo() { titulo = "Num_fact", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[12] = new ExcelReportTitulo() { titulo = "tipoCambio", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[13] = new ExcelReportTitulo() { titulo = "Tipo Moneda", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[14] = new ExcelReportTitulo() { titulo = "codigo", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[15] = new ExcelReportTitulo() { titulo = "UM", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[16] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[17] = new ExcelReportTitulo() { titulo = "fact_tipo", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[18] = new ExcelReportTitulo() { titulo = "mes", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[0] = new ExcelReportTitulo() { titulo = "cantidadOC", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White }; 
                        //arrayTitulo[0] = new ExcelReportTitulo() { titulo = "idEmpresa", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White }; 
                        arrayTitulo[19] = new ExcelReportTitulo() { titulo = "Entrada / Salida", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[20] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[21] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[22] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[23] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[24] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[25] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[26] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[27] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        arrayTitulo[28] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[29] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[30] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[31] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[32] = new ExcelReportTitulo() { titulo = "CANTIDAD", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[33] = new ExcelReportTitulo() { titulo = "PU", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        //arrayTitulo[34] = new ExcelReportTitulo() { titulo = "TOTAL", backgroundColor = XLColor.DarkSeaGreen, foreColor = XLColor.White };
                        
                        ExcelReport.GetExcelReportKardex<KardexValorizadoPrincipal>(sfd.FileName, arrayTitulo, listaval);

                        ResponseMessage.Message("Reporte Exportado", "INFORMATION");
                    };
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvListado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la celda editada pertenece a la columna "PU"
            if (dgvListado.Columns[e.ColumnIndex].Name == "PU")
            {
                // Obtener el nuevo valor de la celda
                var nuevaValor = dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Validar si el valor es numérico
                if (!decimal.TryParse(nuevaValor?.ToString(), out decimal resultado))
                {
                    MessageBox.Show("Por favor, ingrese un valor numérico válido en PU.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0; // Restaurar a 0 si es inválido
                }
                else
                {
                    // Aquí puedes actualizar la base de datos o realizar otra acción
                    //Console.WriteLine($"Nuevo valor de PU: {resultado}");

                    //dgvListado.Rows[index].Cells["orden"].Value = item.orden;
                    //dgvListado.Rows[index].Cells["tipo"].Value = item.tipo;
                    //dgvListado.Rows[index].Cells["cod"].Value = item.cod;
                    //dgvListado.Rows[index].Cells["Nombre_Articulo"].Value = item.Nombre_Articulo;
                    //dgvListado.Rows[index].Cells["color"].Value = item.color;
                    //dgvListado.Rows[index].Cells["Fecha_Guia"].Value = item.Fecha_Guia;
                    //dgvListado.Rows[index].Cells["serie"].Value = item.serie;
                    //dgvListado.Rows[index].Cells["numero"].Value = item.numero;
                    //dgvListado.Rows[index].Cells["codigo_Proveedor"].Value = item.codigo_Proveedor;
                    //dgvListado.Rows[index].Cells["razonSocial"].Value = item.razonSocial;
                    //dgvListado.Rows[index].Cells["serie_fact"].Value = item.serie_fact;
                    //dgvListado.Rows[index].Cells["Num_fact"].Value = item.Num_fact;
                    //dgvListado.Rows[index].Cells["Tipo_Moneda"].Value = item.Tipo_Moneda;
                    //dgvListado.Rows[index].Cells["codigo"].Value = item.codigo;
                    //dgvListado.Rows[index].Cells["UM"].Value = item.UM;
                    //dgvListado.Rows[index].Cells["PU"].Value = item.PU;
                    //dgvListado.Rows[index].Cells["fact_tipo"].Value = item.fact_tipo;
                    //dgvListado.Rows[index].Cells["mes"].Value = item.mes;
                    //dgvListado.Rows[index].Cells["tipoMovimiento"].Value = item.tipoMovimiento;
                    //dgvListado.Rows[index].Cells["cantidad"].Value = item.cantidadSolesE;

                    string Tipo = dgvListado.Rows[e.ColumnIndex].Cells["tipoMovimiento"].Value.ToString() == "E" ? "N" : "E";
                    int IdEmpresa = 1;
                    string Serie = dgvListado.Rows[e.ColumnIndex].Cells["serie"].Value.ToString();
                    int Numero = Convert.ToInt32(dgvListado.Rows[e.ColumnIndex].Cells["numero"].Value.ToString());
                    int Secuencia = Convert.ToInt32(dgvListado.Rows[e.ColumnIndex].Cells["secuencia"].Value.ToString().Trim());
                    float Precio = (float)resultado;

                    _kardexBL.CambiarPrecio(Tipo, IdEmpresa, Serie, Numero, Secuencia, Precio);

                }
            }
        }
    }
}
