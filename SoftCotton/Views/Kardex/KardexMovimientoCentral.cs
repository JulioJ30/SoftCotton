using SoftCotton.BusinessLogic;
using SoftCotton.Util;
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
    public partial class KardexMovimientoCentral : Form
    {
        KardexBL _kardexBL = new KardexBL();
        public KardexMovimientoCentral()
        {
            InitializeComponent();
        }

        private void KardexMovimientoCentral_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = VariableGeneral.codigoProducto;
            lblTipo.Text = VariableGeneral.tipo;
            lblGrupo.Text = VariableGeneral.grupo;
            lblColor.Text = VariableGeneral.color;
            lblStock.Text = VariableGeneral.stock.ToString();

            if (VariableGeneral.nivel == string.Empty)
            {
                dgvListado.DataSource = _kardexBL.GetKardexCentralMovimientos(VariableGeneral.codigoProducto);
            }
            else
            {
                dgvListado.DataSource = _kardexBL.GetKardexCentralMovimientosFecha(1,VariableGeneral.fechaInicio, dtpFechaFin.Text, "", VariableGeneral.nivel);
            }

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (VariableGeneral.nivel == string.Empty)
            {
                dgvListado.DataSource = _kardexBL.GetKardexCentralMovimientosFecha(1,dtpFechaInicio.Text, dtpFechaFin.Text, VariableGeneral.codigoProducto, "");
            }
            else
            {
                dgvListado.DataSource = _kardexBL.GetKardexCentralMovimientosFecha(1, dtpFechaInicio.Text, dtpFechaFin.Text, "", VariableGeneral.nivel);

            }
        }

        private void dgvListado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvListado.ClearSelection();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListado.Rows.Count > 0) { }
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel Documents (*.xls)|*.xls";
                save.FileName = "Kardex Movimientos Central";
                dgvListado.SelectAll();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    dgvListado.GridToExcel(save.FileName);
                }
                else
                {
                    MessageBox.Show("No Hay Datos para Exportar", "Kardex Movimientos Central", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kardex Movimientos Central", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
