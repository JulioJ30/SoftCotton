using SoftCotton.BusinessLogic;
using SoftCotton.Model.Invoices;
using SoftCotton.Util;
using SoftCotton.Views.Shared;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
using SoftCotton.Model.Maintenance;
using System.Data;
//using SoftCotton.Util;

namespace SoftCotton.Views.Invoices
{
    public partial class RegistroFacturasView : Form
    {
        FacturaBL _facturaBL;
        //MantenimientoBL _mantenimientoBL;
        CompartidoBL _compartidoBL;
        MantenimientoBL _mantenimientoBL;


        SetFacCabParam _facCabParam;
        SetFacDetParam _facDetParam;
        DataTable tblTiposCambios;


        ConstantesBL _constantesBL;
        List<Constantes> CONSTANTES;
        Constantes constanteIGV = new Constantes();
        decimal TipoCambio = 0;
        decimal TipoCambioModificado = 0;


        public RegistroFacturasView()
        {
            InitializeComponent();

            _facturaBL = new FacturaBL();
            _compartidoBL = new CompartidoBL();
            _mantenimientoBL = new MantenimientoBL();

            _constantesBL = new ConstantesBL();
            CONSTANTES = new List<Constantes>();
            CONSTANTES = _constantesBL.Get1_Constantes();
            constanteIGV = CONSTANTES.Find(x => x.nombre == "IGV");


        }

        private void RegistroFacturasView_Load(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                ListarTiposMonedas();
                ValoresPredeterminados();
                ListarTipoComprobantes();
                txtSerie.Focus();


                cbTipoCambio.Enabled = UserApplication.USUARIO == "ADMIN" ? true : false;
                //cboTipoComprobante.SelectedValue = "01";
            }
            catch (Exception ex)
            {

            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            ValoresPredeterminados();
            txtSerie.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar("01");
        }

        private void Buscar(string tipoComprobante = "01")
        {
            if (!string.IsNullOrEmpty(lblRUC.Text.Trim()) &&
                !string.IsNullOrEmpty(txtSerie.Text.Trim()) &&
                !string.IsNullOrEmpty(txtNumero.Text.Trim()))
            {


                //GetFact3_Cabecera factCab = _facturaBL.Get3_Cabecera(Empresa.ID_EMPRESA, txtSerie.Text.Trim(), txtNumero.Text.Trim(), lblRUC.Text.Trim(),cboTipoComprobante.SelectedValue.ToString());
                string tipoComprobanteFiltro = cboTipoComprobante.SelectedValue.ToString() != "" ? cboTipoComprobante.SelectedValue.ToString() : tipoComprobante;
                GetFact3_Cabecera factCab = _facturaBL.Get3_Cabecera(Empresa.ID_EMPRESA, txtSerie.Text.Trim(), txtNumero.Text.Trim(), lblRUC.Text.Trim(), tipoComprobanteFiltro);


                if (factCab.idEmpresa == 0 &&
                    factCab.serie.Trim() == "" &&
                    factCab.numero == 0)
                {
                    TipoCambio = 0;
                    ResponseMessage.Message("La factura no existe", "WARNING");
                }
                else
                {
                    TipoCambio = factCab.tipoCambio;
                    txtSerie.Text = factCab.serie;
                    txtNumero.Text = factCab.numero.ToString();
                    dtpFechaEmision.Value = Convert.ToDateTime(factCab.fechaEmision).Date;
                    lblRUC.Text = factCab.codigoPC;
                    lblRS.Text = factCab.razonSocial;

                    //cbxTipoMoneda.SelectedValue = factCab.idTipoMoneda;
                    GetTipoCambio(factCab.idTipoMoneda);
                    cboTipoComprobante.SelectedValue = factCab.codTipoCpte;
                    cbTipoCambio.SelectedValue = factCab.tipoCambio.ToString();

                    txtAnio.Text = factCab.anio.ToString();
                    txtMes.Text = factCab.mes.ToString();
                    //txtContabilizado.Text = factCab.contabilizado;



                    ListarDetalle(Empresa.ID_EMPRESA, factCab.serie, factCab.numero, factCab.codigoPC, factCab.codTipoCpte);
                }
            }
            else
            {
                ResponseMessage.Message("Ingrese RUC, serie y número de factura valido para busqueda", "WARNING");
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            BuscarProvClienteView provClienteView = new BuscarProvClienteView();

            provClienteView.ShowDialog();
            lblRUC.Text = provClienteView.codProvCliente;
            lblRS.Text = provClienteView.provCliente;

            txtSerie.Focus();
        }

        private void dgvListadoDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            EnumerarSecuencia();
        }

        private void dgvListadoDetalle_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            EnumerarSecuencia();
        }


        // Funciones 

