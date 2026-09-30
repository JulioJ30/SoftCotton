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
        public bool permiteEntrada { get; set; }
        public bool permiteSalida { get; set; }
        public bool permiteDevolucion { get; set; }

        public SetAccesoParam()
        {
            idUsuario = 0;
            idSubModulo = 0;
            usuarioReg = "";
            activo = false;
            permiteEntrada = true;
            permiteSalida = true;
            permiteDevolucion = true;
        }
    }
}
