using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.Model.Maintenance;
using SoftCotton.BusinessLogic;
using SoftCotton.Views.Maintenance;
using SoftCotton.Model.ServiceOrder;
using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Util;
using SoftCotton.Views.Shared;
using SoftCotton.Reports.ServiceOrder.OrdenServicio;



namespace SoftCotton.Views.ServiceOrder
{
    public partial class RegistroOSEspecialView : Form
    {

        MantenimientoBL _mantenimientoBL;
        List<GetMant21_Tallas> tallas = new List<GetMant21_Tallas>();
        List<GetOS5_TipoAprobacion> listaTiposAprobaciones;
        List<GetOS6_TipoAnulado> listaTiposAnulaciones;
        OrdenServicioBL _ordenServicioBL;
        GetOS15_FirmanteXNivel _firmanteInicial;
        GuiaRemisionBL _referralGuideBL;


        int ID_PrimerTipoAprobacion;
        string Nombre_PrimerTipoAprobacion;

        ConstantesBL _constantesBL;
        List<Constantes> CONSTANTES;
        Constantes constanteIGV = new Constantes();
        

        int indiceInicioTallas = 4;


        public RegistroOSEspecialView()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();
            _ordenServicioBL = new OrdenServicioBL();
            _firmanteInicial = new GetOS15_FirmanteXNivel();

            listaTiposAprobaciones = new List<GetOS5_TipoAprobacion>();
            listaTiposAnulaciones = new List<GetOS6_TipoAnulado>();


            _constantesBL = new ConstantesBL();
            CONSTANTES = new List<Constantes>();

            _referralGuideBL = new GuiaRemisionBL();


        }

        private void CalcularMontosFinales()
        {
            decimal subTotal = 0;

            foreach (DataGridViewRow row in dgvOSDetalle.Rows)
            {
                if (row.Cells["totalTalla"].Value != null && row.Cells["precio"].Value != null)
                {
                    subTotal += Convert.ToDecimal(row.Cells["total"].Value);
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


        private void RegistroOSEspecialView_Load(object sender, EventArgs e)
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

            // CARGAMOS TALLAS
            tallas = _mantenimientoBL.Get48_Tallas().ToList();
            CargarColumnas();

        }

        public void ValoresPredeterminados()
        {
            int nivelAprobacion = listaTiposAprobaciones.Where(x => x.estado).Min(x => x.nivelAprobacion);
            ID_PrimerTipoAprobacion = Convert.ToInt32(listaTiposAprobaciones.Where(x => x.estado && x.nivelAprobacion == nivelAprobacion).First().idTipoAprobacion.ToString());

            var tipoAprobacion = listaTiposAprobaciones.Find(x => x.idTipoAprobacion == ID_PrimerTipoAprobacion);
            if (tipoAprobacion != null) { Nombre_PrimerTipoAprobacion = tipoAprobacion.descripcion; }

            //this.dgvOSDetalle.Columns["dgvTxtItem"].ReadOnly = true;
            //this.dgvOSDetalle.Columns["dgvTxtUM"].ReadOnly = true;
            //this.dgvOSDetalle.Columns["dgvTxtTotal"].ReadOnly = true;

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

        private void CargarColumnas()
        {

            dgvOSDetalle.Columns.Add(setColumna("OP", "pedido"));
            dgvOSDetalle.Columns.Add(setColumna("Estilo", "codigoEstilo"));
            dgvOSDetalle.Columns.Add(setColumna("Nombre", "estilo"));
            dgvOSDetalle.Columns.Add(setColumna("Color", "color"));
            foreach (var item in tallas)
            {
                dgvOSDetalle.Columns.Add(setColumna(item.descripcion, item.descripcion));
            }
            dgvOSDetalle.Columns.Add(setColumna("Total Talla", "totalTalla"));
            dgvOSDetalle.Columns.Add(setColumna("Precio", "precio"));
            dgvOSDetalle.Columns.Add(setColumna("Total", "total"));
            dgvOSDetalle.Columns.Add(setColumna("idPedidoColor", "idPedidoColor",false));

            //dgvOSDetalle.Columns.Add(setColumna("Destinatario", "destinatario"));
            //dgvOSDetalle.Columns.Add(setColumna("idProcesoControlDespachoDet", "idProcesoControlDespachoDet", false));


        }

        public void ObtenerFirmanteInicial(int idUsuario, int nivelAprobacion)
        {
            _firmanteInicial = _ordenServicioBL.Get15_FirmanteXNivel(idUsuario, nivelAprobacion);
        }
        private DataGridViewTextBoxColumn setColumna(string titulo, string nombre, bool visible = true, bool tipofecha = false)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = titulo;
            col.Name = nombre;
            col.DataPropertyName = nombre;
            col.Visible = visible;
            return col;
        }

        private void dgvOSDetalle_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.B)
            {


                BuscarPedidosColorView frm = new BuscarPedidosColorView();
                frm.ShowDialog();
                dgvOSDetalle.CurrentRow.Cells["pedido"].Value = frm.pedidoParam.ToString();
                dgvOSDetalle.CurrentRow.Cells["codigoEstilo"].Value = frm.codigoEstiloParam.ToString();
                dgvOSDetalle.CurrentRow.Cells["estilo"].Value = frm.estiloParam.ToString();
                dgvOSDetalle.CurrentRow.Cells["color"].Value = frm.colorParam.ToString();
                dgvOSDetalle.CurrentRow.Cells["idPedidoColor"].Value = frm.idPedidoColorParam;

            }

        }

