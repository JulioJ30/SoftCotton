using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Requerimiento
{
    public partial class RegistrarRequerimiento : Form
    {
        private frmListaRequerimiento frmListaRequerimientox;

        List<E_Producto_Reque> items = new List<E_Producto_Reque>();
        MantenimientoBL _mantenimientoBL = new MantenimientoBL();

        bool editar = true;

        KardexBL _kardexBL = new KardexBL();
        public RegistrarRequerimiento(frmListaRequerimiento frm)
        {
            InitializeComponent();
            frmListaRequerimientox = frm;
        }

        private void RegistrarRequerimiento_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = UserApplication.USUARIO;

            List<SetAreasAlmacen> listaCeCos = _mantenimientoBL.GetListarAreasAlmacen(txtCodigo.Text);
            cbAlmacen.DataSource = listaCeCos;
            cbAlmacen.DisplayMember = "Descripcion";
            cbAlmacen.ValueMember = "Codigo";


            CbAlmacen2.DataSource = _mantenimientoBL.SetDatatable(62, UserApplication.USUARIO, "", 0, 0);
            CbAlmacen2.DisplayMember = "Descripcion";
            CbAlmacen2.ValueMember = "codAlmacen";

            if (VariableGeneral.codigoAlmacen != "")
            {
                DataTable tbl;
                tbl = _mantenimientoBL.SetDatatable(65, UserApplication.USUARIO, "", 0, 0);

                cbAlmacen.SelectedValue = VariableGeneral.codigoAlmacen;
                CbAlmacen2.SelectedValue = VariableGeneral.codigoAlmacenReq;
                lblEstado.Text = VariableGeneral.estadoRequerimiento;
                lblIdRequerimiento.Text = VariableGeneral.idRequerimiento;
                txtObservacion.Text = VariableGeneral.observacion;
                IniciarRequer(false);

                DataTable dt = _mantenimientoBL.SetDatatable(64, VariableGeneral.idRequerimiento, "", 0, 0);
                DgvLista.DataSource = dt;
                lblCantidad.Text = dt.Rows.Count.ToString();

                editar = (tbl.Rows[0][0].ToString() == "0") ? false : true;
                DgvLista.Enabled = (tbl.Rows[0][0].ToString() != "0") ? true : false;

                btnProcesar.Enabled = VariableGeneral.Estado == "0" && editar == true ? true : false;
                BtnAnular.Enabled = VariableGeneral.Estado == "2" ? false : true;
               
                //btnProcesar.Enabled = (editar != true) ? false : true;
                
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (lblProducto.Text == string.Empty)
            {
                ResponseMessage.Message("Debe Buscar un Articulo", "WARNING");
                return;
            }

            if (txtCantidad.Text == "0" || txtCantidad.Text == string.Empty)
            {
                ResponseMessage.Message("Ingrese valor cantidad", "WARNING");
                return;
            }

            //if (Convert.ToDouble(txtCantidad.Text) >  Convert.ToDouble(txtStock.Text))
            //{
            //    ResponseMessage.Message("Ingrese valor cantidad", "WARNING");
            //    return;
            //}
            int maxItem = 0;
            if (items.Count > 0)
            {
                maxItem = items.Max(i => i.item);
            }
            else
            {
                maxItem = 0;
            }


            E_Producto_Reque _item;
            _item = new E_Producto_Reque();
            _item.item = maxItem + 1;
            _item.codigo = txtCodigo.Text;
            _item.producto = lblProducto.Text;
            _item.unidad_medida = lblUnidad.Text;
            _item.cantidad = Convert.ToDouble(txtCantidad.Text);
            _item.stock = Convert.ToDouble(txtStock.Text); // - Convert.ToDouble(txtCantidad.Text);
            _item.cantidad_atendida = 0;

            items.Add(_item);

            DgvLista.DataSource = items.ToList();

            txtCodigo.Text = string.Empty;
            lblProducto.Text = string.Empty;
            lblUnidad.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtStock.Text = string.Empty;
            lblCantidad.Text = items.Count.ToString();

            DgvLista.ClearSelection();
            txtCodigo.Focus();

        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvLista.Columns["eliminar"].Index && e.RowIndex >= 0)
            {
                if (editar)
                {
                    int item = Convert.ToInt32(DgvLista.Rows[e.RowIndex].Cells["item"].Value.ToString());
                    E_Producto_Reque productoAEliminar = items.Find(p => p.item == item);

                    if (productoAEliminar != null)
                    {
                        items.Remove(productoAEliminar);
                    }
                    DgvLista.DataSource = items.ToList();
                    DgvLista.ClearSelection();

                    if (DgvLista.RowCount == 0)
                    {
                        cbAlmacen.Enabled = true;
                        CbAlmacen2.Enabled = true;
                    }
                    else
                    {
                        cbAlmacen.Enabled = false;
                        CbAlmacen2.Enabled = false;
                    }
                }
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            VariableGeneral._sEnter = false;

            if (e.KeyCode == Keys.F2)
            {
                ListaArticulo formulario = new ListaArticulo(cbAlmacen.SelectedValue.ToString());
                formulario.ShowDialog();

                if (VariableGeneral._sEnter)
                {
                    txtCodigo.Text = VariableGeneral._sCodigo;
                    lblProducto.Text = VariableGeneral._sDescr;
                    lblUnidad.Text = VariableGeneral.UND;
                    txtStock.Text = VariableGeneral.stock.ToString();
                    txtCantidad.Focus();
                    cbAlmacen.Enabled = false;
                    CbAlmacen2.Enabled = false;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string resultado = _kardexBL.RegistrarReq_Cabe(0, cbAlmacen.SelectedValue.ToString(), CbAlmacen2.SelectedValue.ToString(), 0, txtObservacion.Text, UserApplication.ID_USUARIO);

            foreach (var item in items)
            {
                _kardexBL.RegistrarReq_Deta(Convert.ToInt32(resultado), item.codigo, item.cantidad, item.stock, item.cantidad_atendida);
            }

            if (resultado != "")
            {
                lblEstado.Text = "CREADO";
                lblIdRequerimiento.Text = resultado;

                ResponseMessage.Message("Requerimiento Generado Correctamente " + lblIdRequerimiento.Text, "INFORMATION");
                frmListaRequerimientox.DgvLista.DataSource = _mantenimientoBL.SetDatatable(63, UserApplication.USUARIO, "", 0, 0);
                IniciarRequer(false);
            }
            else
            {
                ResponseMessage.Message("Error al Generar Requerimiento", "ERROR");
            }
        }

        void IniciarRequer(bool val)
        {

            BtnAgregar.Enabled = val;
            txtObservacion.Enabled = val;
            btnGrabar.Enabled = val;
            DgvLista.Enabled = val;
            cbAlmacen.Enabled = val;
            CbAlmacen2.Enabled = val;
            txtCantidad.Enabled = val;
            txtCodigo.Enabled = val;

            if (val)
            {
                txtObservacion.Text = string.Empty;
                lblEstado.Text = string.Empty;
                lblUsuario.Text = string.Empty;
                lblIdRequerimiento.Text = string.Empty;

                txtCodigo.Text = string.Empty;
                lblProducto.Text = string.Empty;
                lblUnidad.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtStock.Text = string.Empty;
                lblCantidad.Text = items.Count.ToString();

                items.Clear();
                DgvLista.DataSource = items.ToList();
                DgvLista.ClearSelection();
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            procesar(1, "Procesado");
        }

        private void DgvLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvLista.ClearSelection();
        }

        void procesar(int tipo, string mensaje)
        {
            if (editar == false && VariableGeneral.Estado == "1")
            {
                ResponseMessage.Message("Requerimiento no se puede Anular por este usuario, consulte con el administrador ", "WARNING");
                return;                
            }


            string resultado = _kardexBL.update_RequerimientoCabe(tipo, Convert.ToDouble(lblIdRequerimiento.Text), UserApplication.ID_USUARIO);

            if (tipo == 2)
            {
                if (VariableGeneral.Estado == "0")
                {
                    ResponseMessage.Message("Requerimiento " + mensaje + " Correctamente: " + lblIdRequerimiento.Text, "INFORMATION");
                    frmListaRequerimientox.DgvLista.DataSource = _mantenimientoBL.SetDatatable(63, UserApplication.USUARIO, "", 0, 0);
                    Close();
                }
            }
           


            if (VariableGeneral.Estado == "1" || VariableGeneral.Estado == "0")
            {
                string resu = "";
                if (resultado != "")
                {
                    E_Producto_Reque d_ite;
                    d_ite = new E_Producto_Reque();
                    foreach (DataGridViewRow row in DgvLista.Rows)
                    {
                        string item = row.Cells["item"].Value?.ToString() ?? string.Empty;
                        string codigo = row.Cells["Codigo"].Value?.ToString() ?? string.Empty;
                        string producto = row.Cells["producto"].Value?.ToString() ?? string.Empty;
                        string unidad_medida = row.Cells["unidad_medida"].Value?.ToString() ?? string.Empty;
                        string cantidad = row.Cells["cantidad"].Value?.ToString() ?? string.Empty;
                        string stock = row.Cells["stock"].Value?.ToString() ?? string.Empty;
                        string cantidad_atendida = row.Cells["cantidad_atendida"].Value?.ToString() ?? string.Empty;

                        d_ite.item = Convert.ToInt32(item);
                        d_ite.codigo = codigo;
                        d_ite.producto = producto;
                        d_ite.unidad_medida = unidad_medida;
                        d_ite.cantidad = Convert.ToDouble(cantidad);
                        d_ite.stock = Convert.ToDouble(stock);
                        d_ite.cantidad_atendida = Convert.ToDouble(cantidad_atendida);

                        resu = _kardexBL.update_RequerimientoDeta(tipo, d_ite, Convert.ToDouble(lblIdRequerimiento.Text),
                            VariableGeneral.codigoAlmacen, VariableGeneral.codigoAlmacenReq, UserApplication.USUARIO);
                    }

                    if (resu != "")
                    {
                        ResponseMessage.Message("Requerimiento " + mensaje + " Correctamente " + lblIdRequerimiento.Text, "INFORMATION");
                        frmListaRequerimientox.DgvLista.DataSource = _mantenimientoBL.SetDatatable(63, UserApplication.USUARIO, "", 0, 0);
                        Close();
                    }
                    else
                    {
                        ResponseMessage.Message("Error al " + mensaje + " Requerimiento " + lblIdRequerimiento.Text, "ERROR");
                    }

                }
                else
                {
                    ResponseMessage.Message("Error al " + mensaje + " Requerimiento", "ERROR");
                }
            }

        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            procesar(2, "Anulado");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
