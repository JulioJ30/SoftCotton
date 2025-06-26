using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Charts;
using SoftCotton.Model.Maintenance;
using SoftCotton.Model.Movimientos;
using SoftCotton.Repository;
using SoftCotton.Util;

namespace SoftCotton.Views.Movimientos
{
    public partial class IngresoDeTelas : Form
    {

        List<MovimientosDetalle> listMovimientosDetalle;
        MantenimientoRepository mantenimientoRepository = new MantenimientoRepository();
        MovimientosRepository movimientosRepository = new MovimientosRepository();
        int IdCabecera = 0;

        public IngresoDeTelas()
        {
            InitializeComponent();
        }

        private void IngresoDeTelas_Load(object sender, EventArgs e)
        {
            listMovimientosDetalle = new List<MovimientosDetalle>();
            getTipoMovimientos();

        }


        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            IngresoDeProductosPorNivel objFormulario = new IngresoDeProductosPorNivel();
            objFormulario.CodigoNivel = "03";
            objFormulario.ShowDialog();

            // AGREGAMOS VALORES A DGV
            if (objFormulario.NivelParam != "")
            {

                // LIMPIAMOS
                dgvItem.Rows.Clear();

                // AGREGAMOS A TMP
                MovimientosDetalle item = new MovimientosDetalle();
                item.CodigoNivel = objFormulario.NivelParam;
                item.CodGrupo = objFormulario.GrupoParam;
                item.CodColor = objFormulario.ColorParam;
                item.CodTalla = objFormulario.TallaParam;

                item.Cantidad = objFormulario.CantidadParam;
                item.PartidaProveedor = objFormulario.PartidaProveedorParam;
                item.Producto = objFormulario.ProductoParam;
                item.Pedido = objFormulario.PedidoParam;
                item.PedidoColor = objFormulario.ColorPedidoParam;

                item.Estilo = objFormulario.EstiloParam;
                item.Programa = objFormulario.ProgramaParam;
                item.Comentario = objFormulario.ComentarioParam;
                item.IdPedidoColor = objFormulario.IdPedidoColorParam;



                listMovimientosDetalle.Add(item);


                // LISTAMOS
                ListarDetalle(listMovimientosDetalle);

            }

            

        }

        public void ListarDetalle(List<MovimientosDetalle> ListDetalle)
        {
            foreach (var item in ListDetalle)
            {
                int index = dgvItem.Rows.Add();
                
                dgvItem.Rows[index].Cells["item"].Value = index +1;


                dgvItem.Rows[index].Cells["IdPedidoColor"].Value = item.IdPedidoColor;
                dgvItem.Rows[index].Cells["CodigoNivel"].Value = item.CodigoNivel;
                dgvItem.Rows[index].Cells["CodGrupo"].Value = item.CodGrupo;
                dgvItem.Rows[index].Cells["CodColor"].Value = item.CodColor;
                dgvItem.Rows[index].Cells["CodTalla"].Value = item.CodTalla;
                dgvItem.Rows[index].Cells["Cantidad"].Value = item.Cantidad;
                dgvItem.Rows[index].Cells["PartidaProveedor"].Value = item.PartidaProveedor;
                dgvItem.Rows[index].Cells["Producto"].Value = item.Producto;
                dgvItem.Rows[index].Cells["Pedido"].Value = item.Pedido;
                dgvItem.Rows[index].Cells["PedidoColor"].Value = item.PedidoColor;

                dgvItem.Rows[index].Cells["Estilo"].Value = item.Estilo;
                dgvItem.Rows[index].Cells["Programa"].Value = item.Programa;
                dgvItem.Rows[index].Cells["Comentario"].Value = item.Comentario;


                //if (item.estado)
                //{
                //dgvPedidos.Rows[index].Cells["estado"].Value = true;
                dgvItem.Rows[index].Cells["btnEditarItem"].Style.BackColor = Color.MediumSeaGreen;
                dgvItem.Rows[index].Cells["btnEditarItem"].Style.SelectionBackColor = Color.MediumSeaGreen;
                //}
                //else
                //{
                //dgvPedidos.Rows[index].Cells["estado"].Value = false;
                dgvItem.Rows[index].Cells["btnEliminarItem"].Style.BackColor = Color.Red;
                dgvItem.Rows[index].Cells["btnEliminarItem"].Style.SelectionBackColor = Color.Red;
                //}

            }
        }

        private void getTipoMovimientos()
        {
            IEnumerable<GetMant73_TiposMovimientos>  listMovimientos  =  mantenimientoRepository.getTiposMovimientos();
            cboTipoMovimiento.DataSource = listMovimientos;
            cboTipoMovimiento.DisplayMember = "DescripcionTipoMovimiento";
            cboTipoMovimiento.ValueMember = "IdTipoMovimiento";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarMovimiento();
        }


