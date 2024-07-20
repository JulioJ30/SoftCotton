using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetCategoriasParam
    {
        public int idCategoria { get; set; }
        public string descripcionCategoria { get; set; }
        public string usuarioCrea { get; set; }
        public string usuarioMod { get; set; }
        public string fechaCrea { get; set; }
        public string fechaMod { get; set; }
        public bool estado { get; set; }

        public SetCategoriasParam()
        {
            idCategoria = 0;
            descripcionCategoria = "";
            usuarioCrea = "";
            usuarioMod = "";
            fechaCrea = "";
            fechaMod = "";
            estado = true;


        }
    }
}
