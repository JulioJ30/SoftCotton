using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ServiceOrder
{
    public class SetOSTipoAnuladoParam
    {
        public int opcion { get; set; }
        public int idTipoAnulado { get; set; }
        public int idTipoAnuladoUpdate { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public string usuarioReg { get; set; }

        public SetOSTipoAnuladoParam()
        {
            opcion = 0;
            idTipoAnulado = 0;
            idTipoAnuladoUpdate = 0;
            descripcion = "";
            estado = false;
            usuarioReg = "";
        }
    }
}
