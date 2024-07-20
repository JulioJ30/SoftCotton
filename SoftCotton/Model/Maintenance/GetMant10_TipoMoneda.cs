using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant10_TipoMoneda
    {
        public int idTipoMoneda { get; set; }
        public string simbolo { get; set;}
        public string monedaSingular { get; set; }
        public string monedaPlural { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }
        public bool estado { get; set; }
    }
}
