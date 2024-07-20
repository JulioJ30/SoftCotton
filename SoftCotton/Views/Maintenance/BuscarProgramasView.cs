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
    public partial class BuscarProgramasView : Form
    {

        MantenimientoBL _mantenimientoBL;
        public int idProgramaParam = 0;
        public string programaParam = "";



        public BuscarProgramasView()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();
        }

        private void BuscarProgramasView_Load(object sender, EventArgs e)
        {
            //dgvProgramas.DataSource = _mantenimientoBL.GetProgramas();
        }

        private void txtPedido_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    string pedido = txtPrograma.Text.Trim();
            //    dgvProgramas.DataSource = _mantenimientoBL.GetProgramas();
            //}
        }

        private void BuscarProgramasView_Load_1(object sender, EventArgs e)
        {
            dgvProgramas.DataSource = _mantenimientoBL.GetProgramas();

            if (dgvProgramas.Rows.Count > 0)
            {
                dgvProgramas.Focus();
                dgvProgramas.Rows[0].Selected = true;
            }

            txtPrograma.Focus();
        }

        private void dgvProgramas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvProgramas.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvProgramas.CurrentRow;

                    idProgramaParam = Convert.ToInt32(dgr.Cells["idPrograma"].Value.ToString().Trim());
                    programaParam = dgr.Cells["programa"].Value.ToString().Trim();


                    this.Close();
                }

            }
        }

        private void dgvProgramas_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
