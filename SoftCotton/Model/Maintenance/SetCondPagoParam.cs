using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetCondPagoParam
    {
        public int opcion { get; set; }
        public int idCondPago { get; set; }
        public string condicion { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetCondPagoParam()
        {
            opcion = 0;
            idCondPago = 0;
            condicion = "";
            usuarioReg = "";
            estado = false;
        }
    }
}
