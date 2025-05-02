using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class GetGR6_RpteGROC
    {
        public string tipo { get; set; }
        public int codigo { get; set; }
        public int secuencia { get; set; }
        public string codProducto { get; set; }
        public string codGrupoAlt { get; set; }
        public decimal cantidad { get; set; }
        public decimal igv { get; set; }
        public decimal precioUnitario { get; set; }
        public string codigoPC { get; set; }
        public string razonSocial { get; set; }
        public string cobservacion { get; set; }

        public string gserie { get; set; }
        public string gnumero { get; set; }
        public string gfechaInicioTraslado { get; set; }
        public string gdestCodigoPC { get; set; }
        public string gdestRazonSocial { get; set; }
        public string gtransCodigoPC { get; set; }
        public string gtransRazonSocial { get; set; }
        public string gnumeroPartida { get; set; }
        public string gtransMarca { get; set; }
        public string gtransNumPlaca { get; set; }
        public string gtransNumLicConducir { get; set; }
        public string gcodTipoCpte { get; set; }
        public string gtipoComprobante { get; set; }
        public string gnumCptePago { get; set; }
        public int gsecuencia { get; set; }
        public string gcodCuenta { get; set; }
        public decimal gcantidadIngresada { get; set; }
        public decimal gpesoIngresado { get; set; }
        public string gtipoMovimiento { get; set; }
        public string gPeriodo { get; set; }

        public string fserie { get; set; }
        public string fnumero { get; set; }
        public string ffechaEmision { get; set; }
        public string fcodigoPC { get; set; }
        public string frazonSocial { get; set; }
        public int fsecuencia { get; set; }
        public string fcodigo { get; set; }
        public string fdescripcion { get; set; }
        public string ftalla { get; set; }
        public string fcolor { get; set; }
        public string fcodUM { get; set; }
        public decimal fcantidad { get; set; }
        public decimal figv { get; set; }
        public decimal fprecioUnitario { get; set; }
        public decimal ftipoCambio { get; set; }
        public string ftipoMoneda { get; set; }
        public string fserieNotaCredito { get; set; }
        public string fnumeroNotaCredito { get; set; }
        public string fobservacionNotaCredito { get; set; }
        public string Op { get; set; }


    }
}
