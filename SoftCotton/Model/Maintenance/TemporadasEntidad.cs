using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Maintenance
{
    public class TemporadasEntidad
    {
        public int IdTemporada { get; set; }
        public int Anio { get; set; }
        public string Temporada { get; set; }
        public string TemporadaDescripcion { get; set; }
        public bool FlgActivo { get; set; }
        public int IdUsuarioCreate { get; set; }
        public string EstacionCreate { get; set; }
        public DateTime FechaCreate { get; set; }
        public int? IdUsuarioUpdate { get; set; }
        public string EstacionUpdate { get; set; }
        public DateTime? FechaUpdate { get; set; }


    }
}
