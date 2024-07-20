using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class SetOCAprobacionParam
    {
        public int opcion { get; set; }
        public int idEmpresa { get; set; }
        public int idOC { get; set; }
        public int idUsuario { get; set; }
        public int idTipoAprobacion { get; set; }
        public int nivelAprobacion { get; set; }

        public SetOCAprobacionParam()
        {
            opcion = 0;
            idEmpresa = 0;
            idOC = 0;
            idUsuario = 0;
            idTipoAprobacion = 0;
            nivelAprobacion = 0;    
        }

    }
}
