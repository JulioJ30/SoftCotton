using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class SetOCAdjuntoParam
    {
        public int opcion { get; set; }
        public int idAdjunto { get; set; }
        public int idEmpresa { get; set; }
        public int idOC { get; set; }
        public string nombreArchivo { get; set; }
        public string extension { get; set; }
        public byte[] contenido { get; set; }
        public string tipoAdjunto { get; set; }
        public string usuarioReg { get; set; }

        public SetOCAdjuntoParam()
        {
            opcion = 0;
            idAdjunto = 0;
            idEmpresa = 0;
            idOC = 0;
            nombreArchivo = "";
            extension = "";
            contenido = null;
            tipoAdjunto = "COTIZACION";
            usuarioReg = "";
        }
    }
}
