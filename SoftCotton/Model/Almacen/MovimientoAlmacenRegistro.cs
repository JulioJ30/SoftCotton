using System;
using System.Collections.Generic;

namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Datos para registrar un ingreso o una salida (cabecera + detalle en una sola llamada a
    /// uspSetMovimientoAlmacen @opcion = 1).
    /// </summary>
    public class MovimientoAlmacenRegistro
    {
        public string TipoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string CodAlmacen { get; set; }
        public string Observacion { get; set; }
        public int IdUsuario { get; set; }
        public List<MovimientoAlmacenLinea> Detalle { get; set; }

        public MovimientoAlmacenRegistro()
        {
            Detalle = new List<MovimientoAlmacenLinea>();
        }

        public bool EsIngreso
        {
            get { return TipoMovimiento == MovimientoAlmacenCab.TipoIngreso; }
        }
    }

    /// <summary>
    /// Línea del detalle en edición.
    ///   Ingreso: proviene de una línea de guía despachada (gr*); Disponible = pendiente.
    ///   Salida : proviene de un producto con stock en el almacén; Disponible = stock.
    /// Los campos descriptivos son solo para la pantalla.
    /// </summary>
    public class MovimientoAlmacenLinea
    {
        // referencia a la línea de guía (solo ingresos)
        public int? grIdEmpresa { get; set; }
        public string grSerie { get; set; }
        public string grNumero { get; set; }
        public string grDestCodigoPC { get; set; }
        public int? grSecuencia { get; set; }
        public string grTipoOrden { get; set; }
        public DateTime? FechaGuia { get; set; }

        public string codNivel { get; set; }
        public string codGrupo { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public decimal Cantidad { get; set; }
        public string Comentario { get; set; }

        public string Guia { get; set; }
        public string Codigo { get; set; }
        public string Articulo { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public string UM { get; set; }
        public decimal Disponible { get; set; }

        public bool DeGuia
        {
            get { return grSecuencia.HasValue; }
        }

        /// <summary>Identifica la línea: la línea de guía (ingreso) o el producto (salida).</summary>
        public string Clave
        {
            get
            {
                return DeGuia
                    ? ClaveGuia(grIdEmpresa.Value, grSerie, grNumero, grDestCodigoPC, grSecuencia.Value, grTipoOrden)
                    : ClaveProducto(codNivel, codGrupo, codTalla, codColor);
            }
        }

        public static string ClaveProducto(string nivel, string grupo, string talla, string color)
        {
            return (nivel ?? "").Trim() + "." + (grupo ?? "").Trim() + "." + (talla ?? "").Trim() + "." + (color ?? "").Trim();
        }

        public static string ClaveGuia(int empresa, string serie, string numero, string destino, int secuencia, string tipoOrden)
        {
            return "G|" + empresa + "|" + (serie ?? "").Trim() + "|" + (numero ?? "").Trim() + "|"
                + (destino ?? "").Trim() + "|" + secuencia + "|" + (tipoOrden ?? "").Trim();
        }

        public static MovimientoAlmacenLinea DesdeGuia(GuiaDespachoPendiente g)
        {
            return new MovimientoAlmacenLinea
            {
                grIdEmpresa = g.grIdEmpresa,
                grSerie = g.grSerie,
                grNumero = g.grNumero,
                grDestCodigoPC = g.grDestCodigoPC,
                grSecuencia = g.grSecuencia,
                grTipoOrden = g.grTipoOrden,
                FechaGuia = g.FechaGuia,
                codNivel = g.codNivel,
                codGrupo = g.codGrupo,
                codTalla = g.codTalla,
                codColor = g.codColor,
                Guia = g.Guia,
                Codigo = g.Codigo,
                Articulo = g.Articulo,
                Talla = g.Talla,
                Color = g.Color,
                UM = g.UM,
                Disponible = g.Pendiente,
                Cantidad = g.Pendiente
            };
        }

        public static MovimientoAlmacenLinea DesdeProducto(ProductoStockAlmacen p)
        {
            return new MovimientoAlmacenLinea
            {
                codNivel = p.codNivel,
                codGrupo = p.codGrupo,
                codTalla = p.codTalla,
                codColor = p.codColor,
                Guia = "",
                Codigo = p.Codigo,
                Articulo = p.Articulo,
                Talla = p.Talla,
                Color = p.Color,
                UM = p.UM,
                Disponible = p.Stock,
                Cantidad = p.Stock
            };
        }
    }
}
