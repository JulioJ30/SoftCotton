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
    public partial class RegistroUnidadMedidaView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetUMParam _umParam;


        public RegistroUnidadMedidaView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void RegistroUnidadMedidaView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            
            txtCodUM.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();

            txtCodUM.Focus();
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
                    lblCodUM.Text = dgvListado.Rows[e.RowIndex].Cells["dgvtxtCodUM"].Value.ToString();
                    txtCodUM.Text = dgvListado.Rows[e.RowIndex].Cells["dgvtxtCodUM"].Value.ToString();
                    txtUM.Text = dgvListado.Rows[e.RowIndex].Cells["dgvtxtUM"].Value.ToString();

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
                    string codCuenta = dgvListado.Rows[e.RowIndex].Cells["dgvtxtCodUM"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _umParam = new SetUMParam();
                        _umParam.opcion = 4; // ELIMINAR 
                        _umParam.codUM = codCuenta;
                        _umParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_umParam);
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

                    _umParam = new SetUMParam();

                    _umParam.opcion = 3; // INHABILITAR
                    _umParam.codUM = row.Cells["dgvtxtCodUM"].Value.ToString();
                    _umParam.usuarioReg = UserApplication.USUARIO;
                    _umParam.estado = valorCheck;

                    Procesar(_umParam);
                }
            }
        }


        // ### Funciones ###
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _umParam = new SetUMParam();

                if (!string.IsNullOrEmpty(lblCodUM.Text))
                {
                    _umParam.opcion = 2; // ACTUALIZAR
                    _umParam.codUMUpdate = lblCodUM.Text;
                    _umParam.codUM = txtCodUM.Text;
                    _umParam.descripcion = txtUM.Text.Trim();
                    _umParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                    _umParam.estado = true;
                }
                else
                {
                    _umParam.opcion = 1; // REGISTRAR
                    _umParam.codUMUpdate = "";
                    _umParam.codUM = txtCodUM.Text;
                    _umParam.descripcion = txtUM.Text.Trim();
                    _umParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                    _umParam.estado = true;
                }

                Procesar(_umParam);
            }
        }

        public void Procesar(SetUMParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetUnidadMedida(parametro);

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
            List<GetMant30_UM> listaUM = _mantenimientoBL.Get30_UM();

            dgvListado.Rows.Clear();

            foreach (var item in listaUM)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["dgvtxtCodUM"].Value = item.codUM;
                dgvListado.Rows[index].Cells["dgvtxtUM"].Value = item.descripcion;

                dgvListado.Rows[index].Cells["dgvTxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["dgvTxtUsuarioReg"].Value = item.usuarioReg;

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

            if (string.IsNullOrEmpty(txtCodUM.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Centro de Costo", "INFORMATION");
                txtCodUM.Focus();
            }
            else if (string.IsNullOrEmpty(txtUM.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el Centro de Costo", "INFORMATION");
                txtUM.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCodUM.Text = "";
            lblCodUM.Text = "";
            txtUM.Text = "";
        }
        
    }
}
