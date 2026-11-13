using System;

namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Cabecera de un ingreso o salida de almacén para el listado.
    /// uspGetMovimientoAlmacen @opcion = 2.
    /// </summary>
    public class MovimientoAlmacenCab
    {
        public const string EstadoActivo = "A";
        public const string EstadoAnulado = "N";
        public const string TipoIngreso = "I";
        public const string TipoSalida = "S";

        public int IdMovimiento { get; set; }
        public string Numero { get; set; }
        public string TipoMovimiento { get; set; }
        public string TipoDescripcion { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string CodAlmacen { get; set; }
        public string Almacen { get; set; }
        public string Guias { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public string EstadoDescripcion { get; set; }
        public int Items { get; set; }
        public decimal CantidadTotal { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioAnulacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }

        public bool EstaAnulado
        {
            get { return Estado == EstadoAnulado; }
        }

        public bool EsIngreso
        {
            get { return TipoMovimiento == TipoIngreso; }
        }
    }
}
