using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class SetGRCabExportacionParam
    {
        public int opcion { get; set; }

        public int idEmpresa { get; set; }

        public string serie { get; set; }

        public string numero { get; set; }

        public string ruc { get; set; }

        public string fechaEmision { get; set; }
        public string fechaVencimiento { get; set; }
        public string observaciones { get; set; }



        public string puntoPartida { get; set; }

        public string puntoLlegada { get; set; }

        public string fechaInicioTraslado { get; set; }

        public string destCodigoPC { get; set; }

        public string transCodigoPC { get; set; }

        public string transMarca { get; set; }

        public string transNumPlaca { get; set; }

        public string transNumConstInscr { get; set; }

        public string transNumLicConducir { get; set; }

        public string usuarioReg { get; set; }

        public int idConstanciaInscripcion { get; set; }

        public int idNumeroLicenciaConducir { get; set; }

        public int idMotivoTraslado { get; set; }

        public string numero_contenedor { get; set; }

        public string precinto_aduana { get; set; }

        public string precinto_linea { get; set; }

        public string precinto { get; set; }

        public decimal total { get; set; }

        public decimal gross_weight { get; set; }

        public decimal net_weight { get; set; }

        public string total_um { get; set; }

        public string gross_weight_um { get; set; }

        public string net_weight_um { get; set; }
        public bool enviadoSunat { get; set; }
        public string respuestaSunat { get; set; }
        public string DamDs { get; set; }
        public string otrosMotivoTraslado { get; set; }


        public SetGRCabExportacionParam()
        {
            opcion = 0;
            idEmpresa = 0;
            serie = "";
            numero = "";
            ruc = "";
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
            usuarioReg = "";
            idConstanciaInscripcion = 0;
            idNumeroLicenciaConducir = 0;
            idMotivoTraslado = 0;
            numero_contenedor = "";
            precinto_aduana = "";
            precinto_linea = "";
            precinto = "";
            total = 0m;
            gross_weight = 0m;
            net_weight = 0m;
            total_um = "";
            gross_weight_um = "";
            net_weight_um = "";

            fechaVencimiento = "";
            observaciones = "";
            enviadoSunat = false;
            respuestaSunat = "";

            DamDs = "";
            otrosMotivoTraslado = "";

        }
    }
}
