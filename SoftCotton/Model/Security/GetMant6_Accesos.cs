using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Security
{
    public class GetMant6_Accesos
    {
        public int idModulo { get; set; }
        public string modulo { get; set; }
        public int idSubModulo { get; set; }
        public string submodulo { get; set; }
        public string rutaForm { get; set; }
        public bool activo { get; set; }

    }
}
