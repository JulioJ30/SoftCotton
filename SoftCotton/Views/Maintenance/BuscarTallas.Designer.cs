namespace SoftCotton.Views.Maintenance
{
    partial class BuscarTallas
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
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.txtTalla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CodTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvDescripcionTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodTalla,
            this.DgvDescripcionTalla});
            this.dgvLista.Location = new System.Drawing.Point(13, 53);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.RowHeadersWidth = 51;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(583, 422);
            this.dgvLista.TabIndex = 9;
            this.dgvLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLista_KeyDown);
            // 
            // txtTalla
            // 
            this.txtTalla.Location = new System.Drawing.Point(217, 6);
            this.txtTalla.Margin = new System.Windows.Forms.Padding(4);
            this.txtTalla.Name = "txtTalla";
            this.txtTalla.Size = new System.Drawing.Size(379, 22);
            this.txtTalla.TabIndex = 8;
            this.txtTalla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTalla_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Talla";
            // 
            // CodTalla
            // 
            this.CodTalla.DataPropertyName = "CodTalla";
            this.CodTalla.HeaderText = "Cod. Talla";
            this.CodTalla.MinimumWidth = 6;
            this.CodTalla.Name = "CodTalla";
            this.CodTalla.ReadOnly = true;
            // 
            // DgvDescripcionTalla
            // 
            this.DgvDescripcionTalla.DataPropertyName = "descripcion";
            this.DgvDescripcionTalla.HeaderText = "Desc. Talla";
            this.DgvDescripcionTalla.MinimumWidth = 6;
            this.DgvDescripcionTalla.Name = "DgvDescripcionTalla";
            this.DgvDescripcionTalla.ReadOnly = true;
            // 
            // BuscarTallas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 488);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.txtTalla);
            this.Controls.Add(this.label1);
            this.Name = "BuscarTallas";
            this.Text = "Busqueda Tallas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.TextBox txtTalla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvDescripcionTalla;
    }
}