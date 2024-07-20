using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Reports.ServiceOrder.OrdenServicio
{
    public class OrdenServicioModelV2
    {
        public OrdenServicioRpteCabModel osCab { get; set; }
        public List<OrdenServicioRpteDetModelV2> osDet { get; set; }
        public List<OrdenServicioRpteObsModel> osObs { get; set; }
        public List<OrdenServicioRpteFirmasModel> osFirmas { get; set; }
    }
}
