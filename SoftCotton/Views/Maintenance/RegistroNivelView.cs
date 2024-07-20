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
    public partial class RegistroNivelView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetNivelParam _familiaParam;

        public RegistroNivelView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();

            //UserApplication.USUARIO = "jmlacs";
        }

        private void RegistroFamiliaView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodNivel.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodNivel.Focus();
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
                    lblCodNivel.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtcodNivel"].Value.ToString().Trim();
                    txtCodNivel.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtcodNivel"].Value.ToString().Trim();
                    txtNivel.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtNivel"].Value.ToString().Trim();
                    txtAbreviatura.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtAbreviatura"].Value.ToString().Trim();
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
                    string codNivel = dgvListado.Rows[e.RowIndex].Cells["ctxtcodNivel"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _familiaParam = new SetNivelParam();
                        _familiaParam.opcion = 4; // ELIMINAR 
                        _familiaParam.codNivel = codNivel;
                        _familiaParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_familiaParam);
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

                    _familiaParam = new SetNivelParam();

                    _familiaParam.opcion = 3; // INHABILITAR
                    _familiaParam.codNivel = row.Cells["ctxtcodNivel"].Value.ToString();
                    _familiaParam.usuarioReg = UserApplication.USUARIO;
                    _familiaParam.estado = valorCheck;

                    Procesar(_familiaParam);
                }
            }
        }


        // ### Funciones ###

        public void Guardar()
        {
            if (ValidarDatos())
            {
                _familiaParam = new SetNivelParam();

                if (!string.IsNullOrEmpty(lblCodNivel.Text))
                {
                    _familiaParam.opcion = 2; // ACTUALIZAR
                    _familiaParam.codNivel = lblCodNivel.Text;
                    _familiaParam.codNivelUpdate = txtCodNivel.Text;
                    _familiaParam.nivel = txtNivel.Text.Trim();
                    _familiaParam.abreviatura = txtAbreviatura.Text.Trim();
                    _familiaParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _familiaParam.opcion = 1; // REGISTRAR
                    _familiaParam.codNivel = txtCodNivel.Text.Trim();
                    _familiaParam.codNivelUpdate = "";
                    _familiaParam.nivel = txtNivel.Text.Trim();
                    _familiaParam.abreviatura = txtAbreviatura.Text.Trim();
                    _familiaParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_familiaParam);
            }
        }

        public void Procesar(SetNivelParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetNivel(parametro);

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
            List<GetMant15_Nivel> listaFamilias = _mantenimientoBL.GetMant15_Nivel();

            dgvListado.Rows.Clear();

            foreach (var item in listaFamilias)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtcodNivel"].Value = item.codNivel;
                dgvListado.Rows[index].Cells["ctxtNivel"].Value = item.nivel;
                dgvListado.Rows[index].Cells["ctxtAbreviatura"].Value = item.abreviatura;
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

            if (string.IsNullOrEmpty(txtCodNivel.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Familia", "INFORMATION");
                txtCodNivel.Focus();
            }
            else if (string.IsNullOrEmpty(txtNivel.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción del tipo de Familia", "INFORMATION");
                txtNivel.Focus();
            }
            else if (string.IsNullOrEmpty(txtAbreviatura.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de abreviatura de familia", "INFORMATION");
                txtAbreviatura.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            lblCodNivel.Text = "";
            txtCodNivel.Text = "";
            txtNivel.Text = "";
            txtAbreviatura.Text = "";
        }

       
    }
}
