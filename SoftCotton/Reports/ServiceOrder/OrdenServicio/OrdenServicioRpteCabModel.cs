using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Reports.ServiceOrder.OrdenServicio
{
    public class OrdenServicioRpteCabModel
    {
        public string empresaRUC { get; set; }
        public string empresaDireccion { get; set; }
        public string codigoOS { get; set; }
        public string fechaEmision { get; set; }
        public string fechaEntrega { get; set; }
        public string proveedorRS { get; set; }
        public string proveedorRUC { get; set; }
        public string proveedorDireccion { get; set; }
        public string contacto { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

        public string tipoMoneda { get; set; }
        public string tipoCompra { get; set; }
        public string formaPago { get; set; }
        public string tipoCambio { get; set; }

        public string subTotal { get; set; }
        public string descuento { get; set; }
        public string baseImponible { get; set; }
        public string igv { get; set; }
        public string total { get; set; }

        public string montoLetras { get; set; }
        public string simbolo { get; set; }
        public string observacion { get; set; }

        public string programa { get; set; }
        public string servicio { get; set; }

    }
}
