using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Reports.ServiceOrder.OrdenServicio
{
    public class OrdenServicioModel
    {
        public OrdenServicioRpteCabModel osCab { get; set; }
        public List<OrdenServicioRpteDetModel> osDet { get; set; }
        public List<OrdenServicioRpteObsModel> osObs { get; set; }
        public List<OrdenServicioRpteFirmasModel> osFirmas { get; set; }
    }
}
