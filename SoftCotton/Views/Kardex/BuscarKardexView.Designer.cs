namespace SoftCotton.Views.Kardex
{
    partial class BuscarKardexView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarKardexView));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
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
            this.orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.orden,
            this.secuencia,
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
            this.cantidad});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 67);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.RowHeadersWidth = 51;
            this.dgvListado.Size = new System.Drawing.Size(1334, 410);
            this.dgvListado.TabIndex = 3;
            this.dgvListado.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellEndEdit);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1334, 67);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCuenta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpFechaHasta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpFechaDesde);
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
            this.groupBox1.Size = new System.Drawing.Size(1328, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(217, 25);
            this.cmbCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(193, 31);
            this.cmbCuenta.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 23);
            this.label7.TabIndex = 82;
            this.label7.Text = "Cuenta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(942, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 23);
            this.label6.TabIndex = 80;
            this.label6.Text = "Hasta:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(988, 27);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(93, 29);
            this.dtpFechaHasta.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(788, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 23);
            this.label4.TabIndex = 78;
            this.label4.Text = "Desde:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(834, 27);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(95, 29);
            this.dtpFechaDesde.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(656, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 76;
            this.label3.Text = "Color:";
            // 
            // txtColor
            // 
            this.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColor.Location = new System.Drawing.Point(698, 27);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.MaxLength = 250;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(69, 29);
            this.txtColor.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 74;
            this.label2.Text = "Talla:";
            // 
            // txtTalla
            // 
            this.txtTalla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTalla.Location = new System.Drawing.Point(578, 27);
            this.txtTalla.Margin = new System.Windows.Forms.Padding(2);
            this.txtTalla.MaxLength = 250;
            this.txtTalla.Name = "txtTalla";
            this.txtTalla.Size = new System.Drawing.Size(66, 29);
            this.txtTalla.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 23);
            this.label5.TabIndex = 72;
            this.label5.Text = "Grupo:";
            // 
            // cbxNivel
            // 
            this.cbxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNivel.FormattingEnabled = true;
            this.cbxNivel.Location = new System.Drawing.Point(48, 26);
            this.cbxNivel.Margin = new System.Windows.Forms.Padding(2);
            this.cbxNivel.Name = "cbxNivel";
            this.cbxNivel.Size = new System.Drawing.Size(104, 31);
            this.cbxNivel.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 23);
            this.label1.TabIndex = 70;
            this.label1.Text = "Nivel:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrupo.Location = new System.Drawing.Point(461, 27);
            this.txtGrupo.Margin = new System.Windows.Forms.Padding(2);
            this.txtGrupo.MaxLength = 250;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(69, 29);
            this.txtGrupo.TabIndex = 71;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1101, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 35);
            this.panel2.TabIndex = 68;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SoftCotton.Properties.Resources.icon_excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(112, 4);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnExcel.Size = new System.Drawing.Size(106, 28);
            this.btnExcel.TabIndex = 58;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click_1);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(5, 4);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnBuscar.Size = new System.Drawing.Size(103, 28);
            this.btnBuscar.TabIndex = 57;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // orden
            // 
            this.orden.HeaderText = "Item";
            this.orden.MinimumWidth = 6;
            this.orden.Name = "orden";
            this.orden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orden.Width = 125;
            // 
            // secuencia
            // 
            this.secuencia.DataPropertyName = "secuencia";
            this.secuencia.HeaderText = "secuencia";
            this.secuencia.MinimumWidth = 8;
            this.secuencia.Name = "secuencia";
            this.secuencia.Visible = false;
            this.secuencia.Width = 150;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "tipo";
            this.tipo.MinimumWidth = 6;
            this.tipo.Name = "tipo";
            this.tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tipo.Width = 125;
            // 
            // cod
            // 
            this.cod.HeaderText = "Cod Producto";
            this.cod.MinimumWidth = 6;
            this.cod.Name = "cod";
            this.cod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cod.Width = 125;
            // 
            // Nombre_Articulo
            // 
            this.Nombre_Articulo.HeaderText = "Nombre_Articulo";
            this.Nombre_Articulo.MinimumWidth = 6;
            this.Nombre_Articulo.Name = "Nombre_Articulo";
            this.Nombre_Articulo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nombre_Articulo.Width = 125;
            // 
            // color
            // 
            this.color.HeaderText = "color";
            this.color.MinimumWidth = 6;
            this.color.Name = "color";
            this.color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.color.Width = 125;
            // 
            // Fecha_Guia
            // 
            this.Fecha_Guia.HeaderText = "Fecha_Guia";
            this.Fecha_Guia.MinimumWidth = 6;
            this.Fecha_Guia.Name = "Fecha_Guia";
            this.Fecha_Guia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Fecha_Guia.Width = 125;
            // 
            // serie
            // 
            this.serie.HeaderText = "serie";
            this.serie.MinimumWidth = 6;
            this.serie.Name = "serie";
            this.serie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serie.Width = 125;
            // 
            // numero
            // 
            this.numero.HeaderText = "numero";
            this.numero.MinimumWidth = 6;
            this.numero.Name = "numero";
            this.numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.numero.Width = 125;
            // 
            // codigo_Proveedor
            // 
            this.codigo_Proveedor.HeaderText = "codigo Proveedor";
            this.codigo_Proveedor.MinimumWidth = 6;
            this.codigo_Proveedor.Name = "codigo_Proveedor";
            this.codigo_Proveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codigo_Proveedor.Width = 125;
            // 
            // razonSocial
            // 
            this.razonSocial.HeaderText = "razonSocial";
            this.razonSocial.MinimumWidth = 6;
            this.razonSocial.Name = "razonSocial";
            this.razonSocial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.razonSocial.Width = 125;
            // 
            // serie_fact
            // 
            this.serie_fact.HeaderText = "Serie Fact";
            this.serie_fact.MinimumWidth = 6;
            this.serie_fact.Name = "serie_fact";
            this.serie_fact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serie_fact.Width = 125;
            // 
            // Num_fact
            // 
            this.Num_fact.HeaderText = "Numero Fact";
            this.Num_fact.MinimumWidth = 6;
            this.Num_fact.Name = "Num_fact";
            this.Num_fact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Num_fact.Width = 125;
            // 
            // Tipo_Moneda
            // 
            this.Tipo_Moneda.HeaderText = "Moneda";
            this.Tipo_Moneda.MinimumWidth = 6;
            this.Tipo_Moneda.Name = "Tipo_Moneda";
            this.Tipo_Moneda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tipo_Moneda.Width = 125;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "codigo";
            this.codigo.MinimumWidth = 6;
            this.codigo.Name = "codigo";
            this.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codigo.Width = 125;
            // 
            // UM
            // 
            this.UM.HeaderText = "UM";
            this.UM.MinimumWidth = 6;
            this.UM.Name = "UM";
            this.UM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UM.Width = 125;
            // 
            // PU
            // 
            this.PU.HeaderText = "PU";
            this.PU.MinimumWidth = 6;
            this.PU.Name = "PU";
            this.PU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PU.Width = 125;
            // 
            // fact_tipo
            // 
            this.fact_tipo.HeaderText = "fact_tipo";
            this.fact_tipo.MinimumWidth = 6;
            this.fact_tipo.Name = "fact_tipo";
            this.fact_tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fact_tipo.Width = 125;
            // 
            // mes
            // 
            this.mes.HeaderText = "mes";
            this.mes.MinimumWidth = 6;
            this.mes.Name = "mes";
            this.mes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mes.Width = 125;
            // 
            // tipoMovimiento
            // 
            this.tipoMovimiento.HeaderText = "Entrada/Salida";
            this.tipoMovimiento.MinimumWidth = 6;
            this.tipoMovimiento.Name = "tipoMovimiento";
            this.tipoMovimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tipoMovimiento.Width = 125;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cantidad.Width = 125;
            // 
            // BuscarKardexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1334, 477);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BuscarKardexView";
            this.Text = "Movimiento de Kardex";
            this.Load += new System.EventHandler(this.BuscarKardexView_Load);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn secuencia;
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
    }
}