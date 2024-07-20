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
    public partial class TipoAprobacionView : Form
    {
        OrdenCompraBL _ordenCompraBL;
        SetOCTipoAprobParam _tipoAprobParam;

        public TipoAprobacionView()
        {
            InitializeComponent();

            _ordenCompraBL = new OrdenCompraBL();
        }

        private void TipoAprobacionView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtIdTipoAprob.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtIdTipoAprob.Focus();
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
                    lblIdTipoAprob.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdTipoAprob"].Value.ToString();
                    txtIdTipoAprob.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdTipoAprob"].Value.ToString();
                    txtDescripcion.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtDescripcion"].Value.ToString();
                    txtNivelAprobacion.Text = dgvListado.Rows[e.RowIndex].Cells["cIntOrdenAprob"].Value.ToString();
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
                    int idTipoAprobacion = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntIdTipoAprob"].Value.ToString());
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _tipoAprobParam = new SetOCTipoAprobParam();
                        _tipoAprobParam.opcion = 4; // ELIMINAR 
                        _tipoAprobParam.idTipoAprobacion = Convert.ToInt32(idTipoAprobacion);
                        _tipoAprobParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_tipoAprobParam);
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

                    _tipoAprobParam = new SetOCTipoAprobParam();

                    _tipoAprobParam.opcion = 3; // INHABILITAR
                    _tipoAprobParam.idTipoAprobacion = Convert.ToInt32(row.Cells["cIntIdTipoAprob"].Value.ToString());
                    _tipoAprobParam.usuarioReg = UserApplication.USUARIO;
                    _tipoAprobParam.estado = valorCheck;

                    Procesar(_tipoAprobParam);
                }
            }
        }




        // ### Funciones.
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _tipoAprobParam = new SetOCTipoAprobParam();

                if (!string.IsNullOrEmpty(lblIdTipoAprob.Text) && lblIdTipoAprob.Text.Trim() != "0")
                {
                    _tipoAprobParam.opcion = 2; // ACTUALIZAR
                    _tipoAprobParam.idTipoAprobacion = Convert.ToInt32(lblIdTipoAprob.Text);
                    _tipoAprobParam.idTipoAprobacionUpdate = Convert.ToInt32(txtIdTipoAprob.Text);
                    _tipoAprobParam.descripcion = txtDescripcion.Text;
                    _tipoAprobParam.estado = true;
                    _tipoAprobParam.nivelAprobacion = Convert.ToInt32(txtNivelAprobacion.Text);
                    _tipoAprobParam.usuarioReg = UserApplication.USUARIO;
                }
                else
                {
                    _tipoAprobParam.opcion = 1; // REGISTRAR
                    _tipoAprobParam.idTipoAprobacion = Convert.ToInt32(txtIdTipoAprob.Text);
                    _tipoAprobParam.descripcion = txtDescripcion.Text;
                    _tipoAprobParam.estado = true;
                    _tipoAprobParam.nivelAprobacion = Convert.ToInt32(txtNivelAprobacion.Text);
                    _tipoAprobParam.usuarioReg = UserApplication.USUARIO;

                }

                Procesar(_tipoAprobParam);
            }
        }

        public void Procesar(SetOCTipoAprobParam parametro)
        {
            Response responseGeneral = _ordenCompraBL.SetOCTipoAprobacion(parametro);

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
            List<GetOC5_TipoAprobacion> listaCeCos = _ordenCompraBL.Get5_TipoAprobaciones();

            dgvListado.Rows.Clear();

            foreach (var item in listaCeCos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntIdTipoAprob"].Value = item.idTipoAprobacion;
                dgvListado.Rows[index].Cells["ctxtDescripcion"].Value = item.descripcion;
                dgvListado.Rows[index].Cells["cIntOrdenAprob"].Value = item.nivelAprobacion;

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

            if (string.IsNullOrEmpty(txtIdTipoAprob.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Aprobación", "INFORMATION");
                txtIdTipoAprob.Focus();
            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción de aprobación", "INFORMATION");
                txtDescripcion.Focus();
            }
            else if (string.IsNullOrEmpty(txtNivelAprobacion.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el número de Nivel de Aprobación", "INFORMATION");
                txtNivelAprobacion.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtIdTipoAprob.Text = "";
            txtDescripcion.Text = "";
            txtNivelAprobacion.Text = "";
            lblIdTipoAprob.Text = "";
        }

       
    }
}
