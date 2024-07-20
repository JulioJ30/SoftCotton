namespace SoftCotton.Views.Requerimiento
{
    partial class frmListaRequerimiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaRequerimiento));
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.BtnBuscar = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Panel();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Panel();
            this.ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idRequerimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEmsion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlmacenID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacenDespacho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlmacenReque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacenrequiere = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodusuarioProce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesusuarioProce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodusuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesusuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodusuarioAnulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesusuarioAnulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAnulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvLista
            // 
            this.DgvLista.AllowUserToAddRows = false;
            this.DgvLista.AllowUserToDeleteRows = false;
            this.DgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvLista.BackgroundColor = System.Drawing.Color.White;
            this.DgvLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(131)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvLista.ColumnHeadersHeight = 30;
            this.DgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ver,
            this.idRequerimiento,
            this.fechaEmsion,
            this.fechaAtencion,
            this.AlmacenID,
            this.almacenDespacho,
            this.AlmacenReque,
            this.almacenrequiere,
            this.observacion,
            this.fechaProceso,
            this.CodusuarioProce,
            this.DesusuarioProce,
            this.CodusuarioReg,
            this.DesusuarioReg,
            this.fechaRegistro,
            this.CodusuarioAnulado,
            this.DesusuarioAnulado,
            this.fechaAnulado,
            this.DesEstado,
            this.Estado});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvLista.DefaultCellStyle = dataGridViewCellStyle14;
            this.DgvLista.EnableHeadersVisualStyles = false;
            this.DgvLista.GridColor = System.Drawing.Color.Black;
            this.DgvLista.Location = new System.Drawing.Point(8, 88);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DgvLista.RowHeadersWidth = 5;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvLista.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DgvLista.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvLista.RowTemplate.Height = 30;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(1144, 565);
            this.DgvLista.TabIndex = 300;
            this.DgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellClick);
            this.DgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellContentClick);
            this.DgvLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellDoubleClick);
            this.DgvLista.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvLista_DataBindingComplete);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackgroundImage = global::SoftCotton.Properties.Resources.btn_Buscar_140x50;
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.Location = new System.Drawing.Point(221, 15);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(148, 58);
            this.BtnBuscar.TabIndex = 301;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackgroundImage = global::SoftCotton.Properties.Resources.btn_nuevo_140x50;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Location = new System.Drawing.Point(850, 16);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(148, 58);
            this.btnNuevo.TabIndex = 271;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(98, 47);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(109, 24);
            this.dtpFechaFin.TabIndex = 304;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(98, 20);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(109, 24);
            this.dtpFechaInicio.TabIndex = 305;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 302;
            this.label5.Text = "Fecha Fin: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 19);
            this.label7.TabIndex = 303;
            this.label7.Text = "Fecha Inicio: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.BtnBuscar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Location = new System.Drawing.Point(8, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 81);
            this.groupBox1.TabIndex = 306;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::SoftCotton.Properties.Resources.btn_excel_140x50;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.Location = new System.Drawing.Point(375, 15);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(148, 58);
            this.btnExcel.TabIndex = 302;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackgroundImage = global::SoftCotton.Properties.Resources.btn_cancelar_140x50;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Location = new System.Drawing.Point(1004, 16);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 58);
            this.btnCancelar.TabIndex = 272;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ver
            // 
            this.ver.DataPropertyName = "ver";
            this.ver.HeaderText = "Ver";
            this.ver.Name = "ver";
            this.ver.ReadOnly = true;
            this.ver.Text = "Ver";
            this.ver.UseColumnTextForButtonValue = true;
            this.ver.Width = 70;
            // 
            // idRequerimiento
            // 
            this.idRequerimiento.DataPropertyName = "idRequerimiento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idRequerimiento.DefaultCellStyle = dataGridViewCellStyle2;
            this.idRequerimiento.HeaderText = "Codigo";
            this.idRequerimiento.Name = "idRequerimiento";
            this.idRequerimiento.ReadOnly = true;
            this.idRequerimiento.Width = 80;
            // 
            // fechaEmsion
            // 
            this.fechaEmsion.DataPropertyName = "fechaEmsion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaEmsion.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaEmsion.HeaderText = "Fecha Emsion";
            this.fechaEmsion.Name = "fechaEmsion";
            this.fechaEmsion.ReadOnly = true;
            this.fechaEmsion.Width = 115;
            // 
            // fechaAtencion
            // 
            this.fechaAtencion.DataPropertyName = "fechaAtencion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaAtencion.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaAtencion.HeaderText = "Fecha Atencion";
            this.fechaAtencion.Name = "fechaAtencion";
            this.fechaAtencion.ReadOnly = true;
            this.fechaAtencion.Width = 115;
            // 
            // AlmacenID
            // 
            this.AlmacenID.DataPropertyName = "AlmacenID";
            this.AlmacenID.HeaderText = "AlmacenID";
            this.AlmacenID.Name = "AlmacenID";
            this.AlmacenID.ReadOnly = true;
            this.AlmacenID.Visible = false;
            // 
            // almacenDespacho
            // 
            this.almacenDespacho.DataPropertyName = "almacenDespacho";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.almacenDespacho.DefaultCellStyle = dataGridViewCellStyle5;
            this.almacenDespacho.HeaderText = "Almacen Despacho";
            this.almacenDespacho.Name = "almacenDespacho";
            this.almacenDespacho.ReadOnly = true;
            this.almacenDespacho.Width = 200;
            // 
            // AlmacenReque
            // 
            this.AlmacenReque.DataPropertyName = "AlmacenReque";
            this.AlmacenReque.HeaderText = "AlmacenReque";
            this.AlmacenReque.Name = "AlmacenReque";
            this.AlmacenReque.ReadOnly = true;
            this.AlmacenReque.Visible = false;
            this.AlmacenReque.Width = 180;
            // 
            // almacenrequiere
            // 
            this.almacenrequiere.DataPropertyName = "almacenrequiere";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.almacenrequiere.DefaultCellStyle = dataGridViewCellStyle6;
            this.almacenrequiere.HeaderText = "Almacen Requiere";
            this.almacenrequiere.Name = "almacenrequiere";
            this.almacenrequiere.ReadOnly = true;
            this.almacenrequiere.Width = 200;
            // 
            // observacion
            // 
            this.observacion.DataPropertyName = "observacion";
            this.observacion.HeaderText = "observacion";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 220;
            // 
            // fechaProceso
            // 
            this.fechaProceso.DataPropertyName = "fechaProceso";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaProceso.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechaProceso.HeaderText = "Fecha Procesado";
            this.fechaProceso.Name = "fechaProceso";
            this.fechaProceso.ReadOnly = true;
            this.fechaProceso.Width = 115;
            // 
            // CodusuarioProce
            // 
            this.CodusuarioProce.DataPropertyName = "CodusuarioProce";
            this.CodusuarioProce.HeaderText = "CodusuarioProcesado";
            this.CodusuarioProce.Name = "CodusuarioProce";
            this.CodusuarioProce.ReadOnly = true;
            this.CodusuarioProce.Visible = false;
            // 
            // DesusuarioProce
            // 
            this.DesusuarioProce.DataPropertyName = "DesusuarioProce";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DesusuarioProce.DefaultCellStyle = dataGridViewCellStyle8;
            this.DesusuarioProce.HeaderText = "Usuario Procesado";
            this.DesusuarioProce.Name = "DesusuarioProce";
            this.DesusuarioProce.ReadOnly = true;
            this.DesusuarioProce.Width = 140;
            // 
            // CodusuarioReg
            // 
            this.CodusuarioReg.DataPropertyName = "CodusuarioReg";
            this.CodusuarioReg.HeaderText = "CodusuarioReg";
            this.CodusuarioReg.Name = "CodusuarioReg";
            this.CodusuarioReg.ReadOnly = true;
            this.CodusuarioReg.Visible = false;
            // 
            // DesusuarioReg
            // 
            this.DesusuarioReg.DataPropertyName = "DesusuarioReg";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DesusuarioReg.DefaultCellStyle = dataGridViewCellStyle9;
            this.DesusuarioReg.HeaderText = "Usuario Registro";
            this.DesusuarioReg.Name = "DesusuarioReg";
            this.DesusuarioReg.ReadOnly = true;
            this.DesusuarioReg.Width = 140;
            // 
            // fechaRegistro
            // 
            this.fechaRegistro.DataPropertyName = "fechaRegistro";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistro.DefaultCellStyle = dataGridViewCellStyle10;
            this.fechaRegistro.HeaderText = "Fecha Registro";
            this.fechaRegistro.Name = "fechaRegistro";
            this.fechaRegistro.ReadOnly = true;
            this.fechaRegistro.Width = 115;
            // 
            // CodusuarioAnulado
            // 
            this.CodusuarioAnulado.DataPropertyName = "CodusuarioAnulado";
            this.CodusuarioAnulado.HeaderText = "CodusuarioAnulado";
            this.CodusuarioAnulado.Name = "CodusuarioAnulado";
            this.CodusuarioAnulado.ReadOnly = true;
            this.CodusuarioAnulado.Visible = false;
            // 
            // DesusuarioAnulado
            // 
            this.DesusuarioAnulado.DataPropertyName = "DesusuarioAnulado";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DesusuarioAnulado.DefaultCellStyle = dataGridViewCellStyle11;
            this.DesusuarioAnulado.HeaderText = "Usuario Anulado";
            this.DesusuarioAnulado.Name = "DesusuarioAnulado";
            this.DesusuarioAnulado.ReadOnly = true;
            this.DesusuarioAnulado.Width = 140;
            // 
            // fechaAnulado
            // 
            this.fechaAnulado.DataPropertyName = "fechaAnulado";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaAnulado.DefaultCellStyle = dataGridViewCellStyle12;
            this.fechaAnulado.HeaderText = "Fecha Anulado";
            this.fechaAnulado.Name = "fechaAnulado";
            this.fechaAnulado.ReadOnly = true;
            this.fechaAnulado.Width = 115;
            // 
            // DesEstado
            // 
            this.DesEstado.DataPropertyName = "DesEstado";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DesEstado.DefaultCellStyle = dataGridViewCellStyle13;
            this.DesEstado.HeaderText = "Estado";
            this.DesEstado.Name = "DesEstado";
            this.DesEstado.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Esta";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // frmListaRequerimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1159, 658);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.DgvLista);
            this.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListaRequerimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Requerimientos";
            this.Load += new System.EventHandler(this.frmListaRequerimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.Panel BtnBuscar;
        private System.Windows.Forms.Panel btnNuevo;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel btnExcel;
        private System.Windows.Forms.Panel btnCancelar;
        private System.Windows.Forms.DataGridViewButtonColumn ver;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRequerimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEmsion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAtencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlmacenID;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacenDespacho;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlmacenReque;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacenrequiere;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodusuarioProce;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesusuarioProce;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodusuarioReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesusuarioReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodusuarioAnulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesusuarioAnulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAnulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}