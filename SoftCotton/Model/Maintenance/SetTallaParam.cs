using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetTallaParam
    {
        public int opcion { get; set; }
        public string codTalla { get; set; }
        public string codTallaUpdate { get; set; }
        public string descripcion { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }
        
        public SetTallaParam()
        {
            codTalla = "";
            codTallaUpdate = "";
            descripcion = "";
            estado = false;
            usuarioReg = "";
        }
        
    }
}
