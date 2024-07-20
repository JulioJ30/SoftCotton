using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetColorParam
    {
        public int opcion { get; set; }
        public string codColor { get; set; }
        public string codColorUpdate { get; set; }
        public string descripcion { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetColorParam()
        {
            opcion = 0;
            codColor = "";
            codColorUpdate = "";
            descripcion = "";
            estado = false;
            usuarioReg = "";
        }
    }
}
