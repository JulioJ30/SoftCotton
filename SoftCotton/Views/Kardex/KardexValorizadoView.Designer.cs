namespace SoftCotton.Views.Kardex
{
    partial class KardexValorizadoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KardexValorizadoView));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Guia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie_fact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num_fact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fact_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpo_opera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPeriodo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbCuenta);
            this.groupBox1.Controls.Add(this.label7);
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
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1364, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPeriodo.Location = new System.Drawing.Point(938, 27);
            this.txtPeriodo.Margin = new System.Windows.Forms.Padding(2);
            this.txtPeriodo.MaxLength = 250;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(108, 26);
            this.txtPeriodo.TabIndex = 84;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(803, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 83;
            this.label4.Text = "Periodo(yyyymm):";
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(266, 25);
            this.cmbCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(176, 28);
            this.cmbCuenta.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 82;
            this.label7.Text = "Cuenta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(685, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 76;
            this.label3.Text = "Color:";
            // 
            // txtColor
            // 
            this.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColor.Location = new System.Drawing.Point(730, 27);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.MaxLength = 250;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(69, 26);
            this.txtColor.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(575, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 74;
            this.label2.Text = "Talla:";
            // 
            // txtTalla
            // 
            this.txtTalla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTalla.Location = new System.Drawing.Point(610, 27);
            this.txtTalla.Margin = new System.Windows.Forms.Padding(2);
            this.txtTalla.MaxLength = 250;
            this.txtTalla.Name = "txtTalla";
            this.txtTalla.Size = new System.Drawing.Size(66, 26);
            this.txtTalla.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(446, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 72;
            this.label5.Text = "Grupo:";
            // 
            // cbxNivel
            // 
            this.cbxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNivel.FormattingEnabled = true;
            this.cbxNivel.Location = new System.Drawing.Point(58, 26);
            this.cbxNivel.Margin = new System.Windows.Forms.Padding(2);
            this.cbxNivel.Name = "cbxNivel";
            this.cbxNivel.Size = new System.Drawing.Size(144, 28);
            this.cbxNivel.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 70;
            this.label1.Text = "Nivel:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrupo.Location = new System.Drawing.Point(493, 27);
            this.txtGrupo.Margin = new System.Windows.Forms.Padding(2);
            this.txtGrupo.MaxLength = 250;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(78, 26);
            this.txtGrupo.TabIndex = 71;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1050, 21);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 38);
            this.panel2.TabIndex = 68;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SoftCotton.Properties.Resources.icon_excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(107, 8);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnExcel.Size = new System.Drawing.Size(96, 28);
            this.btnExcel.TabIndex = 58;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(13, 8);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnBuscar.Size = new System.Drawing.Size(90, 28);
            this.btnBuscar.TabIndex = 57;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orden,
            this.tipo,
            this.cod,
            this.Nombre_Articulo,
            this.color,
            this.Fecha_Guia,
            this.serie,
            this.numero,
            this.codigo_Proveedor,
            this.razonSocial,
            this.serie_fact,
            this.Num_fact,
            this.Tipo_Moneda,
            this.codigo,
            this.UM,
            this.PU,
            this.fact_tipo,
            this.mes,
            this.tipoMovimiento,
            this.cantidad,
            this.cuo,
            this.tpo_opera});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 67);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersWidth = 51;
            this.dgvListado.Size = new System.Drawing.Size(1370, 329);
            this.dgvListado.TabIndex = 5;
            // 
            // orden
            // 
            this.orden.HeaderText = "Item";
            this.orden.MinimumWidth = 6;
            this.orden.Name = "orden";
            this.orden.ReadOnly = true;
            this.orden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orden.Width = 125;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "tipo";
            this.tipo.MinimumWidth = 6;
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tipo.Width = 125;
            // 
            // cod
            // 
            this.cod.HeaderText = "Cod Producto";
            this.cod.MinimumWidth = 6;
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cod.Width = 125;
            // 
            // Nombre_Articulo
            // 
            this.Nombre_Articulo.HeaderText = "Nombre_Articulo";
            this.Nombre_Articulo.MinimumWidth = 6;
            this.Nombre_Articulo.Name = "Nombre_Articulo";
            this.Nombre_Articulo.ReadOnly = true;
            this.Nombre_Articulo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nombre_Articulo.Width = 125;
            // 
            // color
            // 
            this.color.HeaderText = "color";
            this.color.MinimumWidth = 6;
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.color.Width = 125;
            // 
            // Fecha_Guia
            // 
            this.Fecha_Guia.HeaderText = "Fecha_Guia";
            this.Fecha_Guia.MinimumWidth = 6;
            this.Fecha_Guia.Name = "Fecha_Guia";
            this.Fecha_Guia.ReadOnly = true;
            this.Fecha_Guia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Fecha_Guia.Width = 125;
            // 
            // serie
            // 
            this.serie.HeaderText = "serie";
            this.serie.MinimumWidth = 6;
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serie.Width = 125;
            // 
            // numero
            // 
            this.numero.HeaderText = "numero";
            this.numero.MinimumWidth = 6;
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.numero.Width = 125;
            // 
            // codigo_Proveedor
            // 
            this.codigo_Proveedor.HeaderText = "codigo Proveedor";
            this.codigo_Proveedor.MinimumWidth = 6;
            this.codigo_Proveedor.Name = "codigo_Proveedor";
            this.codigo_Proveedor.ReadOnly = true;
            this.codigo_Proveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codigo_Proveedor.Width = 125;
            // 
            // razonSocial
            // 
            this.razonSocial.HeaderText = "razonSocial";
            this.razonSocial.MinimumWidth = 6;
            this.razonSocial.Name = "razonSocial";
            this.razonSocial.ReadOnly = true;
            this.razonSocial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.razonSocial.Width = 125;
            // 
            // serie_fact
            // 
            this.serie_fact.HeaderText = "Serie Fact";
            this.serie_fact.MinimumWidth = 6;
            this.serie_fact.Name = "serie_fact";
            this.serie_fact.ReadOnly = true;
            this.serie_fact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serie_fact.Width = 125;
            // 
            // Num_fact
            // 
            this.Num_fact.HeaderText = "Numero Fact";
            this.Num_fact.MinimumWidth = 6;
            this.Num_fact.Name = "Num_fact";
            this.Num_fact.ReadOnly = true;
            this.Num_fact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Num_fact.Width = 125;
            // 
            // Tipo_Moneda
            // 
            this.Tipo_Moneda.HeaderText = "Moneda";
            this.Tipo_Moneda.MinimumWidth = 6;
            this.Tipo_Moneda.Name = "Tipo_Moneda";
            this.Tipo_Moneda.ReadOnly = true;
            this.Tipo_Moneda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tipo_Moneda.Width = 125;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "codigo";
            this.codigo.MinimumWidth = 6;
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codigo.Width = 125;
            // 
            // UM
            // 
            this.UM.HeaderText = "UM";
            this.UM.MinimumWidth = 6;
            this.UM.Name = "UM";
            this.UM.ReadOnly = true;
            this.UM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UM.Width = 125;
            // 
            // PU
            // 
            this.PU.HeaderText = "PU";
            this.PU.MinimumWidth = 6;
            this.PU.Name = "PU";
            this.PU.ReadOnly = true;
            this.PU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PU.Width = 125;
            // 
            // fact_tipo
            // 
            this.fact_tipo.HeaderText = "fact_tipo";
            this.fact_tipo.MinimumWidth = 6;
            this.fact_tipo.Name = "fact_tipo";
            this.fact_tipo.ReadOnly = true;
            this.fact_tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fact_tipo.Width = 125;
            // 
            // mes
            // 
            this.mes.HeaderText = "mes";
            this.mes.MinimumWidth = 6;
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            this.mes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mes.Width = 125;
            // 
            // tipoMovimiento
            // 
            this.tipoMovimiento.HeaderText = "Entrada/Salida";
            this.tipoMovimiento.MinimumWidth = 6;
            this.tipoMovimiento.Name = "tipoMovimiento";
            this.tipoMovimiento.ReadOnly = true;
            this.tipoMovimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tipoMovimiento.Width = 125;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cantidad.Width = 125;
            // 
            // cuo
            // 
            this.cuo.HeaderText = "CUO";
            this.cuo.MinimumWidth = 8;
            this.cuo.Name = "cuo";
            this.cuo.ReadOnly = true;
            this.cuo.Width = 150;
            // 
            // tpo_opera
            // 
            this.tpo_opera.HeaderText = "Tipo Operación";
            this.tpo_opera.MinimumWidth = 8;
            this.tpo_opera.Name = "tpo_opera";
            this.tpo_opera.ReadOnly = true;
            this.tpo_opera.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1370, 67);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Image = global::SoftCotton.Properties.Resources.icon_print;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(210, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(96, 28);
            this.button1.TabIndex = 59;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // KardexValorizadoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 396);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KardexValorizadoView";
            this.Text = "Kardex Valorizado";
            this.Load += new System.EventHandler(this.KardexValorizadoView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTalla;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxNivel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Guia;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie_fact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num_fact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PU;
        private System.Windows.Forms.DataGridViewTextBoxColumn fact_tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpo_opera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Button button1;
    }
}