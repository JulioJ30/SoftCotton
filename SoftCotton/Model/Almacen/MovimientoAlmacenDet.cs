using System;

namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Línea de un ingreso o salida ya registrado. uspGetMovimientoAlmacen @opcion = 3.
    /// Guia / FechaGuia / Destinatario solo vienen en los ingresos.
    /// </summary>
    public class MovimientoAlmacenDet
    {
        public int IdMovimientoDet { get; set; }
        public int IdMovimiento { get; set; }
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
        public decimal Cantidad { get; set; }
        public string Guia { get; set; }
        public DateTime? FechaGuia { get; set; }
        public string Destinatario { get; set; }
        public string Comentario { get; set; }
    }
}
