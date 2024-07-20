using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Reports.RemittanceGuide.ExportGuide
{
    public class GuiaRemisionExportacionDetModel
    {
        public int idEmpresa { get; set; }
        public string ruc { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public int secuencia { get; set; }

        public string descripcion { get; set; }
        public decimal cantidadIngresada { get; set; }
        public string codUM { get; set; }
        public string codProducto { get; set; }


        public GuiaRemisionExportacionDetModel()
        {
            idEmpresa = 0;
            ruc = "";
            serie = "";
            numero = "";
            secuencia = 0;

            descripcion = "";
            cantidadIngresada = 0;
            codUM = "";
            codProducto = "";
        }

    }
}
