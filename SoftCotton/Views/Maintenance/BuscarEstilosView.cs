using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.Model.Maintenance;
using SoftCotton.BusinessLogic;

namespace SoftCotton.Views.Maintenance
{
    public partial class BuscarEstilosView : Form
    {

        MantenimientoBL _mantenimientoBL;
        public int idEstiloParam = 0;
        public string estiloParam = "";
        public BuscarEstilosView()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();

        }

        private void BuscarEstilosView_Load(object sender, EventArgs e)
        {
            dgvEstilos.DataSource = _mantenimientoBL.GetEstilos();

            if (dgvEstilos.Rows.Count > 0)
            {
                dgvEstilos.Focus();
                dgvEstilos.Rows[0].Selected = true;
            }

            txtEstilo.Focus();
        }

        private void dgvEstilos_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgvEstilos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvEstilos.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvEstilos.CurrentRow;

                    idEstiloParam = Convert.ToInt32(dgr.Cells["idEstilo"].Value.ToString().Trim());
                    estiloParam = dgr.Cells["estilo"].Value.ToString().Trim();
                    this.Close();
                }

            }
        }
    }
}
