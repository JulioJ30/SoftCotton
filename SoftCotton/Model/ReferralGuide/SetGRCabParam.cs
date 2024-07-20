using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class SetGRCabParam
    {
        public int opcion { get; set; }
        public int idEmpresa { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public string fechaEmision { get; set; }
        public string puntoPartida { get; set; }
        public string puntoLlegada { get; set; }
        public string fechaInicioTraslado { get; set; }
        public string destCodigoPC { get; set; }
        public string transCodigoPC { get; set; }
        public string transMarca { get; set; }
        public string transNumPlaca { get; set; }
        public string transNumConstInscr { get; set; }
        public string transNumLicConducir { get; set; }
        public string codTipoCpte { get; set; }
        public string numCptePago { get; set; }
        public string usuarioReg { get; set; }
        public int voucher { get; set; }
        public string tipoOrden { get; set; }
        public string codCuenta { get; set; }
        public int idMotivoTraslado { get; set; }
        public string observaciones { get; set; }
        public bool enviadoSunat { get; set; }
        public string respuestaSunat { get; set; }
        public string otrosMotivoTraslado { get; set; }
        public string codTipoTransporte { get; set; }




        public SetGRCabParam()
        {
            opcion = 0;
            idEmpresa = 0;
            serie = "";
            numero = "";
            fechaEmision = "";
            puntoPartida = "";
            puntoLlegada = "";
            fechaInicioTraslado = "";
            destCodigoPC = "";
            transCodigoPC = "";
            transMarca = "";
            transNumPlaca = "";
            transNumConstInscr = "";
            transNumLicConducir = "";
            codTipoCpte = "";
            numCptePago = "";
            usuarioReg = "";
            voucher = 0;
            tipoOrden = "";
            codCuenta = "";
            idMotivoTraslado = 0;
            observaciones = "";
            enviadoSunat = false;
            respuestaSunat = "";
            otrosMotivoTraslado = "";
            codTipoTransporte = "";



        }

    }
}
