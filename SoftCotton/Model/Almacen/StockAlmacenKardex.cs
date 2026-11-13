using System;

namespace SoftCotton.Model.Almacen
{
    /// <summary>
    /// Fila del reporte de stock por almacén tipo Kardex (solo cantidades).
    /// uspGetMovimientoAlmacen @opcion = 6.
    ///
    /// Por almacén y producto: una fila SALDO INICIAL (si había stock antes del rango) y una
    /// fila por cada ingreso / salida; Saldo es el stock acumulado después de cada fila, así
    /// que la última fila de cada producto (EsUltima) es su stock final.
    /// </summary>
    public class StockAlmacenKardex
    {
        public const string FilaSaldoInicial = "SI";
        public const string FilaIngreso = "I";
        public const string FilaSalida = "S";

        public string CodAlmacen { get; set; }
        public string Almacen { get; set; }
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
        public long Orden { get; set; }
        public DateTime? Fecha { get; set; }
        public string TipoFila { get; set; }
        public string Movimiento { get; set; }
        public string Numero { get; set; }
        public string Guia { get; set; }
        public string Destinatario { get; set; }
        public string Observacion { get; set; }
        public decimal Ingreso { get; set; }
        public decimal Salida { get; set; }
        public decimal Saldo { get; set; }
        public bool EsUltima { get; set; }

        /// <summary>Primera fila del producto dentro del almacén (inicio de grupo).</summary>
        public bool EsPrimera { get; set; }

        /// <summary>Índice del grupo almacén + producto (para alternar el color de fondo).</summary>
        public int Grupo { get; set; }

        public bool EsSaldoInicial
        {
            get { return TipoFila == FilaSaldoInicial; }
        }

        public string ClaveGrupo
        {
            get { return CodAlmacen + "|" + Codigo; }
        }
    }
}
