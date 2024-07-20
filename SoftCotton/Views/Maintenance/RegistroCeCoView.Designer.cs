namespace SoftCotton.Views.Maintenance
{
    partial class RegistroCeCoView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroCeCoView));
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.ctxtCodCeCo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCeCo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbtnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbtnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCodCeCo = new System.Windows.Forms.Label();
            this.txtCodCeCo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCeCo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblCantRegistros = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(7, 11);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(118, 33);
            this.btnNuevo.TabIndex = 17;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnNuevo);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(5, 360);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(227, 47);
            this.panel9.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvListado);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 49);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(682, 298);
            this.panel6.TabIndex = 3;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtCodCeCo,
            this.ctxtCeCo,
            this.ctxtFechaReg,
            this.ctxtUsuarioReg,
            this.cbxActivo,
            this.cbtnEditar,
            this.cbtnEliminar});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListado.Size = new System.Drawing.Size(682, 298);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            // 
            // ctxtCodCeCo
            // 
            this.ctxtCodCeCo.HeaderText = "CodCeCo";
            this.ctxtCodCeCo.Name = "ctxtCodCeCo";
            this.ctxtCodCeCo.ReadOnly = true;
            // 
            // ctxtCeCo
            // 
            this.ctxtCeCo.HeaderText = "CeCo";
            this.ctxtCeCo.Name = "ctxtCeCo";
            this.ctxtCeCo.ReadOnly = true;
            this.ctxtCeCo.Width = 190;
            // 
            // ctxtFechaReg
            // 
            this.ctxtFechaReg.HeaderText = "Fecha Modifica";
            this.ctxtFechaReg.Name = "ctxtFechaReg";
            this.ctxtFechaReg.ReadOnly = true;
            this.ctxtFechaReg.Width = 110;
            // 
            // ctxtUsuarioReg
            // 
            this.ctxtUsuarioReg.HeaderText = "Usuario Modifica";
            this.ctxtUsuarioReg.Name = "ctxtUsuarioReg";
            this.ctxtUsuarioReg.ReadOnly = true;
            this.ctxtUsuarioReg.Width = 120;
            // 
            // cbxActivo
            // 
            this.cbxActivo.HeaderText = "Activo";
            this.cbxActivo.Name = "cbxActivo";
            this.cbxActivo.ReadOnly = true;
            // 
            // cbtnEditar
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.cbtnEditar.DefaultCellStyle = dataGridViewCellStyle1;
            this.cbtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnEditar.HeaderText = "Editar";
            this.cbtnEditar.Name = "cbtnEditar";
            this.cbtnEditar.ReadOnly = true;
            this.cbtnEditar.Text = "Editar";
            this.cbtnEditar.UseColumnTextForButtonValue = true;
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
            this.cbtnEliminar.Name = "cbtnEliminar";
            this.cbtnEliminar.ReadOnly = true;
            this.cbtnEliminar.Text = "Eliminar";
            this.cbtnEliminar.UseColumnTextForButtonValue = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(237, 412);
            this.panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCodCeCo);
            this.groupBox1.Controls.Add(this.txtCodCeCo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCeCo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(227, 355);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro ";
            // 
            // lblCodCeCo
            // 
            this.lblCodCeCo.AutoSize = true;
            this.lblCodCeCo.Location = new System.Drawing.Point(20, 166);
            this.lblCodCeCo.Name = "lblCodCeCo";
            this.lblCodCeCo.Size = new System.Drawing.Size(0, 13);
            this.lblCodCeCo.TabIndex = 12;
            // 
            // txtCodCeCo
            // 
            this.txtCodCeCo.Location = new System.Drawing.Point(8, 52);
            this.txtCodCeCo.MaxLength = 10;
            this.txtCodCeCo.Name = "txtCodCeCo";
            this.txtCodCeCo.Size = new System.Drawing.Size(209, 22);
            this.txtCodCeCo.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Código de Centro de Costo:";
            // 
            // txtCeCo
            // 
            this.txtCeCo.Location = new System.Drawing.Point(8, 118);
            this.txtCeCo.MaxLength = 20;
            this.txtCeCo.Name = "txtCeCo";
            this.txtCeCo.Size = new System.Drawing.Size(209, 22);
            this.txtCeCo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Centro de Costo:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnGuardar);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(520, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(178, 52);
            this.panel7.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(30, 14);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(143, 33);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(237, 360);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(698, 52);
            this.panel5.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(237, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(698, 360);
            this.panel2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 350);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(682, 31);
            this.panel3.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblCantRegistros);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(498, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(184, 31);
            this.panel8.TabIndex = 1;
            // 
            // lblCantRegistros
            // 
            this.lblCantRegistros.AutoSize = true;
            this.lblCantRegistros.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRegistros.Location = new System.Drawing.Point(18, 9);
            this.lblCantRegistros.Name = "lblCantRegistros";
            this.lblCantRegistros.Size = new System.Drawing.Size(134, 15);
            this.lblCantRegistros.TabIndex = 0;
            this.lblCantRegistros.Text = "Cantidad de Registros: 0";
            // 
            // RegistroCeCoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 412);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroCeCoView";
            this.Text = "Registro de Centros de Costos";
            this.Load += new System.EventHandler(this.RegistroCeCoView_Load);
            this.panel9.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCeCo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblCantRegistros;
        private System.Windows.Forms.TextBox txtCodCeCo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCodCeCo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodCeCo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCeCo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtFechaReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUsuarioReg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbxActivo;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEliminar;
    }
}