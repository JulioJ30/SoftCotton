using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Security
{
    public class SetUsuarioParam
    {
        public int opcion { get; set; }
        public int idEmpresa { get; set; }
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }
        public string numDoc { get; set; }

        public SetUsuarioParam()
        {
            opcion = 0;
            idEmpresa = 0;
            idUsuario = 0;
            usuario = "";
            contrasena = "";
            numDoc = "";
            usuarioReg = "";
            estado = false;
        }
    }
}