        private void GuardarMovimiento()
        {
            
            MovimientosCabecera cab = new MovimientosCabecera();
            cab.IdMovimientoCabecera = IdCabecera;
            cab.IdTipoMovimiento = int.Parse(cboTipoMovimiento.SelectedValue.ToString());
            cab.FechaMovimiento = dtpFechaMovimiento.Value;
            cab.Comentario = txtComentario.Text;

            // RECORREMOS
            List<MovimientosDetalle> listDetalle = new List<MovimientosDetalle>();
            foreach (var item in listMovimientosDetalle)
            {
                MovimientosDetalle param = new MovimientosDetalle();

                param.CodigoNivel = item.CodigoNivel;
                param.CodGrupo = item.CodGrupo;
                param.CodTalla = item.CodTalla;
                param.CodColor = item.CodColor;
                param.Cantidad = item.Cantidad;
                param.Comentario = item.Comentario;
                param.IdPedidoColor = item.IdPedidoColor;
                param.PartidaProveedor = item.PartidaProveedor;

                listDetalle.Add(param);

            }

            bool response =  movimientosRepository.setRegistroMovimientosTela(cab, listDetalle, UserApplication.ID_USUARIO);
            if (response)
            {
                ResponseMessage.Message("Realizado correctamente", "INFORMATION");
                Limpiar();
            }
            else
            {
                ResponseMessage.Message("Ocurrio un error en el proceso", "WARNING");
            }

        }


        private void Limpiar()
        {
            txtComentario.Clear();
            dgvItem.Rows.Clear();
            listMovimientosDetalle = new List<MovimientosDetalle>();

            btnNuevo.Visible = true;
            btnCancelar.Visible = false;
            btnBuscar.Visible = true;
            btnGuardar.Visible = false;

            IdCabecera = 0;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Visible = false;
            btnCancelar.Visible = true;
            btnBuscar.Visible = false;
            btnGuardar.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BusquedaMovimientosTela formulario = new BusquedaMovimientosTela();
            formulario.ShowDialog();

            if (formulario.IdMovimientoCabeceraParam != 0)
            {
                IdCabecera = formulario.IdMovimientoCabeceraParam;
                cboTipoMovimiento.SelectedValue = formulario.IdTipoMovimientoParam;
                dtpFechaMovimiento.Value = formulario.FechaMovimientoParam;
                txtComentario.Text= formulario.ComentarioParam;

                GetDetalleMovimientoPorId(IdCabecera);

                btnGuardar.Visible = true;
                btnCancelar.Visible = true;
                btnNuevo.Visible = false;



            }
        }

        private void GetDetalleMovimientoPorId(int IdMovimiento)
        {
            dgvItem.Rows.Clear();

            listMovimientosDetalle = mantenimientoRepository.GetMovimientosDetallePorIdCabecera(IdMovimiento).ToList();
            ListarDetalle(listMovimientosDetalle);
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // EDITAR
            if (dgvItem.Columns[e.ColumnIndex].Name.Equals("btnEditarItem"))
            {

                IngresoDeProductosPorNivel frm = new IngresoDeProductosPorNivel();

                int index = e.RowIndex;

                frm.ModoEditar = true;
                frm.CodigoNivel = "03";
                frm.IdPedidoColorIn = Convert.ToInt32(dgvItem.Rows[index].Cells["IdPedidoColor"].Value.ToString());
                frm.GrupoIn = dgvItem.Rows[index].Cells["CodGrupo"].Value.ToString();
                frm.ColorIn = dgvItem.Rows[index].Cells["CodColor"].Value.ToString();
                frm.TallaIn = dgvItem.Rows[index].Cells["CodTalla"].Value.ToString();
                frm.CantidadIn = dgvItem.Rows[index].Cells["Cantidad"].Value.ToString();
                frm.PartidaProveedorIn = dgvItem.Rows[index].Cells["PartidaProveedor"].Value.ToString();
                frm.ProductoIn = dgvItem.Rows[index].Cells["Producto"].Value.ToString();
                frm.PedidoIn = dgvItem.Rows[index].Cells["Pedido"].Value.ToString();
                frm.ColorPedidoIn = dgvItem.Rows[index].Cells["PedidoColor"].Value.ToString();

                frm.EstiloIn = dgvItem.Rows[index].Cells["Estilo"].Value.ToString();
                frm.ProgramaIn = dgvItem.Rows[index].Cells["Programa"].Value.ToString();
                frm.ComentarioIn = dgvItem.Rows[index].Cells["Comentario"].Value.ToString();

                frm.ShowDialog();

                // ASIGNAMOS VALORES
                dgvItem.Rows[index].Cells["IdPedidoColor"].Value = frm.IdPedidoColorParam;
                dgvItem.Rows[index].Cells["CodigoNivel"].Value = frm.NivelParam;
                dgvItem.Rows[index].Cells["CodGrupo"].Value = frm.GrupoParam;
                dgvItem.Rows[index].Cells["CodColor"].Value = frm.ColorParam;
                dgvItem.Rows[index].Cells["CodTalla"].Value = frm.TallaParam;
                dgvItem.Rows[index].Cells["Cantidad"].Value = frm.CantidadParam;
                dgvItem.Rows[index].Cells["PartidaProveedor"].Value = frm.PartidaProveedorParam;
                dgvItem.Rows[index].Cells["Producto"].Value = frm.ProductoParam;
                dgvItem.Rows[index].Cells["Pedido"].Value = frm.PedidoParam;
                dgvItem.Rows[index].Cells["PedidoColor"].Value = frm.ColorPedidoParam;

                dgvItem.Rows[index].Cells["Estilo"].Value = frm.EstiloParam;
                dgvItem.Rows[index].Cells["Programa"].Value = frm.ProgramaParam;
                dgvItem.Rows[index].Cells["Comentario"].Value = frm.ComentarioParam;


            }

            //VER 
            if (dgvItem.Columns[e.ColumnIndex].Name.Equals("btnEliminarItem"))
            {
                DialogResult response = ResponseMessage.MessageQuestion("Confirme para eliminar item");
                if (response == DialogResult.OK)
                {
                    dgvItem.Rows.RemoveAt(e.RowIndex);
                    listMovimientosDetalle.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
