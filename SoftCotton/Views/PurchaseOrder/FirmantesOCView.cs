using SoftCotton.BusinessLogic;
using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.PurchaseOrder
{
    public partial class FirmantesOCView : Form
    {
        OrdenCompraBL _ordenCompraBL;
        SetOCFirmantesParam _firmanteParam;
        GetOC15_FirmanteXNivel _firmanteInicial;

        public FirmantesOCView()
        {
            InitializeComponent();

            _ordenCompraBL = new OrdenCompraBL();
            _firmanteParam = new SetOCFirmantesParam();
            _firmanteInicial = new GetOC15_FirmanteXNivel();
        }

        private void FirmantesOCView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar(Empresa.ID_EMPRESA);
            btnBuscarUsuario.Focus();
            ListarTiposAprobacionesCBX();

            btnBuscarUsuario.Enabled = true;
            cbxTipoAprobacion.Enabled = true;
        }


        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            BuscarUsuarioView usuarioView = new BuscarUsuarioView();
            usuarioView.ShowDialog();
            lblIdUsuarioReg.Text = usuarioView.idUsuario;
            lblColaborador.Text = usuarioView.colaborador;

            txtRutaImagen.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar(Empresa.ID_EMPRESA);
            btnBuscarUsuario.Focus();

            btnBuscarUsuario.Enabled = true;
            cbxTipoAprobacion.Enabled = true;
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
                    lblIdUsuarioReg.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdUsuario"].Value.ToString();
                    lblIdUsuarioUpdate.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdUsuario"].Value.ToString();
                    lblIdTipoAprobacion.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdTipoAprobacion"].Value.ToString();
                    lblColaborador.Text = dgvListado.Rows[e.RowIndex].Cells["cTxtColaborador"].Value.ToString();

                    cbxTipoAprobacion.SelectedValue = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntIdTipoAprobacion"].Value.ToString());
                    txtRutaImagen.Text = dgvListado.Rows[e.RowIndex].Cells["cTxtRutaImgFirma"].Value.ToString();

                    btnBuscarUsuario.Enabled = false;
                    cbxTipoAprobacion.Enabled = false;
                    
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
                    int idUsuario = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntIdUsuario"].Value.ToString());
                    int idTipoAprobacion = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntIdTipoAprobacion"].Value.ToString());

                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _firmanteParam = new SetOCFirmantesParam();
                        _firmanteParam.opcion = 4; // ELIMINAR 
                        _firmanteParam.idUsuario = idUsuario;
                        _firmanteParam.idTipoAprobacion = idTipoAprobacion;
                        _firmanteParam.usuReg = UserApplication.USUARIO;

                        Procesar(_firmanteParam);
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

                    _firmanteParam = new SetOCFirmantesParam();

                    _firmanteParam.opcion = 3; // INHABILITAR
                    _firmanteParam.idUsuario = Convert.ToInt32(row.Cells["cIntIdUsuario"].Value.ToString());
                    _firmanteParam.idTipoAprobacion = Convert.ToInt32(row.Cells["cIntIdTipoAprobacion"].Value.ToString());

                    _firmanteParam.usuReg = UserApplication.USUARIO;
                    _firmanteParam.estado = valorCheck;

                    Procesar(_firmanteParam);
                }
            }
        }



        // ### Funciones ###
        public void ListarTiposAprobacionesCBX()
        {
            List<GetOC13_TiposAprobacion> cbxTipoDocList = _ordenCompraBL.Get13_TiposAprobacion();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxTipoDocList;

            cbxTipoAprobacion.DisplayMember = "descripcion";
            cbxTipoAprobacion.ValueMember = "idTipoAprobacion";
            cbxTipoAprobacion.DataSource = bindingSource.DataSource;
        }



        // ### Funciones ###
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _firmanteParam = new SetOCFirmantesParam();

                if (lblIdUsuarioUpdate.Text != "0")
                {
                    _firmanteParam.opcion = 2; // ACTUALIZAR
                    _firmanteParam.idUsuario = Convert.ToInt32(lblIdUsuarioUpdate.Text);
                    _firmanteParam.idTipoAprobacion = Convert.ToInt32(lblIdTipoAprobacion.Text);

                    _firmanteParam.idUsuarioUpdate = Convert.ToInt32(lblIdUsuarioUpdate.Text);
                    _firmanteParam.idTipoAprobacionUpdate = Convert.ToInt32(cbxTipoAprobacion.SelectedValue);

                    _firmanteParam.estado = true;
                    _firmanteParam.rutaImgFirma = txtRutaImagen.Text;
                    _firmanteParam.usuReg = UserApplication.USUARIO;
                }
                else
                {
                    _firmanteParam.opcion = 1; // REGISTRAR
                    _firmanteParam.idUsuario = Convert.ToInt32(lblIdUsuarioReg.Text);
                    _firmanteParam.idTipoAprobacion = Convert.ToInt32(cbxTipoAprobacion.SelectedValue);

                    _firmanteParam.idUsuarioUpdate = 0;
                    _firmanteParam.idTipoAprobacionUpdate = 0;

                    _firmanteParam.estado = true;
                    _firmanteParam.rutaImgFirma = txtRutaImagen.Text;
                    _firmanteParam.usuReg = UserApplication.USUARIO;
                }

                Procesar(_firmanteParam);
            }
        }

        public void Procesar(SetOCFirmantesParam parametro)
        {
            Response responseGeneral = _ordenCompraBL.SetOCFirmantes(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar();
                Listar(Empresa.ID_EMPRESA);

                btnBuscarUsuario.Enabled = true;
                cbxTipoAprobacion.Enabled = true;
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        public void Listar(int idEmpresa)
        {
            List<GetOC11_Firmantes> listaFirmantes = _ordenCompraBL.Get11_Firmantes(idEmpresa);

            dgvListado.Rows.Clear();

            foreach (var item in listaFirmantes)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntIdUsuario"].Value = item.idUsuario;
                dgvListado.Rows[index].Cells["cIntIdTipoAprobacion"].Value = item.idTipoAprobacion;
                dgvListado.Rows[index].Cells["cTxtColaborador"].Value = item.colaborador;
                dgvListado.Rows[index].Cells["cTxtTipoAprobacion"].Value = item.tipoAprobacion;
                dgvListado.Rows[index].Cells["cIntNivelAprobacion"].Value = item.nivelAprobacion;
                dgvListado.Rows[index].Cells["cTxtRutaImgFirma"].Value = item.rutaImgFirma;

                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuReg;

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

            if (string.IsNullOrEmpty(lblIdUsuarioReg.Text))
            {
                validacion = false;

                ResponseMessage.Message("Selecccione un usuario", "INFORMATION");
                btnBuscarUsuario.Focus();
            }
            else if (Convert.ToInt32(lblIdUsuarioReg.Text) == 0)
            {
                validacion = false;

                ResponseMessage.Message("Seleccione un usuario", "INFORMATION");
                btnBuscarUsuario.Focus();
            }
            else if (cbxTipoAprobacion.SelectedValue == null)
            {
                validacion = false;

                ResponseMessage.Message("Seleccione un tipo de Aprobación", "INFORMATION");
                btnBuscarUsuario.Focus();
            }
            else if (cbxTipoAprobacion.SelectedValue.ToString() == "0")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione un tipo de Aprobación", "INFORMATION");
                btnBuscarUsuario.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            lblColaborador.Text = "";
            lblIdUsuarioUpdate.Text = "0";
            txtRutaImagen.Text = "";
            cbxTipoAprobacion.SelectedValue = 0;
            lblIdTipoAprobacion.Text = "0";
            lblIdUsuarioReg.Text = "0";
        }


    }
}
