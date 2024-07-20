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
    public partial class RegistroColorView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetColorParam _ColorParam;


        public RegistroColorView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void RegistroColorView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodColor.Focus();
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodColor.Focus();
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
                    lblCodColor.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodColor"].Value.ToString().Trim();
                    txtCodColor.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodColor"].Value.ToString().Trim();
                    txtColor.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtColor"].Value.ToString().Trim();

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
                    string codColor = dgvListado.Rows[e.RowIndex].Cells["ctxtCodColor"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _ColorParam = new SetColorParam();
                        _ColorParam.opcion = 4; // ELIMINAR 
                        _ColorParam.codColor = codColor;
                        _ColorParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_ColorParam);
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

                    _ColorParam = new SetColorParam();

                    _ColorParam.opcion = 3; // INHABILITAR
                    _ColorParam.codColor = row.Cells["ctxtCodColor"].Value.ToString();
                    _ColorParam.usuarioReg = UserApplication.USUARIO;
                    _ColorParam.estado = valorCheck;

                    Procesar(_ColorParam);
                }
            }
        }



        // ### Funciones ###

        public void Guardar()
        {
            if (ValidarDatos())
            {
                _ColorParam = new SetColorParam();

                if (!string.IsNullOrEmpty(lblCodColor.Text))
                {
                    _ColorParam.opcion = 2; // ACTUALIZAR
                    _ColorParam.codColor = lblCodColor.Text;
                    _ColorParam.codColorUpdate = txtCodColor.Text;
                    _ColorParam.descripcion = txtColor.Text.Trim();
                    _ColorParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _ColorParam.opcion = 1; // REGISTRAR
                    _ColorParam.codColor = txtCodColor.Text.Trim();
                    _ColorParam.codColorUpdate = "";
                    _ColorParam.descripcion = txtColor.Text.Trim();
                    _ColorParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_ColorParam);
            }
        }

        public void Procesar(SetColorParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetColor(parametro);

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
            List<GetMant22_Color> listaColors = _mantenimientoBL.Get22_Color();

            dgvListado.Rows.Clear();

            foreach (var item in listaColors)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtCodColor"].Value = item.codColor;
                dgvListado.Rows[index].Cells["ctxtColor"].Value = item.descripcion;
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

            if (string.IsNullOrEmpty(txtCodColor.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Color", "INFORMATION");
                txtCodColor.Focus();
            }
            else if (string.IsNullOrEmpty(txtColor.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción del tipo de Color", "INFORMATION");
                txtColor.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            lblCodColor.Text = "";
            txtCodColor.Text = "";
            txtColor.Text = "";
        }

     
    }
}