        private void calcularTotalPorFila(int indiceFila)
        {
            // REGISTRO NUEVO
            int indiceTotal = dgvOSDetalle.Columns["totalTalla"].Index;

            //int indiceFila = e.RowIndex;
            int cantidadTotal = 0;

            // SUMAMOS CANTIDADES
            for (int x = indiceInicioTallas; x < indiceTotal; x++)
            {
                string valor = dgvOSDetalle.Rows[indiceFila].Cells[x].Value != null ? dgvOSDetalle.Rows[indiceFila].Cells[x].Value.ToString() : "";
                cantidadTotal += (valor == "" ? 0 : Convert.ToInt32(valor));
            }

            // TOTAL POR TALLA
            dgvOSDetalle.Rows[indiceFila].Cells["totalTalla"].Value = cantidadTotal;

            // PRECIO
            decimal precio = dgvOSDetalle.Rows[indiceFila].Cells["precio"].Value != null ? Convert.ToDecimal(dgvOSDetalle.Rows[indiceFila].Cells["precio"].Value) : 0;

            // TOTAL TOTAL
            decimal totalTotal = cantidadTotal * precio;
            dgvOSDetalle.Rows[indiceFila].Cells["total"].Value = totalTotal;


            // CALCULAR MONTOS FINALES
            CalcularMontosFinales();
        }

        private void dgvOSDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calcularTotalPorFila(e.RowIndex);
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

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            BuscarProvClienteView provClienteView = new BuscarProvClienteView();
            provClienteView.ShowDialog();
            txtRUC.Text = provClienteView.codProvCliente;
            txtRS.Text = provClienteView.provCliente;
            txtDireccion.Text = provClienteView.direccion;

            txtObservacion.Focus();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
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
            bool respuesta = true;


            //bool respuesta = false;
            //bool seguirValidando = true;
            //int contador = 1;

            //double output;

            //foreach (DataGridViewRow row in dgvOSDetalle.Rows)
            //{
            //    if (contador < dgvOSDetalle.Rows.Count)
            //    {
            //        if (seguirValidando)
            //        {
            //            // 1. Validar Codigo de Producto
            //            if (row.Cells["dgvTxtCodGrupo"].Value != null)
            //            {
            //                if (row.Cells["dgvTxtCodGrupo"].Value.ToString().Trim() == "")
            //                {
            //                    respuesta = false;
            //                    seguirValidando = false;
            //                    ResponseMessage.Message("Ingrese un codigo de grupo", "WARNING");
            //                }
            //                else
            //                {
            //                    respuesta = true;
            //                }
            //            }
            //            else
            //            {
            //                respuesta = false;
            //                seguirValidando = false;
            //                ResponseMessage.Message("Ingrese un codigo de grupo", "WARNING");
            //            }

