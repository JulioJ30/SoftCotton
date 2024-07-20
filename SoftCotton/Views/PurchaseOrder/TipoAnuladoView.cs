using SoftCotton.BusinessLogic;
using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.PurchaseOrder
{
    public partial class TipoAnuladoView : Form
    {
        OrdenCompraBL _ordenCompraBL;
        SetOCTipoAnuladoParam _tipoAnuladoParam;

        public TipoAnuladoView()
        {
            InitializeComponent();

            _ordenCompraBL = new OrdenCompraBL();
        }

        private void TipoAnuladoView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtIdTipoAnulado.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtIdTipoAnulado.Focus();
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
                    lblIdTipoAnulado.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdTipoAnulado"].Value.ToString();
                    txtIdTipoAnulado.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdTipoAnulado"].Value.ToString();
                    txtDescripcion.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtDescripcion"].Value.ToString();
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
                    int idTipoAnulado = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntIdTipoAnulado"].Value.ToString());
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _tipoAnuladoParam = new SetOCTipoAnuladoParam();
                        _tipoAnuladoParam.opcion = 4; // ELIMINAR 
                        _tipoAnuladoParam.idTipoAnulado = Convert.ToInt32(idTipoAnulado);
                        _tipoAnuladoParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_tipoAnuladoParam);
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

                    _tipoAnuladoParam = new SetOCTipoAnuladoParam();

                    _tipoAnuladoParam.opcion = 3; // INHABILITAR
                    _tipoAnuladoParam.idTipoAnulado = Convert.ToInt32(row.Cells["cIntIdTipoAnulado"].Value.ToString());
                    _tipoAnuladoParam.usuarioReg = UserApplication.USUARIO;
                    _tipoAnuladoParam.estado = valorCheck;

                    Procesar(_tipoAnuladoParam);
                }
            }
        }



        // ### Funciones ###
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _tipoAnuladoParam = new SetOCTipoAnuladoParam();

                if (!string.IsNullOrEmpty(lblIdTipoAnulado.Text) && lblIdTipoAnulado.Text.Trim() != "0")
                {
                    _tipoAnuladoParam.opcion = 2; // ACTUALIZAR
                    _tipoAnuladoParam.idTipoAnulado = Convert.ToInt32(lblIdTipoAnulado.Text);
                    _tipoAnuladoParam.idTipoAnuladoUpdate = Convert.ToInt32(txtIdTipoAnulado.Text);
                    _tipoAnuladoParam.descripcion = txtDescripcion.Text;
                    _tipoAnuladoParam.estado = true;
                    _tipoAnuladoParam.usuarioReg = UserApplication.USUARIO;
                }
                else
                {
                    _tipoAnuladoParam.opcion = 1; // REGISTRAR
                    _tipoAnuladoParam.idTipoAnulado = Convert.ToInt32(txtIdTipoAnulado.Text);
                    _tipoAnuladoParam.descripcion = txtDescripcion.Text;
                    _tipoAnuladoParam.estado = true;
                    _tipoAnuladoParam.usuarioReg = UserApplication.USUARIO;

                }

                Procesar(_tipoAnuladoParam);
            }
        }

        public void Procesar(SetOCTipoAnuladoParam parametro)
        {
            Response responseGeneral = _ordenCompraBL.SetOCTipoAnulado(parametro);

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
            List<GetOC6_TipoAnulado> listaCeCos = _ordenCompraBL.Get6_TipoAnulados();

            dgvListado.Rows.Clear();

            foreach (var item in listaCeCos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntIdTipoAnulado"].Value = item.idTipoAnulado;
                dgvListado.Rows[index].Cells["ctxtDescripcion"].Value = item.descripcion;

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

            if (string.IsNullOrEmpty(txtIdTipoAnulado.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Aprobación", "INFORMATION");
                txtIdTipoAnulado.Focus();
            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción de aprobación", "INFORMATION");
                txtDescripcion.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtIdTipoAnulado.Text = "";
            txtDescripcion.Text = "";
            lblIdTipoAnulado.Text = "";
        }

    
    }
}
