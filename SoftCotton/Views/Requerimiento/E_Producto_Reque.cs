using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Views.Requerimiento
{
    public class E_Producto_Reque
    {
        public int item { get; set; }
        public string codigo { get; set; }
        public string producto { get; set; }
        public string unidad_medida { get; set; }
        public double cantidad { get; set; }
        public double stock { get; set; }
        public double cantidad_atendida { get; set; }
    }
}
