using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Security
{
    public class GetMant1_Usuarios
    {
        public int id { get; set; }
        public string numDoc { get; set; }
        public string persona { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string fechaReg { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }
    }
}
