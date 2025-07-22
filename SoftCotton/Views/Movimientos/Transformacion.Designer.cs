namespace SoftCotton.Views.Movimientos
{
    partial class Transformacion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProveedorGuiaOrigen = new System.Windows.Forms.TextBox();
            this.txtNumeroGuiaOrigen = new System.Windows.Forms.TextBox();
            this.txtSerieGuiaOrigen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNivelOrigen = new System.Windows.Forms.ComboBox();
            this.cboNivelDestino = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvOrigenItems = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvDestinoItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvBtnTallas = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DgvIdTransformacionDet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumeroGuiaDestino = new System.Windows.Forms.TextBox();
            this.txtSerieGuiaDestino = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTipoOrdenCompraServicio = new System.Windows.Forms.ComboBox();
            this.btnGenerarOrden = new System.Windows.Forms.Button();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigenItems)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinoItems)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProveedorGuiaOrigen);
            this.groupBox1.Controls.Add(this.txtNumeroGuiaOrigen);
            this.groupBox1.Controls.Add(this.txtSerieGuiaOrigen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboNivelOrigen);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Origen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(475, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ruc Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Número Guia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Serie Guia";
            // 
            // txtProveedorGuiaOrigen
            // 
            this.txtProveedorGuiaOrigen.Location = new System.Drawing.Point(478, 49);
            this.txtProveedorGuiaOrigen.Name = "txtProveedorGuiaOrigen";
            this.txtProveedorGuiaOrigen.Size = new System.Drawing.Size(199, 22);
            this.txtProveedorGuiaOrigen.TabIndex = 4;
            // 
            // txtNumeroGuiaOrigen
            // 
            this.txtNumeroGuiaOrigen.Location = new System.Drawing.Point(346, 49);
            this.txtNumeroGuiaOrigen.Name = "txtNumeroGuiaOrigen";
            this.txtNumeroGuiaOrigen.Size = new System.Drawing.Size(126, 22);
            this.txtNumeroGuiaOrigen.TabIndex = 3;
            // 
            // txtSerieGuiaOrigen
            // 
            this.txtSerieGuiaOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerieGuiaOrigen.Location = new System.Drawing.Point(242, 49);
            this.txtSerieGuiaOrigen.Name = "txtSerieGuiaOrigen";
            this.txtSerieGuiaOrigen.Size = new System.Drawing.Size(98, 22);
            this.txtSerieGuiaOrigen.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nivel ";
            // 
            // cboNivelOrigen
            // 
            this.cboNivelOrigen.FormattingEnabled = true;
            this.cboNivelOrigen.Location = new System.Drawing.Point(9, 49);
            this.cboNivelOrigen.Name = "cboNivelOrigen";
            this.cboNivelOrigen.Size = new System.Drawing.Size(227, 24);
            this.cboNivelOrigen.TabIndex = 0;
            // 
            // cboNivelDestino
            // 
            this.cboNivelDestino.FormattingEnabled = true;
            this.cboNivelDestino.Location = new System.Drawing.Point(203, 47);
            this.cboNivelDestino.Name = "cboNivelDestino";
            this.cboNivelDestino.Size = new System.Drawing.Size(162, 24);
            this.cboNivelDestino.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGenerarOrden);
            this.groupBox3.Controls.Add(this.btnAgregarItem);
            this.groupBox3.Controls.Add(this.dgvOrigenItems);
            this.groupBox3.Location = new System.Drawing.Point(12, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(677, 388);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Origen Items";
            // 
            // dgvOrigenItems
            // 
            this.dgvOrigenItems.AllowUserToAddRows = false;
            this.dgvOrigenItems.AllowUserToDeleteRows = false;
            this.dgvOrigenItems.AllowUserToResizeRows = false;
            this.dgvOrigenItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrigenItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrigenItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.DgvSecuencia,
            this.CodigoItem,
            this.Producto,
            this.Cantidad});
            this.dgvOrigenItems.Location = new System.Drawing.Point(6, 60);
            this.dgvOrigenItems.MultiSelect = false;
            this.dgvOrigenItems.Name = "dgvOrigenItems";
            this.dgvOrigenItems.ReadOnly = true;
            this.dgvOrigenItems.RowHeadersVisible = false;
            this.dgvOrigenItems.RowHeadersWidth = 51;
            this.dgvOrigenItems.RowTemplate.Height = 24;
            this.dgvOrigenItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrigenItems.Size = new System.Drawing.Size(665, 322);
            this.dgvOrigenItems.TabIndex = 1;
            this.dgvOrigenItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrigenItems_CellContentClick);
            // 
            // item
            // 
            this.item.DataPropertyName = "item";
            this.item.HeaderText = "Item";
            this.item.MinimumWidth = 6;
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Width = 61;
            // 
            // DgvSecuencia
            // 
            this.DgvSecuencia.DataPropertyName = "DgvSecuencia";
            this.DgvSecuencia.HeaderText = "DgvSecuencia";
            this.DgvSecuencia.MinimumWidth = 6;
            this.DgvSecuencia.Name = "DgvSecuencia";
            this.DgvSecuencia.ReadOnly = true;
            this.DgvSecuencia.Visible = false;
            this.DgvSecuencia.Width = 125;
            // 
            // CodigoItem
            // 
            this.CodigoItem.DataPropertyName = "CodigoItem";
            this.CodigoItem.HeaderText = "Cod. Item";
            this.CodigoItem.MinimumWidth = 6;
            this.CodigoItem.Name = "CodigoItem";
            this.CodigoItem.ReadOnly = true;
            this.CodigoItem.Width = 92;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 90;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 90;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvDestinoItems);
            this.groupBox4.Location = new System.Drawing.Point(695, 109);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(710, 388);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Destino Items";
            // 
            // dgvDestinoItems
            // 
            this.dgvDestinoItems.AllowUserToAddRows = false;
            this.dgvDestinoItems.AllowUserToDeleteRows = false;
            this.dgvDestinoItems.AllowUserToResizeRows = false;
            this.dgvDestinoItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDestinoItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.DgvBtnTallas,
            this.DgvIdTransformacionDet});
            this.dgvDestinoItems.Location = new System.Drawing.Point(6, 21);
            this.dgvDestinoItems.MultiSelect = false;
            this.dgvDestinoItems.Name = "dgvDestinoItems";
            this.dgvDestinoItems.ReadOnly = true;
            this.dgvDestinoItems.RowHeadersVisible = false;
            this.dgvDestinoItems.RowHeadersWidth = 51;
            this.dgvDestinoItems.RowTemplate.Height = 24;
            this.dgvDestinoItems.Size = new System.Drawing.Size(698, 361);
            this.dgvDestinoItems.TabIndex = 2;
            this.dgvDestinoItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDestinoItems_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Item";
            this.dataGridViewTextBoxColumn1.HeaderText = "Item";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cod. Item";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Producto";
            this.dataGridViewTextBoxColumn3.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Cantidad";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Comentario";
            this.dataGridViewTextBoxColumn5.HeaderText = "Comentario";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // DgvBtnTallas
            // 
            this.DgvBtnTallas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DgvBtnTallas.HeaderText = "Tallas";
            this.DgvBtnTallas.MinimumWidth = 6;
            this.DgvBtnTallas.Name = "DgvBtnTallas";
            this.DgvBtnTallas.ReadOnly = true;
            this.DgvBtnTallas.Text = "Ver Tallas";
            this.DgvBtnTallas.UseColumnTextForButtonValue = true;
            this.DgvBtnTallas.Width = 125;
            // 
            // DgvIdTransformacionDet
            // 
            this.DgvIdTransformacionDet.DataPropertyName = "IdTransformacionDet";
            this.DgvIdTransformacionDet.HeaderText = "IdTransformacionDet";
            this.DgvIdTransformacionDet.MinimumWidth = 6;
            this.DgvIdTransformacionDet.Name = "DgvIdTransformacionDet";
            this.DgvIdTransformacionDet.ReadOnly = true;
            this.DgvIdTransformacionDet.Visible = false;
            this.DgvIdTransformacionDet.Width = 125;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtNumeroGuiaDestino);
            this.groupBox5.Controls.Add(this.txtSerieGuiaDestino);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.cboNivelDestino);
            this.groupBox5.Controls.Add(this.cboTipoOrdenCompraServicio);
            this.groupBox5.Location = new System.Drawing.Point(742, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(663, 91);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datos Orden / Guia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(474, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Número Guia";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(370, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Serie Guia";
            // 
            // txtNumeroGuiaDestino
            // 
            this.txtNumeroGuiaDestino.Location = new System.Drawing.Point(477, 49);
            this.txtNumeroGuiaDestino.Name = "txtNumeroGuiaDestino";
            this.txtNumeroGuiaDestino.Size = new System.Drawing.Size(126, 22);
            this.txtNumeroGuiaDestino.TabIndex = 10;
            // 
            // txtSerieGuiaDestino
            // 
            this.txtSerieGuiaDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerieGuiaDestino.Location = new System.Drawing.Point(373, 49);
            this.txtSerieGuiaDestino.Name = "txtSerieGuiaDestino";
            this.txtSerieGuiaDestino.Size = new System.Drawing.Size(98, 22);
            this.txtSerieGuiaDestino.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nivel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tipo Orden";
            // 
            // cboTipoOrdenCompraServicio
            // 
            this.cboTipoOrdenCompraServicio.FormattingEnabled = true;
            this.cboTipoOrdenCompraServicio.Location = new System.Drawing.Point(6, 47);
            this.cboTipoOrdenCompraServicio.Name = "cboTipoOrdenCompraServicio";
            this.cboTipoOrdenCompraServicio.Size = new System.Drawing.Size(191, 24);
            this.cboTipoOrdenCompraServicio.TabIndex = 3;
            // 
            // btnGenerarOrden
            // 
            this.btnGenerarOrden.Image = global::SoftCotton.Properties.Resources.icon_refrescar;
            this.btnGenerarOrden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarOrden.Location = new System.Drawing.Point(12, 21);
            this.btnGenerarOrden.Name = "btnGenerarOrden";
            this.btnGenerarOrden.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGenerarOrden.Size = new System.Drawing.Size(203, 33);
            this.btnGenerarOrden.TabIndex = 56;
            this.btnGenerarOrden.Text = "Generar Orden C/S";
            this.btnGenerarOrden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarOrden.UseVisualStyleBackColor = true;
            this.btnGenerarOrden.Click += new System.EventHandler(this.btnGenerarOrden_Click);
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnAgregarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarItem.Location = new System.Drawing.Point(544, 21);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnAgregarItem.Size = new System.Drawing.Size(127, 33);
            this.btnAgregarItem.TabIndex = 55;
            this.btnAgregarItem.Text = "Agregar Item";
            this.btnAgregarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(683, 44);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnBuscar.Size = new System.Drawing.Size(35, 33);
            this.btnBuscar.TabIndex = 54;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Transformacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 507);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Transformacion";
            this.Text = "Tranformacion";
            this.Load += new System.EventHandler(this.Transformacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigenItems)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinoItems)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNivelOrigen;
        private System.Windows.Forms.TextBox txtNumeroGuiaOrigen;
        private System.Windows.Forms.TextBox txtSerieGuiaOrigen;
        private System.Windows.Forms.TextBox txtProveedorGuiaOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboNivelDestino;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvOrigenItems;
        private System.Windows.Forms.DataGridView dgvDestinoItems;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewButtonColumn DgvBtnTallas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIdTransformacionDet;
        private System.Windows.Forms.ComboBox cboTipoOrdenCompraServicio;
        private System.Windows.Forms.Button btnGenerarOrden;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumeroGuiaDestino;
        private System.Windows.Forms.TextBox txtSerieGuiaDestino;
        private System.Windows.Forms.Label label5;
    }
}