using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetTipoDocumentoParam
    {
        public int opcion { get; set; }
        public string codTipoDoc { get; set; }
        public string codTipoDocUpdate { get; set; }
        public string tipoDocLarga { get; set; }
        public string tipoDocCorta { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }

        public SetTipoDocumentoParam()
        {
            opcion = 0;
            codTipoDoc = "";
            codTipoDocUpdate = "";
            tipoDocLarga = "";
            tipoDocCorta = "";
            usuarioReg = "";
            estado = false;
        }
    }
}
