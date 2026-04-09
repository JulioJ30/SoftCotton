using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.Repository;

namespace SoftCotton.Views.Movimientos
{
    public partial class BusquedaMovimientosTela : Form
    {

        MovimientosRepository movimientosRepository = new MovimientosRepository();
        MantenimientoRepository mantenimientoRepository = new MantenimientoRepository();

        public int IdMovimientoCabeceraParam = 0;
        public int IdTipoMovimientoParam;
        public DateTime FechaMovimientoParam;
        public string ComentarioParam;


        public BusquedaMovimientosTela()
        {
            InitializeComponent();
        }

        private void BusquedaMovimientosTela_Load(object sender, EventArgs e)
        {
            CargarData();
        }
        private void CargarData()
        {

            var response = mantenimientoRepository.GetMovimientosCabecera();

            foreach (var item in response)
            {
                int index = dgvItem.Rows.Add();

                //dgvItem.Rows[index].Cells["item"].Value = index + 1;


                dgvItem.Rows[index].Cells["IdMovimientoCabecera"].Value = item.IdMovimientoCabecera;
                dgvItem.Rows[index].Cells["IdTipoMovimiento"].Value = item.IdTipoMovimiento;
                dgvItem.Rows[index].Cells["DescripcionTipoMovimiento"].Value = item.DescripcionTipoMovimiento;
                dgvItem.Rows[index].Cells["FechaMovimiento"].Value = item.FechaMovimiento;
                dgvItem.Rows[index].Cells["Comentario"].Value = item.Comentario;
                dgvItem.Rows[index].Cells["CantidadMovimiento"].Value = item.CantidadMovimiento;
                dgvItem.Rows[index].Cells["Usuario"].Value = item.Usuario;
 

            }

        }

        private void dgvItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvItem.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvItem.CurrentRow;

                    IdMovimientoCabeceraParam = Convert.ToInt32(dgr.Cells["IdMovimientoCabecera"].Value.ToString());
                    IdTipoMovimientoParam = Convert.ToInt32(dgr.Cells["IdTipoMovimiento"].Value.ToString());
                    FechaMovimientoParam = Convert.ToDateTime(dgr.Cells["FechaMovimiento"].Value);
                    ComentarioParam = dgr.Cells["Comentario"].Value.ToString().Trim();
                  



                    this.Hide();
                }

            }
        }


       
    }
}
