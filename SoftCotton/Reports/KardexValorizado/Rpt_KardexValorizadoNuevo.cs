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
    public partial class Rpt_KardexValorizadoNuevo : Form
    {
        public Rpt_KardexValorizadoNuevo()
        {
            InitializeComponent();
            reportViewer1.LocalReport.ReportEmbeddedResource = "SoftCotton.Reports.KardexValorizado.Reporte_KardexValorizadoNuevo.rdlc";
        }

        private void Rpt_KardexValorizadoNuevo_Load(object sender, EventArgs e)
        {
            //this.reportViewer.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
