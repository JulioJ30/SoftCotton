using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SoftCotton.Model.Maintenance;
using SoftCotton.BusinessLogic;
using SoftCotton.Util;
using System.Data;
using System;
using SoftCotton.Views.Employee;


namespace SoftCotton.Views.Maintenance
{
    public partial class RegistroNumeroLicenciaConducirView : Form
    {

        MantenimientoBL _mantenimientoBL;
        SetNumeroLicenciaConducirParam _numeroLicencia;
        string tipodocumento = "";

        public RegistroNumeroLicenciaConducirView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            _numeroLicencia = new SetNumeroLicenciaConducirParam();

        }


        public void Limpiar()
        {
            txtNumeroLicencia.Clear();
            lblid.Text = "0";
        }


        private bool ValidarDatos()
        {
            bool validacion = false;
            if (string.IsNullOrEmpty(txtNumeroLicencia.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el Número de Licencia", "INFORMATION");
                txtNumeroLicencia.Focus();
            }
            else if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese Documento del Condutor", "INFORMATION");
                txtNumeroLicencia.Focus();
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
                _numeroLicencia = new SetNumeroLicenciaConducirParam();

                if (Convert.ToInt32(lblid.Text) > 0)
                {
                    _numeroLicencia.opcion = 2; // ACTUALIZAR
                    _numeroLicencia.idNumeroLicenciaConducir = Convert.ToInt32(lblid.Text);
                    _numeroLicencia.numeroLicenciaConducir = txtNumeroLicencia.Text;
                    _numeroLicencia.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;

                    _numeroLicencia.codTipoDocConductor = tipodocumento;
                    _numeroLicencia.numDocConductor = txtNumeroDocumento.Text.Trim();

                }
                else
                {
                    _numeroLicencia.opcion = 1; // REGISTRAR
                    _numeroLicencia.idNumeroLicenciaConducir = 0;
                    _numeroLicencia.numeroLicenciaConducir = txtNumeroLicencia.Text;
                    _numeroLicencia.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;

                    _numeroLicencia.codTipoDocConductor = tipodocumento;
                    _numeroLicencia.numDocConductor = txtNumeroDocumento.Text.Trim();
                }

                Procesar(_numeroLicencia);
            }
        }

        public void Procesar(SetNumeroLicenciaConducirParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetNumeroLicenciaConducir(parametro);

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
            List<GetMant41_NumeroLicenciaConducir> listaLicencias = _mantenimientoBL.GetMant41_NumeroLicenciaConducir();

            dgvListado.Rows.Clear();

            foreach (var item in listaLicencias)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["idLicencia"].Value = item.idNumeroLicenciaConducir;
                dgvListado.Rows[index].Cells["numeroLicencia"].Value = item.numeroLicenciaConducir;
                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaCrea;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;

                dgvListado.Rows[index].Cells["nombres"].Value = item.nombres;
                dgvListado.Rows[index].Cells["apellidos"].Value = item.apellidos;
                dgvListado.Rows[index].Cells["codtipdocumento"].Value = item.codTipoDocConductor;
                dgvListado.Rows[index].Cells["numerodocumento"].Value = item.numDocConductor;


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

        private void RegistroNumeroLicenciaConducirView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtNumeroLicencia.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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
                    pregunta = "¿Desea activar Número de Licencia?";
                }
                else
                {
                    pregunta = "¿Desea deshabilitar Número de Licencia?";
                }

                DialogResult resultadoPregunta = ResponseMessage.MessageQuestion(pregunta);

                if (resultadoPregunta.Equals(DialogResult.OK))
                {
                    row.Cells["cbxActivo"].Value = valorCheck;

                    _numeroLicencia = new SetNumeroLicenciaConducirParam();

                    _numeroLicencia.opcion = 3; // INHABILITAR
                    _numeroLicencia.idNumeroLicenciaConducir = Convert.ToInt32(row.Cells["idLicencia"].Value);
                    _numeroLicencia.usuarioReg = UserApplication.USUARIO;
                    _numeroLicencia.estado = valorCheck ? "1" : "0";

                    Procesar(_numeroLicencia);
                }
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
                {
                    lblid.Text = dgvListado.Rows[e.RowIndex].Cells["idLicencia"].Value.ToString().Trim();
                    txtNumeroLicencia.Text = dgvListado.Rows[e.RowIndex].Cells["numeroLicencia"].Value.ToString().Trim();

                    txtNumeroDocumento.Text = dgvListado.Rows[e.RowIndex].Cells["numerodocumento"].Value.ToString().Trim();//frm.numerodocumento;
                    txtApellidos.Text = dgvListado.Rows[e.RowIndex].Cells["apellidos"].Value.ToString().Trim();//frm.apellidos;
                    txtNombres.Text = dgvListado.Rows[e.RowIndex].Cells["nombres"].Value.ToString().Trim();//frm.nombres;
                    tipodocumento = dgvListado.Rows[e.RowIndex].Cells["codtipdocumento"].Value.ToString().Trim();//frm.tipodocumento;

                }
                else
                {
                    Limpiar();
                }
            }
        }

        private void btnBuscarDocumento_Click(object sender, EventArgs e)
        {
            BuscarPeronaView frm = new BuscarPeronaView();
            frm.ShowDialog();
            txtNumeroDocumento.Text = frm.numerodocumento;
            txtApellidos.Text = frm.apellidos;
            txtNombres.Text = frm.nombres;
            tipodocumento = frm.tipodocumento;

        }
    }
}
