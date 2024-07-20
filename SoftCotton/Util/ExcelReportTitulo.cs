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
}
