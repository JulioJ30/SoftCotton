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
    public partial class RegistroSubModuloView : Form
    {
        SeguridadBL _seguridadBL;
        SetSubModuloParam _submoduloParam;


        public RegistroSubModuloView()
        {
            InitializeComponent();
            _seguridadBL = new SeguridadBL();
        }

        private void RegistroSubModuloView_Load(object sender, EventArgs e)
        {
            ListarComboBox();
            Listar();
            Limpiar();

            cbxModulo.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            cbxModulo.Focus();

          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }


        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
                {
                    lblIdSubModulo.Text = dgvListado.Rows[e.RowIndex].Cells["cIntSubModulo"].Value.ToString();
                    cbxModulo.SelectedValue = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntIdModulo"].Value.ToString());
                    txtSubModulo.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtSubModulo"].Value.ToString();
                    txtFormulario.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtRutaForm"].Value.ToString();
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
                    int idSubModulo = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntSubModulo"].Value.ToString());
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _submoduloParam = new SetSubModuloParam();

                        _submoduloParam.opcion = 4; // ELIMINAR 
                        _submoduloParam.idSubModulo = idSubModulo;
                        _submoduloParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_submoduloParam);
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
                    
                    _submoduloParam = new SetSubModuloParam();

                    _submoduloParam.opcion = 3; // INHABILITAR
                    _submoduloParam.idSubModulo = Convert.ToInt32(row.Cells["cIntSubModulo"].Value);
                    _submoduloParam.usuarioReg = UserApplication.USUARIO;
                    _submoduloParam.estado = valorCheck;

                    Procesar(_submoduloParam);
                }
            }
        }





        // ###  FUNCIONES   ###
        public void Procesar(SetSubModuloParam parametro)
        {
            Response responseGeneral = _seguridadBL.SetSubModulo(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar();
                Listar();
                cbxModulo.Focus();
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }


        public void Guardar()
        {
            if (ValidarDatos())
            {
                _submoduloParam = new SetSubModuloParam();

                if (Convert.ToInt32(lblIdSubModulo.Text) > 0)
                {
                    _submoduloParam.opcion = 2; // ACTUALIZAR
                    _submoduloParam.idSubModulo = Convert.ToInt32(lblIdSubModulo.Text);
                    _submoduloParam.idModulo = Convert.ToInt32(cbxModulo.SelectedValue);
                    _submoduloParam.subModulo = txtSubModulo.Text.Trim();
                    _submoduloParam.rutaForm = txtFormulario.Text.Trim();
                    _submoduloParam.usuarioReg = UserApplication.USUARIO;
                }
                else
                {
                    _submoduloParam.opcion = 1; // REGISTRAR
                    _submoduloParam.idSubModulo = 0;
                    _submoduloParam.idModulo = Convert.ToInt32(cbxModulo.SelectedValue);
                    _submoduloParam.subModulo = txtSubModulo.Text.Trim();
                    _submoduloParam.rutaForm = txtFormulario.Text.Trim();
                    _submoduloParam.usuarioReg = UserApplication.USUARIO;
                }

                Procesar(_submoduloParam);
            }
        }


        public void ListarComboBox()
        {
            List<GetMant4_CbxModulos> cbxModulosList = _seguridadBL.GetMant4_CbxModulos();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxModulosList;

            cbxModulo.DisplayMember = "modulo";
            cbxModulo.ValueMember = "id";
            cbxModulo.DataSource = bindingSource.DataSource;
        }


        public void Listar()
        {
            List<GetMant3_SubModulos> listaModulos = _seguridadBL.GetMant3_SubModulos();

            dgvListado.Rows.Clear();

            foreach (var item in listaModulos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntSubModulo"].Value = item.id;
                dgvListado.Rows[index].Cells["cIntIdModulo"].Value = item.idModulo;
                dgvListado.Rows[index].Cells["ctxtModulo"].Value = item.modulo;
                dgvListado.Rows[index].Cells["ctxtSubModulo"].Value = item.submodulo;
                dgvListado.Rows[index].Cells["ctxtRutaForm"].Value = item.rutaForm;
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

            if (Convert.ToInt32(cbxModulo.SelectedValue.ToString()) == 0 || cbxModulo.SelectedValue == null)
            {
                validacion = false;
                ResponseMessage.Message("Seleccione el módulo", "INFORMATION");
                cbxModulo.Focus();
            }
            else if (string.IsNullOrEmpty(txtSubModulo.Text))
            {
                validacion = false;
                ResponseMessage.Message("Ingrese el nombre de módulo", "INFORMATION");
                txtSubModulo.Focus();
            }
            else if (string.IsNullOrEmpty(txtFormulario.Text))
            {
                validacion = false;
                ResponseMessage.Message("Ingrese el nombre de formulario", "INFORMATION");
                txtFormulario.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }


        public void Limpiar()
        {
            lblIdSubModulo.Text = "0";
            cbxModulo.SelectedValue = 0;
            txtSubModulo.Text = "";
            txtFormulario.Text = "";
        }

        
    }
}
