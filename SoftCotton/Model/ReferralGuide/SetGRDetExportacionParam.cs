using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class SetGRDetExportacionParam
    {
        public int opcion { get; set; }

        public int idEmpresa { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public string ruc { get; set; }

        public int secuencia { get; set; }
        public string codProducto { get; set; }
        public string descripcion { get; set; }
        public decimal cantidadIngresada { get; set; }
        public string codUM { get; set; }


        public SetGRDetExportacionParam()
        {
            opcion = 0;
            idEmpresa = 0;
            serie = "";
            ruc = "";
            numero = "";
            secuencia = 0;
            cantidadIngresada = 0;
            codProducto = "";
            descripcion = "";
            codUM = "";


        }
    }
}
