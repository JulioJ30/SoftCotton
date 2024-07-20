using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.ReferralGuide
{
    public class GetGR9_DetalleSalidaIngreso
    {
        public string tipoOrden { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public string secuencia { get; set;} 
        public decimal cantidadIngresada { get; set; }
    }
}
