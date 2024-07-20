namespace SoftCotton.Views.ServiceOrder
{
    partial class FirmantesOSView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmantesOSView));
            this.lblIdUsuarioReg = new System.Windows.Forms.Label();
            this.lblIdTipoAprobacion = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtRutaImagen = new System.Windows.Forms.TextBox();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblIdUsuarioUpdate = new System.Windows.Forms.Label();
            this.cbxTipoAprobacion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.cIntIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIntIdTipoAprobacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTxtColaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTxtTipoAprobacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIntNivelAprobacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTxtRutaImgFirma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbtnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbtnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblCantRegistros = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIdUsuarioReg
            // 
            this.lblIdUsuarioReg.AutoSize = true;
            this.lblIdUsuarioReg.Location = new System.Drawing.Point(96, 28);
            this.lblIdUsuarioReg.Name = "lblIdUsuarioReg";
            this.lblIdUsuarioReg.Size = new System.Drawing.Size(13, 13);
            this.lblIdUsuarioReg.TabIndex = 56;
            this.lblIdUsuarioReg.Text = "0";
            this.lblIdUsuarioReg.Visible = false;
            // 
            // lblIdTipoAprobacion
            // 
            this.lblIdTipoAprobacion.AutoSize = true;
            this.lblIdTipoAprobacion.Location = new System.Drawing.Point(790, 52);
            this.lblIdTipoAprobacion.Name = "lblIdTipoAprobacion";
            this.lblIdTipoAprobacion.Size = new System.Drawing.Size(13, 13);
            this.lblIdTipoAprobacion.TabIndex = 55;
            this.lblIdTipoAprobacion.Text = "0";
            this.lblIdTipoAprobacion.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(8, 82);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(118, 27);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtRutaImagen
            // 
            this.txtRutaImagen.Location = new System.Drawing.Point(115, 49);
            this.txtRutaImagen.MaxLength = 300;
            this.txtRutaImagen.Name = "txtRutaImagen";
            this.txtRutaImagen.Size = new System.Drawing.Size(322, 22);
            this.txtRutaImagen.TabIndex = 20;
            // 
            // lblColaborador
            // 
            this.lblColaborador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColaborador.Location = new System.Drawing.Point(142, 24);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.Size = new System.Drawing.Size(295, 21);
            this.lblColaborador.TabIndex = 52;
            this.lblColaborador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 12);
            this.label6.TabIndex = 51;
            this.label6.Text = "RUTA IMAGEN FIRMA:";
            // 
            // lblIdUsuarioUpdate
            // 
            this.lblIdUsuarioUpdate.AutoSize = true;
            this.lblIdUsuarioUpdate.Location = new System.Drawing.Point(442, 28);
            this.lblIdUsuarioUpdate.Name = "lblIdUsuarioUpdate";
            this.lblIdUsuarioUpdate.Size = new System.Drawing.Size(13, 13);
            this.lblIdUsuarioUpdate.TabIndex = 48;
            this.lblIdUsuarioUpdate.Text = "0";
            this.lblIdUsuarioUpdate.Visible = false;
            // 
            // cbxTipoAprobacion
            // 
            this.cbxTipoAprobacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoAprobacion.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoAprobacion.FormattingEnabled = true;
            this.cbxTipoAprobacion.Location = new System.Drawing.Point(580, 25);
            this.cbxTipoAprobacion.Name = "cbxTipoAprobacion";
            this.cbxTipoAprobacion.Size = new System.Drawing.Size(223, 20);
            this.cbxTipoAprobacion.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(477, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 12);
            this.label5.TabIndex = 46;
            this.label5.Text = "TIPO DE APROBACIÓN:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 43;
            this.label4.Text = "USUARIO:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIdUsuarioReg);
            this.groupBox1.Controls.Add(this.lblIdTipoAprobacion);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.txtRutaImagen);
            this.groupBox1.Controls.Add(this.lblColaborador);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblIdUsuarioUpdate);
            this.groupBox1.Controls.Add(this.cbxTipoAprobacion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnBuscarUsuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(913, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro ";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(135, 82);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(143, 27);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.BackgroundImage = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarUsuario.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarUsuario.Location = new System.Drawing.Point(115, 24);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(21, 21);
            this.btnBuscarUsuario.TabIndex = 10;
            this.btnBuscarUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(923, 127);
            this.panel1.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(923, 317);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvListado);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 18);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(917, 296);
            this.panel6.TabIndex = 3;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIntIdUsuario,
            this.cIntIdTipoAprobacion,
            this.cTxtColaborador,
            this.cTxtTipoAprobacion,
            this.cIntNivelAprobacion,
            this.cTxtRutaImgFirma,
            this.ctxtUsuarioReg,
            this.ctxtFechaReg,
            this.cbxActivo,
            this.cbtnEditar,
            this.cbtnEliminar});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListado.Size = new System.Drawing.Size(917, 272);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            // 
            // cIntIdUsuario
            // 
            this.cIntIdUsuario.HeaderText = "ID Usuario";
            this.cIntIdUsuario.Name = "cIntIdUsuario";
            this.cIntIdUsuario.ReadOnly = true;
            this.cIntIdUsuario.Visible = false;
            this.cIntIdUsuario.Width = 120;
            // 
            // cIntIdTipoAprobacion
            // 
            this.cIntIdTipoAprobacion.HeaderText = "ID Tipo Aprobacion";
            this.cIntIdTipoAprobacion.Name = "cIntIdTipoAprobacion";
            this.cIntIdTipoAprobacion.ReadOnly = true;
            this.cIntIdTipoAprobacion.Visible = false;
            this.cIntIdTipoAprobacion.Width = 150;
            // 
            // cTxtColaborador
            // 
            this.cTxtColaborador.HeaderText = "Colaborador";
            this.cTxtColaborador.Name = "cTxtColaborador";
            this.cTxtColaborador.ReadOnly = true;
            this.cTxtColaborador.Width = 200;
            // 
            // cTxtTipoAprobacion
            // 
            this.cTxtTipoAprobacion.HeaderText = "Tipo Aprobación";
            this.cTxtTipoAprobacion.Name = "cTxtTipoAprobacion";
            this.cTxtTipoAprobacion.ReadOnly = true;
            this.cTxtTipoAprobacion.Width = 150;
            // 
            // cIntNivelAprobacion
            // 
            this.cIntNivelAprobacion.HeaderText = "Nivel Aprobación";
            this.cIntNivelAprobacion.Name = "cIntNivelAprobacion";
            this.cIntNivelAprobacion.ReadOnly = true;
            this.cIntNivelAprobacion.Width = 150;
            // 
            // cTxtRutaImgFirma
            // 
            this.cTxtRutaImgFirma.HeaderText = "Ruta Imagen Firma";
            this.cTxtRutaImgFirma.Name = "cTxtRutaImgFirma";
            this.cTxtRutaImgFirma.ReadOnly = true;
            this.cTxtRutaImgFirma.Width = 200;
            // 
            // ctxtUsuarioReg
            // 
            this.ctxtUsuarioReg.HeaderText = "Usuario Modifica";
            this.ctxtUsuarioReg.Name = "ctxtUsuarioReg";
            this.ctxtUsuarioReg.ReadOnly = true;
            this.ctxtUsuarioReg.Width = 120;
            // 
            // ctxtFechaReg
            // 
            this.ctxtFechaReg.HeaderText = "Fecha Modifica";
            this.ctxtFechaReg.Name = "ctxtFechaReg";
            this.ctxtFechaReg.ReadOnly = true;
            this.ctxtFechaReg.Width = 120;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(917, 24);
            this.panel3.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblCantRegistros);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(722, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(195, 24);
            this.panel8.TabIndex = 1;
            // 
            // lblCantRegistros
            // 
            this.lblCantRegistros.AutoSize = true;
            this.lblCantRegistros.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRegistros.Location = new System.Drawing.Point(36, 7);
            this.lblCantRegistros.Name = "lblCantRegistros";
            this.lblCantRegistros.Size = new System.Drawing.Size(134, 15);
            this.lblCantRegistros.TabIndex = 0;
            this.lblCantRegistros.Text = "Cantidad de Registros: 0";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 132);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(923, 317);
            this.panel4.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(933, 454);
            this.panel2.TabIndex = 24;
            // 
            // FirmantesOSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 454);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FirmantesOSView";
            this.Text = "Firmantes de Orden de Servicio";
            this.Load += new System.EventHandler(this.FirmantesOSView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIdUsuarioReg;
        private System.Windows.Forms.Label lblIdTipoAprobacion;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtRutaImagen;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIdUsuarioUpdate;
        private System.Windows.Forms.ComboBox cbxTipoAprobacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIntIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIntIdTipoAprobacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtColaborador;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtTipoAprobacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIntNivelAprobacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtRutaImgFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUsuarioReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtFechaReg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbxActivo;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEliminar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblCantRegistros;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
    }
}