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

namespace SoftCotton.Views.Requerimiento
{
    public partial class ListaArticulo : Form
    {
        MantenimientoBL _mantenimientoBL = new MantenimientoBL();
        string codigoAlmacen = "";
        public ListaArticulo(string CodAlmacen)
        {
            InitializeComponent();
            codigoAlmacen = CodAlmacen;
        }

        private void ListaArticulo_Load(object sender, EventArgs e)
        {
            dgvListado.DataSource = _mantenimientoBL.SetDatatable(61," ", codigoAlmacen,0,0);
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvListado.Columns["asignar"].Index && e.RowIndex >= 0)
                {

                    VariableGeneral._sCodigo = dgvListado.CurrentRow.Cells["codigo"].Value.ToString();
                    VariableGeneral._sDescr = dgvListado.CurrentRow.Cells["grupo"].Value.ToString() + " " + dgvListado.CurrentRow.Cells["color"].Value.ToString();
                    VariableGeneral.stock = Convert.ToDouble(dgvListado.CurrentRow.Cells["stock"].Value.ToString());
                    VariableGeneral.UND = dgvListado.CurrentRow.Cells["codUM"].Value.ToString();
                    VariableGeneral._sEnter = true;
                    Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            VariableGeneral._sEnter = false;
            Close();
        }

        private void ListaArticulo_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void ListaArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                dgvListado.DataSource = _mantenimientoBL.SetDatatable(61, textBox1.Text, codigoAlmacen, 0, 0);
            }                
        }
    }
}
