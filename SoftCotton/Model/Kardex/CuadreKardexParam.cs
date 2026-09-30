using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Kardex
{
    public class CuadreKardexParam
    {
        public int opcion { get; set; }
        public string codNivel { get; set; }
        public string codGrupo { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public string tipoAjuste { get; set; }
        public decimal cantidad { get; set; }
        public string fechaMovimiento { get; set; }
        public int idCuadre { get; set; }
        public string usuarioReg { get; set; }

        public CuadreKardexParam()
        {
            opcion = 0;
            codNivel = "";
            codGrupo = "";
            codTalla = "";
            codColor = "";
            tipoAjuste = "";
            cantidad = 0;
            fechaMovimiento = "";
            idCuadre = 0;
            usuarioReg = "";
        }
    }
}
