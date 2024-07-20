namespace SoftCotton.Views.Shared
{
    partial class BuscarProvClienteView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarProvClienteView));
            this.label1 = new System.Windows.Forms.Label();
            this.txtProvCliente = new System.Windows.Forms.TextBox();
            this.dgvProvCliente = new System.Windows.Forms.DataGridView();
            this.ctxtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor / Cliente:";
            // 
            // txtProvCliente
            // 
            this.txtProvCliente.Location = new System.Drawing.Point(123, 6);
            this.txtProvCliente.Name = "txtProvCliente";
            this.txtProvCliente.Size = new System.Drawing.Size(285, 22);
            this.txtProvCliente.TabIndex = 1;
            this.txtProvCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProvCliente_KeyPress);
            // 
            // dgvProvCliente
            // 
            this.dgvProvCliente.AllowUserToAddRows = false;
            this.dgvProvCliente.AllowUserToDeleteRows = false;
            this.dgvProvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtCodigo,
            this.ctxtRazonSocial,
            this.ctxtDireccion});
            this.dgvProvCliente.Location = new System.Drawing.Point(9, 34);
            this.dgvProvCliente.MultiSelect = false;
            this.dgvProvCliente.Name = "dgvProvCliente";
            this.dgvProvCliente.ReadOnly = true;
            this.dgvProvCliente.RowHeadersVisible = false;
            this.dgvProvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProvCliente.Size = new System.Drawing.Size(402, 294);
            this.dgvProvCliente.TabIndex = 2;
            this.dgvProvCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProvCliente_KeyDown);
            // 
            // ctxtCodigo
            // 
            this.ctxtCodigo.HeaderText = "Código";
            this.ctxtCodigo.Name = "ctxtCodigo";
            this.ctxtCodigo.ReadOnly = true;
            this.ctxtCodigo.Width = 90;
            // 
            // ctxtRazonSocial
            // 
            this.ctxtRazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ctxtRazonSocial.HeaderText = "Razón Social";
            this.ctxtRazonSocial.Name = "ctxtRazonSocial";
            this.ctxtRazonSocial.ReadOnly = true;
            // 
            // ctxtDireccion
            // 
            this.ctxtDireccion.HeaderText = "Direccion";
            this.ctxtDireccion.Name = "ctxtDireccion";
            this.ctxtDireccion.ReadOnly = true;
            this.ctxtDireccion.Visible = false;
            // 
            // BuscarProvClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(419, 331);
            this.Controls.Add(this.dgvProvCliente);
            this.Controls.Add(this.txtProvCliente);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarProvClienteView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Proveedor";
            this.Load += new System.EventHandler(this.BuscarProvClienteView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProvCliente;
        private System.Windows.Forms.DataGridView dgvProvCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtDireccion;
    }
}