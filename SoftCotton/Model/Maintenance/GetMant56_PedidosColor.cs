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
        public int PermitirRegistro { get; set; }

        public string pedido { get; set; }

        public string codColor { get; set; }
        public string color { get; set; }
        public string estilo { get; set; }
        public string programa { get; set; }
        public string fechaCrea { get; set; }
        public bool estado { get; set; }
        public string codigoEstilo { get; set; }

    }


    public class PedidosColorAvance
    {
        public string CodigoNivel { get; set; }
        public string DescripcionNivel { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string RucDestinatario { get; set; }

        public decimal Cantidad { get; set; }

        public string RazonSocial { get; set; }

    }
}   
