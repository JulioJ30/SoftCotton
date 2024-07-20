using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetTipoCambioParam
    {
        public int opcion { get; set; }
        public string fecha { get; set; }
        public int idTipoMoneda { get; set; }
        public decimal compra { get; set; }
        public decimal venta { get; set; }
        public string usuarioReg { get; set; }

        public SetTipoCambioParam()
        {
            opcion = 0;
            fecha = new DateTime(1970, 1, 1).Date.ToString("yyyyMMdd");
            idTipoMoneda = 0;
            compra = 0;
            venta = 0;
            usuarioReg = "";
        }
    }
}
