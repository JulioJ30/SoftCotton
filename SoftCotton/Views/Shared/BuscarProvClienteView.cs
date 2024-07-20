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
    public partial class BuscarProvClienteView : Form
    {
        CompartidoBL _compartidoBL;
        public string codProvCliente = "";
        public string provCliente = "";
        public string direccion = "";

        public BuscarProvClienteView()
        {
            InitializeComponent();

            _compartidoBL = new CompartidoBL();
        }

        private void BuscarProvClienteView_Load(object sender, EventArgs e)
        {

        }

        private void BuscarProvClientes(string filtroBusqueda)
        {
            List<GetShared1_ProvClientes> listaProvClientes = _compartidoBL.Get1_ProvClientes(filtroBusqueda);

            dgvProvCliente.Rows.Clear();

            foreach (var item in listaProvClientes)
            {
                int index = dgvProvCliente.Rows.Add();

                dgvProvCliente.Rows[index].Cells["ctxtCodigo"].Value = item.codigo;
                dgvProvCliente.Rows[index].Cells["ctxtRazonSocial"].Value = item.razonSocial;
                dgvProvCliente.Rows[index].Cells["ctxtDireccion"].Value = item.direccion;
            }

            if (dgvProvCliente.Rows.Count > 0)
            {
                dgvProvCliente.Focus();
                dgvProvCliente.Rows[0].Selected = true;
            }
        }

        private void txtProvCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtProvCliente.Text.Trim()))
                {
                    BuscarProvClientes(txtProvCliente.Text.Trim());
                }
            }
        }

        private void dgvProvCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvProvCliente.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvProvCliente.CurrentRow;
                    
                    codProvCliente = dgr.Cells["ctxtCodigo"].Value.ToString().Trim();
                    provCliente = dgr.Cells["ctxtRazonSocial"].Value.ToString().Trim();
                    direccion = dgr.Cells["ctxtDireccion"].Value.ToString().Trim();

                    this.Hide();
                }
                
            }
        }




    }
}
