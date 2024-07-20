namespace SoftCotton.Views.Employee
{
    partial class RegistroColaboradorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroColaboradorView));
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNumDoc = new System.Windows.Forms.Label();
            this.txtBuscarNumDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblIDEstadoMensaje = new System.Windows.Forms.Label();
            this.dtpFechaCese = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxArea = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxCargo = new System.Windows.Forms.ComboBox();
            this.lblIDPeriodo = new System.Windows.Forms.Label();
            this.lblMensajeEstado = new System.Windows.Forms.Label();
            this.lblDNIBusqueda = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnBuscarValidar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.cIntIdPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtNumDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIntCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIntArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtFechaCese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIntIdEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtMensajeEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbtnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblCantRegistros = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnNuevoPeriodo = new System.Windows.Forms.Button();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnGuardar);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(766, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(178, 52);
            this.panel7.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(23, 7);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(143, 33);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Fecha Ingreso:";
            // 
            // lblNumDoc
            // 
            this.lblNumDoc.AutoSize = true;
            this.lblNumDoc.Location = new System.Drawing.Point(106, 76);
            this.lblNumDoc.Name = "lblNumDoc";
            this.lblNumDoc.Size = new System.Drawing.Size(0, 13);
            this.lblNumDoc.TabIndex = 15;
            // 
            // txtBuscarNumDoc
            // 
            this.txtBuscarNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarNumDoc.Location = new System.Drawing.Point(6, 17);
            this.txtBuscarNumDoc.MaxLength = 180;
            this.txtBuscarNumDoc.Name = "txtBuscarNumDoc";
            this.txtBuscarNumDoc.Size = new System.Drawing.Size(176, 22);
            this.txtBuscarNumDoc.TabIndex = 5;
            this.txtBuscarNumDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarNumDoc_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "N° Documento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "N° Documento:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnNuevo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(147, 52);
            this.panel4.TabIndex = 22;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(15, 7);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(118, 33);
            this.btnNuevo.TabIndex = 21;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lblNumDoc);
            this.groupBox1.Controls.Add(this.panel9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(293, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNuevoPeriodo);
            this.groupBox3.Controls.Add(this.panel10);
            this.groupBox3.Controls.Add(this.lblIDEstadoMensaje);
            this.groupBox3.Controls.Add(this.dtpFechaCese);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dtpFechaIngreso);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbxArea);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbxCargo);
            this.groupBox3.Controls.Add(this.lblIDPeriodo);
            this.groupBox3.Controls.Add(this.lblMensajeEstado);
            this.groupBox3.Controls.Add(this.lblDNIBusqueda);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(5, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 293);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // lblIDEstadoMensaje
            // 
            this.lblIDEstadoMensaje.AutoSize = true;
            this.lblIDEstadoMensaje.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblIDEstadoMensaje.Location = new System.Drawing.Point(82, 35);
            this.lblIDEstadoMensaje.Name = "lblIDEstadoMensaje";
            this.lblIDEstadoMensaje.Size = new System.Drawing.Size(13, 13);
            this.lblIDEstadoMensaje.TabIndex = 31;
            this.lblIDEstadoMensaje.Text = "0";
            this.lblIDEstadoMensaje.Visible = false;
            // 
            // dtpFechaCese
            // 
            this.dtpFechaCese.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCese.Location = new System.Drawing.Point(101, 207);
            this.dtpFechaCese.Name = "dtpFechaCese";
            this.dtpFechaCese.Size = new System.Drawing.Size(168, 22);
            this.dtpFechaCese.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Fecha Cese:";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(101, 179);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(168, 22);
            this.dtpFechaIngreso.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Área:";
            // 
            // cbxArea
            // 
            this.cbxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxArea.FormattingEnabled = true;
            this.cbxArea.Location = new System.Drawing.Point(101, 152);
            this.cbxArea.Name = "cbxArea";
            this.cbxArea.Size = new System.Drawing.Size(168, 21);
            this.cbxArea.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Cargo:";
            // 
            // cbxCargo
            // 
            this.cbxCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCargo.FormattingEnabled = true;
            this.cbxCargo.Location = new System.Drawing.Point(101, 125);
            this.cbxCargo.Name = "cbxCargo";
            this.cbxCargo.Size = new System.Drawing.Size(168, 21);
            this.cbxCargo.TabIndex = 24;
            // 
            // lblIDPeriodo
            // 
            this.lblIDPeriodo.AutoSize = true;
            this.lblIDPeriodo.Location = new System.Drawing.Point(246, 20);
            this.lblIDPeriodo.Name = "lblIDPeriodo";
            this.lblIDPeriodo.Size = new System.Drawing.Size(13, 13);
            this.lblIDPeriodo.TabIndex = 23;
            this.lblIDPeriodo.Text = "0";
            this.lblIDPeriodo.Visible = false;
            // 
            // lblMensajeEstado
            // 
            this.lblMensajeEstado.AutoSize = true;
            this.lblMensajeEstado.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMensajeEstado.Location = new System.Drawing.Point(98, 36);
            this.lblMensajeEstado.Name = "lblMensajeEstado";
            this.lblMensajeEstado.Size = new System.Drawing.Size(11, 13);
            this.lblMensajeEstado.TabIndex = 22;
            this.lblMensajeEstado.Text = "-";
            // 
            // lblDNIBusqueda
            // 
            this.lblDNIBusqueda.AutoSize = true;
            this.lblDNIBusqueda.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNIBusqueda.Location = new System.Drawing.Point(98, 16);
            this.lblDNIBusqueda.Name = "lblDNIBusqueda";
            this.lblDNIBusqueda.Size = new System.Drawing.Size(15, 17);
            this.lblDNIBusqueda.TabIndex = 21;
            this.lblDNIBusqueda.Text = "0";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.btnBuscarValidar);
            this.panel9.Controls.Add(this.txtBuscarNumDoc);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(5, 20);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(283, 43);
            this.panel9.TabIndex = 27;
            // 
            // btnBuscarValidar
            // 
            this.btnBuscarValidar.Image = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscarValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarValidar.Location = new System.Drawing.Point(188, 16);
            this.btnBuscarValidar.Name = "btnBuscarValidar";
            this.btnBuscarValidar.Size = new System.Drawing.Size(92, 24);
            this.btnBuscarValidar.TabIndex = 26;
            this.btnBuscarValidar.Text = "Validar";
            this.btnBuscarValidar.UseVisualStyleBackColor = true;
            this.btnBuscarValidar.Click += new System.EventHandler(this.btnBuscarValidar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(303, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(641, 371);
            this.panel2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 361);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvListado);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 49);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(625, 309);
            this.panel6.TabIndex = 3;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIntIdPeriodo,
            this.ctxtNumDoc,
            this.ctxtPersona,
            this.cIntCargo,
            this.ctxtCargo,
            this.cIntArea,
            this.ctxtArea,
            this.ctxtFechaIngreso,
            this.ctxtFechaCese,
            this.cIntIdEstado,
            this.ctxtMensajeEstado,
            this.ctxtFechaReg,
            this.ctxtUsuarioReg,
            this.cbtnEditar,
            this.cbtnEliminar});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListado.Size = new System.Drawing.Size(625, 309);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            // 
            // cIntIdPeriodo
            // 
            this.cIntIdPeriodo.HeaderText = "ID Periodo";
            this.cIntIdPeriodo.Name = "cIntIdPeriodo";
            this.cIntIdPeriodo.ReadOnly = true;
            this.cIntIdPeriodo.Visible = false;
            // 
            // ctxtNumDoc
            // 
            this.ctxtNumDoc.HeaderText = "N° Documento";
            this.ctxtNumDoc.Name = "ctxtNumDoc";
            this.ctxtNumDoc.ReadOnly = true;
            this.ctxtNumDoc.Width = 120;
            // 
            // ctxtPersona
            // 
            this.ctxtPersona.HeaderText = "Apellidos y Nombres";
            this.ctxtPersona.Name = "ctxtPersona";
            this.ctxtPersona.ReadOnly = true;
            this.ctxtPersona.Width = 240;
            // 
            // cIntCargo
            // 
            this.cIntCargo.HeaderText = "ID Cargo";
            this.cIntCargo.Name = "cIntCargo";
            this.cIntCargo.ReadOnly = true;
            this.cIntCargo.Visible = false;
            // 
            // ctxtCargo
            // 
            this.ctxtCargo.HeaderText = "Cargo";
            this.ctxtCargo.Name = "ctxtCargo";
            this.ctxtCargo.ReadOnly = true;
            // 
            // cIntArea
            // 
            this.cIntArea.HeaderText = "ID Area";
            this.cIntArea.Name = "cIntArea";
            this.cIntArea.ReadOnly = true;
            this.cIntArea.Visible = false;
            // 
            // ctxtArea
            // 
            this.ctxtArea.HeaderText = "Area";
            this.ctxtArea.Name = "ctxtArea";
            this.ctxtArea.ReadOnly = true;
            // 
            // ctxtFechaIngreso
            // 
            this.ctxtFechaIngreso.HeaderText = "Fecha Ingreso";
            this.ctxtFechaIngreso.Name = "ctxtFechaIngreso";
            this.ctxtFechaIngreso.ReadOnly = true;
            this.ctxtFechaIngreso.Width = 120;
            // 
            // ctxtFechaCese
            // 
            this.ctxtFechaCese.HeaderText = "Fecha Cese";
            this.ctxtFechaCese.Name = "ctxtFechaCese";
            this.ctxtFechaCese.ReadOnly = true;
            this.ctxtFechaCese.Width = 120;
            // 
            // cIntIdEstado
            // 
            this.cIntIdEstado.HeaderText = "ID Estado";
            this.cIntIdEstado.Name = "cIntIdEstado";
            this.cIntIdEstado.ReadOnly = true;
            this.cIntIdEstado.Visible = false;
            // 
            // ctxtMensajeEstado
            // 
            this.ctxtMensajeEstado.HeaderText = "Msje Estado";
            this.ctxtMensajeEstado.Name = "ctxtMensajeEstado";
            this.ctxtMensajeEstado.ReadOnly = true;
            this.ctxtMensajeEstado.Visible = false;
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
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(625, 31);
            this.panel3.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblCantRegistros);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(441, 0);
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
            // panel5
            // 
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 371);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(944, 52);
            this.panel5.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(303, 371);
            this.panel1.TabIndex = 7;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DarkGray;
            this.panel10.Location = new System.Drawing.Point(9, 98);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(271, 1);
            this.panel10.TabIndex = 32;
            // 
            // btnNuevoPeriodo
            // 
            this.btnNuevoPeriodo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevoPeriodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoPeriodo.Location = new System.Drawing.Point(11, 69);
            this.btnNuevoPeriodo.Name = "btnNuevoPeriodo";
            this.btnNuevoPeriodo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNuevoPeriodo.Size = new System.Drawing.Size(137, 23);
            this.btnNuevoPeriodo.TabIndex = 33;
            this.btnNuevoPeriodo.Text = "Nuevo Periodo";
            this.btnNuevoPeriodo.UseVisualStyleBackColor = true;
            this.btnNuevoPeriodo.Click += new System.EventHandler(this.btnNuevoPeriodo_Click);
            // 
            // RegistroColaboradorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 423);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroColaboradorView";
            this.Text = "Registro de Colaboradores";
            this.Load += new System.EventHandler(this.RegistroColaboradorView_Load);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNumDoc;
        private System.Windows.Forms.TextBox txtBuscarNumDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblCantRegistros;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBuscarValidar;
        private System.Windows.Forms.Label lblDNIBusqueda;
        private System.Windows.Forms.Label lblMensajeEstado;
        private System.Windows.Forms.Label lblIDPeriodo;
        private System.Windows.Forms.ComboBox cbxCargo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxArea;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.DateTimePicker dtpFechaCese;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIDEstadoMensaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIntIdPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtNumDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIntCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIntArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtFechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtFechaCese;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIntIdEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtMensajeEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtFechaReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUsuarioReg;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEliminar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnNuevoPeriodo;
        private System.Windows.Forms.Panel panel10;
    }
}