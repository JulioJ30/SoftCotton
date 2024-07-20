using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class SetCierrePeriodoParam
    {
        public int opcion { get; set; }
        public int idCierrePeriodo { get; set; }
        public string periodo { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
        public string estado { get; set; }
        public string usuarioReg { get; set; }
        public DateTime? fechaReg { get; set; }

        public SetCierrePeriodoParam()
        {
            opcion = 0;
            idCierrePeriodo = 0;
            periodo = "";
            fechaInicio = DateTime.Now;
            fechaFin =  DateTime.Now;
            estado = "";
        }
    }
}
