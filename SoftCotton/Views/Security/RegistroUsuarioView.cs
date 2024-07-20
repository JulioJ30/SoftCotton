using SoftCotton.BusinessLogic;
using SoftCotton.Model.Security;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.Security
{
    public partial class RegistroUsuarioView : Form
    {
        SeguridadBL _seguridadBL;
        SetUsuarioParam _usuarioParam;
        protected string _usuarioLogin;

        public RegistroUsuarioView()
        {
            InitializeComponent();

            _seguridadBL = new SeguridadBL();

            UserApplication.USUARIO = "jmoran";
        }

        // ### EVENTOS ###

        private void RegistroUsuarioView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            ListarPersonasCBX();
            cbxPersonas.Enabled = true;

            cbxPersonas.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            ListarPersonasCBX();
            cbxPersonas.Enabled = true;

            cbxPersonas.Focus();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Guardar();
            }
        }


        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
                {
                    lblIdUsuario.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdUsuario"].Value.ToString();
                    cbxPersonas.SelectedValue = dgvListado.Rows[e.RowIndex].Cells["ctxtNumDoc"].Value.ToString();
                    txtUsuario.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtUsuario"].Value.ToString();
                    txtContrasena.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtContrasena"].Value.ToString();

                    cbxPersonas.Enabled = false;
                }
                else
                {
                    Limpiar();
                }
            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
                {
                    int idUsuario = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntIdUsuario"].Value.ToString());
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _usuarioParam = new SetUsuarioParam();

                        _usuarioParam.opcion = 4; // ELIMINAR 
                        _usuarioParam.idUsuario = idUsuario;
                        _usuarioParam.usuario = UserApplication.USUARIO;

                        Procesar(_usuarioParam);
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
            if (e.RowIndex >= 0 && dgvListado.Columns[e.ColumnIndex].Name.Equals("cbxActivo"))
            {
                DataGridViewRow row = dgvListado.Rows[e.RowIndex];
                bool valorCheck = !Convert.ToBoolean(row.Cells["cbxActivo"].Value);
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
                    row.Cells["cbxActivo"].Value = valorCheck;

                    _usuarioParam = new SetUsuarioParam();

                    _usuarioParam.opcion = 3; // INHABILITAR
                    _usuarioParam.idUsuario = Convert.ToInt32(row.Cells["cIntIdUsuario"].Value);
                    _usuarioParam.usuarioReg = UserApplication.USUARIO;
                    _usuarioParam.estado = valorCheck;

                    Procesar(_usuarioParam);
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // ### FUNCIONES ###

        public void ListarPersonasCBX()
        {
            List<GetAcceso4_Personas> cbxTipoDocList = _seguridadBL.Get4_Personas();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxTipoDocList;

            cbxPersonas.DisplayMember = "persona";
            cbxPersonas.ValueMember = "numDoc";
            cbxPersonas.DataSource = bindingSource.DataSource;
        }


        public void Guardar()
        {
            if (ValidarDatos())
            {
                _usuarioParam = new SetUsuarioParam();

                if (Convert.ToInt32(lblIdUsuario.Text) > 0)
                {
                    _usuarioParam.opcion = 2; // ACTUALIZAR
                    _usuarioParam.idEmpresa = 1;
                    _usuarioParam.idUsuario = Convert.ToInt32(lblIdUsuario.Text);
                    _usuarioParam.usuario = txtUsuario.Text.Trim();
                    _usuarioParam.contrasena = txtContrasena.Text.Trim();
                    _usuarioParam.numDoc = cbxPersonas.SelectedValue.ToString();
                    _usuarioParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _usuarioParam.opcion = 1; // REGISTRAR
                    _usuarioParam.idEmpresa = 1;
                    _usuarioParam.idUsuario = 0;
                    _usuarioParam.usuario = txtUsuario.Text.Trim();
                    _usuarioParam.contrasena = txtContrasena.Text.Trim();
                    _usuarioParam.numDoc = cbxPersonas.SelectedValue.ToString();
                    _usuarioParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_usuarioParam);
            }
        }


        public void Procesar(SetUsuarioParam parametro)
        {
            Response responseGeneral = _seguridadBL.SetUsuario(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar();
                Listar();
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }


        public void Listar()
        {
            List<GetMant1_Usuarios> listaUsuarios = _seguridadBL.GetMant1_Usuarios();

            dgvListado.Rows.Clear();

            foreach (var item in listaUsuarios)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntIdUsuario"].Value = item.id;
                dgvListado.Rows[index].Cells["ctxtUsuario"].Value = item.usuario;
                dgvListado.Rows[index].Cells["ctxtContrasena"].Value = item.contrasena;
                dgvListado.Rows[index].Cells["ctxtNumDoc"].Value = item.numDoc;
                dgvListado.Rows[index].Cells["ctxtPersona"].Value = item.persona;
                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;

                if (item.estado)
                {
                    dgvListado.Rows[index].Cells["cbxActivo"].Value = true;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.LightCoral;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.LightCoral;   
                }
                else
                {
                    dgvListado.Rows[index].Cells["cbxActivo"].Value = false;
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

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el usuario", "INFORMATION");
                txtUsuario.Focus();
            }
            else if (cbxPersonas.SelectedValue.ToString() == "0")
            {
                validacion = false;
                ResponseMessage.Message("Seleccione", "INFORMATION");

                cbxPersonas.Focus();
            }
            else if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                validacion = false;
                ResponseMessage.Message("Ingrese la contraseña", "INFORMATION");
                txtContrasena.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            lblIdUsuario.Text = "0";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            cbxPersonas.SelectedValue = "0";
        }

      
    }
}
