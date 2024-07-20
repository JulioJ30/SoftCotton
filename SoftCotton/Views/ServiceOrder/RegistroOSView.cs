using SoftCotton.BusinessLogic;
using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Model.ServiceOrder;
using SoftCotton.Reports.ServiceOrder.OrdenServicio;
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

namespace SoftCotton.Views.ServiceOrder
{
    public partial class RegistroOSView : Form
    {
        OrdenServicioBL _ordenServicioBL;
        List<GetOS5_TipoAprobacion> listaTiposAprobaciones;
        List<GetOS6_TipoAnulado> listaTiposAnulaciones;
        GetOS15_FirmanteXNivel _firmanteInicial;
        GuiaRemisionBL _referralGuideBL;

        int ID_PrimerTipoAprobacion;
        string Nombre_PrimerTipoAprobacion;

        // test 
        ConstantesBL _constantesBL;
        List<Constantes> CONSTANTES;
        Constantes constanteIGV = new Constantes();

        public RegistroOSView()
        {
            InitializeComponent();

            _ordenServicioBL = new OrdenServicioBL();
            _firmanteInicial = new GetOS15_FirmanteXNivel();

            listaTiposAprobaciones = new List<GetOS5_TipoAprobacion>();
            listaTiposAnulaciones = new List<GetOS6_TipoAnulado>();

            ID_PrimerTipoAprobacion = 0;
            Nombre_PrimerTipoAprobacion = "";

            // test
            _constantesBL = new ConstantesBL();
            CONSTANTES = new List<Constantes>();


            //UserApplication.ID_USUARIO = 9;
            //UserApplication.USUARIO = "ADMIN";
            //Empresa.ID_EMPRESA = 1;
            _referralGuideBL = new GuiaRemisionBL();
        }

        private void RegistroOSView_Load(object sender, EventArgs e)
        {
            ListarTiposAprobaciones();
            ListarTiposAnulados();
            ListarTipoMonedaCBX();
            ListarFormaPagoCBX();
            ObtenerFirmanteInicial(UserApplication.ID_USUARIO, 1); // PENDIENTE DE ID USUARIO

            txtCodigo.Text = "";
            txtCodigo.Enabled = false;
            txtCodigo.BackColor = Color.LightGreen;

            lblIdTipoAprobacion.Text = "0";
            lblTipoAprobacion.Text = "";

            ValoresPredeterminados();

            // test
            CONSTANTES = _constantesBL.Get1_Constantes();
            constanteIGV = CONSTANTES.Find(x => x.nombre == "IGV");


            txtCodigo.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ListarTiposAnulados();
            Limpiar();
            ValoresPredeterminados();

            txtCodigo.Text = "00000";
            txtCodigo.Enabled = false;
            txtCodigo.BackColor = Color.LightGreen;

            lblIdTipoAprobacion.Text = "0";
            lblTipoAprobacion.Text = "";

            dtpFechaEmision.Focus();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            BuscarProvClienteView provClienteView = new BuscarProvClienteView();
            provClienteView.ShowDialog();
            txtRUC.Text = provClienteView.codProvCliente;
            txtRS.Text = provClienteView.provCliente;
            txtDireccion.Text = provClienteView.direccion;

            txtObservacion.Focus();
        }

        private void btnBuscarOS_Click(object sender, EventArgs e)
        {
            Limpiar();
            ValoresPredeterminados();

            txtCodigo.Text = "";
            txtCodigo.Enabled = true;
            txtCodigo.BackColor = Color.LightBlue;
            txtCodigo.Focus();
        }

