namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Producto con stock en un almacén (lo ingresado menos lo que salió). Buscador del
    /// registro de salidas: uspGetMovimientoAlmacen @opcion = 5.
    /// </summary>
    public class ProductoStockAlmacen
    {
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

        /// <summary>Cantidad que puede salir (columna común del buscador).</summary>
        public decimal Disponible
        {
            get { return Stock; }
        }
    }
}
