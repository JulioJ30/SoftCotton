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
    /// Transferencias entre almacenes: valida en cliente lo que no requiere base de datos
    /// (para responder al instante) y delega en el repositorio. Las reglas de stock se
    /// validan en el procedimiento, dentro de la transacción.
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

        public Task<List<TransferenciaAlmacenCab>> ListarTransferenciasAsync(DateTime? fechaIni, DateTime? fechaFin, string codAlmacen, string estado, string texto, CancellationToken ct)
        {
            return _almacenRepository.ListarTransferenciasAsync(fechaIni, fechaFin, codAlmacen, estado, texto, ct);
        }

        public Task<List<TransferenciaAlmacenDet>> ListarDetalleAsync(int idTransferencia, CancellationToken ct)
        {
            return _almacenRepository.ListarDetalleAsync(idTransferencia, ct);
        }

        public Task<List<ProductoStockAlmacen>> BuscarProductosConStockAsync(string codAlmacen, DateTime fechaCorte, string codNivel, string texto, CancellationToken ct)
        {
            return _almacenRepository.BuscarProductosConStockAsync(codAlmacen, fechaCorte, codNivel, texto, ct);
        }

        public Task<List<StockAlmacenReporte>> ReporteStockAsync(string codAlmacen, DateTime fechaCorte, string codNivel, string texto, CancellationToken ct)
        {
            return _almacenRepository.ReporteStockAsync(codAlmacen, fechaCorte, codNivel, texto, ct);
        }

        public Task<Response> RegistrarAsync(TransferenciaAlmacenRegistro registro, CancellationToken ct)
        {
            string error = Validar(registro);
            if (error != null)
            {
                return Task.FromResult(Advertencia(error));
            }

            return _almacenRepository.RegistrarAsync(registro, ct);
        }

        public Task<Response> AnularAsync(int idTransferencia, string motivo, int idUsuario, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(motivo))
            {
                return Task.FromResult(Advertencia("Ingrese el motivo de la anulación."));
            }

            return _almacenRepository.AnularAsync(idTransferencia, motivo, idUsuario, ct);
        }

        private static string Validar(TransferenciaAlmacenRegistro r)
        {
            if (string.IsNullOrWhiteSpace(r.CodAlmacenOrigen) || string.IsNullOrWhiteSpace(r.CodAlmacenDestino))
                return "Seleccione el almacén de origen y el de destino.";

            if (r.CodAlmacenOrigen == r.CodAlmacenDestino)
                return "El almacén de origen y el de destino deben ser distintos.";

            if (r.FechaTransferencia.Date > DateTime.Today)
                return "La fecha de la transferencia no puede ser posterior a hoy.";

            if (r.Detalle == null || r.Detalle.Count == 0)
                return "Agregue al menos un producto a la transferencia.";

            if (r.Detalle.Any(d => d.Cantidad <= 0))
                return "Todas las cantidades deben ser mayores a cero.";

            var excedidos = r.Detalle.Where(d => d.Cantidad > d.StockDisponible).Select(d => d.Codigo).ToList();
            if (excedidos.Count > 0)
                return "La cantidad supera el stock disponible en: " + string.Join(", ", excedidos.Take(5)) + (excedidos.Count > 5 ? "..." : "");

            if (r.Detalle.GroupBy(d => d.Clave).Any(g => g.Count() > 1))
                return "Hay productos repetidos en el detalle.";

            return null;
        }

        private static Response Advertencia(string mensaje)
        {
            return new Response { idResponse = 0, messageResponse = mensaje, typeMessage = "WARNING" };
        }
    }
}
