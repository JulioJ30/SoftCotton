using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Invoices
{
    public partial class frmTipoCambio : Form
    {
        public decimal TipoCambio = 0;
        public frmTipoCambio()
        {
            InitializeComponent();
        }

        private void frmTipoCambio_Load(object sender, EventArgs e)
        {
            txtTipoCambio.Text = TipoCambio.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AceptarTipoCambio();
        }

        private void AceptarTipoCambio()
        {
            TipoCambio = Convert.ToDecimal(txtTipoCambio.Text.Trim());
            this.Close();
        }

        private void txtTipoCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AceptarTipoCambio();
            }
        }
    }
}
