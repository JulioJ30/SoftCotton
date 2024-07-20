using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SoftCotton.Views.Maintenance
{
    public partial class RegistroTipoDocView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetTipoDocumentoParam _tipoDocParam;

        public RegistroTipoDocView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void RegistroTipoDocView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodTipoDoc.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodTipoDoc.Focus();
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
                    lblCodTipoDoc.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoDoc"].Value.ToString().Trim();
                    txtCodTipoDoc.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoDoc"].Value.ToString().Trim();
                    txtTipoDocLarga.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtTipoDocLarga"].Value.ToString().Trim();
                    txtTipoDocCorta.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtTipoDocCorta"].Value.ToString().Trim();
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
                    string codTipoDoc = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoDoc"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _tipoDocParam = new SetTipoDocumentoParam();
                        _tipoDocParam.opcion = 4; // ELIMINAR 
                        _tipoDocParam.codTipoDoc = codTipoDoc;
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

                    _tipoDocParam = new SetTipoDocumentoParam();

                    _tipoDocParam.opcion = 3; // INHABILITAR
                    _tipoDocParam.codTipoDoc = row.Cells["ctxtCodTipoDoc"].Value.ToString();
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
                _tipoDocParam = new SetTipoDocumentoParam();

                if (!string.IsNullOrEmpty(lblCodTipoDoc.Text))
                {
                    _tipoDocParam.opcion = 2; // ACTUALIZAR 
                    _tipoDocParam.codTipoDoc = lblCodTipoDoc.Text;
                    _tipoDocParam.codTipoDocUpdate = txtCodTipoDoc.Text;
                    _tipoDocParam.tipoDocLarga = txtTipoDocLarga.Text.Trim();
                    _tipoDocParam.tipoDocCorta = txtTipoDocCorta.Text.Trim();
                    _tipoDocParam.usuarioReg = UserApplication.USUARIO;
                }
                else
                {
                    _tipoDocParam.opcion = 1; // REGISTRAR
                    _tipoDocParam.codTipoDoc = txtCodTipoDoc.Text.Trim();
                    _tipoDocParam.codTipoDocUpdate = "";
                    _tipoDocParam.tipoDocLarga = txtTipoDocLarga.Text.Trim();
                    _tipoDocParam.tipoDocCorta = txtTipoDocCorta.Text.Trim();
                    _tipoDocParam.usuarioReg = UserApplication.USUARIO;
                }

                Procesar(_tipoDocParam);
            }
        }

        public void Procesar(SetTipoDocumentoParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetTipoDocumento(parametro);

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
            List<GetMant11_TipoDoc> listaTipoDoc = _mantenimientoBL.GetMant11_TipoDoc();

            dgvListado.Rows.Clear();

            foreach (var item in listaTipoDoc)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtCodTipoDoc"].Value = item.codTipoDoc;
                dgvListado.Rows[index].Cells["ctxtTipoDocLarga"].Value = item.tipoDocLarga;
                dgvListado.Rows[index].Cells["ctxtTipoDocCorta"].Value = item.tipoDocCorta;
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

            if (string.IsNullOrEmpty(txtCodTipoDoc.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de tipo de Documento", "INFORMATION");
                txtCodTipoDoc.Focus();
            }
            else if (string.IsNullOrEmpty(txtTipoDocLarga.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción larga del tipo de Documento", "INFORMATION");
                txtTipoDocLarga.Focus();
            }
            else if (string.IsNullOrEmpty(txtTipoDocCorta.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción corta del tipo de Documento", "INFORMATION");
                txtTipoDocCorta.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCodTipoDoc.Text = "";
            txtTipoDocLarga.Text = "";
            txtTipoDocCorta.Text = "";

            lblCodTipoDoc.Text = "";
        }

       
    }
}
