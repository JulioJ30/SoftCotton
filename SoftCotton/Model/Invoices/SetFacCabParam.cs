using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Invoices
{
    public class SetFacCabParam
    {
        public int opcion { get; set; }
        public int idEmpresa { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public string fechaEmision { get; set; }
        public string codigoPC { get; set; }
        public int idTipoMoneda { get; set; }
        public string usuarioReg { get; set; }


        public decimal tipoCambio { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
        public string contabilizado { get; set; }


        public string codTipoCpte { get; set; }
        public string serieNotaCredito { get; set; }
        public string numeroNotaCredito { get; set; }
        public string observacionNotaCredito { get; set; }





    }
}
