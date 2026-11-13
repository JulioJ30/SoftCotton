namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Almacén activo (AreasAlmacen) para combos. uspGetTransferenciaAlmacen @opcion = 1.
    /// </summary>
    public class AlmacenItem
    {
        public const string CodigoCentral = "000";

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string tResumido { get; set; }
        public bool EsCentral { get; set; }

        public string Texto
        {
            get { return Codigo + " - " + Descripcion; }
        }
    }
}
