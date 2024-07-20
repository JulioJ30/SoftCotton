using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant20_Productos
    {
        public string codFamilia { get; set; }
        public string familia { get; set; }
        public string codProducto { get; set; }
        public string codProductoAlt { get; set; }
        public string producto { get; set; }
        public string codTalla { get; set; }
        public string talla { get; set; }
        public string codColor { get; set; }
        public string color { get; set; }
        public string codUM { get; set; }
        public string unidadMedida { get; set; }
        public bool estado { get; set; }
        public string fechaReg { get; set; }
        public string usuarioReg { get; set; }
    }
}
