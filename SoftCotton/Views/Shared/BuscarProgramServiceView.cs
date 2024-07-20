using SoftCotton.BusinessLogic;
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
    public partial class BuscarProgramServiceView : Form
    {
        MantenimientoBL _mantenimientoBL;

        public string tipoBusqueda = "";
        public string codigo = "";
        public string nombre = "";

        public BuscarProgramServiceView()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();
        }

        private void BuscarProgramServiceView_Load(object sender, EventArgs e)
        {

        }

        private void BuscarProgramService(string filtroBusqueda)
        {
            dgvListado.Rows.Clear();

            if (tipoBusqueda == "S")
            {
                var servicio = _mantenimientoBL.Get33_Servicio(filtroBusqueda, 1);
                foreach (var item in servicio)
                {
                    int index = dgvListado.Rows.Add();

                    dgvListado.Rows[index].Cells["ctxtCodigo"].Value = item.codServicio;
                    dgvListado.Rows[index].Cells["ctxtNombre"].Value = item.nombreServicio;
                }
            }
            else if (tipoBusqueda == "P")
            {
                var programa = _mantenimientoBL.Get34_Programa(filtroBusqueda, 1);
                foreach (var item in programa)
                {
                    int index = dgvListado.Rows.Add();

                    dgvListado.Rows[index].Cells["ctxtCodigo"].Value = item.codPrograma;
                    dgvListado.Rows[index].Cells["ctxtNombre"].Value = item.nombrePrograma;
                }
            }


            if (dgvListado.Rows.Count > 0)
            {
                dgvListado.Focus();
                dgvListado.Rows[0].Selected = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    BuscarProgramService(txtNombre.Text.Trim());
                }
            }
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvListado.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvListado.CurrentRow;

                    codigo = dgr.Cells["ctxtCodigo"].Value.ToString().Trim();
                    nombre = dgr.Cells["ctxtNombre"].Value.ToString().Trim();

                    this.Hide();
                }
            }
        }
    }
}
