using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;

namespace SoftCotton.Model.Movimientos
{
    public class RegistroTransformacionEntity
    {
        public int? IdTransformacionCab { get; set; }
		public string Serie { get; set; }
        public int  Numero { get; set; }
        public string Proveedor { get; set; }
        public string CodigoNivelOrigen { get; set; }
        public string CodigoNivelDestino { get; set; }
        public int IdUsuario { get; set; }
        public int IdSecuenciaDet { get; set; }
        public string CodNivel { get; set; }
        public string CodGrupo { get; set; }
        public string CodTalla { get; set; }
        public string CodColor { get; set; }
        public float Cantidad { get; set; }
        public string Comentario { get; set; }
        public string Pedido { get; set; }

    }
}
