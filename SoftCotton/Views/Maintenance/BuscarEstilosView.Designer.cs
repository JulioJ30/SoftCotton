namespace SoftCotton.Views.Maintenance
{
    partial class BuscarEstilosView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarEstilosView));
            this.txtEstilo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEstilos = new System.Windows.Forms.DataGridView();
            this.idEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstilos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEstilo
            // 
            this.txtEstilo.Location = new System.Drawing.Point(300, 10);
            this.txtEstilo.Name = "txtEstilo";
            this.txtEstilo.Size = new System.Drawing.Size(303, 20);
            this.txtEstilo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Estilos:";
            // 
            // dgvEstilos
            // 
            this.dgvEstilos.AllowUserToAddRows = false;
            this.dgvEstilos.AllowUserToDeleteRows = false;
            this.dgvEstilos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstilos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEstilo,
            this.codigoEstilo,
            this.estilo});
            this.dgvEstilos.Location = new System.Drawing.Point(12, 36);
            this.dgvEstilos.Name = "dgvEstilos";
            this.dgvEstilos.ReadOnly = true;
            this.dgvEstilos.RowHeadersVisible = false;
            this.dgvEstilos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstilos.Size = new System.Drawing.Size(591, 328);
            this.dgvEstilos.TabIndex = 7;
            this.dgvEstilos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvEstilos_KeyDown);
            this.dgvEstilos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvEstilos_KeyUp);
            // 
            // idEstilo
            // 
            this.idEstilo.DataPropertyName = "idEstilo";
            this.idEstilo.HeaderText = "Id";
            this.idEstilo.Name = "idEstilo";
            this.idEstilo.ReadOnly = true;
            // 
            // codigoEstilo
            // 
            this.codigoEstilo.DataPropertyName = "codigoEstilo";
            this.codigoEstilo.HeaderText = "Codigo Estilo";
            this.codigoEstilo.Name = "codigoEstilo";
            this.codigoEstilo.ReadOnly = true;
            // 
            // estilo
            // 
            this.estilo.DataPropertyName = "estilo";
            this.estilo.HeaderText = "Estilo";
            this.estilo.Name = "estilo";
            this.estilo.ReadOnly = true;
            // 
            // BuscarEstilosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 368);
            this.Controls.Add(this.txtEstilo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEstilos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BuscarEstilosView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Estilos";
            this.Load += new System.EventHandler(this.BuscarEstilosView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstilos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEstilo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEstilos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoEstilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estilo;
    }
}