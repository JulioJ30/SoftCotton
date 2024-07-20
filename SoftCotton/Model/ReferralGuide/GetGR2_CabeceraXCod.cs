using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class GetGR2_CabeceraXCod
    {
        public int idEmpresa { get; set; }

        public string ruc { get; set; }

        public string serie { get; set; }

        public string numero { get; set; }

        public string fechaEmision { get; set; }
        public string fechaVencimiento { get; set; }

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
        public string numeroLicenciaConducir { get; set; }

        public string codTipoCpte { get; set; }

        public string numCptePago { get; set; }

        public string usuarioReg { get; set; }

        public string fechaReg { get; set; }

        public int voucher { get; set; }

        public string tipoOrden { get; set; }
        public string descripcionCliente { get; set; }
        public string direccionCliente { get; set; }


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
        public string observaciones { get; set; }

        public string codMotivoTrasladoSunat { get; set; }


        public string codTipoDocConductor { get; set; }
        public string numdocConductor { get; set; }
        public string nombresConductor { get; set; }
        public string apellidosConductor { get; set; }
        public string puntoLlegadaUbigeo { get; set; }
        public bool enviadoSunat { get; set; }
        public string respuestaSunat { get; set; }
        public string otrosMotivoTraslado { get; set; }
        public string constanciaInscripcion { get; set; }
        public string codTipoTransporte { get; set; }

        public string DamDs { get; set; }
        public string cuo { get; set; }



    }
}
