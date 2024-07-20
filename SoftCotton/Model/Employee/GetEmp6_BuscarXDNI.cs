using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Employee
{
    public class GetEmp6_BuscarXDNI
    {
        public int idPeriodo { get; set; }
        public string numeroDocumento { get; set; }
        public int idCargo { get; set; }
        public int idArea { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaCese { get; set; }
    }
}
