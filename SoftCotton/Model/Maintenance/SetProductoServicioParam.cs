using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetProductoServicioParam
    {
        public int opcion { get; set; }
        public string codNivel { get; set; }
        public string codGrupo { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }

        public SetProductoServicioParam()
        {
            opcion = 0;
            codNivel = "";
            codGrupo = "";
            codTalla = "";
            codColor = "";
        }
    }
}
