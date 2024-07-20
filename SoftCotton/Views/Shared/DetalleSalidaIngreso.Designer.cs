namespace SoftCotton.Views.Shared
{
    partial class DetalleSalidaIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleSalidaIngreso));
            this.dgvSalidaIngreso = new System.Windows.Forms.DataGridView();
            this.detTipoOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detSecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detCantidadIngresada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaIngreso)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalidaIngreso
            // 
            this.dgvSalidaIngreso.AllowUserToAddRows = false;
            this.dgvSalidaIngreso.AllowUserToDeleteRows = false;
            this.dgvSalidaIngreso.AllowUserToResizeColumns = false;
            this.dgvSalidaIngreso.AllowUserToResizeRows = false;
            this.dgvSalidaIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalidaIngreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detTipoOrden,
            this.detSerie,
            this.detNumero,
            this.detSecuencia,
            this.detCantidadIngresada});
            this.dgvSalidaIngreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalidaIngreso.Location = new System.Drawing.Point(0, 0);
            this.dgvSalidaIngreso.Name = "dgvSalidaIngreso";
            this.dgvSalidaIngreso.ReadOnly = true;
            this.dgvSalidaIngreso.RowHeadersVisible = false;
            this.dgvSalidaIngreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSalidaIngreso.Size = new System.Drawing.Size(510, 330);
            this.dgvSalidaIngreso.TabIndex = 3;
            // 
            // detTipoOrden
            // 
            this.detTipoOrden.HeaderText = "Tipo Orden";
            this.detTipoOrden.Name = "detTipoOrden";
            this.detTipoOrden.ReadOnly = true;
            // 
            // detSerie
            // 
            this.detSerie.HeaderText = "Guia Serie";
            this.detSerie.Name = "detSerie";
            this.detSerie.ReadOnly = true;
            // 
            // detNumero
            // 
            this.detNumero.HeaderText = "Guia Numero";
            this.detNumero.Name = "detNumero";
            this.detNumero.ReadOnly = true;
            // 
            // detSecuencia
            // 
            this.detSecuencia.HeaderText = "Guia Secuencia";
            this.detSecuencia.Name = "detSecuencia";
            this.detSecuencia.ReadOnly = true;
            // 
            // detCantidadIngresada
            // 
            this.detCantidadIngresada.HeaderText = "Cantidad";
            this.detCantidadIngresada.Name = "detCantidadIngresada";
            this.detCantidadIngresada.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbltotal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 43);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(367, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total:";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbltotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.Location = new System.Drawing.Point(439, 13);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(19, 22);
            this.lbltotal.TabIndex = 1;
            this.lbltotal.Text = "0";
            // 
            // DetalleSalidaIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 330);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSalidaIngreso);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetalleSalidaIngreso";
            this.Text = "Detalle Salida Ingreso";
            this.Load += new System.EventHandler(this.DetalleSalidaIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaIngreso)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalidaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn detTipoOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn detSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn detNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn detSecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn detCantidadIngresada;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label1;
    }
}