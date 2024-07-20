namespace SoftCotton.Reports.RemittanceGuide.ExportGuide
{
    partial class GuiaRemisionExportacionPrintView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuiaRemisionExportacionPrintView));
            this.guiaRemisionReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GuiaRemisionExportacionModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GuiaRemisionExportacionModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // guiaRemisionReportViewer
            // 
            this.guiaRemisionReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsGuiaRemisionExportacion";
            reportDataSource1.Value = this.GuiaRemisionExportacionModelBindingSource;
            this.guiaRemisionReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.guiaRemisionReportViewer.LocalReport.ReportEmbeddedResource = "SoftCotton.Reports.RemittanceGuide.ExportGuide.GuiaRemisionExportacionPrint.rdlc";
            this.guiaRemisionReportViewer.Location = new System.Drawing.Point(0, 0);
            this.guiaRemisionReportViewer.Name = "guiaRemisionReportViewer";
            this.guiaRemisionReportViewer.Size = new System.Drawing.Size(667, 486);
            this.guiaRemisionReportViewer.TabIndex = 0;
            //// 
            //// GuiaRemisionExportacionModelBindingSource
            //// 
            //this.GuiaRemisionExportacionModelBindingSource.DataMember = "greDet";
            //this.GuiaRemisionExportacionModelBindingSource.DataSource = typeof(SoftCotton.Reports.RemittanceGuide.ExportGuide.GuiaRemisionExportacionModel);
            //// 
            // GuiaRemisionExportacionPrintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(667, 486);
            this.Controls.Add(this.guiaRemisionReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GuiaRemisionExportacionPrintView";
            this.Text = "Impresión Guia de Remisión de Exportación";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GuiaRemisionExportacionPrintView_FormClosed);
            this.Load += new System.EventHandler(this.GuiaRemisionExportacionPrintView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GuiaRemisionExportacionModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer guiaRemisionReportViewer;
        private System.Windows.Forms.BindingSource GuiaRemisionExportacionModelBindingSource;
    }
}