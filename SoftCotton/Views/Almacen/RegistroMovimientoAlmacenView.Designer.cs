namespace SoftCotton.Views.Almacen
{
    partial class RegistroMovimientoAlmacenView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lnkCambiar = new System.Windows.Forms.LinkLabel();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.splitContenido = new System.Windows.Forms.SplitContainer();
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            this.colBGuia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBFechaGuia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBDestinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBDespachado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBIngresado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBusquedaPie = new System.Windows.Forms.Panel();
            this.lblAyudaBusqueda = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tlpBusqueda = new System.Windows.Forms.TableLayoutPanel();
            this.dtpGuiaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpGuiaHasta = new System.Windows.Forms.DateTimePicker();
            this.cbxNivel = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblEstadoBusqueda = new System.Windows.Forms.Label();
            this.lblPaso1 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colDGuia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDQuitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblDetalleVacio = new System.Windows.Forms.Label();
            this.lblPaso2 = new System.Windows.Forms.Label();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.tmrBusqueda = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.tlpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContenido)).BeginInit();
            this.splitContenido.Panel1.SuspendLayout();
            this.splitContenido.Panel2.SuspendLayout();
            this.splitContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            this.pnlBusquedaPie.SuspendLayout();
            this.tlpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlEncabezado
            //
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(95)))), ((int)(((byte)(158)))));
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1280, 64);
            this.pnlEncabezado.TabIndex = 0;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(243)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 38);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Subtítulo";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Nuevo movimiento";
            //
            // pnlDatos
            //
            this.pnlDatos.BackColor = System.Drawing.Color.White;
            this.pnlDatos.Controls.Add(this.tlpDatos);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Padding = new System.Windows.Forms.Padding(14, 10, 14, 8);
            this.pnlDatos.Size = new System.Drawing.Size(1280, 128);
            this.pnlDatos.TabIndex = 1;
            //
            // tlpDatos
            //
            this.tlpDatos.ColumnCount = 3;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDatos.Controls.Add(this.lblAlmacen, 0, 0);
            this.tlpDatos.Controls.Add(this.lblFecha, 1, 0);
            this.tlpDatos.Controls.Add(this.cbxAlmacen, 0, 1);
            this.tlpDatos.Controls.Add(this.dtpFecha, 1, 1);
            this.tlpDatos.Controls.Add(this.lnkCambiar, 2, 1);
            this.tlpDatos.Controls.Add(this.lblObservacion, 0, 2);
            this.tlpDatos.Controls.Add(this.txtObservacion, 0, 3);
            this.tlpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 4;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDatos.TabIndex = 0;
            this.tlpDatos.SetColumnSpan(this.txtObservacion, 3);
            this.tlpDatos.SetColumnSpan(this.lblObservacion, 2);
            //
            // lblAlmacen
            //
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Text = "Almacén";
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha";
            //
            // cbxAlmacen
            //
            this.cbxAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlmacen.Margin = new System.Windows.Forms.Padding(3, 7, 12, 3);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.TabIndex = 0;
            this.cbxAlmacen.SelectionChangeCommitted += new System.EventHandler(this.cbxAlmacen_SelectionChangeCommitted);
            //
            // dtpFecha
            //
            this.dtpFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(3, 7, 12, 3);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            //
            // lnkCambiar
            //
            this.lnkCambiar.AutoSize = true;
            this.lnkCambiar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnkCambiar.Margin = new System.Windows.Forms.Padding(14, 3, 3, 3);
            this.lnkCambiar.Name = "lnkCambiar";
            this.lnkCambiar.TabIndex = 2;
            this.lnkCambiar.TabStop = true;
            this.lnkCambiar.Text = "Cambiar almacén / fecha";
            this.lnkCambiar.Visible = false;
            this.toolTip.SetToolTip(this.lnkCambiar, "El stock disponible depende del almacén y la fecha: para cambiarlos se limpia el detalle");
            this.lnkCambiar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCambiar_LinkClicked);
            //
            // lblObservacion
            //
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Text = "Observación (opcional)";
            //
            // txtObservacion
            //
            this.txtObservacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservacion.MaxLength = 500;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.TabIndex = 3;
            //
            // splitContenido
            //
            this.splitContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContenido.Name = "splitContenido";
            //
            // splitContenido.Panel1
            //
            this.splitContenido.Panel1.Controls.Add(this.dgvBusqueda);
            this.splitContenido.Panel1.Controls.Add(this.pnlBusquedaPie);
            this.splitContenido.Panel1.Controls.Add(this.tlpBusqueda);
            this.splitContenido.Panel1.Controls.Add(this.lblPaso1);
            this.splitContenido.Panel1.Padding = new System.Windows.Forms.Padding(14, 6, 6, 6);
            //
            // splitContenido.Panel2
            //
            this.splitContenido.Panel2.Controls.Add(this.lblDetalleVacio);
            this.splitContenido.Panel2.Controls.Add(this.dgvDetalle);
            this.splitContenido.Panel2.Controls.Add(this.lblPaso2);
            this.splitContenido.Panel2.Padding = new System.Windows.Forms.Padding(6, 6, 14, 6);
            this.splitContenido.Size = new System.Drawing.Size(1280, 464);
            this.splitContenido.SplitterDistance = 660;
            this.splitContenido.SplitterWidth = 6;
            this.splitContenido.TabIndex = 2;
            //
            // dgvBusqueda
            //
            this.dgvBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBGuia,
            this.colBFechaGuia,
            this.colBDestinatario,
            this.colBCodigo,
            this.colBArticulo,
            this.colBTalla,
            this.colBColor,
            this.colBUM,
            this.colBDespachado,
            this.colBIngresado,
            this.colBDisponible});
            this.dgvBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.TabIndex = 2;
            this.dgvBusqueda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusqueda_CellDoubleClick);
            this.dgvBusqueda.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBusqueda_CellFormatting);
            this.dgvBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBusqueda_KeyDown);
            //
            // colBGuia
            //
            this.colBGuia.DataPropertyName = "Guia";
            this.colBGuia.HeaderText = "Guía";
            this.colBGuia.Name = "colBGuia";
            this.colBGuia.Width = 95;
            //
            // colBFechaGuia
            //
            this.colBFechaGuia.DataPropertyName = "FechaGuia";
            this.colBFechaGuia.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.colBFechaGuia.HeaderText = "Fecha";
            this.colBFechaGuia.Name = "colBFechaGuia";
            this.colBFechaGuia.Width = 78;
            //
            // colBDestinatario
            //
            this.colBDestinatario.DataPropertyName = "Destinatario";
            this.colBDestinatario.HeaderText = "Destinatario";
            this.colBDestinatario.Name = "colBDestinatario";
            this.colBDestinatario.Width = 140;
            //
            // colBCodigo
            //
            this.colBCodigo.DataPropertyName = "Codigo";
            this.colBCodigo.HeaderText = "Código";
            this.colBCodigo.Name = "colBCodigo";
            this.colBCodigo.Width = 130;
            //
            // colBArticulo
            //
            this.colBArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBArticulo.DataPropertyName = "Articulo";
            this.colBArticulo.HeaderText = "Artículo";
            this.colBArticulo.MinimumWidth = 140;
            this.colBArticulo.Name = "colBArticulo";
            //
            // colBTalla
            //
            this.colBTalla.DataPropertyName = "Talla";
            this.colBTalla.HeaderText = "Talla";
            this.colBTalla.Name = "colBTalla";
            this.colBTalla.Width = 55;
            //
            // colBColor
            //
            this.colBColor.DataPropertyName = "Color";
            this.colBColor.HeaderText = "Color";
            this.colBColor.Name = "colBColor";
            this.colBColor.Width = 100;
            //
            // colBUM
            //
            this.colBUM.DataPropertyName = "UM";
            this.colBUM.HeaderText = "UM";
            this.colBUM.Name = "colBUM";
            this.colBUM.Width = 45;
            //
            // colBDespachado
            //
            this.colBDespachado.DataPropertyName = "Despachado";
            this.colBDespachado.HeaderText = "Despachado";
            this.colBDespachado.Name = "colBDespachado";
            this.colBDespachado.Width = 90;
            //
            // colBIngresado
            //
            this.colBIngresado.DataPropertyName = "Ingresado";
            this.colBIngresado.HeaderText = "Ya ingresado";
            this.colBIngresado.Name = "colBIngresado";
            this.colBIngresado.Width = 90;
            //
            // colBDisponible
            //
            this.colBDisponible.DataPropertyName = "Disponible";
            this.colBDisponible.HeaderText = "Disponible";
            this.colBDisponible.Name = "colBDisponible";
            this.colBDisponible.Width = 90;
            //
            // pnlBusquedaPie
            //
            this.pnlBusquedaPie.Controls.Add(this.lblAyudaBusqueda);
            this.pnlBusquedaPie.Controls.Add(this.btnAgregar);
            this.pnlBusquedaPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBusquedaPie.Name = "pnlBusquedaPie";
            this.pnlBusquedaPie.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlBusquedaPie.Size = new System.Drawing.Size(640, 44);
            this.pnlBusquedaPie.TabIndex = 3;
            //
            // lblAyudaBusqueda
            //
            this.lblAyudaBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAyudaBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblAyudaBusqueda.Name = "lblAyudaBusqueda";
            this.lblAyudaBusqueda.Text = "Doble clic o Enter para agregar. Se propone todo lo disponible; puede ajustar la cantidad a la derecha.";
            this.lblAyudaBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnAgregar
            //
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 38);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar  ▶";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            //
            // tlpBusqueda
            //
            this.tlpBusqueda.ColumnCount = 4;
            this.tlpBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tlpBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tlpBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBusqueda.Controls.Add(this.dtpGuiaDesde, 0, 0);
            this.tlpBusqueda.Controls.Add(this.dtpGuiaHasta, 1, 0);
            this.tlpBusqueda.Controls.Add(this.cbxNivel, 2, 0);
            this.tlpBusqueda.Controls.Add(this.txtBuscar, 3, 0);
            this.tlpBusqueda.Controls.Add(this.lblEstadoBusqueda, 0, 1);
            this.tlpBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpBusqueda.Name = "tlpBusqueda";
            this.tlpBusqueda.RowCount = 2;
            this.tlpBusqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBusqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpBusqueda.Size = new System.Drawing.Size(640, 52);
            this.tlpBusqueda.TabIndex = 1;
            this.tlpBusqueda.SetColumnSpan(this.lblEstadoBusqueda, 4);
            //
            // dtpGuiaDesde
            //
            this.dtpGuiaDesde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpGuiaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGuiaDesde.Name = "dtpGuiaDesde";
            this.dtpGuiaDesde.TabIndex = 0;
            this.toolTip.SetToolTip(this.dtpGuiaDesde, "Guías emitidas desde");
            this.dtpGuiaDesde.ValueChanged += new System.EventHandler(this.filtroGuia_ValueChanged);
            //
            // dtpGuiaHasta
            //
            this.dtpGuiaHasta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpGuiaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGuiaHasta.Name = "dtpGuiaHasta";
            this.dtpGuiaHasta.TabIndex = 1;
            this.toolTip.SetToolTip(this.dtpGuiaHasta, "Guías emitidas hasta");
            this.dtpGuiaHasta.ValueChanged += new System.EventHandler(this.filtroGuia_ValueChanged);
            //
            // cbxNivel
            //
            this.cbxNivel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNivel.Name = "cbxNivel";
            this.cbxNivel.TabIndex = 2;
            this.cbxNivel.SelectionChangeCommitted += new System.EventHandler(this.cbxNivel_SelectionChangeCommitted);
            //
            // txtBuscar
            //
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            //
            // lblEstadoBusqueda
            //
            this.lblEstadoBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstadoBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblEstadoBusqueda.Name = "lblEstadoBusqueda";
            this.lblEstadoBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblPaso1
            //
            this.lblPaso1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPaso1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblPaso1.Name = "lblPaso1";
            this.lblPaso1.Size = new System.Drawing.Size(640, 28);
            this.lblPaso1.Text = "1. Busque";
            this.lblPaso1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dgvDetalle
            //
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDGuia,
            this.colDCodigo,
            this.colDArticulo,
            this.colDTalla,
            this.colDColor,
            this.colDUM,
            this.colDDisponible,
            this.colDCantidad,
            this.colDComentario,
            this.colDQuitar});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.TabIndex = 1;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
            this.dgvDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDetalle_CellValidating);
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            this.dgvDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetalle_DataError);
            this.dgvDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDetalle_KeyDown);
            //
            // colDGuia
            //
            this.colDGuia.DataPropertyName = "Guia";
            this.colDGuia.HeaderText = "Guía";
            this.colDGuia.Name = "colDGuia";
            this.colDGuia.ReadOnly = true;
            this.colDGuia.Width = 95;
            //
            // colDCodigo
            //
            this.colDCodigo.DataPropertyName = "Codigo";
            this.colDCodigo.HeaderText = "Código";
            this.colDCodigo.Name = "colDCodigo";
            this.colDCodigo.ReadOnly = true;
            this.colDCodigo.Width = 125;
            //
            // colDArticulo
            //
            this.colDArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDArticulo.DataPropertyName = "Articulo";
            this.colDArticulo.HeaderText = "Artículo";
            this.colDArticulo.MinimumWidth = 110;
            this.colDArticulo.Name = "colDArticulo";
            this.colDArticulo.ReadOnly = true;
            //
            // colDTalla
            //
            this.colDTalla.DataPropertyName = "Talla";
            this.colDTalla.HeaderText = "Talla";
            this.colDTalla.Name = "colDTalla";
            this.colDTalla.ReadOnly = true;
            this.colDTalla.Width = 50;
            //
            // colDColor
            //
            this.colDColor.DataPropertyName = "Color";
            this.colDColor.HeaderText = "Color";
            this.colDColor.Name = "colDColor";
            this.colDColor.ReadOnly = true;
            this.colDColor.Width = 90;
            //
            // colDUM
            //
            this.colDUM.DataPropertyName = "UM";
            this.colDUM.HeaderText = "UM";
            this.colDUM.Name = "colDUM";
            this.colDUM.ReadOnly = true;
            this.colDUM.Width = 45;
            //
            // colDDisponible
            //
            this.colDDisponible.DataPropertyName = "Disponible";
            this.colDDisponible.HeaderText = "Disponible";
            this.colDDisponible.Name = "colDDisponible";
            this.colDDisponible.ReadOnly = true;
            this.colDDisponible.Width = 85;
            //
            // colDCantidad
            //
            this.colDCantidad.DataPropertyName = "Cantidad";
            this.colDCantidad.HeaderText = "Cantidad ✎";
            this.colDCantidad.Name = "colDCantidad";
            this.colDCantidad.Width = 90;
            //
            // colDComentario
            //
            this.colDComentario.DataPropertyName = "Comentario";
            this.colDComentario.HeaderText = "Comentario ✎";
            this.colDComentario.MaxInputLength = 250;
            this.colDComentario.Name = "colDComentario";
            this.colDComentario.Width = 120;
            //
            // colDQuitar
            //
            this.colDQuitar.HeaderText = "";
            this.colDQuitar.Name = "colDQuitar";
            this.colDQuitar.Text = "✕";
            this.colDQuitar.ToolTipText = "Quitar del detalle (Supr)";
            this.colDQuitar.UseColumnTextForButtonValue = true;
            this.colDQuitar.Width = 34;
            //
            // lblDetalleVacio
            //
            this.lblDetalleVacio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetalleVacio.BackColor = System.Drawing.Color.White;
            this.lblDetalleVacio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDetalleVacio.Location = new System.Drawing.Point(40, 180);
            this.lblDetalleVacio.Name = "lblDetalleVacio";
            this.lblDetalleVacio.Size = new System.Drawing.Size(540, 60);
            this.lblDetalleVacio.Text = "Aún no hay líneas.\r\nBúsquelas a la izquierda y agréguelas con doble clic.";
            this.lblDetalleVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblPaso2
            //
            this.lblPaso2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPaso2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblPaso2.Name = "lblPaso2";
            this.lblPaso2.Size = new System.Drawing.Size(594, 28);
            this.lblPaso2.Text = "2. Detalle";
            this.lblPaso2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlPie
            //
            this.pnlPie.BackColor = System.Drawing.Color.White;
            this.pnlPie.Controls.Add(this.lblResumen);
            this.pnlPie.Controls.Add(this.btnCancelar);
            this.pnlPie.Controls.Add(this.btnGrabar);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlPie.Size = new System.Drawing.Size(1280, 60);
            this.pnlPie.TabIndex = 3;
            //
            // lblResumen
            //
            this.lblResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Text = "Sin líneas";
            this.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnCancelar
            //
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // btnGrabar
            //
            this.btnGrabar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(170, 40);
            this.btnGrabar.TabIndex = 0;
            this.btnGrabar.Text = "Grabar  (Ctrl+G)";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            //
            // tmrBusqueda
            //
            this.tmrBusqueda.Interval = 400;
            this.tmrBusqueda.Tick += new System.EventHandler(this.tmrBusqueda_Tick);
            //
            // RegistroMovimientoAlmacenView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 716);
            this.Controls.Add(this.splitContenido);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlEncabezado);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 640);
            this.Name = "RegistroMovimientoAlmacenView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de movimiento de almacén";
            this.Load += new System.EventHandler(this.RegistroMovimientoAlmacenView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegistroMovimientoAlmacenView_KeyDown);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.tlpDatos.ResumeLayout(false);
            this.tlpDatos.PerformLayout();
            this.splitContenido.Panel1.ResumeLayout(false);
            this.splitContenido.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContenido)).EndInit();
            this.splitContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            this.pnlBusquedaPie.ResumeLayout(false);
            this.tlpBusqueda.ResumeLayout(false);
            this.tlpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.LinkLabel lnkCambiar;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.SplitContainer splitContenido;
        private System.Windows.Forms.DataGridView dgvBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBGuia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBFechaGuia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBDestinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBDespachado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBIngresado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBDisponible;
        private System.Windows.Forms.Panel pnlBusquedaPie;
        private System.Windows.Forms.Label lblAyudaBusqueda;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TableLayoutPanel tlpBusqueda;
        private System.Windows.Forms.DateTimePicker dtpGuiaDesde;
        private System.Windows.Forms.DateTimePicker dtpGuiaHasta;
        private System.Windows.Forms.ComboBox cbxNivel;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblEstadoBusqueda;
        private System.Windows.Forms.Label lblPaso1;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDGuia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDDisponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDComentario;
        private System.Windows.Forms.DataGridViewButtonColumn colDQuitar;
        private System.Windows.Forms.Label lblDetalleVacio;
        private System.Windows.Forms.Label lblPaso2;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Timer tmrBusqueda;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
