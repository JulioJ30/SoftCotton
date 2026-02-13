using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Util
{
    public class ExcelReportTitulo
    {
        public string titulo { get; set; }
        public XLColor backgroundColor { get; set; }
        public XLColor foreColor { get; set; }

        public ExcelReportTitulo()
        {
            titulo = "";
            backgroundColor = XLColor.White;
            foreColor = XLColor.Black;
        }
    }


    public class TituloPdf
    {
        public string Periodo { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Establecimiento { get; set; }
        public string CodigoExistencia { get; set; }
        public string Tipo { get; set; }
        public string TipoDescripcion { get; set; }
        public string CodigoUnidadMedida { get; set; }
        public string MetodoEvaluacion { get; set; }
    }
}
