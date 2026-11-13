using System;

namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Fila del reporte de stock por almacén. uspGetTransferenciaAlmacen @opcion = 5.
    /// </summary>
    public class StockAlmacenReporte
    {
        public string CodAlmacen { get; set; }
        public string Almacen { get; set; }
        public string codNivel { get; set; }
        public string codGrupo { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public string Codigo { get; set; }
        public string Nivel { get; set; }
        public string Articulo { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public string UM { get; set; }
        public decimal Stock { get; set; }
        public decimal StockCentral { get; set; }
        public DateTime? FechaUltimoMovimiento { get; set; }

        /// <summary>
        /// El central negativo indica que el producto se despachó con guía desde este
        /// almacén sin registrar antes la devolución al almacén central.
        /// </summary>
        public bool TieneAlerta
        {
            get { return CodAlmacen != AlmacenItem.CodigoCentral && StockCentral < 0; }
        }
    }
}
