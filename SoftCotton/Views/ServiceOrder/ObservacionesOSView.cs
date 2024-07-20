using SoftCotton.BusinessLogic;
using SoftCotton.Model.ServiceOrder;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.ServiceOrder
{
    public partial class ObservacionesOSView : Form
    {
        OrdenServicioBL _ordenServicioBL;
        SetOSObservacionParam _observacionParam;
        
        public ObservacionesOSView()
        {
            InitializeComponent();

            _ordenServicioBL = new OrdenServicioBL();
        }

        private void ObservacionesOSView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtObservacion.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtObservacion.Focus();
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
                    lbIIdObs.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdObs"].Value.ToString().Trim();
                    txtObservacion.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtObservacion"].Value.ToString().Trim();
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
                    int idObs = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntIdObs"].Value.ToString());
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _observacionParam = new SetOSObservacionParam();
                        _observacionParam.opcion = 4; // ELIMINAR 
                        _observacionParam.idObs = idObs;
                        _observacionParam.usuReg = UserApplication.USUARIO;

                        Procesar(_observacionParam);
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

                    _observacionParam = new SetOSObservacionParam();

                    _observacionParam.opcion = 3; // INHABILITAR
                    _observacionParam.idObs = Convert.ToInt32(row.Cells["cIntIdObs"].Value.ToString());
                    _observacionParam.usuReg = UserApplication.USUARIO;
                    _observacionParam.estado = valorCheck;

                    Procesar(_observacionParam);
                }
            }
        }



        // ### Funciones ###

        public void Guardar()
        {
            if (ValidarDatos())
            {
                _observacionParam = new SetOSObservacionParam();

                if (lbIIdObs.Text != "0")
                {
                    _observacionParam.opcion = 2; // ACTUALIZAR 
                    _observacionParam.idObs = Convert.ToInt32(lbIIdObs.Text);
                    _observacionParam.observacion = txtObservacion.Text;
                    _observacionParam.usuReg = UserApplication.USUARIO;
                }
                else
                {
                    _observacionParam.opcion = 1; // REGISTRAR
                    _observacionParam.idObs = 0;
                    _observacionParam.observacion = txtObservacion.Text;
                    _observacionParam.usuReg = UserApplication.USUARIO;
                }

                Procesar(_observacionParam);
            }
        }

        public void Procesar(SetOSObservacionParam parametro)
        {
            Response responseGeneral = _ordenServicioBL.SetOSObservacion(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar();
                Listar();
                lbIIdObs.Text = "0";
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        public void Listar()
        {
            List<GetOS14_Observaciones> listaObservaciones = _ordenServicioBL.Get14_Observaciones();

            dgvListado.Rows.Clear();

            foreach (var item in listaObservaciones)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntIdObs"].Value = item.idObs;
                dgvListado.Rows[index].Cells["ctxtObservacion"].Value = item.observacion;

                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["ctxtUsuReg"].Value = item.usuReg;

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

            dgvListado.ClearSelection();
        }


        private bool ValidarDatos()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de tipo de Documento", "INFORMATION");
                txtObservacion.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtObservacion.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
