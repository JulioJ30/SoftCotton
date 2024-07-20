using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SoftCotton.Views.Maintenance
{
    public partial class RegistroCeCoView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetCeCoParam _cecoParam;

        public RegistroCeCoView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void RegistroCeCoView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodCeCo.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodCeCo.Focus();
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
                    lblCodCeCo.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodCeCo"].Value.ToString();
                    txtCodCeCo.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodCeCo"].Value.ToString();
                    txtCeCo.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCeCo"].Value.ToString();
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
                    string codCeCo = dgvListado.Rows[e.RowIndex].Cells["ctxtCodCeCo"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _cecoParam = new SetCeCoParam();
                        _cecoParam.opcion = 4; // ELIMINAR 
                        _cecoParam.codceco = codCeCo;
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

                    _cecoParam = new SetCeCoParam();

                    _cecoParam.opcion = 3; // INHABILITAR
                    _cecoParam.codceco = row.Cells["ctxtCodCeCo"].Value.ToString();
                    _cecoParam.usuarioReg = UserApplication.USUARIO;
                    _cecoParam.estado = valorCheck;

                    Procesar(_cecoParam);
                }
            }
        }





        // ### Funciones ###
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _cecoParam = new SetCeCoParam();

                if (!string.IsNullOrEmpty(lblCodCeCo.Text))
                {
                    _cecoParam.opcion = 2; // ACTUALIZAR
                    _cecoParam.codceco = lblCodCeCo.Text;
                    _cecoParam.codcecoUpdate = txtCodCeCo.Text;
                    _cecoParam.ceco = txtCeCo.Text.Trim();
                    _cecoParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _cecoParam.opcion = 1; // REGISTRAR
                    _cecoParam.codceco = txtCodCeCo.Text.Trim();
                    _cecoParam.codcecoUpdate = "";
                    _cecoParam.ceco = txtCeCo.Text.Trim();
                    _cecoParam.usuarioReg = UserApplication.USUARIO;// UserApplication.USUARIO;
                }

                Procesar(_cecoParam);
            }
        }

        public void Procesar(SetCeCoParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetCentroCosto(parametro);

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
            List<GetMant7_CeCos> listaCeCos = _mantenimientoBL.GetMant7_CeCos();

            dgvListado.Rows.Clear();

            foreach (var item in listaCeCos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtCodCeCo"].Value = item.codceco;
                dgvListado.Rows[index].Cells["ctxtCeCo"].Value = item.ceco;
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

            if (string.IsNullOrEmpty(txtCodCeCo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Centro de Costo", "INFORMATION");
                txtCodCeCo.Focus();
            }
            else if (string.IsNullOrEmpty(txtCeCo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el Centro de Costo", "INFORMATION");
                txtCeCo.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCodCeCo.Text = "";
            txtCeCo.Text = "";
            lblCodCeCo.Text = "";
        }

    }
}
