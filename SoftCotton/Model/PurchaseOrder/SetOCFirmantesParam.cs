using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class SetOCFirmantesParam
    {
        public int opcion { get; set; }
        public int idUsuario { get; set; }
        public int idTipoAprobacion { get; set; }
        public int idUsuarioUpdate { get; set; }
        public int idTipoAprobacionUpdate { get; set; }
        public bool estado { get; set; }
        public string usuReg { get; set; }
        public string rutaImgFirma { get; set; }

        public SetOCFirmantesParam()
        {
            opcion = 0;
            idUsuario = 0;
            idTipoAprobacion = 0;
            idUsuarioUpdate = 0;
            idTipoAprobacionUpdate = 0;
            estado = false;
            usuReg = "";
            rutaImgFirma = "";
        }
    }
}
