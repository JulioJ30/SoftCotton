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
    public partial class RegistroTipoCambioView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetTipoCambioParam _tipoCambioParam;

        public RegistroTipoCambioView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void RegistroTipoCambioView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            valoresPredeterminados();
            ListarTiposMonedas();

            dtpFecha.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            valoresPredeterminados();
            
            dtpFecha.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                dtpFecha.Value = Convert.ToDateTime(dgvListado.Rows[e.RowIndex].Cells["ctxtFecha"].Value.ToString()).Date;
                cbxMoneda.SelectedValue = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["ctxtIntTipoMoneda"].Value.ToString());
                txtCompra.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCompra"].Value.ToString();
                txtVenta.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtVenta"].Value.ToString();

                dtpFecha.Enabled = false;
                cbxMoneda.Enabled = false;
                
            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            {
                string fecha = Convert.ToDateTime(dgvListado.Rows[e.RowIndex].Cells["ctxtFecha"].Value).ToString("yyyyMMdd");
                int idTipoMoneda = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["ctxtIntTipoMoneda"].Value.ToString());

                DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                if (pregunta.Equals(DialogResult.OK))
                {
                    _tipoCambioParam = new SetTipoCambioParam();
                    _tipoCambioParam.opcion = 2; // ELIMINAR 
                    _tipoCambioParam.fecha = fecha;
                    _tipoCambioParam.idTipoMoneda = idTipoMoneda;
                    _tipoCambioParam.usuarioReg = UserApplication.USUARIO;

                    Procesar(_tipoCambioParam);
                }
                
            }
        }
        

        // ### Funciones ###
        public void ListarTiposMonedas()
        {
            List<GetMant24_TipoMoneda> cbxMonedasList = _mantenimientoBL.Get24_TipoMoneda();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxMonedasList;

            cbxMoneda.DisplayMember = "moneda";
            cbxMoneda.ValueMember = "idTipoMoneda";
            cbxMoneda.DataSource = bindingSource.DataSource;
        }

        public void Guardar()
        {
            if (ValidarDatos())
            {
                _tipoCambioParam = new SetTipoCambioParam();

                _tipoCambioParam.opcion = 1; // REGISTRAR
                _tipoCambioParam.fecha = dtpFecha.Value.ToString("yyyyMMdd");
                _tipoCambioParam.idTipoMoneda = Convert.ToInt32(cbxMoneda.SelectedValue.ToString());
                _tipoCambioParam.compra = Convert.ToDecimal(txtCompra.Text.Trim());
                _tipoCambioParam.venta = Convert.ToDecimal(txtVenta.Text.Trim());
                _tipoCambioParam.usuarioReg = UserApplication.USUARIO;

                Procesar(_tipoCambioParam);
            }
        }

        public void Procesar(SetTipoCambioParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetTipoCambio(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar();
                Listar();

                dtpFecha.Enabled = true;
                cbxMoneda.Enabled = true;
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        public void Listar()
        {
            List<GetMant23_TipoCambio> listaTipoDoc = _mantenimientoBL.Get23_TipoCambio();

            dgvListado.Rows.Clear();

            foreach (var item in listaTipoDoc)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtFecha"].Value = item.fecha;
                dgvListado.Rows[index].Cells["ctxtTipoMoneda"].Value = item.monedaSingular;
                dgvListado.Rows[index].Cells["ctxtIntTipoMoneda"].Value = item.idTipoMoneda;
                dgvListado.Rows[index].Cells["ctxtCompra"].Value = item.compra;
                dgvListado.Rows[index].Cells["ctxtVenta"].Value = item.venta;

                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;
                
                dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.LightCoral;
                dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.LightCoral;
                
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }


        private bool ValidarDatos()
        {
            bool validacion = false;

            if (cbxMoneda.SelectedValue.ToString() == "0")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione un tipo de moneda", "INFORMATION");
                cbxMoneda.Focus();
            }
            else if (string.IsNullOrEmpty(txtCompra.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el valor de compra", "INFORMATION");
                txtCompra.Focus();
            }
            else if (string.IsNullOrEmpty(txtVenta.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el valor de venta", "INFORMATION");
                txtVenta.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCompra.Text = "0";
            txtVenta.Text = "0";
        }

        private void valoresPredeterminados()
        {
            dtpFecha.Value = DateTime.Now.Date;
            cbxMoneda.SelectedValue = 2;
            dtpFecha.Enabled = true;
            cbxMoneda.Enabled = true;

        }


    }
}
