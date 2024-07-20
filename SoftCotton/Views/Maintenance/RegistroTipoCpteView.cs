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
    public partial class RegistroTipoCpteView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetTipoComprobanteParam _tipoDocParam;

        public RegistroTipoCpteView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void RegistroTipoDocView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodTipoCpte.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodTipoCpte.Focus();
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
                    lblCodTipoCpte.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoCpte"].Value.ToString().Trim();
                    txtCodTipoCpte.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoCpte"].Value.ToString().Trim();
                    txtTipoCpte.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtTipoCpte"].Value.ToString().Trim();
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
                    string codTipoDoc = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoCpte"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _tipoDocParam = new SetTipoComprobanteParam();
                        _tipoDocParam.opcion = 4; // ELIMINAR 
                        _tipoDocParam.codTipoCpte = codTipoDoc;
                        _tipoDocParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_tipoDocParam);
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

                    _tipoDocParam = new SetTipoComprobanteParam();

                    _tipoDocParam.opcion = 3; // INHABILITAR
                    _tipoDocParam.codTipoCpte = row.Cells["ctxtCodTipoCpte"].Value.ToString();
                    _tipoDocParam.usuarioReg = UserApplication.USUARIO;
                    _tipoDocParam.estado = valorCheck;

                    Procesar(_tipoDocParam);
                }
            }
        }




        // ### Funciones ###

        public void Guardar()
        {
            if (ValidarDatos())
            {
                _tipoDocParam = new SetTipoComprobanteParam();

                if (!string.IsNullOrEmpty(lblCodTipoCpte.Text))
                {
                    _tipoDocParam.opcion = 2; // ACTUALIZAR
                    _tipoDocParam.codTipoCpte = lblCodTipoCpte.Text;
                    _tipoDocParam.codTipoCpteUpdate = txtCodTipoCpte.Text;
                    _tipoDocParam.tipoComprobante = txtTipoCpte.Text.Trim();
                    _tipoDocParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _tipoDocParam.opcion = 1; // REGISTRAR
                    _tipoDocParam.codTipoCpte = txtCodTipoCpte.Text.Trim();
                    _tipoDocParam.codTipoCpteUpdate = "";
                    _tipoDocParam.tipoComprobante = txtTipoCpte.Text.Trim();
                    _tipoDocParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_tipoDocParam);
            }
        }

        public void Procesar(SetTipoComprobanteParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetTipoComprobante(parametro);

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
            List<GetMant8_TipoCpte> listaTipoDoc = _mantenimientoBL.GetMant8_TipoDoc();

            dgvListado.Rows.Clear();

            foreach (var item in listaTipoDoc)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtCodTipoCpte"].Value = item.codTipoCpte;
                dgvListado.Rows[index].Cells["ctxtTipoCpte"].Value = item.tipoComprobante;
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

            if (string.IsNullOrEmpty(txtCodTipoCpte.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de tipo de comprobante", "INFORMATION");
                txtCodTipoCpte.Focus();
            }
            else if (string.IsNullOrEmpty(txtTipoCpte.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción del tipo de comprobante", "INFORMATION");
                txtTipoCpte.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCodTipoCpte.Text = "";
            txtTipoCpte.Text = "";
            lblCodTipoCpte.Text = "";
        }

       
    }
}
