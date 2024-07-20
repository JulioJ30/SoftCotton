using SoftCotton.BusinessLogic;
using SoftCotton.Model.Employee;
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

namespace SoftCotton.Views.Employee
{
    public partial class RegistroPersonaView : Form
    {
        EmpleadoBL _empleadoBL;
        MantenimientoBL _mantenimientoBL;

        SetPersonaParam _personaParam;

        public RegistroPersonaView()
        {
            InitializeComponent();

            _empleadoBL = new EmpleadoBL();
            _mantenimientoBL = new MantenimientoBL();
        }


        private void RegistroPersonaView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            ListarTipoDocumentoCBX();
            ValoresPredeterminado();

            cbxTipoDocumento.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            ListarTipoDocumentoCBX();
            ValoresPredeterminado();

            cbxTipoDocumento.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
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

                    _personaParam = new SetPersonaParam();

                    _personaParam.opcion = 3; // INHABILITAR
                    _personaParam.codTipoDoc = row.Cells["ctxtCodTipoDoc"].Value.ToString();
                    _personaParam.usuarioReg = UserApplication.USUARIO;

                    Procesar(_personaParam);
                }
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                txtNumDoc.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtNumDoc"].Value.ToString().Trim();
                lblNumDoc.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtNumDoc"].Value.ToString().Trim();

                cbxTipoDocumento.SelectedValue = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoDoc"].Value.ToString().Trim();
                txtNombres.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtNombres"].Value.ToString().Trim();
                txtApellidoPaterno.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtApellidoPaterno"].Value.ToString().Trim();
                txtApellidoMaterno.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtApellidoMaterno"].Value.ToString().Trim();
                txtCelular.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCelular"].Value.ToString().Trim();

            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            {
                string numDoc = dgvListado.Rows[e.RowIndex].Cells["ctxtNumDoc"].Value.ToString();
                DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                if (pregunta.Equals(DialogResult.OK))
                {
                    _personaParam = new SetPersonaParam();
                    _personaParam.opcion = 3; // ELIMINAR 
                    _personaParam.numDoc = numDoc;
                    _personaParam.usuarioReg = UserApplication.USUARIO;

                    Procesar(_personaParam);
                }
            }
        }



        // ### Funciones ###

        public void ListarTipoDocumentoCBX()
        {
            List<GetMant13_TipoDoc> cbxTipoDocList = _mantenimientoBL.GetMant13_TipoDoc();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxTipoDocList;

            cbxTipoDocumento.DisplayMember = "tipoDocCorta";
            cbxTipoDocumento.ValueMember = "codTipoDoc";
            cbxTipoDocumento.DataSource = bindingSource.DataSource;
        }


        public void Guardar()
        {
            if (ValidarDatos())
            {
                _personaParam = new SetPersonaParam();

                if (!string.IsNullOrEmpty(lblNumDoc.Text))
                {
                    _personaParam.opcion = 2; // ACTUALIZAR 
                    _personaParam.numDoc = lblNumDoc.Text.Trim();
                    _personaParam.numDocUpdate = txtNumDoc.Text.Trim();
                    _personaParam.codTipoDoc = cbxTipoDocumento.SelectedValue.ToString();
                    _personaParam.nombres = txtNombres.Text.Trim();
                    _personaParam.apellidoPaterno = txtApellidoPaterno.Text.Trim();
                    _personaParam.apellidoMaterno = txtApellidoMaterno.Text.Trim();
                    _personaParam.celular = txtCelular.Text.Trim();
                    _personaParam.usuarioReg = UserApplication.USUARIO;  // UserApplication.USUARIO;
                }
                else
                {
                    _personaParam.opcion = 1; // REGISTRAR
                    _personaParam.numDoc = txtNumDoc.Text.Trim();
                    _personaParam.numDocUpdate = "";
                    _personaParam.codTipoDoc = cbxTipoDocumento.SelectedValue.ToString();
                    _personaParam.nombres = txtNombres.Text.Trim();
                    _personaParam.apellidoPaterno = txtApellidoPaterno.Text.Trim();
                    _personaParam.apellidoMaterno = txtApellidoMaterno.Text.Trim();
                    _personaParam.celular = txtCelular.Text.Trim();
                    _personaParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_personaParam);
            }
        }

        public void Procesar(SetPersonaParam parametro)
        {
            Response responseGeneral = _empleadoBL.SetEmpPersona(parametro);

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
            List<GetEmp1_Personas> listaPersona = _empleadoBL.Get1_Personas();

            dgvListado.Rows.Clear();

            foreach (var item in listaPersona)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtNumDoc"].Value = item.numDoc;
                dgvListado.Rows[index].Cells["ctxtCodTipoDoc"].Value = item.codTipoDoc;
                dgvListado.Rows[index].Cells["ctxtTipoDocCorta"].Value = item.tipoDocCorta;
                dgvListado.Rows[index].Cells["ctxtNombres"].Value = item.nombres;
                dgvListado.Rows[index].Cells["ctxtApellidoPaterno"].Value = item.apellidoPaterno;
                dgvListado.Rows[index].Cells["ctxtApellidoMaterno"].Value = item.apellidoMaterno;
                dgvListado.Rows[index].Cells["ctxtCelular"].Value = item.celular;

                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;

            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }


        private bool ValidarDatos()
        {
            bool validacion = false;

            if (cbxTipoDocumento.SelectedValue.ToString() == "00")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione un tipo de Documento", "INFORMATION");
                cbxTipoDocumento.Focus();
            }
            else if (string.IsNullOrEmpty(txtNumDoc.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el número de Documento", "INFORMATION");
                txtNumDoc.Focus();
            }
            else if (string.IsNullOrEmpty(txtNombres.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el nombre de la persona", "INFORMATION");
                txtNombres.Focus();
            }
            else if (string.IsNullOrEmpty(txtApellidoPaterno.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el apellido Paterno", "INFORMATION");
                txtNombres.Focus();
            }
            else if (string.IsNullOrEmpty(txtApellidoMaterno.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el apellido Materno", "INFORMATION");
                txtNombres.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtNumDoc.Text = "";
            txtNombres.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtCelular.Text = "";
        }

        public void ValoresPredeterminado()
        {
            cbxTipoDocumento.SelectedValue = "00";
        }


    }
}
