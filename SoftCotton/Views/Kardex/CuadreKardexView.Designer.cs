namespace SoftCotton.Views.Kardex
{
    partial class CuadreKardexView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTalla = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaMovimiento = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTipoAjuste = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNivel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.ctxtIdCuadre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtTipoAjuste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtFechaMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCantRegistros = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(240, 520);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTalla);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtGrupo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpFechaMovimiento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxTipoAjuste);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxNivel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(230, 463);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Cuadre";
            // 
            // txtColor
            // 
            this.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColor.Location = new System.Drawing.Point(8, 241);
            this.txtColor.MaxLength = 6;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(210, 26);
            this.txtColor.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Código de Color:";
            // 
            // txtTalla
            // 
            this.txtTalla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTalla.Location = new System.Drawing.Point(8, 177);
            this.txtTalla.MaxLength = 3;
            this.txtTalla.Name = "txtTalla";
            this.txtTalla.Size = new System.Drawing.Size(210, 26);
            this.txtTalla.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Código de Talla:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrupo.Location = new System.Drawing.Point(8, 113);
            this.txtGrupo.MaxLength = 5;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(210, 26);
            this.txtGrupo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Código de Grupo:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(8, 358);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(210, 26);
            this.txtCantidad.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad:";
            // 
            // dtpFechaMovimiento
            // 
            this.dtpFechaMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaMovimiento.Location = new System.Drawing.Point(8, 425);
            this.dtpFechaMovimiento.Name = "dtpFechaMovimiento";
            this.dtpFechaMovimiento.Size = new System.Drawing.Size(210, 26);
            this.dtpFechaMovimiento.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha de Registro:";
            // 
            // cbxTipoAjuste
            // 
            this.cbxTipoAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoAjuste.FormattingEnabled = true;
            this.cbxTipoAjuste.Location = new System.Drawing.Point(8, 306);
            this.cbxTipoAjuste.Name = "cbxTipoAjuste";
            this.cbxTipoAjuste.Size = new System.Drawing.Size(210, 27);
            this.cbxTipoAjuste.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Ajuste:";
            // 
            // cbxNivel
            // 
            this.cbxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNivel.FormattingEnabled = true;
            this.cbxNivel.Location = new System.Drawing.Point(8, 52);
            this.cbxNivel.Name = "cbxNivel";
            this.cbxNivel.Size = new System.Drawing.Size(210, 27);
            this.cbxNivel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nivel / Categoría:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnGuardar);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(5, 468);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(230, 47);
            this.panel9.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(30, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(170, 33);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Registrar Cuadre";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(240, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(660, 520);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 510);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuadres Registrados";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvListado);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 53);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(644, 454);
            this.panel6.TabIndex = 1;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtIdCuadre,
            this.ctxtCodigo,
            this.ctxtArticulo,
            this.ctxtTipoAjuste,
            this.ctxtCantidad,
            this.ctxtFechaMovimiento,
            this.ctxtUsuarioReg,
            this.ctxtFechaReg,
            this.cbtnEliminar});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.RowHeadersWidth = 51;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListado.Size = new System.Drawing.Size(644, 454);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            // 
            // ctxtIdCuadre
            // 
            this.ctxtIdCuadre.HeaderText = "#";
            this.ctxtIdCuadre.MinimumWidth = 6;
            this.ctxtIdCuadre.Name = "ctxtIdCuadre";
            this.ctxtIdCuadre.ReadOnly = true;
            this.ctxtIdCuadre.Visible = false;
            this.ctxtIdCuadre.Width = 125;
            // 
            // ctxtCodigo
            // 
            this.ctxtCodigo.HeaderText = "Código de Producto";
            this.ctxtCodigo.MinimumWidth = 6;
            this.ctxtCodigo.Name = "ctxtCodigo";
            this.ctxtCodigo.ReadOnly = true;
            this.ctxtCodigo.Width = 150;
            // 
            // ctxtArticulo
            // 
            this.ctxtArticulo.HeaderText = "Artículo";
            this.ctxtArticulo.MinimumWidth = 6;
            this.ctxtArticulo.Name = "ctxtArticulo";
            this.ctxtArticulo.ReadOnly = true;
            this.ctxtArticulo.Width = 160;
            // 
            // ctxtTipoAjuste
            // 
            this.ctxtTipoAjuste.HeaderText = "Tipo de Ajuste";
            this.ctxtTipoAjuste.MinimumWidth = 6;
            this.ctxtTipoAjuste.Name = "ctxtTipoAjuste";
            this.ctxtTipoAjuste.ReadOnly = true;
            this.ctxtTipoAjuste.Width = 125;
            // 
            // ctxtCantidad
            // 
            this.ctxtCantidad.HeaderText = "Cantidad";
            this.ctxtCantidad.MinimumWidth = 6;
            this.ctxtCantidad.Name = "ctxtCantidad";
            this.ctxtCantidad.ReadOnly = true;
            this.ctxtCantidad.Width = 125;
            // 
            // ctxtFechaMovimiento
            // 
            this.ctxtFechaMovimiento.HeaderText = "Fecha de Registro";
            this.ctxtFechaMovimiento.MinimumWidth = 6;
            this.ctxtFechaMovimiento.Name = "ctxtFechaMovimiento";
            this.ctxtFechaMovimiento.ReadOnly = true;
            this.ctxtFechaMovimiento.Width = 110;
            // 
            // ctxtUsuarioReg
            // 
            this.ctxtUsuarioReg.HeaderText = "Usuario";
            this.ctxtUsuarioReg.MinimumWidth = 6;
            this.ctxtUsuarioReg.Name = "ctxtUsuarioReg";
            this.ctxtUsuarioReg.ReadOnly = true;
            this.ctxtUsuarioReg.Width = 125;
            // 
            // ctxtFechaReg
            // 
            this.ctxtFechaReg.HeaderText = "Fecha Ingreso";
            this.ctxtFechaReg.MinimumWidth = 6;
            this.ctxtFechaReg.Name = "ctxtFechaReg";
            this.ctxtFechaReg.ReadOnly = true;
            this.ctxtFechaReg.Width = 130;
            // 
            // cbtnEliminar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.cbtnEliminar.DefaultCellStyle = dataGridViewCellStyle2;
            this.cbtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnEliminar.HeaderText = "Eliminar";
            this.cbtnEliminar.MinimumWidth = 6;
            this.cbtnEliminar.Name = "cbtnEliminar";
            this.cbtnEliminar.ReadOnly = true;
            this.cbtnEliminar.Text = "Eliminar";
            this.cbtnEliminar.UseColumnTextForButtonValue = true;
            this.cbtnEliminar.Width = 125;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCantRegistros);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 31);
            this.panel3.TabIndex = 0;
            // 
            // lblCantRegistros
            // 
            this.lblCantRegistros.AutoSize = true;
            this.lblCantRegistros.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRegistros.Location = new System.Drawing.Point(8, 9);
            this.lblCantRegistros.Name = "lblCantRegistros";
            this.lblCantRegistros.Size = new System.Drawing.Size(173, 20);
            this.lblCantRegistros.TabIndex = 0;
            this.lblCantRegistros.Text = "Cantidad de Registros: 0";
            // 
            // CuadreKardexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CuadreKardexView";
            this.Text = "Cuadre de Kardex";
            this.Load += new System.EventHandler(this.CuadreKardexView_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaMovimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTipoAjuste;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxNivel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTalla;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtIdCuadre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtTipoAjuste;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtFechaMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUsuarioReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtFechaReg;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEliminar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCantRegistros;
    }
}
