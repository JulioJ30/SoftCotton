using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Security
{
    public class SetAccesoParam
    {
        public int idUsuario { get; set; }
        public int idSubModulo { get; set; }
        public string usuarioReg { get; set; }
        public bool activo { get; set; }

        public SetAccesoParam()
        {
            idUsuario = 0;
            idSubModulo = 0;
            usuarioReg = "";
            activo = false;
        }
    }
}
