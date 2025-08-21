namespace SoftCotton.Views.Maintenance
{
    partial class BuscarProgramasView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarProgramasView));
            this.dgvProgramas = new System.Windows.Forms.DataGridView();
            this.idPrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrograma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProgramas
            // 
            this.dgvProgramas.AllowUserToAddRows = false;
            this.dgvProgramas.AllowUserToDeleteRows = false;
            this.dgvProgramas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgramas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPrograma,
            this.programa});
            this.dgvProgramas.Location = new System.Drawing.Point(16, 44);
            this.dgvProgramas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProgramas.Name = "dgvProgramas";
            this.dgvProgramas.ReadOnly = true;
            this.dgvProgramas.RowHeadersVisible = false;
            this.dgvProgramas.RowHeadersWidth = 51;
            this.dgvProgramas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProgramas.Size = new System.Drawing.Size(788, 217);
            this.dgvProgramas.TabIndex = 0;
            this.dgvProgramas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProgramas_KeyDown);
            this.dgvProgramas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvProgramas_KeyUp);
            // 
            // idPrograma
            // 
            this.idPrograma.DataPropertyName = "idPrograma";
            this.idPrograma.HeaderText = "Id";
            this.idPrograma.MinimumWidth = 6;
            this.idPrograma.Name = "idPrograma";
            this.idPrograma.ReadOnly = true;
            this.idPrograma.Width = 125;
            // 
            // programa
            // 
            this.programa.DataPropertyName = "programa";
            this.programa.HeaderText = "Programa";
            this.programa.MinimumWidth = 6;
            this.programa.Name = "programa";
            this.programa.ReadOnly = true;
            this.programa.Width = 125;
            // 
            // txtPrograma
            // 
            this.txtPrograma.Location = new System.Drawing.Point(400, 12);
            this.txtPrograma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(403, 22);
            this.txtPrograma.TabIndex = 6;
            this.txtPrograma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrograma_KeyDown);
            this.txtPrograma.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPedido_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Programa:";
            // 
            // BuscarProgramasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 273);
            this.Controls.Add(this.txtPrograma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProgramas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BuscarProgramasView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Programas";
            this.Load += new System.EventHandler(this.BuscarProgramasView_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProgramas;
        private System.Windows.Forms.TextBox txtPrograma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrograma;
        private System.Windows.Forms.DataGridViewTextBoxColumn programa;
    }
}