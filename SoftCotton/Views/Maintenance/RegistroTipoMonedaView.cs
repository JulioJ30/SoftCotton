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
    public partial class RegistroTipoMonedaView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetTipoMonedaParam _tipoMonedaParam;

        public RegistroTipoMonedaView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            _tipoMonedaParam = new SetTipoMonedaParam();
        }

        private void RegistroTipoMonedaView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtIDTipoMoneda.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtIDTipoMoneda.Focus();

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
                    lblIDTipoMoneda.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIDTipoMoneda"].Value.ToString().Trim();
                    txtIDTipoMoneda.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIDTipoMoneda"].Value.ToString().Trim();
                    txtSimbolo.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtSimbolo"].Value.ToString().Trim();
                    txtMonedaSingular.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtMonedaSingular"].Value.ToString().Trim();
                    txtMonedaPlural.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtMonedaPlural"].Value.ToString().Trim();
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
                    string idTipoMoneda = dgvListado.Rows[e.RowIndex].Cells["cIntIDTipoMoneda"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _tipoMonedaParam = new SetTipoMonedaParam();
                        _tipoMonedaParam.opcion = 4; // ELIMINAR 
                        _tipoMonedaParam.idTipoMoneda = Convert.ToInt32(idTipoMoneda);
                        _tipoMonedaParam.usuarioReg = "JMORAN";

                        Procesar(_tipoMonedaParam);
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

                    _tipoMonedaParam = new SetTipoMonedaParam();

                    _tipoMonedaParam.opcion = 3; // INHABILITAR
                    _tipoMonedaParam.idTipoMoneda = Convert.ToInt32(row.Cells["cIntIDTipoMoneda"].Value);
                    _tipoMonedaParam.usuarioReg = UserApplication.USUARIO;
                    _tipoMonedaParam.estado = valorCheck;

                    Procesar(_tipoMonedaParam);
                }
            }
        }

        private void txtIDTipoMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        // ### Funciones ###
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _tipoMonedaParam = new SetTipoMonedaParam();

                if (Convert.ToInt32(lblIDTipoMoneda.Text) > 0)
                {
                    _tipoMonedaParam.opcion = 2; // ACTUALIZAR
                    _tipoMonedaParam.idTipoMoneda = Convert.ToInt32(lblIDTipoMoneda.Text);
                    _tipoMonedaParam.simbolo = txtSimbolo.Text;
                    _tipoMonedaParam.monedaSingular = txtMonedaSingular.Text.Trim();
                    _tipoMonedaParam.monedaPlural = txtMonedaPlural.Text.Trim();
                    _tipoMonedaParam.usuarioReg = UserApplication.USUARIO;
                }
                else
                {
                    _tipoMonedaParam.opcion = 1; // REGISTRAR
                    _tipoMonedaParam.idTipoMoneda = Convert.ToInt32(txtIDTipoMoneda.Text);
                    _tipoMonedaParam.simbolo = txtSimbolo.Text;
                    _tipoMonedaParam.monedaSingular = txtMonedaSingular.Text.Trim();
                    _tipoMonedaParam.monedaPlural = txtMonedaPlural.Text.Trim();
                    _tipoMonedaParam.usuarioReg = UserApplication.USUARIO;
                }

                Procesar(_tipoMonedaParam);
            }
        }

        public void Procesar(SetTipoMonedaParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetTipoMoneda(parametro);

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
            List<GetMant10_TipoMoneda> listaTipoDoc = _mantenimientoBL.GetMant10_TipoMoneda();

            dgvListado.Rows.Clear();

            foreach (var item in listaTipoDoc)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntIDTipoMoneda"].Value = item.idTipoMoneda;
                dgvListado.Rows[index].Cells["ctxtSimbolo"].Value = item.simbolo;
                dgvListado.Rows[index].Cells["ctxtMonedaSingular"].Value = item.monedaSingular;
                dgvListado.Rows[index].Cells["ctxtMonedaPlural"].Value = item.monedaPlural;
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

            if (string.IsNullOrEmpty(txtIDTipoMoneda.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el ID de Tipo de Moneda", "INFORMATION");
                txtIDTipoMoneda.Focus();
            }
            else if (string.IsNullOrEmpty(txtSimbolo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción del tipo de documento", "INFORMATION");
                txtSimbolo.Focus();
            }
            else if (string.IsNullOrEmpty(txtMonedaSingular.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción de Moneda en Singular", "INFORMATION");
                txtMonedaSingular.Focus();
            }
            else if (string.IsNullOrEmpty(txtMonedaPlural.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción del Moneda en Plural", "INFORMATION");
                txtMonedaPlural.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            lblIDTipoMoneda.Text = "0";
            txtIDTipoMoneda.Text = "";
            txtSimbolo.Text = "";
            txtMonedaSingular.Text = "";
            txtMonedaPlural.Text = "";
        }

        
    }
}
