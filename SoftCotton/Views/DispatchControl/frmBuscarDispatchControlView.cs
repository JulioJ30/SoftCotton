using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.DispatchControl;

namespace SoftCotton.Views.DispatchControl
{
    public partial class frmBuscarDispatchControlView : Form
    {
        DispatchControlBL _dispatchControlBL;
        public int id;
        public string pedidoBusqueda,estiloBusqueda,clienteBusqueda,rucBusqueda, codColorBusqueda, descripcionColorBusqueda,codClienteBusqueda, colorBusqueda,proveedorBusqueda, idProveedorBusqueda;
        public int idPedidoColorBusqueda, idProcesoControlDespachoCabBusqueda;

        public frmBuscarDispatchControlView()
        {
            InitializeComponent();
            _dispatchControlBL = new DispatchControlBL();
        }

        private void frmBuscarDispatchControlView_Load(object sender, EventArgs e)
        {

        }


        private void Buscar(string filtroBusqueda)
        {
            List<busquedaControlDespacho> listaDatos = _dispatchControlBL.GetControlDespachos(1, filtroBusqueda).ToList();
            dgvListado.DataSource = listaDatos;
            //dgvListado.Rows.Clear();

            //foreach (var item in listaDatos)
            //{
            //    int index = dgvListado.Rows.Add();

            //    dgvListado.Rows[index].Cells["idProcesoControlDespachoCab"].Value = item.idProcesoControlDespachoCab;
            //    dgvListado.Rows[index].Cells["codPrograma"].Value = item.codPrograma;
            //    dgvListado.Rows[index].Cells["estilo"].Value = item.estilo;
            //    dgvListado.Rows[index].Cells["codColor"].Value = item.codColor;
            //    dgvListado.Rows[index].Cells["descripcionColor"].Value = item.descripcionColor;
            //    dgvListado.Rows[index].Cells["pedido"].Value = item.pedido;
            //    dgvListado.Rows[index].Cells["codCliente"].Value = item.codCliente;
            //    dgvListado.Rows[index].Cells["razonSocial"].Value = item.razonSocial;
            //    dgvListado.Rows[index].Cells["ruc"].Value = item.ruc;

            //}

            if (dgvListado.Rows.Count > 0)
            {
                dgvListado.Focus();
                dgvListado.Rows[0].Selected = true;
            }
        }

        private void txtPedidoBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtPedidoBuscar.Text.Trim()))
                {
                    Buscar(txtPedidoBuscar.Text.Trim());
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

                    idPedidoColorBusqueda = Convert.ToInt32(dgr.Cells["idPedidoColor"].Value.ToString().Trim());
                    id = Convert.ToInt32(dgr.Cells["idProcesoControlDespachoCab"].Value.ToString().Trim());
                    idProcesoControlDespachoCabBusqueda = Convert.ToInt32(dgr.Cells["idProcesoControlDespachoCab"].Value.ToString().Trim());
                    
                    pedidoBusqueda = dgr.Cells["pedido"].Value.ToString().Trim();
                    estiloBusqueda = dgr.Cells["estilo"].Value.ToString().Trim();
                    colorBusqueda = dgr.Cells["color"].Value.ToString().Trim();
                    clienteBusqueda = dgr.Cells["cliente"].Value.ToString().Trim();
                    proveedorBusqueda = dgr.Cells["proveedor"].Value.ToString().Trim();
                    idProveedorBusqueda = dgr.Cells["idProveedor"].Value.ToString().Trim();



                    this.Close();
                }

            }
        }
    }
}
