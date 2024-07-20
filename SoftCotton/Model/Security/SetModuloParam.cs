using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Security
{
    public class SetModuloParam
    {
        public int opcion { get; set; }
        public int idModulo { get; set; }
        public string modulo { get; set; }
        public string iconPath { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetModuloParam()
        {
            opcion = 0;
            idModulo = 0;
            modulo = "";
            iconPath = "";
            usuarioReg = "";
            estado = false;
        }
    }

}
