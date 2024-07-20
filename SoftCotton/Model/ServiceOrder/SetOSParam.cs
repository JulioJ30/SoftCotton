using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ServiceOrder
{
    public class SetOSParam
    {
        public int opcion { get; set; }
        public int idEmpresa { get; set; }
        public int idOS { get; set; }
        public string fechaEmision { get; set; }
        public string fechaEntrega { get; set; }
        public string codigoPC { get; set; }
        public int idTipoMoneda { get; set; }
        public string tipoCompra { get; set; }
        public int idCondPago { get; set; }
        public int idTipoAprobacion { get; set; }
        public int idTipoAnulado { get; set; }
        public string fechaAnulado { get; set; }
        public string usuarioAnulado { get; set; }
        public string usuarioRegistro { get; set; }
        public string observacion { get; set; }
        public string CodPrograma { get; set; }
        public string CodServicio { get; set; }

        public int secuencia { get; set; }
        public int idPedidoColor { get; set; }
        public decimal precio { get; set; }
        public string codTalla { get; set; }
        public int cantidad { get; set; }


        public SetOSParam()
        {
            opcion = 0;
            idEmpresa = 0;
            idOS = 0;
            fechaEmision = "";
            fechaEntrega = "";
            codigoPC = "";
            idTipoMoneda = 0;
            tipoCompra = "";
            idCondPago = 0;
            idTipoAprobacion = 0;
            idTipoAnulado = 0;
            fechaAnulado = "";
            usuarioAnulado = "";
            usuarioRegistro = "";
            observacion = "";
            CodPrograma = "";
            CodServicio = "";

            secuencia = 0;
            idPedidoColor = 0;
            precio = 0;
            codTalla = "";
            cantidad = 0;



        }
    }
}
