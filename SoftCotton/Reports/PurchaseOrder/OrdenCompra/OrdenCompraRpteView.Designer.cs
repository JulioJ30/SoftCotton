﻿namespace SoftCotton.Reports.PurchaseOrder.OrdenCompra
{
    partial class OrdenCompraRpteView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenCompraRpteView));
            this.OrdenCompraModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdenCompraReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenCompraModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdenCompraModelBindingSource
            // 
            this.OrdenCompraModelBindingSource.DataMember = "ocDet";
            this.OrdenCompraModelBindingSource.DataSource = typeof(SoftCotton.Reports.PurchaseOrder.OrdenCompra.OrdenCompraModel);
            // 
            // OrdenCompraReportViewer
            // 
            this.OrdenCompraReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsOrdenCompraDetalle";
            reportDataSource1.Value = this.OrdenCompraModelBindingSource;
            this.OrdenCompraReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.OrdenCompraReportViewer.LocalReport.ReportEmbeddedResource = "SoftCotton.Reports.PurchaseOrder.OrdenCompra.OrdenCompraRpte.rdlc";
            this.OrdenCompraReportViewer.Location = new System.Drawing.Point(0, 0);
            this.OrdenCompraReportViewer.Name = "OrdenCompraReportViewer";
            this.OrdenCompraReportViewer.Size = new System.Drawing.Size(576, 515);
            this.OrdenCompraReportViewer.TabIndex = 0;
            // 
            // OrdenCompraRpteView
            // 
            this.ClientSize = new System.Drawing.Size(576, 515);
            this.Controls.Add(this.OrdenCompraReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdenCompraRpteView";
            this.Text = "Reporte de Orden Compra";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrdenCompraRpteView_FormClosed);
            this.Load += new System.EventHandler(this.OrdenCompraRpteView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdenCompraModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private Microsoft.Reporting.WinForms.ReportViewer OrdenCompraReportViewer;
        private System.Windows.Forms.BindingSource OrdenCompraModelBindingSource;

        #endregion

        //private Microsoft.Reporting.WinForms.ReportViewer OrdenCompraReportViewer;
    }
}