using Dapper;
using SoftCotton.Database;
using SoftCotton.Model.Almacen;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoftCotton.Repository
{
    /// <summary>
    /// Acceso a datos de Ingresos y Salidas de Almacén.
    /// Todos los métodos son asíncronos y aceptan cancelación, para no bloquear la interfaz.
    /// </summary>
    public class AlmacenRepository
    {
        private const string ProcConsulta = "uspGetMovimientoAlmacen";
        private const string ProcRegistro = "uspSetMovimientoAlmacen";
        private const string TipoDetalle = "dbo.MovimientoAlmacenDetTipo";

        private const int TimeoutSegundos = 120;

        public Task<List<AlmacenItem>> ListarAlmacenesAsync(CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 1);
            return ConsultarAsync<AlmacenItem>(p, ct);
        }

        public Task<List<MovimientoAlmacenCab>> ListarMovimientosAsync(DateTime? fechaIni, DateTime? fechaFin, string codAlmacen, string tipo, string estado, string texto, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 2);
            p.Add("@FechaIni", fechaIni, DbType.Date);
            p.Add("@FechaFin", fechaFin, DbType.Date);
            p.Add("@CodAlmacen", Nulo(codAlmacen), DbType.AnsiString, size: 3);
            p.Add("@TipoMovimiento", Nulo(tipo), DbType.AnsiStringFixedLength, size: 1);
            p.Add("@Estado", Nulo(estado), DbType.AnsiStringFixedLength, size: 1);
            p.Add("@Texto", Nulo(texto), DbType.AnsiString, size: 100);
            return ConsultarAsync<MovimientoAlmacenCab>(p, ct);
        }

        public Task<List<MovimientoAlmacenDet>> ListarDetalleAsync(int idMovimiento, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 3);
            p.Add("@IdMovimiento", idMovimiento);
            return ConsultarAsync<MovimientoAlmacenDet>(p, ct);
        }

        public Task<List<GuiaDespachoPendiente>> BuscarGuiasPendientesAsync(DateTime? fechaIni, DateTime? fechaFin, string codNivel, string texto, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 4);
            p.Add("@FechaIni", fechaIni, DbType.Date);
            p.Add("@FechaFin", fechaFin, DbType.Date);
            p.Add("@codNivel", Nulo(codNivel), DbType.AnsiStringFixedLength, size: 2);
            p.Add("@Texto", Nulo(texto), DbType.AnsiString, size: 100);
            return ConsultarAsync<GuiaDespachoPendiente>(p, ct);
        }

        public Task<List<ProductoStockAlmacen>> BuscarProductosConStockAsync(string codAlmacen, DateTime fechaCorte, string codNivel, string texto, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 5);
            p.Add("@CodAlmacen", codAlmacen, DbType.AnsiString, size: 3);
            p.Add("@FechaCorte", fechaCorte.Date, DbType.Date);
            p.Add("@codNivel", Nulo(codNivel), DbType.AnsiStringFixedLength, size: 2);
            p.Add("@Texto", Nulo(texto), DbType.AnsiString, size: 100);
            return ConsultarAsync<ProductoStockAlmacen>(p, ct);
        }

        public Task<List<StockAlmacenKardex>> ReporteStockAsync(string codAlmacen, DateTime fechaIni, DateTime fechaFin, string codNivel, string texto, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 6);
            p.Add("@CodAlmacen", Nulo(codAlmacen), DbType.AnsiString, size: 3);
            p.Add("@FechaIni", fechaIni.Date, DbType.Date);
            p.Add("@FechaFin", fechaFin.Date, DbType.Date);
            p.Add("@codNivel", Nulo(codNivel), DbType.AnsiStringFixedLength, size: 2);
            p.Add("@Texto", Nulo(texto), DbType.AnsiString, size: 100);
            return ConsultarAsync<StockAlmacenKardex>(p, ct);
        }

        /// <summary>
        /// Registra cabecera y detalle en una sola llamada (el detalle viaja como parámetro
        /// tipo tabla). El procedimiento maneja la transacción.
        /// </summary>
        public Task<Response> RegistrarAsync(MovimientoAlmacenRegistro registro, CancellationToken ct)
        {
            var detalle = new DataTable();
            detalle.Columns.Add("grIdEmpresa", typeof(int));
            detalle.Columns.Add("grSerie", typeof(string));
            detalle.Columns.Add("grNumero", typeof(string));
            detalle.Columns.Add("grDestCodigoPC", typeof(string));
            detalle.Columns.Add("grSecuencia", typeof(int));
            detalle.Columns.Add("grTipoOrden", typeof(string));
            detalle.Columns.Add("codNivel", typeof(string));
            detalle.Columns.Add("codGrupo", typeof(string));
            detalle.Columns.Add("codTalla", typeof(string));
            detalle.Columns.Add("codColor", typeof(string));
            detalle.Columns.Add("Cantidad", typeof(decimal));
            detalle.Columns.Add("Comentario", typeof(string));

            foreach (var linea in registro.Detalle)
            {
                // ingreso: viaja la referencia de la guía (el producto lo resuelve el proc)
                // salida : viaja el producto
                bool deGuia = registro.EsIngreso;
                detalle.Rows.Add(
                    deGuia ? (object)linea.grIdEmpresa : DBNull.Value,
                    deGuia ? (object)linea.grSerie : DBNull.Value,
                    deGuia ? (object)linea.grNumero : DBNull.Value,
                    deGuia ? (object)linea.grDestCodigoPC : DBNull.Value,
                    deGuia ? (object)linea.grSecuencia : DBNull.Value,
                    deGuia ? (object)linea.grTipoOrden : DBNull.Value,
                    deGuia ? DBNull.Value : (object)linea.codNivel,
                    deGuia ? DBNull.Value : (object)linea.codGrupo,
                    deGuia ? DBNull.Value : (object)linea.codTalla,
                    deGuia ? DBNull.Value : (object)linea.codColor,
                    linea.Cantidad,
                    string.IsNullOrWhiteSpace(linea.Comentario) ? (object)DBNull.Value : linea.Comentario.Trim());
            }

            var p = new DynamicParameters();
            p.Add("@opcion", 1);
            p.Add("@TipoMovimiento", registro.TipoMovimiento, DbType.AnsiStringFixedLength, size: 1);
            p.Add("@FechaMovimiento", registro.FechaMovimiento.Date, DbType.Date);
            p.Add("@CodAlmacen", registro.CodAlmacen, DbType.AnsiString, size: 3);
            p.Add("@Observacion", Nulo(registro.Observacion), DbType.AnsiString, size: 500);
            p.Add("@IdUsuario", registro.IdUsuario);
            p.Add("@Detalle", detalle.AsTableValuedParameter(TipoDetalle));

            return EjecutarAsync(p, ct);
        }

        public Task<Response> AnularAsync(int idMovimiento, string motivo, int idUsuario, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 2);
            p.Add("@IdMovimiento", idMovimiento);
            p.Add("@MotivoAnulacion", Nulo(motivo), DbType.AnsiString, size: 250);
            p.Add("@IdUsuario", idUsuario);
            // @Detalle no se envía: un parámetro tipo tabla omitido llega como tabla vacía

            return EjecutarAsync(p, ct);
        }

        // ------------------------------------------------------------------------------

        private static async Task<List<T>> ConsultarAsync<T>(DynamicParameters parametros, CancellationToken ct)
        {
            using (var cn = ConnectionBD.GetConnection())
            {
                await cn.OpenAsync(ct).ConfigureAwait(false);

                var comando = new CommandDefinition(ProcConsulta, parametros,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: TimeoutSegundos,
                    cancellationToken: ct);

                var filas = await cn.QueryAsync<T>(comando).ConfigureAwait(false);
                return filas.ToList();
            }
        }

        private static async Task<Response> EjecutarAsync(DynamicParameters parametros, CancellationToken ct)
        {
            using (var cn = ConnectionBD.GetConnection())
            {
                await cn.OpenAsync(ct).ConfigureAwait(false);

                var comando = new CommandDefinition(ProcRegistro, parametros,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: TimeoutSegundos,
                    cancellationToken: ct);

                var respuesta = (await cn.QueryAsync<Response>(comando).ConfigureAwait(false)).FirstOrDefault();

                return respuesta ?? new Response
                {
                    idResponse = 0,
                    messageResponse = "El servidor no devolvió respuesta.",
                    typeMessage = "ERROR"
                };
            }
        }

        private static string Nulo(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
        }
    }
}
