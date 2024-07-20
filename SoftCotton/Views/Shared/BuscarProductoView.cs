using SoftCotton.BusinessLogic;
using SoftCotton.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.Shared
{
    public partial class BuscarProductoView : Form
    {
        CompartidoBL _compartidoBL;

        public string _codProductoServicio = "";
        public string _productoServicio = "";
        
        public string codProductoServicio = "";
        public string productoServicio = "";
        public string codNivel = "";
        public string nivel = "";
        public string codGrupo = "";
        public string grupo = "";
        public string codTalla = "";
        public string talla = "";
        public string codColor = "";
        public string color = "";
        public string codUM = "";


        public BuscarProductoView(string pCodProductoServicio, string pProductoServicio)
        {
            InitializeComponent();

            _codProductoServicio = pCodProductoServicio;
            _productoServicio = pProductoServicio;

            _compartidoBL = new CompartidoBL();
        }

        private void BuscarProductoView_Load(object sender, EventArgs e)
        {
            BuscarProductos(_codProductoServicio, _productoServicio);
        }

        private void BuscarProductoView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }


        private void BuscarProductos(string codNivel, string codGrupo)
        {
            List<GetShared2_BuscarProdServ> listaProductos = _compartidoBL.Get2_BuscarProdServ(codNivel, codGrupo);

            dgvProdServ.Rows.Clear();

            foreach (var item in listaProductos)
            {
                int index = dgvProdServ.Rows.Add();

                dgvProdServ.Rows[index].Cells["ctxtCodigoProducto"].Value = item.codProducto;
                dgvProdServ.Rows[index].Cells["ctxtProductoServ"].Value = item.producto;
                dgvProdServ.Rows[index].Cells["ctxtCodigoNivel"].Value = item.codNivel;
                dgvProdServ.Rows[index].Cells["ctxtNivel"].Value = item.nivel;
                dgvProdServ.Rows[index].Cells["ctxtCodigoGrupo"].Value = item.codGrupo;
                dgvProdServ.Rows[index].Cells["ctxtGrupo"].Value = item.grupo;
                dgvProdServ.Rows[index].Cells["ctxtCodigoTalla"].Value = item.codTalla;
                dgvProdServ.Rows[index].Cells["ctxtTalla"].Value = item.talla;
                dgvProdServ.Rows[index].Cells["ctxtCodigoColor"].Value = item.codColor;
                dgvProdServ.Rows[index].Cells["ctxtColor"].Value = item.color;
                dgvProdServ.Rows[index].Cells["ctxtCodigoUM"].Value = item.codUM;

            }

            if (dgvProdServ.Rows.Count > 0)
            {
                dgvProdServ.Focus();
                dgvProdServ.Rows[0].Selected = true;
            }
        }

        private void dgvProdServ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvProdServ.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvProdServ.CurrentRow;

                    codProductoServicio = dgr.Cells["ctxtCodigoProducto"].Value.ToString().Trim();
                    productoServicio = dgr.Cells["ctxtProductoServ"].Value.ToString().Trim();
                    codNivel = dgr.Cells["ctxtCodigoNivel"].Value.ToString().Trim();
                    nivel = dgr.Cells["ctxtNivel"].Value.ToString().Trim();
                    codGrupo = dgr.Cells["ctxtCodigoGrupo"].Value.ToString().Trim();
                    grupo = dgr.Cells["ctxtGrupo"].Value.ToString().Trim();
                    codTalla = dgr.Cells["ctxtCodigoTalla"].Value.ToString().Trim();
                    talla = dgr.Cells["ctxtTalla"].Value.ToString().Trim();
                    codColor = dgr.Cells["ctxtCodigoColor"].Value.ToString().Trim();
                    color = dgr.Cells["ctxtColor"].Value.ToString().Trim();
                    codUM = dgr.Cells["ctxtCodigoUM"].Value.ToString().Trim();

                    this.Hide();
                }
            }
        }


    }
}
