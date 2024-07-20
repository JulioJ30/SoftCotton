using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.DispatchControl
{
    public class parametrosRegistros
    {
        public int id { get; set; }

        public int? idProcesoControlDespachoCab { get; set; }
        public int? idPedidoColor { get; set; }

        public int idProcesoControl { get; set; }
        public string codPrograma { get; set; }
        public string cliente { get; set; }
        public string idProveedor { get; set; }
        public string usuario { get; set; }

        public string codCliente { get; set; }
        public string codColor { get; set; }
        public string fechaDespacho { get; set; }
        public string ruc { get; set; }

        public int? idProcesoControlDespachoDet { get; set; }
        public int numeroCorte { get; set; }
        public string fechaGuia { get; set; }
        public string guia { get; set; }
        public string fechaFactura { get; set; }
        public string factura { get; set; }
        public string ordenServicio { get; set; }
        public string destinario { get; set; }

        public int idProcesoControlDespachoDetTalla { get; set; }
        public string codTalla { get; set; }
        public string talla { get; set; }
        public int ordenTalla { get; set; }
        public int cantidad { get; set; }


    }
}
