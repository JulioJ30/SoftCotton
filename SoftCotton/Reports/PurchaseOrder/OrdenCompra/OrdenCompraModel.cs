using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Reports.PurchaseOrder.OrdenCompra
{
    public class OrdenCompraModel
    {
        public OrdenCompraRpteCabModel ocCab { get; set; }
        public List<OrdenCompraRpteDetModel> ocDet { get; set; }
        public List<OrdenCompraRpteObsModel> ocObs { get; set; }
        public List<OrdenCompraRpteFirmasModel> ocFirmas { get; set; }
    }
}
