namespace SoftCotton.Views.Movimientos
{
    partial class IngresoDeTelas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaMovimiento = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPedidoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartidaProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditarItem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEliminarItem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.txtComentario);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpFechaMovimiento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboTipoMovimiento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 118);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SoftCotton.Properties.Resources.icon_eliminar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(325, 74);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnCancelar.Size = new System.Drawing.Size(118, 33);
            this.btnCancelar.TabIndex = 54;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(449, 74);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnBuscar.Size = new System.Drawing.Size(134, 33);
            this.btnBuscar.TabIndex = 53;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(589, 74);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(134, 33);
            this.btnGuardar.TabIndex = 52;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(729, 74);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(118, 33);
            this.btnNuevo.TabIndex = 51;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(401, 46);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(446, 22);
            this.txtComentario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Comentario";
            // 
            // dtpFechaMovimiento
            // 
            this.dtpFechaMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaMovimiento.Location = new System.Drawing.Point(240, 44);
            this.dtpFechaMovimiento.Name = "dtpFechaMovimiento";
            this.dtpFechaMovimiento.Size = new System.Drawing.Size(139, 22);
            this.dtpFechaMovimiento.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Movimiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Movimiento";
            // 
            // cboTipoMovimiento
            // 
            this.cboTipoMovimiento.FormattingEnabled = true;
            this.cboTipoMovimiento.Location = new System.Drawing.Point(12, 44);
            this.cboTipoMovimiento.Name = "cboTipoMovimiento";
            this.cboTipoMovimiento.Size = new System.Drawing.Size(206, 24);
            this.cboTipoMovimiento.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregarItem);
            this.groupBox1.Controls.Add(this.dgvItem);
            this.groupBox1.Location = new System.Drawing.Point(12, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 399);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle Movimiento";
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnAgregarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarItem.Location = new System.Drawing.Point(681, 21);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnAgregarItem.Size = new System.Drawing.Size(148, 33);
            this.btnAgregarItem.TabIndex = 52;
            this.btnAgregarItem.Text = "Agregar Item";
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.AllowUserToResizeRows = false;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.IdPedidoColor,
            this.CodigoNivel,
            this.CodGrupo,
            this.CodTalla,
            this.CodColor,
            this.Producto,
            this.Cantidad,
            this.Pedido,
            this.PedidoColor,
            this.Programa,
            this.Estilo,
            this.PartidaProveedor,
            this.Comentario,
            this.btnEditarItem,
            this.btnEliminarItem});
            this.dgvItem.Location = new System.Drawing.Point(6, 70);
            this.dgvItem.MultiSelect = false;
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.RowHeadersWidth = 51;
            this.dgvItem.RowTemplate.Height = 24;
            this.dgvItem.Size = new System.Drawing.Size(823, 310);
            this.dgvItem.TabIndex = 0;
            this.dgvItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellContentClick);
            // 
            // item
            // 
            this.item.DataPropertyName = "item";
            this.item.HeaderText = "Item";
            this.item.MinimumWidth = 6;
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Width = 125;
            // 
            // IdPedidoColor
            // 
            this.IdPedidoColor.HeaderText = "IdPedidoColor";
            this.IdPedidoColor.MinimumWidth = 6;
            this.IdPedidoColor.Name = "IdPedidoColor";
            this.IdPedidoColor.ReadOnly = true;
            this.IdPedidoColor.Visible = false;
            this.IdPedidoColor.Width = 125;
            // 
            // CodigoNivel
            // 
            this.CodigoNivel.DataPropertyName = "CodigoNivel";
            this.CodigoNivel.HeaderText = "Cod. Nivel";
            this.CodigoNivel.MinimumWidth = 6;
            this.CodigoNivel.Name = "CodigoNivel";
            this.CodigoNivel.ReadOnly = true;
            this.CodigoNivel.Width = 125;
            // 
            // CodGrupo
            // 
            this.CodGrupo.DataPropertyName = "CodGrupo";
            this.CodGrupo.HeaderText = "Cod. Grupo";
            this.CodGrupo.MinimumWidth = 6;
            this.CodGrupo.Name = "CodGrupo";
            this.CodGrupo.ReadOnly = true;
            this.CodGrupo.Width = 125;
            // 
            // CodTalla
            // 
            this.CodTalla.DataPropertyName = "CodTalla";
            this.CodTalla.HeaderText = "Cod. Talla";
            this.CodTalla.MinimumWidth = 6;
            this.CodTalla.Name = "CodTalla";
            this.CodTalla.ReadOnly = true;
            this.CodTalla.Width = 125;
            // 
            // CodColor
            // 
            this.CodColor.DataPropertyName = "CodColor";
            this.CodColor.HeaderText = "Cod. Color";
            this.CodColor.MinimumWidth = 6;
            this.CodColor.Name = "CodColor";
            this.CodColor.ReadOnly = true;
            this.CodColor.Width = 125;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 125;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 125;
            // 
            // Pedido
            // 
            this.Pedido.DataPropertyName = "Pedido";
            this.Pedido.HeaderText = "Pedido";
            this.Pedido.MinimumWidth = 6;
            this.Pedido.Name = "Pedido";
            this.Pedido.ReadOnly = true;
            this.Pedido.Width = 125;
            // 
            // PedidoColor
            // 
            this.PedidoColor.DataPropertyName = "PedidoColor";
            this.PedidoColor.HeaderText = "Color Pedido";
            this.PedidoColor.MinimumWidth = 6;
            this.PedidoColor.Name = "PedidoColor";
            this.PedidoColor.ReadOnly = true;
            this.PedidoColor.Width = 125;
            // 
            // Programa
            // 
            this.Programa.HeaderText = "Programa";
            this.Programa.MinimumWidth = 6;
            this.Programa.Name = "Programa";
            this.Programa.ReadOnly = true;
            this.Programa.Width = 125;
            // 
            // Estilo
            // 
            this.Estilo.HeaderText = "Estilo";
            this.Estilo.MinimumWidth = 6;
            this.Estilo.Name = "Estilo";
            this.Estilo.ReadOnly = true;
            this.Estilo.Width = 125;
            // 
            // PartidaProveedor
            // 
            this.PartidaProveedor.DataPropertyName = "PartidaProveedor";
            this.PartidaProveedor.HeaderText = "Partida Proveedor";
            this.PartidaProveedor.MinimumWidth = 6;
            this.PartidaProveedor.Name = "PartidaProveedor";
            this.PartidaProveedor.ReadOnly = true;
            this.PartidaProveedor.Width = 125;
            // 
            // Comentario
            // 
            this.Comentario.DataPropertyName = "Comentario";
            this.Comentario.HeaderText = "Comentario";
            this.Comentario.MinimumWidth = 6;
            this.Comentario.Name = "Comentario";
            this.Comentario.ReadOnly = true;
            this.Comentario.Width = 125;
            // 
            // btnEditarItem
            // 
            this.btnEditarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarItem.HeaderText = "Editar";
            this.btnEditarItem.MinimumWidth = 6;
            this.btnEditarItem.Name = "btnEditarItem";
            this.btnEditarItem.ReadOnly = true;
            this.btnEditarItem.Text = "Editar";
            this.btnEditarItem.UseColumnTextForButtonValue = true;
            this.btnEditarItem.Width = 125;
            // 
            // btnEliminarItem
            // 
            this.btnEliminarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarItem.HeaderText = "Eliminar";
            this.btnEliminarItem.MinimumWidth = 6;
            this.btnEliminarItem.Name = "btnEliminarItem";
            this.btnEliminarItem.ReadOnly = true;
            this.btnEliminarItem.Text = "Eliminar";
            this.btnEliminarItem.UseColumnTextForButtonValue = true;
            this.btnEliminarItem.Width = 125;
            // 
            // IngresoDeTelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 546);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "IngresoDeTelas";
            this.Text = "Ingreso de Telas";
            this.Load += new System.EventHandler(this.IngresoDeTelas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFechaMovimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPedidoColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartidaProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditarItem;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminarItem;
    }
}