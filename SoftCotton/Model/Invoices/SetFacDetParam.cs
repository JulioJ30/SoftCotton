﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Invoices
{
    public class SetFacDetParam
    {
        public int opcion { get; set; }
        public int idEmpresa { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public int secuencia { get; set; }

        public int grIdEmpresa { get; set; }
        public string grSerie { get; set; }
        public string grNumero { get; set; }
        public int grSecuencia { get; set; }

        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string codUM { get; set; }
        public decimal cantidad { get; set; }
        public decimal igv { get; set; }
        public decimal precioUnitario { get; set; }
        
        public string codigoPC { get; set; }
        public string grTipoOrden { get; set; }

        public decimal cantidadNotaCredito { get; set; }
        public string serieNotaCredito { get; set; }
        public string numeroNotaCredito { get; set; }
        public string codTipoCpte { get; set; }



        public SetFacDetParam()
        {
            opcion = 0;
            idEmpresa = 0;
            serie = "";
            numero = 0;
            secuencia = 0;
            grIdEmpresa = 0;
            grSerie = "";
            grNumero = "";
            grSecuencia = 0;
            codigo = "";
            descripcion = "";
            codUM = "";
            cantidad = 0;
            cantidadNotaCredito = 0;
            igv = 0;
            precioUnitario = 0;
            codigoPC = "";
            grTipoOrden = "";

            serieNotaCredito = "";
            numeroNotaCredito = "";
            codTipoCpte = "";

        }
    }
}