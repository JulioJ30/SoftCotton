using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class SetOCObservacionParam
    {
        public int opcion { get; set; }
        public int idObs { get; set; }
        public string observacion { get; set; }
        public string usuReg { get; set; }
        public bool estado { get; set; }

        public SetOCObservacionParam()
        {
            opcion = 0;
            idObs = 0;
            observacion = "";
            usuReg = "";
            estado = false;
        }
    }
}
