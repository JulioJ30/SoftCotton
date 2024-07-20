using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;

namespace SoftCotton.Views.Maintenance
{
    public partial class BuscarPedidosColorView : Form
    {
        MantenimientoBL _mantenimientoBL;
        public int idPedidoColorParam = 0;
        public string pedidoParam = "";
        public string colorParam = "";
        public string estiloParam = "";
        public string codigoEstiloParam = "";



        public BuscarPedidosColorView()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();

        }

        private void txtPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtPedido.Text.Trim()))
                {
                    BuscarPedidosColor(txtPedido.Text.Trim());
                }
            }
        }

        private void BuscarPedidosColor(string filtro)
        {

            List<GetMant56_PedidosColor> lista = _mantenimientoBL.getPedidosColorFiltro(filtro).ToList();
            
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

                    idPedidoColorParam = Convert.ToInt32(dgr.Cells["idPedidoColor"].Value.ToString());
                    pedidoParam = dgr.Cells["pedido"].Value.ToString().Trim();
                    colorParam = dgr.Cells["color"].Value.ToString().Trim();
                    estiloParam = dgr.Cells["estilo"].Value.ToString().Trim();
                    codigoEstiloParam = dgr.Cells["codigoEstilo"].Value.ToString().Trim();


                    this.Hide();
                }

            }
        }
    }
}