        private void ListarTiposMonedas()
        {
            List<GetFact2_TipoMoneda> listaTipoMonedas = _facturaBL.Get2_TipoMoneda();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = listaTipoMonedas;

            cbxTipoMoneda.DisplayMember = "moneda";
            cbxTipoMoneda.ValueMember = "idTipoMoneda";
            cbxTipoMoneda.DataSource = bindingSource.DataSource;

        }

        // LISTAR TIPO COMPROBANTES
        private void ListarTipoComprobantes()
        {

            List<GetMant8_TipoCpte> listaTipoComprobantes = _mantenimientoBL.GetMant8_TipoDoc();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = listaTipoComprobantes;

            cboTipoComprobante.DisplayMember = "tipoComprobante";
            cboTipoComprobante.ValueMember = "codTipoCpte";
            cboTipoComprobante.DataSource = bindingSource.DataSource;

            //List<GetMant8_TipoCpte> GetMant8_TipoDoc()
        }

        private void GuardarCambios()
        {
            if (ValidarDatosCabecera() && ValidarDatosDetalle())
            {
                _facCabParam = new SetFacCabParam();

                // Insertar / Actualizar
                _facCabParam.opcion = 1;

                _facCabParam.idEmpresa = Empresa.ID_EMPRESA;
                _facCabParam.serie = txtSerie.Text.Trim();
                _facCabParam.numero = Convert.ToInt32(txtNumero.Text.Trim());
                _facCabParam.fechaEmision = dtpFechaEmision.Value.ToString("yyyyMMdd");
                _facCabParam.codigoPC = lblRUC.Text.Trim();
                _facCabParam.idTipoMoneda = Convert.ToInt32(cbxTipoMoneda.SelectedValue.ToString());
                _facCabParam.usuarioReg = UserApplication.USUARIO;

                _facCabParam.tipoCambio = Convert.ToDecimal(cbTipoCambio.SelectedValue.ToString());
                _facCabParam.mes = Convert.ToInt32(txtMes.Text.Trim());
                _facCabParam.anio = Convert.ToInt32(txtAnio.Text.Trim());
                //_facCabParam.contabilizado = txtContabilizado.Text.Trim();


                // AGREGADO
                string tipoComprobante = cboTipoComprobante.SelectedValue.ToString();
                _facCabParam.codTipoCpte = tipoComprobante;
                if (tipoComprobante == "07")
                {
                    _facCabParam.serieNotaCredito = txtSerieNotaCredito.Text.Trim();
                    _facCabParam.numeroNotaCredito = txtNumeroNotaCredito.Text.Trim();
                    _facCabParam.observacionNotaCredito = txtObservaciones.Text.Trim();
                }
                else
                {
                    _facCabParam.serieNotaCredito = "0";
                    _facCabParam.numeroNotaCredito = "0";
                    _facCabParam.observacionNotaCredito = "";
                }

                Procesar(_facCabParam);

            }
        }


