using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.Model.Transformacion;
using SoftCotton.Repository;
using SoftCotton.Views.Maintenance;

namespace SoftCotton.Views.Movimientos
{
    public partial class TransformacionTallas : Form
    {

        public int IdTransformacionDetParam = 0;
        string codTalla = string.Empty;
        MovimientosRepository movimientosRepository = new MovimientosRepository();
        public TransformacionTallas()
        {
            InitializeComponent();
        }

        private void btnBuscarTalla_Click(object sender, EventArgs e)
        {
            busqueda();   
        }

        private void busqueda()
        {
            BuscarTallas frm = new BuscarTallas();
            frm.ShowDialog();
            if (frm.codTalla != "")
            {
                txtTalla.Text = frm.descripcion;
                codTalla = frm.codTalla;
                txtCantidad.Focus();
            }
        }

        private void TransformacionTallas_Load(object sender, EventArgs e)
        {
            GetTallasPorIdDet();
        }

        private void GetTallasPorIdDet()
        {

            var response = movimientosRepository.GetRegistroTransformacionDetTallaPorIdDet(IdTransformacionDetParam).ToList();
            dgvDatos.DataSource = response; 
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {

            DetalleTransformacionDetTallaEntity parametro = new DetalleTransformacionDetTallaEntity();
            parametro.IdTransformacionDet = IdTransformacionDetParam;
            parametro.IdTransformacionDetTalla = 0; // Nuevo registro, no tiene Id
            parametro.CodTalla = codTalla;
            parametro.Cantidad = txtCantidad.Text.Trim() == "" ? 0 : float.Parse(txtCantidad.Text.Trim());
            parametro.Observacion = txtObservacion.Text.Trim();

            bool rpt = movimientosRepository.setRegistroTransformacionDetTalla(parametro,1);
            if (rpt)
            {
                txtCantidad.Clear();
                txtObservacion.Clear();
                txtTalla.Clear();

                GetTallasPorIdDet();
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //VER 
            if (dgvDatos.Columns[e.ColumnIndex].Name.Equals("DgvbtnEliminar"))
            {

                int idTransformacionDetTalla = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["DgvIdTransformacionDetTalla"].Value);
                if (MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool rpt = movimientosRepository.setRegistroTransformacionDetTallaDelete(idTransformacionDetTalla);
                    if (rpt)
                    {
                        GetTallasPorIdDet();
                    }
                }

                //TransformacionTallas frm = new TransformacionTallas();

                //frm.IdTransformacionDetParam = Convert.ToInt32(dgvDestinoItems.Rows[e.RowIndex].Cells["DgvIdTransformacionDet"].Value);
                //frm.ShowDialog();
            }
        }
    }
}
