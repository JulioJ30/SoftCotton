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
    public partial class RegistroTallaView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetTallaParam _TallaParam;
        
        public RegistroTallaView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }
    


        private void RegistroTallaView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodTalla.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodTalla.Focus();
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
                    lblCodTalla.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTalla"].Value.ToString().Trim();
                    txtCodTalla.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTalla"].Value.ToString().Trim();
                    txtTalla.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtTalla"].Value.ToString().Trim();

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
                    string codTalla = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTalla"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _TallaParam = new SetTallaParam();
                        _TallaParam.opcion = 4; // ELIMINAR 
                        _TallaParam.codTalla = codTalla;
                        _TallaParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_TallaParam);
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

                    _TallaParam = new SetTallaParam();

                    _TallaParam.opcion = 3; // INHABILITAR
                    _TallaParam.codTalla = row.Cells["ctxtCodTalla"].Value.ToString();
                    _TallaParam.usuarioReg = UserApplication.USUARIO;
                    _TallaParam.estado = valorCheck;

                    Procesar(_TallaParam);
                }
            }
        }



        // ### Funciones ###

        public void Guardar()
        {
            if (ValidarDatos())
            {
                _TallaParam = new SetTallaParam();

                if (!string.IsNullOrEmpty(lblCodTalla.Text))
                {
                    _TallaParam.opcion = 2; // ACTUALIZAR
                    _TallaParam.codTalla = lblCodTalla.Text;
                    _TallaParam.codTallaUpdate = txtCodTalla.Text;
                    _TallaParam.descripcion = txtTalla.Text.Trim();
                    _TallaParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _TallaParam.opcion = 1; // REGISTRAR
                    _TallaParam.codTalla = txtCodTalla.Text.Trim();
                    _TallaParam.codTallaUpdate = "";
                    _TallaParam.descripcion = txtTalla.Text.Trim();
                    _TallaParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_TallaParam);
            }
        }

        public void Procesar(SetTallaParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetTalla(parametro);

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
            List<GetMant21_Tallas> listaTallas = _mantenimientoBL.Get21_Tallas();

            dgvListado.Rows.Clear();

            foreach (var item in listaTallas)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtCodTalla"].Value = item.codTalla;
                dgvListado.Rows[index].Cells["ctxtTalla"].Value = item.descripcion;
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

            if (string.IsNullOrEmpty(txtCodTalla.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Talla", "INFORMATION");
                txtCodTalla.Focus();
            }
            else if (string.IsNullOrEmpty(txtTalla.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción del tipo de Talla", "INFORMATION");
                txtTalla.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            lblCodTalla.Text = "";
            txtCodTalla.Text = "";
            txtTalla.Text = "";
        }

       
    }
}
