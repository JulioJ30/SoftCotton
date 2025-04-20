using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class GetOC19_Reporte
    {
        public int idEmpresa { get; set; }
        public int idOC { get; set; }
        public string fechaEmision { get; set; }
        public string fechaEntrega { get; set; }
        public string codigoPC { get; set; }
        public string razonsocial { get; set; }
        public string tipoMoneda { get; set; }
        public string tipoCompra { get; set; }
        public string condicion { get; set; }
        public string estadooc { get; set; }
        public string usuCreacionReg { get; set; }
        public string usuFechaReg { get; set; }
        public string observacion { get; set; }

        public string codNivel { get; set; }
        public string codGrupo { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public string codProductoGeneral { get; set; }
        public string producto { get; set; }
        public string color { get; set; }
        public string obs1 { get; set; }
        public string obs2 { get; set; }
        public string obs3 { get; set; }
        public string obs4 { get; set; }
        public string obs5 { get; set; }

        public decimal cantidad { get; set; }
        public string codUM { get; set; }
        public decimal igv { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }
        public string programa { get; set; }


    }
}
