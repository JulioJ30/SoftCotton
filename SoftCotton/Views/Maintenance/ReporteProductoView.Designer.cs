namespace SoftCotton.Views.Maintenance
{
    partial class ReporteProductoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteProductoView));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTalla = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxNivel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvTxtCodNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodProductoAlt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtStockReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTxtCodNivel,
            this.dgvTxtNivel,
            this.dgvTxtCodGrupo,
            this.dgvTxtGrupo,
            this.dgvTxtCodTalla,
            this.dgvTxtTalla,
            this.dgvTxtCodColor,
            this.dgvTxtColor,
            this.dgvTxtCodProductoAlt,
            this.dgvTxtStockReal});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 70);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(913, 335);
            this.dgvListado.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(913, 70);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTalla);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbxNivel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGrupo);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por Fechas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(519, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Color:";
            // 
            // txtColor
            // 
            this.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColor.Location = new System.Drawing.Point(558, 22);
            this.txtColor.MaxLength = 250;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(91, 22);
            this.txtColor.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Talla:";
            // 
            // txtTalla
            // 
            this.txtTalla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTalla.Location = new System.Drawing.Point(422, 22);
            this.txtTalla.MaxLength = 250;
            this.txtTalla.Name = "txtTalla";
            this.txtTalla.Size = new System.Drawing.Size(87, 22);
            this.txtTalla.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Grupo:";
            // 
            // cbxNivel
            // 
            this.cbxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNivel.FormattingEnabled = true;
            this.cbxNivel.Location = new System.Drawing.Point(60, 22);
            this.cbxNivel.Name = "cbxNivel";
            this.cbxNivel.Size = new System.Drawing.Size(138, 21);
            this.cbxNivel.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Nivel:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrupo.Location = new System.Drawing.Point(267, 22);
            this.txtGrupo.MaxLength = 250;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(91, 22);
            this.txtGrupo.TabIndex = 62;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(699, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 41);
            this.panel2.TabIndex = 59;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SoftCotton.Properties.Resources.icon_excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(106, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnExcel.Size = new System.Drawing.Size(92, 25);
            this.btnExcel.TabIndex = 58;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(8, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnBuscar.Size = new System.Drawing.Size(92, 25);
            this.btnBuscar.TabIndex = 57;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvTxtCodNivel
            // 
            this.dgvTxtCodNivel.HeaderText = "Cod. Nivel";
            this.dgvTxtCodNivel.Name = "dgvTxtCodNivel";
            this.dgvTxtCodNivel.ReadOnly = true;
            // 
            // dgvTxtNivel
            // 
            this.dgvTxtNivel.HeaderText = "Nivel";
            this.dgvTxtNivel.Name = "dgvTxtNivel";
            this.dgvTxtNivel.ReadOnly = true;
            // 
            // dgvTxtCodGrupo
            // 
            this.dgvTxtCodGrupo.HeaderText = "Cod.Grupo";
            this.dgvTxtCodGrupo.Name = "dgvTxtCodGrupo";
            this.dgvTxtCodGrupo.ReadOnly = true;
            // 
            // dgvTxtGrupo
            // 
            this.dgvTxtGrupo.HeaderText = "Grupo";
            this.dgvTxtGrupo.Name = "dgvTxtGrupo";
            this.dgvTxtGrupo.ReadOnly = true;
            // 
            // dgvTxtCodTalla
            // 
            this.dgvTxtCodTalla.HeaderText = "Cod. Talla";
            this.dgvTxtCodTalla.Name = "dgvTxtCodTalla";
            this.dgvTxtCodTalla.ReadOnly = true;
            // 
            // dgvTxtTalla
            // 
            this.dgvTxtTalla.HeaderText = "Talla";
            this.dgvTxtTalla.Name = "dgvTxtTalla";
            this.dgvTxtTalla.ReadOnly = true;
            // 
            // dgvTxtCodColor
            // 
            this.dgvTxtCodColor.HeaderText = "Cod. Color";
            this.dgvTxtCodColor.Name = "dgvTxtCodColor";
            this.dgvTxtCodColor.ReadOnly = true;
            // 
            // dgvTxtColor
            // 
            this.dgvTxtColor.HeaderText = "Color";
            this.dgvTxtColor.Name = "dgvTxtColor";
            this.dgvTxtColor.ReadOnly = true;
            // 
            // dgvTxtCodProductoAlt
            // 
            this.dgvTxtCodProductoAlt.HeaderText = "Cod. Producto Alternativo";
            this.dgvTxtCodProductoAlt.Name = "dgvTxtCodProductoAlt";
            this.dgvTxtCodProductoAlt.ReadOnly = true;
            // 
            // dgvTxtStockReal
            // 
            this.dgvTxtStockReal.HeaderText = "Stock Real";
            this.dgvTxtStockReal.Name = "dgvTxtStockReal";
            this.dgvTxtStockReal.ReadOnly = true;
            // 
            // ReporteProductoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 405);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteProductoView";
            this.Text = "Reporte de Productos / Servicios";
            this.Load += new System.EventHandler(this.ReporteProductoView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxNivel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodProductoAlt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtStockReal;
    }
}