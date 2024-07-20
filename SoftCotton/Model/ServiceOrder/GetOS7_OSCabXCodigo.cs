using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ServiceOrder
{
    public class GetOS7_OSCabXCodigo
    {
        public int idEmpresa { get; set; }
        public int idOS { get; set; }
        public string fechaEmision { get; set; }
        public string fechaEntrega { get; set; }

        public string codigoPC { get; set; }
        public string razonSocial { get; set; }
        public string direccion { get; set; }

        public int idTipoMoneda { get; set; }
        public string tipoCompra { get; set; }
        public int idCondPago { get; set; }

        public int idTipoAprobacion { get; set; }
        public string tipoAprobacion { get; set; }

        public int idTipoAnulado { get; set; }
        public string fechaAnulado { get; set; }
        public string usuarioAnulado { get; set; }

        public string usuCreacionReg { get; set; }
        public string usuFechaReg { get; set; }

        public string observacion { get; set; }

        public string codServicio { get; set; }
        public string nombreServicio { get; set; }

        public string codPrograma { get; set; }
        public string nombrePrograma { get; set; }

        public decimal subTotal { get; set; }
        public decimal igv { get; set; }
        public decimal total { get; set; }

        public GetOS7_OSCabXCodigo()
        {
            fechaEmision = new DateTime(1970, 1, 1).ToString("yyyy-MM-dd");
            fechaEntrega = new DateTime(1970, 1, 1).ToString("yyyy-MM-dd");

            codigoPC = "";
            razonSocial = "";
            direccion = "";
            tipoCompra = "";
            tipoAprobacion = "";
            fechaAnulado = "";
            usuarioAnulado = "";
            usuCreacionReg = "";
            usuFechaReg = "";
            observacion = "";
            codServicio = "";
            nombreServicio = "";
            codPrograma = "";
            nombrePrograma = "";
        }

    }
}
