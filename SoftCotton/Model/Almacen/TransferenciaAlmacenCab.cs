using System;

namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Cabecera de transferencia para el listado. uspGetTransferenciaAlmacen @opcion = 2.
    /// </summary>
    public class TransferenciaAlmacenCab
    {
        public const string EstadoActivo = "A";
        public const string EstadoAnulado = "N";
        public const string TipoNormal = "T";
        public const string TipoDevolucion = "D";

        public int IdTransferencia { get; set; }
        public string Numero { get; set; }
        public string TipoTransferencia { get; set; }
        public string TipoDescripcion { get; set; }
        public DateTime FechaTransferencia { get; set; }
        public string CodAlmacenOrigen { get; set; }
        public string AlmacenOrigen { get; set; }
        public string CodAlmacenDestino { get; set; }
        public string AlmacenDestino { get; set; }
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

        public bool EstaAnulada
        {
            get { return Estado == EstadoAnulado; }
        }
    }
}
