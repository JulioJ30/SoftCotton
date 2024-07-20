using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Maintenance
{
    public class SetPedidosColorParam
    {
        public int opcion { get; set; }
        public int idpedidocolor { get; set; }
        public int idpedido { get; set; }
        public string codcolor { get; set; }
        public int idusuariocrea { get; set; }
        public bool estado { get; set; }
    }
}
