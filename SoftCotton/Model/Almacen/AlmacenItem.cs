namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Almacén activo (AreasAlmacen) para combos. uspGetMovimientoAlmacen @opcion = 1.
    /// </summary>
    public class AlmacenItem
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string tResumido { get; set; }

        public string Texto
        {
            get { return Codigo + " - " + Descripcion; }
        }

        public string NombreCorto
        {
            get { return string.IsNullOrWhiteSpace(tResumido) ? Descripcion : tResumido.Trim(); }
        }
    }
}
