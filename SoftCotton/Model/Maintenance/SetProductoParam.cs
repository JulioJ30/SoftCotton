using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetProductoParam
    {
        public int opcion { get; set; }
        public string codFamilia { get; set; }
        public string codProducto { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public string descripcion { get; set; }
        public string codUM { get; set; }
        public string codProductoAlt { get; set; }
        public bool estado { get; set; }
        public string usuarioReg { get; set; }

        public SetProductoParam()
        {
            opcion = 0;
            codFamilia = "";
            codProducto = "";
            codTalla = "";
            codColor = "";
            descripcion = "";
            codProductoAlt = "";
            codUM = "";
            estado = false;
            usuarioReg = "";
        }
    }
}
