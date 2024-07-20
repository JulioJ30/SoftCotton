using SoftCotton.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Maintenance
{
    public partial class BuscarArticulo : Form
    {
        KardexBL _kardexBL;
        public BuscarArticulo()
        {
            InitializeComponent();
            _kardexBL = new KardexBL();
        }

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                VariableGeneral._sCodigo = DgvLista.CurrentRow.Cells["Codigo"].Value.ToString();
                VariableGeneral._sDescr = DgvLista.CurrentRow.Cells["Descripcion"].Value.ToString();
                VariableGeneral._sEnter = true;
                Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void BuscarArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //VariableGeneral._sEnter = false;
        }

        private void BuscarArticulo_Load(object sender, EventArgs e)
        {
            DgvLista.DataSource = _kardexBL.GetListArticulos("");

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                   DgvLista.DataSource = _kardexBL.GetListArticulos(textBox1.Text);
            }
        }
    }
}
