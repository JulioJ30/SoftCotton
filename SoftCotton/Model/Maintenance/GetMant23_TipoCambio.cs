using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant23_TipoCambio
    {
        public string fecha { get; set; }
        public int idTipoMoneda { get; set; }
        public string monedaSingular { get; set; }
        public decimal compra { get; set; }
        public decimal venta { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }
    }
}
