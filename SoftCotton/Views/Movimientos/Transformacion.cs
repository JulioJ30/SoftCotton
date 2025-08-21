using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Model.Movimientos;
using SoftCotton.Model.ReferralGuide;
using SoftCotton.Model.Transformacion;
using SoftCotton.Repository;
using SoftCotton.Util;
using SoftCotton.Views.PurchaseOrder;
using SoftCotton.Views.ServiceOrder;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace SoftCotton.Views.Movimientos
{
    public partial class Transformacion : Form
    {
        GuiaRemisionBL _referralGuideBL;
        MantenimientoRepository _mantenimientoRepository;
        List<GetGR3_DetalleXCod> grDetsGenerales;
        List<OrdenCompraServicio> listOrdenCompraServicio = new List<OrdenCompraServicio>();


        public Transformacion()
        {
            InitializeComponent();

            _referralGuideBL = new GuiaRemisionBL();
            _mantenimientoRepository = new MantenimientoRepository();
        }


        private void Transformacion_Load(object sender, EventArgs e)
        {
            ListarNiveles();
            ListarTiposOrden();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDetalleGuias();
        }


        // BUSCAR DETALLE DE GUIAS
        private void BuscarDetalleGuias()
        {
            dgvOrigenItems.Columns["DgvCheck"].ReadOnly = false;


            string serie = txtSerieGuiaOrigen.Text.Trim();
            string numero = txtNumeroGuiaOrigen.Text.Trim();
            string rucProveedor = txtProveedorGuiaOrigen.Text.Trim();
            List<GetGR3_DetalleXCod> grDets = _referralGuideBL.Get3_DetalleXCod(Empresa.ID_EMPRESA, serie, numero, "C",10,"E", rucProveedor);
            grDetsGenerales = grDets;
            dgvOrigenItems.Rows.Clear();

            int count = 0;
            foreach (var item in grDets)
            {
                count++;
                int index = dgvOrigenItems.Rows.Add();

                dgvOrigenItems.Rows[index].Cells["item"].Value = index + 1;

                dgvOrigenItems.Rows[index].Cells["DgvCheck"].Value = false;
                dgvOrigenItems.Rows[index].Cells["DgvSecuencia"].Value = item.secuencia;
                dgvOrigenItems.Rows[index].Cells["CodigoItem"].Value = item.codigoProducto;
                dgvOrigenItems.Rows[index].Cells["Producto"].Value = item.producto;
                dgvOrigenItems.Rows[index].Cells["Cantidad"].Value = item.cantidadIngresada;

                if (count == 1)
                {
                    ListarDetallePorFiltro(new DetalleTransformacionFiltroPorBusquedaEntity
                    {
                        IdSencuenciaDet = item.secuencia,
                        Serie = serie,
                        Numero = int.Parse(numero.Trim()),
                        Proveedor = rucProveedor
                    }
                    );
                }

            }

        }

        private void ListarNiveles()
        {
            List<GetMant16_NivelCBX> nivelsOrigen = _mantenimientoRepository.Get16_NivelCBX();
            List<GetMant16_NivelCBX> nivelsDestino = _mantenimientoRepository.Get16_NivelCBX();



            // ORIGEN
            cboNivelOrigen.DataSource = nivelsOrigen;
            cboNivelOrigen.DisplayMember = "nivel";
            cboNivelOrigen.ValueMember = "codNivel";

            // DESTINO
            cboNivelDestino.DataSource = nivelsDestino;
            cboNivelDestino.DisplayMember = "nivel";
            cboNivelDestino.ValueMember = "codNivel";

        }

        private void ListarTiposOrden()
        {
            //  AGREGAMOS
            listOrdenCompraServicio.Add(new OrdenCompraServicio { IdTipo = 1, Tipo = "Orden Compra" });
            listOrdenCompraServicio.Add(new OrdenCompraServicio { IdTipo = 2, Tipo = "Orden Servicio" });

            // DESTINO
            cboTipoOrdenCompraServicio.DataSource = listOrdenCompraServicio;
            cboTipoOrdenCompraServicio.DisplayMember = "Tipo";
            cboTipoOrdenCompraServicio.ValueMember = "IdTipo";
        }


        private void btnAgregarItem_Click(object sender, EventArgs e)
        {

            bool haySeleccionados = dgvOrigenItems.Rows
                       .Cast<DataGridViewRow>()
                       .Any(r => !r.IsNewRow && Convert.ToBoolean(r.Cells["DgvCheck"].Value));

            if (!haySeleccionados)
            {
                ResponseMessage.Message("Debe seleccionar al menos un registro", "WARNING");
                return;
            }


            IngresoDeProductosPorNivel objFormulario = new IngresoDeProductosPorNivel();
            objFormulario.CodigoNivel = cboNivelDestino.SelectedValue.ToString();
            objFormulario.ShowDialog();

            //
            if (objFormulario.NivelParam != "")
            {

               


                foreach (DataGridViewRow row in dgvOrigenItems.Rows)
                {

                    if (!row.IsNewRow)
                    {
                        // Suponiendo que la columna CheckBox se llama "Seleccionar"
                        bool isChecked = Convert.ToBoolean(row.Cells["DgvCheck"].Value);

                        if (isChecked)
                        {

                            MovimientosRepository movimientosRepository = new MovimientosRepository();
                            RegistroTransformacionEntity detalleTransformacion = new RegistroTransformacionEntity
                            {
                                IdTransformacionCab = null,
                                Serie = txtSerieGuiaOrigen.Text.Trim(),
                                Numero = Convert.ToInt32(txtNumeroGuiaOrigen.Text.Trim()),
                                Proveedor = txtProveedorGuiaOrigen.Text.Trim(),
                                CodigoNivelOrigen = cboNivelOrigen.SelectedValue.ToString(),
                                CodigoNivelDestino = cboNivelDestino.SelectedValue.ToString(),
                                IdUsuario = UserApplication.ID_USUARIO,
                                //IdSecuenciaDet = Convert.ToInt32(dgvOrigenItems.CurrentRow.Cells["DgvSecuencia"].Value),
                                IdSecuenciaDet = Convert.ToInt32(row.Cells["DgvSecuencia"].Value),
                                CodNivel = objFormulario.NivelParam,
                                CodGrupo = objFormulario.GrupoParam,
                                CodTalla = objFormulario.TallaParam,
                                CodColor = objFormulario.ColorParam,
                                Cantidad = Convert.ToSingle(objFormulario.CantidadParam),
                                Comentario = objFormulario.ComentarioParam,
                                Pedido = $"{objFormulario.PedidoParam} {objFormulario.ColorPedidoParam} | {objFormulario.ProgramaParam} {objFormulario.EstiloParam}"
                            };

                            movimientosRepository.setRegistroTransformacion(detalleTransformacion);
                        }
                    }

                }

                // LUEGO DEL REGISTRO ACTUALIZAMOS
                BuscarDetalleGuias();




            }

        }

        private void ListarDetallePorFiltro(DetalleTransformacionFiltroPorBusquedaEntity filtros)
        {
            GuiaRemisionRepository guiaRemisionRepository = new GuiaRemisionRepository();

            List<DetalleTransformacionEntity> detalleTransformacion = guiaRemisionRepository.GetTransformacionDetPorFiltros(filtros).ToList();
            dgvDestinoItems.DataSource = detalleTransformacion;
        }

        private void dgvOrigenItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DetalleTransformacionFiltroPorBusquedaEntity filtros = new DetalleTransformacionFiltroPorBusquedaEntity();

            ////OBTENEMOS DATA DE FILTROS
            //filtros.IdSencuenciaDet = Convert.ToInt32(dgvOrigenItems.Rows[e.RowIndex].Cells["DgvSecuencia"].Value.ToString());
            //filtros.Serie       = txtSerieGuiaOrigen.Text.Trim();
            //filtros.Numero      = Convert.ToInt32(txtNumeroGuiaOrigen.Text.Trim());
            //filtros.Proveedor   = txtProveedorGuiaOrigen.Text.Trim();


            //ListarDetallePorFiltro(filtros);
        }


        private void dgvDestinoItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //VER 
            if (dgvDestinoItems.Columns[e.ColumnIndex].Name.Equals("DgvBtnTallas"))
            {
                TransformacionTallas frm = new TransformacionTallas();

                frm.IdTransformacionDetParam = Convert.ToInt32(dgvDestinoItems.Rows[e.RowIndex].Cells["DgvIdTransformacionDet"].Value);
                frm.ShowDialog();
            }
        }


        private bool ValidarCrearOrden()
        {
            bool validacion = false;
            string valorNivel = cboNivelDestino.SelectedValue.ToString();

            if ((valorNivel == string.Empty || valorNivel == "00") && !validacion)
            {
                ResponseMessage.Message("Ingrese el nivel de destino por favor", "WARNING");
                validacion = true;
            }

            if (txtSerieGuiaDestino.Text.Trim() == string.Empty && !validacion)
            {
                ResponseMessage.Message("Ingresa la serie Guia de destino por favor", "WARNING");
                validacion = true;
            }

            if (txtNumeroGuiaDestino.Text.Trim() == string.Empty && !validacion)
            {
                ResponseMessage.Message("Ingresa el número Guia de destino por favor", "WARNING");
                validacion = true;
            }

            //if (txtNumeroGuiaDestino.Text.Trim() == string.Empty && !validacion)
            //{
            //    ResponseMessage.Message("Ingresa el número Guia de destino por favor", "WARNING");
            //    validacion = true;
            //}


            return validacion;
        }

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {

            if(ValidarCrearOrden())
            {
                return;
            }


            //obtenemos valor
            string tipo = cboTipoOrdenCompraServicio.SelectedValue.ToString();
                
            // ORDEN COMPRA
            if (tipo == "1")
            {
                RegistroOCView frmOrdenCompra = new RegistroOCView();
                frmOrdenCompra.FlgCrearDeTransformacionInput = true;
                frmOrdenCompra.SerieGuia = txtSerieGuiaOrigen.Text.Trim();
                frmOrdenCompra.NumeroGuia = int.Parse(txtNumeroGuiaOrigen.Text.Trim());
                frmOrdenCompra.RucGuia = txtProveedorGuiaOrigen.Text.Trim();

                frmOrdenCompra.SerieGuiaDestino     = txtSerieGuiaDestino.Text.Trim();
                frmOrdenCompra.NumeroGuiaDestino    = int.Parse(txtNumeroGuiaDestino.Text.Trim());

                frmOrdenCompra.ShowDialog();
            }


            // ORDEN SERVICIO
            if (tipo == "2")
            {
                RegistroOSView frmOrdenServicio = new RegistroOSView();
                frmOrdenServicio.FlgCrearDeTransformacionInput = true;
                frmOrdenServicio.SerieGuia = txtSerieGuiaOrigen.Text.Trim();
                frmOrdenServicio.NumeroGuia = int.Parse(txtNumeroGuiaOrigen.Text.Trim());
                frmOrdenServicio.RucGuia = txtProveedorGuiaOrigen.Text.Trim();

                frmOrdenServicio.SerieGuiaDestino = txtSerieGuiaDestino.Text.Trim();
                frmOrdenServicio.NumeroGuiaDestino = int.Parse(txtNumeroGuiaDestino.Text.Trim());

                frmOrdenServicio.ShowDialog();
            }

        }

        private void dgvOrigenItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DetalleTransformacionFiltroPorBusquedaEntity filtros = new DetalleTransformacionFiltroPorBusquedaEntity();

            //OBTENEMOS DATA DE FILTROS
            filtros.IdSencuenciaDet = Convert.ToInt32(dgvOrigenItems.Rows[e.RowIndex].Cells["DgvSecuencia"].Value.ToString());
            filtros.Serie = txtSerieGuiaOrigen.Text.Trim();
            filtros.Numero = Convert.ToInt32(txtNumeroGuiaOrigen.Text.Trim());
            filtros.Proveedor = txtProveedorGuiaOrigen.Text.Trim();


            ListarDetallePorFiltro(filtros);

            if (e.RowIndex >= 0 && dgvOrigenItems.Columns[e.ColumnIndex].Name.Equals("DgvCheck"))
            {
                foreach (DataGridViewRow rowItem in dgvOrigenItems.Rows)
                {
                    if (rowItem.Index == e.RowIndex)
                    {
                        rowItem.Cells["DgvCheck"].Value = !Convert.ToBoolean(rowItem.Cells["DgvCheck"].Value);
                    }
                }
            }
        }
    }

    public class OrdenCompraServicio
    {
        public int IdTipo { get; set; }
        public string Tipo { get; set; }


    }

}
