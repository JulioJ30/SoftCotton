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

namespace SoftCotton.Views.Requerimiento
{
    public partial class frmListaRequerimiento : Form
    {
        MantenimientoBL _mantenimientoBL = new MantenimientoBL();

        public frmListaRequerimiento()
        {
            InitializeComponent();
        }

        private void frmListaRequerimiento_Load(object sender, EventArgs e)
        {
            cargar();
        }
        void cargar()
        {
            DataTable dt;
            //DgvLista.DataSource = _mantenimientoBL.SetDatatable(63, UserApplication.USUARIO, "", 0, 0);
            dt = _mantenimientoBL.SetDatatableReporte(3, UserApplication.USUARIO, "", "", "", dtpFechaInicio.Text, dtpFechaFin.Text);
            DgvLista.DataSource = dt;
            DgvLista.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            VariableGeneral.codigoAlmacen = "";
            RegistrarRequerimiento frm = new RegistrarRequerimiento(this);
            frm.ShowDialog();
            DgvLista.ClearSelection();
        }

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvLista.ClearSelection();

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvLista.Rows.Count > 0)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Excel Documents (*.xls)|*.xls";
                    save.FileName = "Lista de Requerimientos";
                    DgvLista.SelectAll();
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        DgvLista.GridToExcel(save.FileName);
                    }
                    else
                    {
                        MessageBox.Show("No Hay Datos para Exportar", "Lista de Requerimientos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lista de Requerimientos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == DgvLista.Columns["ver"].Index && e.RowIndex >= 0)
                {
                    //AlmacenID
                    string idRequerimiento = DgvLista.Rows[e.RowIndex].Cells["idRequerimiento"].Value.ToString();
                    string codigoAlmacen = DgvLista.Rows[e.RowIndex].Cells["AlmacenID"].Value.ToString();
                    string codigoAlmacenReq = DgvLista.Rows[e.RowIndex].Cells["AlmacenReque"].Value.ToString();
                    string estadoRequerimiento = DgvLista.Rows[e.RowIndex].Cells["DesEstado"].Value.ToString();
                    string observacion = DgvLista.Rows[e.RowIndex].Cells["observacion"].Value.ToString();
                    string Estado = DgvLista.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                    VariableGeneral.codigoAlmacen = codigoAlmacen;
                    VariableGeneral.codigoAlmacenReq = codigoAlmacenReq;
                    VariableGeneral.estadoRequerimiento = estadoRequerimiento;
                    VariableGeneral.idRequerimiento = idRequerimiento;
                    VariableGeneral.observacion = observacion;
                    VariableGeneral.Estado = Estado;

                    RegistrarRequerimiento frm = new RegistrarRequerimiento(this);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
