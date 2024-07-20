using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Employee
{
    public class GetEmp2_Colaboradores
    {
        public int idPeriodo { get; set; }
        public string numeroDocumento { get; set; }
        public string persona { get; set; }
        public int idCargo { get; set; }
        public string cargo { get; set; }
        public int idArea { get; set; }
        public string area { get; set; }
        public string fechaIngreso { get; set; }
        public string fechaCese { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }

        public int idEstado { get; set; }
        public string mensajeEstado { get; set; }
    }
}
