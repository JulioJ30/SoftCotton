using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Maintenance
{
    public class SetAreasAlmacen
    {
        public int opcion { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string resumida { get; set; }
        public bool estado { get; set; }

        public SetAreasAlmacen()
        {
            opcion = 0;
            codigo = string.Empty;  
            descripcion = string.Empty;
            resumida = string.Empty;
            estado = false;
        }
    }
}
