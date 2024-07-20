using SoftCotton.BusinessLogic;
using SoftCotton.Model.ReferralGuide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Shared
{
    public partial class DetalleSalidaIngreso : Form
    {

        GuiaRemisionBL _grBL;
        
        string _tipoOrden;
        int _idOC;
        string _tipoMovimiento;
        int _secuencia;


        public DetalleSalidaIngreso(string tipoOrden, int idOC, string tipoMovimiento, int secuencia )
        {
            _tipoOrden = tipoOrden;
            _idOC = idOC;
            _tipoMovimiento = tipoMovimiento;
            _secuencia = secuencia;
            
            InitializeComponent();

            _grBL = new GuiaRemisionBL();
        }

        private void DetalleSalidaIngreso_Load(object sender, EventArgs e)
        {
            List<GetGR9_DetalleSalidaIngreso> lista = _grBL.GetGRDetalleSalidaIngreso(_idOC, _tipoMovimiento, _secuencia, _tipoOrden);

            dgvSalidaIngreso.Rows.Clear();

            decimal cantidad = 0;

            foreach (var item in lista)
            {
                int index = dgvSalidaIngreso.Rows.Add();


                if (item.tipoOrden == "C")
                {
                    dgvSalidaIngreso.Rows[index].Cells["detTipoOrden"].Value = "Orden de Compra";
                }
                else if (item.tipoOrden == "S")
                {
                    dgvSalidaIngreso.Rows[index].Cells["detTipoOrden"].Value = "Orden de Servicio";
                }


                dgvSalidaIngreso.Rows[index].Cells["detSerie"].Value = item.serie;
                dgvSalidaIngreso.Rows[index].Cells["detNumero"].Value = item.numero;
                dgvSalidaIngreso.Rows[index].Cells["detSecuencia"].Value = item.secuencia;
                dgvSalidaIngreso.Rows[index].Cells["detCantidadIngresada"].Value = item.cantidadIngresada;

                cantidad += item.cantidadIngresada;
            }

            lbltotal.Text = cantidad.ToString();
        }


    }
}
