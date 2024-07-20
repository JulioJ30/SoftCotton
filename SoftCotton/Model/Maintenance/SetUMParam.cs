using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetUMParam
    {
        public int opcion { get; set; }
        public string codUM { get; set; }
        public string codUMUpdate { get; set; }
        public string descripcion { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetUMParam()
        {
            opcion = 0;
            codUM = "";
            codUMUpdate = "";
            descripcion = "";
            usuarioReg = "";
            estado = false; 
        }

    }
}
