using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetTipoComprobanteParam
    {
        public int opcion { get; set; }
        public string codTipoCpte { get; set; }
        public string codTipoCpteUpdate { get; set; }
        public string tipoComprobante { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetTipoComprobanteParam()
        {
            opcion = 0;
            codTipoCpte = "";
            codTipoCpteUpdate = "";
            tipoComprobante = "";
            usuarioReg = "";
            estado = false;
        }
    }
}
