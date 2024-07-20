using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ServiceOrder
{
    public class SetOSDetParam
    {
        public int opcion { get; set; }
        public int idEmpresa { get; set; }
        public int idOS { get; set; }
        public int secuencia { get; set; }
        public string codNivel { get; set; }
        public string codGrupo { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public decimal cantidad { get; set; }
        public decimal igv { get; set; }
        public decimal precioUnitario { get; set; }

        public string obs1 { get; set; }
        public string obs2 { get; set; }
        public string obs3 { get; set; }
        public string obs4 { get; set; }
        public string obs5 { get; set; }

        public SetOSDetParam()
        {
            opcion = 0;
            idEmpresa = 0;
            idOS = 0;
            secuencia = 0;
            codNivel = "";
            codGrupo = "";
            codTalla = "";
            codColor = "";
            cantidad = 0;
            igv = 0;
            precioUnitario = 0;

            obs1 = "";
            obs2 = "";
            obs3 = "";
            obs4 = "";
            obs5 = "";
        }
    }
}
