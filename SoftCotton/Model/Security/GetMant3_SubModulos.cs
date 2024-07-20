using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Security
{
    public class GetMant3_SubModulos
    {
        public int id { get; set; }
        public int idModulo { get; set; }
        public string modulo { get; set; }
        public string submodulo { get; set; }
        public string rutaForm { get; set; }
        public string iconPath { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }
        public bool estado { get; set; }
    }
}
