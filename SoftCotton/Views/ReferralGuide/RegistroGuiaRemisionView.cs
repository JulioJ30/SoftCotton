using SoftCotton.BusinessLogic;
using SoftCotton.Model.Kardex;
using SoftCotton.Model.ReferralGuide;
using SoftCotton.Util;
using SoftCotton.Views.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SoftCotton.Model.Maintenance;

using Newtonsoft.Json;
using System.Text;
using DocumentFormat.OpenXml.Drawing;


namespace SoftCotton.Views.ReferralGuide
{
    public partial class RegistroGuiaRemisionView : Form
    {
        GuiaRemisionBL _referralGuideBL;
        KardexBL _kardexBL;
        MantenimientoBL _referraMantBL;
        GetGR2_CabeceraXCod grCabGenerales;
        List<GetGR3_DetalleXCod> grDetsGenerales;


        SetGRCabParam _grCabParam;
        SetGRDetParam _grDetParam;

        public RegistroGuiaRemisionView()
        {
            InitializeComponent();

            _referralGuideBL = new GuiaRemisionBL();
            _kardexBL = new KardexBL();
            _referraMantBL = new MantenimientoBL();

        }

        private void RegistroGuiaRemisionView_Load(object sender, EventArgs e)
        {
            Limpiar();
            ValoresPredeterminados();

            ListarTipoComprobantes();
            txtSerie.Focus();
            cargarcb();
            cbxTipoOrden.SelectedIndex = 0;

            UserApplication.USUARIO = "PRUEBA JMORAN";
            Empresa.ID_EMPRESA = 1;

            // TIPO DE TRANSPORTE
            List<GR_TipoTransporte> lTipoTransporte = new List<GR_TipoTransporte>();
            lTipoTransporte.Add(new GR_TipoTransporte { codTipoTransporte = "01", tipoTransporte = "TRANSPORTE PÚBLICO" });
            lTipoTransporte.Add(new GR_TipoTransporte { codTipoTransporte = "02", tipoTransporte = "TRANSPORTE PRIVADO" });

            ////
            cboTipoTransporte.DataSource = lTipoTransporte;
            cboTipoTransporte.ValueMember = "codTipoTransporte";
            cboTipoTransporte.DisplayMember = "tipoTransporte";


            List<GetMant40_ConstanciaInscripcion> constancias = _referraMantBL.GetMant40_ConstanciaInscripcion("1");
            cboConstanciaInscripcion.DataSource = constancias;
            cboConstanciaInscripcion.ValueMember = "idConstanciaInscripcion";
            cboConstanciaInscripcion.DisplayMember = "constanciaInscripcion";

            List<GetMant41_NumeroLicenciaConducir> licencias = _referraMantBL.GetMant41_NumeroLicenciaConducir("1");
            cboLicenciaConducir.DataSource = licencias;
            cboLicenciaConducir.DisplayMember = "numeroLicenciaConducir";
            cboLicenciaConducir.ValueMember = "idNumeroLicenciaConducir";

            cbxTipoMovDefault.SelectedIndex = 0;
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

        private void btnBuscarProvDest_Click(object sender, EventArgs e)
        {
            BuscarProvClienteView provClienteView = new BuscarProvClienteView();

            provClienteView.ShowDialog();
            lblRUCDest.Text = provClienteView.codProvCliente;
            lblRSDest.Text = provClienteView.provCliente;
            txtPuntoLlegada.Text = provClienteView.direccion;

            txtMarca.Focus();
        }

        private void btnBuscarProvTransp_Click(object sender, EventArgs e)
        {
            BuscarProvClienteView provClienteView = new BuscarProvClienteView();

            provClienteView.ShowDialog();
            lblRUCTransporte.Text = provClienteView.codProvCliente;
            lblRSTransporte.Text = provClienteView.provCliente;

            txtCodigoOrdenDefault.Focus();
        }


        private void dgvGRDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            EnumerarSecuencia();

            if (cbxTipoMovDefault.SelectedIndex == 0 || cbxTipoMovDefault.SelectedIndex == -1)
            {
                dgvGRDetalle.Rows[e.RowIndex].Cells["dgvTxtTipoMov"].Value = "ENTRADA";
                cbxTipoMovDefault.SelectedIndex = 0;
            }
            else if (cbxTipoMovDefault.SelectedIndex == 1)
            {
                dgvGRDetalle.Rows[e.RowIndex].Cells["dgvTxtTipoMov"].Value = "SALIDA";
            }
            else if (cbxTipoMovDefault.SelectedIndex == 2)
            {
                dgvGRDetalle.Rows[e.RowIndex].Cells["dgvTxtTipoMov"].Value = "DEVOLUCION";
            }

            dgvGRDetalle.Rows[e.RowIndex].Cells["dgvTxtIdDet"].Value = txtCodigoOrdenDefault.Text;
        }

        private void dgvGRDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double output;
            double cantidad;
            decimal cantidadIngresadoSalida = 0;
            decimal cantidadSaldo = 0;
            decimal cantidadIngresadoTotal = 0;

