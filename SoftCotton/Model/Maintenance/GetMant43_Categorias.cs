using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant43_Categorias
    {
        public int idCategoria { get; set; }
        public string descripcionCategoria { get; set; }
        public string usuarioCrea { get; set; }
        public string usuarioMod { get; set; }
        public string fechaCrea { get; set; }
        public string fechaMod { get; set; }
        public bool estado { get; set; }
    }
}
