using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class GetMantRpte2_Productos
    {
        public string codNivel { get; set; }
        public string nivel { get; set; }
        public string codGrupo { get; set; }
        public string grupo { get; set; }
        public string codTalla { get; set; }
        public string talla { get; set; }
        public string codColor { get; set; }
        public string color { get; set; }
        public string codGrupoAlt { get; set; }
        public decimal stockReal { get; set; }
    }
}
