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
    public partial class BuscarNiveles : Form
    {
        KardexBL _kardexBL;
        List<string> codigosSeleccionados = new List<string>();


        public BuscarNiveles()
        {
            InitializeComponent();
            _kardexBL = new KardexBL();
        }

        private void BuscarNiveles_Load(object sender, EventArgs e)
        {
            DgvLista.DataSource = _kardexBL.GetListarNiveles("");
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                DgvLista.DataSource = _kardexBL.GetListarNiveles(txtFiltro.Text);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            string codigosSeleccionados = "";

            // Itera a través de todas las filas del DataGridView
            foreach (DataGridViewRow fila in DgvLista.Rows)
            {
                // Verifica si el checkbox de la columna "seleccionar" está marcado
                DataGridViewCheckBoxCell checkbox = fila.Cells["Seleccionar"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(checkbox.Value))
                {
                    // Obtiene el valor de la columna "Codigo" de la fila actual y lo concatena a la variable
                    codigosSeleccionados += fila.Cells["Codigo"].Value.ToString() + ",";
                }
            }

            // Elimina la última coma si existe
            if (!string.IsNullOrEmpty(codigosSeleccionados))
            {
                codigosSeleccionados = codigosSeleccionados.TrimEnd(',');
            }

        }
 
    }
}
