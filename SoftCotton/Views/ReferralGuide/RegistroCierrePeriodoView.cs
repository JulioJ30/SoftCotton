using SoftCotton.BusinessLogic;
using SoftCotton.Model.ReferralGuide;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SoftCotton.Views.ReferralGuide
{
    public partial class RegistroCierrePeriodoView : Form
    {
        GuiaRemisionBL _guiaRemisionBL;
        SetCierrePeriodoParam _cierrePeriodoParam;

        public RegistroCierrePeriodoView()
        {
            InitializeComponent();

            _guiaRemisionBL = new GuiaRemisionBL();
        }

        private void RegistroCierrePeriodoView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtPeriodo.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtPeriodo.Focus();
            Fecha();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }


        // ### Funciones ###
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _cierrePeriodoParam = new SetCierrePeriodoParam();

                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    _cierrePeriodoParam.opcion = 2; // ACTUALIZAR
                    _cierrePeriodoParam.idCierrePeriodo = Convert.ToInt32(lblId.Text);
                    _cierrePeriodoParam.periodo = txtPeriodo.Text;
                    _cierrePeriodoParam.fechaInicio = dtpFechaInicio.Value;
                    _cierrePeriodoParam.fechaFin = dtpFechaFin.Value;
                    _cierrePeriodoParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _cierrePeriodoParam.opcion = 1; // REGISTRAR
                    _cierrePeriodoParam.idCierrePeriodo = 0;
                    _cierrePeriodoParam.periodo = txtPeriodo.Text;
                    _cierrePeriodoParam.fechaInicio = dtpFechaInicio.Value;
                    _cierrePeriodoParam.fechaFin = dtpFechaFin.Value;
                    _cierrePeriodoParam.usuarioReg = UserApplication.USUARIO;// UserApplication.USUARIO;
                }

                Procesar(_cierrePeriodoParam);
            }
        }

        public void Procesar(SetCierrePeriodoParam parametro)
        {
            Response responseGeneral = _guiaRemisionBL.SetCierrePeriodo(parametro);

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
            List<GetGR7_CierrePeriodo> listaCeCos = _guiaRemisionBL.GetGR7_CierrePeriodo();

            dgvListado.Rows.Clear();

            foreach (var item in listaCeCos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtPeriodo"].Value = item.periodo;
                dgvListado.Rows[index].Cells["ctxtFechaInicio"].Value = item.fechaInicio;
                dgvListado.Rows[index].Cells["ctxtFechaFin"].Value = item.fechaFin;
                dgvListado.Rows[index].Cells["ctxtEstado"].Value = item.estado;
                dgvListado.Rows[index].Cells["ctxtidCierrePeriodo"].Value = item.idCierrePeriodo;
                dgvListado.Rows[index].Cells["ctxtidEstado"].Value = item.idEstado;

                if (item.idEstado == "A")
                {
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.LightCoral;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.LightCoral;
                    dgvListado.Rows[index].Cells["cbtnCerrar"].Style.BackColor = Color.Blue;
                    dgvListado.Rows[index].Cells["cbtnCerrar"].Style.SelectionBackColor = Color.Blue;
                    dgvListado.Rows[index].Cells["cbtnReAbrir"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnReAbrir"].Style.SelectionBackColor = Color.Gray;
                }
                else
                {
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnCerrar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnCerrar"].Style.SelectionBackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnReAbrir"].Style.BackColor = Color.Orange;
                    dgvListado.Rows[index].Cells["cbtnReAbrir"].Style.SelectionBackColor = Color.Orange;
                }
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }

        private bool ValidarDatos()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtPeriodo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el periodo", "INFORMATION");
                txtPeriodo.Focus();
            }
            else if (string.IsNullOrEmpty(dtpFechaInicio.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la fecha inicio", "INFORMATION");
                dtpFechaInicio.Focus();
            }
            else if (string.IsNullOrEmpty(dtpFechaFin.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la fecha fin", "INFORMATION");
                dtpFechaFin.Focus();
            }
            else if (!string.IsNullOrEmpty(txtPeriodo.Text))
            {
                var length = txtPeriodo.Text.Trim().Length;
                if (length < 7)
                {
                    validacion = false;

                    ResponseMessage.Message("El período debe tener 7 digito YYYY-MM", "INFORMATION");
                    txtPeriodo.Focus();
                }
                else
                {
                    validacion = true;
                }
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            lblId.Text = "";
            txtPeriodo.Text = "";
            Fecha();
        }

        public void Fecha()
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var fechaInicio = date;
            var fechaFin = date.AddMonths(1).AddDays(-1);

            dtpFechaInicio.Text = fechaInicio.ToString();
            dtpFechaFin.Text = fechaFin.ToString();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var idCierrePeriodo = dgvListado.Rows[e.RowIndex].Cells["ctxtidCierrePeriodo"].Value.ToString();
            var estado = dgvListado.Rows[e.RowIndex].Cells["ctxtidEstado"].Value.ToString();

            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar") && estado == "A")
            {
                lblId.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtidCierrePeriodo"].Value.ToString();
                txtPeriodo.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtPeriodo"].Value.ToString();
                dtpFechaInicio.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtFechaInicio"].Value.ToString();
                dtpFechaFin.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtFechaFin"].Value.ToString();
            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar") && estado == "A")
            {
                DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                if (pregunta.Equals(DialogResult.OK))
                {
                    _cierrePeriodoParam = new SetCierrePeriodoParam();
                    _cierrePeriodoParam.opcion = 3; // ELIMINAR 
                    _cierrePeriodoParam.idCierrePeriodo = Convert.ToInt32(idCierrePeriodo);
                    _cierrePeriodoParam.usuarioReg = UserApplication.USUARIO;

                    Procesar(_cierrePeriodoParam);
                }
            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnCerrar") && estado == "A")
            {
                DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea cerrar el período?");

                if (pregunta.Equals(DialogResult.OK))
                {
                    var fechaInicio = Convert.ToDateTime(dgvListado.Rows[e.RowIndex].Cells["ctxtFechaInicio"].Value.ToString());
                    var fechaFin = Convert.ToDateTime(dgvListado.Rows[e.RowIndex].Cells["ctxtFechaFin"].Value.ToString());

                    _cierrePeriodoParam = new SetCierrePeriodoParam();
                    _cierrePeriodoParam.opcion = 4; // CERRAR 
                    _cierrePeriodoParam.idCierrePeriodo = Convert.ToInt32(idCierrePeriodo);
                    _cierrePeriodoParam.fechaInicio = fechaInicio;
                    _cierrePeriodoParam.fechaFin = fechaFin;
                    _cierrePeriodoParam.usuarioReg = UserApplication.USUARIO;

                    Procesar(_cierrePeriodoParam);
                }
            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnReAbrir") && estado == "C")
            {
                DialogResult pregunta = ResponseMessage.MessageQuestion("¿Estas seguro de reabrir el período?");

                if (pregunta.Equals(DialogResult.OK))
                {
                    var fechaInicio = Convert.ToDateTime(dgvListado.Rows[e.RowIndex].Cells["ctxtFechaInicio"].Value.ToString());
                    var fechaFin = Convert.ToDateTime(dgvListado.Rows[e.RowIndex].Cells["ctxtFechaFin"].Value.ToString());

                    _cierrePeriodoParam = new SetCierrePeriodoParam();
                    _cierrePeriodoParam.opcion = 6; // RE ABRIR 
                    _cierrePeriodoParam.idCierrePeriodo = Convert.ToInt32(idCierrePeriodo);
                    _cierrePeriodoParam.fechaInicio = fechaInicio;
                    _cierrePeriodoParam.fechaFin = fechaFin;
                    _cierrePeriodoParam.usuarioReg = UserApplication.USUARIO;

                    Procesar(_cierrePeriodoParam);
                }
            }
        }
    }
}
