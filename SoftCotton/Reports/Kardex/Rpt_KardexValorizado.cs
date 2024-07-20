using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Reports.Kardex
{
    public partial class Rpt_KardexValorizado : Form
    {
        public Rpt_KardexValorizado()
        {
            InitializeComponent();
            reportViewer.LocalReport.ReportEmbeddedResource = "SoftCotton.Reports.Kardex.Reporte_KardexValorizado.rdlc";
        }

        private void Rpt_KardexValorizado_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }
}
