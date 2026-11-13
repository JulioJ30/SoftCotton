using SoftCotton.Model.Almacen;
using SoftCotton.Repository;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoftCotton.BusinessLogic
{
    /// <summary>
    /// Ingresos y salidas de almacén: valida en cliente lo que no requiere base de datos
    /// (para responder al instante) y delega en el repositorio. Las reglas de stock y de lo
    /// pendiente de cada guía se validan en el procedimiento, dentro de la transacción.
    /// </summary>
    public class AlmacenBL
    {
        private readonly AlmacenRepository _almacenRepository;

        public AlmacenBL()
        {
            _almacenRepository = new AlmacenRepository();
        }

        public Task<List<AlmacenItem>> ListarAlmacenesAsync(CancellationToken ct)
        {
            return _almacenRepository.ListarAlmacenesAsync(ct);
        }

        public Task<List<MovimientoAlmacenCab>> ListarMovimientosAsync(DateTime? fechaIni, DateTime? fechaFin, string codAlmacen, string tipo, string estado, string texto, CancellationToken ct)
        {
            return _almacenRepository.ListarMovimientosAsync(fechaIni, fechaFin, codAlmacen, tipo, estado, texto, ct);
        }

        public Task<List<MovimientoAlmacenDet>> ListarDetalleAsync(int idMovimiento, CancellationToken ct)
        {
            return _almacenRepository.ListarDetalleAsync(idMovimiento, ct);
        }

        public Task<List<GuiaDespachoPendiente>> BuscarGuiasPendientesAsync(DateTime? fechaIni, DateTime? fechaFin, string codNivel, string texto, CancellationToken ct)
        {
            return _almacenRepository.BuscarGuiasPendientesAsync(fechaIni, fechaFin, codNivel, texto, ct);
        }

        public Task<List<ProductoStockAlmacen>> BuscarProductosConStockAsync(string codAlmacen, DateTime fechaCorte, string codNivel, string texto, CancellationToken ct)
        {
            return _almacenRepository.BuscarProductosConStockAsync(codAlmacen, fechaCorte, codNivel, texto, ct);
        }

        /// <summary>
        /// Reporte tipo Kardex. Además marca, para la grilla, el inicio de cada grupo
        /// almacén + producto y un índice de grupo para alternar colores.
        /// </summary>
        public async Task<List<StockAlmacenKardex>> ReporteStockAsync(string codAlmacen, DateTime fechaIni, DateTime fechaFin, string codNivel, string texto, CancellationToken ct)
        {
            var filas = await _almacenRepository.ReporteStockAsync(codAlmacen, fechaIni, fechaFin, codNivel, texto, ct).ConfigureAwait(false);

            string claveAnterior = null;
            int grupo = -1;
            foreach (var fila in filas)
            {
                string clave = fila.ClaveGrupo;
                fila.EsPrimera = clave != claveAnterior;
                if (fila.EsPrimera)
                {
                    grupo++;
                }
                fila.Grupo = grupo;
                claveAnterior = clave;
            }

            return filas;
        }

        public Task<Response> RegistrarAsync(MovimientoAlmacenRegistro registro, CancellationToken ct)
        {
            string error = Validar(registro);
            if (error != null)
            {
                return Task.FromResult(Advertencia(error));
            }

            return _almacenRepository.RegistrarAsync(registro, ct);
        }

        public Task<Response> AnularAsync(int idMovimiento, string motivo, int idUsuario, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(motivo))
            {
                return Task.FromResult(Advertencia("Ingrese el motivo de la anulación."));
            }

            return _almacenRepository.AnularAsync(idMovimiento, motivo, idUsuario, ct);
        }

        private static string Validar(MovimientoAlmacenRegistro r)
        {
            if (r.TipoMovimiento != MovimientoAlmacenCab.TipoIngreso && r.TipoMovimiento != MovimientoAlmacenCab.TipoSalida)
                return "Tipo de movimiento no válido.";

            if (string.IsNullOrWhiteSpace(r.CodAlmacen))
                return "Seleccione el almacén.";

            if (r.FechaMovimiento.Date > DateTime.Today)
                return "La fecha no puede ser posterior a hoy.";

            if (r.Detalle == null || r.Detalle.Count == 0)
                return "Agregue al menos una línea al detalle.";

            if (r.Detalle.Any(d => d.Cantidad <= 0))
                return "Todas las cantidades deben ser mayores a cero.";

            if (r.EsIngreso && r.Detalle.Any(d => !d.DeGuia))
                return "Cada línea del ingreso debe provenir de una guía despachada.";

            if (!r.EsIngreso && r.Detalle.Any(d => d.DeGuia))
                return "La salida no puede llevar líneas de guía.";

            var excedidos = r.Detalle.Where(d => d.Cantidad > d.Disponible).Select(d => DescribirLinea(d)).ToList();
            if (excedidos.Count > 0)
                return (r.EsIngreso ? "La cantidad supera lo pendiente de la guía en: " : "La cantidad supera el stock del almacén en: ")
                    + string.Join(", ", excedidos.Take(5)) + (excedidos.Count > 5 ? "..." : "");

            if (r.EsIngreso)
            {
                var posteriores = r.Detalle
                    .Where(d => d.FechaGuia.HasValue && d.FechaGuia.Value.Date > r.FechaMovimiento.Date)
                    .Select(d => d.Guia)
                    .Distinct()
                    .ToList();
                if (posteriores.Count > 0)
                    return "La fecha del ingreso no puede ser anterior a la fecha de la guía: " + string.Join(", ", posteriores.Take(5));
            }

            if (r.Detalle.GroupBy(d => d.Clave).Any(g => g.Count() > 1))
                return r.EsIngreso ? "Hay líneas de guía repetidas en el detalle." : "Hay productos repetidos en el detalle.";

            return null;
        }

        private static string DescribirLinea(MovimientoAlmacenLinea d)
        {
            return d.DeGuia ? d.Guia + " " + d.Codigo : d.Codigo;
        }

        private static Response Advertencia(string mensaje)
        {
            return new Response { idResponse = 0, messageResponse = mensaje, typeMessage = "WARNING" };
        }
    }
}
