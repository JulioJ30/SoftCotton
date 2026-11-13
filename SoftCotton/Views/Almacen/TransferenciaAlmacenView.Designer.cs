namespace SoftCotton.Views.Almacen
{
    partial class TransferenciaAlmacenView
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
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.tlpFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevaTransferencia = new System.Windows.Forms.Button();
            this.btnNuevaDevolucion = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.splitContenido = new System.Windows.Forms.SplitContainer();
            this.dgvCabecera = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCabeceraTitulo = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colDetCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDetalleTitulo = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAyuda = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.tlpFiltros.SuspendLayout();
            this.flpAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContenido)).BeginInit();
            this.splitContenido.Panel1.SuspendLayout();
            this.splitContenido.Panel2.SuspendLayout();
            this.splitContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabecera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlEncabezado
            //
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(95)))), ((int)(((byte)(158)))));
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1184, 64);
            this.pnlEncabezado.TabIndex = 0;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(243)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 38);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(520, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Mueva sobrantes de stock entre almacenes sin generar OC ni OS. Los movimientos se reflejan en el Kardex.";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(330, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Transferencias entre almacenes";
            //
            // pnlFiltros
            //
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.tlpFiltros);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 64);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.pnlFiltros.Size = new System.Drawing.Size(1184, 68);
            this.pnlFiltros.TabIndex = 1;
            //
            // tlpFiltros
            //
            this.tlpFiltros.ColumnCount = 7;
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFiltros.Controls.Add(this.lblDesde, 0, 0);
            this.tlpFiltros.Controls.Add(this.lblHasta, 1, 0);
            this.tlpFiltros.Controls.Add(this.lblAlmacen, 2, 0);
            this.tlpFiltros.Controls.Add(this.lblEstado, 3, 0);
            this.tlpFiltros.Controls.Add(this.lblBuscar, 4, 0);
            this.tlpFiltros.Controls.Add(this.dtpDesde, 0, 1);
            this.tlpFiltros.Controls.Add(this.dtpHasta, 1, 1);
            this.tlpFiltros.Controls.Add(this.cbxAlmacen, 2, 1);
            this.tlpFiltros.Controls.Add(this.cbxEstado, 3, 1);
            this.tlpFiltros.Controls.Add(this.txtBuscar, 4, 1);
            this.tlpFiltros.Controls.Add(this.btnBuscar, 5, 1);
            this.tlpFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltros.Location = new System.Drawing.Point(14, 8);
            this.tlpFiltros.Name = "tlpFiltros";
            this.tlpFiltros.RowCount = 2;
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFiltros.Size = new System.Drawing.Size(1156, 52);
            this.tlpFiltros.TabIndex = 0;
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDesde.Location = new System.Drawing.Point(3, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Text = "Desde";
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblHasta.Location = new System.Drawing.Point(133, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Text = "Hasta";
            //
            // lblAlmacen
            //
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblAlmacen.Location = new System.Drawing.Point(263, 0);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Text = "Almacén (origen o destino)";
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblEstado.Location = new System.Drawing.Point(513, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Estado";
            //
            // lblBuscar
            //
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblBuscar.Location = new System.Drawing.Point(653, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "N°, producto u observación";
            //
            // dtpDesde
            //
            this.dtpDesde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.TabIndex = 0;
            //
            // dtpHasta
            //
            this.dtpHasta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.TabIndex = 1;
            //
            // cbxAlmacen
            //
            this.cbxAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlmacen.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.TabIndex = 2;
            //
            // cbxEstado
            //
            this.cbxEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstado.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.TabIndex = 3;
            //
            // txtBuscar
            //
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            //
            // btnBuscar
            //
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            //
            // flpAcciones
            //
            this.flpAcciones.Controls.Add(this.btnNuevaTransferencia);
            this.flpAcciones.Controls.Add(this.btnNuevaDevolucion);
            this.flpAcciones.Controls.Add(this.btnAnular);
            this.flpAcciones.Controls.Add(this.btnExportar);
            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpAcciones.Location = new System.Drawing.Point(0, 132);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Padding = new System.Windows.Forms.Padding(12, 10, 12, 6);
            this.flpAcciones.Size = new System.Drawing.Size(1184, 56);
            this.flpAcciones.TabIndex = 2;
            //
            // btnNuevaTransferencia
            //
            this.btnNuevaTransferencia.Name = "btnNuevaTransferencia";
            this.btnNuevaTransferencia.Size = new System.Drawing.Size(190, 34);
            this.btnNuevaTransferencia.TabIndex = 0;
            this.btnNuevaTransferencia.Text = "＋  Nueva transferencia";
            this.toolTip.SetToolTip(this.btnNuevaTransferencia, "Mover stock del almacén central (u otro) a un almacén (Ctrl+N)");
            this.btnNuevaTransferencia.Click += new System.EventHandler(this.btnNuevaTransferencia_Click);
            //
            // btnNuevaDevolucion
            //
            this.btnNuevaDevolucion.Name = "btnNuevaDevolucion";
            this.btnNuevaDevolucion.Size = new System.Drawing.Size(180, 34);
            this.btnNuevaDevolucion.TabIndex = 1;
            this.btnNuevaDevolucion.Text = "↩  Nueva devolución";
            this.toolTip.SetToolTip(this.btnNuevaDevolucion, "Regresar stock de un almacén al almacén central (por ejemplo, antes de despacharlo con guía)");
            this.btnNuevaDevolucion.Click += new System.EventHandler(this.btnNuevaDevolucion_Click);
            //
            // btnAnular
            //
            this.btnAnular.Margin = new System.Windows.Forms.Padding(24, 3, 3, 3);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(110, 34);
            this.btnAnular.TabIndex = 2;
            this.btnAnular.Text = "Anular";
            this.toolTip.SetToolTip(this.btnAnular, "Anular la transferencia seleccionada");
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            //
            // btnExportar
            //
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(130, 34);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar Excel";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            //
            // splitContenido
            //
            this.splitContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContenido.Location = new System.Drawing.Point(0, 188);
            this.splitContenido.Name = "splitContenido";
            this.splitContenido.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitContenido.Panel1
            //
            this.splitContenido.Panel1.Controls.Add(this.dgvCabecera);
            this.splitContenido.Panel1.Controls.Add(this.lblCabeceraTitulo);
            this.splitContenido.Panel1.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            //
            // splitContenido.Panel2
            //
            this.splitContenido.Panel2.Controls.Add(this.dgvDetalle);
            this.splitContenido.Panel2.Controls.Add(this.lblDetalleTitulo);
            this.splitContenido.Panel2.Padding = new System.Windows.Forms.Padding(14, 0, 14, 8);
            this.splitContenido.Size = new System.Drawing.Size(1184, 451);
            this.splitContenido.SplitterDistance = 250;
            this.splitContenido.SplitterWidth = 8;
            this.splitContenido.TabIndex = 3;
            //
            // dgvCabecera
            //
            this.dgvCabecera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colTipo,
            this.colFecha,
            this.colOrigen,
            this.colDestino,
            this.colItems,
            this.colCantidadTotal,
            this.colEstado,
            this.colUsuario,
            this.colFechaRegistro,
            this.colObservacion});
            this.dgvCabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCabecera.MultiSelect = false;
            this.dgvCabecera.Name = "dgvCabecera";
            this.dgvCabecera.TabIndex = 1;
            this.dgvCabecera.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCabecera_CellFormatting);
            this.dgvCabecera.SelectionChanged += new System.EventHandler(this.dgvCabecera_SelectionChanged);
            //
            // colNumero
            //
            this.colNumero.DataPropertyName = "Numero";
            this.colNumero.HeaderText = "N°";
            this.colNumero.Name = "colNumero";
            this.colNumero.Width = 70;
            //
            // colTipo
            //
            this.colTipo.DataPropertyName = "TipoDescripcion";
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Width = 115;
            //
            // colFecha
            //
            this.colFecha.DataPropertyName = "FechaTransferencia";
            this.colFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Width = 85;
            //
            // colOrigen
            //
            this.colOrigen.DataPropertyName = "AlmacenOrigen";
            this.colOrigen.HeaderText = "Origen";
            this.colOrigen.Name = "colOrigen";
            this.colOrigen.Width = 170;
            //
            // colDestino
            //
            this.colDestino.DataPropertyName = "AlmacenDestino";
            this.colDestino.HeaderText = "Destino";
            this.colDestino.Name = "colDestino";
            this.colDestino.Width = 170;
            //
            // colItems
            //
            this.colItems.DataPropertyName = "Items";
            this.colItems.HeaderText = "Ítems";
            this.colItems.Name = "colItems";
            this.colItems.Width = 55;
            //
            // colCantidadTotal
            //
            this.colCantidadTotal.DataPropertyName = "CantidadTotal";
            this.colCantidadTotal.HeaderText = "Cantidad";
            this.colCantidadTotal.Name = "colCantidadTotal";
            this.colCantidadTotal.Width = 95;
            //
            // colEstado
            //
            this.colEstado.DataPropertyName = "EstadoDescripcion";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 85;
            //
            // colUsuario
            //
            this.colUsuario.DataPropertyName = "UsuarioRegistro";
            this.colUsuario.HeaderText = "Registrado por";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.Width = 110;
            //
            // colFechaRegistro
            //
            this.colFechaRegistro.DataPropertyName = "FechaRegistro";
            this.colFechaRegistro.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            this.colFechaRegistro.HeaderText = "Registrado el";
            this.colFechaRegistro.Name = "colFechaRegistro";
            this.colFechaRegistro.Width = 120;
            //
            // colObservacion
            //
            this.colObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colObservacion.DataPropertyName = "Observacion";
            this.colObservacion.HeaderText = "Observación";
            this.colObservacion.MinimumWidth = 120;
            this.colObservacion.Name = "colObservacion";
            //
            // lblCabeceraTitulo
            //
            this.lblCabeceraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCabeceraTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblCabeceraTitulo.Name = "lblCabeceraTitulo";
            this.lblCabeceraTitulo.Size = new System.Drawing.Size(1156, 26);
            this.lblCabeceraTitulo.TabIndex = 0;
            this.lblCabeceraTitulo.Text = "Transferencias registradas";
            this.lblCabeceraTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dgvDetalle
            //
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetCodigo,
            this.colDetArticulo,
            this.colDetTalla,
            this.colDetColor,
            this.colDetUM,
            this.colDetCantidad,
            this.colDetCuenta,
            this.colDetComentario});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.TabIndex = 1;
            //
            // colDetCodigo
            //
            this.colDetCodigo.DataPropertyName = "Codigo";
            this.colDetCodigo.HeaderText = "Código";
            this.colDetCodigo.Name = "colDetCodigo";
            this.colDetCodigo.Width = 150;
            //
            // colDetArticulo
            //
            this.colDetArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDetArticulo.DataPropertyName = "Articulo";
            this.colDetArticulo.HeaderText = "Artículo";
            this.colDetArticulo.MinimumWidth = 160;
            this.colDetArticulo.Name = "colDetArticulo";
            //
            // colDetTalla
            //
            this.colDetTalla.DataPropertyName = "Talla";
            this.colDetTalla.HeaderText = "Talla";
            this.colDetTalla.Name = "colDetTalla";
            this.colDetTalla.Width = 80;
            //
            // colDetColor
            //
            this.colDetColor.DataPropertyName = "Color";
            this.colDetColor.HeaderText = "Color";
            this.colDetColor.Name = "colDetColor";
            this.colDetColor.Width = 140;
            //
            // colDetUM
            //
            this.colDetUM.DataPropertyName = "UM";
            this.colDetUM.HeaderText = "UM";
            this.colDetUM.Name = "colDetUM";
            this.colDetUM.Width = 55;
            //
            // colDetCantidad
            //
            this.colDetCantidad.DataPropertyName = "Cantidad";
            this.colDetCantidad.HeaderText = "Cantidad";
            this.colDetCantidad.Name = "colDetCantidad";
            this.colDetCantidad.Width = 100;
            //
            // colDetCuenta
            //
            this.colDetCuenta.DataPropertyName = "codCuenta";
            this.colDetCuenta.HeaderText = "Cuenta";
            this.colDetCuenta.Name = "colDetCuenta";
            this.colDetCuenta.Width = 95;
            //
            // colDetComentario
            //
            this.colDetComentario.DataPropertyName = "Comentario";
            this.colDetComentario.HeaderText = "Comentario";
            this.colDetComentario.Name = "colDetComentario";
            this.colDetComentario.Width = 220;
            //
            // lblDetalleTitulo
            //
            this.lblDetalleTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Size = new System.Drawing.Size(1156, 26);
            this.lblDetalleTitulo.TabIndex = 0;
            this.lblDetalleTitulo.Text = "Detalle";
            this.lblDetalleTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // statusStrip
            //
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTotal,
            this.tsslAyuda});
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.TabIndex = 4;
            //
            // tsslTotal
            //
            this.tsslTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.tsslTotal.Name = "tsslTotal";
            this.tsslTotal.Text = "0 transferencias";
            //
            // tsslAyuda
            //
            this.tsslAyuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.tsslAyuda.Name = "tsslAyuda";
            this.tsslAyuda.Spring = true;
            this.tsslAyuda.Text = "F5 actualizar · Ctrl+N nueva transferencia · Ctrl+D nueva devolución";
            this.tsslAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // TransferenciaAlmacenView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.splitContenido);
            this.Controls.Add(this.flpAcciones);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.statusStrip);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(980, 560);
            this.Name = "TransferenciaAlmacenView";
            this.Text = "Transferencias entre almacenes";
            this.Load += new System.EventHandler(this.TransferenciaAlmacenView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransferenciaAlmacenView_KeyDown);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.tlpFiltros.ResumeLayout(false);
            this.tlpFiltros.PerformLayout();
            this.flpAcciones.ResumeLayout(false);
            this.splitContenido.Panel1.ResumeLayout(false);
            this.splitContenido.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContenido)).EndInit();
            this.splitContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabecera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.TableLayoutPanel tlpFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.ComboBox cbxEstado;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnNuevaTransferencia;
        private System.Windows.Forms.Button btnNuevaDevolucion;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.SplitContainer splitContenido;
        private System.Windows.Forms.DataGridView dgvCabecera;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.Label lblCabeceraTitulo;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetComentario;
        private System.Windows.Forms.Label lblDetalleTitulo;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotal;
        private System.Windows.Forms.ToolStripStatusLabel tsslAyuda;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
