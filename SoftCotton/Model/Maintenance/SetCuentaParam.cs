using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetCuentaParam
    {
        public int opcion { get; set; }
        public string codCuenta { get; set; }
        public string codCuentaUpdate { get; set; }
        public string cuenta { get; set; }
        public string codCuentaNivel { get; set; }
        public string codCuentaTipo { get; set; }
        public string cuentaAmarreDebe { get; set; }
        public string cuentaAmarreHaber { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }
        public bool FlgMostrarKardex { get; set; }


        public SetCuentaParam()
        {
            opcion = 0;
            codCuenta = "";
            codCuentaUpdate = "";
            cuenta = "";
            codCuentaNivel = "";
            codCuentaTipo = "";
            cuentaAmarreDebe = "";
            cuentaAmarreHaber = "";
            usuarioReg = "";
            estado = false;
            FlgMostrarKardex = true;

        }
    }
}
