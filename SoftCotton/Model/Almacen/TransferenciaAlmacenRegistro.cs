using System;
using System.Collections.Generic;

namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Datos para registrar una transferencia (cabecera + detalle en una sola llamada a
    /// uspSetTransferenciaAlmacen @opcion = 1).
    /// </summary>
    public class TransferenciaAlmacenRegistro
    {
        public DateTime FechaTransferencia { get; set; }
        public string CodAlmacenOrigen { get; set; }
        public string CodAlmacenDestino { get; set; }
        public string Observacion { get; set; }
        public int IdUsuario { get; set; }
        public List<TransferenciaAlmacenLinea> Detalle { get; set; }

        public TransferenciaAlmacenRegistro()
        {
            Detalle = new List<TransferenciaAlmacenLinea>();
        }
    }

    /// <summary>
    /// Línea del detalle en edición. Los campos descriptivos son solo para la pantalla.
    /// </summary>
    public class TransferenciaAlmacenLinea
    {
        public string codNivel { get; set; }
        public string codGrupo { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public string codCuenta { get; set; }
        public decimal Cantidad { get; set; }
        public string Comentario { get; set; }

        public string Codigo { get; set; }
        public string Articulo { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public string UM { get; set; }
        public decimal StockDisponible { get; set; }

        public string Clave
        {
            get { return ClaveProducto(codNivel, codGrupo, codTalla, codColor); }
        }

        public static string ClaveProducto(string nivel, string grupo, string talla, string color)
        {
            return (nivel ?? "").Trim() + "." + (grupo ?? "").Trim() + "." + (talla ?? "").Trim() + "." + (color ?? "").Trim();
        }

        public static TransferenciaAlmacenLinea DesdeProducto(ProductoStockAlmacen p)
        {
            return new TransferenciaAlmacenLinea
            {
                codNivel = p.codNivel,
                codGrupo = p.codGrupo,
                codTalla = p.codTalla,
                codColor = p.codColor,
                codCuenta = p.codCuenta,
                Codigo = p.Codigo,
                Articulo = p.Articulo,
                Talla = p.Talla,
                Color = p.Color,
                UM = p.UM,
                StockDisponible = p.Stock,
                Cantidad = p.Stock
            };
        }

        public static TransferenciaAlmacenLinea DesdeStock(StockAlmacenReporte s)
        {
            return new TransferenciaAlmacenLinea
            {
                codNivel = s.codNivel,
                codGrupo = s.codGrupo,
                codTalla = s.codTalla,
                codColor = s.codColor,
                codCuenta = null,
                Codigo = s.Codigo,
                Articulo = s.Articulo,
                Talla = s.Talla,
                Color = s.Color,
                UM = s.UM,
                StockDisponible = s.Stock,
                Cantidad = s.Stock
            };
        }
    }
}
