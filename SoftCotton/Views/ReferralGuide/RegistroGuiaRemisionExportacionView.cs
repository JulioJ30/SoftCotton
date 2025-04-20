using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SoftCotton.Model.ReferralGuide;
using SoftCotton.Util;
using SoftCotton.Views.Shared;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using excel = Microsoft.Office.Interop.Excel;
using SoftCotton.Reports.RemittanceGuide.ExportGuide;


using Newtonsoft.Json;
using System.Text;



namespace SoftCotton.Views.ReferralGuide
{
    public partial class RegistroGuiaRemisionExportacionView : Form
    {
        MantenimientoBL _mantenimientoBL = new MantenimientoBL();

        GuiaRemisionExportacionBL _referralGuideBL;
        MantenimientoBL _referraMantBL;

        SetGRCabExportacionParam _grCabParam;
        SetGRDetExportacionParam _grDetParam;

        List<GetGR3_DetalleXCod> grDetsGenerales;
        GetGR2_CabeceraXCod grCabGenerales;

        bool nuuevoregistro = true;
        DataTable dtReporte;

        public RegistroGuiaRemisionExportacionView()
        {
            InitializeComponent();

            _referralGuideBL = new GuiaRemisionExportacionBL();
            _referraMantBL = new MantenimientoBL();
        }


        // GUARDAMOS CAMBIOS
        private void GuardarCambios()
        {
            if (ValidarDatosCabecera() && ValidarDatosDetalle())
            {
                _grCabParam = new SetGRCabExportacionParam();
                _grCabParam.opcion = 1;
                _grCabParam.idEmpresa = Empresa.ID_EMPRESA;
                _grCabParam.serie = txtSerie.Text.Trim();
                _grCabParam.numero = txtNumero.Text.Trim();
                _grCabParam.ruc = txtRuc.Text.Trim();
                _grCabParam.fechaEmision = dtpFechaEmision.Value.ToString("yyyyMMdd");
                _grCabParam.puntoPartida = txtPuntoPartida.Text.Trim();
                _grCabParam.puntoLlegada = txtPuntoLlegada.Text.Trim();
                _grCabParam.fechaInicioTraslado = dtpFechaInicioTraslado.Value.ToString("yyyyMMdd");
                _grCabParam.destCodigoPC = txtRucDestinatario.Text.Trim();
                _grCabParam.transCodigoPC = txtRucEmpresaTransporte.Text.Trim();
                _grCabParam.transMarca = txtMarca.Text;
                _grCabParam.transNumPlaca = txtNumPlaca.Text;
                _grCabParam.idConstanciaInscripcion = Convert.ToInt32(cboConstanciaInscripcion.SelectedValue.ToString());
                _grCabParam.idNumeroLicenciaConducir = Convert.ToInt32(cboLicenciaConducir.SelectedValue.ToString());
                _grCabParam.usuarioReg = UserApplication.USUARIO;
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
                else if (chkM6.Checked)
                {
                    _grCabParam.idMotivoTraslado = 4;
                }
                else if (chkM9.Checked)
                {
                    _grCabParam.idMotivoTraslado = 5;
                }
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
                else
                {
                    _grCabParam.idMotivoTraslado = 0;
                }
                if (string.IsNullOrEmpty(txtNumContenedor.Text))
                {
                    _grCabParam.numero_contenedor = "";
                }
                else
                {
                    _grCabParam.numero_contenedor = txtNumContenedor.Text;
                }
                if (string.IsNullOrEmpty(txtPrecintoAduana.Text))
                {
                    _grCabParam.precinto_aduana = "";
                }
                else
                {
                    _grCabParam.precinto_aduana = txtPrecintoAduana.Text;
                }
                if (string.IsNullOrEmpty(txtPrecintoLinea.Text))
                {
                    _grCabParam.precinto_linea = "";
                }
                else
                {
                    _grCabParam.precinto_linea = txtPrecintoLinea.Text;
                }
                if (string.IsNullOrEmpty(txtPrecinto.Text))
                {
                    _grCabParam.precinto = "";
                }
                else
                {
                    _grCabParam.precinto = txtPrecinto.Text;
                }
                if (string.IsNullOrEmpty(txtTotal.Text))
                {
                    _grCabParam.total = 0m;
                }
                else
                {
                    _grCabParam.total = Convert.ToDecimal(txtTotal.Text);
                }
                if (string.IsNullOrEmpty(txtGrossWeight.Text))
                {
                    _grCabParam.gross_weight = 0m;
                }
                else
                {
                    _grCabParam.gross_weight = Convert.ToDecimal(txtGrossWeight.Text);
                }
                if (string.IsNullOrEmpty(txtNetWeight.Text))
                {
                    _grCabParam.net_weight = 0m;
                }
                else
                {
                    _grCabParam.net_weight = Convert.ToDecimal(txtNetWeight.Text);
                }
                _grCabParam.total_um = cbxTotalUM.SelectedValue.ToString();
                _grCabParam.gross_weight_um = cbxGrossWeightUM.SelectedValue.ToString();
                _grCabParam.net_weight_um = cbxNetWeightUM.SelectedValue.ToString();

                // AGREGADO
                _grCabParam.fechaVencimiento = dtpFechaVencimiento.Value.ToString("yyyyMMdd");
                _grCabParam.observaciones = txtObservaciones.Text.Trim();
                _grCabParam.otrosMotivoTraslado = txtOtros.Text.Trim();
                _grCabParam.DamDs = txtDamDua.Text.Trim();
                Procesar(_grCabParam);
            }
        }

