using SoftCotton.BusinessLogic;
using SoftCotton.Model.Kardex;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using SoftCotton.Views.Shared;
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
    public partial class RegistroProductoView : Form
    {
        MantenimientoBL _mantenimientoBL;
        KardexBL _kardexBL;
        SetProductoServicioParam _productoServicioParam;
        SetGrupoParam _grupoParam;

        string codigoColor;

        public RegistroProductoView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            _kardexBL = new KardexBL();
            _productoServicioParam = new SetProductoServicioParam();
            _grupoParam = new SetGrupoParam();

            codigoColor = "";

            //UserApplication.USUARIO = "PMORAN";

        }

        private void RegistroProductoView_Load(object sender, EventArgs e)
        {
            ListarNivelCBX();
            ListarTallasCBX();
            //ListarColoresCBX();
            ListarUMCBX();

            LimpiarGrupo();
            ValoresPredeterminadoGrupo();

            txtCodGrupo.Enabled = false;
            btnBuscarGrupo.Enabled = false;
            txtCodGrupo.Text = "00000";
            cbxNivel.Focus();
        }


        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            LimpiarGrupo();
            LimpiarDetalle();
            ValoresPredeterminadoGrupo();
            ValoresDetallePredeterminados();

            txtCodGrupo.Enabled = false;
            btnBuscarGrupo.Enabled = false;
            btnGuardarGrupo.Enabled = true;
            cbxNivel.Enabled = true;
            txtCodGrupo.Text = "00000";

            cbxNivel.Focus();
        }

        private void btnBuscarGrupo_Click(object sender, EventArgs e)
        {
            if (cbxNivel.SelectedValue.ToString() != "00" && cbxNivel.SelectedValue != null)
            {
                if (!string.IsNullOrEmpty(txtCodGrupo.Text.Trim()))
                {
                    ListarGrupos(cbxNivel.SelectedValue.ToString(), txtCodGrupo.Text.Trim());
                    ListarDetalle(cbxNivel.SelectedValue.ToString(), txtCodGrupo.Text.Trim());
                }
                else
                {
                    ResponseMessage.Message("Ingrese el código de grupo", "INFORMATION");
                }
            }
            else
            {
                ResponseMessage.Message("Seleccione el tipo de nivel", "INFORMATION");
            }
        }

        private void btnHabilitarBuscar_Click(object sender, EventArgs e)
        {
            LimpiarGrupo();
            LimpiarDetalle();
            ValoresPredeterminadoGrupo();
            ValoresDetallePredeterminados();

            cbxNivel.Enabled = true;
            txtCodGrupo.Enabled = true;
            btnBuscarGrupo.Enabled = true;

            txtGrupo.Enabled = false;
            btnBuscarCuenta.Enabled = false;
            txtCuenta.Enabled = false;
            cbxUnidadMedida.Enabled = false;
            txtCodProductoAlt.Enabled = false;

            btnGuardarGrupo.Enabled = false;

            txtCodGrupo.Text = "";
            cbxNivel.Focus();
        }

        private void btnGuardarGrupo_Click(object sender, EventArgs e)
        {
            GuardarGrupo();
        }


        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            {
                string codNivel = dgvListado.Rows[e.RowIndex].Cells["cdgvGDCodNivel"].Value.ToString();
                string codGrupo = dgvListado.Rows[e.RowIndex].Cells["cdgvGDCodGrupo"].Value.ToString();
                string codTalla = dgvListado.Rows[e.RowIndex].Cells["cdgvGDCodTalla"].Value.ToString();
                string codColor = dgvListado.Rows[e.RowIndex].Cells["cdgvGDCodColor"].Value.ToString();

                DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                if (pregunta.Equals(DialogResult.OK))
                {
                    _productoServicioParam = new SetProductoServicioParam();
                    _productoServicioParam.opcion = 2; // ELIMINAR 
                    _productoServicioParam.codNivel = codNivel;
                    _productoServicioParam.codGrupo = codGrupo;
                    _productoServicioParam.codTalla = codTalla;
                    _productoServicioParam.codColor = codColor;

                    GuardarDetalle(_productoServicioParam);
                }
            }
        }


        private void dgvListadoGrupos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListadoGrupos.Columns[e.ColumnIndex].Name.Equals("cdgvBtnAgregarDet"))
            {
                lblCodNivelSeleccionado.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtCodNivel"].Value.ToString();
                lblNivelSeleccionado.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtNivel"].Value.ToString();

                lblCodGrupoSeleccionado.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtCodGrupo"].Value.ToString();
                lblGrupoSeleccionado.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtGrupo"].Value.ToString();

                cbxTalla.Enabled = true;
                btnBuscarColor.Enabled = true;

            }
            else if (dgvListadoGrupos.Columns[e.ColumnIndex].Name.Equals("cdgvBtnEliminar"))
            {
                string codNivel = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtCodNivel"].Value.ToString();
                string codGrupo = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtCodGrupo"].Value.ToString();

                DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                if (pregunta.Equals(DialogResult.OK))
                {
                    _grupoParam = new SetGrupoParam();
                    _grupoParam.opcion = 3; // ELIMINAR 
                    _grupoParam.codNivel = codNivel;
                    _grupoParam.codGrupo = codGrupo;

                    ProcesarGrupo(_grupoParam);


                    LimpiarGrupo();
                    LimpiarDetalle();
                    ValoresPredeterminadoGrupo();
                    ValoresDetallePredeterminados();

                    txtCodGrupo.Enabled = false;
                    btnBuscarGrupo.Enabled = true;
                    btnGuardarGrupo.Enabled = false;
                    btnNuevoGrupo.Enabled = true;
                    cbxNivel.Enabled = true;
                    txtCodGrupo.Text = "00000";

                    cbxNivel.Focus();

                }
            }
            else if (dgvListadoGrupos.Columns[e.ColumnIndex].Name.Equals("cdgvBtnEditar"))
            {
                cbxNivel.SelectedValue = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtCodNivel"].Value.ToString();
                txtCodGrupo.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtCodGrupo"].Value.ToString();
                txtGrupo.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtGrupo"].Value.ToString();
                txtGrupo.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtGrupo"].Value.ToString();
                lblCodCuenta.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtCodCuenta"].Value.ToString();
                txtCuenta.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtCuenta"].Value.ToString();
                cbxUnidadMedida.SelectedValue = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtUM"].Value.ToString();
                txtCodProductoAlt.Text = dgvListadoGrupos.Rows[e.RowIndex].Cells["cdgvGPTxtCodGrupoAlt"].Value.ToString();

                cbxNivel.Enabled = false;
                btnGuardarGrupo.Enabled = true;

                cbxNivel.Enabled = false;
                txtCodGrupo.Enabled = false;
                txtGrupo.Enabled = true;
                cbxUnidadMedida.Enabled = true;
                txtCodProductoAlt.Enabled = true;
                btnBuscarCuenta.Enabled = true;


            }
        }

        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDetalle())
            {

                _productoServicioParam = new SetProductoServicioParam();

                _productoServicioParam.opcion = 1; // REGISTRAR
                _productoServicioParam.codNivel = lblCodNivelSeleccionado.Text;
                _productoServicioParam.codGrupo = lblCodGrupoSeleccionado.Text;
                _productoServicioParam.codTalla = cbxTalla.SelectedValue.ToString();
                _productoServicioParam.codColor = codigoColor;

                GuardarDetalle(_productoServicioParam);

            }
        }


        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            BuscarCuentaView frmView = new BuscarCuentaView();
            frmView.ShowDialog();

            txtCuenta.Text = frmView.codCuenta.Trim() + " - " + frmView.cuenta.Trim();
            lblCodCuenta.Text = frmView.codCuenta;
            cbxUnidadMedida.Focus();
        }



        // ### Funciones ###
        public void ListarNivelCBX()
        {
            List<GetMant16_NivelCBX> cbxFamiliaList = _mantenimientoBL.Get16_NivelCBX();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxFamiliaList;

            cbxNivel.DisplayMember = "nivel";
            cbxNivel.ValueMember = "codNivel";
            cbxNivel.DataSource = bindingSource.DataSource;
        }

        public void ListarTallasCBX()
        {
            List<GetMant17_TallasCBX> cbxTallaList = _mantenimientoBL.Get17_TallasCBX();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxTallaList;

            cbxTalla.DisplayMember = "descripcion";
            cbxTalla.ValueMember = "codTalla";
            cbxTalla.DataSource = bindingSource.DataSource;
        }

        //public void ListarColoresCBX()
        //{
        //    List<GetMant18_ColoresCBX> cbxColoresList = _mantenimientoBL.Get18_ColoresCBX();
        //    var bindingSource = new BindingSource();
        //    bindingSource.DataSource = cbxColoresList;

        //    cbxColor.DisplayMember = "descripcion";
        //    cbxColor.ValueMember = "codColor";
        //    cbxColor.DataSource = bindingSource.DataSource;
        //}

        public void ListarUMCBX()
        {
            List<GetMant19_UMCBX> cbxUMList = _mantenimientoBL.Get19_UMCBX();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxUMList;

            cbxUnidadMedida.DisplayMember = "descripcion";
            cbxUnidadMedida.ValueMember = "codUM";
            cbxUnidadMedida.DataSource = bindingSource.DataSource;
        }

        private void GuardarGrupo()
        {
            if (ValidarDatosGrupo())
            {
                _grupoParam = new SetGrupoParam();

                if (txtCodGrupo.Text != "00000")
                {
                    _grupoParam.opcion = 2; // ACTUALIZAR
                    _grupoParam.codNivel = cbxNivel.SelectedValue.ToString();
                    _grupoParam.codGrupo = txtCodGrupo.Text;
                    _grupoParam.codGrupoAlt = txtCodProductoAlt.Text;
                    _grupoParam.grupo = txtGrupo.Text;
                    _grupoParam.codUM = cbxUnidadMedida.SelectedValue.ToString();
                    _grupoParam.codCuenta = lblCodCuenta.Text;
                    _grupoParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _grupoParam.opcion = 1; // REGISTRAR
                    _grupoParam.codNivel = cbxNivel.SelectedValue.ToString();
                    _grupoParam.codGrupo = txtCodGrupo.Text;
                    _grupoParam.codGrupoAlt = txtCodProductoAlt.Text;
                    _grupoParam.grupo = txtGrupo.Text;
                    _grupoParam.codUM = cbxUnidadMedida.SelectedValue.ToString();
                    _grupoParam.codCuenta = lblCodCuenta.Text;
                    _grupoParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;

                }

                ProcesarGrupo(_grupoParam);
            }
        }


        public void ProcesarGrupo(SetGrupoParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetGrupo(parametro);

            if (responseGeneral.idResponse > 0)
            {
                ListarGrupos(cbxNivel.SelectedValue.ToString(), responseGeneral.messageResponse);

                if (parametro.opcion == 1)
                {
                    ResponseMessage.Message("Guardado Correctamente", "INFORMATION");
                }
                else if (parametro.opcion == 2)
                {
                    ResponseMessage.Message("Actualizado Correctamente", "INFORMATION");
                }
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }


        public void GuardarDetalle(SetProductoServicioParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetProductoServicio(parametro);

            if (responseGeneral.idResponse > 0)
            {
                ListarDetalle(parametro.codNivel, parametro.codGrupo);
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        public void ListarGrupos(string codNivel, string codGrupo)
        {
            List<GetMant25_Grupos> listaGrupos = _mantenimientoBL.Get25_Grupos(codNivel, codGrupo);

            dgvListadoGrupos.Rows.Clear();

            foreach (var item in listaGrupos)
            {
                int index = dgvListadoGrupos.Rows.Add();

                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtCodNivel"].Value = item.codNivel;
                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtCodGrupo"].Value = item.codGrupo;
                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtNivel"].Value = item.nivel;
                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtNivelCompleto"].Value = item.codNivel.Trim() + " - " + item.nivel.Trim();
                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtGrupo"].Value = item.grupo;
                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtGrupoCompleto"].Value = item.codGrupo.Trim() + " - " + item.grupo.Trim();
                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtUM"].Value = item.codUM;
                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtCodCuenta"].Value = item.codCuenta;
                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtCuenta"].Value = item.codCuenta.Trim() + " - " + item.cuenta.Trim();
                dgvListadoGrupos.Rows[index].Cells["cdgvGPTxtCodGrupoAlt"].Value = item.codGrupoAlt;

                dgvListadoGrupos.Rows[index].Cells["cdgvBtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                dgvListadoGrupos.Rows[index].Cells["cdgvBtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                dgvListadoGrupos.Rows[index].Cells["cdgvBtnEditar"].Style.ForeColor = Color.White;
                dgvListadoGrupos.Rows[index].Cells["cdgvBtnEditar"].Style.SelectionForeColor = Color.White;

                dgvListadoGrupos.Rows[index].Cells["cdgvBtnEliminar"].Style.BackColor = Color.LightCoral;
                dgvListadoGrupos.Rows[index].Cells["cdgvBtnEliminar"].Style.SelectionBackColor = Color.LightCoral;
                dgvListadoGrupos.Rows[index].Cells["cdgvBtnEliminar"].Style.ForeColor = Color.White;
                dgvListadoGrupos.Rows[index].Cells["cdgvBtnEliminar"].Style.SelectionForeColor = Color.White;

                dgvListadoGrupos.Rows[index].Cells["cdgvBtnAgregarDet"].Style.BackColor = Color.SteelBlue;
                dgvListadoGrupos.Rows[index].Cells["cdgvBtnAgregarDet"].Style.SelectionBackColor = Color.SteelBlue;
                dgvListadoGrupos.Rows[index].Cells["cdgvBtnAgregarDet"].Style.ForeColor = Color.White;
                dgvListadoGrupos.Rows[index].Cells["cdgvBtnAgregarDet"].Style.SelectionForeColor = Color.White;
            }

            dgvListadoGrupos.ClearSelection();
        }



        public void ListarDetalle(string codNivel, string codGrupo)
        {
            List<GetMant26_ProdServicios> listaDetalle = _mantenimientoBL.Get26_ProductosServicios(codNivel, codGrupo);

            dgvListado.Rows.Clear();

            foreach (var item in listaDetalle)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cdgvGDCodNivel"].Value = item.codNivel;
                dgvListado.Rows[index].Cells["cdgvGDCodGrupo"].Value = item.codGrupo;
                dgvListado.Rows[index].Cells["cdgvGDCodTalla"].Value = item.codTalla;
                dgvListado.Rows[index].Cells["cdgvGDCodColor"].Value = item.codColor;

                dgvListado.Rows[index].Cells["cdgvGDNivel"].Value = item.nivel;
                dgvListado.Rows[index].Cells["cdgvGDGrupo"].Value = item.grupo;
                dgvListado.Rows[index].Cells["cdgvGDTalla"].Value = item.talla;
                dgvListado.Rows[index].Cells["cdgvGDColor"].Value = item.color;

            }

            dgvListado.ClearSelection();
        }


        private bool ValidarDatosDetalle()
        {
            bool validacion = false;

            if (lblCodNivelSeleccionado.Text == "---")
            {
                validacion = false;

                ResponseMessage.Message("No existe nivel seleccionado", "INFORMATION");
                txtGrupo.Focus();

            }
            if (lblCodGrupoSeleccionado.Text == "---")
            {
                validacion = false;

                ResponseMessage.Message("No existe grupo seleccionado", "INFORMATION");
                txtGrupo.Focus();

            }
            else if (cbxTalla.SelectedValue.ToString() == "000")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione una talla / Medida", "INFORMATION");
                txtGrupo.Focus();

            }
            else if (codigoColor == "000000" || codigoColor == "" || codigoColor == null)
            {
                validacion = false;

                ResponseMessage.Message("Seleccione un color", "INFORMATION");
                txtGrupo.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }



        private bool ValidarDatosGrupo()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtGrupo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese una descripción de Producto", "INFORMATION");
                txtGrupo.Focus();
            }
            else if (cbxNivel.SelectedValue.ToString() == "000")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione la Familia", "INFORMATION");
                cbxNivel.Focus();
            }
            else if (cbxUnidadMedida.SelectedValue.ToString() == "000")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione la unidad de medida", "INFORMATION");
                cbxNivel.Focus();
            }
            else if (lblCodCuenta.Text.Trim() == "")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione la cuenta contable por favor", "INFORMATION");
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }


        private void LimpiarGrupo()
        {
            txtCodGrupo.Text = "";
            txtGrupo.Text = "";
            txtCodProductoAlt.Text = "";
            txtCuenta.Text = "";
            lblCodCuenta.Text = "";

            dgvListadoGrupos.Rows.Clear();
        }

        private void ValoresPredeterminadoGrupo()
        {
            cbxNivel.SelectedValue = "00";
            cbxUnidadMedida.SelectedValue = "000";
        }

        public void LimpiarDetalle()
        {
            lblCodNivelSeleccionado.Text = "---";
            lblNivelSeleccionado.Text = "---";
            lblCodGrupoSeleccionado.Text = "---";
            lblGrupoSeleccionado.Text = "---";

            dgvListado.Rows.Clear();
        }

        private void ValoresDetallePredeterminados()
        {
            cbxTalla.SelectedValue = "000";
        }

        private void btnBuscarColor_Click(object sender, EventArgs e)
        {
            BuscarColorProductoView colorView = new BuscarColorProductoView();
            colorView.ShowDialog();

            codigoColor = colorView.codColor;
            lblColorDescripcion.Text = colorView.codColor + " - " + colorView.descripcion;

            btnGuardarDetalle.Focus();
        }



    }
}
