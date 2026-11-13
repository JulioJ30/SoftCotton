namespace SoftCotton.Views.Almacen
{
    partial class StockAlmacenView
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
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblFechaCorte = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.cbxNivel = new System.Windows.Forms.ComboBox();
            this.dtpFechaCorte = new System.Windows.Forms.DateTimePicker();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.flpTarjetas = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTarjetaProductos = new System.Windows.Forms.Panel();
            this.lblProductosValor = new System.Windows.Forms.Label();
            this.lblProductosTitulo = new System.Windows.Forms.Label();
            this.pnlTarjetaUnidades = new System.Windows.Forms.Panel();
            this.lblUnidadesValor = new System.Windows.Forms.Label();
            this.lblUnidadesTitulo = new System.Windows.Forms.Label();
            this.pnlTarjetaAlertas = new System.Windows.Forms.Panel();
            this.lblAlertasValor = new System.Windows.Forms.Label();
            this.lblAlertasTitulo = new System.Windows.Forms.Label();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnMover = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblAyudaAcciones = new System.Windows.Forms.Label();
            this.pnlGrilla = new System.Windows.Forms.Panel();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.colAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockCentral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSinDatos = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslLeyenda = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.tlpFiltros.SuspendLayout();
            this.flpTarjetas.SuspendLayout();
            this.pnlTarjetaProductos.SuspendLayout();
            this.pnlTarjetaUnidades.SuspendLayout();
            this.pnlTarjetaAlertas.SuspendLayout();
            this.flpAcciones.SuspendLayout();
            this.pnlGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlEncabezado
            //
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(95)))), ((int)(((byte)(158)))));
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.lblSubtitulo.Text = "Stock ubicado en cada almacén según las transferencias y devoluciones registradas.";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Stock por almacén";
            //
            // pnlFiltros
            //
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.tlpFiltros);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.pnlFiltros.Size = new System.Drawing.Size(1184, 68);
            this.pnlFiltros.TabIndex = 1;
            //
            // tlpFiltros
            //
            this.tlpFiltros.ColumnCount = 6;
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFiltros.Controls.Add(this.lblAlmacen, 0, 0);
            this.tlpFiltros.Controls.Add(this.lblNivel, 1, 0);
            this.tlpFiltros.Controls.Add(this.lblFechaCorte, 2, 0);
            this.tlpFiltros.Controls.Add(this.lblBuscar, 3, 0);
            this.tlpFiltros.Controls.Add(this.cbxAlmacen, 0, 1);
            this.tlpFiltros.Controls.Add(this.cbxNivel, 1, 1);
            this.tlpFiltros.Controls.Add(this.dtpFechaCorte, 2, 1);
            this.tlpFiltros.Controls.Add(this.txtBuscar, 3, 1);
            this.tlpFiltros.Controls.Add(this.btnConsultar, 4, 1);
            this.tlpFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltros.Name = "tlpFiltros";
            this.tlpFiltros.RowCount = 2;
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFiltros.TabIndex = 0;
            //
            // lblAlmacen
            //
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Text = "Almacén";
            //
            // lblNivel
            //
            this.lblNivel.AutoSize = true;
            this.lblNivel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Text = "Nivel";
            //
            // lblFechaCorte
            //
            this.lblFechaCorte.AutoSize = true;
            this.lblFechaCorte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblFechaCorte.Name = "lblFechaCorte";
            this.lblFechaCorte.Text = "Stock al";
            //
            // lblBuscar
            //
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Código, artículo o color";
            //
            // cbxAlmacen
            //
            this.cbxAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlmacen.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.TabIndex = 0;
            //
            // cbxNivel
            //
            this.cbxNivel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNivel.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.cbxNivel.Name = "cbxNivel";
            this.cbxNivel.TabIndex = 1;
            //
            // dtpFechaCorte
            //
            this.dtpFechaCorte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCorte.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.dtpFechaCorte.Name = "dtpFechaCorte";
            this.dtpFechaCorte.TabIndex = 2;
            //
            // txtBuscar
            //
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            //
            // btnConsultar
            //
            this.btnConsultar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            //
            // flpTarjetas
            //
            this.flpTarjetas.Controls.Add(this.pnlTarjetaProductos);
            this.flpTarjetas.Controls.Add(this.pnlTarjetaUnidades);
            this.flpTarjetas.Controls.Add(this.pnlTarjetaAlertas);
            this.flpTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTarjetas.Name = "flpTarjetas";
            this.flpTarjetas.Padding = new System.Windows.Forms.Padding(11, 10, 11, 0);
            this.flpTarjetas.Size = new System.Drawing.Size(1184, 86);
            this.flpTarjetas.TabIndex = 2;
            //
            // pnlTarjetaProductos
            //
            this.pnlTarjetaProductos.BackColor = System.Drawing.Color.White;
            this.pnlTarjetaProductos.Controls.Add(this.lblProductosValor);
            this.pnlTarjetaProductos.Controls.Add(this.lblProductosTitulo);
            this.pnlTarjetaProductos.Name = "pnlTarjetaProductos";
            this.pnlTarjetaProductos.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.pnlTarjetaProductos.Size = new System.Drawing.Size(220, 70);
            //
            // lblProductosValor
            //
            this.lblProductosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductosValor.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblProductosValor.Name = "lblProductosValor";
            this.lblProductosValor.Text = "—";
            this.lblProductosValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblProductosTitulo
            //
            this.lblProductosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblProductosTitulo.Name = "lblProductosTitulo";
            this.lblProductosTitulo.Size = new System.Drawing.Size(192, 18);
            this.lblProductosTitulo.Text = "Productos con stock";
            //
            // pnlTarjetaUnidades
            //
            this.pnlTarjetaUnidades.BackColor = System.Drawing.Color.White;
            this.pnlTarjetaUnidades.Controls.Add(this.lblUnidadesValor);
            this.pnlTarjetaUnidades.Controls.Add(this.lblUnidadesTitulo);
            this.pnlTarjetaUnidades.Name = "pnlTarjetaUnidades";
            this.pnlTarjetaUnidades.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.pnlTarjetaUnidades.Size = new System.Drawing.Size(220, 70);
            //
            // lblUnidadesValor
            //
            this.lblUnidadesValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUnidadesValor.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblUnidadesValor.Name = "lblUnidadesValor";
            this.lblUnidadesValor.Text = "—";
            this.lblUnidadesValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblUnidadesTitulo
            //
            this.lblUnidadesTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUnidadesTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblUnidadesTitulo.Name = "lblUnidadesTitulo";
            this.lblUnidadesTitulo.Size = new System.Drawing.Size(192, 18);
            this.lblUnidadesTitulo.Text = "Unidades en total";
            //
            // pnlTarjetaAlertas
            //
            this.pnlTarjetaAlertas.BackColor = System.Drawing.Color.White;
            this.pnlTarjetaAlertas.Controls.Add(this.lblAlertasValor);
            this.pnlTarjetaAlertas.Controls.Add(this.lblAlertasTitulo);
            this.pnlTarjetaAlertas.Name = "pnlTarjetaAlertas";
            this.pnlTarjetaAlertas.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.pnlTarjetaAlertas.Size = new System.Drawing.Size(320, 70);
            //
            // lblAlertasValor
            //
            this.lblAlertasValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlertasValor.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblAlertasValor.Name = "lblAlertasValor";
            this.lblAlertasValor.Text = "—";
            this.lblAlertasValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblAlertasTitulo
            //
            this.lblAlertasTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAlertasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblAlertasTitulo.Name = "lblAlertasTitulo";
            this.lblAlertasTitulo.Size = new System.Drawing.Size(292, 18);
            this.lblAlertasTitulo.Text = "Despachados sin devolución previa";
            this.toolTip.SetToolTip(this.lblAlertasTitulo, "Productos cuyo stock en el almacén central quedó negativo: probablemente se despacharon con guía desde este almacén sin registrar antes la devolución.");
            //
            // flpAcciones
            //
            this.flpAcciones.Controls.Add(this.btnDevolver);
            this.flpAcciones.Controls.Add(this.btnMover);
            this.flpAcciones.Controls.Add(this.btnExportar);
            this.flpAcciones.Controls.Add(this.lblAyudaAcciones);
            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Padding = new System.Windows.Forms.Padding(12, 8, 12, 4);
            this.flpAcciones.Size = new System.Drawing.Size(1184, 52);
            this.flpAcciones.TabIndex = 3;
            //
            // btnDevolver
            //
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(180, 34);
            this.btnDevolver.TabIndex = 0;
            this.btnDevolver.Text = "↩  Devolver al central";
            this.toolTip.SetToolTip(this.btnDevolver, "Registrar la devolución al almacén central de las filas seleccionadas (por ejemplo, antes de despacharlas con guía)");
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            //
            // btnMover
            //
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(180, 34);
            this.btnMover.TabIndex = 1;
            this.btnMover.Text = "⇄  Mover a otro almacén";
            this.toolTip.SetToolTip(this.btnMover, "Transferir las filas seleccionadas a otro almacén");
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            //
            // btnExportar
            //
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(130, 34);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "Exportar Excel";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            //
            // lblAyudaAcciones
            //
            this.lblAyudaAcciones.AutoSize = true;
            this.lblAyudaAcciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblAyudaAcciones.Margin = new System.Windows.Forms.Padding(14, 11, 3, 0);
            this.lblAyudaAcciones.Name = "lblAyudaAcciones";
            this.lblAyudaAcciones.Text = "Seleccione una o varias filas de un mismo almacén (Ctrl/Shift + clic).";
            //
            // pnlGrilla
            //
            this.pnlGrilla.Controls.Add(this.lblSinDatos);
            this.pnlGrilla.Controls.Add(this.dgvStock);
            this.pnlGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrilla.Name = "pnlGrilla";
            this.pnlGrilla.Padding = new System.Windows.Forms.Padding(14, 4, 14, 8);
            this.pnlGrilla.TabIndex = 4;
            //
            // dgvStock
            //
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAlmacen,
            this.colCodigo,
            this.colArticulo,
            this.colTalla,
            this.colColor,
            this.colUM,
            this.colStock,
            this.colStockCentral,
            this.colUltimoMovimiento});
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.TabIndex = 0;
            this.dgvStock.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStock_CellFormatting);
            this.dgvStock.SelectionChanged += new System.EventHandler(this.dgvStock_SelectionChanged);
            //
            // colAlmacen
            //
            this.colAlmacen.DataPropertyName = "Almacen";
            this.colAlmacen.HeaderText = "Almacén";
            this.colAlmacen.Name = "colAlmacen";
            this.colAlmacen.Width = 190;
            //
            // colCodigo
            //
            this.colCodigo.DataPropertyName = "Codigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 145;
            //
            // colArticulo
            //
            this.colArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colArticulo.DataPropertyName = "Articulo";
            this.colArticulo.HeaderText = "Artículo";
            this.colArticulo.MinimumWidth = 160;
            this.colArticulo.Name = "colArticulo";
            //
            // colTalla
            //
            this.colTalla.DataPropertyName = "Talla";
            this.colTalla.HeaderText = "Talla";
            this.colTalla.Name = "colTalla";
            this.colTalla.Width = 70;
            //
            // colColor
            //
            this.colColor.DataPropertyName = "Color";
            this.colColor.HeaderText = "Color";
            this.colColor.Name = "colColor";
            this.colColor.Width = 140;
            //
            // colUM
            //
            this.colUM.DataPropertyName = "UM";
            this.colUM.HeaderText = "UM";
            this.colUM.Name = "colUM";
            this.colUM.Width = 50;
            //
            // colStock
            //
            this.colStock.DataPropertyName = "Stock";
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.Width = 100;
            //
            // colStockCentral
            //
            this.colStockCentral.DataPropertyName = "StockCentral";
            this.colStockCentral.HeaderText = "Stock en central";
            this.colStockCentral.Name = "colStockCentral";
            this.colStockCentral.ToolTipText = "Stock del mismo producto en el almacén central (todo el Kardex que no fue movido)";
            this.colStockCentral.Width = 120;
            //
            // colUltimoMovimiento
            //
            this.colUltimoMovimiento.DataPropertyName = "FechaUltimoMovimiento";
            this.colUltimoMovimiento.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.colUltimoMovimiento.HeaderText = "Último mov.";
            this.colUltimoMovimiento.Name = "colUltimoMovimiento";
            this.colUltimoMovimiento.Width = 95;
            //
            // lblSinDatos
            //
            this.lblSinDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSinDatos.BackColor = System.Drawing.Color.White;
            this.lblSinDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSinDatos.Location = new System.Drawing.Point(392, 120);
            this.lblSinDatos.Name = "lblSinDatos";
            this.lblSinDatos.Size = new System.Drawing.Size(400, 50);
            this.lblSinDatos.Text = "No hay stock en otros almacenes para los filtros seleccionados.";
            this.lblSinDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinDatos.Visible = false;
            //
            // statusStrip
            //
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTotal,
            this.tsslLeyenda});
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.TabIndex = 5;
            //
            // tsslTotal
            //
            this.tsslTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.tsslTotal.Name = "tsslTotal";
            this.tsslTotal.Text = "";
            //
            // tsslLeyenda
            //
            this.tsslLeyenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(100)))), ((int)(((byte)(4)))));
            this.tsslLeyenda.Name = "tsslLeyenda";
            this.tsslLeyenda.Spring = true;
            this.tsslLeyenda.Text = "Filas en amarillo: el central quedó negativo — registre la devolución antes de despachar con guía.";
            this.tsslLeyenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // StockAlmacenView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlGrilla);
            this.Controls.Add(this.flpAcciones);
            this.Controls.Add(this.flpTarjetas);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.statusStrip);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(980, 560);
            this.Name = "StockAlmacenView";
            this.Text = "Stock por almacén";
            this.Load += new System.EventHandler(this.StockAlmacenView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockAlmacenView_KeyDown);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.tlpFiltros.ResumeLayout(false);
            this.tlpFiltros.PerformLayout();
            this.flpTarjetas.ResumeLayout(false);
            this.pnlTarjetaProductos.ResumeLayout(false);
            this.pnlTarjetaUnidades.ResumeLayout(false);
            this.pnlTarjetaAlertas.ResumeLayout(false);
            this.flpAcciones.ResumeLayout(false);
            this.flpAcciones.PerformLayout();
            this.pnlGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
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
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblFechaCorte;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.ComboBox cbxNivel;
        private System.Windows.Forms.DateTimePicker dtpFechaCorte;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.FlowLayoutPanel flpTarjetas;
        private System.Windows.Forms.Panel pnlTarjetaProductos;
        private System.Windows.Forms.Label lblProductosValor;
        private System.Windows.Forms.Label lblProductosTitulo;
        private System.Windows.Forms.Panel pnlTarjetaUnidades;
        private System.Windows.Forms.Label lblUnidadesValor;
        private System.Windows.Forms.Label lblUnidadesTitulo;
        private System.Windows.Forms.Panel pnlTarjetaAlertas;
        private System.Windows.Forms.Label lblAlertasValor;
        private System.Windows.Forms.Label lblAlertasTitulo;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblAyudaAcciones;
        private System.Windows.Forms.Panel pnlGrilla;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockCentral;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUltimoMovimiento;
        private System.Windows.Forms.Label lblSinDatos;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotal;
        private System.Windows.Forms.ToolStripStatusLabel tsslLeyenda;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
