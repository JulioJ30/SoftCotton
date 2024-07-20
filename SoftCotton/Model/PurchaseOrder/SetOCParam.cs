using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class SetOCParam
    {
        public int opcion { get; set; }
        public int idEmpresa { get; set; }
        public int idOC { get; set; }
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

        public SetOCParam()
        {
            opcion = 0;
            idEmpresa = 0;
            idOC = 0;
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
        }

    }
}
