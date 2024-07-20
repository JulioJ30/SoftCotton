using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Employee
{
    public class SetColaboradorParam
    {
        public int opcion { get; set; }
        public int idPeriodo { get; set; }
        public string numeroDocumento { get; set; }
        public int idCargo { get; set; }
        public int idArea { get; set; }
        public string fechaIngreso { get; set; }
        public string fechaCese { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }

        public SetColaboradorParam()
        {
            opcion = 0;
            idPeriodo = 0;
            numeroDocumento = "";
            idCargo = 0;
            idArea = 0;
            fechaIngreso = "";
            fechaCese = "";
            usuarioReg = "";
            fechaReg = "";
        }
    }
}
