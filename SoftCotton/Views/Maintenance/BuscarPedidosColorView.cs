using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;

namespace SoftCotton.Views.Maintenance
{
    public partial class BuscarPedidosColorView : Form
    {
        MantenimientoBL _mantenimientoBL;
        public int idPedidoColorParam = 0;
        public int idPedidoColorInput = 0;
        public string pedidoParam = "";
        public string colorParam = "";
        public string estiloParam = "";
        public string codigoEstiloParam = "";
        public string programaParam = "";
        public bool showDetalleInterno = false;
        public string nivelInterno = "";




        public BuscarPedidosColorView(bool mostrarDetalle = false,string nivel = "20")
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();
            this.showDetalleInterno = mostrarDetalle;
            this.nivelInterno = nivel;

            // Opción 1: por nombre de columna (recomendado)
            dgvLista.Columns["btnVerDetalle"].Visible = mostrarDetalle;

        }

        private void txtPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtPedido.Text.Trim()))
                {
                    BuscarPedidosColor(txtPedido.Text.Trim(),nivelInterno);
                }
            }
        }

        private void BuscarPedidosColor(string filtro,string nivel)
        {

            List<GetMant56_PedidosColor> lista = _mantenimientoBL.getPedidosColorFiltro(filtro,nivel).ToList();
            
            dgvLista.DataSource = lista;
            if (dgvLista.Rows.Count > 0)
            {
                dgvLista.Focus();
                dgvLista.Rows[0].Selected = true;
            }
        }

        private void BuscarPedidosColorView_Load(object sender, EventArgs e)
        {

        }

        private void dgvLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvLista.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvLista.CurrentRow;

                    bool permitirRegistro = Convert.ToInt32(dgr.Cells["ColPermitirRegistro"].Value) > 0;

                    if (permitirRegistro)
                    {
                        idPedidoColorParam = Convert.ToInt32(dgr.Cells["idPedidoColor"].Value.ToString());
                        pedidoParam = dgr.Cells["pedido"].Value.ToString().Trim();
                        colorParam = dgr.Cells["color"].Value.ToString().Trim();
                        estiloParam = dgr.Cells["estilo"].Value.ToString().Trim();
                        codigoEstiloParam = dgr.Cells["codigoEstilo"].Value.ToString().Trim();
                        programaParam = dgr.Cells["programa"].Value.ToString().Trim();



                        this.Hide();
                    }
                    else
                    {
                        ResponseMessage.Message("Pedido Color no tiene registro en proceso de acabados, verifique el detalle", "WARNING");
                    }


                }

            }
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            //VER 
            if (dgvLista.Columns[e.ColumnIndex].Name.Equals("btnVerDetalle"))
            {

                idPedidoColorInput = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["idPedidoColor"].Value.ToString());

                BuscarAvancesGuiasPorIdPedidoColorView frm = new BuscarAvancesGuiasPorIdPedidoColorView(idPedidoColorInput);
                frm.ShowDialog();
            }
        }
    }
}
