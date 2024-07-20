using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetCeCoParam
    {
        public int opcion { get; set; }
        public string codceco { get; set; }
        public string codcecoUpdate { get; set; }
        public string ceco { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetCeCoParam()
        {
            opcion = 0;
            codceco = "";
            codcecoUpdate = "";
            ceco = "";
            usuarioReg = "";
            estado = false;
        }
    }
}
