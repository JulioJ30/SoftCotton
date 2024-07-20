using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Employee
{
    public class SetPersonaParam
    {
        public int opcion { get; set; }
        public string numDoc { get; set; }
        public string numDocUpdate { get; set; }
        public string codTipoDoc { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string celular { get; set; }
        public string usuarioReg { get; set; }

        public SetPersonaParam()
        {
            opcion = 0;
            numDoc = "";
            numDocUpdate = "";
            codTipoDoc = "";
            nombres = "";
            apellidoPaterno = "";
            apellidoMaterno = "";
            celular = "";
            usuarioReg = "";
        }
    }
}
