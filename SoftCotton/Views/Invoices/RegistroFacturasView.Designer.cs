namespace SoftCotton.Views.Invoices
{
    partial class RegistroFacturasView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroFacturasView));
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListadoDetalle = new System.Windows.Forms.DataGridView();
            this.dgvTxtItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtRUC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtSecuenciaBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtGRIdEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtGRSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtGRNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtGRSecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtGRTipoOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecIGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblIGV = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaEmision = new System.Windows.Forms.DateTimePicker();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.cbTipoCambio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.gpTipoComprobante = new System.Windows.Forms.GroupBox();
            this.btnBuscarNotaCredito = new System.Windows.Forms.Button();
            this.lblNotaCredito = new System.Windows.Forms.Label();
            this.txtSerieNotaCredito = new System.Windows.Forms.TextBox();
            this.txtNumeroNotaCredito = new System.Windows.Forms.TextBox();
            this.cboTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblRS = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblRUC = new System.Windows.Forms.Label();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cbxTipoMoneda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOp = new System.Windows.Forms.TextBox();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDetalle)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpTipoComprobante.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 173);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(965, 334);
            this.panel5.TabIndex = 66;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvListadoDetalle);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(965, 334);
            this.panel2.TabIndex = 0;
            // 
            // dgvListadoDetalle
            // 
            this.dgvListadoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTxtItem,
            this.dgvTxtSerie,
            this.dgvTxtRUC,
            this.dgvTxtNumero,
            this.dgvTxtSecuenciaBD,
            this.dgvTxtGRIdEmpresa,
            this.dgvTxtGRSerie,
            this.dgvTxtGRNumero,
            this.dgvTxtGRSecuencia,
            this.dgvTxtGRTipoOrden,
            this.dgvTxtCodigo,
            this.dgvTxtDescripcion,
            this.dgvTxtCodUM,
            this.dgvDecCantidad,
            this.dgvDecPrecioUnitario,
            this.dgvDecIGV});
            this.dgvListadoDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoDetalle.Location = new System.Drawing.Point(3, 3);
            this.dgvListadoDetalle.Name = "dgvListadoDetalle";
            this.dgvListadoDetalle.RowHeadersWidth = 62;
            this.dgvListadoDetalle.Size = new System.Drawing.Size(959, 229);
            this.dgvListadoDetalle.TabIndex = 0;
            this.dgvListadoDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvListadoDetalle_CellValidating);
            this.dgvListadoDetalle.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoDetalle_CellValueChanged);
            this.dgvListadoDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvListadoDetalle_EditingControlShowing);
            this.dgvListadoDetalle.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvListadoDetalle_RowsAdded);
            this.dgvListadoDetalle.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvListadoDetalle_UserDeletedRow);
            this.dgvListadoDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListadoDetalle_KeyDown);
            // 
            // dgvTxtItem
            // 
            this.dgvTxtItem.DataPropertyName = "bdItem";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvTxtItem.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTxtItem.HeaderText = "Item";
            this.dgvTxtItem.MinimumWidth = 8;
            this.dgvTxtItem.Name = "dgvTxtItem";
            this.dgvTxtItem.Width = 50;
            // 
            // dgvTxtSerie
            // 
            this.dgvTxtSerie.HeaderText = "Serie";
            this.dgvTxtSerie.MinimumWidth = 8;
            this.dgvTxtSerie.Name = "dgvTxtSerie";
            this.dgvTxtSerie.Visible = false;
            this.dgvTxtSerie.Width = 150;
            // 
            // dgvTxtRUC
            // 
            this.dgvTxtRUC.HeaderText = "RUC";
            this.dgvTxtRUC.MinimumWidth = 8;
            this.dgvTxtRUC.Name = "dgvTxtRUC";
            this.dgvTxtRUC.Width = 150;
            // 
            // dgvTxtNumero
            // 
            this.dgvTxtNumero.HeaderText = "Numero";
            this.dgvTxtNumero.MinimumWidth = 8;
            this.dgvTxtNumero.Name = "dgvTxtNumero";
            this.dgvTxtNumero.Visible = false;
            this.dgvTxtNumero.Width = 150;
            // 
            // dgvTxtSecuenciaBD
            // 
            this.dgvTxtSecuenciaBD.HeaderText = "Secuencia";
            this.dgvTxtSecuenciaBD.MinimumWidth = 8;
            this.dgvTxtSecuenciaBD.Name = "dgvTxtSecuenciaBD";
            this.dgvTxtSecuenciaBD.ReadOnly = true;
            this.dgvTxtSecuenciaBD.Visible = false;
            this.dgvTxtSecuenciaBD.Width = 150;
            // 
            // dgvTxtGRIdEmpresa
            // 
            this.dgvTxtGRIdEmpresa.HeaderText = "ID Empresa";
            this.dgvTxtGRIdEmpresa.MinimumWidth = 8;
            this.dgvTxtGRIdEmpresa.Name = "dgvTxtGRIdEmpresa";
            this.dgvTxtGRIdEmpresa.Visible = false;
            this.dgvTxtGRIdEmpresa.Width = 150;
            // 
            // dgvTxtGRSerie
            // 
            this.dgvTxtGRSerie.HeaderText = "Serie";
            this.dgvTxtGRSerie.MinimumWidth = 8;
            this.dgvTxtGRSerie.Name = "dgvTxtGRSerie";
            this.dgvTxtGRSerie.Width = 150;
            // 
            // dgvTxtGRNumero
            // 
            this.dgvTxtGRNumero.HeaderText = "Numero";
            this.dgvTxtGRNumero.MinimumWidth = 8;
            this.dgvTxtGRNumero.Name = "dgvTxtGRNumero";
            this.dgvTxtGRNumero.Width = 150;
            // 
            // dgvTxtGRSecuencia
            // 
            this.dgvTxtGRSecuencia.HeaderText = "Secuencia";
            this.dgvTxtGRSecuencia.MinimumWidth = 8;
            this.dgvTxtGRSecuencia.Name = "dgvTxtGRSecuencia";
            this.dgvTxtGRSecuencia.Width = 150;
            // 
            // dgvTxtGRTipoOrden
            // 
            this.dgvTxtGRTipoOrden.HeaderText = "Tipo Orden";
            this.dgvTxtGRTipoOrden.MinimumWidth = 8;
            this.dgvTxtGRTipoOrden.Name = "dgvTxtGRTipoOrden";
            this.dgvTxtGRTipoOrden.ReadOnly = true;
            this.dgvTxtGRTipoOrden.Width = 150;
            // 
            // dgvTxtCodigo
            // 
            this.dgvTxtCodigo.HeaderText = "Código";
            this.dgvTxtCodigo.MinimumWidth = 8;
            this.dgvTxtCodigo.Name = "dgvTxtCodigo";
            this.dgvTxtCodigo.Width = 150;
            // 
            // dgvTxtDescripcion
            // 
            this.dgvTxtDescripcion.HeaderText = "Descripción";
            this.dgvTxtDescripcion.MinimumWidth = 8;
            this.dgvTxtDescripcion.Name = "dgvTxtDescripcion";
            this.dgvTxtDescripcion.Width = 150;
            // 
            // dgvTxtCodUM
            // 
            this.dgvTxtCodUM.HeaderText = "UM";
            this.dgvTxtCodUM.MinimumWidth = 8;
            this.dgvTxtCodUM.Name = "dgvTxtCodUM";
            this.dgvTxtCodUM.Width = 150;
            // 
            // dgvDecCantidad
            // 
            this.dgvDecCantidad.HeaderText = "Cantidad";
            this.dgvDecCantidad.MinimumWidth = 8;
            this.dgvDecCantidad.Name = "dgvDecCantidad";
            this.dgvDecCantidad.Width = 150;
            // 
            // dgvDecPrecioUnitario
            // 
            this.dgvDecPrecioUnitario.HeaderText = "Precio Unitario";
            this.dgvDecPrecioUnitario.MinimumWidth = 8;
            this.dgvDecPrecioUnitario.Name = "dgvDecPrecioUnitario";
            this.dgvDecPrecioUnitario.Width = 150;
            // 
            // dgvDecIGV
            // 
            this.dgvDecIGV.HeaderText = "IGV";
            this.dgvDecIGV.MinimumWidth = 8;
            this.dgvDecIGV.Name = "dgvDecIGV";
            this.dgvDecIGV.Width = 150;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 232);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(959, 99);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.lblSubTotal);
            this.panel4.Controls.Add(this.lblIGV);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(284, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(670, 46);
            this.panel4.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(576, 4);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(88, 23);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(206, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "SUBTOTAL:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(532, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 23);
            this.label16.TabIndex = 4;
            this.label16.Text = "TOTAL:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(272, 4);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(88, 23);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "0.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIGV
            // 
            this.lblIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIGV.Location = new System.Drawing.Point(423, 4);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(88, 23);
            this.lblIGV.TabIndex = 3;
            this.lblIGV.Text = "0.00";
            this.lblIGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(385, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 23);
            this.label11.TabIndex = 2;
            this.label11.Text = "I.G.V.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnGuardar);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(5, 51);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(4);
            this.panel6.Size = new System.Drawing.Size(949, 43);
            this.panel6.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(807, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(138, 35);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serie y Número:";
            // 
            // dtpFechaEmision
            // 
            this.dtpFechaEmision.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmision.Location = new System.Drawing.Point(717, 18);
            this.dtpFechaEmision.Name = "dtpFechaEmision";
            this.dtpFechaEmision.Size = new System.Drawing.Size(222, 25);
            this.dtpFechaEmision.TabIndex = 2;
            this.dtpFechaEmision.ValueChanged += new System.EventHandler(this.dtpFechaEmision_ValueChanged);
            // 
            // txtSerie
            // 
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(79, 38);
            this.txtSerie.MaxLength = 4;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(32, 25);
            this.txtSerie.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(643, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Fecha Emisión:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(965, 173);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnCambiar);
            this.groupBox1.Controls.Add(this.cbTipoCambio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Controls.Add(this.gpTipoComprobante);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAnio);
            this.groupBox1.Controls.Add(this.txtMes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.cbxTipoMoneda);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.dtpFechaEmision);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(957, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "REGISTRO";
            // 
            // btnCambiar
            // 
            this.btnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiar.Location = new System.Drawing.Point(859, 71);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnCambiar.Size = new System.Drawing.Size(80, 25);
            this.btnCambiar.TabIndex = 15;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // cbTipoCambio
            // 
            this.cbTipoCambio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCambio.FormattingEnabled = true;
            this.cbTipoCambio.Location = new System.Drawing.Point(717, 69);
            this.cbTipoCambio.Name = "cbTipoCambio";
            this.cbTipoCambio.Size = new System.Drawing.Size(140, 27);
            this.cbTipoCambio.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Enabled = false;
            this.txtObservaciones.Location = new System.Drawing.Point(92, 135);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(307, 26);
            this.txtObservaciones.TabIndex = 13;
            // 
            // gpTipoComprobante
            // 
            this.gpTipoComprobante.Controls.Add(this.btnBuscarNotaCredito);
            this.gpTipoComprobante.Controls.Add(this.lblNotaCredito);
            this.gpTipoComprobante.Controls.Add(this.txtSerieNotaCredito);
            this.gpTipoComprobante.Controls.Add(this.txtNumeroNotaCredito);
            this.gpTipoComprobante.Controls.Add(this.cboTipoComprobante);
            this.gpTipoComprobante.Location = new System.Drawing.Point(13, 14);
            this.gpTipoComprobante.Name = "gpTipoComprobante";
            this.gpTipoComprobante.Size = new System.Drawing.Size(619, 41);
            this.gpTipoComprobante.TabIndex = 12;
            this.gpTipoComprobante.TabStop = false;
            this.gpTipoComprobante.Text = "Tipo Comprobante";
            // 
            // btnBuscarNotaCredito
            // 
            this.btnBuscarNotaCredito.BackgroundImage = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscarNotaCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBuscarNotaCredito.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarNotaCredito.Location = new System.Drawing.Point(497, 15);
            this.btnBuscarNotaCredito.Name = "btnBuscarNotaCredito";
            this.btnBuscarNotaCredito.Size = new System.Drawing.Size(115, 22);
            this.btnBuscarNotaCredito.TabIndex = 9;
            this.btnBuscarNotaCredito.Text = "Buscar Nota Credito";
            this.btnBuscarNotaCredito.UseVisualStyleBackColor = true;
            this.btnBuscarNotaCredito.Visible = false;
            this.btnBuscarNotaCredito.Click += new System.EventHandler(this.btnBuscarNotaCredito_Click);
            // 
            // lblNotaCredito
            // 
            this.lblNotaCredito.AutoSize = true;
            this.lblNotaCredito.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotaCredito.Location = new System.Drawing.Point(214, 18);
            this.lblNotaCredito.Name = "lblNotaCredito";
            this.lblNotaCredito.Size = new System.Drawing.Size(189, 19);
            this.lblNotaCredito.TabIndex = 6;
            this.lblNotaCredito.Text = "Serie y Número Nota Credito:";
            this.lblNotaCredito.Visible = false;
            // 
            // txtSerieNotaCredito
            // 
            this.txtSerieNotaCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerieNotaCredito.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerieNotaCredito.Location = new System.Drawing.Point(357, 15);
            this.txtSerieNotaCredito.MaxLength = 4;
            this.txtSerieNotaCredito.Name = "txtSerieNotaCredito";
            this.txtSerieNotaCredito.Size = new System.Drawing.Size(32, 25);
            this.txtSerieNotaCredito.TabIndex = 7;
            this.txtSerieNotaCredito.Visible = false;
            // 
            // txtNumeroNotaCredito
            // 
            this.txtNumeroNotaCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroNotaCredito.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroNotaCredito.Location = new System.Drawing.Point(392, 15);
            this.txtNumeroNotaCredito.MaxLength = 6;
            this.txtNumeroNotaCredito.Name = "txtNumeroNotaCredito";
            this.txtNumeroNotaCredito.Size = new System.Drawing.Size(99, 25);
            this.txtNumeroNotaCredito.TabIndex = 8;
            this.txtNumeroNotaCredito.Visible = false;
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.FormattingEnabled = true;
            this.cboTipoComprobante.Location = new System.Drawing.Point(6, 15);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(156, 27);
            this.cboTipoComprobante.TabIndex = 0;
            this.cboTipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cboTipoComprobante_SelectedIndexChanged);
            this.cboTipoComprobante.SelectionChangeCommitted += new System.EventHandler(this.cboTipoComprobante_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(638, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Año-Mes (Contable)";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(737, 95);
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(116, 26);
            this.txtAnio.TabIndex = 10;
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(859, 95);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(80, 26);
            this.txtMes.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(638, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de Cambio:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.txtSerie);
            this.groupBox2.Controls.Add(this.txtNumero);
            this.groupBox2.Controls.Add(this.lblRS);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lblRUC);
            this.groupBox2.Controls.Add(this.btnBuscarProveedor);
            this.groupBox2.Location = new System.Drawing.Point(13, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 74);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda y Registro:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(216, 36);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 26);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar Factura";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(114, 38);
            this.txtNumero.MaxLength = 6;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(99, 25);
            this.txtNumero.TabIndex = 5;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // lblRS
            // 
            this.lblRS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRS.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRS.Location = new System.Drawing.Point(216, 15);
            this.lblRS.Name = "lblRS";
            this.lblRS.Size = new System.Drawing.Size(374, 20);
            this.lblRS.TabIndex = 2;
            this.lblRS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(27, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 19);
            this.label17.TabIndex = 0;
            this.label17.Text = "RUC:";
            // 
            // lblRUC
            // 
            this.lblRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRUC.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRUC.Location = new System.Drawing.Point(79, 15);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(134, 20);
            this.lblRUC.TabIndex = 1;
            this.lblRUC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.BackgroundImage = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscarProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProveedor.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProveedor.Location = new System.Drawing.Point(54, 14);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(22, 22);
            this.btnBuscarProveedor.TabIndex = 1;
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SoftCotton.Properties.Resources.icon_eliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(519, 134);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnEliminar.Size = new System.Drawing.Size(113, 25);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cbxTipoMoneda
            // 
            this.cbxTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoMoneda.FormattingEnabled = true;
            this.cbxTipoMoneda.Location = new System.Drawing.Point(717, 43);
            this.cbxTipoMoneda.Name = "cbxTipoMoneda";
            this.cbxTipoMoneda.Size = new System.Drawing.Size(222, 27);
            this.cbxTipoMoneda.TabIndex = 4;
            this.cbxTipoMoneda.SelectedIndexChanged += new System.EventHandler(this.cbxTipoMoneda_SelectedIndexChanged);
            this.cbxTipoMoneda.SelectionChangeCommitted += new System.EventHandler(this.cbxTipoMoneda_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(638, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de Moneda:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(405, 134);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(113, 25);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Nuevo OC";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnNuevo.Leave += new System.EventHandler(this.btnNuevo_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(638, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "OP";
            // 
            // txtOp
            // 
            this.txtOp.Location = new System.Drawing.Point(717, 134);
            this.txtOp.MaxLength = 1000;
            this.txtOp.Name = "txtOp";
            this.txtOp.Size = new System.Drawing.Size(222, 26);
            this.txtOp.TabIndex = 17;
            // 
            // RegistroFacturasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(965, 507);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroFacturasView";
            this.Text = "Registro de Facturas";
            this.Load += new System.EventHandler(this.RegistroFacturasView_Load);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDetalle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpTipoComprobante.ResumeLayout(false);
            this.gpTipoComprobante.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoDetalle;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaEmision;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblRS;
        private System.Windows.Forms.Label lblRUC;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTipoMoneda;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblIGV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.GroupBox gpTipoComprobante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.ComboBox cboTipoComprobante;
        private System.Windows.Forms.Label lblNotaCredito;
        private System.Windows.Forms.TextBox txtSerieNotaCredito;
        private System.Windows.Forms.TextBox txtNumeroNotaCredito;
        private System.Windows.Forms.Button btnBuscarNotaCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtRUC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtSecuenciaBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtGRIdEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtGRSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtGRNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtGRSecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtGRTipoOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecIGV;
        private System.Windows.Forms.ComboBox cbTipoCambio;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.TextBox txtOp;
        private System.Windows.Forms.Label label5;
    }
}