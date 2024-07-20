using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.DispatchControl
{
    public class controlDespachoDet
    {
        public int? idProcesoControlDespachoDet { get; set; }
        public int? idProcesoControlDespachoCab { get; set; }
        public int numeroCorte { get; set; }
        public string fechaGuia { get; set; }
        public string guia { get; set; }
        public string fechaFactura { get; set; }
        public string factura { get; set; }
        public string ordenServicio { get; set; }
        public string destinario { get; set; }




    }
}
