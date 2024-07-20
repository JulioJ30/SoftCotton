using SoftCotton.BusinessLogic;
using SoftCotton.Model.Employee;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.Employee
{
    public partial class RegistroColaboradorView : Form
    {
        EmpleadoBL _empleadoBL;
        SetColaboradorParam _colaboradorParam;

        public RegistroColaboradorView()
        {
            InitializeComponent();

            _empleadoBL = new EmpleadoBL();
        }

        private void RegistroColaboradorView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            ListarCargosCBX();
            ListarAreasCBX();
            ValoresPredeterminado();
            btnNuevoPeriodo.Enabled = false;

            txtBuscarNumDoc.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            ListarCargosCBX();
            ListarAreasCBX();
            ValoresPredeterminado();
            btnNuevoPeriodo.Enabled = false;

            txtBuscarNumDoc.Focus();
        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }



        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                lblIDPeriodo.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdPeriodo"].Value.ToString().Trim();
                lblIDEstadoMensaje.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdPeriodo"].Value.ToString().Trim();

                lblDNIBusqueda.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtNumDoc"].Value.ToString().Trim();
                cbxCargo.SelectedValue = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntCargo"].Value.ToString());
                cbxArea.SelectedValue = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntCargo"].Value.ToString());

                dtpFechaIngreso.Value = Convert.ToDateTime(dgvListado.Rows[e.RowIndex].Cells["ctxtFechaIngreso"].Value.ToString());
                dtpFechaCese.Value = Convert.ToDateTime(dgvListado.Rows[e.RowIndex].Cells["ctxtFechaCese"].Value.ToString());

                lblIDEstadoMensaje.Text = dgvListado.Rows[e.RowIndex].Cells["cIntIdEstado"].Value.ToString();
                lblMensajeEstado.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtMensajeEstado"].Value.ToString();

                if (lblIDEstadoMensaje.Text == "2")
                {
                    // 2. Personal Cesado
                    btnNuevoPeriodo.Enabled = true;
                }
                else
                {
                    btnNuevoPeriodo.Enabled = false;
                }

            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            {
                string idPeriodo = dgvListado.Rows[e.RowIndex].Cells["cIntIdPeriodo"].Value.ToString();
                DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                if (pregunta.Equals(DialogResult.OK))
                {
                    _colaboradorParam = new SetColaboradorParam();
                    _colaboradorParam.opcion = 4; // ELIMINAR 
                    _colaboradorParam.idPeriodo = Convert.ToInt32(idPeriodo);
                    _colaboradorParam.usuarioReg = UserApplication.USUARIO;

                    Procesar(_colaboradorParam);
                }
            }
        }

        private void btnBuscarValidar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscarNumDoc.Text))
            {
                BuscarXDNI(txtBuscarNumDoc.Text);
            }
        }

        private void txtBuscarNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtBuscarNumDoc.Text))
                {
                    BuscarXDNI(txtBuscarNumDoc.Text);
                }
            }
        }
        
        private void btnNuevoPeriodo_Click(object sender, EventArgs e)
        {
            lblIDPeriodo.Text = "0";
            cbxCargo.SelectedValue = 0;
            cbxArea.SelectedValue = 0;

            dtpFechaIngreso.Value = DateTime.Now.Date;
            dtpFechaCese.Value = Convert.ToDateTime(new DateTime(1970, 1, 1));
        }



        // ### Funciones ###
        public void ListarCargosCBX()
        {
            List<GetEmp4_Cargos> cbxCargosList = _empleadoBL.Get4_Cargos();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxCargosList;

            cbxCargo.DisplayMember = "cargo";
            cbxCargo.ValueMember = "idCargo";
            cbxCargo.DataSource = bindingSource.DataSource;
        }
        public void ListarAreasCBX()
        {
            List<GetEmp5_Areas> cbxAreasList = _empleadoBL.Get5_Areas();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxAreasList;

            cbxArea.DisplayMember = "area";
            cbxArea.ValueMember = "idArea";
            cbxArea.DataSource = bindingSource.DataSource;
        }

        private void BuscarXDNI(string numeroDocumento)
        {
            // 1: Colaborador activo 
            // 2: Colaborador Cesado
            // 4: Personal Nuevo
            // 0: Persona no encontrada

            GetEmp3_BuscarPersona estadoBusqueda = _empleadoBL.Get3_BuscarPersona(numeroDocumento);

            lblIDEstadoMensaje.Text = estadoBusqueda.estadoBusqueda.ToString();
            lblDNIBusqueda.Text = estadoBusqueda.numDoc.Trim();
            lblMensajeEstado.Text = estadoBusqueda.mensaje;

            if (lblIDEstadoMensaje.Text.ToString() == "1" || lblIDEstadoMensaje.Text.ToString() == "2")
            {
                GetEmp6_BuscarXDNI colaborador = _empleadoBL.Get6_BuscarXDNI(numeroDocumento);

                lblIDPeriodo.Text = colaborador.idPeriodo.ToString();
                cbxCargo.SelectedValue = colaborador.idCargo;
                cbxArea.SelectedValue = colaborador.idArea;
                dtpFechaIngreso.Value = colaborador.fechaIngreso.Date;
                dtpFechaCese.Value = colaborador.fechaCese.Date;


                if (lblIDEstadoMensaje.Text.ToString() == "2")
                {
                    btnNuevoPeriodo.Enabled = true;
                }
                else
                {
                    btnNuevoPeriodo.Enabled = false;
                }

            }
            else if (lblIDEstadoMensaje.Text.ToString() == "0")
            {
                Limpiar();
                ValoresPredeterminado();

                btnNuevoPeriodo.Enabled = false;
            }
        }


        public void Guardar()
        {
            if (ValidarDatos())
            {
                _colaboradorParam = new SetColaboradorParam();

                if (lblIDPeriodo.Text != "0")
                {
                    _colaboradorParam.opcion = 2; // ACTUALIZAR 
                    _colaboradorParam.idPeriodo = Convert.ToInt32(lblIDPeriodo.Text);
                    _colaboradorParam.numeroDocumento = lblDNIBusqueda.Text.Trim();
                    _colaboradorParam.idCargo = Convert.ToInt32(cbxCargo.SelectedValue.ToString());
                    _colaboradorParam.idArea = Convert.ToInt32(cbxArea.SelectedValue.ToString());
                    _colaboradorParam.fechaIngreso = dtpFechaIngreso.Value.Date.ToString("yyyyMMdd");
                    _colaboradorParam.fechaCese = dtpFechaCese.Value.Date.ToString("yyyyMMdd");
                    _colaboradorParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _colaboradorParam.opcion = 1; // REGISTRAR
                    _colaboradorParam.idPeriodo = 0;
                    _colaboradorParam.numeroDocumento = lblDNIBusqueda.Text.Trim();
                    _colaboradorParam.idCargo = Convert.ToInt32(cbxCargo.SelectedValue.ToString());
                    _colaboradorParam.idArea = Convert.ToInt32(cbxArea.SelectedValue.ToString());
                    _colaboradorParam.fechaIngreso = dtpFechaIngreso.Value.Date.ToString("yyyyMMdd");
                    _colaboradorParam.fechaCese = dtpFechaCese.Value.Date.ToString("yyyyMMdd");
                    _colaboradorParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_colaboradorParam);
            }
        }

        public void Procesar(SetColaboradorParam parametro)
        {
            Response responseGeneral = _empleadoBL.SetEmpColaborador(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar();
                Listar();
                ValoresPredeterminado();
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        public void Listar()
        {
            List<GetEmp2_Colaboradores> listaColaborador = _empleadoBL.Get2_Colaboradores();

            dgvListado.Rows.Clear();

            foreach (var item in listaColaborador)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntIdPeriodo"].Value = item.idPeriodo;

                dgvListado.Rows[index].Cells["ctxtNumDoc"].Value = item.numeroDocumento;
                dgvListado.Rows[index].Cells["ctxtPersona"].Value = item.persona;

                dgvListado.Rows[index].Cells["cIntCargo"].Value = item.idCargo;
                dgvListado.Rows[index].Cells["ctxtCargo"].Value = item.cargo;
                dgvListado.Rows[index].Cells["cIntArea"].Value = item.idArea;
                dgvListado.Rows[index].Cells["ctxtArea"].Value = item.area;

                dgvListado.Rows[index].Cells["ctxtFechaIngreso"].Value = item.fechaIngreso;
                dgvListado.Rows[index].Cells["ctxtFechaCese"].Value = item.fechaCese;

                dgvListado.Rows[index].Cells["cIntIdEstado"].Value = item.idEstado;
                dgvListado.Rows[index].Cells["ctxtMensajeEstado"].Value = item.mensajeEstado;

                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }


        private bool ValidarDatos()
        {
            bool validacion = false;

            if (lblDNIBusqueda.Text == "0")
            {
                validacion = false;

                ResponseMessage.Message("Colaborador No Encontrado", "INFORMATION");
                txtBuscarNumDoc.Focus();
            }
            else if (lblIDEstadoMensaje.Text == "0")
            {
                validacion = false;

                ResponseMessage.Message("Colaborador no encontrado", "INFORMATION");
                txtBuscarNumDoc.Focus();
            }
            else if (cbxCargo.SelectedValue.ToString() == "0")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione el cargo", "INFORMATION");
                cbxCargo.Focus();
            }
            else if (cbxArea.SelectedValue.ToString() == "0")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione el Area", "INFORMATION");
                cbxArea.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            lblDNIBusqueda.Text = "0";
            lblIDEstadoMensaje.Text = "0";
            lblMensajeEstado.Text = "";
            txtBuscarNumDoc.Text = "";
        }

        public void ValoresPredeterminado()
        {
            lblIDPeriodo.Text = "0";
            cbxCargo.SelectedValue = 0;
            cbxArea.SelectedValue = 0;

            dtpFechaIngreso.Value = DateTime.Now.Date;
            dtpFechaCese.Value = Convert.ToDateTime(new DateTime(1970, 1, 1));
        }

   

    }
}
