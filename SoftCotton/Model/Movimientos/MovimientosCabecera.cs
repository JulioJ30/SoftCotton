using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Movimientos
{
    public class MovimientosCabecera
    {
        public int? IdMovimientoCabecera { get; set; }
        public int IdTipoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Comentario { get; set; }
        public string DescripcionTipoMovimiento { get; set; }
        public string Usuario { get; set; }
        public float CantidadMovimiento { get; set; }



    }
}
