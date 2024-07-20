using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetGrupoParam
    {
        public int opcion { get; set; }
        public string codNivel { get; set; }
        public string codGrupo { get; set; }
        public string codGrupoAlt { get; set; }
        public string grupo { get; set; }
        public string codUM { get; set; }
        public string usuarioReg { get; set; }
        public string codCuenta { get; set; }

        public SetGrupoParam()
        {
            opcion = 0;
            codNivel = "";
            codGrupo = "";
            codGrupoAlt = "";
            grupo = "";
            codUM = "";
            usuarioReg = "";
            codCuenta = "";
        }
    }
}
