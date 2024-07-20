using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Reports.RemittanceGuide.ExportGuide
{
    public class GuiaRemisionExportacionModel
    {
        public GuiaRemisionExportacionCabModel greCab { get; set; } = new GuiaRemisionExportacionCabModel();
        public List<GuiaRemisionExportacionDetModel> greDet { get; set; } = new List<GuiaRemisionExportacionDetModel>();
    }
}
