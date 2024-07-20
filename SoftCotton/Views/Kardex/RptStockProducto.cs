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
    public partial class RptStockProducto : Form
    {
        MantenimientoBL _mantenimientoBL = new MantenimientoBL();
        public RptStockProducto()
        {
            InitializeComponent();
        }

        private void RptStockProducto_Load(object sender, EventArgs e)
        {
            cbSubAlmacenes.DataSource = _mantenimientoBL.SetDatatable(70, "", "", 0, 0);
            cbSubAlmacenes.DisplayMember = "Descripcion";
            cbSubAlmacenes.ValueMember = "Codigo";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (cbSubAlmacenes.SelectedValue.ToString() == "000")
            {
                dt = _mantenimientoBL.SetDatatableReporte(2, cbSubAlmacenes.SelectedValue.ToString(), "", "", "", dtpFechaInicio.Text, dtpFechaFin.Text);
            }
            else
            {
                dt = _mantenimientoBL.SetDatatableReporte(1, cbSubAlmacenes.SelectedValue.ToString(), "", "", "", dtpFechaInicio.Text, dtpFechaFin.Text);
            }

            dgvListado.DataSource = dt;
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListado.Rows.Count > 0)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Excel Documents (*.xls)|*.xls";
                    save.FileName = "Reporte de sctok por Producto a la fecha";
                    dgvListado.SelectAll();
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        dgvListado.GridToExcel(save.FileName);
                    }
                    else
                    {
                        MessageBox.Show("No Hay Datos para Exportar", "Reporte de sctok por Producto a la fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reporte de sctok por Producto a la fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
