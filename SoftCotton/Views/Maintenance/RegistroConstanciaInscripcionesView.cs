using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SoftCotton.Model.Maintenance;
using SoftCotton.BusinessLogic;
using SoftCotton.Util;
using System.Data;
using System;





namespace SoftCotton.Views.Maintenance
{
    public partial class RegistroConstanciaInscripcionesView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetConstanciaInscripcionParam _constanciaInscripcion;


        public RegistroConstanciaInscripcionesView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            _constanciaInscripcion = new SetConstanciaInscripcionParam();
        }



        public void Limpiar()
        {
            txtConstancia.Clear();
            lblid.Text = "0";
        }


        private bool ValidarDatos()
        {
            bool validacion = false;
            if (string.IsNullOrEmpty(txtConstancia.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción de Constancia", "INFORMATION");
                txtConstancia.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Guardar()
        {
            if (ValidarDatos())
            {
                _constanciaInscripcion = new SetConstanciaInscripcionParam();

                if (Convert.ToInt32(lblid.Text) > 0)
                {
                    _constanciaInscripcion.opcion = 2; // ACTUALIZAR
                    _constanciaInscripcion.idConstanciaInscripcion = Convert.ToInt32(lblid.Text);
                    _constanciaInscripcion.constanciaInscripcion = txtConstancia.Text;
                    _constanciaInscripcion.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _constanciaInscripcion.opcion = 1; // REGISTRAR
                    _constanciaInscripcion.idConstanciaInscripcion = 0;
                    _constanciaInscripcion.constanciaInscripcion = txtConstancia.Text;
                    _constanciaInscripcion.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_constanciaInscripcion);
            }
        }

        public void Procesar(SetConstanciaInscripcionParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetConstanciaInscripciones(parametro);

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
            List<GetMant40_ConstanciaInscripcion> listaConstancia = _mantenimientoBL.GetMant40_ConstanciaInscripcion();

            dgvListado.Rows.Clear();

            foreach (var item in listaConstancia)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["idConstancia"].Value = item.idConstanciaInscripcion;
                dgvListado.Rows[index].Cells["constanciaInscripcion"].Value = item.constanciaInscripcion;
                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaCrea;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;

                if (item.estado == "1")
                {
                    dgvListado.Rows[index].Cells["cbxActivo"].Value = true;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.LightCoral;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.LightCoral;
                }
                else
                {
                    dgvListado.Rows[index].Cells["cbxActivo"].Value = false;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.Gray;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.Gray;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.Gray;
                }
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }

        private void RegistroConstanciaInscripcionesView_Load(object sender, System.EventArgs e)
        {
            Limpiar();
            Listar();
        }

        private void btnNuevo_Click(object sender, System.EventArgs e)
        {
            Limpiar();
            Listar();
            txtConstancia.Focus();
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            Guardar();
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
                    pregunta = "¿Desea activar Constancia de Inscripciones?";
                }
                else
                {
                    pregunta = "¿Desea deshabilitar el Constancia de Inscripciones?";
                }

                DialogResult resultadoPregunta = ResponseMessage.MessageQuestion(pregunta);

                if (resultadoPregunta.Equals(DialogResult.OK))
                {
                    row.Cells["cbxActivo"].Value = valorCheck;

                    _constanciaInscripcion = new SetConstanciaInscripcionParam();

                    _constanciaInscripcion.opcion = 3; // INHABILITAR
                    _constanciaInscripcion.idConstanciaInscripcion = Convert.ToInt32(row.Cells["idConstancia"].Value);
                    _constanciaInscripcion.usuarioReg = UserApplication.USUARIO;
                    _constanciaInscripcion.estado = valorCheck ? "1" : "0";

                    Procesar(_constanciaInscripcion);
                }
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
                {
                    lblid.Text = dgvListado.Rows[e.RowIndex].Cells["idConstancia"].Value.ToString().Trim();
                    txtConstancia.Text = dgvListado.Rows[e.RowIndex].Cells["constanciaInscripcion"].Value.ToString().Trim();
                }
                else
                {
                    Limpiar();
                }
            }
        }
    }
}
