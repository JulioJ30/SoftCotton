using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ServiceOrder
{
    public class GetOS5_TipoAprobacion
    {
        public int idTipoAprobacion { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public int nivelAprobacion { get; set; }
        public string fechaReg { get; set; }
        public string usuarioReg { get; set; }
    }
}
