using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class GetGR8_RpteExportacion
    {
        public int idEmpresa { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }

        public string fechaEmision { get; set; }
        public string puntoPartida { get; set; }
        public string puntoLlegada { get; set; }
        public string fechaInicioTraslado { get; set; }
        public string destCodigoPC { get; set; }
        public string destRS { get; set; }
        public string transCodigoPC { get; set; }
        public string transRS { get; set; }
        public string transMarca { get; set; }
        public string transNumPlaca { get; set; }
        public string transNumConstInscr { get; set; }
        public string transNumLicConducir { get; set; }
        public string codTipoCpte { get; set; }
        public string numCptePago { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }

        public int voucher { get; set; }
        public string tipoOrden { get; set; }

        public string ruc { get; set; }

        // DETALLE
        public int secuencia { get; set; }
        public decimal cantidadIngresada { get; set; }
        public string descripcion { get; set; }
        public string codUM { get; set; }
        public string descripcionUM { get; set; }



    }
}
