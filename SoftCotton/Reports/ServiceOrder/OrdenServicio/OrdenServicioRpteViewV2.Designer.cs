namespace SoftCotton.Reports.ServiceOrder.OrdenServicio
{
    partial class OrdenServicioRpteViewV2
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.OrdenServicioReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OrdenServicioModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrdenServicioModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdenServicioReportViewer
            // 
            this.OrdenServicioReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dsOrdenServicioDetalle";
            reportDataSource2.Value = null;
            this.OrdenServicioReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.OrdenServicioReportViewer.LocalReport.ReportEmbeddedResource = "SoftCotton.Reports.ServiceOrder.OrdenServicio.OrdenServicioRpteV2.rdlc";
            this.OrdenServicioReportViewer.Location = new System.Drawing.Point(0, 0);
            this.OrdenServicioReportViewer.Margin = new System.Windows.Forms.Padding(2);
            this.OrdenServicioReportViewer.Name = "OrdenServicioReportViewer";
            this.OrdenServicioReportViewer.Size = new System.Drawing.Size(384, 335);
            this.OrdenServicioReportViewer.TabIndex = 2;
            // 
            // OrdenServicioModelBindingSource
            // 
            this.OrdenServicioModelBindingSource.DataMember = "osDet";
            this.OrdenServicioModelBindingSource.DataSource = typeof(SoftCotton.Reports.ServiceOrder.OrdenServicio.OrdenServicioModelV2);
            // 
            // OrdenServicioRpteViewV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 335);
            this.Controls.Add(this.OrdenServicioReportViewer);
            this.Name = "OrdenServicioRpteViewV2";
            this.Text = "Reporte de Orden Servicio Especial";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrdenServicioRpteViewV2_FormClosed);
            this.Load += new System.EventHandler(this.OrdenServicioRpteViewV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdenServicioModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer OrdenServicioReportViewer;
        private System.Windows.Forms.BindingSource OrdenServicioModelBindingSource;
    }
}