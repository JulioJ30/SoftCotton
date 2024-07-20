using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class SetGRMotTraslado
    {
        public int opcion { get; set; }
        public int idMotivo { get; set; }
        public string motivo { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetGRMotTraslado()
        {
            opcion = 0;
            idMotivo = 0;
            motivo = "";
            usuarioReg = "";
            estado = false;
        }
    }
}
