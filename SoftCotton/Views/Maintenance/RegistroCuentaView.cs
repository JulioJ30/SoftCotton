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
    public partial class RegistroCuentaView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetCuentaParam _cecoParam;

        public RegistroCuentaView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            
        }

        private void RegistroCuentaView_Load(object sender, EventArgs e)
        {
            Limpiar();
            ValoresPredeterminados();
            Listar();
            ListarCuentaNivelesCBX();
            ListarCuentaTiposCBX();

            txtCodCuenta.Focus();
        }
        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            ListarCuentaNivelesCBX();
            ListarCuentaTiposCBX();

            txtCodCuenta.Focus();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["dgvChxActivo"].Value))
                {
                    lblCodCuenta.Text = dgvListado.Rows[e.RowIndex].Cells["dgvTxtCodCuenta"].Value.ToString();
                    txtCodCuenta.Text = dgvListado.Rows[e.RowIndex].Cells["dgvTxtCodCuenta"].Value.ToString();
                    txtCuenta.Text = dgvListado.Rows[e.RowIndex].Cells["dgvTxtCuenta"].Value.ToString();
                    cbxNivelCuenta.SelectedValue = dgvListado.Rows[e.RowIndex].Cells["dgvTxtCodNivelCuenta"].Value.ToString();
                    cbxTipoCuenta.SelectedValue = dgvListado.Rows[e.RowIndex].Cells["dgvTxtCodTipoCuenta"].Value.ToString();
                    txtCuentaAmarreDebe.Text = dgvListado.Rows[e.RowIndex].Cells["dgvTxtCuentaAmarreDebe"].Value.ToString();
                    txtCuentaAmarreHaber.Text = dgvListado.Rows[e.RowIndex].Cells["dgvTxtCuentaAmarreHaber"].Value.ToString();

                    var checkkardex = dgvListado.Rows[e.RowIndex].Cells["dgvChxMostrarKardex"].Value;
                    chkMostrarKardex.Checked = (bool)checkkardex;


                }
                else
                {
                    Limpiar();
                }
            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["dgvChxActivo"].Value))
                {
                    string codCuenta = dgvListado.Rows[e.RowIndex].Cells["dgvTxtCodCuenta"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _cecoParam = new SetCuentaParam();
                        _cecoParam.opcion = 4; // ELIMINAR 
                        _cecoParam.codCuenta = codCuenta;
                        _cecoParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_cecoParam);
                    }
                }
                else
                {
                    Limpiar();
                }
            }
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvListado.Columns[e.ColumnIndex].Name.Equals("dgvChxActivo"))
            {
                DataGridViewRow row = dgvListado.Rows[e.RowIndex];
                bool valorCheck = !Convert.ToBoolean(row.Cells["dgvChxActivo"].Value);
                string pregunta = "";

                if (valorCheck)
                {
                    pregunta = "¿Desea activar usuario?";
                }
                else
                {
                    pregunta = "¿Desea deshabilitar el usuario?";
                }

                DialogResult resultadoPregunta = ResponseMessage.MessageQuestion(pregunta);

                if (resultadoPregunta.Equals(DialogResult.OK))
                {
                    row.Cells["dgvChxActivo"].Value = valorCheck;

                    _cecoParam = new SetCuentaParam();

                    _cecoParam.opcion = 3; // INHABILITAR
                    _cecoParam.codCuenta = row.Cells["dgvTxtCodCuenta"].Value.ToString();
                    _cecoParam.usuarioReg = UserApplication.USUARIO;
                    _cecoParam.estado = valorCheck;

                    Procesar(_cecoParam);
                }
            }
        }

        private void txtCuentaAmarreHaber_Leave(object sender, EventArgs e)
        {
            btnGuardar.Focus();
        }



        // ### Funciones ###
        public void ListarCuentaNivelesCBX()
        {
            List<GetMant28_CuentaNivelCBX> cbxNivelesList = _mantenimientoBL.Get28_CuentaNiveles();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxNivelesList;

            cbxNivelCuenta.DisplayMember = "cuentaNivel";
            cbxNivelCuenta.ValueMember = "codCuentaNivel";
            cbxNivelCuenta.DataSource = bindingSource.DataSource;
        }

        public void ListarCuentaTiposCBX()
        {
            List<GetMant29_CuentaTipoCBX> cbxTiposList = _mantenimientoBL.Get29_CuentaTipos();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxTiposList;

            cbxTipoCuenta.DisplayMember = "cuentaTipo";
            cbxTipoCuenta.ValueMember = "codCuentaTipo";
            cbxTipoCuenta.DataSource = bindingSource.DataSource;
        }



        public void Guardar()
        {
            if (ValidarDatos())
            {
                _cecoParam = new SetCuentaParam();

                if (!string.IsNullOrEmpty(lblCodCuenta.Text))
                {
                    _cecoParam.opcion = 2; // ACTUALIZAR
                    _cecoParam.codCuenta = lblCodCuenta.Text;
                    _cecoParam.codCuentaUpdate = txtCodCuenta.Text;
                    _cecoParam.cuenta = txtCuenta.Text.Trim();
                    _cecoParam.codCuentaNivel = cbxNivelCuenta.SelectedValue.ToString();
                    _cecoParam.codCuentaTipo = cbxTipoCuenta.SelectedValue.ToString();
                    _cecoParam.cuentaAmarreDebe = txtCuentaAmarreDebe.Text;
                    _cecoParam.cuentaAmarreHaber = txtCuentaAmarreHaber.Text;
                    _cecoParam.FlgMostrarKardex = chkMostrarKardex.Checked;
                    _cecoParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _cecoParam.opcion = 1; // REGISTRAR
                    _cecoParam.codCuenta = txtCodCuenta.Text;
                    _cecoParam.codCuentaUpdate = "";
                    _cecoParam.cuenta = txtCuenta.Text.Trim();
                    _cecoParam.codCuentaNivel = cbxNivelCuenta.SelectedValue.ToString();
                    _cecoParam.codCuentaTipo = cbxTipoCuenta.SelectedValue.ToString();
                    _cecoParam.cuentaAmarreDebe = txtCuentaAmarreDebe.Text;
                    _cecoParam.cuentaAmarreHaber = txtCuentaAmarreHaber.Text;
                    _cecoParam.FlgMostrarKardex = chkMostrarKardex.Checked;

                    _cecoParam.usuarioReg = UserApplication.USUARIO;// UserApplication.USUARIO;
                }

                Procesar(_cecoParam);
            }
        }

        public void Procesar(SetCuentaParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetCuenta(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar();
                ValoresPredeterminados();
                Listar();
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        public void Listar()
        {
            List<GetMant27_Cuentas> listaCuentas = _mantenimientoBL.Get27_Cuentas();

            dgvListado.Rows.Clear();

            foreach (var item in listaCuentas)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["dgvTxtCodCuenta"].Value = item.codCuenta;
                dgvListado.Rows[index].Cells["dgvTxtCuenta"].Value = item.cuenta;
                dgvListado.Rows[index].Cells["dgvTxtCodNivelCuenta"].Value = item.codCuentaNivel;
                dgvListado.Rows[index].Cells["dgvTxtNivelCuenta"].Value = item.cuentaNivel;
                dgvListado.Rows[index].Cells["dgvTxtCodTipoCuenta"].Value = item.codCuentaTipo;
                dgvListado.Rows[index].Cells["dgvTxtTipoCuenta"].Value = item.cuentaTipo;

                dgvListado.Rows[index].Cells["dgvTxtCuentaAmarreDebe"].Value = item.cuentaAmarreDebe;
                dgvListado.Rows[index].Cells["dgvTxtCuentaAmarreHaber"].Value = item.cuentaAmarreHaber;

                dgvListado.Rows[index].Cells["dgvTxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["dgvTxtUsuarioReg"].Value = item.usuarioReg;
                dgvListado.Rows[index].Cells["dgvChxMostrarKardex"].Value = item.FlgMostrarKardex;


                if (item.estado)
                {
                    dgvListado.Rows[index].Cells["dgvChxActivo"].Value = true;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.LightCoral;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.LightCoral;
                }
                else
                {
                    dgvListado.Rows[index].Cells["dgvChxActivo"].Value = false;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.Gray;
                }
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }

        private bool ValidarDatos()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtCodCuenta.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Centro de Costo", "INFORMATION");
                txtCodCuenta.Focus();
            }
            else if (string.IsNullOrEmpty(txtCuenta.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el Centro de Costo", "INFORMATION");
                txtCuenta.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCodCuenta.Text = "";
            lblCodCuenta.Text = "";
            txtCuenta.Text = "";
            txtCuentaAmarreDebe.Text = "";
            txtCuentaAmarreHaber.Text = "";
        }

        private void ValoresPredeterminados()
        {
            cbxNivelCuenta.SelectedValue = "0";
            cbxTipoCuenta.SelectedValue = "0";
        }

     
    }
}