            if (dgvGRDetalle.CurrentRow != null)
            {
                if (dgvGRDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecCantIngresada"))
                {
                    if (dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantIngresada"].Value != null && dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidadSaldo"].Value != null)
                    {
                        //cantidad = 0;
                        //cantidadIngresado = 0;

                        //if (double.TryParse(dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value.ToString(), out output))
                        //{
                        //    cantidad = Convert.ToDouble(dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value);
                        //}

                        if (double.TryParse(dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantIngresada"].Value.ToString(), out output))
                        {
                            cantidadIngresadoSalida = Convert.ToDecimal(dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantIngresada"].Value);
                        }

                        //cantidadSaldo = Convert.ToDouble(dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidadSaldo"].Value);


                        //if (dgvGRDetalle.Rows[0].Cells["dgvTxtTipoMov"].Value.ToString() == "SALIDA")
                        //{
                        //    if ((cantidadSaldo + Math.Abs(cantidadIngresado)) > cantidad)
                        //    {
                        //        DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("Stock Insuficiente");
                        //        dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantIngresada"].Value = 0;

                        //        //if (resultadoMensaje != DialogResult.OK)
                        //        //{
                        //        //}
                        //        //else
                        //        //{
                        //        //    dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidadSaldo"].Value = cantidad - cantidadIngresado;
                        //        //}
                        //    }
                        //    else
                        //    {
                        //        dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidadSaldo"].Value = cantidad - cantidadIngresado;
                        //    }
                        //}
                        //else
                        //{
                        //    dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidadSaldo"].Value = cantidad - cantidadIngresado;
                        //}

                        if (dgvGRDetalle.Rows[0].Cells["dgvTxtTipoMov"].Value.ToString() == "SALIDA")
                        {
                            cantidadSaldo = Convert.ToDecimal(dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidadSaldo"].Value);

                            if (Math.Abs(cantidadIngresadoSalida) > Math.Abs(cantidadSaldo))
                            {
                                ResponseMessage.Message("Stock Insuficiente", "INFORMATION");
                                dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantIngresada"].Value = 0;
                            }
                        }
                    }
                }
                else if (dgvGRDetalle.Columns[e.ColumnIndex].Name.Equals("dgvCodCuenta"))
                {
                    if (dgvGRDetalle.Rows[e.RowIndex].Cells["dgvCodCuenta"].Value != null && dgvGRDetalle.Rows[e.RowIndex].Cells["dgvCodCuenta"].Value != "")
                    {
                        SetGRCabParam setGRCabParam = new SetGRCabParam();

                        setGRCabParam.opcion = 3;
                        setGRCabParam.codCuenta = dgvGRDetalle.Rows[e.RowIndex].Cells["dgvCodCuenta"].Value.ToString();

                        Response responseGeneral = _referralGuideBL.SetGRCabecera(setGRCabParam);

                        if (responseGeneral.idResponse == 0)
                        {
                            dgvGRDetalle.Rows[e.RowIndex].Cells["dgvCodCuenta"].Value = null;
                            ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
                        }
                    }
                }
            }
        }

        private void dgvGRDetalle_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            EnumerarSecuencia();
        }


        private void btnBuscarGR_Click(object sender, EventArgs e)
        {
            BuscarGuias();
        }

        private void BuscarGuias()
        {
            if (!string.IsNullOrEmpty(txtSerie.Text.Trim()) && !string.IsNullOrEmpty(txtNumero.Text.Trim()))
            {

                // OBTENEMOS DATOS DE LA CABECERA

                //if (grCab.tipoOrden == "C")
                //{
                //    cbxTipoOrden.SelectedIndex = 1;
                //}
                //else if (grCab.tipoOrden == "S")
                //{
                //    cbxTipoOrden.SelectedIndex = 2;
                //}

                string tipo_orden = "";
                if (cbxTipoOrden.SelectedIndex == 1 && rbIngreso.Checked)
                {
                    tipo_orden = "C";
                }
                else if (cbxTipoOrden.SelectedIndex == 2 && rbIngreso.Checked)
                {
                    tipo_orden = "S";
                }
                else if (cbxTipoOrden.SelectedIndex == 1 && rbSalida.Checked)
                {
                    tipo_orden = "E"; // pedido
                }
                else if (cbxTipoOrden.SelectedIndex == 2 && rbSalida.Checked)
                {
                    tipo_orden = "P"; // produccion
                }




                GetGR2_CabeceraXCod grCab = _referralGuideBL.Get2_CabeceraXCod(Empresa.ID_EMPRESA, txtSerie.Text.Trim(), txtNumero.Text.Trim(), tipo_orden);
                grCabGenerales = grCab;

                if (grCab == null)
                {
                    ResponseMessage.Message("La guía de remisión no existe", "WARNING");
                    Limpiar();
                }
                else
                {
                    txtSerie.Text = grCab.serie;
                    txtNumero.Text = grCab.numero;
                    dtpFechaEmision.Value = Convert.ToDateTime(grCab.fechaEmision).Date;
                    txtPuntoPartida.Text = grCab.puntoPartida;
                    txtPuntoLlegada.Text = grCab.puntoLlegada;

                    dtpFechaTraslado.Value = Convert.ToDateTime(grCab.fechaInicioTraslado).Date;
                    lblRUCDest.Text = grCab.destCodigoPC;
                    lblRSDest.Text = grCab.destRS;

                    txtMarca.Text = grCab.transMarca;
                    txtNumPlaca.Text = grCab.transNumPlaca;
                    cboConstanciaInscripcion.Text = grCab.transNumConstInscr;
                    cboLicenciaConducir.Text = grCab.transNumLicConducir;
                    cboTipoTransporte.SelectedValue = grCab.codTipoTransporte;

                    lblRUCTransporte.Text = grCab.transCodigoPC;
                    lblRSTransporte.Text = grCab.transRS;

                    cbxTipoCpte.SelectedValue = grCab.codTipoCpte;
                    txtNumCpte.Text = grCab.numCptePago;
                    txtVoucher.Text = grCab.voucher.ToString();
                    txtOtrosMotivos.Text = grCab.otrosMotivoTraslado;
                    txtObservaciones.Text = grCab.observaciones;

                    //if (grCab.tipoOrden == "C")
                    //{
                    //    cbxTipoOrden.SelectedIndex = 1;
                    //}
                    //else if (grCab.tipoOrden == "S")
                    //{
                    //    cbxTipoOrden.SelectedIndex = 2;
                    //}

                    switch (grCab.idMotivoTraslado)
                    {
                        case 1: chkM1.Checked = true; break;
                        case 2: chkM2.Checked = true; break;
                        case 3: chkM3.Checked = true; break;
                        case 4: chkM6.Checked = true; break;
                        case 5: chkM9.Checked = true; break;
                        case 6: chkM11.Checked = true; break;
                        case 7: chkM12.Checked = true; break;
                        case 8: chkM13.Checked = true; break;

                    }

                    lblcuo.Text = $"Número de Movimiento:{grCab.cuo}";
                    btnEnviarNubefact.Enabled = !grCab.enviadoSunat;

                    ListarDetalle(Empresa.ID_EMPRESA, grCab.serie, grCab.numero, grCab.tipoOrden);
                }
            }
            else
            {
                ResponseMessage.Message("Ingrese una serie y número de guía de remisión valida", "WARNING");
            }
        }



        // Funciones 
        private void ListarTipoComprobantes()
        {
            List<GetGR4_TipoCptes> listaTipoCptes = _referralGuideBL.Get4_TipoCptes();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = listaTipoCptes;

            cbxTipoCpte.DisplayMember = "tipoComprobante";
            cbxTipoCpte.ValueMember = "codTipoCpte";
            cbxTipoCpte.DataSource = bindingSource.DataSource;

            cbxTipoCpte.SelectedValue = "00";
        }


        private void GuardarCambios()
        {
            var fechaEmision = dtpFechaEmision.Value.ToString();
            var responseGeneral = _referralGuideBL.SetValidarPeriodo(fechaEmision);

            if (responseGeneral.idResponse == 1)
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
                return;
            }

            if (ValidarDatosCabecera() && ValidarDatosDetalle())
            {
                _grCabParam = new SetGRCabParam();

                // Insertar
                _grCabParam.opcion = 1;

                _grCabParam.codTipoTransporte = cboTipoTransporte.SelectedValue.ToString();
                _grCabParam.idEmpresa = Empresa.ID_EMPRESA;
                _grCabParam.serie = txtSerie.Text.Trim();
                _grCabParam.numero = txtNumero.Text.Trim();
                _grCabParam.fechaEmision = dtpFechaEmision.Value.ToString("yyyyMMdd");
                _grCabParam.puntoPartida = txtPuntoPartida.Text.Trim();
                _grCabParam.puntoLlegada = txtPuntoLlegada.Text.Trim();

                _grCabParam.fechaInicioTraslado = dtpFechaTraslado.Value.ToString("yyyyMMdd");
                _grCabParam.destCodigoPC = lblRUCDest.Text.Trim();
                _grCabParam.transCodigoPC = lblRUCTransporte.Text.Trim();

                _grCabParam.transMarca = txtMarca.Text;
                _grCabParam.transNumPlaca = txtNumPlaca.Text;
                _grCabParam.transNumConstInscr = cboConstanciaInscripcion.SelectedValue.ToString();
                _grCabParam.transNumLicConducir = cboLicenciaConducir.SelectedValue.ToString();

                _grCabParam.codTipoCpte = cbxTipoCpte.SelectedValue.ToString();
                _grCabParam.numCptePago = txtNumCpte.Text;
                _grCabParam.usuarioReg = UserApplication.USUARIO;

                if (cbxTipoOrden.SelectedIndex == 1 && rbIngreso.Checked)
                {
                    _grCabParam.tipoOrden = "C";
                }
                else if (cbxTipoOrden.SelectedIndex == 2 && rbIngreso.Checked)
                {
                    _grCabParam.tipoOrden = "S";
                }
                else if (cbxTipoOrden.SelectedIndex == 1 && rbSalida.Checked)
                {
                    _grCabParam.tipoOrden = "E"; // pedido
                }
                else if (cbxTipoOrden.SelectedIndex == 2 && rbSalida.Checked)
                {
                    _grCabParam.tipoOrden = "P"; // produccion
                }



 



                if (string.IsNullOrEmpty(txtVoucher.Text))
                {
                    _grCabParam.voucher = 0;
                }
                else
                {
                    _grCabParam.voucher = Convert.ToInt32(txtVoucher.Text);
                }


                if (chkM1.Checked)
                {
                    _grCabParam.idMotivoTraslado = 1;
                }
                else if (chkM2.Checked)
                {
                    _grCabParam.idMotivoTraslado = 2;
                }
                else if (chkM3.Checked)
                {
                    _grCabParam.idMotivoTraslado = 3;
                }
                //else if (chkM4.Checked)
                //{
                //    _grCabParam.idMotivoTraslado = 4;
                //}
                //else if (chkM5.Checked)
                //{
                //    _grCabParam.idMotivoTraslado = 5;
                //}
                else if (chkM6.Checked)
                {
                    _grCabParam.idMotivoTraslado = 4;
                }
                //else if (chkM7.Checked)
                //{
                //    _grCabParam.idMotivoTraslado = 7;
                //}
                //else if (chkM8.Checked)
                //{
                //    _grCabParam.idMotivoTraslado = 8;
                //}
                else if (chkM9.Checked)
                {
                    _grCabParam.idMotivoTraslado = 5;
                }
                //else if (chkM10.Checked)
                //{
                //    _grCabParam.idMotivoTraslado = 10;
                //}
                else if (chkM11.Checked)
                {
                    _grCabParam.idMotivoTraslado = 6;
                }
                else if (chkM12.Checked)
                {
                    _grCabParam.idMotivoTraslado = 7;
                }
                else if (chkM13.Checked)
                {
                    _grCabParam.idMotivoTraslado = 8;
                }
                //else
                //{
                //    _grCabParam.idMotivoTraslado = 0;
                //}

                _grCabParam.observaciones = txtObservaciones.Text.Trim();
                _grCabParam.otrosMotivoTraslado = txtOtrosMotivos.Text.Trim();

                Procesar(_grCabParam);
            }
        }

        public void Procesar(SetGRCabParam parametro)
        {
            Response responseGeneral = _referralGuideBL.SetGRCabecera(parametro);

            if (responseGeneral.idResponse > 0)
            {
                ProcesarDetalle(Empresa.ID_EMPRESA, parametro.serie, parametro.numero, parametro.tipoOrden);
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }


        private void ProcesarDetalle(int idEmpresa, string serie, string numero, string tipoOrden)
        {
            Response respuestaDetalle = new Response();
            bool estadoProceso = true;
            int contador = 1;

            foreach (DataGridViewRow row in dgvGRDetalle.Rows)
            {
                if (estadoProceso && (contador < dgvGRDetalle.Rows.Count))
                {
                    // Insertar si no existe, en todo caso actualizar.
                    _grDetParam = new SetGRDetParam();

                    _grDetParam.opcion = 1; // Insertar / Actualizar.

                    _grDetParam.idEmpresa = Empresa.ID_EMPRESA;
                    _grDetParam.serie = serie;
                    _grDetParam.numero = numero;


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
                    _grDetParam.secuencia = v_secuencia;



                    _grDetParam.idEmpresaDet = Convert.ToInt32(row.Cells["dgvIntIdEmpresaDet"].Value);
                    _grDetParam.idDet = Convert.ToInt32(row.Cells["dgvTxtIdDet"].Value);
                    _grDetParam.idSecuenciaDet = Convert.ToInt32(row.Cells["dgvIntSecuenciaDet"].Value);

                    if (row.Cells["dgvCodCuenta"].Value == null)
                    {
                        _grDetParam.codCuenta = "";
                    }
                    else
                    {
                        _grDetParam.codCuenta = row.Cells["dgvCodCuenta"].Value.ToString();
                    }

                    var nroFisico = string.Concat(serie, numero);
                    var codigoProducto = row.Cells["dgvTxtCodigoProducto"].Value.ToString();
                    var cantidadInresada = Convert.ToDecimal(row.Cells["dgvDecCantIngresada"].Value);
                    var precioUniCompra = Convert.ToDecimal(row.Cells["dgvDescPrecioUnitario"].Value);

                    if (row.Cells["dgvTxtTipoMov"].Value.ToString() == "ENTRADA")
                    {
                        _grDetParam.tipoMovimiento = "E";
                    }
                    else if (row.Cells["dgvTxtTipoMov"].Value.ToString() == "SALIDA")
                    {
                        _grDetParam.tipoMovimiento = "S";
                    }
                    else if (row.Cells["dgvTxtTipoMov"].Value.ToString() == "DEVOLUCION")
                    {
                        _grDetParam.tipoMovimiento = "D";
                    }

                    _grDetParam.cantidadIngresada = Convert.ToDecimal(row.Cells["dgvDecCantIngresada"].Value);
                    _grDetParam.pesoIngresado = Convert.ToDecimal(row.Cells["dgvDecPesoIngresado"].Value);


                    if (row.Cells["dgvTxtNumPartida"].Value == null)
                    {
                        _grDetParam.numeroPartida = "";
                    }
                    else
                    {
                        _grDetParam.numeroPartida = row.Cells["dgvTxtNumPartida"].Value.ToString();
                    }

                    if (cbxTipoOrden.SelectedIndex == 1 && rbIngreso.Checked)
                    {
                        _grDetParam.tipoOrden = "C";
                    }
                    else if (cbxTipoOrden.SelectedIndex == 2 && rbIngreso.Checked)
                    {
                        _grDetParam.tipoOrden = "S";
                    }
                    else if (cbxTipoOrden.SelectedIndex == 1 && rbSalida.Checked)
                    {
                        _grDetParam.tipoOrden = "E"; // pedido
                    }
                    else if (cbxTipoOrden.SelectedIndex == 2 && rbSalida.Checked)
                    {
                        _grDetParam.tipoOrden = "P"; // produccion
                    }

                    respuestaDetalle = _referralGuideBL.SetGRDetalle(_grDetParam);

                    if (respuestaDetalle.idResponse == 0)
                    {
                        estadoProceso = false;
                        ResponseMessage.Message(respuestaDetalle.messageResponse, respuestaDetalle.typeMessage);
                    }
                    //else
                    //{
                    //    var split = codigoProducto.Split('.');

                    //    //Kardex
                    //    Kardex(split[0].ToString(), split[1].ToString(), split[2].ToString(), split[3].ToString(), nroFisico, cantidadInresada, precioUniCompra);
                    //}
                }

                contador++;
            }


            if (estadoProceso)
            {
                ResponseMessage.Message(respuestaDetalle.messageResponse, "INFORMATION");
                BuscarGuias();
            }

            dgvGRDetalle.Rows.Clear();
            ListarDetalle(Empresa.ID_EMPRESA, _grCabParam.serie, _grCabParam.numero, _grCabParam.tipoOrden);
        }

        private void ListarDetalle(int idEmpresa, string serie, string numero, string tipoOrden)
        {
            List<GetGR3_DetalleXCod> grDets = _referralGuideBL.Get3_DetalleXCod(idEmpresa, serie, numero, tipoOrden);
            grDetsGenerales = grDets;
            dgvGRDetalle.Rows.Clear();

            foreach (var item in grDets)
            {
                int index = dgvGRDetalle.Rows.Add();

                dgvGRDetalle.Rows[index].Cells["dgvTxtTipoOrdenID"].Value = item.tipo;

                if (item.tipo == "C")
                {
                    dgvGRDetalle.Rows[index].Cells["dgvTxtTipoOrden"].Value = "Orden de Compra";
                }
                else if (item.tipo == "S")
                {
                    dgvGRDetalle.Rows[index].Cells["dgvTxtTipoOrden"].Value = "Orden de Servicio";
                }
                else if (item.tipo == "E")
                {
                    dgvGRDetalle.Rows[index].Cells["dgvTxtTipoOrden"].Value = "Orden de Pedido";
                }
                else if (item.tipo == "P")
                {
                    dgvGRDetalle.Rows[index].Cells["dgvTxtTipoOrden"].Value = "Orden de Producciono";
                }



                dgvGRDetalle.Rows[index].Cells["dgvTxtSecuenciaBD"].Value = item.secuencia;


                dgvGRDetalle.Rows[index].Cells["dgvTxtIdDet"].Value = item.idDet;
                dgvGRDetalle.Rows[index].Cells["dgvIntIdEmpresaDet"].Value = item.idEmpresaDet;
                dgvGRDetalle.Rows[index].Cells["dgvTxtSerie"].Value = item.serie;
                dgvGRDetalle.Rows[index].Cells["dgvTxtNumero"].Value = item.numero;

                dgvGRDetalle.Rows[index].Cells["dgvTxtProveedor"].Value = item.codigo.Trim() + " - " + item.razonSocial.Trim();
                dgvGRDetalle.Rows[index].Cells["dgvIntSecuenciaDet"].Value = item.secuenciaDet;
                dgvGRDetalle.Rows[index].Cells["dgvTxtCodigoProducto"].Value = item.codigoProducto;
                dgvGRDetalle.Rows[index].Cells["dgvTxtProducto"].Value = item.producto;
                dgvGRDetalle.Rows[index].Cells["dgvCodCuenta"].Value = item.codCuenta;
                dgvGRDetalle.Rows[index].Cells["dgvDecCantidad"].Value = item.cantidadOC;

                dgvGRDetalle.Rows[index].Cells["dgvTxtCodUM"].Value = item.codUM;
                dgvGRDetalle.Rows[index].Cells["dgvDescPrecioUnitario"].Value = item.precioUnitario;
                dgvGRDetalle.Rows[index].Cells["dgvTxtTotal"].Value = Math.Round(item.total, 2);

                if (item.tipoMovimiento == "E")
                {
                    dgvGRDetalle.Rows[index].Cells["dgvTxtTipoMov"].Value = "ENTRADA";
                }
                else if (item.tipoMovimiento == "S")
                {
                    dgvGRDetalle.Rows[index].Cells["dgvTxtTipoMov"].Value = "SALIDA";
                }
                else if (item.tipoMovimiento == "D")
                {
                    dgvGRDetalle.Rows[index].Cells["dgvTxtTipoMov"].Value = "DEVOLUCION";
                }

                dgvGRDetalle.Rows[index].Cells["dgvTxtNumPartida"].Value = item.numeroPartida;

                dgvGRDetalle.Rows[index].Cells["dgvDecCantIngresada"].Value = Math.Round(item.cantidadIngresada, 3);

                dgvGRDetalle.Rows[index].Cells["dgvDecCantIngresadoTotal"].Value = Math.Round(item.cantidadIngresoTotal, 3);
                dgvGRDetalle.Rows[index].Cells["dgvDecCantSalidaTotal"].Value = Math.Round(item.cantidadSalidaTotal, 3);

                dgvGRDetalle.Rows[index].Cells["dgvDecPesoIngresado"].Value = Math.Round(item.pesoIngresado, 3);
                dgvGRDetalle.Rows[index].Cells["dgvDecCantidadSaldo"].Value = Math.Round(item.cantidadSaldo, 3);

                dgvGRDetalle.Rows[index].Cells["dgvIntIdOC"].Value = item.idOrden;
                
                PintarDataGridDetalle(index);

                dgvGRDetalle.CurrentCell = dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"];
            }
        }


        private bool ValidarDatosCabecera()
        {
            bool respuesta = false;

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
            else if (dgvGRDetalle.Rows.Count == 0)
            {
                respuesta = false;
                ResponseMessage.Message("La Guía de Remisión no tiene detalle", "WARNING");
            }
            else if (cbxTipoOrden.SelectedIndex == 0)
            {
                respuesta = false;
                ResponseMessage.Message("La Guía de Remisión no tiene definido un tipo de Orden", "WARNING");
            }
            else if (cbxTipoCpte.SelectedValue == null)
            {
                respuesta = false;
                ResponseMessage.Message("Seleccione un tipo de comprobante", "WARNING");
            }
            else if (chkM13.Checked && txtOtrosMotivos.Text.Trim() == string.Empty)
            {
                respuesta = false;
                ResponseMessage.Message("Por favor ingrese otros motivos de traslado", "WARNING");
                txtOtrosMotivos.Focus();
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

            foreach (DataGridViewRow row in dgvGRDetalle.Rows)
            {
                if (contador < dgvGRDetalle.Rows.Count)
                {
                    if (seguirValidando)
                    {
                        // Validar tipo de orden de compra
                        if (row.Cells["dgvTxtTipoOrdenID"].Value != null)
                        {
                            if (row.Cells["dgvTxtTipoOrdenID"].Value.ToString().Trim() == "")
                            {
                                respuesta = false;
                                seguirValidando = false;
                                ResponseMessage.Message("No tiene especificado el tipo de orden", "WARNING");
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
                            ResponseMessage.Message("No tiene especificado el tipo de orden", "WARNING");
                        }


                        // 1. Validar Codigo de Producto
                        if (row.Cells["dgvTxtIdDet"].Value != null)
                        {
                            if (row.Cells["dgvTxtIdDet"].Value.ToString().Trim() == "")
                            {
                                respuesta = false;
                                seguirValidando = false;
                                ResponseMessage.Message("Ingrese un codigo de producto", "WARNING");
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
                            ResponseMessage.Message("Ingrese un codigo de producto", "WARNING");
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
                            if (row.Cells["dgvDecCantIngresada"].Value != null)
                            {
                                if (!double.TryParse(row.Cells["dgvDecCantIngresada"].Value.ToString(), out output))
                                {
                                    respuesta = false;
                                    seguirValidando = false;
                                    ResponseMessage.Message("Ingresa la cantidad ingresada", "WARNING");
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
                                ResponseMessage.Message("Ingresa la cantidad ingresada", "WARNING");
                            }
                        }

                        // 5. Validar que seleccione el tipo de movimiento
                        if (respuesta)
                        {
                            if (row.Cells["dgvTxtTipoMov"].Value != null)
                            {
                                if (row.Cells["dgvTxtTipoMov"].Value.ToString().Trim() == "")
                                {
                                    respuesta = false;
                                    seguirValidando = false;
                                    ResponseMessage.Message("Seleccione el tipo de movimiento", "WARNING");
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
                                ResponseMessage.Message("Seleccione el tipo de movimiento", "WARNING");
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
            txtPuntoPartida.Text = "";
            txtPuntoLlegada.Text = "";

            lblRUCDest.Text = "";
            lblRSDest.Text = "";

            txtMarca.Text = "";
            txtNumPlaca.Text = "";
            //txtConstInsc.Text = "";
            //txtLicCond.Text = "";


            lblRUCTransporte.Text = "";
            lblRSTransporte.Text = "";

            txtVoucher.Text = "";
            txtObservaciones.Clear();
            dgvGRDetalle.Rows.Clear();
            lblcuo.Text = $"Número de movimiento:";

        }

        private void ValoresPredeterminados()
        {
            txtNumero.Text = "";
            dtpFechaEmision.Value = DateTime.Now.Date;
            dtpFechaTraslado.Value = DateTime.Now.Date;
        }

        private void EnumerarSecuencia()
        {
            int secuencia = 1;

            foreach (DataGridViewRow row in dgvGRDetalle.Rows)
            {
                row.Cells["dgvTxtItem"].Value = secuencia;

                secuencia++;
            }
        }



        private void dgvGRDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType().FullName == "System.Windows.Forms.DataGridViewTextBoxEditingControl")
            {
                // TextBox
                DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;

                tb.KeyDown -= dgvGRDetalle_KeyDown;
                tb.KeyDown += new KeyEventHandler(dgvGRDetalle_KeyDown);
            }
        }

        private void dgvGRDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            int n;
            string vTipoOrdenID = "";

            if (e.Control && e.KeyCode == Keys.B)
            {
                string FiltroOC = dgvGRDetalle.CurrentRow.Cells["dgvTxtIdDet"].EditedFormattedValue.ToString();

                if (!string.IsNullOrEmpty(FiltroOC))
                {
                    if (cbxTipoOrden.SelectedIndex > 0)
                    {
                        bool esNumero = int.TryParse(FiltroOC.Trim(), out n);

                        if (esNumero)
                        {
                            if (!string.IsNullOrEmpty(txtSerie.Text.Trim()) && !string.IsNullOrEmpty(txtNumero.Text.Trim()))
                            {

                                if (cbxTipoOrden.SelectedIndex == 1 && rbIngreso.Checked) 
                                {
                                    vTipoOrdenID = "C"; 
                                } 
                                else if (cbxTipoOrden.SelectedIndex == 2 && rbIngreso.Checked)
                                { 
                                    vTipoOrdenID = "S"; 
                                }
                                else if (cbxTipoOrden.SelectedIndex == 1 && rbSalida.Checked)
                                {
                                    vTipoOrdenID = "E";
                                }
                                else if (cbxTipoOrden.SelectedIndex == 2 && rbSalida.Checked)
                                {
                                    vTipoOrdenID = "P";
                                }
                                




                                BuscarOCGRView ocView = new BuscarOCGRView(Empresa.ID_EMPRESA, Convert.ToInt32(FiltroOC.Trim()), vTipoOrdenID, cbxTipoOrden.Text);

                                ocView.ShowDialog();

                                if (ocView.producto == "")
                                {
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrdenID"].Value = ocView._tipoOrdenID;
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrden"].Value = ocView._tipoOrden;
                                    dgvGRDetalle.CurrentRow.Cells["dgvIntIdEmpresaDet"].Value = ocView._idEmpresa;
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtSerie"].Value = txtSerie.Text.Trim();
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtNumero"].Value = txtNumero.Text.Trim();

                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtProveedor"].Value = "";
                                    dgvGRDetalle.CurrentRow.Cells["dgvIntSecuenciaDet"].Value = "";

                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtCodigoProducto"].Value = "";
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = "";
                                    dgvGRDetalle.CurrentRow.Cells["dgvCodCuenta"].Value = "";
                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantidad"].Value = "";
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtCodUM"].Value = "";
                                    dgvGRDetalle.CurrentRow.Cells["dgvDescPrecioUnitario"].Value = "";
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTotal"].Value = "";


                                    if (cbxTipoMovDefault.SelectedIndex == 0 || cbxTipoMovDefault.SelectedIndex == -1)
                                    {
                                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "ENTRADA";
                                        cbxTipoMovDefault.SelectedIndex = 0;
                                    }
                                    else if (cbxTipoMovDefault.SelectedIndex == 1)
                                    {
                                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "SALIDA";
                                    }
                                    else if (cbxTipoMovDefault.SelectedIndex == 2)
                                    {
                                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "DEVOLUCION";
                                    }


                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresada"].Value = 0;

                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresadoTotal"].Value = 0;
                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantSalidaTotal"].Value = 0;

                                    dgvGRDetalle.CurrentRow.Cells["dgvDecPesoIngresado"].Value = 0;
                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantidadSaldo"].Value = 0;

                                }
                                else
                                {
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrdenID"].Value = ocView._tipoOrdenID;
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrden"].Value = ocView._tipoOrden;

                                    dgvGRDetalle.CurrentRow.Cells["dgvIntIdEmpresaDet"].Value = ocView._idEmpresa;
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtSerie"].Value = txtSerie.Text.Trim();
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtNumero"].Value = txtNumero.Text.Trim();

                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtProveedor"].Value = ocView.proveedor;
                                    dgvGRDetalle.CurrentRow.Cells["dgvIntSecuenciaDet"].Value = ocView.secuencia;

                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtCodigoProducto"].Value = ocView.codProductoGeneral;
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = ocView.producto;
                                    dgvGRDetalle.CurrentRow.Cells["dgvCodCuenta"].Value = ocView.codCuenta;
                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantidad"].Value = ocView.cantidad;
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtCodUM"].Value = ocView.codUM;
                                    dgvGRDetalle.CurrentRow.Cells["dgvDescPrecioUnitario"].Value = ocView.precioUnitario;
                                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTotal"].Value = ocView.total;


                                    if (cbxTipoMovDefault.SelectedIndex == 0 || cbxTipoMovDefault.SelectedIndex == -1)
                                    {
                                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "ENTRADA";
                                        cbxTipoMovDefault.SelectedIndex = 0;
                                    }
                                    else if (cbxTipoMovDefault.SelectedIndex == 1)
                                    {
                                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "SALIDA";
                                    }
                                    else if (cbxTipoMovDefault.SelectedIndex == 2)
                                    {
                                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "DEVOLUCION";
                                    }

                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresada"].Value = 0;

                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresadoTotal"].Value = ocView.cantidadIngreso;
                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantSalidaTotal"].Value = ocView.cantidadSalida;

                                    dgvGRDetalle.CurrentRow.Cells["dgvDecPesoIngresado"].Value = 0;
                                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantidadSaldo"].Value = ocView.cantidadSaldo;

                                    PintarDataGridDetalle(dgvGRDetalle.CurrentRow.Index);

                                    dgvGRDetalle.CurrentCell = dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresada"];
                                }
                            }
                            else
                            {
                                ResponseMessage.Message("Ingrese la serie y número de la guía de remisión para buscar la orden de compra", "INFORMATION");
                            }
                        }
                    }
                    else
                    {
                        ResponseMessage.Message("Seleccione un tipo de orden de compra", "WARNING");
                    }

                }
                else
                {
                    ResponseMessage.Message("Ingrese un número de Orden de compra para la busqueda", "WARNING");
                }

            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                vTipoOrdenID = "";

                if (dgvGRDetalle.CurrentRow != null)
                {
                    DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar el item seleccionado?");

                    if (resultadoMensaje == DialogResult.OK)
                    {
                        // Insertar si no existe, en todo caso actualizar.
                        _grDetParam = new SetGRDetParam();

                        _grDetParam.opcion = 2; // Insertar / Actualizar.

                        _grDetParam.idEmpresa = Empresa.ID_EMPRESA;
                        _grDetParam.serie = dgvGRDetalle.CurrentRow.Cells["dgvTxtSerie"].Value.ToString();
                        _grDetParam.numero = dgvGRDetalle.CurrentRow.Cells["dgvTxtNumero"].Value.ToString();
                        _grDetParam.secuencia = Convert.ToInt32(dgvGRDetalle.CurrentRow.Cells["dgvTxtSecuenciaBD"].Value);
                        _grDetParam.tipoOrden = (dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrdenID"].Value.ToString() == "") ? textBox1.Text : dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrdenID"].Value.ToString();

                        Response respuesta = _referralGuideBL.SetGRDetalle(_grDetParam);

                        if (respuesta.idResponse == 0)
                        {
                            ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);
                        }

                        dgvGRDetalle.Rows.Clear();

                        if (cbxTipoOrden.SelectedIndex == 1 && rbIngreso.Checked )
                        {
                            vTipoOrdenID = "C"; // compra 
                        }
                        else if (cbxTipoOrden.SelectedIndex == 2 && rbIngreso.Checked)
                        {
                            vTipoOrdenID = "S"; // servicio
                        }
                        else if (cbxTipoOrden.SelectedIndex == 1 && rbSalida.Checked)
                        {
                            vTipoOrdenID = "E"; // pedido
                        }
                        else if (cbxTipoOrden.SelectedIndex == 2 && rbSalida.Checked)
                        {
                            vTipoOrdenID = "P"; // produccion
                        }
                        else
                        {
                            vTipoOrdenID = "";
                        }

                        ListarDetalle(Empresa.ID_EMPRESA, _grDetParam.serie, _grDetParam.numero, vTipoOrdenID);

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
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtTipoOrden"].Style.BackColor = Color.WhiteSmoke;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvIntIdEmpresaDet"].Style.BackColor = Color.WhiteSmoke;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtProveedor"].Style.BackColor = Color.WhiteSmoke;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvIntSecuenciaDet"].Style.BackColor = Color.WhiteSmoke;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtCodigoProducto"].Style.BackColor = Color.WhiteSmoke;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtProducto"].Style.BackColor = Color.WhiteSmoke;
            //dgvGRDetalle.Rows[rowIndex].Cells["dgvCodCuenta"].Style.BackColor = Color.WhiteSmoke;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvDecCantidad"].Style.BackColor = Color.WhiteSmoke;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtCodUM"].Style.BackColor = Color.WhiteSmoke;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvDescPrecioUnitario"].Style.BackColor = Color.WhiteSmoke;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtTotal"].Style.BackColor = Color.WhiteSmoke;

            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtTipoOrden"].ReadOnly = true;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvIntIdEmpresaDet"].ReadOnly = true;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtProveedor"].ReadOnly = true;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvIntSecuenciaDet"].ReadOnly = true;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtCodigoProducto"].ReadOnly = true;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtProducto"].ReadOnly = true;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvCodCuenta"].ReadOnly = false;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvDecCantidad"].ReadOnly = true;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtCodUM"].ReadOnly = true;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvDescPrecioUnitario"].ReadOnly = true;
            dgvGRDetalle.Rows[rowIndex].Cells["dgvTxtTotal"].ReadOnly = true;
        }


        private void dgvGRDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnEliminarGR_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSerie.Text.Trim()) &&
                !string.IsNullOrEmpty(txtNumero.Text.Trim()) &&
                cbxTipoOrden.SelectedIndex > 0)
            {
                DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar la GR " + txtSerie.Text.Trim() + "-" + txtNumero.Text.Trim() + "?");

                if (resultadoMensaje == DialogResult.OK)
                {
                    _grCabParam = new SetGRCabParam();

                    // Eliminar
                    _grCabParam.opcion = 2;

                    _grCabParam.idEmpresa = Empresa.ID_EMPRESA;
                    _grCabParam.serie = txtSerie.Text.Trim();
                    _grCabParam.numero = txtNumero.Text.Trim();

                    if (cbxTipoOrden.SelectedIndex == 1)
                    {
                        _grCabParam.tipoOrden = "C";
                    }
                    else if (cbxTipoOrden.SelectedIndex == 2)
                    {
                        _grCabParam.tipoOrden = "S";
                    }

                    Response responseGeneral = _referralGuideBL.SetGRCabecera(_grCabParam);

                    if (responseGeneral.idResponse > 0)
                    {
                        Limpiar();
                    }

                    ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
                }
            }
            else
            {
                ResponseMessage.Message("Ingrese un tipo de orden, serie y número de la Guía de Remision válida.", "WARNING");
            }
        }

