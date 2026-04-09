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
using SoftCotton.Repository;

namespace SoftCotton.Views.Maintenance
{
    public partial class BuscarTallas : Form
    {
        MantenimientoBL _mantenimientoBL;
        public string codTalla = "";
        public string descripcion = "";

        public BuscarTallas()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();

        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtTalla.Text.Trim()))
                {
                    BuscarTallasFuncion(txtTalla.Text.Trim());
                }
            }
        }
        private void BuscarTallasFuncion(string filtro)
        {

            List<GetMant21_TallasNuevo> lista = _mantenimientoBL.Get76_Tallas(filtro).ToList();

            dgvLista.DataSource = lista;
            if (dgvLista.Rows.Count > 0)
            {
                dgvLista.Focus();
                dgvLista.Rows[0].Selected = true;
            }
        }

        private void dgvLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvLista.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvLista.CurrentRow;

                    codTalla = dgr.Cells["CodTalla"].Value.ToString();
                    descripcion = dgr.Cells["DgvDescripcionTalla"].Value.ToString().Trim();


                    this.Hide();
                }

            }
        }
    }
}
