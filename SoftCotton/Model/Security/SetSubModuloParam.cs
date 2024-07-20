using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Security
{
    public class SetSubModuloParam
    {
        public int opcion { get; set; }
        public int idSubModulo { get; set; }
        public int idModulo { get; set; }
        public string subModulo { get; set; }
        public string rutaForm { get; set; }
        public string iconPath { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetSubModuloParam()
        {
            opcion = 0;
            idSubModulo = 0;
            idModulo = 0;
            subModulo = "";
            rutaForm = "";
            iconPath = "";
            usuarioReg = "";
            estado = false;
        }

    }
}
