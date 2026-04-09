using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Movimientos
{
    public class MovimientosDetalle
    {
        public int item { get; set; }
        public string CodigoNivel { get; set; }
        public string CodGrupo { get; set; }
        public string CodTalla { get; set; }
        public string CodColor { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public int? IdPedidoColor { get; set; }

        public string Pedido { get; set; }
        public string PedidoColor { get; set; }

        public string Estilo { get; set; }
        public string Programa { get; set; }



        public string PartidaProveedor { get; set; }
        public string Comentario { get; set; }

    }
}
