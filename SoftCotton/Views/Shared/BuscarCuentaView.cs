using SoftCotton.BusinessLogic;
using SoftCotton.Model.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftCotton.Views.Shared
{
    public partial class BuscarCuentaView : Form
    {
        CompartidoBL _compartidoBL;
        public string codCuenta = "";
        public string cuenta = "";
        
        public BuscarCuentaView()
        {
            InitializeComponent();
            _compartidoBL = new CompartidoBL();
        }
    

        private void BuscarCuentaView_Load(object sender, EventArgs e)
        {

        }

        private void BuscarCuentas(string filtroBusqueda)
        {
            List<GetShared3_BuscarCuenta> listaCuentas = _compartidoBL.Get3_BuscarCuenta(filtroBusqueda);

            dgvListado.Rows.Clear();

            foreach (var item in listaCuentas)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["dgvtxtCodCuenta"].Value = item.codCuenta;
                dgvListado.Rows[index].Cells["dgvtxtCuenta"].Value = item.cuenta;
            }

            if (dgvListado.Rows.Count > 0)
            {
                dgvListado.Focus();
                dgvListado.Rows[0].Selected = true;
            }
        }

        private void txtCuentaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtCuentaBuscar.Text.Trim()))
                {
                    BuscarCuentas(txtCuentaBuscar.Text.Trim());
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

                    codCuenta = dgr.Cells["dgvtxtCodCuenta"].Value.ToString().Trim();
                    cuenta = dgr.Cells["dgvtxtCuenta"].Value.ToString().Trim();

                    this.Hide();
                }

            }
        }






    }
}
