using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetNumeroLicenciaConducirParam
    {
        public int opcion { get; set; }
        public int idNumeroLicenciaConducir { get; set; }
        public string numeroLicenciaConducir { get; set; }
        public string estado { get; set; }
        public string fechaCrea { get; set; }
        public string fechaMod { get; set; }
        public string usuarioReg { get; set; }
        public string numDocConductor { get; set; }
        public string codTipoDocConductor { get; set; }


        public SetNumeroLicenciaConducirParam()
        {
            opcion = 0;
            idNumeroLicenciaConducir = 0;
            numeroLicenciaConducir = "";
            estado = "1";
            fechaCrea = "";
            fechaMod = "";
            usuarioReg = "";
            numDocConductor = "";
            codTipoDocConductor = "";

        }
    }
}
