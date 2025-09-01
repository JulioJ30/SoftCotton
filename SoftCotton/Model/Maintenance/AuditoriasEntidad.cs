using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Maintenance
{
    public class AuditoriasEntidad
    {
        public string Tipo { get; set; }
        public string Documento { get; set; }
        public string Ruc { get; set; }
        public string Usuario { get; set; }
        public string Estacion { get; set; }
        public string Campo { get; set; }
        public DateTime FecHora { get; set; }
        public string Accion { get; set; }
        public string ValorAntiguo { get; set; }
        public string ValorNuevo { get; set; }

    }
}
