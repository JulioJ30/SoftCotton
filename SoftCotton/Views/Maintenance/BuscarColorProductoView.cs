using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.Maintenance
{
    public partial class BuscarColorProductoView : Form
    {
        MantenimientoBL _mantenimientoBL;
        public string codColor = "";
        public string descripcion = "";
        
        public BuscarColorProductoView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void BuscarColorProductoView_Load(object sender, EventArgs e)
        {

        }

        private void BuscarColores(string filtroBusqueda)
        {
            List<GetMant32_BuscarColor> listaColores = _mantenimientoBL.Get32_BuscarColor(filtroBusqueda);

            dgvColor.Rows.Clear();

            foreach (var item in listaColores)
            {
                int index = dgvColor.Rows.Add();

                dgvColor.Rows[index].Cells["ctxtCodigo"].Value = item.codColor;
                dgvColor.Rows[index].Cells["ctxtColor"].Value = item.descripcion;
            }

            if (dgvColor.Rows.Count > 0)
            {
                dgvColor.Focus();
                dgvColor.Rows[0].Selected = true;
            }
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtColor.Text.Trim()))
                {
                    BuscarColores(txtColor.Text.Trim());
                }
            }
        }

        private void dgvColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvColor.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvColor.CurrentRow;

                    codColor = dgr.Cells["ctxtCodigo"].Value.ToString().Trim();
                    descripcion = dgr.Cells["ctxtColor"].Value.ToString().Trim();
                    
                    this.Hide();
                }

            }
        }


    }
}
