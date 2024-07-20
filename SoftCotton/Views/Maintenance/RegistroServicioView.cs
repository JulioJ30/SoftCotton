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
    public partial class RegistroServicioView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetServicioParam _ServicioParam;
        public string _codServicioUpdate;

        public RegistroServicioView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void RegistroServicioView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodServicio.Focus();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodServicio.Focus();
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
                    txtCodServicio.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodServicio"].Value.ToString().Trim();
                    txtServicio.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtServicio"].Value.ToString().Trim();
                    _codServicioUpdate = dgvListado.Rows[e.RowIndex].Cells["ctxtCodServicio"].Value.ToString().Trim();
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
                    string codServicio = dgvListado.Rows[e.RowIndex].Cells["ctxtCodServicio"].Value.ToString().Trim();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _ServicioParam = new SetServicioParam();
                        _ServicioParam.opcion = 4; // ELIMINAR 
                        _ServicioParam.codServicio = codServicio;
                        _ServicioParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_ServicioParam);
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
                    pregunta = "¿Desea activar el servicio?";
                }
                else
                {
                    pregunta = "¿Desea deshabilitar el servicio?";
                }

                DialogResult resultadoPregunta = ResponseMessage.MessageQuestion(pregunta);

                if (resultadoPregunta.Equals(DialogResult.OK))
                {
                    row.Cells["cbxActivo"].Value = valorCheck;

                    _ServicioParam = new SetServicioParam();

                    _ServicioParam.opcion = 3; // INHABILITAR
                    _ServicioParam.codServicio = row.Cells["ctxtCodServicio"].Value.ToString().Trim();
                    _ServicioParam.usuarioReg = UserApplication.USUARIO;
                    _ServicioParam.estado = valorCheck;

                    Procesar(_ServicioParam);
                }
            }

        }


        // ### Funciones ###
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _ServicioParam = new SetServicioParam();

                if (!string.IsNullOrEmpty(_codServicioUpdate))
                {
                    _ServicioParam.opcion = 2; // ACTUALIZAR
                    _ServicioParam.codServicio = txtCodServicio.Text;
                    _ServicioParam.codServicioUpdate = _codServicioUpdate;
                    _ServicioParam.nombreServicio = txtServicio.Text;
                    _ServicioParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _ServicioParam.opcion = 1; // REGISTRAR
                    _ServicioParam.codServicio = txtCodServicio.Text;
                    _ServicioParam.nombreServicio = txtServicio.Text;
                    _ServicioParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_ServicioParam);
            }
        }

        public void Procesar(SetServicioParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetServicio(parametro);

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
            List<GetMant33_Servicio> listaServicio = _mantenimientoBL.Get33_Servicio();

            dgvListado.Rows.Clear();

            foreach (var item in listaServicio)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtCodServicio"].Value = item.codServicio;
                dgvListado.Rows[index].Cells["ctxtServicio"].Value = item.nombreServicio;
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

            if (string.IsNullOrEmpty(txtCodServicio.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Servicio", "INFORMATION");
                txtCodServicio.Focus();
            }
            else if (string.IsNullOrEmpty(txtServicio.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el nombre del servicio", "INFORMATION");
                txtServicio.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCodServicio.Text = "";
            txtServicio.Text = "";
            _codServicioUpdate = "";
        }


    }
}
