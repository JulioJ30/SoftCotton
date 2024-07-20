using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Kardex
{
    public partial class SubKardexCentral : Form
    {
        MantenimientoBL _mantenimientoBL = new MantenimientoBL();

        public SubKardexCentral()
        {
            InitializeComponent();
        }
        public void ListarNivelCBX()
        {

            List<GetMant16_NivelCBX> cbxNivelList = _mantenimientoBL.Get16_NivelCBX();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxNivelList;

            cbxNivel.DisplayMember = "nivel";
            cbxNivel.ValueMember = "codNivel";
            cbxNivel.DataSource = bindingSource.DataSource;
        }
        private void SubKardexCentral_Load(object sender, EventArgs e)
        {
            ListarNivelCBX();

            DataTable dt = _mantenimientoBL.SetDatatable(67, "", "", 0, 0);
            cbSubAlmacenes.DataSource = dt;
            cbSubAlmacenes.DisplayMember = "Descripcion";
            cbSubAlmacenes.ValueMember = "tCodigoSubArea";

        }

        private void btnBuscarSub_Click(object sender, EventArgs e)
        {
            DataTable dt = _mantenimientoBL.SetDatatable(66, " ", cbSubAlmacenes.SelectedValue.ToString(), 0, 0);
            dgvListado.DataSource = dt;
        }

        private void dgvListado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvListado.ClearSelection();
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvListado.Columns["Movimientos"].Index && e.RowIndex >= 0)
                {
                    string codigo = dgvListado.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                    string tipo = dgvListado.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
                    string grupo = dgvListado.Rows[e.RowIndex].Cells["grupo"].Value.ToString();
                    string color = dgvListado.Rows[e.RowIndex].Cells["color"].Value.ToString();
                    double stock = Convert.ToDouble(dgvListado.Rows[e.RowIndex].Cells["stock"].Value.ToString());

                    VariableGeneral.codigoProducto = codigo;
                    VariableGeneral.tipo = tipo;
                    VariableGeneral.grupo = grupo;
                    VariableGeneral.color = color;
                    VariableGeneral.stock = stock;
                    VariableGeneral.nivel = string.Empty;
                    SubKardexMovimientoCentral frm = new SubKardexMovimientoCentral();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            VariableGeneral.codigoProducto = "Nivel Seleccionado " + cbxNivel.Text;
            VariableGeneral.tipo = cbxNivel.Text;
            VariableGeneral.grupo = "";
            VariableGeneral.color = "";
            VariableGeneral.stock = 0;
            VariableGeneral.nivel = cbxNivel.SelectedValue.ToString();
            VariableGeneral.fechaInicio = dtpFechaInicio.Text;
            VariableGeneral.fechaFin = dtpFechaFin.Text;

            SubKardexMovimientoCentral frm = new SubKardexMovimientoCentral();
            frm.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                DataTable dt = _mantenimientoBL.SetDatatable(66, textBox1.Text , cbSubAlmacenes.SelectedValue.ToString(), 0, 0);
                dgvListado.DataSource = dt;
            }
        }
    }
}
