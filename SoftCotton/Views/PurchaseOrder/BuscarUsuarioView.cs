using SoftCotton.BusinessLogic;
using SoftCotton.Model.PurchaseOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.PurchaseOrder
{
    public partial class BuscarUsuarioView : Form
    {
        OrdenCompraBL _ordenCompraBL;
        public string idUsuario = "";
        public string colaborador = "";

        public BuscarUsuarioView()
        {
            InitializeComponent();

            _ordenCompraBL = new OrdenCompraBL();
        }

        private void BuscarUsuarioView_Load(object sender, EventArgs e)
        {
            List<GetOC12_Usuarios> listaUsuarios = _ordenCompraBL.Get12_Usuarios(1);

            dgvUsuarios.Rows.Clear();

            foreach (var item in listaUsuarios)
            {
                int index = dgvUsuarios.Rows.Add();

                dgvUsuarios.Rows[index].Cells["cIntId"].Value = item.id;
                dgvUsuarios.Rows[index].Cells["ctxtColaborador"].Value = item.colaborador;
                dgvUsuarios.Rows[index].Cells["ctxtArea"].Value = item.area;
            }

            if (dgvUsuarios.Rows.Count > 0)
            {
                dgvUsuarios.Focus();
                dgvUsuarios.Rows[0].Selected = true;
            }
        }
        
        private void dgvUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    DataGridViewRow dgr = dgvUsuarios.CurrentRow;

                    idUsuario = dgr.Cells["cIntId"].Value.ToString().Trim();
                    colaborador = dgr.Cells["ctxtColaborador"].Value.ToString().Trim();

                    this.Hide();
                }
            }
        }

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow dgr = dgvUsuarios.CurrentRow;

            idUsuario = dgr.Cells["cIntId"].Value.ToString().Trim();
            colaborador = dgr.Cells["ctxtColaborador"].Value.ToString().Trim();

            this.Hide();
        }
    }
}