        private void btnEliminarOS_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text.Trim()))
            {
                DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar la orden de compra N° " + txtCodigo.Text.Trim() + " ?");

                if (resultadoMensaje == DialogResult.OK)
                {
                    SetOSParam parametro = new SetOSParam();

                    parametro.opcion = 4;
                    parametro.idEmpresa = Empresa.ID_EMPRESA;
                    parametro.idOS = Convert.ToInt32(txtCodigo.Text);

                    Response responseGeneral = _ordenServicioBL.SetOS(parametro);

                    if (responseGeneral.idResponse > 0)
                    {
                        Limpiar();
                    }

                    ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
                }
            }
            else
            {
                ResponseMessage.Message("Ingrese un código de OC válido.", "WARNING");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                if (Convert.ToInt32(txtCodigo.Text) > 0)
                {
                    Cursor = Cursors.WaitCursor;

                    OrdenServicioRpteView ocPDF = new OrdenServicioRpteView(Convert.ToInt32(txtCodigo.Text));
                    ocPDF.ShowDialog();
                    Cursor = Cursors.Default;
                }
                else
                {
                    ResponseMessage.Message("No existe orden de compra", "WARNING");
                }
            }
            else
            {
                ResponseMessage.Message("No existe orden de compra", "WARNING");
            }
        }

        private void dgvOSDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOSDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (cbxTipoMoneda.SelectedValue.ToString() == "0")
            {
                ResponseMessage.Message("Seleccione el tipo de moneda", "WARNING");
                cbxTipoMoneda.Focus();
            }
            else if (cbxTipoCompra.SelectedIndex == 0)
            {
                ResponseMessage.Message("Seleccione el tipo de Compra", "WARNING");
                cbxTipoCompra.Focus();
            }

            if (dgvOSDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecCantidad") || dgvOSDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDescPrecioUnitario"))
            {
                decimal cantidad = dgvOSDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value == null ? 0 : Convert.ToDecimal(dgvOSDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value);
                decimal precioUnitario = dgvOSDetalle.Rows[e.RowIndex].Cells["dgvDescPrecioUnitario"].Value == null ? 0 : Convert.ToDecimal(dgvOSDetalle.Rows[e.RowIndex].Cells["dgvDescPrecioUnitario"].Value);

                dgvOSDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value = Math.Round(cantidad, 5);
                dgvOSDetalle.Rows[e.RowIndex].Cells["dgvDescPrecioUnitario"].Value = Math.Round(precioUnitario, 5);

                dgvOSDetalle.Rows[e.RowIndex].Cells["dgvTxtTotal"].Value = Math.Round((cantidad * precioUnitario), 5);

                CalcularMontosFinales();
            }
        }

        private void dgvOSDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double output;

            if (dgvOSDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecCantidad"))
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out output) && dgvOSDetalle.Rows[e.RowIndex].Cells["dgvTxtCodTalla"].Value != null)
                {
                    ResponseMessage.Message("Ingresa la cantidad", "WARNING");
                    e.Cancel = true;
                }
            }
            else if (dgvOSDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDescPrecioUnitario"))
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out output) && dgvOSDetalle.Rows[e.RowIndex].Cells["dgvTxtCodTalla"].Value != null)
                {
                    ResponseMessage.Message("Ingresa el precio unitario", "WARNING");
                    e.Cancel = true;
                }
            }
        }

        private void dgvOSDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOSDetalle.CurrentRow != null)
            {

            }
        }

        private void dgvOSDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;

            tb.KeyDown -= dgvOCDetalle_KeyDown;
            tb.KeyDown += new KeyEventHandler(dgvOCDetalle_KeyDown);
        }

        private void dgvOSDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                string vCodNivel = dgvOSDetalle.CurrentRow.Cells["dgvTxtCodNivel"].EditedFormattedValue.ToString();
                string vCodGrupo = dgvOSDetalle.CurrentRow.Cells["dgvTxtCodGrupo"].EditedFormattedValue.ToString();

                if (!string.IsNullOrEmpty(vCodNivel))
                {
                    if (!string.IsNullOrEmpty(vCodGrupo))
                    {
                        BuscarProductoView frmBuscarProductoView = new BuscarProductoView(vCodNivel, vCodGrupo);
                        frmBuscarProductoView.ShowDialog();

                        if (string.IsNullOrEmpty(frmBuscarProductoView.codTalla) || frmBuscarProductoView.codTalla == "")
                        {
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodNivel"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodGrupo"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodTalla"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodColor"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtUM"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvDecIGV"].Value = "";

                            dgvOSDetalle.CurrentCell = dgvOSDetalle.CurrentRow.Cells["dgvTxtCodGrupo"];
                        }
                        else
                        {
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = frmBuscarProductoView.productoServicio;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodNivel"].Value = frmBuscarProductoView.codNivel;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodGrupo"].Value = frmBuscarProductoView.codGrupo;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodTalla"].Value = frmBuscarProductoView.codTalla;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodColor"].Value = frmBuscarProductoView.codColor;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtUM"].Value = frmBuscarProductoView.codUM;
                            dgvOSDetalle.CurrentRow.Cells["dgvDecIGV"].Value = constanteIGV.valor;

                            PintarDataGridDetalle(dgvOSDetalle.CurrentRow.Index);

                            dgvOSDetalle.CurrentCell = dgvOSDetalle.CurrentRow.Cells["dgvDecCantidad"];
                        }
                    }
                    else
                    {
                        ResponseMessage.Message("Ingrese el código de grupo del producto", "WARNING");
                    }
                }
                else
                {
                    ResponseMessage.Message("Ingrese el código de nivel del producto", "WARNING");
                }

            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                if (dgvOSDetalle.CurrentRow != null)
                {
                    DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar el item seleccionado?");

                    if (resultadoMensaje == DialogResult.OK)
                    {
                        SetOSDetParam osDetParam = new SetOSDetParam();

                        osDetParam.opcion = 2; // Eliminar

                        osDetParam.idEmpresa = Empresa.ID_EMPRESA;
                        osDetParam.idOS = Convert.ToInt32(txtCodigo.Text.Trim());
                        osDetParam.secuencia = Convert.ToInt32(dgvOSDetalle.CurrentRow.Cells["dgvTxtItem"].Value);

                        Response respuesta = _ordenServicioBL.SetOSDetalle(osDetParam);

                        if (respuesta.idResponse == 0)
                        {
                            ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);
                        }

                        dgvOSDetalle.Rows.Clear();

                        ListarDetalle(Empresa.ID_EMPRESA, Convert.ToInt32(txtCodigo.Text.Trim()));
                    }
                }
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                GuardarCambios();
            }

        }

       
        private void dgvOSDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            EnumerarSecuencia();
        }

        private void dgvOSDetalle_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            EnumerarSecuencia();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    if (!string.IsNullOrEmpty(txtCodigo.Text))
                    {
                        int oc = Convert.ToInt32(txtCodigo.Text);
                        Limpiar();
                        BuscarOC(Empresa.ID_EMPRESA, oc);
                    }
                    else
                    {
                        ResponseMessage.Message("Ingrese un código de Orden de compra", "INFORMATION");
                    }

                }
            }
        }




        // FUNCIONES

        public void ObtenerFirmanteInicial(int idUsuario, int nivelAprobacion)
        {
            _firmanteInicial = _ordenServicioBL.Get15_FirmanteXNivel(idUsuario, nivelAprobacion);
        }


        public void ValoresPredeterminados()
        {
            int nivelAprobacion = listaTiposAprobaciones.Where(x => x.estado).Min(x => x.nivelAprobacion);
            ID_PrimerTipoAprobacion = Convert.ToInt32(listaTiposAprobaciones.Where(x => x.estado && x.nivelAprobacion == nivelAprobacion).First().idTipoAprobacion.ToString());

            var tipoAprobacion = listaTiposAprobaciones.Find(x => x.idTipoAprobacion == ID_PrimerTipoAprobacion);
            if (tipoAprobacion != null) { Nombre_PrimerTipoAprobacion = tipoAprobacion.descripcion; }

            this.dgvOSDetalle.Columns["dgvTxtItem"].ReadOnly = true;
            this.dgvOSDetalle.Columns["dgvTxtUM"].ReadOnly = true;
            this.dgvOSDetalle.Columns["dgvTxtTotal"].ReadOnly = true;

            cbxTiposAnulado.SelectedValue = listaTiposAnulaciones.Where(x => x.estado).Min(x => x.idTipoAnulado);

            cbxTipoMoneda.SelectedValue = 0;
            cbxTipoCompra.SelectedIndex = 0;
            cbxFormaPago.SelectedValue = 0;

            dtpFechaEmision.Value = DateTime.Now.Date;
            dtpFechaEntrega.Value = DateTime.Now.Date;
        }

        private void ListarTiposAprobaciones()
        {
            listaTiposAprobaciones = _ordenServicioBL.Get5_TipoAprobaciones();
        }

        private void ListarTiposAnulados()
        {
            listaTiposAnulaciones = _ordenServicioBL.Get6_TipoAnulados();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = listaTiposAnulaciones;

            cbxTiposAnulado.DisplayMember = "descripcion";
            cbxTiposAnulado.ValueMember = "idTipoAnulado";
            cbxTiposAnulado.DataSource = bindingSource.DataSource;

        }

        public void ListarTipoMonedaCBX()
        {
            List<GetOC1_TipoMoneda> cbxTipoMonedaList = _ordenServicioBL.Get1_TipoMoneda();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxTipoMonedaList;

            cbxTipoMoneda.DisplayMember = "moneda";
            cbxTipoMoneda.ValueMember = "idTipoMoneda";
            cbxTipoMoneda.DataSource = bindingSource.DataSource;
        }

        public void ListarFormaPagoCBX()
        {
            List<GetOC2_CondPago> cbxRelEmpresaList = _ordenServicioBL.Get2_CondicionPago();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxRelEmpresaList;

            cbxFormaPago.DisplayMember = "condicion";
            cbxFormaPago.ValueMember = "idCondPago";
            cbxFormaPago.DataSource = bindingSource.DataSource;
        }

        private void EnumerarSecuencia()
        {
            int secuencia = 1;

            foreach (DataGridViewRow row in dgvOSDetalle.Rows)
            {
                row.Cells["dgvTxtItem"].Value = secuencia;

                secuencia++;
            }
        }

        private void CalcularMontosFinales()
        {
            decimal subTotal = 0;

            foreach (DataGridViewRow row in dgvOSDetalle.Rows)
            {
                if (row.Cells["dgvDecCantidad"].Value != null && row.Cells["dgvDescPrecioUnitario"].Value != null)
                {
                    subTotal += Convert.ToDecimal(row.Cells["dgvTxtTotal"].Value);
                }
            }

            if (cbxTipoCompra.SelectedIndex == 1)
            {
                // COMPRA NACIONAL
                lblSubTotal.Text = Math.Round(subTotal, 2).ToString("N5");
                lblIGV.Text = Math.Round((subTotal * (Convert.ToDecimal(constanteIGV.valor) / 100)), 2).ToString("N5");
                lblTotal.Text = (Convert.ToDecimal(lblSubTotal.Text) + Convert.ToDecimal(lblIGV.Text)).ToString("N5");

            }
            else if (cbxTipoCompra.SelectedIndex == 2)
            {
                // COMPRA IMPORTADO
                lblSubTotal.Text = Math.Round(subTotal, 3).ToString("N5");
                lblIGV.Text = "0.00000";
                lblTotal.Text = (Convert.ToDecimal(lblSubTotal.Text) + Convert.ToDecimal(lblIGV.Text)).ToString("N5");

            }
        }


        private void GuardarCambios()
        {
            bool procesarRegistro = false;
            int id_tipoAprobacion = 0;

            var fechaEmision = dtpFechaEmision.Value.ToString();
            var responseGeneral = _referralGuideBL.SetValidarPeriodo(fechaEmision);

            if (responseGeneral.idResponse == 1)
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
                return;
            }

            if (ValidarDatosCabecera() && ValidarDatosDetalle())
            {
                SetOSParam oc = new SetOSParam();

                if (Convert.ToInt32(txtCodigo.Text) == 0)
                {
                    // Insertar
                    oc.opcion = 1;
                    id_tipoAprobacion = Convert.ToInt32(ID_PrimerTipoAprobacion);

                    if (_firmanteInicial.idUsuario != 0)
                    {
                        procesarRegistro = true;
                    }
                    else
                    {
                        ResponseMessage.Message("El usuario no tiene permiso para aprobación de primera Firma", "WARNING");
                        procesarRegistro = false;
                    }

                }
                else
                {
                    // Actualizar
                    oc.opcion = 2;
                    id_tipoAprobacion = Convert.ToInt32(lblIdTipoAprobacion.Text);

                    procesarRegistro = true;
                }


                if (procesarRegistro)
                {
                    oc.idEmpresa = 1; // Empresa.ID_EMPRESA;
                    oc.idOS = Convert.ToInt32(txtCodigo.Text);
                    oc.fechaEmision = dtpFechaEmision.Value.ToString("yyyyMMdd");
                    oc.fechaEntrega = dtpFechaEntrega.Value.ToString("yyyyMMdd");
                    oc.codigoPC = txtRUC.Text;
                    oc.idTipoMoneda = Convert.ToInt32(cbxTipoMoneda.SelectedValue);

                    if (cbxTipoCompra.SelectedIndex == 1)
                    {
                        // NACIONAL
                        oc.tipoCompra = "N";
                    }
                    else if (cbxTipoCompra.SelectedIndex == 2)
                    {
                        // IMPORTADO
                        oc.tipoCompra = "I";
                    }

                    oc.idCondPago = Convert.ToInt32(cbxFormaPago.SelectedValue);

                    oc.idTipoAprobacion = id_tipoAprobacion;
                    oc.idTipoAnulado = Convert.ToInt32(cbxTiposAnulado.SelectedValue.ToString());
                    oc.fechaAnulado = new DateTime(1970, 1, 1).Date.ToString("yyyyMMdd");
                    oc.usuarioAnulado = "";
                    oc.observacion = txtObservacion.Text;
                    oc.CodPrograma = txtCodPrograma.Text;
                    oc.CodServicio = txtCodServicio.Text;

                    oc.usuarioRegistro = UserApplication.USUARIO;

                    Procesar(oc);
                }
            }
        }


        public void Procesar(SetOSParam parametro)
        {
            Response responseGeneral = _ordenServicioBL.SetOS(parametro);

            if (responseGeneral.idResponse > 0)
            {
                // FIRMA : Validar si es insertar.
                if (parametro.opcion == 1)
                {
                    SetOSAprobacionParam parametroAprobacion = new SetOSAprobacionParam();

                    parametroAprobacion.opcion = 1;
                    parametroAprobacion.idEmpresa = 1; // CAMBIO EMPRESA AQUIIIIII
                    parametroAprobacion.idOS = responseGeneral.idResponse;
                    parametroAprobacion.idUsuario = _firmanteInicial.idUsuario;
                    parametroAprobacion.idTipoAprobacion = _firmanteInicial.idTipoAprobacion;
                    parametroAprobacion.nivelAprobacion = _firmanteInicial.nivelAprobacion;

                    Response respuestaFirma = _ordenServicioBL.SetOSAprobacion(parametroAprobacion);

                    if (respuestaFirma.idResponse > 0)
                    {
                        ProcesarDetalle(Empresa.ID_EMPRESA, responseGeneral.idResponse, parametro.opcion, parametro.tipoCompra);
                    }
                    else
                    {
                        ResponseMessage.Message(respuestaFirma.messageResponse, respuestaFirma.typeMessage);
                    }
                }
                else
                {
                    ProcesarDetalle(Empresa.ID_EMPRESA, Convert.ToInt32(txtCodigo.Text), parametro.opcion, parametro.tipoCompra);
                }
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        private void ProcesarDetalle(int idEmpresa, int idOC, int opcion, string tipoCompra)
        {
            SetOSDetParam ocDetParam = null;
            bool estadoProceso = true;
            int contador = 1;

            foreach (DataGridViewRow row in dgvOSDetalle.Rows)
            {
                if (estadoProceso && (contador < dgvOSDetalle.Rows.Count))
                {
                    // Insertar si no existe, en todo caso actualizar.
                    ocDetParam = new SetOSDetParam();

                    ocDetParam.opcion = 1; // Insertar / Actualizar.
                    ocDetParam.idEmpresa = Empresa.ID_EMPRESA;
                    ocDetParam.idOS = idOC;
                    ocDetParam.secuencia = Convert.ToInt32(row.Cells["dgvTxtItem"].Value);

                    ocDetParam.codNivel = Convert.ToString(row.Cells["dgvTxtCodNivel"].Value);
                    ocDetParam.codGrupo = Convert.ToString(row.Cells["dgvTxtCodGrupo"].Value);
                    ocDetParam.codTalla = Convert.ToString(row.Cells["dgvTxtCodTalla"].Value);
                    ocDetParam.codColor = Convert.ToString(row.Cells["dgvTxtCodColor"].Value);
                    ocDetParam.cantidad = Convert.ToDecimal(row.Cells["dgvDecCantidad"].Value);

                    if (tipoCompra == "N")
                    {
                        ocDetParam.igv = Convert.ToDecimal(constanteIGV.valor);
                    }
                    else if (tipoCompra == "I")
                    {
                        ocDetParam.igv = 0;
                    }

                    ocDetParam.precioUnitario = Convert.ToDecimal(row.Cells["dgvDescPrecioUnitario"].Value);

                    if (row.Cells["dgvTxtObs1"].Value == null)
                    {
                        ocDetParam.obs1 = "";
                    }
                    else
                    {
                        ocDetParam.obs1 = row.Cells["dgvTxtObs1"].Value.ToString();
                    }


                    if (row.Cells["dgvTxtObs2"].Value == null)
                    {
                        ocDetParam.obs2 = "";
                    }
                    else
                    {
                        ocDetParam.obs2 = row.Cells["dgvTxtObs2"].Value.ToString();
                    }


                    if (row.Cells["dgvTxtObs3"].Value == null)
                    {
                        ocDetParam.obs3 = "";
                    }
                    else
                    {
                        ocDetParam.obs3 = row.Cells["dgvTxtObs3"].Value.ToString();
                    }


                    if (row.Cells["dgvTxtObs4"].Value == null)
                    {
                        ocDetParam.obs4 = "";
                    }
                    else
                    {
                        ocDetParam.obs4 = row.Cells["dgvTxtObs4"].Value.ToString();
                    }


                    if (row.Cells["dgvTxtObs5"].Value == null)
                    {
                        ocDetParam.obs5 = "";
                    }
                    else
                    {
                        ocDetParam.obs5 = row.Cells["dgvTxtObs5"].Value.ToString();
                    }


                    Response respuesta = _ordenServicioBL.SetOSDetalle(ocDetParam);

                    if (respuesta.idResponse == 0)
                    {
                        estadoProceso = false;
                        ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);
                    }
                }

                contador++;
            }

            if (estadoProceso)
            {
                txtCodigo.Text = idOC.ToString();
                txtCodigo.Enabled = false;
                txtCodigo.BackColor = Color.LightGreen;

                lblUsuarioCreacion.Text = "Creado por: " + UserApplication.USUARIO;
                ListarFirmantes(Empresa.ID_EMPRESA, Convert.ToInt32(txtCodigo.Text));

                if (opcion == 1)
                {
                    // Insertar
                    lblIdTipoAprobacion.Text = ID_PrimerTipoAprobacion.ToString();
                    lblTipoAprobacion.Text = Nombre_PrimerTipoAprobacion;
                }

                dgvOSDetalle.Rows.Clear();
                ListarDetalle(Empresa.ID_EMPRESA, Convert.ToInt32(txtCodigo.Text));
            }

        }


        private bool ValidarDatosCabecera()
        {
            bool respuesta = false;

            if (string.IsNullOrEmpty(txtRS.Text.Trim()))
            {
                respuesta = false;
                ResponseMessage.Message("No existe Razón Social", "WARNING");
            }
            else if (string.IsNullOrEmpty(txtRUC.Text.Trim()))
            {
                respuesta = false;
                ResponseMessage.Message("No número de RUC", "WARNING");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                respuesta = false;
                ResponseMessage.Message("No existe Dirección", "WARNING");
            }
            else if (cbxTipoMoneda.SelectedValue.ToString() == "0")
            {
                respuesta = false;
                ResponseMessage.Message("Seleccione el tipo de moneda", "WARNING");
            }
            else if (cbxTipoCompra.SelectedIndex == 0)
            {
                respuesta = false;
                ResponseMessage.Message("Seleccione el tipo de compra", "WARNING");
            }
            else if (cbxFormaPago.SelectedValue.ToString() == "0")
            {
                respuesta = false;
                ResponseMessage.Message("Seleccione la forma de pago", "WARNING");
            }
            else if (cbxTiposAnulado.SelectedValue == null)
            {
                respuesta = false;
                ResponseMessage.Message("No existe tipo de Anulado", "WARNING");
            }
            else
            {
                respuesta = true;
            }

            return respuesta;
        }

        private bool ValidarDatosDetalle()
        {
            bool respuesta = false;
            bool seguirValidando = true;
            int contador = 1;

            double output;

            foreach (DataGridViewRow row in dgvOSDetalle.Rows)
            {
                if (contador < dgvOSDetalle.Rows.Count)
                {
                    if (seguirValidando)
                    {
                        // 1. Validar Codigo de Producto
                        if (row.Cells["dgvTxtCodGrupo"].Value != null)
                        {
                            if (row.Cells["dgvTxtCodGrupo"].Value.ToString().Trim() == "")
                            {
                                respuesta = false;
                                seguirValidando = false;
                                ResponseMessage.Message("Ingrese un codigo de grupo", "WARNING");
                            }
                            else
                            {
                                respuesta = true;
                            }
                        }
                        else
                        {
                            respuesta = false;
                            seguirValidando = false;
                            ResponseMessage.Message("Ingrese un codigo de grupo", "WARNING");
                        }

                        // 2. Nombre de Producto
                        if (respuesta)
                        {
                            if (row.Cells["dgvTxtProducto"].Value != null)
                            {
                                if (row.Cells["dgvTxtProducto"].Value.ToString().Trim() == "")
                                {
                                    respuesta = false;
                                    seguirValidando = false;
                                    ResponseMessage.Message("Ingrese el nombre de producto", "WARNING");
                                }
                                else
                                {
                                    respuesta = true;
                                }
                            }
                            else
                            {
                                respuesta = false;
                                seguirValidando = false;
                                ResponseMessage.Message("Ingresa el nombre de producto", "WARNING");
                            }
                        }

                        // 3. Validar la cantidad 
                        if (respuesta)
                        {
                            if (row.Cells["dgvDecCantidad"].Value != null)
                            {
                                if (!double.TryParse(row.Cells["dgvDecCantidad"].Value.ToString(), out output))
                                {
                                    respuesta = false;
                                    seguirValidando = false;
                                    ResponseMessage.Message("Ingresa la cantidad", "WARNING");
                                }
                                else
                                {
                                    respuesta = true;
                                }
                            }
                            else
                            {
                                respuesta = false;
                                seguirValidando = false;
                                ResponseMessage.Message("Ingresa la cantidad", "WARNING");
                            }
                        }

                        // 4. Validar la Precio Unitario 
                        if (respuesta)
                        {
                            if (row.Cells["dgvDescPrecioUnitario"].Value != null)
                            {
                                if (!double.TryParse(row.Cells["dgvDescPrecioUnitario"].Value.ToString(), out output))
                                {
                                    respuesta = false;
                                    seguirValidando = false;
                                    ResponseMessage.Message("Ingresa el Precio Unitario", "WARNING");
                                }
                                else
                                {
                                    respuesta = true;
                                }
                            }
                            else
                            {
                                respuesta = false;
                                seguirValidando = false;
                                ResponseMessage.Message("Ingresa el Precio Unitario", "WARNING");
                            }
                        }

                    }
                }

                contador++;
            }

            return respuesta;
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            dtpFechaEmision.Value = DateTime.Now;
            dtpFechaEntrega.Value = DateTime.Now;
            txtRUC.Text = "";
            txtRS.Text = "";
            txtDireccion.Text = "";
            txtObservacion.Text = "";
            lblUsuarioCreacion.Text = "Creado por: -";

            txtCodPrograma.Text = "";
            txtPrograma.Text = "";

            txtCodServicio.Text = "";
            txtServicio.Text = "";

            dgvOSDetalle.Rows.Clear();

            lblFirmante1.Text = "-";
            lblFirmante2.Text = "-";
            lblFirmante3.Text = "-";
        }

        private void BuscarOC(int idEmpresa, int codigoOC)
        {
            GetOS7_OSCabXCodigo ocCab = _ordenServicioBL.Get7_OCCabXCodigo(idEmpresa, codigoOC);

            txtCodigo.Text = codigoOC.ToString();
            dtpFechaEmision.Value = Convert.ToDateTime(ocCab.fechaEmision).Date;
            dtpFechaEntrega.Value = Convert.ToDateTime(ocCab.fechaEntrega).Date;
            txtRUC.Text = ocCab.codigoPC.Trim();
            txtRS.Text = ocCab.razonSocial.Trim();
            txtDireccion.Text = ocCab.direccion.Trim();
            cbxTipoMoneda.SelectedValue = ocCab.idTipoMoneda;

            if (ocCab.tipoCompra == "N")
            {
                cbxTipoCompra.SelectedIndex = 1;
            }
            else if (ocCab.tipoCompra == "I")
            {
                cbxTipoCompra.SelectedIndex = 2;
            }

            cbxFormaPago.SelectedValue = ocCab.idCondPago;
            txtObservacion.Text = ocCab.observacion;
            lblIdTipoAprobacion.Text = ocCab.idTipoAprobacion.ToString();
            lblTipoAprobacion.Text = ocCab.tipoAprobacion.ToString();
            cbxTiposAnulado.SelectedValue = ocCab.idTipoAnulado;

            lblSubTotal.Text = ocCab.subTotal.ToString("N2");
            lblIGV.Text = ocCab.igv.ToString("N2");
            lblTotal.Text = ocCab.total.ToString("N2");

            txtCodServicio.Text = ocCab.codServicio.ToString();
            txtServicio.Text = ocCab.codServicio.ToString();

            txtCodPrograma.Text = ocCab.codPrograma.ToString();
            txtPrograma.Text = ocCab.nombrePrograma.ToString();

            lblUsuarioCreacion.Text = "Creado por: " + ocCab.usuCreacionReg;

            ListarFirmantes(Empresa.ID_EMPRESA, codigoOC);
            ListarDetalle(Empresa.ID_EMPRESA, codigoOC);
        }


        private void ListarDetalle(int idEmpresa, int codigoOC)
        {
            List<GetOS8_OSDetXCodigo> ocDets = _ordenServicioBL.Get8_OSDetXCodigo(idEmpresa, codigoOC);

            foreach (var item in ocDets)
            {
                int index = dgvOSDetalle.Rows.Add();

                dgvOSDetalle.Rows[index].Cells["dgvTxtItem"].Value = item.secuencia;
                dgvOSDetalle.Rows[index].Cells["dgvTxtCodNivel"].Value = item.codNivel;
                dgvOSDetalle.Rows[index].Cells["dgvTxtCodGrupo"].Value = item.codGrupo;
                dgvOSDetalle.Rows[index].Cells["dgvTxtCodTalla"].Value = item.codTalla;
                dgvOSDetalle.Rows[index].Cells["dgvTxtCodColor"].Value = item.codColor;
                dgvOSDetalle.Rows[index].Cells["dgvTxtProducto"].Value = item.producto;
                dgvOSDetalle.Rows[index].Cells["dgvDecCantidad"].Value = item.cantidad;
                dgvOSDetalle.Rows[index].Cells["dgvTxtUM"].Value = item.codUM;
                dgvOSDetalle.Rows[index].Cells["dgvDescPrecioUnitario"].Value = item.precioUnitario;
                dgvOSDetalle.Rows[index].Cells["dgvDecIGV"].Value = item.igv;

                dgvOSDetalle.Rows[index].Cells["dgvTxtObs1"].Value = item.obs1;
                dgvOSDetalle.Rows[index].Cells["dgvTxtObs2"].Value = item.obs2;
                dgvOSDetalle.Rows[index].Cells["dgvTxtObs3"].Value = item.obs3;
                dgvOSDetalle.Rows[index].Cells["dgvTxtObs4"].Value = item.obs4;
                dgvOSDetalle.Rows[index].Cells["dgvTxtObs5"].Value = item.obs5;

                dgvOSDetalle.Rows[index].Cells["dgvTxtTotal"].Value = Math.Round((item.cantidad * item.precioUnitario), 3);

            }
        }


        private void ListarFirmantes(int idEmpresa, int oc)
        {
            List<GetOS16_Firmantes> firmantes = _ordenServicioBL.Get16_Firmantes(idEmpresa, oc);
            int c = 1;

            foreach (var item in firmantes)
            {
                if (c == 1)
                {
                    lblFirmante1.Text = item.firmante + " - " + item.tipoAprobacion + "";
                }
                else if (c == 2)
                {
                    lblFirmante2.Text = item.firmante + " - " + item.tipoAprobacion + "";
                }
                else if (c == 3)
                {
                    lblFirmante3.Text = item.firmante + " - " + item.tipoAprobacion + "";
                }

                c++;
            }
        }

        #region Digitacion Rapida
        private void dtpFechaEmision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dtpFechaEntrega.Focus();
            }
        }
        private void dtpFechaEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnBuscarProveedor.Focus();
            }
        }
        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cbxTipoMoneda.Focus();
            }
        }
        private void cbxTipoMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cbxTipoCompra.Focus();
            }
        }
        private void cbxTipoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cbxFormaPago.Focus();
            }
        }
        private void cbxFormaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dgvOSDetalle.Focus();
            }
        }



        #endregion

       
        private void dgvOCDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;

            tb.KeyDown -= dgvOCDetalle_KeyDown;
            tb.KeyDown += new KeyEventHandler(dgvOCDetalle_KeyDown);
        }

        private void dgvOCDetalle_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.B)
            {
                string vCodNivel = dgvOSDetalle.CurrentRow.Cells["dgvTxtCodNivel"].EditedFormattedValue.ToString();
                string vCodGrupo = dgvOSDetalle.CurrentRow.Cells["dgvTxtCodGrupo"].EditedFormattedValue.ToString();

                if (!string.IsNullOrEmpty(vCodNivel))
                {
                    if (!string.IsNullOrEmpty(vCodGrupo))
                    {
                        BuscarProductoView frmBuscarProductoView = new BuscarProductoView(vCodNivel, vCodGrupo);
                        frmBuscarProductoView.ShowDialog();

                        if (string.IsNullOrEmpty(frmBuscarProductoView.codTalla) || frmBuscarProductoView.codTalla == "")
                        {
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodNivel"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodGrupo"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodTalla"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodColor"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtUM"].Value = "";
                            dgvOSDetalle.CurrentRow.Cells["dgvDecIGV"].Value = "";

                            dgvOSDetalle.CurrentCell = dgvOSDetalle.CurrentRow.Cells["dgvTxtCodGrupo"];
                        }
                        else
                        {
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = frmBuscarProductoView.productoServicio;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodNivel"].Value = frmBuscarProductoView.codNivel;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodGrupo"].Value = frmBuscarProductoView.codGrupo;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodTalla"].Value = frmBuscarProductoView.codTalla;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtCodColor"].Value = frmBuscarProductoView.codColor;
                            dgvOSDetalle.CurrentRow.Cells["dgvTxtUM"].Value = frmBuscarProductoView.codUM;
                            dgvOSDetalle.CurrentRow.Cells["dgvDecIGV"].Value = constanteIGV.valor;

                            PintarDataGridDetalle(dgvOSDetalle.CurrentRow.Index);

                            dgvOSDetalle.CurrentCell = dgvOSDetalle.CurrentRow.Cells["dgvDecCantidad"];
                        }
                    }
                    else
                    {
                        ResponseMessage.Message("Ingrese el código de grupo del producto", "WARNING");
                    }
                }
                else
                {
                    ResponseMessage.Message("Ingrese el código de nivel del producto", "WARNING");
                }

            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                if (dgvOSDetalle.CurrentRow != null)
                {
                    DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar el item seleccionado?");

                    if (resultadoMensaje == DialogResult.OK)
                    {
                        SetOSDetParam ocDetParam = new SetOSDetParam();

                        ocDetParam.opcion = 2; // Eliminar

                        ocDetParam.idEmpresa = Empresa.ID_EMPRESA;
                        ocDetParam.idOS = Convert.ToInt32(txtCodigo.Text.Trim());
                        ocDetParam.secuencia = Convert.ToInt32(dgvOSDetalle.CurrentRow.Cells["dgvTxtItem"].Value);

                        Response respuesta = _ordenServicioBL.SetOSDetalle(ocDetParam);

                        if (respuesta.idResponse == 0)
                        {
                            ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);
                        }

                        dgvOSDetalle.Rows.Clear();

                        ListarDetalle(Empresa.ID_EMPRESA, Convert.ToInt32(txtCodigo.Text.Trim()));
                    }
                }
            }



        }



        private void PintarDataGridDetalle(int rowIndex)
        {
            dgvOSDetalle.Rows[rowIndex].Cells["dgvTxtCodTalla"].Style.BackColor = Color.WhiteSmoke;
            dgvOSDetalle.Rows[rowIndex].Cells["dgvTxtCodColor"].Style.BackColor = Color.WhiteSmoke;
            dgvOSDetalle.Rows[rowIndex].Cells["dgvTxtProducto"].Style.BackColor = Color.WhiteSmoke;
            dgvOSDetalle.Rows[rowIndex].Cells["dgvTxtUM"].Style.BackColor = Color.WhiteSmoke;

            dgvOSDetalle.Rows[rowIndex].Cells["dgvTxtCodTalla"].ReadOnly = true;
            dgvOSDetalle.Rows[rowIndex].Cells["dgvTxtCodColor"].ReadOnly = true;
            dgvOSDetalle.Rows[rowIndex].Cells["dgvTxtProducto"].ReadOnly = true;
            dgvOSDetalle.Rows[rowIndex].Cells["dgvTxtUM"].ReadOnly = true;

        }

        private void cbxTipoCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoCompra.SelectedIndex != 0)
            {
                CalcularMontosFinales();
            }
            else
            {
                lblSubTotal.Text = "0.00000";
                lblIGV.Text = "0.00000";
                lblTotal.Text = "0.00000";
            }
        }

        private void txtObservacion_Leave(object sender, EventArgs e)
        {
            cbxTipoMoneda.Focus();
        }

        private void cbxFormaPago_Leave(object sender, EventArgs e)
        {
            dgvOSDetalle.Focus();
        }

        private void dgvOSDetalle_Leave(object sender, EventArgs e)
        {
            btnGuardar.Focus();
        }

        private void btnBuscarPrograma_Click(object sender, EventArgs e)
        {
            BuscarProgramServiceView programaView = new BuscarProgramServiceView();
            programaView.tipoBusqueda = "P";
            programaView.ShowDialog();

            txtCodPrograma.Text = programaView.codigo;
            txtPrograma.Text = programaView.nombre;
        }

        private void btnBuscarServicio_Click(object sender, EventArgs e)
        {
            BuscarProgramServiceView programaView = new BuscarProgramServiceView();
            programaView.tipoBusqueda = "S";
            programaView.ShowDialog();

            txtCodServicio.Text = programaView.codigo;
            txtServicio.Text = programaView.nombre;
        }
    }
}
