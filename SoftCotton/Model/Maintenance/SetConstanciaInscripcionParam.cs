using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Maintenance
{
    public class SetConstanciaInscripcionParam
    {
        public int opcion { get; set; }
        public int idConstanciaInscripcion { get; set; }
        public string constanciaInscripcion { get; set; }
        public string estado { get; set; }
        public string fechaCrea { get; set; }
        public string fechaMod { get; set; }
        public string usuarioReg { get; set; }

        public SetConstanciaInscripcionParam()
        {
            opcion = 0;
            idConstanciaInscripcion = 0;
            constanciaInscripcion = "";
            estado = "1";
            fechaCrea = "";
            fechaMod = "";
            usuarioReg = "";

        }
    }
}
