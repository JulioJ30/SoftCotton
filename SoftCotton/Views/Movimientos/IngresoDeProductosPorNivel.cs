    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using SoftCotton.Views.Maintenance;
using SoftCotton.Views.Shared;

namespace SoftCotton.Views.Movimientos
{
    public partial class IngresoDeProductosPorNivel : Form
    {
        // INPUT
        public string CodigoNivel = "";
        public bool ModoEditar = false;


        public string GrupoIn = "";
        public string TallaIn = "";
        public string ColorIn = "";
        public string CantidadIn = "";
        public string PartidaProveedorIn = "";
        public string ProductoIn = "";
        public string PedidoIn = "";
        public string EstiloIn = "";
        public string ProgramaIn = "";
        public string ColorPedidoIn = "";
        public string ComentarioIn = "";
        public int IdPedidoColorIn = 0;


        // OUTPUT
        public string NivelParam = "";
        public string GrupoParam = "";
        public string TallaParam = "";
        public string ColorParam = "";
        public string CantidadParam = "";
        public string PartidaProveedorParam = "";
        public string ProductoParam = "";
        public string PedidoParam = "";
        public string EstiloParam = "";
        public string ProgramaParam = "";
        public string ColorPedidoParam = "";
        public string ComentarioParam = "";
        public int IdPedidoColorParam = 0;





        public IngresoDeProductosPorNivel()
        {
            InitializeComponent();
        }

        // CARGA
        private void IngresoDeProductosPorNivel_Load(object sender, EventArgs e)
        {
            txtNivel.Text = CodigoNivel;
            if (ModoEditar)
            {
                AsignarValoresPorDefecto();
            }
        }

        // ASIGNAR VALORES
        private void AsignarValoresPorDefecto()
        {
            //NivelParam = txtNivel.Text.Trim();
            txtGrupo.Text = GrupoIn;
            txtTalla.Text = TallaIn;
            txtColor.Text = ColorIn;
            txtCantidad.Text = CantidadIn;
            txtPartidaProveedor.Text = PartidaProveedorIn;
            txtProducto.Text = ProductoIn;  
            txtPedido.Text = PedidoIn;
            txtEstilo.Text = EstiloIn;
            txtPrograma.Text = ProgramaIn;
            txtColorPedido.Text = ColorPedidoIn;
            txtComentario.Text = ComentarioIn;
            IdPedidoColorParam = IdPedidoColorIn;
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BusquedaPorNivelYGrupo();
        }

        private void BusquedaPorNivelYGrupo()
        {
            string vCodGrupo = txtGrupo.Text.Trim();
            BuscarProductoView frmBuscarProductoView = new BuscarProductoView(CodigoNivel, vCodGrupo);
            frmBuscarProductoView.ShowDialog();

            if (string.IsNullOrEmpty(frmBuscarProductoView.codTalla) || frmBuscarProductoView.codTalla == "")
            {
                txtProducto.Clear();
                txtTalla.Clear();
                txtColor.Clear();
            }
            else
            {
                txtProducto.Text = frmBuscarProductoView.productoServicio;
                txtTalla.Text = frmBuscarProductoView.codTalla;
                txtColor.Text = frmBuscarProductoView.codColor;

                txtCantidad.Focus();
            }
        }

        private void txtGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BusquedaPorNivelYGrupo();
            }
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            BuscarPedidos();
        }

        private void BuscarPedidos()
        {
            BuscarPedidosColorView objFormulario = new BuscarPedidosColorView();
            objFormulario.ShowDialog();

            if (objFormulario.idPedidoColorParam != 0)
            {
                txtPedido.Text = objFormulario.pedidoParam;
                txtEstilo.Text = objFormulario.estiloParam;
                txtPrograma.Text = objFormulario.programaParam;
                txtColorPedido.Text = objFormulario.colorParam;
                IdPedidoColorParam = objFormulario.idPedidoColorParam;
                txtComentario.Focus();
            }
        }

        // ENVIAR DATOS
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DevolverDatos();
        }

        private void DevolverDatos()
        {
            NivelParam = txtNivel.Text.Trim();
            GrupoParam = txtGrupo.Text.Trim();
            TallaParam = txtTalla.Text.Trim();
            ColorParam = txtColor.Text.Trim();
            CantidadParam = txtCantidad.Text.Trim();
            PartidaProveedorParam = txtPartidaProveedor.Text.Trim();
            ProductoParam = txtProducto.Text.Trim();
            PedidoParam = txtPedido.Text.Trim();
            EstiloParam = txtEstilo.Text.Trim();
            ProgramaParam = txtPrograma.Text.Trim();
            ColorPedidoParam = txtColorPedido.Text.Trim();
            ComentarioParam = txtComentario.Text.Trim();


            this.Hide();
        }

        private void txtComentario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DevolverDatos();
            }
        }
    }
}
