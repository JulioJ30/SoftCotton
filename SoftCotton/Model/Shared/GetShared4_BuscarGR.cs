using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Shared
{
    public class GetShared4_BuscarGR
    {
        public string tipo { get; set; }
        public int idEmpresa { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public string fechaEmision { get; set; }
        public string destCodigoPC { get; set; }
        public string razonSocial { get; set; }
        public int secuencia { get; set; }
        public int idDet { get; set; }
        public int idSecuenciaDet { get; set; }
        public string codNivel { get; set; }
        public string codGrupo { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public string codProducto { get; set; }
        public string producto { get; set; }
        public string codUM { get; set; }

        public string tipoMovimiento { get; set; }
        public decimal cantidadIngresada { get; set; }
        public decimal pesoIngresado { get; set; }
    }
}
