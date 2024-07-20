using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class GetOC14_Observaciones
    {
        public int idObs { get; set; }
        public string observacion { get; set; }
        public bool estado { get; set; }
        public string usuReg { get; set; }
        public string fechaReg { get; set; }
    }
}
