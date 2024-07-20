using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Views.Maintenance;
using SoftCotton.Views.Shared;
using SoftCotton.Model.DispatchControl;
using FastMember;
using SoftCotton.Util;
using ClosedXML.Excel;


namespace SoftCotton.Views.DispatchControl
{
    public partial class DispatchControlView : Form
    {
        MantenimientoBL _mantenimientoBL;
        DispatchControlBL _dispatchControlBL;
        DataTable DtDetalle = new DataTable();
        private BindingSource bindingSource = new BindingSource();
        List<GetMant21_Tallas> tallas = new List<GetMant21_Tallas>();
        controlDespachoCab cabecera = new controlDespachoCab();
        int idPedidoColor = 0;
        int idProcesoControlDespachoCabBusqueda = 0;



        int indiceInicioTallas = 4;
        //bool dataCargada = false;
        string codProgram       = string.Empty;
        string codColor         = string.Empty;
        string codCliente       = string.Empty;


        public DispatchControlView()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();
            _dispatchControlBL = new DispatchControlBL();

        }

        private void MatrizView_Load(object sender, EventArgs e)
        {
            tallas = _mantenimientoBL.Get48_Tallas().ToList();
            CargarTallas();
        }


        private void CargarTallas()
        {

            DtDetalle = new DataTable();

            dgvDetalle.Columns.Add(setColumna("Nc","nc"));
            dgvDetalle.Columns.Add(setColumna("OrdenServicio", "ordenServicio"));
            dgvDetalle.Columns.Add(setColumna("FechaGuia", "fechaGuia",true,true));
            dgvDetalle.Columns.Add(setColumna("Guia", "guia"));
            foreach (var item in tallas)
            {
                dgvDetalle.Columns.Add(setColumna(item.descripcion, item.descripcion));
            }
            dgvDetalle.Columns.Add(setColumna("Total", "total"));
            dgvDetalle.Columns.Add(setColumna("FechaFactura", "fechaFactura",true,true));
            dgvDetalle.Columns.Add(setColumna("Factura", "factura"));
            dgvDetalle.Columns.Add(setColumna("Destinatario", "destinatario"));
            dgvDetalle.Columns.Add(setColumna("idProcesoControlDespachoDet", "idProcesoControlDespachoDet", false));


            // FORMATEAMOS
            formatearDataGridView();

        }

