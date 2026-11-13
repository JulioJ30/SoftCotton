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
    /// Acceso a datos de Transferencias entre Almacenes.
    /// Todos los métodos son asíncronos y aceptan cancelación, para no bloquear la interfaz.
    /// </summary>
    public class AlmacenRepository
    {
        private const string ProcConsulta = "uspGetTransferenciaAlmacen";
        private const string ProcRegistro = "uspSetTransferenciaAlmacen";
        private const string TipoDetalle = "dbo.TransferenciaAlmacenDetTipo";

        // El stock del almacén central recorre el Kardex: se da margen suficiente.
        private const int TimeoutSegundos = 300;

        public Task<List<AlmacenItem>> ListarAlmacenesAsync(CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 1);
            return ConsultarAsync<AlmacenItem>(p, ct);
        }

        public Task<List<TransferenciaAlmacenCab>> ListarTransferenciasAsync(DateTime? fechaIni, DateTime? fechaFin, string codAlmacen, string estado, string texto, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 2);
            p.Add("@FechaIni", fechaIni, DbType.Date);
            p.Add("@FechaFin", fechaFin, DbType.Date);
            p.Add("@CodAlmacen", Nulo(codAlmacen), DbType.AnsiString, size: 3);
            p.Add("@Estado", Nulo(estado), DbType.AnsiStringFixedLength, size: 1);
            p.Add("@Texto", Nulo(texto), DbType.AnsiString, size: 100);
            return ConsultarAsync<TransferenciaAlmacenCab>(p, ct);
        }

        public Task<List<TransferenciaAlmacenDet>> ListarDetalleAsync(int idTransferencia, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 3);
            p.Add("@IdTransferencia", idTransferencia);
            return ConsultarAsync<TransferenciaAlmacenDet>(p, ct);
        }

        public Task<List<ProductoStockAlmacen>> BuscarProductosConStockAsync(string codAlmacen, DateTime fechaCorte, string codNivel, string texto, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 4);
            p.Add("@CodAlmacen", codAlmacen, DbType.AnsiString, size: 3);
            p.Add("@FechaCorte", fechaCorte.Date, DbType.Date);
            p.Add("@codNivel", Nulo(codNivel), DbType.AnsiStringFixedLength, size: 2);
            p.Add("@Texto", Nulo(texto), DbType.AnsiString, size: 100);
            return ConsultarAsync<ProductoStockAlmacen>(p, ct);
        }

        public Task<List<StockAlmacenReporte>> ReporteStockAsync(string codAlmacen, DateTime fechaCorte, string codNivel, string texto, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 5);
            p.Add("@CodAlmacen", Nulo(codAlmacen), DbType.AnsiString, size: 3);
            p.Add("@FechaCorte", fechaCorte.Date, DbType.Date);
            p.Add("@codNivel", Nulo(codNivel), DbType.AnsiStringFixedLength, size: 2);
            p.Add("@Texto", Nulo(texto), DbType.AnsiString, size: 100);
            return ConsultarAsync<StockAlmacenReporte>(p, ct);
        }

        /// <summary>
        /// Registra cabecera y detalle en una sola llamada (el detalle viaja como parámetro
        /// tipo tabla). El procedimiento maneja la transacción.
        /// </summary>
        public Task<Response> RegistrarAsync(TransferenciaAlmacenRegistro registro, CancellationToken ct)
        {
            var detalle = new DataTable();
            detalle.Columns.Add("codNivel", typeof(string));
            detalle.Columns.Add("codGrupo", typeof(string));
            detalle.Columns.Add("codTalla", typeof(string));
            detalle.Columns.Add("codColor", typeof(string));
            detalle.Columns.Add("codCuenta", typeof(string));
            detalle.Columns.Add("Cantidad", typeof(decimal));
            detalle.Columns.Add("Comentario", typeof(string));

            foreach (var linea in registro.Detalle)
            {
                detalle.Rows.Add(
                    linea.codNivel,
                    linea.codGrupo,
                    linea.codTalla,
                    linea.codColor,
                    string.IsNullOrWhiteSpace(linea.codCuenta) ? (object)DBNull.Value : linea.codCuenta,
                    linea.Cantidad,
                    string.IsNullOrWhiteSpace(linea.Comentario) ? (object)DBNull.Value : linea.Comentario.Trim());
            }

            var p = new DynamicParameters();
            p.Add("@opcion", 1);
            p.Add("@FechaTransferencia", registro.FechaTransferencia.Date, DbType.Date);
            p.Add("@CodAlmacenOrigen", registro.CodAlmacenOrigen, DbType.AnsiString, size: 3);
            p.Add("@CodAlmacenDestino", registro.CodAlmacenDestino, DbType.AnsiString, size: 3);
            p.Add("@Observacion", Nulo(registro.Observacion), DbType.AnsiString, size: 500);
            p.Add("@IdUsuario", registro.IdUsuario);
            p.Add("@Detalle", detalle.AsTableValuedParameter(TipoDetalle));

            return EjecutarAsync(p, ct);
        }

        public Task<Response> AnularAsync(int idTransferencia, string motivo, int idUsuario, CancellationToken ct)
        {
            var p = new DynamicParameters();
            p.Add("@opcion", 2);
            p.Add("@IdTransferencia", idTransferencia);
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
