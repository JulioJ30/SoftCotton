using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class SetGRDetParam
    {
        public int opcion { get; set; }
        
        public int idEmpresa { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public int secuencia { get; set; }
        public int idEmpresaDet { get; set; }
        public int idDet { get; set; }
        public int idSecuenciaDet { get; set; }

        public string codCuenta { get; set; }
        public string tipoMovimiento { get; set; }
        public decimal cantidadIngresada { get; set; }
        public decimal pesoIngresado { get; set; }

        public string numeroPartida { get; set; }
        public string tipoOrden { get; set; }
        public string OP { get; set; }

        public int? IdPedidoColor { get; set; }
        public string PartidaProveedor { get; set; }
        public string destCodigoPC { get; set; }
        public string Comentario { get; set; }

        public decimal PrecioGr { get; set; }


        public SetGRDetParam()
        {
            opcion = 0;
            idEmpresa = 0;
            serie = "";
            numero = "";
            secuencia = 0;
            idEmpresaDet = 0;
            idDet = 0;
            idSecuenciaDet = 0;
            cantidadIngresada = 0;
            pesoIngresado = 0;
            tipoMovimiento = "";
            numeroPartida = "";
            codCuenta = "";
            tipoOrden = "";
            OP = "";
            IdPedidoColor = null;
            PartidaProveedor = "";
            destCodigoPC = "";
            Comentario = "";
            PrecioGr = 0;
        }
    }
}
