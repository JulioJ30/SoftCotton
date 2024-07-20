using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Maintenance
{
    public class SetPedidosParam
    {
        public int opcion { get; set; }
        public int idpedido { get; set; }
        public int idestilo { get; set; }
        public int idprograma { get; set; }
        public int idusuariocrea { get; set; }
        public string pedido { get; set; }
        public bool estado { get; set; }

    }
}
