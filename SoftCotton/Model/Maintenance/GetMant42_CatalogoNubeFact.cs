using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant42_CatalogoNubeFact
    {
        public string codigoInterno { get; set; }
        public int? idCategoria { get; set; }
        public string codUm { get; set; }
        public string codMoneda { get; set; }

        public string descripcionCatalogo { get; set; }
        public decimal? ventaValorUnitarioSinIgv { get; set; }
        public decimal? ventaPrecioUnitarioIgv { get; set; }
        public decimal? compraValorUnitarioSinIgv { get; set; }
        public decimal? compraPrecioUnitarioIgv { get; set; }
        public string destacado { get; set; }
        public string tipoAfectacionIgv { get; set; }
        public string codProductoSunat { get; set; }

        public decimal stockActualDisponible { get; set; }
        public int total { get; set; }

    }
}
