using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant9_CondPago
    {
        public int idCondPago { get; set; }
        public string condicion { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }
        public bool estado { get; set; }

        public decimal valor { get; set; }
    }
}
