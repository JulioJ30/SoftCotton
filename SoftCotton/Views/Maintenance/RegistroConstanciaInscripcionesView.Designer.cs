﻿namespace SoftCotton.Views.Maintenance
{
    partial class RegistroConstanciaInscripcionesView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConstancia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCantRegistros = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblid = new System.Windows.Forms.Label();
            this.idConstancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constanciaInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbtnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(237, 545);
            this.panel1.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblid);
            this.groupBox1.Controls.Add(this.txtConstancia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(227, 488);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro ";
            // 
            // txtConstancia
            // 
            this.txtConstancia.Location = new System.Drawing.Point(10, 49);
            this.txtConstancia.MaxLength = 20;
            this.txtConstancia.Name = "txtConstancia";
            this.txtConstancia.Size = new System.Drawing.Size(209, 26);
            this.txtConstancia.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Constancia de Inscripción";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnNuevo);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(5, 493);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(227, 47);
            this.panel9.TabIndex = 1;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(7, 9);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(118, 33);
            this.btnNuevo.TabIndex = 17;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(237, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(890, 545);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvListado);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 53);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(884, 489);
            this.panel6.TabIndex = 3;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idConstancia,
            this.constanciaInscripcion,
            this.ctxtFechaReg,
            this.ctxtUsuarioReg,
            this.cbxActivo,
            this.cbtnEditar});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListado.Size = new System.Drawing.Size(884, 489);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCantRegistros);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(884, 31);
            this.panel3.TabIndex = 1;
            // 
            // lblCantRegistros
            // 
            this.lblCantRegistros.AutoSize = true;
            this.lblCantRegistros.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRegistros.Location = new System.Drawing.Point(643, 6);
            this.lblCantRegistros.Name = "lblCantRegistros";
            this.lblCantRegistros.Size = new System.Drawing.Size(214, 25);
            this.lblCantRegistros.TabIndex = 0;
            this.lblCantRegistros.Text = "Cantidad de Registros: 0";
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(700, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(184, 31);
            this.panel8.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(237, 493);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(890, 52);
            this.panel5.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnGuardar);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(712, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(178, 52);
            this.panel7.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(28, 14);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(143, 33);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(37, 124);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(18, 20);
            this.lblid.TabIndex = 2;
            this.lblid.Text = "0";
            this.lblid.Visible = false;
            // 
            // idConstancia
            // 
            this.idConstancia.HeaderText = "ID Constancia";
            this.idConstancia.Name = "idConstancia";
            this.idConstancia.ReadOnly = true;
            this.idConstancia.Width = 150;
            // 
            // constanciaInscripcion
            // 
            this.constanciaInscripcion.HeaderText = "Constancia Inscripción";
            this.constanciaInscripcion.Name = "constanciaInscripcion";
            this.constanciaInscripcion.ReadOnly = true;
            this.constanciaInscripcion.Width = 220;
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
            // RegistroConstanciaInscripcionesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 545);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Name = "RegistroConstanciaInscripcionesView";
            this.Text = "Registro Constancia de Inscripciones";
            this.Load += new System.EventHandler(this.RegistroConstanciaInscripcionesView_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConstancia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblCantRegistros;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConstancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn constanciaInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtFechaReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUsuarioReg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbxActivo;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEditar;
    }
}