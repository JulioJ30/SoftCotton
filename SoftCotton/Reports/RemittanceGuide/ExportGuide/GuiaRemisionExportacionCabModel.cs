using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Reports.RemittanceGuide.ExportGuide
{
    public class GuiaRemisionExportacionCabModel
    {
        public int idEmpresa { get; set; }
        public string ruc { get; set; }
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

        public int idConstanciaInscripcion { get; set; }
        public string constanciaInscripcion { get; set; }
        public int idNumeroLicenciaConducir { get; set; }
        public string numeroLicenciaConducir { get; set; }

        public string codTipoCpte { get; set; }
        public string numCptePago { get; set; }
        public string usuarioReg { get; set; }
        public int voucher { get; set; }
        public string tipoOrden { get; set; }
        public string codCuenta { get; set; }

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

        public GuiaRemisionExportacionCabModel()
        {
            idEmpresa = 0;
            ruc = "";
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

            idConstanciaInscripcion = 0;
            constanciaInscripcion = "";
            idNumeroLicenciaConducir = 0;
            numeroLicenciaConducir = "";

            codTipoCpte = "";
            numCptePago = "";
            usuarioReg = "";
            voucher = 0;
            tipoOrden = "";
            codCuenta = "";

            idMotivoTraslado = 0;
            numero_contenedor = "";
            precinto_aduana = "";
            precinto_linea = "";
            precinto = "";

            total = 0;
            gross_weight = 0;
            net_weight = 0;

            total_um = "";
            gross_weight_um = "";
            net_weight_um = "";
        }
    }

}
