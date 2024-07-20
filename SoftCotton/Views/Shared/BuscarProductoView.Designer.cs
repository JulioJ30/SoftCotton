namespace SoftCotton.Views.Shared
{
    partial class BuscarProductoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarProductoView));
            this.dgvProdServ = new System.Windows.Forms.DataGridView();
            this.ctxtCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtProductoServ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCodigoNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCodigoGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCodigoTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCodigoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCodigoUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdServ)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdServ
            // 
            this.dgvProdServ.AllowUserToAddRows = false;
            this.dgvProdServ.AllowUserToDeleteRows = false;
            this.dgvProdServ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdServ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtCodigoProducto,
            this.ctxtProductoServ,
            this.ctxtCodigoNivel,
            this.ctxtNivel,
            this.ctxtCodigoGrupo,
            this.ctxtGrupo,
            this.ctxtCodigoTalla,
            this.ctxtTalla,
            this.ctxtCodigoColor,
            this.ctxtColor,
            this.ctxtCodigoUM});
            this.dgvProdServ.Location = new System.Drawing.Point(3, 20);
            this.dgvProdServ.MultiSelect = false;
            this.dgvProdServ.Name = "dgvProdServ";
            this.dgvProdServ.ReadOnly = true;
            this.dgvProdServ.RowHeadersVisible = false;
            this.dgvProdServ.RowHeadersWidth = 51;
            this.dgvProdServ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdServ.Size = new System.Drawing.Size(725, 367);
            this.dgvProdServ.TabIndex = 5;
            this.dgvProdServ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProdServ_KeyDown);
            // 
            // ctxtCodigoProducto
            // 
            this.ctxtCodigoProducto.HeaderText = "Código";
            this.ctxtCodigoProducto.MinimumWidth = 6;
            this.ctxtCodigoProducto.Name = "ctxtCodigoProducto";
            this.ctxtCodigoProducto.ReadOnly = true;
            this.ctxtCodigoProducto.Width = 140;
            // 
            // ctxtProductoServ
            // 
            this.ctxtProductoServ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ctxtProductoServ.HeaderText = "Producto / Servicio";
            this.ctxtProductoServ.MinimumWidth = 6;
            this.ctxtProductoServ.Name = "ctxtProductoServ";
            this.ctxtProductoServ.ReadOnly = true;
            // 
            // ctxtCodigoNivel
            // 
            this.ctxtCodigoNivel.HeaderText = "Cod. Nivel";
            this.ctxtCodigoNivel.MinimumWidth = 6;
            this.ctxtCodigoNivel.Name = "ctxtCodigoNivel";
            this.ctxtCodigoNivel.ReadOnly = true;
            this.ctxtCodigoNivel.Visible = false;
            this.ctxtCodigoNivel.Width = 125;
            // 
            // ctxtNivel
            // 
            this.ctxtNivel.HeaderText = "Nivel";
            this.ctxtNivel.MinimumWidth = 6;
            this.ctxtNivel.Name = "ctxtNivel";
            this.ctxtNivel.ReadOnly = true;
            this.ctxtNivel.Visible = false;
            this.ctxtNivel.Width = 125;
            // 
            // ctxtCodigoGrupo
            // 
            this.ctxtCodigoGrupo.HeaderText = "Cod. Grupo";
            this.ctxtCodigoGrupo.MinimumWidth = 6;
            this.ctxtCodigoGrupo.Name = "ctxtCodigoGrupo";
            this.ctxtCodigoGrupo.ReadOnly = true;
            this.ctxtCodigoGrupo.Visible = false;
            this.ctxtCodigoGrupo.Width = 125;
            // 
            // ctxtGrupo
            // 
            this.ctxtGrupo.HeaderText = "Grupo";
            this.ctxtGrupo.MinimumWidth = 6;
            this.ctxtGrupo.Name = "ctxtGrupo";
            this.ctxtGrupo.ReadOnly = true;
            this.ctxtGrupo.Visible = false;
            this.ctxtGrupo.Width = 125;
            // 
            // ctxtCodigoTalla
            // 
            this.ctxtCodigoTalla.HeaderText = "Cod. Talla";
            this.ctxtCodigoTalla.MinimumWidth = 6;
            this.ctxtCodigoTalla.Name = "ctxtCodigoTalla";
            this.ctxtCodigoTalla.ReadOnly = true;
            this.ctxtCodigoTalla.Visible = false;
            this.ctxtCodigoTalla.Width = 125;
            // 
            // ctxtTalla
            // 
            this.ctxtTalla.HeaderText = "Talla";
            this.ctxtTalla.MinimumWidth = 6;
            this.ctxtTalla.Name = "ctxtTalla";
            this.ctxtTalla.ReadOnly = true;
            this.ctxtTalla.Visible = false;
            this.ctxtTalla.Width = 125;
            // 
            // ctxtCodigoColor
            // 
            this.ctxtCodigoColor.HeaderText = "Cod. Color";
            this.ctxtCodigoColor.MinimumWidth = 6;
            this.ctxtCodigoColor.Name = "ctxtCodigoColor";
            this.ctxtCodigoColor.ReadOnly = true;
            this.ctxtCodigoColor.Visible = false;
            this.ctxtCodigoColor.Width = 125;
            // 
            // ctxtColor
            // 
            this.ctxtColor.HeaderText = "Color";
            this.ctxtColor.MinimumWidth = 6;
            this.ctxtColor.Name = "ctxtColor";
            this.ctxtColor.ReadOnly = true;
            this.ctxtColor.Visible = false;
            this.ctxtColor.Width = 125;
            // 
            // ctxtCodigoUM
            // 
            this.ctxtCodigoUM.HeaderText = "Cod. UM";
            this.ctxtCodigoUM.MinimumWidth = 6;
            this.ctxtCodigoUM.Name = "ctxtCodigoUM";
            this.ctxtCodigoUM.ReadOnly = true;
            this.ctxtCodigoUM.Visible = false;
            this.ctxtCodigoUM.Width = 125;
            // 
            // BuscarProductoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(731, 393);
            this.Controls.Add(this.dgvProdServ);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "BuscarProductoView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Producto";
            this.Load += new System.EventHandler(this.BuscarProductoView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BuscarProductoView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdServ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProdServ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtProductoServ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodigoNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodigoGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodigoTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodigoColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodigoUM;
    }
}