            //            // 2. Nombre de Producto
            //            if (respuesta)
            //            {
            //                if (row.Cells["dgvTxtProducto"].Value != null)
            //                {
            //                    if (row.Cells["dgvTxtProducto"].Value.ToString().Trim() == "")
            //                    {
            //                        respuesta = false;
            //                        seguirValidando = false;
            //                        ResponseMessage.Message("Ingrese el nombre de producto", "WARNING");
            //                    }
            //                    else
            //                    {
            //                        respuesta = true;
            //                    }
            //                }
            //                else
            //                {
            //                    respuesta = false;
            //                    seguirValidando = false;
            //                    ResponseMessage.Message("Ingresa el nombre de producto", "WARNING");
            //                }
            //            }

            //            // 3. Validar la cantidad 
            //            if (respuesta)
            //            {
            //                if (row.Cells["dgvDecCantidad"].Value != null)
            //                {
            //                    if (!double.TryParse(row.Cells["dgvDecCantidad"].Value.ToString(), out output))
            //                    {
            //                        respuesta = false;
            //                        seguirValidando = false;
            //                        ResponseMessage.Message("Ingresa la cantidad", "WARNING");
            //                    }
            //                    else
            //                    {
            //                        respuesta = true;
            //                    }
            //                }
            //                else
            //                {
            //                    respuesta = false;
            //                    seguirValidando = false;
            //                    ResponseMessage.Message("Ingresa la cantidad", "WARNING");
            //                }
            //            }

            //            // 4. Validar la Precio Unitario 
            //            if (respuesta)
            //            {
            //                if (row.Cells["dgvDescPrecioUnitario"].Value != null)
            //                {
            //                    if (!double.TryParse(row.Cells["dgvDescPrecioUnitario"].Value.ToString(), out output))
            //                    {
            //                        respuesta = false;
            //                        seguirValidando = false;
            //                        ResponseMessage.Message("Ingresa el Precio Unitario", "WARNING");
            //                    }
            //                    else
            //                    {
            //                        respuesta = true;
            //                    }
            //                }
            //                else
            //                {
            //                    respuesta = false;
            //                    seguirValidando = false;
            //                    ResponseMessage.Message("Ingresa el Precio Unitario", "WARNING");
            //                }
            //            }

            //        }
            //    }

            //    contador++;
            //}

            return respuesta;
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
            Response responseGeneral = _ordenServicioBL.SetOSEspecial(parametro);
            txtCodigo.Text = responseGeneral.idResponse.ToString();
            ProcesarDetalle(parametro.idEmpresa, responseGeneral.idResponse, 1, "");
            Limpiar();
            ValoresPredeterminados();
            BuscarOC(Empresa.ID_EMPRESA, responseGeneral.idResponse);

            // CALCULAMOS TOTALES POR FILA
            for (int x = 0; x < dgvOSDetalle.Rows.Count; x++)
            {
                calcularTotalPorFila(x);
            }

