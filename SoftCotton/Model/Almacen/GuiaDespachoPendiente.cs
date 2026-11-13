using System;

namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Línea de guía de remisión despachada (salida) con cantidad pendiente de ingresar a un
    /// almacén. Buscador del registro de ingresos: uspGetMovimientoAlmacen @opcion = 4.
    /// </summary>
    public class GuiaDespachoPendiente
    {
        public int grIdEmpresa { get; set; }
        public string grSerie { get; set; }
        public string grNumero { get; set; }
        public string grDestCodigoPC { get; set; }
        public int grSecuencia { get; set; }
        public string grTipoOrden { get; set; }
        public string Guia { get; set; }
        public DateTime FechaGuia { get; set; }
        public string Destinatario { get; set; }
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
        public decimal Despachado { get; set; }
        public decimal Ingresado { get; set; }
        public decimal Pendiente { get; set; }

        /// <summary>Cantidad que aún puede ingresarse (columna común del buscador).</summary>
        public decimal Disponible
        {
            get { return Pendiente; }
        }
    }
}