        private void cbxTipoOrden_Leave(object sender, EventArgs e)
        {
            txtSerie.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cbxTipoOrden.SelectedIndex == 0)
            {
                ResponseMessage.Message("Seleccione el tipo de orden", "WARNING");
            }
            else if (string.IsNullOrEmpty(txtSerie.Text.Trim()))
            {
                ResponseMessage.Message("Ingrese la serie del documento", "WARNING");
            }
            else if (string.IsNullOrEmpty(txtNumero.Text.Trim()))
            {
                ResponseMessage.Message("Ingrese el número del documento", "WARNING");
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = @"C:\";
                sfd.Title = "Guardar Archivo Como";
                sfd.Filter = "Excel |*.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(sfd.FileName))
                    {
                        try
                        {
                            string tipoOrden = "";

                            string tipo_orden = "";
                            if (cbxTipoOrden.SelectedIndex == 1)
                            {
                                tipo_orden = "C";
                            }
                            else if (cbxTipoOrden.SelectedIndex == 2)
                            {
                                tipo_orden = "S";

                            }

                            GetGR2_CabeceraXCod grCab = _referralGuideBL.Get2_CabeceraXCod(Empresa.ID_EMPRESA, txtSerie.Text.Trim(), txtNumero.Text.Trim(), tipo_orden);

                            if (grCab.serie == "0")
                            {
                                ResponseMessage.Message("La guia ingresada no existe", "WARNING");
                            }
                            else
                            {
                                if (cbxTipoOrden.SelectedIndex == 1) { tipoOrden = "C"; } else if (cbxTipoOrden.SelectedIndex == 2) { tipoOrden = "S"; }
                                List<GetGR3_DetalleXCod> grDets = _referralGuideBL.Get3_DetalleXCod(Empresa.ID_EMPRESA, txtSerie.Text.Trim(), txtNumero.Text.Trim(), tipoOrden);

                                ExcelReport.ExportarGuiaRemision(sfd.FileName, grCab, grDets);
                            }

                            ResponseMessage.Message("Reporte Exportado", "INFORMATION");

                        }
                        catch (Exception ex)
                        {
                            ResponseMessage.Message(ex.Message, "ERROR");
                        }


                    }
                }

            }

        }


        // ENVIAR SUNAT
        private void btnEnviarNubefact_Click(object sender, EventArgs e)
        {

            Invoice invoice = new Invoice();


            invoice.operacion = "generar_guia";
            invoice.tipo_de_comprobante = 7;
            invoice.serie = grCabGenerales.serie;
            invoice.numero = Convert.ToInt32(grCabGenerales.numero);
            invoice.sunat_transaction = 1;
            //invoice.sunat_transaction = 2;

            invoice.cliente_tipo_de_documento = 6;
            //invoice.cliente_numero_de_documento = "20600695771";
            invoice.cliente_numero_de_documento = grCabGenerales.ruc;

            invoice.cliente_denominacion = grCabGenerales.descripcionCliente;
            invoice.cliente_direccion = grCabGenerales.direccionCliente;
            invoice.cliente_email = "demo@gmail.com";
            invoice.cliente_email_1 = "";
            invoice.cliente_email_2 = "";
            invoice.observaciones = grCabGenerales.observaciones;
            invoice.fecha_de_emision = Convert.ToDateTime(grCabGenerales.fechaEmision);
            if (grCabGenerales.fechaVencimiento != null)
            {
                invoice.fecha_de_vencimiento = Convert.ToDateTime(grCabGenerales.fechaVencimiento);
            }
            invoice.fecha_de_inicio_de_traslado = Convert.ToDateTime(grCabGenerales.fechaInicioTraslado);

            invoice.documento_relacionado_codigo = "50";//grCabGenerales.50;
            invoice.motivo_de_traslado = grCabGenerales.codMotivoTrasladoSunat;
            invoice.motivo_de_traslado_otros_descripcion = grCabGenerales.otrosMotivoTraslado;

            invoice.peso_bruto_total = "1";
            invoice.peso_bruto_unidad_de_medida = "KGM";
            invoice.numero_de_bultos = "1";
            invoice.tipo_de_transporte = cboTipoTransporte.SelectedValue.ToString();
            invoice.transportista_documento_tipo = "6";
            invoice.transportista_documento_numero = grCabGenerales.transCodigoPC;
            invoice.transportista_denominacion = grCabGenerales.transRS;
            invoice.tuc_vehiculo_principal = grCabGenerales.constanciaInscripcion;
            //invoice.transportista_placa_numero = "ABC444";
            invoice.transportista_placa_numero = grCabGenerales.transNumPlaca;

            invoice.conductor_documento_tipo = grCabGenerales.codTipoDocConductor != string.Empty ? Convert.ToInt32(grCabGenerales.codTipoDocConductor).ToString() : grCabGenerales.codTipoDocConductor;
            invoice.conductor_documento_numero = grCabGenerales.numdocConductor;
            invoice.conductor_nombre = grCabGenerales.nombresConductor;
            invoice.conductor_apellidos = grCabGenerales.apellidosConductor;
            invoice.conductor_numero_licencia = grCabGenerales.numeroLicenciaConducir;
            //invoice.punto_de_partida_ubigeo = "151021";
            invoice.punto_de_partida_ubigeo = "150103";

            //invoice.punto_de_partida_direccion = "DIRECCION PARTIDA";
            invoice.punto_de_partida_direccion = grCabGenerales.puntoPartida;

            invoice.punto_de_partida_codigo_establecimiento_sunat = "0000";
            invoice.punto_de_llegada_ubigeo = grCabGenerales.puntoLlegadaUbigeo;
            //invoice.punto_de_llegada_direccion = "DIRECCION LLEGADA";
            invoice.punto_de_llegada_direccion = grCabGenerales.puntoLlegada;

            invoice.punto_de_llegada_codigo_establecimiento_sunat = "0000";
            invoice.enviar_automaticamente_al_cliente = false;
            invoice.formato_de_pdf = "";
            //invoice.observaciones

            // OBTENEMOS ITEMS
            List<Items> itemsAgregar = new List<Items>();
            foreach (var item in grDetsGenerales)
            {
                Items itemNew = new Items();


                //itemNew.unidad_de_medida = (grCabGenerales.codMotivoTrasladoSunat == "08" || grCabGenerales.codMotivoTrasladoSunat == "09") ? item.codUmDam : item.codUM;
                //itemNew.unidad_de_medida = item.codUmDam;
                itemNew.unidad_de_medida = item.codUmDam.Trim();

                itemNew.codigo = item.codigoProducto;
                itemNew.descripcion = item.descripcion;
                if (item.cantidadIngresada < 0)
                {
                    itemNew.cantidad = (item.cantidadIngresada * -1);
                }
                else
                {
                    itemNew.cantidad = item.cantidadIngresada;
                }
                //itemNew.codigo_dam = grCabGenerales.DamDs;


                itemsAgregar.Add(itemNew);
            }


            invoice.items = itemsAgregar;

            string json = JsonConvert.SerializeObject(invoice, Formatting.Indented);
            Console.WriteLine(json);
            byte[] bytes = Encoding.Default.GetBytes(json);
            string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

            string json_de_respuesta = EnviarGuiaRemisionBL.SendJson(json_en_utf_8);
            dynamic r = JsonConvert.DeserializeObject<Respuesta>(json_de_respuesta);
            string r2 = JsonConvert.SerializeObject(r, Formatting.Indented);
            dynamic json_r_in = JsonConvert.DeserializeObject<Respuesta>(r2);


            dynamic leer_respuesta = JsonConvert.DeserializeObject<Respuesta>(json_de_respuesta);


            _grCabParam = new SetGRCabParam();
            _grCabParam.opcion = 4;
            _grCabParam.idEmpresa = Empresa.ID_EMPRESA;
            _grCabParam.serie = txtSerie.Text.Trim();
            _grCabParam.numero = txtNumero.Text.Trim();
            //_grCabParam.ruc = txtRuc.Text.Trim();

            if (leer_respuesta.errors == null)
            {
                _grCabParam.enviadoSunat = true;
                _grCabParam.respuestaSunat = "Enviado correctamente";
                Procesar(_grCabParam);
                ResponseMessage.Message("Guia Enviada correctamente", "INFORMATION");
            }
            else
            {
                _grCabParam.enviadoSunat = false;
                _grCabParam.respuestaSunat = leer_respuesta.errors;
                Procesar(_grCabParam);
                ResponseMessage.Message(leer_respuesta.errors, "WARNING");
            }


        }

        private void cbxTipoOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cbxTipoOrden.Text != "-- SELECCIONE --")
            {
                lblFiltro.Text = "Buscar por " + cbxTipoOrden.Text;
            }
            
        }

        private void cbxTipoMovDefault_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigoOrdenDefault_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCodigoOrdenDefault_Leave(object sender, EventArgs e)
        {
            cbxTipoMovDefault.Focus();
        }

        private void cbxTipoMovDefault_Leave(object sender, EventArgs e)
        {
            dgvGRDetalle.Focus();

            if (dgvGRDetalle.Rows.Count == 1)
            {
                // CODIGO DE ORDEN DE COMPRA
                string codigo = dgvGRDetalle.Rows[0].Cells["dgvTxtIdDet"].Value.ToString();
                if (codigo.ToString() == "")
                {
                    dgvGRDetalle.Rows[0].Cells["dgvTxtIdDet"].Value = txtCodigoOrdenDefault.Text;
                }

                // TIPO DE MOVIMIENTO
                if (cbxTipoMovDefault.SelectedIndex == 0 || cbxTipoMovDefault.SelectedIndex == -1)
                {
                    dgvGRDetalle.Rows[0].Cells["dgvTxtTipoMov"].Value = "ENTRADA";
                    cbxTipoMovDefault.SelectedIndex = 0;
                }
                else if (cbxTipoMovDefault.SelectedIndex == 1)
                {
                    dgvGRDetalle.Rows[0].Cells["dgvTxtTipoMov"].Value = "SALIDA";
                }
                else if (cbxTipoMovDefault.SelectedIndex == 2)
                {
                    dgvGRDetalle.Rows[0].Cells["dgvTxtTipoMov"].Value = "DEVOLUCION";
                }

            }



        }

        private void chkM13_CheckedChanged(object sender, EventArgs e)
        {
            bool check = chkM13.Checked;

            txtOtrosMotivos.Visible = check;
            if (check)
            {
                //txtOtrosMotivos.Clear();
                txtOtrosMotivos.Focus();
            }
        }

        private void dgvGRDetalle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string cantidad_ingreso = dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresada"].EditedFormattedValue.ToString();

            if (string.IsNullOrEmpty(cantidad_ingreso) && (dgvGRDetalle.Columns[e.ColumnIndex].Name.Equals("dgvTxtIdDet")))
            {
                if (cantidad_ingreso.ToString() == "0" || string.IsNullOrEmpty(cantidad_ingreso))
                {
                    if (cbxTipoMovDefault.SelectedIndex == 0 || cbxTipoMovDefault.SelectedIndex == -1)
                    {
                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "ENTRADA";
                        cbxTipoMovDefault.SelectedIndex = 0;
                    }
                    else if (cbxTipoMovDefault.SelectedIndex == 1)
                    {
                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "SALIDA";
                    }
                    else if (cbxTipoMovDefault.SelectedIndex == 2)
                    {
                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "DEVOLUCION";
                    }

                    string codigoOrden = dgvGRDetalle.CurrentRow.Cells["dgvTxtIdDet"].Value.ToString();
                    if (string.IsNullOrEmpty(codigoOrden))
                    {
                        dgvGRDetalle.CurrentRow.Cells["dgvTxtIdDet"].Value = txtCodigoOrdenDefault.Text;
                    }
                }
            }
        }

        void cargarcb()
        {
            cbxTipoOrden.Items.Clear();
            if (rbIngreso.Checked)
            {
                cbxTipoOrden.Items.Add("-- SELECCIONE --");
                cbxTipoOrden.Items.Add("ORDEN DE COMPRA");
                cbxTipoOrden.Items.Add("ORDEN DE SERVICIO");
            }
            else
            {
                cbxTipoOrden.Items.Add("-- SELECCIONE --");
                cbxTipoOrden.Items.Add("ORDEN DE PEDIDO");
                cbxTipoOrden.Items.Add("ORDEN DE PRODUCCION");
            }
            cbxTipoOrden.SelectedIndex = 0;
       
        }

        private void rbIngreso_CheckedChanged(object sender, EventArgs e)
        {
            cargarcb();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            //int n;
            //string vTipoOrdenID = "";
            //dgvGRDetalle.Rows.Add();
            //string FiltroOC = textBox1.Text; // dgvGRDetalle.CurrentRow.Cells["dgvTxtIdDet"].EditedFormattedValue.ToString();

            //if (!string.IsNullOrEmpty(FiltroOC))
            //{
            //    if (cbxTipoOrden.SelectedIndex > 0)
            //    {
            //        bool esNumero = int.TryParse(FiltroOC.Trim(), out n);

            //        if (esNumero)
            //        {
            //            if (!string.IsNullOrEmpty(txtSerie.Text.Trim()) && !string.IsNullOrEmpty(txtNumero.Text.Trim()))
            //            {
            //                VariableGeneral._sEnter = false;
            //                if (cbxTipoOrden.SelectedIndex == 1) { vTipoOrdenID = "C"; } else { vTipoOrdenID = "S"; }

            //                BuscarOCGRView ocView = new BuscarOCGRView(Empresa.ID_EMPRESA, Convert.ToInt32(FiltroOC.Trim()), vTipoOrdenID, cbxTipoOrden.Text);

            //                ocView.ShowDialog();

            //                if (!VariableGeneral._sEnter)
            //                {
            //                    return;
            //                }

            //                if (ocView.producto == "")
            //                {
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrdenID"].Value = ocView._tipoOrdenID;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrden"].Value = ocView._tipoOrden;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvIntIdEmpresaDet"].Value = ocView._idEmpresa;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtSerie"].Value = txtSerie.Text.Trim();
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtNumero"].Value = txtNumero.Text.Trim();

            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtProveedor"].Value = "";
            //                    dgvGRDetalle.CurrentRow.Cells["dgvIntSecuenciaDet"].Value = "";

            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtCodigoProducto"].Value = "";
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = "";
            //                    dgvGRDetalle.CurrentRow.Cells["dgvCodCuenta"].Value = "";
            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantidad"].Value = "";
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtCodUM"].Value = "";
            //                    dgvGRDetalle.CurrentRow.Cells["dgvDescPrecioUnitario"].Value = "";
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTotal"].Value = "";


            //                    if (cbxTipoMovDefault.SelectedIndex == 0 || cbxTipoMovDefault.SelectedIndex == -1)
            //                    {
            //                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "ENTRADA";
            //                        cbxTipoMovDefault.SelectedIndex = 0;
            //                    }
            //                    else if (cbxTipoMovDefault.SelectedIndex == 1)
            //                    {
            //                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "SALIDA";
            //                    }
            //                    else if (cbxTipoMovDefault.SelectedIndex == 2)
            //                    {
            //                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "DEVOLUCION";
            //                    }


            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresada"].Value = 0;

            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresadoTotal"].Value = 0;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantSalidaTotal"].Value = 0;

            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecPesoIngresado"].Value = 0;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantidadSaldo"].Value = 0;

            //                }
            //                else
            //                {
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtIdDet"].Value = textBox1.Text;
                                
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrdenID"].Value = ocView._tipoOrdenID;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoOrden"].Value = ocView._tipoOrden;

            //                    dgvGRDetalle.CurrentRow.Cells["dgvIntIdEmpresaDet"].Value = ocView._idEmpresa;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtSerie"].Value = txtSerie.Text.Trim();
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtNumero"].Value = txtNumero.Text.Trim();

            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtProveedor"].Value = ocView.proveedor;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvIntSecuenciaDet"].Value = ocView.secuencia;

            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtCodigoProducto"].Value = ocView.codProductoGeneral;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtProducto"].Value = ocView.producto;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvCodCuenta"].Value = ocView.codCuenta;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantidad"].Value = ocView.cantidad;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtCodUM"].Value = ocView.codUM;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvDescPrecioUnitario"].Value = ocView.precioUnitario;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvTxtTotal"].Value = ocView.total;


            //                    if (cbxTipoMovDefault.SelectedIndex == 0 || cbxTipoMovDefault.SelectedIndex == -1)
            //                    {
            //                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "ENTRADA";
            //                        cbxTipoMovDefault.SelectedIndex = 0;
            //                    }
            //                    else if (cbxTipoMovDefault.SelectedIndex == 1)
            //                    {
            //                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "SALIDA";
            //                    }
            //                    else if (cbxTipoMovDefault.SelectedIndex == 2)
            //                    {
            //                        dgvGRDetalle.CurrentRow.Cells["dgvTxtTipoMov"].Value = "DEVOLUCION";
            //                    }

            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresada"].Value = 0;

            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresadoTotal"].Value = ocView.cantidadIngreso;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantSalidaTotal"].Value = ocView.cantidadSalida;

            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecPesoIngresado"].Value = 0;
            //                    dgvGRDetalle.CurrentRow.Cells["dgvDecCantidadSaldo"].Value = ocView.cantidadSaldo;

            //                    PintarDataGridDetalle(dgvGRDetalle.CurrentRow.Index);

            //                    dgvGRDetalle.CurrentCell = dgvGRDetalle.CurrentRow.Cells["dgvDecCantIngresada"];
            //                }
            //            }
            //            else
            //            {
            //                ResponseMessage.Message("Ingrese la serie y número de la guía de remisión para buscar la orden de compra", "INFORMATION");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        ResponseMessage.Message("Seleccione un tipo de orden de compra", "WARNING");
            //    }

            //}
            //else
            //{
            //    ResponseMessage.Message("Ingrese un número de Orden de compra para la busqueda", "WARNING");
            //}
        }

        private void dgvGRDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
        }

        private void rbSalida_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
