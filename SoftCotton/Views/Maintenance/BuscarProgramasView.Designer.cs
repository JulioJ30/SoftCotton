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
            this.dgvProgramas.Location = new System.Drawing.Point(12, 36);
            this.dgvProgramas.Name = "dgvProgramas";
            this.dgvProgramas.ReadOnly = true;
            this.dgvProgramas.RowHeadersVisible = false;
            this.dgvProgramas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProgramas.Size = new System.Drawing.Size(591, 176);
            this.dgvProgramas.TabIndex = 0;
            this.dgvProgramas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProgramas_KeyDown);
            this.dgvProgramas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvProgramas_KeyUp);
            // 
            // idPrograma
            // 
            this.idPrograma.DataPropertyName = "idPrograma";
            this.idPrograma.HeaderText = "Id";
            this.idPrograma.Name = "idPrograma";
            this.idPrograma.ReadOnly = true;
            // 
            // programa
            // 
            this.programa.DataPropertyName = "programa";
            this.programa.HeaderText = "Programa";
            this.programa.Name = "programa";
            this.programa.ReadOnly = true;
            // 
            // txtPrograma
            // 
            this.txtPrograma.Location = new System.Drawing.Point(300, 10);
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(303, 20);
            this.txtPrograma.TabIndex = 6;
            this.txtPrograma.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPedido_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Programa:";
            // 
            // BuscarProgramasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 222);
            this.Controls.Add(this.txtPrograma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProgramas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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