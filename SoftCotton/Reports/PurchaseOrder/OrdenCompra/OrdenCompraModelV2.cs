using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Reports.PurchaseOrder.OrdenCompra
{
    public class OrdenCompraModelV2
    {
        public OrdenCompraRpteCabModel ocCab { get; set; }
        public List<OrdenCompraRpteDetModelV2> ocDet { get; set; }
        public List<OrdenCompraRpteObsModel> ocObs { get; set; }
        public List<OrdenCompraRpteFirmasModel> ocFirmas { get; set; }
    }
}