        public void Procesar(SetFacCabParam parametro)
        {
            Response responseGeneral = _facturaBL.SetFacCab(parametro);

            if (responseGeneral.idResponse > 0)
            {
                ProcesarDetalle(Empresa.ID_EMPRESA, parametro.serie, parametro.numero, parametro.codigoPC, parametro.serieNotaCredito, parametro.numeroNotaCredito, parametro.codTipoCpte);
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }


        private void ProcesarDetalle(int idEmpresa, string serie, int numero, string ruc, string serieNotaCredito, string numeroNotaCredito, string tipocomprobante)
        {
            Response respuestaDetalle = new Response();
            bool estadoProceso = true;
            int contador = 1;

            foreach (DataGridViewRow row in dgvListadoDetalle.Rows)
            {
                if (estadoProceso && (contador < dgvListadoDetalle.Rows.Count))
                {
                    // Insertar si no existe, en todo caso actualizar.
                    _facDetParam = new SetFacDetParam();

                    _facDetParam.opcion = 1; // Insertar / Actualizar.

                    _facDetParam.idEmpresa = Empresa.ID_EMPRESA;
                    _facDetParam.serie = serie;
                    _facDetParam.numero = numero;
                    _facDetParam.secuencia = Convert.ToInt32(row.Cells["dgvTxtSecuenciaBD"].Value);

                    // AGREGADO NOTA CREDITO
                    _facDetParam.serieNotaCredito = serieNotaCredito;
                    _facDetParam.numeroNotaCredito = numeroNotaCredito;
                    _facDetParam.codTipoCpte = tipocomprobante;


                    //if (tipocomprobante == "07")
                    //{
                    //    _facDetParam.cantidadNotaCredito = string.IsNullOrEmpty(row.Cells["cantidadNotaCredito"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["cantidadNotaCredito"].Value);

                    //}
                    //else
                    //{
                    //    _facDetParam.cantidadNotaCredito = 0;

                    //}



                    if (row.Cells["dgvTxtGRIdEmpresa"].Value == null)
                    {
                        _facDetParam.grIdEmpresa = 0;
                    }
                    else
                    {
                        _facDetParam.grIdEmpresa = Convert.ToInt32(row.Cells["dgvTxtGRIdEmpresa"].Value);
                    }

                    if (row.Cells["dgvTxtGRSerie"].Value == null)
                    {
                        _facDetParam.grSerie = "";
                    }
                    else
                    {
                        _facDetParam.grSerie = row.Cells["dgvTxtGRSerie"].Value.ToString();
                    }

                    if (row.Cells["dgvTxtGRNumero"].Value == null)
                    {
                        _facDetParam.grNumero = "";
                    }
                    else
                    {
                        _facDetParam.grNumero = row.Cells["dgvTxtGRNumero"].Value.ToString();
                    }

                    if (row.Cells["dgvTxtGRSecuencia"].Value == null)
                    {
                        _facDetParam.grSecuencia = 0;
                    }
                    else
                    {
                        _facDetParam.grSecuencia = Convert.ToInt32(row.Cells["dgvTxtGRSecuencia"].Value);
                    }

                    _facDetParam.grTipoOrden = string.IsNullOrEmpty(row.Cells["dgvTxtGRTipoOrden"].Value.ToString()) ? "" : row.Cells["dgvTxtGRTipoOrden"].Value.ToString();

                    _facDetParam.codigo = string.IsNullOrEmpty(row.Cells["dgvTxtCodigo"].Value.ToString()) ? "" : row.Cells["dgvTxtCodigo"].Value.ToString();
                    _facDetParam.descripcion = string.IsNullOrEmpty(row.Cells["dgvTxtDescripcion"].Value.ToString()) ? "" : row.Cells["dgvTxtDescripcion"].Value.ToString();
                    _facDetParam.codUM = string.IsNullOrEmpty(row.Cells["dgvTxtCodUM"].Value.ToString()) ? "" : row.Cells["dgvTxtCodUM"].Value.ToString();

                    _facDetParam.igv = string.IsNullOrEmpty(row.Cells["dgvDecIGV"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["dgvDecIGV"].Value);

                    _facDetParam.cantidad = string.IsNullOrEmpty(row.Cells["dgvDecCantidad"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["dgvDecCantidad"].Value);
                    _facDetParam.precioUnitario = string.IsNullOrEmpty(row.Cells["dgvDecPrecioUnitario"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["dgvDecPrecioUnitario"].Value);

                    _facDetParam.codigoPC = ruc;

                    respuestaDetalle = _facturaBL.SetFacDet(_facDetParam);

                    if (respuestaDetalle.idResponse == 0)
                    {
                        estadoProceso = false;
                        ResponseMessage.Message(respuestaDetalle.messageResponse, respuestaDetalle.typeMessage);
                    }
                }

                contador++;
            }


            if (estadoProceso)
            {
                ResponseMessage.Message(respuestaDetalle.messageResponse, "INFORMATION");
            }

            dgvListadoDetalle.Rows.Clear();
            ListarDetalle(Empresa.ID_EMPRESA, _facCabParam.serie, _facCabParam.numero, _facCabParam.codigoPC, _facCabParam.codTipoCpte);
        }


        private void ListarDetalle(int idEmpresa, string serie, int numero, string ruc, string tipoComprobante)
        {
            List<GetFact1_Detalle> grDets = _facturaBL.Get1_Detalle(idEmpresa, serie, numero, ruc, tipoComprobante);

            dgvListadoDetalle.Rows.Clear();

            foreach (var item in grDets)
            {
                int index = dgvListadoDetalle.Rows.Add();

                dgvListadoDetalle.Rows[index].Cells["dgvTxtItem"].Value = item.secuencia;

                dgvListadoDetalle.Rows[index].Cells["dgvTxtSerie"].Value = item.serie;
                dgvListadoDetalle.Rows[index].Cells["dgvTxtNumero"].Value = item.numero;
                dgvListadoDetalle.Rows[index].Cells["dgvTxtRUC"].Value = item.codigoPC;
                dgvListadoDetalle.Rows[index].Cells["dgvTxtSecuenciaBD"].Value = item.secuencia;


                dgvListadoDetalle.Rows[index].Cells["dgvTxtGRIdEmpresa"].Value = item.grIdEmpresa;
                dgvListadoDetalle.Rows[index].Cells["dgvTxtGRSerie"].Value = item.grSerie;
                dgvListadoDetalle.Rows[index].Cells["dgvTxtGRNumero"].Value = item.grNumero;
                dgvListadoDetalle.Rows[index].Cells["dgvTxtGRSecuencia"].Value = item.grSecuencia;
                dgvListadoDetalle.Rows[index].Cells["dgvTxtGRTipoOrden"].Value = item.grTipoOrden;

                dgvListadoDetalle.Rows[index].Cells["dgvTxtCodigo"].Value = item.codigo;
                dgvListadoDetalle.Rows[index].Cells["dgvTxtDescripcion"].Value = item.descripcion;
                dgvListadoDetalle.Rows[index].Cells["dgvTxtCodUM"].Value = item.codUM;
                dgvListadoDetalle.Rows[index].Cells["dgvDecCantidad"].Value = item.cantidad;

                //dgvListadoDetalle.Rows[index].Cells["cantidadNotaCredito"].Value = item.cantidadNotaCredito;

                dgvListadoDetalle.Rows[index].Cells["dgvDecPrecioUnitario"].Value = item.precioUnitario;
                dgvListadoDetalle.Rows[index].Cells["dgvDecIGV"].Value = item.igv;

                PintarDataGridDetalle(index, false);
            }

            CalcularMontosFinales();

            dgvListadoDetalle.AutoResizeColumns();
            dgvListadoDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }


        private bool ValidarDatosCabecera()
        {
            bool respuesta = true;
            string messtring = txtMes.Text.Trim();
            string aniostring = txtAnio.Text.Trim();

            string tipoComprobante = cboTipoComprobante.SelectedValue.ToString();


            if (string.IsNullOrEmpty(txtSerie.Text.Trim()))
            {
                respuesta = false;
                ResponseMessage.Message("Ingrese la serie de documento", "WARNING");
            }
            else if (string.IsNullOrEmpty(txtNumero.Text.Trim()))
            {
                respuesta = false;
                ResponseMessage.Message("Ingrese el numero de documento", "WARNING");
            }
            else if (string.IsNullOrEmpty(lblRUC.Text.Trim()))
            {
                respuesta = false;
                ResponseMessage.Message("Ingrese RUC de Destinatario", "WARNING");
            }
            else if (string.IsNullOrEmpty(lblRS.Text.Trim()))
            {
                respuesta = false;
                ResponseMessage.Message("Ingrese la Marca", "WARNING");
            }
            else if (cbxTipoMoneda.SelectedIndex == 0)
            {
                respuesta = false;
                ResponseMessage.Message("Seleccionar Tipo de Moneda", "WARNING");
            }
            else if (dgvListadoDetalle.Rows.Count == 0)
            {
                respuesta = false;
                ResponseMessage.Message("La Guía de Remisión no tiene detalle", "WARNING");
            }
            else if (messtring != string.Empty)
            {
                int mesnumerico = 0;
                if (!int.TryParse(messtring, out mesnumerico))
                {
                    respuesta = false;
                    ResponseMessage.Message("Ingresa un mes correcto", "WARNING");
                }
                else
                {
                    if (Convert.ToInt32(mesnumerico) > 12)
                    {
                        respuesta = false;
                        ResponseMessage.Message("Los meses deben ser menores a 12", "WARNING");
                    }
                }

            }
            else if (aniostring != string.Empty)
            {
                int anionumerico = 0;
                if (!int.TryParse(aniostring, out anionumerico))
                {
                    respuesta = false;
                    ResponseMessage.Message("Ingresa un año correcto", "WARNING");
                }
                else
                {

                    if (Convert.ToInt32(anionumerico) < 1900)
                    {
                        respuesta = false;
                        ResponseMessage.Message("El año no puede ser menor que 1900", "WARNING");
                    }

                    if (Convert.ToInt32(anionumerico) > 3000)
                    {
                        respuesta = false;
                        ResponseMessage.Message("El año no puede ser menor que 3000", "WARNING");
                    }
                }

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

            foreach (DataGridViewRow row in dgvListadoDetalle.Rows)
            {
                if (contador < dgvListadoDetalle.Rows.Count)
                {
                    if (seguirValidando)
                    {
                        // 1. Serie de Factura
                        if (row.Cells["dgvTxtCodigo"].Value != null)
                        {
                            if (row.Cells["dgvTxtCodigo"].Value.ToString().Trim() == "")
                            {
                                respuesta = false;
                                seguirValidando = false;
                                ResponseMessage.Message("Ingrese un código", "WARNING");
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
                            ResponseMessage.Message("Ingrese un código", "WARNING");
                        }

                        // 2. Número de Factura
                        if (respuesta)
                        {
                            if (row.Cells["dgvTxtDescripcion"].Value != null)
                            {
                                if (row.Cells["dgvTxtDescripcion"].Value.ToString().Trim() == "")
                                {
                                    respuesta = false;
                                    seguirValidando = false;
                                    ResponseMessage.Message("Ingrese la descripción de detalle", "WARNING");
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
                                ResponseMessage.Message("Ingrese la descripción de detalle", "WARNING");
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
                                    ResponseMessage.Message("Ingresa la cantidad en el detalle", "WARNING");
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
                                ResponseMessage.Message("Ingresa la cantidad en el detalle", "WARNING");
                            }
                        }

                        // 4. Validar la Precio Unitario 
                        if (respuesta)
                        {
                            if (row.Cells["dgvTxtCodUM"].Value != null)
                            {
                                if (row.Cells["dgvTxtCodUM"].Value.ToString().Trim() == "")
                                {
                                    respuesta = false;
                                    seguirValidando = false;
                                    ResponseMessage.Message("Ingrese la unidad de medida en el detalle", "WARNING");
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
                                ResponseMessage.Message("Ingrese la unidad de medida en el detalle", "WARNING");
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
            txtSerie.Text = "";
            txtNumero.Text = "";
            lblRUC.Text = "";
            lblRS.Text = "";

            dgvListadoDetalle.Rows.Clear();
        }

        private void ValoresPredeterminados()
        {
            dtpFechaEmision.Value = DateTime.Now.Date;
            cbxTipoMoneda.SelectedValue = 0;
        }

        private void EnumerarSecuencia()
        {
            int secuencia = 1;

            foreach (DataGridViewRow row in dgvListadoDetalle.Rows)
            {
                row.Cells["dgvTxtItem"].Value = secuencia;

                secuencia++;
            }
        }



        private void dgvListadoDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType().FullName == "System.Windows.Forms.DataGridViewTextBoxEditingControl")
            {
                // TextBox
                DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;

                tb.KeyDown -= dgvListadoDetalle_KeyDown;
                tb.KeyDown += new KeyEventHandler(dgvListadoDetalle_KeyDown);
            }
        }

        private void dgvListadoDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                string serie = dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRSerie"].EditedFormattedValue.ToString();
                string numero = dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRNumero"].EditedFormattedValue.ToString();

                if (!string.IsNullOrEmpty(serie) && !string.IsNullOrEmpty(numero))
                {

                    if (!string.IsNullOrEmpty(lblRUC.Text.Trim()) &&
                        !string.IsNullOrEmpty(txtSerie.Text.Trim()) &&
                        !string.IsNullOrEmpty(txtNumero.Text.Trim()))
                    {
                        BuscarGuiaRemisionView ocView = new BuscarGuiaRemisionView(Empresa.ID_EMPRESA, serie, numero);

                        ocView.ShowDialog();

                        if (ocView.Serie == "")
                        {
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRSerie"].Value = "";

                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtSerie"].Value = txtSerie.Text.Trim();
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtNumero"].Value = txtNumero.Text.Trim();
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtRUC"].Value = lblRUC.Text.Trim();

                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRIdEmpresa"].Value = 0;
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRSerie"].Value = "";
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRSerie"].Value = "";
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRSecuencia"].Value = "";
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRTipoOrden"].Value = "";

                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtCodigo"].Value = "";
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtDescripcion"].Value = 0;
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtCodUM"].Value = 0;

                            dgvListadoDetalle.CurrentRow.Cells["dgvDecCantidad"].Value = 0;
                            dgvListadoDetalle.CurrentRow.Cells["dgvDecIGV"].Value = constanteIGV.valor;
                            dgvListadoDetalle.CurrentRow.Cells["dgvDecPrecioUnitario"].Value = 0;

                            dgvListadoDetalle.CurrentCell = dgvListadoDetalle.CurrentRow.Cells["dgvTxtCodigo"];

                            PintarDataGridDetalle(dgvListadoDetalle.CurrentRow.Index, false);

                        }
                        else
                        {
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtSerie"].Value = txtSerie.Text.Trim();
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtNumero"].Value = txtNumero.Text.Trim();
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtRUC"].Value = lblRUC.Text.Trim();

                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRIdEmpresa"].Value = ocView.IdEmpresa;
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRSerie"].Value = ocView.Serie;
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRNumero"].Value = ocView.Numero;
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRSecuencia"].Value = ocView.Secuencia;
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtGRTipoOrden"].Value = ocView.Tipo;

                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtCodigo"].Value = ocView.CodProducto;
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtDescripcion"].Value = ocView.Producto;
                            dgvListadoDetalle.CurrentRow.Cells["dgvTxtCodUM"].Value = ocView.CodUM;

                            dgvListadoDetalle.CurrentRow.Cells["dgvDecCantidad"].Value = 0;
                            dgvListadoDetalle.CurrentRow.Cells["dgvDecIGV"].Value = constanteIGV.valor;
                            dgvListadoDetalle.CurrentRow.Cells["dgvDecPrecioUnitario"].Value = 0;

                            PintarDataGridDetalle(dgvListadoDetalle.CurrentRow.Index, false);

                            dgvListadoDetalle.CurrentCell = dgvListadoDetalle.CurrentRow.Cells["dgvTxtCodUM"];

                            dgvListadoDetalle.AutoResizeColumns();
                            dgvListadoDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        }

                        CalcularMontosFinales();
                    }
                }
                else
                {
                    ResponseMessage.Message("Ingrese la serie y número de la factura", "WARNING");
                }

            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                if (dgvListadoDetalle.CurrentRow != null)
                {
                    DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar el item seleccionado?");

                    if (resultadoMensaje == DialogResult.OK)
                    {
                        // Insertar si no existe, en todo caso actualizar.
                        _facDetParam = new SetFacDetParam();

                        _facDetParam.opcion = 2; // Eliminar

                        _facDetParam.idEmpresa = Empresa.ID_EMPRESA;

                        _facDetParam.serie = dgvListadoDetalle.CurrentRow.Cells["dgvTxtSerie"].Value.ToString();
                        _facDetParam.numero = Convert.ToInt32(dgvListadoDetalle.CurrentRow.Cells["dgvTxtNumero"].Value);
                        _facDetParam.codigoPC = dgvListadoDetalle.CurrentRow.Cells["dgvTxtRUC"].Value.ToString();
                        _facDetParam.secuencia = Convert.ToInt32(dgvListadoDetalle.CurrentRow.Cells["dgvTxtSecuenciaBD"].Value);
                        _facDetParam.codTipoCpte = cboTipoComprobante.SelectedValue.ToString();

                        Response respuesta = _facturaBL.SetFacDet(_facDetParam);

                        if (respuesta.idResponse == 0)
                        {
                            ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);
                        }

                        dgvListadoDetalle.Rows.Clear();
                        ListarDetalle(Empresa.ID_EMPRESA, _facDetParam.serie, _facDetParam.numero, _facDetParam.codigoPC, _facDetParam.codTipoCpte);
                        CalcularMontosFinales();
                        EnumerarSecuencia();

                    }
                }

            }

        }


        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvListadoDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double output;

            if (dgvListadoDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecCantidad") && dgvListadoDetalle.Rows[e.RowIndex].Cells["dgvTxtCodigo"].Value != null)
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out output))
                {
                    ResponseMessage.Message("Ingresa la cantidad", "WARNING");
                    e.Cancel = true;
                }
            }
            else if (dgvListadoDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecPrecioUnitario") && dgvListadoDetalle.Rows[e.RowIndex].Cells["dgvTxtCodigo"].Value != null)
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out output))
                {
                    ResponseMessage.Message("Ingresa el precio unitario", "WARNING");
                    e.Cancel = true;
                }
            }

        }

        private void dgvListadoDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListadoDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecCantidad") ||
                dgvListadoDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecPrecioUnitario") ||
                dgvListadoDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecIGV"))
            {
                if (dgvListadoDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value != null &&
                    dgvListadoDetalle.Rows[e.RowIndex].Cells["dgvDecPrecioUnitario"].Value != null &&
                    dgvListadoDetalle.Rows[e.RowIndex].Cells["dgvDecIGV"].Value != null)
                {
                    CalcularMontosFinales();
                }
            }
        }

        private void PintarDataGridDetalle(int rowIndex, bool tieneGR)
        {
            if (tieneGR)
            {
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRIdEmpresa"].Style.BackColor = Color.WhiteSmoke;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRSerie"].Style.BackColor = Color.WhiteSmoke;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRNumero"].Style.BackColor = Color.WhiteSmoke;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtCodigo"].Style.BackColor = Color.WhiteSmoke;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtDescripcion"].Style.BackColor = Color.WhiteSmoke;

                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRIdEmpresa"].ReadOnly = true;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRSerie"].ReadOnly = true;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRNumero"].ReadOnly = true;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtCodigo"].ReadOnly = true;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtDescripcion"].ReadOnly = true;

            }
            else
            {
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRIdEmpresa"].Style.BackColor = Color.White;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRSerie"].Style.BackColor = Color.White;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRNumero"].Style.BackColor = Color.White;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtCodigo"].Style.BackColor = Color.White;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtDescripcion"].Style.BackColor = Color.White;

                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRIdEmpresa"].ReadOnly = false;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRSerie"].ReadOnly = false;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtGRNumero"].ReadOnly = false;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtCodigo"].ReadOnly = false;
                dgvListadoDetalle.Rows[rowIndex].Cells["dgvTxtDescripcion"].ReadOnly = false;
            }
        }


        private void CalcularMontosFinales()
        {
            decimal subTotal = 0;
            decimal igv = 0;
            decimal total = 0;

            foreach (DataGridViewRow row in dgvListadoDetalle.Rows)
            {
                if (row.Cells["dgvDecCantidad"].Value != null && row.Cells["dgvDecPrecioUnitario"].Value != null)
                {
                    subTotal += (Convert.ToDecimal(row.Cells["dgvDecCantidad"].Value) * Convert.ToDecimal(row.Cells["dgvDecPrecioUnitario"].Value));

                    igv += (Convert.ToDecimal(row.Cells["dgvDecCantidad"].Value) * Convert.ToDecimal(row.Cells["dgvDecPrecioUnitario"].Value)) * (Convert.ToDecimal(row.Cells["dgvDecIGV"].Value) / 100);

                    total += (Convert.ToDecimal(row.Cells["dgvDecCantidad"].Value) * Convert.ToDecimal(row.Cells["dgvDecPrecioUnitario"].Value)) +
                        ((Convert.ToDecimal(row.Cells["dgvDecCantidad"].Value) * Convert.ToDecimal(row.Cells["dgvDecPrecioUnitario"].Value)) * (Convert.ToDecimal(row.Cells["dgvDecIGV"].Value) / 100));
                }
            }

            // COMPRA NACIONAL
            lblSubTotal.Text = Math.Round(subTotal, 2).ToString("N2");
            lblIGV.Text = Math.Round(igv, 2).ToString("N2");
            lblTotal.Text = Math.Round(total, 2).ToString("N2");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SetFacCabParam factParametro = new SetFacCabParam();
            factParametro.opcion = 2;
            factParametro.fechaEmision = "";
            factParametro.idEmpresa = Empresa.ID_EMPRESA;
            factParametro.codigoPC = "";
            factParametro.usuarioReg = "";
            string tipoComprobante = cboTipoComprobante.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(lblRUC.Text.Trim()) && lblRUC.Text.Trim() != "" &&
                !string.IsNullOrEmpty(txtSerie.Text.Trim()) && txtSerie.Text.Trim() != "" &&
                !string.IsNullOrEmpty(txtNumero.Text.Trim()) && txtNumero.Text.Trim() != "" &&
                !string.IsNullOrEmpty(tipoComprobante))
            {
                DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar la factura " + txtSerie.Text.Trim() + "-" + txtNumero.Text.Trim() + " ?");

                if (resultadoMensaje == DialogResult.OK)
                {
                    factParametro.serie = txtSerie.Text.Trim();
                    factParametro.numero = Convert.ToInt32(txtNumero.Text.Trim());
                    factParametro.codigoPC = lblRUC.Text.Trim();
                    factParametro.codTipoCpte = tipoComprobante;
                    factParametro.serieNotaCredito = txtSerieNotaCredito.Text.Trim();
                    factParametro.numeroNotaCredito = string.IsNullOrEmpty(txtNumeroNotaCredito.Text.Trim()) ? "0" : txtNumeroNotaCredito.Text.Trim();

                    Response responseGeneral = _facturaBL.SetFacCab(factParametro);
                    ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);

                    Limpiar();
                }
            }
            else
            {
                ResponseMessage.Message("Ingrese un N° RUC / Documento correcto / Tipo Documento", "WARNING");
            }
        }

        private void btnNuevo_Leave(object sender, EventArgs e)
        {
            dgvListadoDetalle.Focus();
        }

        private void cbxTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cbxTipoMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTipoCambio();
        }

        private void GetTipoCambio(int? IdTipoMoneda = null)
        {
            string fecha = dtpFechaEmision.Value.ToString("yyyy-MM-dd");

            if (IdTipoMoneda != null)
            {
                cbxTipoMoneda.SelectedValue = IdTipoMoneda;
            }

            int idtipomoneda = IdTipoMoneda != null ? (int)IdTipoMoneda : Convert.ToInt32(cbxTipoMoneda.SelectedValue.ToString()); 
            

            //DataTable tbl;
            tblTiposCambios = new DataTable();

            if (idtipomoneda != 0)
            {
                tblTiposCambios = _mantenimientoBL.SetDatatable(72, fecha, "0", idtipomoneda, 0,TipoCambio);
          

                if (tblTiposCambios.Rows.Count > 0)
                {
                    cbTipoCambio.DataSource = tblTiposCambios;// _mantenimientoBL.SetDatatable(72, fecha, "0", idtipomoneda, 0,TipoCambio);
                    cbTipoCambio.DisplayMember = "descripcion";
                    cbTipoCambio.ValueMember = "codigo";
                }
                else
                {
                    ResponseMessage.Message("No cuenta con tipo de cambio registrado, para el día " + fecha, "WARNING");
                }
            }
        





            if (string.IsNullOrEmpty(txtAnio.Text) || txtAnio.Text == "0")
            {
                txtAnio.Text = dtpFechaEmision.Value.Year.ToString();
            }

            if (string.IsNullOrEmpty(txtMes.Text) || txtMes.Text == "0")
            {
                txtMes.Text = dtpFechaEmision.Value.Month.ToString();
            }
        }

        private void dtpFechaEmision_ValueChanged(object sender, EventArgs e)
        {
            GetTipoCambio();
        }

        private void cboTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string valor = cboTipoComprobante.SelectedValue.ToString();

            //// NOTA DE DEBITOS
            //if (valor == "07")
            //{
            //    txtObservaciones.Enabled = true;
            //    //  RECORREMSO LAS COLUMNAS
            //    foreach (DataGridViewColumn col in dgvListadoDetalle.Columns)
            //    {
            //        col.ReadOnly = true;
            //    }
            //    lblNotaCredito.Visible = true;

            //    txtSerieNotaCredito.Clear();
            //    txtNumeroNotaCredito.Clear();

            //    txtSerieNotaCredito.Visible = true;
            //    txtNumeroNotaCredito.Visible = true;

            //    dgvListadoDetalle.Columns["cantidadNotaDebito"].Visible = true;
            //    dgvListadoDetalle.Columns["cantidadNotaDebito"].ReadOnly = false;
            //}
            //else
            //{
            //    txtObservaciones.Enabled = false;
            //    foreach (DataGridViewColumn col in dgvListadoDetalle.Columns)
            //    {
            //        col.ReadOnly = false;
            //    }
            //    dgvListadoDetalle.Columns["cantidadNotaDebito"].Visible = false;

            //    lblNotaCredito.Visible = false;
            //    txtSerieNotaCredito.Visible = false;
            //    txtNumeroNotaCredito.Visible = false;
            //}


        }

        private void cboTipoComprobante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string valor = cboTipoComprobante.SelectedValue.ToString();

            // NOTA DE CREDITO
            if (valor == "07" || valor == "08")
            {
                btnBuscarNotaCredito.Visible = true;
                //btnBuscar.Visible = false;
                txtObservaciones.Enabled = true;
                //  RECORREMSO LAS COLUMNAS
                foreach (DataGridViewColumn col in dgvListadoDetalle.Columns)
                {
                    col.ReadOnly = true;
                }
                lblNotaCredito.Visible = true;

                txtSerieNotaCredito.Clear();
                txtNumeroNotaCredito.Clear();

                txtSerieNotaCredito.Visible = true;
                txtNumeroNotaCredito.Visible = true;

                //dgvListadoDetalle.Columns["cantidadNotaCredito"].Visible = true;
                //dgvListadoDetalle.Columns["cantidadNotaCredito"].ReadOnly = false;
                dgvListadoDetalle.Columns["dgvDecCantidad"].ReadOnly = false;
                dgvListadoDetalle.Columns["dgvDecPrecioUnitario"].ReadOnly = false;


            }
            else
            {

                //btnBuscar.Visible = true;
                btnBuscarNotaCredito.Visible = false;

                txtObservaciones.Enabled = false;
                foreach (DataGridViewColumn col in dgvListadoDetalle.Columns)
                {
                    col.ReadOnly = false;
                }
                //dgvListadoDetalle.Columns["cantidadNotaCredito"].Visible = false;

                //if (dgvListadoDetalle.Columns.Count >0 )
                //{
                //    dgvListadoDetalle.Columns["cantidadNotaCredito"].Visible = false;

                //}


                lblNotaCredito.Visible = false;
                txtSerieNotaCredito.Visible = false;
                txtNumeroNotaCredito.Visible = false;
            }
        }

        private void btnBuscarNotaCredito_Click(object sender, EventArgs e)
        {
            Buscar("07");

        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            frmTipoCambio frm = new frmTipoCambio();
            frm.ShowDialog();

            TipoCambioModificado = frm.TipoCambio;

            // BUSCAMOS SI EXISTE O NO PARA REGISTRARLO COMO TIPO DE CAMBIO
            bool existe = false;
            for (int x = 0;x < tblTiposCambios.Rows.Count; x++ )
            {
                if (Convert.ToDecimal(tblTiposCambios.Rows[x]["codigo"].ToString()) == TipoCambioModificado)
                {
                    existe = true;
                }
            }

            if (!existe)
            {
                // Agregar una nueva fila al DataTable
                DataRow newRow = tblTiposCambios.NewRow();
                newRow["descripcion"] = "Modificado - " + TipoCambioModificado.ToString();
                newRow["codigo"] = TipoCambioModificado.ToString();
                tblTiposCambios.Rows.Add(newRow);
            }

            cbTipoCambio.SelectedValue = TipoCambioModificado;

            //cbTipoCambio.DataSource = tblTiposCambios;// _mantenimientoBL.SetDatatable(72, fecha, "0", idtipomoneda, 0,TipoCambio);
            //cbTipoCambio.DisplayMember = "descripcion";
            //cbTipoCambio.ValueMember = "codigo";
        }
    }
}
