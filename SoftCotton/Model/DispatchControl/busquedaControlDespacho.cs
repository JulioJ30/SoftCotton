using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.DispatchControl
{
    public class busquedaControlDespacho
    {

        public int idProcesoControl { get; set; }
        public string proceso { get; set; }
        public int idProcesoControlDespachoCab { get; set; }
        public int idPrograma { get; set; }
        public string programa { get; set; }
        public int idEstilo { get; set; }
        public string estilo { get; set; }
        public string pedido { get; set; }
        public int idPedidoColor { get; set; }
        public string color { get; set; }
        public string cliente { get; set; }
        public string idProveedor { get; set; }
        public string proveedor { get; set; }


    }
}
