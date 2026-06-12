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
    public partial class BuscarAvancesGuiasPorIdPedidoColorView : Form
    {
        MantenimientoBL _mantenimientoBL;
        int IdPedidoColorInput;

        public BuscarAvancesGuiasPorIdPedidoColorView(int IdPedidoColor)
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();
            this.IdPedidoColorInput = IdPedidoColor;
            this.BuscarPedidosColor(this.IdPedidoColorInput);
        }

        private void BuscarAvancesGuiasPorIdPedidoColorView_Load(object sender, EventArgs e)
        {

        }

        private void BuscarPedidosColor(int IdPedidoColor)
        {

            List<PedidosColorAvance> lista = _mantenimientoBL.getPedidosColorAvance(IdPedidoColor).ToList();
            dgvDetalle.DataSource = lista;
            //if (dgvDetalle.Rows.Count > 0)
            //{
            //    dgvLista.Focus();
            //    dgvLista.Rows[0].Selected = true;
            //}
        }
    }
}