            CalcularMontosFinales();
            ResponseMessage.Message("Registrado Correctamente", "INFORMATION");

        }

        public void ProcesarDetalle(int idEmpresa, int idOC, int opcion, string tipoCompra)
        {

            // ELIMINAMOS DETALLE TALLAS
            SetOSParam delete = new SetOSParam();
            delete.opcion = 6;
            delete.idEmpresa = idEmpresa;
            delete.idOS = idOC;
            var responsedelete = _ordenServicioBL.SetOSEspecial(delete);

            // RECORREMOS

            for (int x = 0; x < dgvOSDetalle.Rows.Count - 1; x++)
            {
                SetOSParam detalle = new SetOSParam();

                detalle.opcion = 4;
                detalle.idEmpresa = idEmpresa;
                detalle.idOS = idOC;
                detalle.secuencia = (x+1);
                detalle.idPedidoColor = Convert.ToInt32(dgvOSDetalle.Rows[x].Cells["idPedidoColor"].Value);
                detalle.precio = dgvOSDetalle.Rows[x].Cells["precio"].Value != null  ? Convert.ToDecimal(dgvOSDetalle.Rows[x].Cells["precio"].Value) : 0;


                var response = _ordenServicioBL.SetOSEspecial(detalle);


                // REGISTRAMOS DETALLE DE TALLAS
                int indiceTotal = dgvOSDetalle.Columns["totalTalla"].Index;

                // RECORREMOS DETALLE DE TALLAS
                for (int y = indiceInicioTallas; y < indiceTotal; y++)
                {
                    string valor = dgvOSDetalle.Rows[x].Cells[y].Value == null ? "0" : dgvOSDetalle.Rows[x].Cells[y].Value.ToString();
                    string nombreTalla = dgvOSDetalle.Columns[y].Name;
                    if (valor != "")
                    {
                        SetOSParam detalletalla = new SetOSParam();
                        detalletalla.opcion = 5;
                        detalletalla.idEmpresa = idEmpresa;
                        detalletalla.idOS = idOC;
                        detalletalla.secuencia = (x + 1);
                        detalletalla.cantidad = Convert.ToInt32(valor);

                        // BUSCAMOS TALLAS
                        string codTalla = tallas.Find(obj => obj.descripcion == nombreTalla).codTalla;
                        detalletalla.codTalla = codTalla;
                        var responseTalla = _ordenServicioBL.SetOSEspecial( detalletalla);

                    }

                }



            }
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


        private void BuscarOC(int idEmpresa, int codigoOC)
        {
            GetOS7_OSCabXCodigo ocCab = _ordenServicioBL.Get7_OCCabXCodigoEspecial(idEmpresa, codigoOC);

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

            //ListarFirmantes(Empresa.ID_EMPRESA, codigoOC);
            ListarDetalle(Empresa.ID_EMPRESA, codigoOC);
        }


        private void ListarDetalle(int idempresa,int codigoos)
        {
            DataTable dt =  _ordenServicioBL.Get7_OCDeetXCodigoEspecial(idempresa,codigoos);
            // CARGAMOS
            dgvOSDetalle.Rows.Clear();

            for (int x = 0; x < dt.Rows.Count ; x++)
            {
                int index = dgvOSDetalle.Rows.Add();

                // RECORREMSO COLUMANS
                foreach (DataGridViewColumn col in dgvOSDetalle.Columns)
                {
                    string nombreColumna = col.Name;
                    dgvOSDetalle.Rows[index].Cells[nombreColumna].Value = dt.Rows[x][nombreColumna].ToString();
                }

                calcularTotalPorFila(index);


            }

            // CALCULAMOS TOTALES POR FILA
            //for (int x = 0; x < dgvOSDetalle.Rows.Count; x++)
            //{
            //    calcularTotalPorFila(x);
            //}

            CalcularMontosFinales();


        }

        private void btnEliminarOS_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text.Trim() != "")
            {
                // ELIMINAMOS TODA LA OS
                SetOSParam delete = new SetOSParam();
                delete.opcion = 7;
                delete.idEmpresa = Empresa.ID_EMPRESA;
                delete.idOS = Convert.ToInt32(txtCodigo.Text.Trim());
                var responsedelete = _ordenServicioBL.SetOSEspecial(delete);

                Limpiar();
                ValoresPredeterminados();

                txtCodigo.Text = "";
                txtCodigo.Enabled = true;
                txtCodigo.BackColor = Color.LightBlue;
                txtCodigo.Focus();

                ResponseMessage.Message("Eliminado correctamente", "INFORMATION");

            }
            else
            {
                        ResponseMessage.Message("Ingrese una OS","WARNING");

            }


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                if (Convert.ToInt32(txtCodigo.Text) > 0)
                {
                    Cursor = Cursors.WaitCursor;

                    OrdenServicioRpteViewV2 ocPDF = new OrdenServicioRpteViewV2(Convert.ToInt32(txtCodigo.Text));
                    ocPDF.ShowDialog();
                    Cursor = Cursors.Default;
                }
                else
                {
                    ResponseMessage.Message("No existe orden de servicio", "WARNING");
                }
            }
            else
            {
                ResponseMessage.Message("No existe orden de servicio", "WARNING");
            }
        }
    }
}
