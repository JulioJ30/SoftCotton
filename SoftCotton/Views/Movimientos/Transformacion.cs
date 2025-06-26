using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
using static ClosedXML.Excel.XLPredefinedFormat;

namespace SoftCotton.Views.Movimientos
{
    public partial class Transformacion : Form
    {
        GuiaRemisionBL _referralGuideBL;
        MantenimientoRepository _mantenimientoRepository;
        List<GetGR3_DetalleXCod> grDetsGenerales;


        public Transformacion()
        {
            InitializeComponent();

            _referralGuideBL = new GuiaRemisionBL();
            _mantenimientoRepository = new MantenimientoRepository();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDetalleGuias();
        }


        // BUSCAR DETALLE DE GUIAS
        private void BuscarDetalleGuias()
        {
            string serie = txtSerieGuiaOrigen.Text.Trim();
            string numero = txtNumeroGuiaOrigen.Text.Trim();
            List<GetGR3_DetalleXCod> grDets = _referralGuideBL.Get3_DetalleXCod(Empresa.ID_EMPRESA, serie, numero, "C",10);
            grDetsGenerales = grDets;
            dgvOrigenItems.Rows.Clear();


            foreach (var item in grDets)
            {
                int index = dgvOrigenItems.Rows.Add();

                dgvOrigenItems.Rows[index].Cells["item"].Value = index + 1;


                dgvOrigenItems.Rows[index].Cells["DgvSecuencia"].Value = item.secuencia;
                dgvOrigenItems.Rows[index].Cells["CodigoItem"].Value = item.codigoProducto;
                dgvOrigenItems.Rows[index].Cells["Producto"].Value = item.producto;
                dgvOrigenItems.Rows[index].Cells["Cantidad"].Value = item.cantidadIngresada;
                //dgvOrigenItems.Rows[index].Cells["dgvTxtSecuenciaBD"].Value = item.secuencia;

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

        private void Transformacion_Load(object sender, EventArgs e)
        {
            ListarNiveles();
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            IngresoDeProductosPorNivel objFormulario = new IngresoDeProductosPorNivel();
            objFormulario.CodigoNivel = cboNivelDestino.SelectedValue.ToString();
            objFormulario.ShowDialog();

            //
            if (objFormulario.NivelParam != "")
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
                    IdSecuenciaDet = Convert.ToInt32(dgvOrigenItems.CurrentRow.Cells["DgvSecuencia"].Value),
                    CodNivel = objFormulario.NivelParam,
                    CodGrupo = objFormulario.GrupoParam,
                    CodTalla = objFormulario.TallaParam,
                    CodColor = objFormulario.ColorParam,
                    Cantidad = Convert.ToSingle(objFormulario.CantidadParam),
                    Comentario = objFormulario.ComentarioParam
                };

                movimientosRepository.setRegistroTransformacion(detalleTransformacion);

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
            DetalleTransformacionFiltroPorBusquedaEntity filtros = new DetalleTransformacionFiltroPorBusquedaEntity();

            //OBTENEMOS DATA DE FILTROS
            filtros.IdSencuenciaDet = Convert.ToInt32(dgvOrigenItems.Rows[e.RowIndex].Cells["DgvSecuencia"].Value.ToString());
            filtros.Serie       = txtSerieGuiaOrigen.Text.Trim();
            filtros.Numero      = Convert.ToInt32(txtNumeroGuiaOrigen.Text.Trim());
            filtros.Proveedor   = txtProveedorGuiaOrigen.Text.Trim();


            ListarDetallePorFiltro(filtros);
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
    }
}
