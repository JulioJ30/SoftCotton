﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Invoices
{
    public class GetFact3_Cabecera
    {
        public int idEmpresa { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public string fechaEmision { get; set; }
        public string codigoPC { get; set; }
        public string razonSocial { get; set; }
        public int idTipoMoneda { get; set; }


        public decimal tipoCambio { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
        public string contabilizado { get; set; }

        public string numeroNotaCredito { get; set; }
        public string OP { get; set; }

        public string serieNotaCredito { get; set; }
        public string codTipoCpte { get; set; }
        public string observacionNotaCredito { get; set; }



    }
}
