using SoftCotton.BusinessLogic;
using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Reports.PurchaseOrder.OrdenCompra;
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

namespace SoftCotton.Views.PurchaseOrder
{
    public partial class RegistroOCView : Form
    {
        OrdenCompraBL _ordenCompraBL;
        List<GetOC5_TipoAprobacion> listaTiposAprobaciones;
        List<GetOC6_TipoAnulado> listaTiposAnulaciones;
        GetOC15_FirmanteXNivel _firmanteInicial;
        GuiaRemisionBL _referralGuideBL;

        int ID_PrimerTipoAprobacion;
        string Nombre_PrimerTipoAprobacion;

        // test 
        ConstantesBL _constantesBL;
        List<Constantes> CONSTANTES;
        Constantes constanteIGV = new Constantes();

        public RegistroOCView()
        {
            InitializeComponent();

            _ordenCompraBL = new OrdenCompraBL();
            _firmanteInicial = new GetOC15_FirmanteXNivel();

            listaTiposAprobaciones = new List<GetOC5_TipoAprobacion>();
            listaTiposAnulaciones = new List<GetOC6_TipoAnulado>();

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

        private void RegistroOCView_Load(object sender, EventArgs e)
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

        private void dgvOCDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            EnumerarSecuencia();
        }

        private void dgvOCDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOCDetalle.CurrentRow != null)
            {

            }
        }

        private void dgvOCDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double output;

            if (dgvOCDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecCantidad"))
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out output) && dgvOCDetalle.Rows[e.RowIndex].Cells["dgvTxtCodTalla"].Value != null)
                {
                    ResponseMessage.Message("Ingresa la cantidad", "WARNING");
                    e.Cancel = true;
                }
            }
            else if (dgvOCDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDescPrecioUnitario"))
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out output) && dgvOCDetalle.Rows[e.RowIndex].Cells["dgvTxtCodTalla"].Value != null)
                {
                    ResponseMessage.Message("Ingresa el precio unitario", "WARNING");
                    e.Cancel = true;
                }
            }
        }

        private void dgvOCDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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

            if (dgvOCDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecCantidad") || dgvOCDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDescPrecioUnitario"))
            {
                decimal cantidad = dgvOCDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value == null ? 0 : Convert.ToDecimal(dgvOCDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value);
                decimal precioUnitario = dgvOCDetalle.Rows[e.RowIndex].Cells["dgvDescPrecioUnitario"].Value == null ? 0 : Convert.ToDecimal(dgvOCDetalle.Rows[e.RowIndex].Cells["dgvDescPrecioUnitario"].Value);

                dgvOCDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value = Math.Round(cantidad, 5);
                dgvOCDetalle.Rows[e.RowIndex].Cells["dgvDescPrecioUnitario"].Value = Math.Round(precioUnitario, 5);

                dgvOCDetalle.Rows[e.RowIndex].Cells["dgvTxtTotal"].Value = Math.Round((cantidad * precioUnitario), 5);

                CalcularMontosFinales();
            }
        }

        private void dgvOCDetalle_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            EnumerarSecuencia();
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void btnBuscarOC_Click(object sender, EventArgs e)
        {
            Limpiar();
            ValoresPredeterminados();

            txtCodigo.Text = "";
            txtCodigo.Enabled = true;
            txtCodigo.BackColor = Color.LightBlue;
            txtCodigo.Focus();
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

        



        // ### Funciones ###

        public void ObtenerFirmanteInicial(int idUsuario, int nivelAprobacion)
        {
            _firmanteInicial = _ordenCompraBL.Get15_FirmanteXNivel(idUsuario, nivelAprobacion);
        }


        public void ValoresPredeterminados()
        {
            int nivelAprobacion = listaTiposAprobaciones.Where(x => x.estado).Min(x => x.nivelAprobacion);
            ID_PrimerTipoAprobacion = Convert.ToInt32(listaTiposAprobaciones.Where(x => x.estado && x.nivelAprobacion == nivelAprobacion).First().idTipoAprobacion.ToString());

            var tipoAprobacion = listaTiposAprobaciones.Find(x => x.idTipoAprobacion == ID_PrimerTipoAprobacion);
            if (tipoAprobacion != null) { Nombre_PrimerTipoAprobacion = tipoAprobacion.descripcion; }

            this.dgvOCDetalle.Columns["dgvTxtItem"].ReadOnly = true;
            this.dgvOCDetalle.Columns["dgvTxtUM"].ReadOnly = true;
            this.dgvOCDetalle.Columns["dgvTxtTotal"].ReadOnly = true;

            cbxTiposAnulado.SelectedValue = listaTiposAnulaciones.Where(x => x.estado).Min(x => x.idTipoAnulado);

            cbxTipoMoneda.SelectedValue = 0;
            cbxTipoCompra.SelectedIndex = 0;
            cbxFormaPago.SelectedValue = 0;

            dtpFechaEmision.Value = DateTime.Now.Date;
            dtpFechaEntrega.Value = DateTime.Now.Date;
        }

        private void ListarTiposAprobaciones()
        {
            listaTiposAprobaciones = _ordenCompraBL.Get5_TipoAprobaciones();
        }

        private void ListarTiposAnulados()
        {
            listaTiposAnulaciones = _ordenCompraBL.Get6_TipoAnulados();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = listaTiposAnulaciones;

            cbxTiposAnulado.DisplayMember = "descripcion";
            cbxTiposAnulado.ValueMember = "idTipoAnulado";
            cbxTiposAnulado.DataSource = bindingSource.DataSource;

        }

        public void ListarTipoMonedaCBX()
        {
            List<GetOC1_TipoMoneda> cbxTipoMonedaList = _ordenCompraBL.Get1_TipoMoneda();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxTipoMonedaList;

            cbxTipoMoneda.DisplayMember = "moneda";
            cbxTipoMoneda.ValueMember = "idTipoMoneda";
            cbxTipoMoneda.DataSource = bindingSource.DataSource;
        }

        public void ListarFormaPagoCBX()
        {
            List<GetOC2_CondPago> cbxRelEmpresaList = _ordenCompraBL.Get2_CondicionPago();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxRelEmpresaList;

            cbxFormaPago.DisplayMember = "condicion";
            cbxFormaPago.ValueMember = "idCondPago";
            cbxFormaPago.DataSource = bindingSource.DataSource;
        }

        private void EnumerarSecuencia()
        {
            int secuencia = 1;

            foreach (DataGridViewRow row in dgvOCDetalle.Rows)
            {
                row.Cells["dgvTxtItem"].Value = secuencia;

                secuencia++;
            }
        }

        private void CalcularMontosFinales()
        {
            decimal subTotal = 0;

            foreach (DataGridViewRow row in dgvOCDetalle.Rows)
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
                SetOCParam oc = new SetOCParam();

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
                    oc.idOC = Convert.ToInt32(txtCodigo.Text);
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

                    oc.usuarioRegistro = UserApplication.USUARIO;

                    Procesar(oc);
                }
            }
        }


        public void Procesar(SetOCParam parametro)
        {
            Response responseGeneral = _ordenCompraBL.SetOC(parametro);

            if (responseGeneral.idResponse > 0)
            {
                // FIRMA : Validar si es insertar.
                if (parametro.opcion == 1)
                {
                    SetOCAprobacionParam parametroAprobacion = new SetOCAprobacionParam();

                    parametroAprobacion.opcion = 1;
                    parametroAprobacion.idEmpresa = 1; // CAMBIO EMPRESA AQUIIIIII
                    parametroAprobacion.idOC = responseGeneral.idResponse;
                    parametroAprobacion.idUsuario = _firmanteInicial.idUsuario;
                    parametroAprobacion.idTipoAprobacion = _firmanteInicial.idTipoAprobacion;
                    parametroAprobacion.nivelAprobacion = _firmanteInicial.nivelAprobacion;

                    Response respuestaFirma = _ordenCompraBL.SetOCAprobacion(parametroAprobacion);

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
            SetOCDetParam ocDetParam = null;
            bool estadoProceso = true;
            int contador = 1;

            foreach (DataGridViewRow row in dgvOCDetalle.Rows)
            {
                if (estadoProceso && (contador < dgvOCDetalle.Rows.Count))
                {
                    // Insertar si no existe, en todo caso actualizar.
                    ocDetParam = new SetOCDetParam();

                    ocDetParam.opcion = 1; // Insertar / Actualizar.
                    ocDetParam.idEmpresa = Empresa.ID_EMPRESA;
                    ocDetParam.idOC = idOC;

                    int v_secuencia = 0;
                    if (row.Cells["dgvTxtSecuenciaBD"].Value == null)
                    {
                        v_secuencia = 0;
                    }
                    else if (row.Cells["dgvTxtSecuenciaBD"].Value.ToString() == "")
                    {
                        v_secuencia = 0;
                    }
                    else
                    {
                        v_secuencia = Convert.ToInt32(row.Cells["dgvTxtSecuenciaBD"].Value);
                    }
                    ocDetParam.secuencia = v_secuencia;
                    

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


                    Response respuesta = _ordenCompraBL.SetOCDetalle(ocDetParam);

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

                dgvOCDetalle.Rows.Clear();
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
            else if (string.IsNullOrEmpty(txtCodPrograma.Text.Trim()))
            {
                respuesta = false;
                ResponseMessage.Message("Ingrese Programa por favor", "WARNING");
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

            foreach (DataGridViewRow row in dgvOCDetalle.Rows)
            {
                if (contador < dgvOCDetalle.Rows.Count)
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

            dgvOCDetalle.Rows.Clear();

            lblFirmante1.Text = "-";
            lblFirmante2.Text = "-";
            lblFirmante3.Text = "-";
        }

        private void BuscarOC(int idEmpresa, int codigoOC)
        {
            GetOC7_OCCabXCodigo ocCab = _ordenCompraBL.Get7_OCCabXCodigo(idEmpresa, codigoOC);

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

            txtCodPrograma.Text = ocCab.codPrograma.ToString();
            txtPrograma.Text = ocCab.nombrePrograma.ToString();

            lblUsuarioCreacion.Text = "Creado por: " + ocCab.usuCreacionReg;

            ListarFirmantes(Empresa.ID_EMPRESA, codigoOC);
            ListarDetalle(Empresa.ID_EMPRESA, codigoOC);
        }


        private void ListarDetalle(int idEmpresa, int codigoOC)
        {
            List<GetOC8_OCDetXCodigo> ocDets = _ordenCompraBL.Get8_OCDetXCodigo(idEmpresa, codigoOC);

            foreach (var item in ocDets)
            {
                int index = dgvOCDetalle.Rows.Add();

                dgvOCDetalle.Rows[index].Cells["dgvTxtSecuenciaBD"].Value = item.secuencia;

                dgvOCDetalle.Rows[index].Cells["dgvTxtCodNivel"].Value = item.codNivel;
                dgvOCDetalle.Rows[index].Cells["dgvTxtCodGrupo"].Value = item.codGrupo;
                dgvOCDetalle.Rows[index].Cells["dgvTxtCodTalla"].Value = item.codTalla;
                dgvOCDetalle.Rows[index].Cells["dgvTxtCodColor"].Value = item.codColor;
                dgvOCDetalle.Rows[index].Cells["dgvTxtProducto"].Value = item.producto;
                dgvOCDetalle.Rows[index].Cells["dgvDecCantidad"].Value = item.cantidad;
                dgvOCDetalle.Rows[index].Cells["dgvTxtUM"].Value = item.codUM;
                dgvOCDetalle.Rows[index].Cells["dgvDescPrecioUnitario"].Value = item.precioUnitario;
                dgvOCDetalle.Rows[index].Cells["dgvDecIGV"].Value = item.igv;

                dgvOCDetalle.Rows[index].Cells["dgvTxtObs1"].Value = item.obs1;
                dgvOCDetalle.Rows[index].Cells["dgvTxtObs2"].Value = item.obs2;
                dgvOCDetalle.Rows[index].Cells["dgvTxtObs3"].Value = item.obs3;
                dgvOCDetalle.Rows[index].Cells["dgvTxtObs4"].Value = item.obs4;
                dgvOCDetalle.Rows[index].Cells["dgvTxtObs5"].Value = item.obs5;

                dgvOCDetalle.Rows[index].Cells["dgvTxtTotal"].Value = Math.Round((item.cantidad * item.precioUnitario), 3);

            }
        }


        private void ListarFirmantes(int idEmpresa, int oc)
        {
            List<GetOC16_Firmantes> firmantes = _ordenCompraBL.Get16_Firmantes(idEmpresa, oc);
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
                dgvOCDetalle.Focus();
            }
        }



        #endregion

        private void txtObservacion_Leave(object sender, EventArgs e)
        {
            cbxTipoMoneda.Focus();
        }

        private void cbxFormaPago_Leave(object sender, EventArgs e)
        {
            dgvOCDetalle.Focus();
        }

        private void dgvOCDetalle_Leave(object sender, EventArgs e)
        {
            btnGuardar.Focus();
        }

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
                string vCodNivel = dgvOCDetalle.CurrentRow.Cells["dgvTxtCodNivel"].EditedFormattedValue.ToString();
                string vCodGrupo = dgvOCDetalle.CurrentRow.Cells["dgvTxtCodGrupo"].EditedFormattedValue.ToString();

                if (!string.IsNullOrEmpty(vCodNivel))
                {
                    if (!string.IsNullOrEmpty(vCodGrupo))
                    {
                        BuscarProductoView frmBuscarProductoView = new BuscarProductoView(vCodNivel, vCodGrupo);
                        frmBuscarProductoView.ShowDialog();

                        if (string.IsNullOrEmpty(frmBuscarProductoView.codTalla) || frmBuscarProductoView.codTalla == "")
                        {
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = "";
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtCodNivel"].Value = "";
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtCodGrupo"].Value = "";
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtCodTalla"].Value = "";
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtCodColor"].Value = "";
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtUM"].Value = "";
                            dgvOCDetalle.CurrentRow.Cells["dgvDecIGV"].Value = "";

                            dgvOCDetalle.CurrentCell = dgvOCDetalle.CurrentRow.Cells["dgvTxtCodGrupo"];
                        }
                        else
                        {
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = frmBuscarProductoView.productoServicio;
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtCodNivel"].Value = frmBuscarProductoView.codNivel;
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtCodGrupo"].Value = frmBuscarProductoView.codGrupo;
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtCodTalla"].Value = frmBuscarProductoView.codTalla;
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtCodColor"].Value = frmBuscarProductoView.codColor;
                            dgvOCDetalle.CurrentRow.Cells["dgvTxtUM"].Value = frmBuscarProductoView.codUM;
                            dgvOCDetalle.CurrentRow.Cells["dgvDecIGV"].Value = constanteIGV.valor;

                            PintarDataGridDetalle(dgvOCDetalle.CurrentRow.Index);

                            dgvOCDetalle.CurrentCell = dgvOCDetalle.CurrentRow.Cells["dgvDecCantidad"];
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
                if (dgvOCDetalle.CurrentRow != null)
                {
                    DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar el item seleccionado?");

                    if (resultadoMensaje == DialogResult.OK)
                    {
                        SetOCDetParam ocDetParam = new SetOCDetParam();

                        ocDetParam.opcion = 2; // Eliminar

                        ocDetParam.idEmpresa = Empresa.ID_EMPRESA;
                        ocDetParam.idOC = Convert.ToInt32(txtCodigo.Text.Trim());
                        ocDetParam.secuencia = Convert.ToInt32(dgvOCDetalle.CurrentRow.Cells["dgvTxtSecuenciaBD"].Value);
                        
                        Response respuesta = _ordenCompraBL.SetOCDetalle(ocDetParam);

                        if (respuesta.idResponse == 0)
                        {
                            ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);
                        }

                        dgvOCDetalle.Rows.Clear();

                        ListarDetalle(Empresa.ID_EMPRESA, Convert.ToInt32(txtCodigo.Text.Trim()));
                    }
                }
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                GuardarCambios();
            }


        }



        private void PintarDataGridDetalle(int rowIndex)
        {
            dgvOCDetalle.Rows[rowIndex].Cells["dgvTxtCodTalla"].Style.BackColor = Color.WhiteSmoke;
            dgvOCDetalle.Rows[rowIndex].Cells["dgvTxtCodColor"].Style.BackColor = Color.WhiteSmoke;
            dgvOCDetalle.Rows[rowIndex].Cells["dgvTxtProducto"].Style.BackColor = Color.WhiteSmoke;
            dgvOCDetalle.Rows[rowIndex].Cells["dgvTxtUM"].Style.BackColor = Color.WhiteSmoke;

            dgvOCDetalle.Rows[rowIndex].Cells["dgvTxtCodTalla"].ReadOnly = true;
            dgvOCDetalle.Rows[rowIndex].Cells["dgvTxtCodColor"].ReadOnly = true;
            dgvOCDetalle.Rows[rowIndex].Cells["dgvTxtProducto"].ReadOnly = true;
            dgvOCDetalle.Rows[rowIndex].Cells["dgvTxtUM"].ReadOnly = true;

        }

        private void dgvOCDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminarOC_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text.Trim()))
            {
                DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar la orden de compra N° " + txtCodigo.Text.Trim() + " ?");

                if (resultadoMensaje == DialogResult.OK)
                {
                    SetOCParam parametro = new SetOCParam();

                    parametro.opcion = 4;
                    parametro.idEmpresa = Empresa.ID_EMPRESA;
                    parametro.idOC = Convert.ToInt32(txtCodigo.Text);

                    Response responseGeneral = _ordenCompraBL.SetOC(parametro);

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

        private void btnBuscarPrograma_Click(object sender, EventArgs e)
        {
            BuscarProgramServiceView programaView = new BuscarProgramServiceView();
            programaView.tipoBusqueda = "P";
            programaView.ShowDialog();

            txtCodPrograma.Text = programaView.codigo;
            txtPrograma.Text = programaView.nombre;
        }


        // IMPRIMIR 
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                if (Convert.ToInt32(txtCodigo.Text) > 0)
                {
                    Cursor = Cursors.WaitCursor;

                    OrdenCompraRpteView ocPDF = new OrdenCompraRpteView(Convert.ToInt32(txtCodigo.Text));
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



        // IMPRIMIR VERSION 2
        private void btnImprimirV2_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                if (Convert.ToInt32(txtCodigo.Text) > 0)
                {
                    Cursor = Cursors.WaitCursor;

                    OrdenCompraRpteViewV2 ocPDF = new OrdenCompraRpteViewV2(Convert.ToInt32(txtCodigo.Text));
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
    }
}