        // PROCESAR DATOS PARA REGISTROS DE CABECERA
        public void Procesar(SetGRCabExportacionParam parametro)
        {
            Response responseGeneral = _referralGuideBL.SetGRCabeceraExportacion(parametro);
            if (responseGeneral.idResponse > 0)
            {
                ProcesarDetalle(Empresa.ID_EMPRESA, parametro.serie, parametro.numero, parametro.ruc);
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        // PROCESAR DATOS PARA REGISTROS DE DETALLE
        private void ProcesarDetalle(int idEmpresa, string serie, string numero, string ruc)
        {
            Response respuestaDetalle = new Response();
            bool estadoProceso = true;
            int contador = 1;

            foreach (DataGridViewRow row in dgvGRDetalle.Rows)
            {
                if (estadoProceso && (contador < dgvGRDetalle.Rows.Count))
                {
                    // Insertar si no existe, en todo caso actualizar.
                    _grDetParam = new SetGRDetExportacionParam();

                    _grDetParam.opcion = 1; // Insertar / Actualizar.

                    _grDetParam.idEmpresa = Empresa.ID_EMPRESA;
                    _grDetParam.serie = serie;
                    _grDetParam.numero = numero;
                    _grDetParam.ruc = ruc;

                    _grDetParam.secuencia = row.Cells["Secuencia"].Value == null ? 0 : Convert.ToInt32(row.Cells["Secuencia"].Value);

                    _grDetParam.codProducto = row.Cells["codigoProducto"].Value.ToString();
                    _grDetParam.descripcion = row.Cells["dgvTxtProducto"].Value.ToString();
                    _grDetParam.cantidadIngresada = Convert.ToDecimal(row.Cells["dgvDecCantidad"].Value);
                    _grDetParam.codUM = row.Cells["dgvTxtUnidadMedida"].Value.ToString();
                    _grDetParam.OP = row.Cells["OP"].Value.ToString();


                    respuestaDetalle = _referralGuideBL.SetGRDetalleExportacion(_grDetParam);

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

            dgvGRDetalle.Rows.Clear();
            //ListarDetalle(Empresa.ID_EMPRESA, _grCabParam.serie, _grCabParam.numero, _grCabParam.ruc);

            // BUSCAMOS GUIAS FINAL
            BuscarGuias();
        }

        // VALIDAMOS DATOS DE CABECERA
        private bool ValidarDatosCabecera()
        {
            bool respuesta = false;
            double esdouble = 0;
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
            else if (string.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                respuesta = false;
                ResponseMessage.Message("Ingrese el numero de RUC", "WARNING");
            }
            else if (string.IsNullOrEmpty(cbxTotalUM.SelectedValue.ToString()) || cbxTotalUM.SelectedValue.ToString() == "000")
            {
                respuesta = false;
                ResponseMessage.Message("Seleccione la UM del total", "WARNING");
            }
            else if (string.IsNullOrEmpty(cbxGrossWeightUM.SelectedValue.ToString()) || cbxGrossWeightUM.SelectedValue.ToString() == "000")
            {
                respuesta = false;
                ResponseMessage.Message("Seleccione la UM Gross Weight", "WARNING");
            }
            else if (!double.TryParse(txtGrossWeight.Text.Trim(), out esdouble))
            {
                respuesta = false;
                ResponseMessage.Message("Ingrese un valor correcto para Gross Weight ", "WARNING");
            }
            else if (string.IsNullOrEmpty(cbxNetWeightUM.SelectedValue.ToString()) || cbxNetWeightUM.SelectedValue.ToString() == "000")
            {
                respuesta = false;
                ResponseMessage.Message("Seleccione la UM Net Weight", "WARNING");
            }
            else if (!double.TryParse(txtNetWeight.Text.Trim(), out esdouble))
            {
                respuesta = false;
                ResponseMessage.Message("Ingrese un valor correcto para Net Weight ", "WARNING");
            }
            else if (dgvGRDetalle.Rows.Count == 0)
            {
                respuesta = false;
                ResponseMessage.Message("La Guía de Remisión no tiene detalle", "WARNING");
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        // VALIDAMOS DATOS DE DETALLE
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
                        // VALIDAMOS LA UNIDAD DE MEDIDA
                        if (row.Cells["dgvTxtUnidadMedida"].Value != null)
                        {
                            if (row.Cells["dgvTxtUnidadMedida"].Value.ToString().Trim() == "")
                            {
                                respuesta = false;
                                seguirValidando = false;
                                ResponseMessage.Message("No tiene especificado la unidad de medida", "WARNING");
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
                            ResponseMessage.Message("No tiene especificado la unidad de medida", "WARNING");
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

                        // 4. Codigo de Productos
                        if (respuesta)
                        {
                            if (row.Cells["codigoProducto"].Value != null)
                            {
                                if (row.Cells["codigoProducto"].Value.ToString().Trim() == "")
                                {
                                    respuesta = false;
                                    seguirValidando = false;
                                    ResponseMessage.Message("Ingrese el codigo de producto", "WARNING");
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
                                ResponseMessage.Message("Ingresa el codigo de producto", "WARNING");
                            }
                        }


                    }
                }

                contador++;
            }

            return respuesta;

        }


        // BUSCAR PROVEEDOR DESTINO
        private void btnBuscarProvDest_Click(object sender, EventArgs e)
        {
            BuscarProvClienteView provClienteView = new BuscarProvClienteView();

            provClienteView.ShowDialog();
            txtRucDestinatario.Text = provClienteView.codProvCliente;
            txtRazonSocialDestinatario.Text = provClienteView.provCliente;
            txtPuntoLlegada.Text = provClienteView.direccion;

            txtMarca.Focus();
        }


        // BUSCAR EMPRESA TRANSPORTES
        private void btnBuscarEmpresaTransportes_Click(object sender, EventArgs e)
        {
            BuscarProvClienteView provClienteView = new BuscarProvClienteView();

            provClienteView.ShowDialog();
            txtRucEmpresaTransporte.Text = provClienteView.codProvCliente;
            txtNombreEmpresaTransporte.Text = provClienteView.provCliente;
            //txtPuntoLlegada.Text = provClienteView.direccion;

            //txtMarca.Focus();
        }

        // LOAD DE DATAGRID
        private void RegistroGuiaRemisionExportacionView_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn comboboxColumn = dgvGRDetalle.Columns["dgvTxtUnidadMedida"] as DataGridViewComboBoxColumn;

            List<GetMant19_UMCBX> unidadesMed = _referraMantBL.Get19_UMCBX();
            List<GetMant19_UMCBX> unidadesMed2 = _referraMantBL.Get19_UMCBX();
            List<GetMant19_UMCBX> unidadesMed3 = _referraMantBL.Get19_UMCBX();
            List<GetMant19_UMCBX> unidadesMed4 = _referraMantBL.Get19_UMCBX();

            comboboxColumn.DataSource = unidadesMed;
            comboboxColumn.DisplayMember = "descripcion";
            comboboxColumn.ValueMember = "codUM";

            cbxTotalUM.DataSource = unidadesMed2;
            cbxTotalUM.DisplayMember = "descripcion";
            cbxTotalUM.ValueMember = "codUM";

            cbxGrossWeightUM.DataSource = unidadesMed3;
            cbxGrossWeightUM.DisplayMember = "descripcion";
            cbxGrossWeightUM.ValueMember = "codUM";

            cbxNetWeightUM.DataSource = unidadesMed4;
            cbxNetWeightUM.DisplayMember = "descripcion";
            cbxNetWeightUM.ValueMember = "codUM";

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


        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            GuardarCambios();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarGuias();
        }

        private void BuscarGuias()
        {
            if (!string.IsNullOrEmpty(txtSerie.Text.Trim()) && !string.IsNullOrEmpty(txtNumero.Text.Trim()) && !string.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                GetGR2_CabeceraXCod grCab = _referralGuideBL.Get2_CabeceraXCod(Empresa.ID_EMPRESA, txtSerie.Text.Trim(), txtNumero.Text.Trim(), txtRuc.Text.Trim());
                if (grCab.idEmpresa == 0 && grCab.serie.Trim() == "0" && grCab.numero.Trim() == "0")
                {
                    ResponseMessage.Message("La guía de remisión no existe", "WARNING");
                    return;
                }

                txtSerie.Text = grCab.serie;
                txtNumero.Text = grCab.numero;
                dtpFechaEmision.Value = Convert.ToDateTime(grCab.fechaEmision).Date;
                txtPuntoPartida.Text = grCab.puntoPartida;
                txtPuntoLlegada.Text = grCab.puntoLlegada;
                dtpFechaInicioTraslado.Value = Convert.ToDateTime(grCab.fechaInicioTraslado).Date;
                if (grCab.fechaVencimiento != null)
                {
                    dtpFechaVencimiento.Value = Convert.ToDateTime(grCab.fechaVencimiento).Date;

                }

                txtRucDestinatario.Text = grCab.destCodigoPC;
                txtRazonSocialDestinatario.Text = grCab.destRS;
                txtMarca.Text = grCab.transMarca;
                txtNumPlaca.Text = grCab.transNumPlaca;
                cboConstanciaInscripcion.SelectedValue = grCab.idConstanciaInscripcion;
                cboLicenciaConducir.SelectedValue = grCab.idNumeroLicenciaConducir;
                txtRucEmpresaTransporte.Text = grCab.transCodigoPC;
                txtNombreEmpresaTransporte.Text = grCab.transRS;
                marcandoOpcionMotivo(grCab.idMotivoTraslado);
                txtNumContenedor.Text = grCab.numero_contenedor;
                txtPrecintoAduana.Text = grCab.precinto_aduana;
                txtPrecintoLinea.Text = grCab.precinto_linea;
                txtPrecinto.Text = grCab.precinto;
                txtTotal.Text = grCab.total.ToString();
                txtGrossWeight.Text = grCab.gross_weight.ToString();
                txtNetWeight.Text = grCab.net_weight.ToString();
                cbxTotalUM.SelectedValue = grCab.total_um;
                cbxGrossWeightUM.SelectedValue = grCab.gross_weight_um;
                cbxNetWeightUM.SelectedValue = grCab.net_weight_um;
                txtObservaciones.Text = grCab.observaciones;
                txtOtros.Text = grCab.otrosMotivoTraslado;
                txtDamDua.Text = grCab.DamDs;
                //txtDamDs.Text = grCab.DamDs;

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



                // MOSTRAMOS DETALLE
                grCabGenerales = grCab;
                ListarDetalle(Empresa.ID_EMPRESA, grCab.serie, grCab.numero, grCab.ruc);

                btnGuardar.Text = "Modificar";
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = true;

                btnEnviarNubefact.Enabled = !grCab.enviadoSunat;

            }
            else
            {
                ResponseMessage.Message("Ingrese una serie y número de guía de remisión valida", "WARNING");
            }
        }

        private void ListarDetalle(int idEmpresa, string serie, string numero, string ruc)
        {

            List<GetGR3_DetalleXCod> grDets = _referralGuideBL.Get3_DetalleXCod(idEmpresa, serie, numero, ruc);

            // CARGAMOS DETALLES
            grDetsGenerales = grDets;

            dgvGRDetalle.Rows.Clear();
            double total_cantidad = default(double);
            foreach (GetGR3_DetalleXCod item in grDets)
            {
                int index = dgvGRDetalle.Rows.Add();
                dgvGRDetalle.Rows[index].Cells["codigoProducto"].Value = item.codigoProducto;
                dgvGRDetalle.Rows[index].Cells["dgvTxtProducto"].Value = item.descripcion;
                dgvGRDetalle.Rows[index].Cells["dgvDecCantidad"].Value = item.cantidadIngresada;
                dgvGRDetalle.Rows[index].Cells["dgvTxtUnidadMedida"].Value = item.codUM;
                dgvGRDetalle.Rows[index].Cells["Secuencia"].Value = item.secuencia;
                dgvGRDetalle.Rows[index].Cells["OP"].Value = item.OP;

                total_cantidad = total_cantidad + item.cantidadIngresada;
            }
            lblCantidadTotal.Text = total_cantidad.ToString();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            nuuevoregistro = !nuuevoregistro;

        }

        private void LimpiarCampos()
        {
            txtRuc.Clear();
            txtSerie.Clear();
            txtNumero.Clear();
            txtPuntoPartida.Clear();
            txtPuntoLlegada.Clear();
            txtRazonSocialDestinatario.Clear();
            txtRucDestinatario.Clear();
            txtMarca.Clear();
            txtNumPlaca.Clear();
            txtNombreEmpresaTransporte.Clear();
            txtRucEmpresaTransporte.Clear();
            dgvGRDetalle.Rows.Clear();
            btnGuardar.Text = "Guardar";
            marcandoOpcionMotivo(0);
            txtNumContenedor.Clear();
            txtPrecintoAduana.Clear();
            txtPrecintoLinea.Clear();
            txtPrecinto.Clear();
            txtTotal.Clear();
            txtGrossWeight.Clear();
            txtNetWeight.Clear();
            lblCantidadTotal.Text = "0";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSerie.Text.Trim()) && !string.IsNullOrEmpty(txtNumero.Text.Trim()) && !string.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar la GR " + txtSerie.Text.Trim() + "-" + txtNumero.Text.Trim() + "?");

                if (resultadoMensaje == DialogResult.OK)
                {
                    _grCabParam = new SetGRCabExportacionParam();

                    // Eliminar
                    _grCabParam.opcion = 2;

                    _grCabParam.idEmpresa = Empresa.ID_EMPRESA;
                    _grCabParam.serie = txtSerie.Text.Trim();
                    _grCabParam.numero = txtNumero.Text.Trim();
                    _grCabParam.ruc = txtRuc.Text.Trim();


                    Response responseGeneral = _referralGuideBL.SetGRCabeceraExportacion(_grCabParam);

                    if (responseGeneral.idResponse > 0)
                    {
                        LimpiarCampos();
                    }

                    ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
                }
            }
            else
            {
                ResponseMessage.Message("Ingrese la serie y número de la Guía de Remision válida.", "WARNING");
            }
        }

        private void btnBuscarProvDest_Click_1(object sender, EventArgs e)
        {
            BuscarProvClienteView provClienteView = new BuscarProvClienteView();

            provClienteView.ShowDialog();
            txtRucDestinatario.Text = provClienteView.codProvCliente;
            txtRazonSocialDestinatario.Text = provClienteView.provCliente;
            txtPuntoLlegada.Text = provClienteView.direccion;

            txtMarca.Focus();
        }

        private void btnBuscarEmpresaTransportes_Click_1(object sender, EventArgs e)
        {
            BuscarProvClienteView provClienteView = new BuscarProvClienteView();

            provClienteView.ShowDialog();
            txtRucEmpresaTransporte.Text = provClienteView.codProvCliente;
            txtNombreEmpresaTransporte.Text = provClienteView.provCliente;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //string filePath = "C:\\MyExcelFile.xlsx";
            ExportToExcel(dtReporte);
        }



        public void ExportToExcel(DataTable dataTable)
        {
            // Crea una instancia de Excel
            excel.Application excel = new excel.Application();

            // Crea un nuevo libro de trabajo
            excel.Workbook workbook = excel.Workbooks.Add();

            // Crea una nueva hoja de trabajo
            excel.Worksheet worksheet = (excel.Worksheet)workbook.ActiveSheet;

            // Escribir los encabezados de las columnas
            int columnIndex = 0;
            foreach (DataColumn column in dataTable.Columns)
            {
                columnIndex++;
                worksheet.Cells[1, columnIndex] = column.ColumnName;
            }

            // Escribir los datos en la hoja de trabajo
            int rowIndex = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                rowIndex++;
                columnIndex = 0;
                foreach (DataColumn column in dataTable.Columns)
                {
                    columnIndex++;
                    worksheet.Cells[rowIndex, columnIndex] = row[column.ColumnName].ToString();
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Guardar archivo";
            saveFileDialog.FileName = "MyExcelFile.xlsx";
            //saveFileDialog.InitialDirectory = @"C:\";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                // Guarda el libro de trabajo en el archivo especificado
                workbook.SaveAs(filePath);
                //using (StreamWriter writer = new StreamWriter(filePath))
                //{
                //    writer.Write(content);
                //}
            }



            // Cierra Excel
            excel.Quit();
        }

        private void btnBuscarReporte_Click(object sender, EventArgs e)
        {
            string opcion = rdbRangoFechas.Checked ? "1" : "2";
            string filtro1 = "";
            string filtro2 = "";
            string filtro3 = "";

            if (opcion == "1")
            {
                filtro1 = dtpFechaInicioFiltro.Value.ToString("yyyy-MM-dd");
                filtro2 = dtpFechafinFiltro.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                filtro1 = txtRucFiltro.Text.Trim();
                filtro2 = txtSerieFiltro.Text.Trim();
                filtro3 = txtNumeroFiltro.Text.Trim();

            }

            // CARGAMOS REPORTE
            dtReporte = _referralGuideBL.Get8_ReporteExportacion(opcion, filtro1, filtro2, filtro3);
            dgvDataReporte.DataSource = dtReporte;
        }

        private void rdbRangoFechas_CheckedChanged(object sender, EventArgs e)
        {

            gbFiltroFechas.Enabled = rdbRangoFechas.Checked;
            gbFiltroFiltros.Enabled = !rdbRangoFechas.Checked;

            if (rdbRangoFechas.Checked)
            {
                txtRucFiltro.Clear();
                txtSerieFiltro.Clear();
                txtNumeroFiltro.Clear();

            }
        }

        private void dgvGRDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            int aa = Convert.ToInt32(dgvGRDetalle.CurrentRow.Cells["dgvDecCantidad"].Value);


            //if (e.Control && e.KeyCode == Keys.G)
            //{
            //    GuardarCambios();
            //}
            //if (!e.Control || e.KeyCode != Keys.D || dgvGRDetalle.CurrentRow == null)
            //{
            //    return;
            //}
            //DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar el item seleccionado?");
            //if (resultadoMensaje == DialogResult.OK)
            //{
            //    _grDetParam = new SetGRDetExportacionParam();
            //    _grDetParam.opcion = 2;
            //    _grDetParam.idEmpresa = Empresa.ID_EMPRESA;
            //    _grDetParam.serie = txtSerie.Text.Trim();
            //    _grDetParam.numero = txtNumero.Text.Trim();
            //    _grDetParam.secuencia = Convert.ToInt32(dgvGRDetalle.CurrentRow.Cells["Secuencia"].Value);
            //    _grDetParam.ruc = txtRuc.Text.Trim();
            //    Response respuesta = _referralGuideBL.SetGRDetalleExportacion(_grDetParam);
            //    if (respuesta.idResponse == 0)
            //    {
            //        ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);
            //    }
            //    dgvGRDetalle.Rows.Clear();
            //    ListarDetalle(Empresa.ID_EMPRESA, _grDetParam.serie, _grDetParam.numero, _grDetParam.ruc);
            //}
        }


        private void btnCargarDetalle_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cargar Excel";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                excel.Application xlApp = new excel.Application();
                excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
                excel._Worksheet xlWorksheet = (excel._Worksheet)xlWorkbook.Sheets[1];
                excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;


                List<GetGR3_DetalleXCod> detalle = new List<GetGR3_DetalleXCod>();

                // CARGAMOS DATA EN LISTA
                for (int x = 3; x < rowCount; x++)
                {

                    string celdaCodigo = "A" + x.ToString();
                    string celdaDescripcion = "B" + x.ToString();
                    string celdaCantidad = "G" + x.ToString();
                    string celdaUnidadMedida = "H" + x.ToString();

                    excel.Range cellCodigo = xlWorksheet.Range[celdaCodigo];
                    excel.Range cellDescripcion = xlWorksheet.Range[celdaDescripcion];
                    excel.Range cellCantidad = xlWorksheet.Range[celdaCantidad];
                    excel.Range cellUnidadMedida = xlWorksheet.Range[celdaUnidadMedida];

                    if (cellCodigo.Value != null)
                    {
                        GetGR3_DetalleXCod item = new GetGR3_DetalleXCod();
                        item.codigoProducto = cellCodigo.Value.ToString().Trim();
                        item.descripcion = cellDescripcion.Value.ToString().Trim();
                        item.cantidadIngresada = Convert.ToInt32(cellCantidad.Value.ToString().Trim());
                        item.codUM = cellUnidadMedida.Value.ToString().Trim();

                        detalle.Add(item);
                    }
                }

                // ASIGANMOS DATA DE LISTA A DATAGRID
                foreach (var item in detalle)
                {
                    int index = dgvGRDetalle.Rows.Add();


                    dgvGRDetalle.Rows[index].Cells["codigoProducto"].Value = item.codigoProducto;
                    dgvGRDetalle.Rows[index].Cells["dgvTxtProducto"].Value = item.descripcion;
                    dgvGRDetalle.Rows[index].Cells["dgvDecCantidad"].Value = item.cantidadIngresada;
                    dgvGRDetalle.Rows[index].Cells["dgvTxtUnidadMedida"].Value = item.codUM;
                    dgvGRDetalle.Rows[index].Cells["Secuencia"].Value = item.secuencia;
                }

            }


        }

