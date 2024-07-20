using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetTipoMonedaParam
    {
        public int opcion { get; set; }
        public int idTipoMoneda { get; set; }
        public string simbolo { get; set; }
        public string monedaSingular { get; set; }
        public string monedaPlural { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetTipoMonedaParam()
        {
            opcion = 0;
            idTipoMoneda = 0;
            simbolo = "";
            monedaSingular = "";
            monedaPlural = "";
            usuarioReg = "";
            estado = false;
        }
    }
}
