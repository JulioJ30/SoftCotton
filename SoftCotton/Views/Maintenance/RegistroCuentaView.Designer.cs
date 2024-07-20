namespace SoftCotton.Views.Maintenance
{
    partial class RegistroCuentaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroCuentaView));
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cbxTipoCuenta = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.txtCuentaAmarreDebe = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxNivelCuenta = new System.Windows.Forms.ComboBox();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCodTipoDoc = new System.Windows.Forms.Label();
            this.txtCodCuenta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblCantRegistros = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCodCuenta = new System.Windows.Forms.Label();
            this.txtCuentaAmarreHaber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMostrarKardex = new System.Windows.Forms.CheckBox();
            this.dgvTxtCodCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodNivelCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtNivelCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodTipoCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtTipoCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCuentaAmarreDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCuentaAmarreHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChxActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvChxMostrarKardex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbtnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbtnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(416, 59);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(0, 23);
            this.lblCodigo.TabIndex = 34;
            this.lblCodigo.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(626, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 23);
            this.label8.TabIndex = 27;
            this.label8.Text = "Tipo de Cuenta: (*)";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(145, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(135, 25);
            this.btnGuardar.TabIndex = 35;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(4, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(135, 25);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SoftCotton.Properties.Resources.icon_excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(189, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnExcel.Size = new System.Drawing.Size(93, 25);
            this.btnExcel.TabIndex = 40;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // cbxTipoCuenta
            // 
            this.cbxTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoCuenta.Location = new System.Drawing.Point(625, 32);
            this.cbxTipoCuenta.Name = "cbxTipoCuenta";
            this.cbxTipoCuenta.Size = new System.Drawing.Size(207, 31);
            this.cbxTipoCuenta.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvListado);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 162);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(901, 263);
            this.panel2.TabIndex = 20;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTxtCodCuenta,
            this.dgvTxtCuenta,
            this.dgvTxtCodNivelCuenta,
            this.dgvTxtNivelCuenta,
            this.dgvTxtCodTipoCuenta,
            this.dgvTxtTipoCuenta,
            this.dgvTxtCuentaAmarreDebe,
            this.dgvTxtCuentaAmarreHaber,
            this.dgvTxtUsuarioReg,
            this.dgvTxtFechaReg,
            this.dgvChxActivo,
            this.dgvChxMostrarKardex,
            this.cbtnEditar,
            this.cbtnEliminar});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(5, 5);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.RowHeadersWidth = 62;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListado.Size = new System.Drawing.Size(891, 253);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            // 
            // txtCuentaAmarreDebe
            // 
            this.txtCuentaAmarreDebe.Location = new System.Drawing.Point(9, 75);
            this.txtCuentaAmarreDebe.MaxLength = 10;
            this.txtCuentaAmarreDebe.Name = "txtCuentaAmarreDebe";
            this.txtCuentaAmarreDebe.Size = new System.Drawing.Size(123, 29);
            this.txtCuentaAmarreDebe.TabIndex = 25;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnGuardar);
            this.panel9.Controls.Add(this.btnNuevo);
            this.panel9.Controls.Add(this.panel3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(5, 116);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(881, 31);
            this.panel9.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExcel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(586, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(295, 31);
            this.panel3.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "Cuenta Amarre Debe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nivel de Cuenta: (*)";
            // 
            // cbxNivelCuenta
            // 
            this.cbxNivelCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNivelCuenta.Location = new System.Drawing.Point(406, 32);
            this.cbxNivelCuenta.Name = "cbxNivelCuenta";
            this.cbxNivelCuenta.Size = new System.Drawing.Size(213, 31);
            this.cbxNivelCuenta.TabIndex = 15;
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(137, 31);
            this.txtCuenta.MaxLength = 150;
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(263, 29);
            this.txtCuenta.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nombre de Cuenta: (*)";
            // 
            // lblCodTipoDoc
            // 
            this.lblCodTipoDoc.AutoSize = true;
            this.lblCodTipoDoc.Location = new System.Drawing.Point(10, 217);
            this.lblCodTipoDoc.Name = "lblCodTipoDoc";
            this.lblCodTipoDoc.Size = new System.Drawing.Size(0, 23);
            this.lblCodTipoDoc.TabIndex = 12;
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.Location = new System.Drawing.Point(9, 31);
            this.txtCodCuenta.MaxLength = 10;
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(122, 29);
            this.txtCodCuenta.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Código de Cuenta: (*)";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 425);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(901, 30);
            this.panel5.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblCantRegistros);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(715, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(186, 30);
            this.panel7.TabIndex = 1;
            // 
            // lblCantRegistros
            // 
            this.lblCantRegistros.AutoSize = true;
            this.lblCantRegistros.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRegistros.Location = new System.Drawing.Point(12, 6);
            this.lblCantRegistros.Name = "lblCantRegistros";
            this.lblCantRegistros.Size = new System.Drawing.Size(214, 25);
            this.lblCantRegistros.TabIndex = 0;
            this.lblCantRegistros.Text = "Cantidad de Registros: 0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(901, 162);
            this.panel1.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMostrarKardex);
            this.groupBox1.Controls.Add(this.lblCodCuenta);
            this.groupBox1.Controls.Add(this.txtCuentaAmarreHaber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxTipoCuenta);
            this.groupBox1.Controls.Add(this.txtCuentaAmarreDebe);
            this.groupBox1.Controls.Add(this.panel9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxNivelCuenta);
            this.groupBox1.Controls.Add(this.txtCuenta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblCodTipoDoc);
            this.groupBox1.Controls.Add(this.txtCodCuenta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(891, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblCodCuenta
            // 
            this.lblCodCuenta.AutoSize = true;
            this.lblCodCuenta.Location = new System.Drawing.Point(296, 78);
            this.lblCodCuenta.Name = "lblCodCuenta";
            this.lblCodCuenta.Size = new System.Drawing.Size(0, 23);
            this.lblCodCuenta.TabIndex = 39;
            this.lblCodCuenta.Visible = false;
            // 
            // txtCuentaAmarreHaber
            // 
            this.txtCuentaAmarreHaber.Location = new System.Drawing.Point(137, 75);
            this.txtCuentaAmarreHaber.MaxLength = 10;
            this.txtCuentaAmarreHaber.Name = "txtCuentaAmarreHaber";
            this.txtCuentaAmarreHaber.Size = new System.Drawing.Size(123, 29);
            this.txtCuentaAmarreHaber.TabIndex = 30;
            this.txtCuentaAmarreHaber.Leave += new System.EventHandler(this.txtCuentaAmarreHaber_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Cuenta Amarre Haber";
            // 
            // chkMostrarKardex
            // 
            this.chkMostrarKardex.AutoSize = true;
            this.chkMostrarKardex.Location = new System.Drawing.Point(321, 83);
            this.chkMostrarKardex.Name = "chkMostrarKardex";
            this.chkMostrarKardex.Size = new System.Drawing.Size(152, 27);
            this.chkMostrarKardex.TabIndex = 40;
            this.chkMostrarKardex.Text = "Mostrar Kardex";
            this.chkMostrarKardex.UseVisualStyleBackColor = true;
            // 
            // dgvTxtCodCuenta
            // 
            this.dgvTxtCodCuenta.HeaderText = "Cod. Cuenta";
            this.dgvTxtCodCuenta.MinimumWidth = 8;
            this.dgvTxtCodCuenta.Name = "dgvTxtCodCuenta";
            this.dgvTxtCodCuenta.ReadOnly = true;
            this.dgvTxtCodCuenta.Width = 150;
            // 
            // dgvTxtCuenta
            // 
            this.dgvTxtCuenta.HeaderText = "Cuenta";
            this.dgvTxtCuenta.MinimumWidth = 8;
            this.dgvTxtCuenta.Name = "dgvTxtCuenta";
            this.dgvTxtCuenta.ReadOnly = true;
            this.dgvTxtCuenta.Width = 200;
            // 
            // dgvTxtCodNivelCuenta
            // 
            this.dgvTxtCodNivelCuenta.HeaderText = "Cod. Nivel Cuenta";
            this.dgvTxtCodNivelCuenta.MinimumWidth = 8;
            this.dgvTxtCodNivelCuenta.Name = "dgvTxtCodNivelCuenta";
            this.dgvTxtCodNivelCuenta.ReadOnly = true;
            this.dgvTxtCodNivelCuenta.Width = 130;
            // 
            // dgvTxtNivelCuenta
            // 
            this.dgvTxtNivelCuenta.HeaderText = "Nivel Cuenta";
            this.dgvTxtNivelCuenta.MinimumWidth = 8;
            this.dgvTxtNivelCuenta.Name = "dgvTxtNivelCuenta";
            this.dgvTxtNivelCuenta.ReadOnly = true;
            this.dgvTxtNivelCuenta.Width = 130;
            // 
            // dgvTxtCodTipoCuenta
            // 
            this.dgvTxtCodTipoCuenta.HeaderText = "Cod. Tipo Cuenta";
            this.dgvTxtCodTipoCuenta.MinimumWidth = 8;
            this.dgvTxtCodTipoCuenta.Name = "dgvTxtCodTipoCuenta";
            this.dgvTxtCodTipoCuenta.ReadOnly = true;
            this.dgvTxtCodTipoCuenta.Width = 130;
            // 
            // dgvTxtTipoCuenta
            // 
            this.dgvTxtTipoCuenta.HeaderText = "Tipo Cuenta";
            this.dgvTxtTipoCuenta.MinimumWidth = 8;
            this.dgvTxtTipoCuenta.Name = "dgvTxtTipoCuenta";
            this.dgvTxtTipoCuenta.ReadOnly = true;
            this.dgvTxtTipoCuenta.Width = 130;
            // 
            // dgvTxtCuentaAmarreDebe
            // 
            this.dgvTxtCuentaAmarreDebe.HeaderText = "Cuenta Amarre Debe";
            this.dgvTxtCuentaAmarreDebe.MinimumWidth = 8;
            this.dgvTxtCuentaAmarreDebe.Name = "dgvTxtCuentaAmarreDebe";
            this.dgvTxtCuentaAmarreDebe.ReadOnly = true;
            this.dgvTxtCuentaAmarreDebe.Width = 160;
            // 
            // dgvTxtCuentaAmarreHaber
            // 
            this.dgvTxtCuentaAmarreHaber.HeaderText = "Cuenta Amarre Haber";
            this.dgvTxtCuentaAmarreHaber.MinimumWidth = 8;
            this.dgvTxtCuentaAmarreHaber.Name = "dgvTxtCuentaAmarreHaber";
            this.dgvTxtCuentaAmarreHaber.ReadOnly = true;
            this.dgvTxtCuentaAmarreHaber.Width = 160;
            // 
            // dgvTxtUsuarioReg
            // 
            this.dgvTxtUsuarioReg.HeaderText = "Usuario Reg.";
            this.dgvTxtUsuarioReg.MinimumWidth = 8;
            this.dgvTxtUsuarioReg.Name = "dgvTxtUsuarioReg";
            this.dgvTxtUsuarioReg.ReadOnly = true;
            this.dgvTxtUsuarioReg.Width = 150;
            // 
            // dgvTxtFechaReg
            // 
            this.dgvTxtFechaReg.HeaderText = "Fecha Reg.";
            this.dgvTxtFechaReg.MinimumWidth = 8;
            this.dgvTxtFechaReg.Name = "dgvTxtFechaReg";
            this.dgvTxtFechaReg.ReadOnly = true;
            this.dgvTxtFechaReg.Width = 150;
            // 
            // dgvChxActivo
            // 
            this.dgvChxActivo.HeaderText = "Activo";
            this.dgvChxActivo.MinimumWidth = 8;
            this.dgvChxActivo.Name = "dgvChxActivo";
            this.dgvChxActivo.ReadOnly = true;
            this.dgvChxActivo.Width = 150;
            // 
            // dgvChxMostrarKardex
            // 
            this.dgvChxMostrarKardex.HeaderText = "Mostrar Kardex";
            this.dgvChxMostrarKardex.MinimumWidth = 8;
            this.dgvChxMostrarKardex.Name = "dgvChxMostrarKardex";
            this.dgvChxMostrarKardex.ReadOnly = true;
            this.dgvChxMostrarKardex.Width = 150;
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
            this.cbtnEditar.MinimumWidth = 8;
            this.cbtnEditar.Name = "cbtnEditar";
            this.cbtnEditar.ReadOnly = true;
            this.cbtnEditar.Text = "Editar";
            this.cbtnEditar.UseColumnTextForButtonValue = true;
            this.cbtnEditar.Width = 150;
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
            this.cbtnEliminar.MinimumWidth = 8;
            this.cbtnEliminar.Name = "cbtnEliminar";
            this.cbtnEliminar.ReadOnly = true;
            this.cbtnEliminar.Text = "Eliminar";
            this.cbtnEliminar.UseColumnTextForButtonValue = true;
            this.cbtnEliminar.Width = 150;
            // 
            // RegistroCuentaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(901, 455);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroCuentaView";
            this.Text = "Registro de Cuenta";
            this.Load += new System.EventHandler(this.RegistroCuentaView_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ComboBox cbxTipoCuenta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.TextBox txtCuentaAmarreDebe;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxNivelCuenta;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCodTipoDoc;
        private System.Windows.Forms.TextBox txtCodCuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblCantRegistros;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCuentaAmarreHaber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCodCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodNivelCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtNivelCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodTipoCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtTipoCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCuentaAmarreDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCuentaAmarreHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtUsuarioReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtFechaReg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvChxActivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvChxMostrarKardex;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEliminar;
        private System.Windows.Forms.CheckBox chkMostrarKardex;
    }
}