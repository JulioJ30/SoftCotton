using SoftCotton.BusinessLogic;
using SoftCotton.DTO.Security;
using SoftCotton.Model.Enterprise;
using SoftCotton.Model.Security;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftCotton.Views.Security
{
    public partial class LoginView : Form
    {
        SeguridadBL _seguridadBL;
        EmpresaBL _empresaBL;
        List<Get1_Empresas> listaEmpresas;

        public LoginView()
        {
            InitializeComponent();

            _seguridadBL = new SeguridadBL();
            _empresaBL = new EmpresaBL();
            listaEmpresas = new List<Get1_Empresas>();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            ListarEmpresas();
            Limpiar();
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public void ListarEmpresas()
        {
            listaEmpresas = _empresaBL.Get1_Empresas();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = listaEmpresas;

            cbxEmpresas.DisplayMember = "rs";
            cbxEmpresas.ValueMember = "idEmpresa";
            cbxEmpresas.DataSource = bindingSource.DataSource;
        }



        private void IniciarSesion()
        {

            if (ValidarDatos())
            {
                LoginDTO login = new LoginDTO();
                GetLogin respuestaUsuario = new GetLogin();

                login.idEmpresa = Convert.ToInt32(cbxEmpresas.SelectedValue);
                login.usuario = txtUsuario.Text.Trim();
                login.contrasena = txtContrasena.Text.Trim();

                respuestaUsuario = _seguridadBL.Login(login);

                if (respuestaUsuario.id > 0)
                {
                    this.Hide();
                    PrincipalView principalView = new PrincipalView(respuestaUsuario.id.ToString(),
                                                                    respuestaUsuario.usuario,
                                                                    respuestaUsuario.nombres + " " + respuestaUsuario.apellidos);

                    UserApplication.ID_USUARIO = respuestaUsuario.id;
                    UserApplication.USUARIO = respuestaUsuario.usuario;
                    UserApplication.COLABORADOR = respuestaUsuario.nombres + " " + respuestaUsuario.apellidos;

                    Get1_Empresas empresa = listaEmpresas.Find(x => x.idEmpresa == Convert.ToInt32(cbxEmpresas.SelectedValue));
                    Empresa.ID_EMPRESA = empresa.idEmpresa;
                    Empresa.RUC = empresa.ruc;
                    Empresa.RS = empresa.rs;
                    Empresa.Validar_stock_exportacion = empresa.Validar_stock_exportacion;
                    Empresa.Activar_Transa_Kardex = empresa.Activar_Transa_Kardex;

                    principalView.Show();
                }
                else
                {
                    UserApplication.ID_USUARIO = 0;
                    UserApplication.USUARIO = "";
                    UserApplication.COLABORADOR = "";

                    Empresa.ID_EMPRESA = 0;
                    Empresa.RUC = "";
                    Empresa.RS = "";

                    ResponseMessage.Message("Usuario Incorrecto", "ERROR");
                }
            }

        }

        private bool ValidarDatos()
        {
            bool validacion = false;

            if (cbxEmpresas.SelectedValue == null)
            {
                validacion = false;

                ResponseMessage.Message("Seleccione la empresa", "INFORMATION");
                cbxEmpresas.Focus();
            }
            else if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el usuario", "INFORMATION");
                txtUsuario.Focus();
            }
            else if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                validacion = false;
                ResponseMessage.Message("Ingrese la contraseña", "INFORMATION");
                txtUsuario.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        private void Limpiar()
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                IniciarSesion();
            }
        }
    }
}
