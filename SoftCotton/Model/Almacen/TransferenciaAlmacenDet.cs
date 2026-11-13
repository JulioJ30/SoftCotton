namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Línea de una transferencia ya registrada. uspGetTransferenciaAlmacen @opcion = 3.
    /// </summary>
    public class TransferenciaAlmacenDet
    {
        public int IdTransferenciaDet { get; set; }
        public int IdTransferencia { get; set; }
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
        public string codCuenta { get; set; }
        public decimal Cantidad { get; set; }
        public string Comentario { get; set; }
    }
}
