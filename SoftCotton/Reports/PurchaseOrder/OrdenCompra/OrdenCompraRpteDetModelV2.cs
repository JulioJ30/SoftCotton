﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Reports.PurchaseOrder.OrdenCompra
{
    public class OrdenCompraRpteDetModelV2
    {
        public int idEmpresa { get; set; }
        public int idOC { get; set; }
        //public int secuencia { get; set; }
        public string codNivel { get; set; }
        //public string codGrupo { get; set; }
        //public string codTalla { get; set; }
        public string codColor { get; set; }
        public string codProductoGeneral { get; set; }
        public string producto { get; set; }
        public string color { get; set; }
        //public decimal cantidad { get; set; }
        public OrdenCompraRpteDetModelTallaV2 Tallas { get; set; }
        public string codUM { get; set; }
        //public decimal igv { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }

        public string codTalla { get; set; }
        public string tallaDescripcion { get; set; }


        //public string obs1 { get; set; }
        //public string obs2 { get; set; }
        //public string obs3 { get; set; }
        //public string obs4 { get; set; }
        //public string obs5 { get; set; }
    }
}