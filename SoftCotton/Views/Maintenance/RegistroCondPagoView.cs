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
    public partial class RegistroCondPagoView : Form
    {

        MantenimientoBL _mantenimientoBL;
        SetCondPagoParam _condPagoParam;

        public RegistroCondPagoView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            _condPagoParam = new SetCondPagoParam();
        }


     
        private void RegistroCondPagoView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCondicion.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCondicion.Focus();
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
                    lblIdCondPago.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdCondPago"].Value.ToString().Trim();
                    txtCondicion.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCondicion"].Value.ToString().Trim();
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
                    string idCondPago = dgvListado.Rows[e.RowIndex].Cells["cIntIdCondPago"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _condPagoParam = new SetCondPagoParam();
                        _condPagoParam.opcion = 4; // ELIMINAR 
                        _condPagoParam.idCondPago = Convert.ToInt32(idCondPago);
                        _condPagoParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_condPagoParam);
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

                    _condPagoParam = new SetCondPagoParam();

                    _condPagoParam.opcion = 3; // INHABILITAR
                    _condPagoParam.idCondPago = Convert.ToInt32(row.Cells["cIntIdCondPago"].Value);
                    _condPagoParam.usuarioReg = UserApplication.USUARIO;
                    _condPagoParam.estado = valorCheck;

                    Procesar(_condPagoParam);
                }
            }
        }


        // ### Funciones ###
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _condPagoParam = new SetCondPagoParam();

                if (Convert.ToInt32(lblIdCondPago.Text) > 0)
                {
                    _condPagoParam.opcion = 2; // ACTUALIZAR
                    _condPagoParam.idCondPago = Convert.ToInt32(lblIdCondPago.Text);
                    _condPagoParam.condicion = txtCondicion.Text;
                    _condPagoParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _condPagoParam.opcion = 1; // REGISTRAR
                    _condPagoParam.idCondPago = 0;
                    _condPagoParam.condicion = txtCondicion.Text;
                    _condPagoParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_condPagoParam);
            }
        }

        public void Procesar(SetCondPagoParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetCondicionesPago(parametro);

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
            List<GetMant9_CondPago> listaCondPagos = _mantenimientoBL.GetMant9_CondPago ();

            dgvListado.Rows.Clear();

            foreach (var item in listaCondPagos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntIdCondPago"].Value = item.idCondPago;
                dgvListado.Rows[index].Cells["ctxtCondicion"].Value = item.condicion;
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
            if (string.IsNullOrEmpty(txtCondicion.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción de Condición de Pago", "INFORMATION");
                txtCondicion.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            lblIdCondPago.Text = "0";
            txtCondicion.Text = "";
        }

      
    }
}
