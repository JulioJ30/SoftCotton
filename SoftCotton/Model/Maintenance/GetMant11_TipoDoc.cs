using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant11_TipoDoc
    {
        public string codTipoDoc { get; set; }
        public string tipoDocLarga { get; set; }
        public string tipoDocCorta { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }
        public bool estado { get; set; }
    }
}
