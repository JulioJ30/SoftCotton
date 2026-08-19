using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ServiceOrder
{
    public class SetOSAdjuntoParam
    {
        public int opcion { get; set; }
        public int idAdjunto { get; set; }
        public int idEmpresa { get; set; }
        public int idOS { get; set; }
        public string nombreArchivo { get; set; }
        public string extension { get; set; }
        public byte[] contenido { get; set; }
        public string tipoAdjunto { get; set; }
        public string usuarioReg { get; set; }

        public SetOSAdjuntoParam()
        {
            opcion = 0;
            idAdjunto = 0;
            idEmpresa = 0;
            idOS = 0;
            nombreArchivo = "";
            extension = "";
            contenido = null;
            tipoAdjunto = "COTIZACION";
            usuarioReg = "";
        }
    }
}
