using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class GetOC11_Firmantes
    {
        public int idUsuario { get; set; }
        public int idTipoAprobacion { get; set; }
        public string colaborador { get; set; }
        public string tipoAprobacion { get; set; }
        public int nivelAprobacion { get; set; }
        public string rutaImgFirma { get; set; }
        public bool estado { get; set; }
        public string usuReg { get; set; }
        public string fechaReg { get; set; }
    }
}
