using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class GetOC29_AdjuntoContenido
    {
        public int idAdjunto { get; set; }
        public string nombreArchivo { get; set; }
        public string extension { get; set; }
        public byte[] contenido { get; set; }
    }
}