        private void chkM1_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(1);
        }

        private void chkM2_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(2);
        }

        private void chkM3_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(3);
        }

        private void chkM4_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(4);
        }

        private void chkM5_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(5);
        }

        private void chkM6_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(6);
        }

        private void chkM7_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(7);
        }

        private void chkM8_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(8);
        }

        private void chkM9_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(9);
        }

        private void chkM10_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(10);
        }

        private void chkM11_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(11);
        }

        private void chkM12_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(12);
        }

        private void chkM13_Click(object sender, EventArgs e)
        {
            marcandoOpcionMotivo(13);
        }

        private void marcandoOpcionMotivo(int opcion)
        {
            chkM1.Checked = false;
            chkM2.Checked = false;
            chkM3.Checked = false;
            //chkM4.Checked = false;
            //chkM5.Checked = false;
            chkM6.Checked = false;
            //chkM7.Checked = false;
            //chkM8.Checked = false;
            chkM9.Checked = false;
            //chkM10.Checked = false;
            chkM11.Checked = false;
            chkM12.Checked = false;
            chkM13.Checked = false;
            switch (opcion)
            {
                case 1:
                    chkM1.Checked = true;
                    break;
                case 2:
                    chkM2.Checked = true;
                    break;
                case 3:
                    chkM3.Checked = true;
                    break;
                //case 4:
                //    chkM4.Checked = true;
                //    break;
                //case 5:
                //    chkM5.Checked = true;
                //    break;
                case 6:
                    chkM6.Checked = true;
                    break;
                //case 7:
                //    chkM7.Checked = true;
                //    break;
                //case 8:
                //    chkM8.Checked = true;
                //    break;
                case 9:
                    chkM9.Checked = true;
                    break;
                //case 10:
                //    chkM10.Checked = true;
                //    break;
                case 11:
                    chkM11.Checked = true;
                    break;
                case 12:
                    chkM12.Checked = true;
                    break;
                case 13:
                    chkM13.Checked = true;
                    break;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRuc.Text) && !string.IsNullOrEmpty(txtSerie.Text) && !string.IsNullOrEmpty(txtNumero.Text))
            {
                Cursor = Cursors.WaitCursor;
                GuiaRemisionExportacionPrintView ocPDF = new GuiaRemisionExportacionPrintView(txtRuc.Text, txtSerie.Text, txtNumero.Text);
                ocPDF.ShowDialog();
                Cursor = Cursors.Default;
            }
            else
            {
                ResponseMessage.Message("No existe orden de compra", "WARNING");
            }
        }

        private void btnEnviarNubefact_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();


            invoice.operacion = "generar_guia";
            invoice.tipo_de_comprobante = 7;
            invoice.serie = grCabGenerales.serie;
            invoice.numero = Convert.ToInt32(grCabGenerales.numero);
            //invoice.sunat_transaction = 1;
            invoice.sunat_transaction = 2;

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
            invoice.fecha_de_vencimiento = Convert.ToDateTime(grCabGenerales.fechaVencimiento);
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
            //invoice.transportista_placa_numero = "ABC444";
            invoice.transportista_placa_numero = grCabGenerales.transNumPlaca;

            invoice.conductor_documento_tipo = grCabGenerales.codTipoDocConductor;
            invoice.conductor_documento_numero = grCabGenerales.numdocConductor;
            invoice.conductor_nombre = grCabGenerales.nombresConductor;
            invoice.conductor_apellidos = grCabGenerales.apellidosConductor;
            invoice.conductor_numero_licencia = grCabGenerales.transNumLicConducir;
            invoice.punto_de_partida_ubigeo = "151021";
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


                itemNew.unidad_de_medida = (grCabGenerales.codMotivoTrasladoSunat == "08" || grCabGenerales.codMotivoTrasladoSunat == "09") ? item.codUmDam : item.codUM;

                itemNew.codigo = item.codigoProducto;
                itemNew.descripcion = item.descripcion;
                itemNew.cantidad = item.cantidadIngresada;
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


            _grCabParam = new SetGRCabExportacionParam();
            _grCabParam.opcion = 3;
            _grCabParam.idEmpresa = Empresa.ID_EMPRESA;
            _grCabParam.serie = txtSerie.Text.Trim();
            _grCabParam.numero = txtNumero.Text.Trim();
            _grCabParam.ruc = txtRuc.Text.Trim();

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

        private void chkM13_CheckedChanged(object sender, EventArgs e)
        {
            txtOtros.Visible = chkM13.Checked;
            txtOtros.Focus();

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
            nuuevoregistro = !nuuevoregistro;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSerie.Text.Trim()) && !string.IsNullOrEmpty(txtNumero.Text.Trim()) && !string.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                DialogResult resultadoMensaje = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar la GR " + txtSerie.Text.Trim() + "-" + txtNumero.Text.Trim() + "?");

                if (resultadoMensaje == DialogResult.OK)
                {
                    _grCabParam = new SetGRCabExportacionParam();

                    // Eliminar
                    _grCabParam.opcion = 2;

                    _grCabParam.idEmpresa = Empresa.ID_EMPRESA;
                    _grCabParam.serie = txtSerie.Text.Trim();
                    _grCabParam.numero = txtNumero.Text.Trim();
                    _grCabParam.ruc = txtRuc.Text.Trim();


                    Response responseGeneral = _referralGuideBL.SetGRCabeceraExportacion(_grCabParam);

                    if (responseGeneral.idResponse > 0)
                    {
                        LimpiarCampos();
                    }

                    ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
                }
            }
            else
            {
                ResponseMessage.Message("Ingrese la serie y número de la Guía de Remision válida.", "WARNING");
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRuc.Text) && !string.IsNullOrEmpty(txtSerie.Text) && !string.IsNullOrEmpty(txtNumero.Text))
            {
                Cursor = Cursors.WaitCursor;
                GuiaRemisionExportacionPrintView ocPDF = new GuiaRemisionExportacionPrintView(txtRuc.Text, txtSerie.Text, txtNumero.Text);
                ocPDF.ShowDialog();
                Cursor = Cursors.Default;
            }
            else
            {
                ResponseMessage.Message("No existe orden de compra", "WARNING");
            }
        }

        private void btnEnviarNubefact_Click_1(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();


            invoice.operacion = "generar_guia";
            invoice.tipo_de_comprobante = 7;
            invoice.serie = grCabGenerales.serie;
            invoice.numero = Convert.ToInt32(grCabGenerales.numero);
            //invoice.sunat_transaction = 1;
            invoice.sunat_transaction = 2;

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
            invoice.fecha_de_vencimiento = Convert.ToDateTime(grCabGenerales.fechaVencimiento);
            invoice.fecha_de_inicio_de_traslado = Convert.ToDateTime(grCabGenerales.fechaInicioTraslado);

            //invoice.documento_relacionado_codigo = "50";//grCabGenerales.50;
            invoice.motivo_de_traslado = grCabGenerales.codMotivoTrasladoSunat;
            invoice.motivo_de_traslado_otros_descripcion = grCabGenerales.otrosMotivoTraslado;

            invoice.peso_bruto_total = grCabGenerales.gross_weight.ToString();
            invoice.peso_bruto_unidad_de_medida = "KGM";
            invoice.numero_de_bultos = "1";
            invoice.tipo_de_transporte = cboTipoTransporte.SelectedValue.ToString();
            invoice.transportista_documento_tipo = "6";
            invoice.transportista_documento_numero = grCabGenerales.transCodigoPC;
            invoice.transportista_denominacion = grCabGenerales.transRS;
            //invoice.transportista_placa_numero = "ABC444";
            invoice.transportista_placa_numero = grCabGenerales.transNumPlaca;

            invoice.conductor_documento_tipo = grCabGenerales.codTipoDocConductor;
            invoice.conductor_documento_numero = grCabGenerales.numdocConductor;
            invoice.conductor_nombre = grCabGenerales.nombresConductor;
            invoice.conductor_apellidos = grCabGenerales.apellidosConductor;
            invoice.conductor_numero_licencia = grCabGenerales.transNumLicConducir;

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

            if (grCabGenerales.idMotivoTraslado == 6 || grCabGenerales.idMotivoTraslado == 7)
            {
                invoice.documento_relacionado_codigo = "50";
            }

            // OBTENEMOS ITEMS
            List<Items> itemsAgregar = new List<Items>();
            foreach (var item in grDetsGenerales)
            {
                Items itemNew = new Items();

                itemNew.codigo_dam = grCabGenerales.DamDs;
                itemNew.unidad_de_medida = (grCabGenerales.codMotivoTrasladoSunat == "08" || grCabGenerales.codMotivoTrasladoSunat == "09") ? item.codUmDam : item.codUM;

                itemNew.codigo = item.codigoProducto;
                itemNew.descripcion = item.descripcion;
                itemNew.cantidad = item.cantidadIngresada;
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


            _grCabParam = new SetGRCabExportacionParam();
            _grCabParam.opcion = 3;
            _grCabParam.idEmpresa = Empresa.ID_EMPRESA;
            _grCabParam.serie = txtSerie.Text.Trim();
            _grCabParam.numero = txtNumero.Text.Trim();
            _grCabParam.ruc = txtRuc.Text.Trim();

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

        private void btnCargarDetalle_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cargar Excel";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                excel.Application xlApp = new excel.Application();
                excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
                excel._Worksheet xlWorksheet = (excel._Worksheet)xlWorkbook.Sheets[1];
                excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                DataTable tblStock;
                List<GetGR3_DetalleXCod> detalle = new List<GetGR3_DetalleXCod>();

                // CARGAMOS DATA EN LISTA
                for (int x = 3; x <= rowCount; x++)
                {

                    string celdaCodigo = "A" + x.ToString();
                    string celdaDescripcion = "B" + x.ToString();
                    string celdaCantidad = "G" + x.ToString();
                    string celdaUnidadMedida = "H" + x.ToString();
                    string celdaOp              = "I" + x.ToString();


                    excel.Range cellCodigo          = xlWorksheet.Range[celdaCodigo];
                    excel.Range cellDescripcion     = xlWorksheet.Range[celdaDescripcion];
                    excel.Range cellCantidad        = xlWorksheet.Range[celdaCantidad];
                    excel.Range cellUnidadMedida    = xlWorksheet.Range[celdaUnidadMedida];
                    excel.Range cellOp              = xlWorksheet.Range[celdaOp];


                    if (cellCodigo.Value != null)
                    {
                        GetGR3_DetalleXCod item = new GetGR3_DetalleXCod();
                        item.codigoProducto = cellCodigo.Value.ToString().Trim();
                        item.descripcion = cellDescripcion.Value.ToString().Trim();
                        item.cantidadIngresada = Convert.ToInt32(cellCantidad.Value.ToString().Trim());
                        item.codUM = cellUnidadMedida.Value.ToString().Trim();
                        item.OP = cellOp.Value.ToString().Trim();



                        if (Empresa.Validar_stock_exportacion)
                        {
                            tblStock = _mantenimientoBL.SetDatatable(71, cellCodigo.Value.ToString().Trim(), "", 0, 0);

                            if (Convert.ToInt32(cellCantidad.Value.ToString().Trim()) > Convert.ToInt32(tblStock.Rows[0][0].ToString()))
                            {
                                ResponseMessage.Message("No cuenta con stock el siguiente producto " + cellDescripcion.Value.ToString(), "WARNING");
                                return;
                            }
                        }



                        detalle.Add(item);
                    }
                }

                // ASIGANMOS DATA DE LISTA A DATAGRID
                foreach (var item in detalle)
                {
                    int index = dgvGRDetalle.Rows.Add();
                    dgvGRDetalle.Rows[index].Cells["codigoProducto"].Value = item.codigoProducto;
                    dgvGRDetalle.Rows[index].Cells["dgvTxtProducto"].Value = item.descripcion;
                    dgvGRDetalle.Rows[index].Cells["dgvDecCantidad"].Value = item.cantidadIngresada;
                    dgvGRDetalle.Rows[index].Cells["dgvTxtUnidadMedida"].Value = item.codUM;
                    dgvGRDetalle.Rows[index].Cells["OP"].Value = item.OP;
                    dgvGRDetalle.Rows[index].Cells["Secuencia"].Value = item.secuencia;
                }
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkM12_CheckedChanged(object sender, EventArgs e)
        {
            txtDamDua.Visible = chkM12.Checked;
            txtDamDua.Focus();
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            MantenimientoBL _mantenimientoBL = new MantenimientoBL();
            DataTable tbl = _mantenimientoBL.SetDatatable(69, txtidOrden.Text, "", 0, 0);

            List<GetGR3_DetalleXCod> detalle = new List<GetGR3_DetalleXCod>();


            foreach (DataRow row in tbl.Rows)
            {
                // Crear una nueva instancia de GetGR3_DetalleXCod
                GetGR3_DetalleXCod item = new GetGR3_DetalleXCod();

                // Asignar los valores de las columnas del DataTable a las propiedades del objeto
                item.codigoProducto = row["codGrupoAlt"].ToString().Trim();
                item.descripcion = row["grupo"].ToString().Trim();
                item.cantidadIngresada = Convert.ToDouble(row["cantidad"].ToString().Trim());
                item.codUM = row["codUM"].ToString().Trim();

                // Añadir el objeto a la lista
                detalle.Add(item);
            }


            // ASIGANMOS DATA DE LISTA A DATAGRID
            foreach (var item in detalle)
            {
                int index = dgvGRDetalle.Rows.Add();


                dgvGRDetalle.Rows[index].Cells["codigoProducto"].Value = item.codigoProducto;
                dgvGRDetalle.Rows[index].Cells["dgvTxtProducto"].Value = item.descripcion;
                dgvGRDetalle.Rows[index].Cells["dgvDecCantidad"].Value = item.cantidadIngresada;
                dgvGRDetalle.Rows[index].Cells["dgvTxtUnidadMedida"].Value = item.codUM;
                dgvGRDetalle.Rows[index].Cells["Secuencia"].Value = item.secuencia;
            }
        }

        private void dgvGRDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvGRDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGRDetalle.CurrentRow != null)
            {
                if (dgvGRDetalle.Columns[e.ColumnIndex].Name.Equals("dgvDecCantidad"))
                {
                    if (dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value != null && dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value != null)
                    {
                        string cellCodigo = dgvGRDetalle.Rows[e.RowIndex].Cells["codigoProducto"].Value.ToString();
                        double cellCantidad = Convert.ToDouble(dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value);
                        string cellDescripcion = dgvGRDetalle.Rows[e.RowIndex].Cells["dgvTxtProducto"].Value.ToString();

                        if (Empresa.Validar_stock_exportacion)
                        {
                            DataTable tblStock;
                            tblStock = _mantenimientoBL.SetDatatable(71, cellCodigo.ToString().Trim(), "", 0, 0);

                            if (Convert.ToDouble(cellCantidad.ToString().Trim()) > Convert.ToInt32(tblStock.Rows[0][0].ToString()))
                            {
                                dgvGRDetalle.Rows[e.RowIndex].Cells["dgvDecCantidad"].Value = 0;
                                ResponseMessage.Message("No cuenta con stock el siguiente producto " + cellDescripcion.ToString(), "WARNING");
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void dgvGRDetalle_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvGRDetalle.Columns["Quitar"].Index && e.RowIndex >= 0)
                {
                    // Elimina la fila seleccionada
                    dgvGRDetalle.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void dgvGRDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
