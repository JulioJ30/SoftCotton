namespace SoftCotton.Views.Maintenance
{
    partial class BuscarColorProductoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarColorProductoView));
            this.dgvColor = new System.Windows.Forms.DataGridView();
            this.ctxtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvColor
            // 
            this.dgvColor.AllowUserToAddRows = false;
            this.dgvColor.AllowUserToDeleteRows = false;
            this.dgvColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtCodigo,
            this.ctxtColor});
            this.dgvColor.Location = new System.Drawing.Point(12, 33);
            this.dgvColor.MultiSelect = false;
            this.dgvColor.Name = "dgvColor";
            this.dgvColor.ReadOnly = true;
            this.dgvColor.RowHeadersVisible = false;
            this.dgvColor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColor.Size = new System.Drawing.Size(402, 336);
            this.dgvColor.TabIndex = 5;
            this.dgvColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvColor_KeyDown);
            // 
            // ctxtCodigo
            // 
            this.ctxtCodigo.HeaderText = "Código";
            this.ctxtCodigo.Name = "ctxtCodigo";
            this.ctxtCodigo.ReadOnly = true;
            this.ctxtCodigo.Width = 90;
            // 
            // ctxtColor
            // 
            this.ctxtColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ctxtColor.HeaderText = "Color";
            this.ctxtColor.Name = "ctxtColor";
            this.ctxtColor.ReadOnly = true;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(126, 5);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(285, 22);
            this.txtColor.TabIndex = 4;
            this.txtColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColor_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Color:";
            // 
            // BuscarColorProductoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 376);
            this.Controls.Add(this.dgvColor);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BuscarColorProductoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Color por Producto";
            this.Load += new System.EventHandler(this.BuscarColorProductoView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtColor;
    }
}