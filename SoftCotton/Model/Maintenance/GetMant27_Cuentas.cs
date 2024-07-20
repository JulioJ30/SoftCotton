using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant27_Cuentas
    {
        public string codCuenta { get; set; }
        public string cuenta { get; set; }
        public string codCuentaNivel { get; set; }
        public string cuentaNivel { get; set; }
        public string codCuentaTipo { get; set; }
        public string cuentaTipo { get; set; }
        public string cuentaAmarreDebe { get; set; }
        public string cuentaAmarreHaber { get; set; }
        public string fechaReg { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }
        public bool FlgMostrarKardex { get; set; }

    }
}
