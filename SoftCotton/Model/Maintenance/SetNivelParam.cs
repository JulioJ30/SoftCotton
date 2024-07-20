using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetNivelParam
    {
        public int opcion { get; set; }
        public string codNivel { get; set; }
        public string codNivelUpdate { get; set; }
        public string nivel { get; set; }
        public string abreviatura { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetNivelParam()
        {
            opcion = 0;
            codNivel = "";
            codNivelUpdate = "";
            nivel = "";
            abreviatura = "";
            usuarioReg = "";
            estado = false;
        }
    }
}
