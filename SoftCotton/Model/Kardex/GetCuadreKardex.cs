using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Kardex
{
    public class GetCuadreKardex
    {
        public int idCuadre { get; set; }
        public string codNivel { get; set; }
        public string nivel { get; set; }
        public string codGrupo { get; set; }
        public string grupo { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public string color { get; set; }
        public string tipoAjuste { get; set; }
        public string tipoAjusteDescripcion { get; set; }
        public decimal cantidad { get; set; }
        public DateTime fechaMovimiento { get; set; }
        public string serieGR { get; set; }
        public string numeroGR { get; set; }
        public int secuenciaGR { get; set; }
        public string usuarioReg { get; set; }
        public DateTime fechaReg { get; set; }
    }
}
