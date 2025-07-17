using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Transformacion
{


    public class DetalleTransformacionDetTallaEntity
    {
        public int IdTransformacionDetTalla { get; set; }
        public int IdTransformacionDet { get; set; }
        public string CodTalla { get; set; } = string.Empty;
        public string DescripcionTalla { get; set; } = string.Empty;
        public float Cantidad { get; set; }
        public string Observacion { get; set; } = string.Empty;

    }

    public class DetalleTransformacionEntity
    {
        public int Item { get; set; }
        public int IdTransformacionDet { get; set; }
        public string CodigoProducto { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;
        public float Cantidad { get; set; }
        public string Comentario { get; set; } = string.Empty;

        public string CodNivel { get; set; } = string.Empty;
        public string CodGrupo { get; set; } = string.Empty;
        public string CodColor { get; set; } = string.Empty;
        public string CodTalla { get; set; } = string.Empty;
        public string CodUM { get; set; } = string.Empty;




    }


    public class DetalleTransformacionFiltroPorBusquedaEntity
    {
        public int IdSencuenciaDet { get; set; }
        public string Serie { get; set; } = string.Empty;
        public int Numero { get; set; } 
        public string Proveedor { get; set; } = string.Empty;

    }
}
