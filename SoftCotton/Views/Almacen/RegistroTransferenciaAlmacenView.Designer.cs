namespace SoftCotton.Views.Almacen
{
    partial class RegistroTransferenciaAlmacenView
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
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.flpTipo = new System.Windows.Forms.FlowLayoutPanel();
            this.rbTransferencia = new System.Windows.Forms.RadioButton();
            this.rbDevolucion = new System.Windows.Forms.RadioButton();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbxOrigen = new System.Windows.Forms.ComboBox();
            this.lblFlecha = new System.Windows.Forms.Label();
            this.cbxDestino = new System.Windows.Forms.ComboBox();
            this.lnkCambiar = new System.Windows.Forms.LinkLabel();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.splitContenido = new System.Windows.Forms.SplitContainer();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colPCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlProductosPie = new System.Windows.Forms.Panel();
            this.lblAyudaProductos = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tlpBusqueda = new System.Windows.Forms.TableLayoutPanel();
            this.cbxNivel = new System.Windows.Forms.ComboBox();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.lblEstadoBusqueda = new System.Windows.Forms.Label();
            this.lblPaso1 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
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
            this.flpTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContenido)).BeginInit();
            this.splitContenido.Panel1.SuspendLayout();
            this.splitContenido.Panel2.SuspendLayout();
            this.splitContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlProductosPie.SuspendLayout();
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
            this.pnlEncabezado.Size = new System.Drawing.Size(1200, 64);
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
            this.lblTitulo.Text = "Nueva transferencia";
            //
            // pnlDatos
            //
            this.pnlDatos.BackColor = System.Drawing.Color.White;
            this.pnlDatos.Controls.Add(this.tlpDatos);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Padding = new System.Windows.Forms.Padding(14, 10, 14, 8);
            this.pnlDatos.Size = new System.Drawing.Size(1200, 128);
            this.pnlDatos.TabIndex = 1;
            //
            // tlpDatos
            //
            this.tlpDatos.ColumnCount = 6;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDatos.Controls.Add(this.lblTipo, 0, 0);
            this.tlpDatos.Controls.Add(this.lblFecha, 1, 0);
            this.tlpDatos.Controls.Add(this.lblOrigen, 2, 0);
            this.tlpDatos.Controls.Add(this.lblDestino, 4, 0);
            this.tlpDatos.Controls.Add(this.flpTipo, 0, 1);
            this.tlpDatos.Controls.Add(this.dtpFecha, 1, 1);
            this.tlpDatos.Controls.Add(this.cbxOrigen, 2, 1);
            this.tlpDatos.Controls.Add(this.lblFlecha, 3, 1);
            this.tlpDatos.Controls.Add(this.cbxDestino, 4, 1);
            this.tlpDatos.Controls.Add(this.lnkCambiar, 5, 1);
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
            this.tlpDatos.SetColumnSpan(this.txtObservacion, 5);
            this.tlpDatos.SetColumnSpan(this.lblObservacion, 3);
            //
            // lblTipo
            //
            this.lblTipo.AutoSize = true;
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Text = "Tipo de movimiento";
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha";
            //
            // lblOrigen
            //
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Text = "Sale de (almacén origen)";
            //
            // lblDestino
            //
            this.lblDestino.AutoSize = true;
            this.lblDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Text = "Entra a (almacén destino)";
            //
            // flpTipo
            //
            this.flpTipo.Controls.Add(this.rbTransferencia);
            this.flpTipo.Controls.Add(this.rbDevolucion);
            this.flpTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTipo.Margin = new System.Windows.Forms.Padding(0);
            this.flpTipo.Name = "flpTipo";
            this.flpTipo.TabIndex = 0;
            //
            // rbTransferencia
            //
            this.rbTransferencia.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbTransferencia.Checked = true;
            this.rbTransferencia.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.rbTransferencia.Name = "rbTransferencia";
            this.rbTransferencia.Size = new System.Drawing.Size(122, 32);
            this.rbTransferencia.TabIndex = 0;
            this.rbTransferencia.TabStop = true;
            this.rbTransferencia.Text = "Transferencia";
            this.rbTransferencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.rbTransferencia, "Mover stock hacia un almacén (por ejemplo, un sobrante que no se despachó)");
            this.rbTransferencia.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
            //
            // rbDevolucion
            //
            this.rbDevolucion.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDevolucion.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.rbDevolucion.Name = "rbDevolucion";
            this.rbDevolucion.Size = new System.Drawing.Size(122, 32);
            this.rbDevolucion.TabIndex = 1;
            this.rbDevolucion.Text = "Devolución";
            this.rbDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.rbDevolucion, "Regresar stock de un almacén al almacén central (por ejemplo, para despacharlo con guía)");
            this.rbDevolucion.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
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
            // cbxOrigen
            //
            this.cbxOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrigen.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.cbxOrigen.Name = "cbxOrigen";
            this.cbxOrigen.TabIndex = 2;
            this.cbxOrigen.SelectionChangeCommitted += new System.EventHandler(this.cbxOrigen_SelectionChangeCommitted);
            //
            // lblFlecha
            //
            this.lblFlecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFlecha.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblFlecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(95)))), ((int)(((byte)(158)))));
            this.lblFlecha.Name = "lblFlecha";
            this.lblFlecha.Text = "→";
            this.lblFlecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // cbxDestino
            //
            this.cbxDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDestino.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.cbxDestino.Name = "cbxDestino";
            this.cbxDestino.TabIndex = 3;
            //
            // lnkCambiar
            //
            this.lnkCambiar.AutoSize = true;
            this.lnkCambiar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnkCambiar.Margin = new System.Windows.Forms.Padding(14, 3, 3, 3);
            this.lnkCambiar.Name = "lnkCambiar";
            this.lnkCambiar.TabIndex = 4;
            this.lnkCambiar.TabStop = true;
            this.lnkCambiar.Text = "Cambiar origen / fecha";
            this.lnkCambiar.Visible = false;
            this.toolTip.SetToolTip(this.lnkCambiar, "El stock disponible depende del origen y la fecha: para cambiarlos se limpia el detalle");
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
            this.txtObservacion.TabIndex = 5;
            //
            // splitContenido
            //
            this.splitContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContenido.Name = "splitContenido";
            //
            // splitContenido.Panel1
            //
            this.splitContenido.Panel1.Controls.Add(this.dgvProductos);
            this.splitContenido.Panel1.Controls.Add(this.pnlProductosPie);
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
            this.splitContenido.Size = new System.Drawing.Size(1200, 464);
            this.splitContenido.SplitterDistance = 560;
            this.splitContenido.SplitterWidth = 6;
            this.splitContenido.TabIndex = 2;
            //
            // dgvProductos
            //
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPCodigo,
            this.colPArticulo,
            this.colPTalla,
            this.colPColor,
            this.colPUM,
            this.colPStock});
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.TabIndex = 2;
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            //
            // colPCodigo
            //
            this.colPCodigo.DataPropertyName = "Codigo";
            this.colPCodigo.HeaderText = "Código";
            this.colPCodigo.Name = "colPCodigo";
            this.colPCodigo.Width = 135;
            //
            // colPArticulo
            //
            this.colPArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPArticulo.DataPropertyName = "Articulo";
            this.colPArticulo.HeaderText = "Artículo";
            this.colPArticulo.MinimumWidth = 120;
            this.colPArticulo.Name = "colPArticulo";
            //
            // colPTalla
            //
            this.colPTalla.DataPropertyName = "Talla";
            this.colPTalla.HeaderText = "Talla";
            this.colPTalla.Name = "colPTalla";
            this.colPTalla.Width = 60;
            //
            // colPColor
            //
            this.colPColor.DataPropertyName = "Color";
            this.colPColor.HeaderText = "Color";
            this.colPColor.Name = "colPColor";
            this.colPColor.Width = 110;
            //
            // colPUM
            //
            this.colPUM.DataPropertyName = "UM";
            this.colPUM.HeaderText = "UM";
            this.colPUM.Name = "colPUM";
            this.colPUM.Width = 45;
            //
            // colPStock
            //
            this.colPStock.DataPropertyName = "Stock";
            this.colPStock.HeaderText = "Disponible";
            this.colPStock.Name = "colPStock";
            this.colPStock.Width = 90;
            //
            // pnlProductosPie
            //
            this.pnlProductosPie.Controls.Add(this.lblAyudaProductos);
            this.pnlProductosPie.Controls.Add(this.btnAgregar);
            this.pnlProductosPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProductosPie.Name = "pnlProductosPie";
            this.pnlProductosPie.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlProductosPie.Size = new System.Drawing.Size(540, 44);
            this.pnlProductosPie.TabIndex = 3;
            //
            // lblAyudaProductos
            //
            this.lblAyudaProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAyudaProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblAyudaProductos.Name = "lblAyudaProductos";
            this.lblAyudaProductos.Text = "Doble clic o Enter para agregar. Se propone todo el stock disponible; puede ajustar la cantidad a la derecha.";
            this.lblAyudaProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tlpBusqueda.ColumnCount = 2;
            this.tlpBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBusqueda.Controls.Add(this.cbxNivel, 0, 0);
            this.tlpBusqueda.Controls.Add(this.txtBuscarProducto, 1, 0);
            this.tlpBusqueda.Controls.Add(this.lblEstadoBusqueda, 0, 1);
            this.tlpBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpBusqueda.Name = "tlpBusqueda";
            this.tlpBusqueda.RowCount = 2;
            this.tlpBusqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBusqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpBusqueda.Size = new System.Drawing.Size(540, 52);
            this.tlpBusqueda.TabIndex = 1;
            this.tlpBusqueda.SetColumnSpan(this.lblEstadoBusqueda, 2);
            //
            // cbxNivel
            //
            this.cbxNivel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNivel.Name = "cbxNivel";
            this.cbxNivel.TabIndex = 0;
            this.cbxNivel.SelectionChangeCommitted += new System.EventHandler(this.cbxNivel_SelectionChangeCommitted);
            //
            // txtBuscarProducto
            //
            this.txtBuscarProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtBuscarProducto, "Busca por código, artículo o color mientras escribe (F3)");
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            this.txtBuscarProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarProducto_KeyDown);
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
            this.lblPaso1.Size = new System.Drawing.Size(540, 28);
            this.lblPaso1.Text = "1. Busque productos con stock en el origen";
            this.lblPaso1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dgvDetalle
            //
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            // colDCodigo
            //
            this.colDCodigo.DataPropertyName = "Codigo";
            this.colDCodigo.HeaderText = "Código";
            this.colDCodigo.Name = "colDCodigo";
            this.colDCodigo.ReadOnly = true;
            this.colDCodigo.Width = 130;
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
            this.colDTalla.Width = 55;
            //
            // colDColor
            //
            this.colDColor.DataPropertyName = "Color";
            this.colDColor.HeaderText = "Color";
            this.colDColor.Name = "colDColor";
            this.colDColor.ReadOnly = true;
            this.colDColor.Width = 95;
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
            this.colDDisponible.DataPropertyName = "StockDisponible";
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
            this.colDComentario.Width = 130;
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
            this.lblDetalleVacio.Text = "Aún no hay productos.\r\nBúsquelos a la izquierda y agréguelos con doble clic.";
            this.lblDetalleVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblPaso2
            //
            this.lblPaso2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPaso2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblPaso2.Name = "lblPaso2";
            this.lblPaso2.Size = new System.Drawing.Size(614, 28);
            this.lblPaso2.Text = "2. Productos a mover";
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
            this.pnlPie.Size = new System.Drawing.Size(1200, 60);
            this.pnlPie.TabIndex = 3;
            //
            // lblResumen
            //
            this.lblResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Text = "Sin productos";
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
            // RegistroTransferenciaAlmacenView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 716);
            this.Controls.Add(this.splitContenido);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlEncabezado);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1060, 640);
            this.Name = "RegistroTransferenciaAlmacenView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de transferencia entre almacenes";
            this.Load += new System.EventHandler(this.RegistroTransferenciaAlmacenView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegistroTransferenciaAlmacenView_KeyDown);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.tlpDatos.ResumeLayout(false);
            this.tlpDatos.PerformLayout();
            this.flpTipo.ResumeLayout(false);
            this.splitContenido.Panel1.ResumeLayout(false);
            this.splitContenido.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContenido)).EndInit();
            this.splitContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlProductosPie.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.FlowLayoutPanel flpTipo;
        private System.Windows.Forms.RadioButton rbTransferencia;
        private System.Windows.Forms.RadioButton rbDevolucion;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cbxOrigen;
        private System.Windows.Forms.Label lblFlecha;
        private System.Windows.Forms.ComboBox cbxDestino;
        private System.Windows.Forms.LinkLabel lnkCambiar;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.SplitContainer splitContenido;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPStock;
        private System.Windows.Forms.Panel pnlProductosPie;
        private System.Windows.Forms.Label lblAyudaProductos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TableLayoutPanel tlpBusqueda;
        private System.Windows.Forms.ComboBox cbxNivel;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblEstadoBusqueda;
        private System.Windows.Forms.Label lblPaso1;
        private System.Windows.Forms.DataGridView dgvDetalle;
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
