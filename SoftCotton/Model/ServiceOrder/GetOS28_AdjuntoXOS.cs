using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ServiceOrder
{
    public class GetOS28_AdjuntoXOS
    {
        public int idAdjunto { get; set; }
        public int idEmpresa { get; set; }
        public int idOS { get; set; }
        public string nombreArchivo { get; set; }
        public string extension { get; set; }
        public string tipoAdjunto { get; set; }
        public decimal tamanioKB { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }
    }
}
