using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant56_PedidosColor
    {
        public int idPedidoColor { get; set; }
        public int idPedido { get; set; }
        public int idEstilo { get; set; }
        public int idPrograma { get; set; }
        public string pedido { get; set; }

        public string codColor { get; set; }
        public string color { get; set; }
        public string estilo { get; set; }
        public string programa { get; set; }
        public string fechaCrea { get; set; }
        public bool estado { get; set; }
        public string codigoEstilo { get; set; }

    }
}   
