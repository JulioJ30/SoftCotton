namespace SoftCotton.Reports.ServiceOrder.OrdenServicio
{
    partial class OrdenServicioRpteView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenServicioRpteView));
            this.OrdenServicioReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OrdenServicioModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrdenServicioModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdenServicioReportViewer
            // 
            this.OrdenServicioReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsOrdenServicioDetalle";
            reportDataSource1.Value = this.OrdenServicioModelBindingSource;
            this.OrdenServicioReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.OrdenServicioReportViewer.LocalReport.ReportEmbeddedResource = "SoftCotton.Reports.ServiceOrder.OrdenServicio.OrdenServicioRpte.rdlc";
            this.OrdenServicioReportViewer.Location = new System.Drawing.Point(0, 0);
            this.OrdenServicioReportViewer.Name = "OrdenServicioReportViewer";
            this.OrdenServicioReportViewer.Size = new System.Drawing.Size(576, 515);
            this.OrdenServicioReportViewer.TabIndex = 0;
            // 
            // OrdenServicioModelBindingSource
            // 
            this.OrdenServicioModelBindingSource.DataMember = "osDet";
            this.OrdenServicioModelBindingSource.DataSource = typeof(SoftCotton.Reports.ServiceOrder.OrdenServicio.OrdenServicioModel);
            // 
            // OrdenServicioRpteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 515);
            this.Controls.Add(this.OrdenServicioReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdenServicioRpteView";
            this.Text = "Reporte de Orden de Servicio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrdenServicioRpteView_FormClosed);
            this.Load += new System.EventHandler(this.OrdenServicioRpteView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdenServicioModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer OrdenServicioReportViewer;
        private System.Windows.Forms.BindingSource OrdenServicioModelBindingSource;
    }
}