        private DataGridViewTextBoxColumn setColumna(string titulo, string nombre,bool visible = true,bool tipofecha = false)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = titulo;
            col.Name = nombre;
            col.DataPropertyName = nombre;
            col.Visible = visible;
            return col;
        }


        // FORMATEAMOS COLUMNAS DATAGRID
        private void formatearDataGridView()
        {
            // ACTUALIZAMOS
            dgvDetalle.Columns["Nc"].Width = 50;

            // OCULTAMOS COLUMNA DE ID
            dgvDetalle.Columns["idProcesoControlDespachoDet"].Visible = false;
            dgvDetalle.Columns["Total"].ReadOnly = false;


            // OBTENEMOS INDICE DE LA COLUMNA TOTAL
            int indiceTotal = dgvDetalle.Columns["Total"].Index;

            foreach (DataGridViewColumn col in dgvDetalle.Columns)
            {
                // ASIGANMOS
                //col.DataPropertyName = col.Name;

                if (col.Index >= indiceInicioTallas && col.Index < indiceTotal )
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    col.ReadOnly = false;
                }
            }

        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calcularTotalPorFila(e.RowIndex);
        }

        private void calcularTotalPorFila(int indiceFila)
        {
            // REGISTRO NUEVO
            int indiceTotal = dgvDetalle.Columns["Total"].Index;

            //int indiceFila = e.RowIndex;
            int cantidadTotal = 0;

            // SUMAMOS CANTIDADES
            for (int x = indiceInicioTallas; x < indiceTotal; x++)
            {
                string valor = dgvDetalle.Rows[indiceFila].Cells[x].Value != null ? dgvDetalle.Rows[indiceFila].Cells[x].Value.ToString() : "";
                cantidadTotal += (valor == "" ? 0 : Convert.ToInt32(valor));
            }
            dgvDetalle.Rows[indiceFila].Cells["Total"].Value = cantidadTotal;
         

        }


        private void txtCliente_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    BuscarProvClienteView frm = new BuscarProvClienteView();
            //    frm.ShowDialog();
            //    txtCliente.Text = frm.provCliente;
            //    codCliente = frm.codProvCliente;
            //    txtRucProveedor.Focus();
            //}
        }


        private void dgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            int indiceOs = dgvDetalle.CurrentCell.ColumnIndex;
            if (indiceOs == 1)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int indiceRow = dgvDetalle.CurrentRow.Index;
                    int idOs = dgvDetalle.Rows[indiceRow].Cells["OrdenServicio"].Value != null ? Convert.ToInt32(dgvDetalle.Rows[indiceRow].Cells["OrdenServicio"].Value.ToString()) : 0; ;
                    var responseTalla = _dispatchControlBL.GetDetalleTallasOs(idOs).ToList();
                    if (responseTalla.Count > 0)
                    {

                        // RECORRREMOS COLUMNAS DE LA TALLA
                        foreach (var item in responseTalla)
                        {
                            // RECORREMOS COLUMNAS DEL DGV
                            foreach (DataGridViewColumn col in dgvDetalle.Columns)
                            {
                                if (col.Name == item.talla)
                                {
                                    dgvDetalle.Rows[indiceRow].Cells[col.Name].Value = item.cantidad;

                                }
                            }
                        }

                        // CALCULAMOS TOTAL
                        calcularTotalPorFila(indiceRow);


                    }

                }

            }
        }


        // GUARDAR CABECERA
        private void GuardarCabecera()
        {
            cabecera.idProcesoControlDespachoCab = cabecera.idProcesoControlDespachoCab != null ? cabecera.idProcesoControlDespachoCab : null;
            cabecera.idProcesoControl = 1;
            cabecera.idPedidoColor = idPedidoColor;
            cabecera.cliente = txtCliente.Text.Trim();
            cabecera.idProveedor = txtRucProveedor.Text.Trim();
            cabecera.usuario = UserApplication.USUARIO;
            // CARGAMOS
            parametrosRegistros param = new parametrosRegistros();
            param.idProcesoControlDespachoCab = cabecera.idProcesoControlDespachoCab;
            param.idProcesoControl = cabecera.idProcesoControl;
            param.idPedidoColor = cabecera.idPedidoColor;
            param.cliente = cabecera.cliente;
            param.idProveedor = cabecera.idProveedor;
            param.usuario = cabecera.usuario;

            // REGISTRA
            var response = _dispatchControlBL.SetControlDespacho(1, param);
            cabecera.idProcesoControlDespachoCab = response.id;


        }

        // ELIMINOS DETALLE
        private void EliminarDetalleTallas(int idDetalle)
        {
            parametrosRegistros param = new parametrosRegistros();
            param.idProcesoControlDespachoDet = idDetalle;
            _dispatchControlBL.SetControlDespacho(3, param);
        }

        // GUARDAMOS DETALLE
        private void GuardarDetalle()
        {
            // RECORREMOS

            for (int x = 0; x <  dgvDetalle.Rows.Count - 1; x++)
            {
                parametrosRegistros detalle = new parametrosRegistros();

                detalle.idProcesoControlDespachoCab = cabecera.idProcesoControlDespachoCab;

                detalle.idProcesoControlDespachoDet = null;
                detalle.numeroCorte = 0;
                detalle.fechaGuia           = dgvDetalle.Rows[x].Cells["FechaGuia"].Value == null ? null : dgvDetalle.Rows[x].Cells["FechaGuia"].Value.ToString();
                detalle.guia                = dgvDetalle.Rows[x].Cells["Guia"].Value == null ? null : dgvDetalle.Rows[x].Cells["Guia"].Value.ToString();
                detalle.fechaFactura        = dgvDetalle.Rows[x].Cells["FechaFactura"].Value == null ? null : dgvDetalle.Rows[x].Cells["FechaFactura"].Value.ToString();
                detalle.factura             = dgvDetalle.Rows[x].Cells["Factura"].Value == null ? null : dgvDetalle.Rows[x].Cells["Factura"].Value.ToString();
                detalle.ordenServicio       = dgvDetalle.Rows[x].Cells["OrdenServicio"].Value == null ? null : dgvDetalle.Rows[x].Cells["OrdenServicio"].Value.ToString();
                detalle.destinario          = dgvDetalle.Rows[x].Cells["Destinatario"].Value == null ? null : dgvDetalle.Rows[x].Cells["Destinatario"].Value.ToString(); 


                var response = _dispatchControlBL.SetControlDespacho(2, detalle);
                // ELIMINAMOS DETALLE
                EliminarDetalleTallas(response.id);

                // REGISTRAMOS DETALLE DE TALLAS
                int indiceTotal = dgvDetalle.Columns["Total"].Index;

                // RECORREMOS DETALLE DE TALLAS
                for (int y = indiceInicioTallas; y < indiceTotal; y++)
                {
                    string valor = dgvDetalle.Rows[x].Cells[y].Value == null ? "0" : dgvDetalle.Rows[x].Cells[y].Value.ToString();
                    string nombreTalla = dgvDetalle.Columns[y].Name;
                    if (valor != "")
                    {
                        parametrosRegistros detalletalla = new parametrosRegistros();
                        detalletalla.idProcesoControlDespachoDet = response.id;
                        detalletalla.cantidad = Convert.ToInt32(valor);

                        // BUSCAMOS TALLAS
                        string codTalla = tallas.Find(obj => obj.descripcion == nombreTalla).codTalla;
                        detalletalla.codTalla = codTalla;
                        var responseTalla = _dispatchControlBL.SetControlDespacho(4, detalletalla);
                            
                    }

                }
                


            }

            btnEliminar.Enabled = true;
            // MOSTRAMOS MENSAJE DE REGISTRO CORRECTAMENTE
            ResponseMessage.Message("Registrado Correctamente", "INFORMATION");


        }

        private void btnBuscarOP_Click(object sender, EventArgs e)
        {
            BuscarPedidosColorView frm = new BuscarPedidosColorView();
            frm.ShowDialog();
            txtOrdenProduccion.Text = frm.pedidoParam;
            txtColor.Text = frm.colorParam;
            txtEstilo.Text = frm.estiloParam;
            idPedidoColor = frm.idPedidoColorParam;
            txtCliente.Focus();

        }

        private void btnBuscarRuc_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // REGISTRAMOS CABECERA
            GuardarCabecera();
            // REGISTRAMOS DETALLE
            GuardarDetalle();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            frmBuscarDispatchControlView frmbusqueda = new frmBuscarDispatchControlView();
            frmbusqueda.ShowDialog();
            cabecera.idProcesoControlDespachoCab = frmbusqueda.id;


            cabecera.idProcesoControlDespachoCab = frmbusqueda.idProcesoControlDespachoCabBusqueda;
            idPedidoColor = frmbusqueda.id;
            txtEstilo.Text = frmbusqueda.estiloBusqueda;
            txtOrdenProduccion.Text = frmbusqueda.pedidoBusqueda;
            txtCliente.Text = frmbusqueda.clienteBusqueda;
            txtRucProveedor.Text = frmbusqueda.idProveedorBusqueda;
            txtColor.Text = frmbusqueda.colorBusqueda;


            DtDetalle = _dispatchControlBL.GetControlDespachoDetalleTalla(cabecera.idProcesoControlDespachoCab);
            // CARGAMOS
            dgvDetalle.Rows.Clear();

            for (int x = 0; x < DtDetalle.Rows.Count; x++)
            {
                int index = dgvDetalle.Rows.Add();

                // RECORREMSO COLUMANS
                foreach (DataGridViewColumn col in dgvDetalle.Columns)
                {
                    string nombreColumna = col.Name;
                    dgvDetalle.Rows[index].Cells[nombreColumna].Value = DtDetalle.Rows[x][nombreColumna].ToString();
                }

            }

            btnEliminar.Enabled = true;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoControlDespacho();
        }

        private void NuevoControlDespacho()
        {
            cabecera = new controlDespachoCab();
            txtOrdenProduccion.Clear();
            txtEstilo.Clear();
            txtColor.Clear();
            txtCliente.Clear();
            txtRucProveedor.Clear();
            dgvDetalle.Rows.Clear();
            btnEliminar.Enabled = false;
        }

        // ELIMINAMOS
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ResponseMessage.MessageQuestion("Confirme para Eliminar Control de Despacho") == DialogResult.OK)
            {

                var responseEliminado = _dispatchControlBL.SetControlDespacho(5, new parametrosRegistros {
                    idProcesoControlDespachoCab = cabecera.idProcesoControlDespachoCab
                });

                ResponseMessage.Message("Eliminado Correctamente", "INFORMATION");
                NuevoControlDespacho();


            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = @"C:\";
                sfd.Title = "Guardar Archivo Como";
                sfd.Filter = "Excel |*.xlsx";
                sfd.FileName = "reporteexportado.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(sfd.FileName))
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Hoja1");

                            // CABECERAS
                            worksheet.Cell(2, 1).Value = "Orden Producción";
                            worksheet.Cell(2, 2).Value = txtOrdenProduccion.Text.Trim();

                            worksheet.Cell(2, 5).Value = "Estilo";
                            worksheet.Cell(2, 6).Value = txtEstilo.Text.Trim();

                            worksheet.Cell(2, 9).Value = "Color";
                            worksheet.Cell(2, 10).Value = txtColor.Text.Trim();


                            worksheet.Cell(3, 1).Value = "Cliente";
                            worksheet.Cell(3, 2).Value = txtCliente.Text.Trim();

                            worksheet.Cell(3, 9).Value = "Ruc Proveedor:";
                            worksheet.Cell(3, 10).Value = txtRucProveedor.Text.Trim();


                            // Agregar los encabezados de las columnas
                            for (int i = 1; i <= dgvDetalle.Columns.Count; i++)
                            {
                                worksheet.Cell(5, i).Value = dgvDetalle.Columns[i - 1].HeaderText;
                            }

                            // Agregar datos
                            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvDetalle.Columns.Count; j++)
                                {
                                    worksheet.Cell(i + 6, j + 1).Value = dgvDetalle.Rows[i].Cells[j].Value;
                                }
                            }

                            // Guardar el archivo Excel
                            workbook.SaveAs(sfd.FileName);
                        }

                        ResponseMessage.Message("Reporte Exportado", "INFORMATION");
                    };
                }
            }
        }
    }
}