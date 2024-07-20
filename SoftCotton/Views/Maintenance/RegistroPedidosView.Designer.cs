namespace SoftCotton.Views.Maintenance
{
    partial class RegistroPedidosView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroPedidosView));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBuscarEstilos = new System.Windows.Forms.Button();
            this.btnBuscarProgramas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEstilo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrograma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregarColor = new System.Windows.Forms.Button();
            this.btnBuscarColor = new System.Windows.Forms.Button();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.dgvPedidosColor = new System.Windows.Forms.DataGridView();
            this.idPedidoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoColor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.lblPedido = new System.Windows.Forms.Label();
            this.idPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuarioCrea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCrea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbtnVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbtnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosColor)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.btnBuscarEstilos);
            this.groupBox1.Controls.Add(this.btnBuscarProgramas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEstilo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPrograma);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPedido);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro Pedidos";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(370, 74);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(144, 24);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(278, 74);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(88, 24);
            this.btnNuevo.TabIndex = 15;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBuscarEstilos
            // 
            this.btnBuscarEstilos.BackgroundImage = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscarEstilos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarEstilos.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarEstilos.Location = new System.Drawing.Point(382, 34);
            this.btnBuscarEstilos.Name = "btnBuscarEstilos";
            this.btnBuscarEstilos.Size = new System.Drawing.Size(22, 22);
            this.btnBuscarEstilos.TabIndex = 14;
            this.btnBuscarEstilos.UseVisualStyleBackColor = true;
            this.btnBuscarEstilos.Click += new System.EventHandler(this.btnBuscarEstilos_Click);
            // 
            // btnBuscarProgramas
            // 
            this.btnBuscarProgramas.BackgroundImage = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscarProgramas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProgramas.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProgramas.Location = new System.Drawing.Point(231, 33);
            this.btnBuscarProgramas.Name = "btnBuscarProgramas";
            this.btnBuscarProgramas.Size = new System.Drawing.Size(22, 22);
            this.btnBuscarProgramas.TabIndex = 13;
            this.btnBuscarProgramas.UseVisualStyleBackColor = true;
            this.btnBuscarProgramas.Click += new System.EventHandler(this.btnBuscarProgramas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estilo";
            // 
            // txtEstilo
            // 
            this.txtEstilo.Location = new System.Drawing.Point(276, 34);
            this.txtEstilo.Name = "txtEstilo";
            this.txtEstilo.ReadOnly = true;
            this.txtEstilo.Size = new System.Drawing.Size(100, 22);
            this.txtEstilo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Programa";
            // 
            // txtPrograma
            // 
            this.txtPrograma.Location = new System.Drawing.Point(131, 34);
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.ReadOnly = true;
            this.txtPrograma.Size = new System.Drawing.Size(100, 22);
            this.txtPrograma.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pedido";
            // 
            // txtPedido
            // 
            this.txtPedido.Location = new System.Drawing.Point(6, 34);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(100, 22);
            this.txtPedido.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPedido);
            this.groupBox2.Controls.Add(this.btnAgregarColor);
            this.groupBox2.Controls.Add(this.btnBuscarColor);
            this.groupBox2.Controls.Add(this.txtColor);
            this.groupBox2.Controls.Add(this.dgvPedidosColor);
            this.groupBox2.Location = new System.Drawing.Point(538, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 370);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colores";
            // 
            // btnAgregarColor
            // 
            this.btnAgregarColor.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnAgregarColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarColor.Location = new System.Drawing.Point(254, 45);
            this.btnAgregarColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarColor.Name = "btnAgregarColor";
            this.btnAgregarColor.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnAgregarColor.Size = new System.Drawing.Size(108, 24);
            this.btnAgregarColor.TabIndex = 17;
            this.btnAgregarColor.Text = "Agregar Color";
            this.btnAgregarColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarColor.UseVisualStyleBackColor = true;
            this.btnAgregarColor.Click += new System.EventHandler(this.btnAgregarColor_Click);
            // 
            // btnBuscarColor
            // 
            this.btnBuscarColor.BackgroundImage = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscarColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarColor.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarColor.Location = new System.Drawing.Point(224, 45);
            this.btnBuscarColor.Name = "btnBuscarColor";
            this.btnBuscarColor.Size = new System.Drawing.Size(22, 22);
            this.btnBuscarColor.TabIndex = 15;
            this.btnBuscarColor.UseVisualStyleBackColor = true;
            this.btnBuscarColor.Click += new System.EventHandler(this.btnBuscarColor_Click);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(6, 45);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.Size = new System.Drawing.Size(212, 22);
            this.txtColor.TabIndex = 5;
            // 
            // dgvPedidosColor
            // 
            this.dgvPedidosColor.AllowUserToAddRows = false;
            this.dgvPedidosColor.AllowUserToDeleteRows = false;
            this.dgvPedidosColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosColor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPedidoColor,
            this.codColor,
            this.color,
            this.estadoColor});
            this.dgvPedidosColor.Location = new System.Drawing.Point(6, 74);
            this.dgvPedidosColor.Name = "dgvPedidosColor";
            this.dgvPedidosColor.ReadOnly = true;
            this.dgvPedidosColor.RowHeadersVisible = false;
            this.dgvPedidosColor.Size = new System.Drawing.Size(350, 289);
            this.dgvPedidosColor.TabIndex = 0;
            // 
            // idPedidoColor
            // 
            this.idPedidoColor.DataPropertyName = "idPedidoColor";
            this.idPedidoColor.HeaderText = "idPedidoColor";
            this.idPedidoColor.Name = "idPedidoColor";
            this.idPedidoColor.ReadOnly = true;
            this.idPedidoColor.Visible = false;
            // 
            // codColor
            // 
            this.codColor.DataPropertyName = "codColor";
            this.codColor.HeaderText = "codColor";
            this.codColor.Name = "codColor";
            this.codColor.ReadOnly = true;
            this.codColor.Visible = false;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "Color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            // 
            // estadoColor
            // 
            this.estadoColor.DataPropertyName = "estadoColor";
            this.estadoColor.HeaderText = "Estado";
            this.estadoColor.Name = "estadoColor";
            this.estadoColor.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPedidos);
            this.groupBox3.Location = new System.Drawing.Point(12, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(520, 261);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle Pedidos";
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AllowUserToResizeRows = false;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPedido,
            this.idEstilo,
            this.idPrograma,
            this.idUsuarioCrea,
            this.pedido,
            this.fechaCrea,
            this.estilo,
            this.programa,
            this.estado,
            this.cbtnVer,
            this.cbtnEditar});
            this.dgvPedidos.Location = new System.Drawing.Point(6, 21);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(508, 233);
            this.dgvPedidos.TabIndex = 0;
            this.dgvPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellClick);
            this.dgvPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellContentClick);
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Location = new System.Drawing.Point(6, 29);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(46, 13);
            this.lblPedido.TabIndex = 18;
            this.lblPedido.Text = "Pedido:";
            // 
            // idPedido
            // 
            this.idPedido.HeaderText = "idPedido";
            this.idPedido.Name = "idPedido";
            this.idPedido.ReadOnly = true;
            this.idPedido.Visible = false;
            // 
            // idEstilo
            // 
            this.idEstilo.HeaderText = "idEstilo";
            this.idEstilo.Name = "idEstilo";
            this.idEstilo.ReadOnly = true;
            this.idEstilo.Visible = false;
            // 
            // idPrograma
            // 
            this.idPrograma.HeaderText = "idPrograma";
            this.idPrograma.Name = "idPrograma";
            this.idPrograma.ReadOnly = true;
            this.idPrograma.Visible = false;
            // 
            // idUsuarioCrea
            // 
            this.idUsuarioCrea.HeaderText = "idUsuarioCrea";
            this.idUsuarioCrea.Name = "idUsuarioCrea";
            this.idUsuarioCrea.ReadOnly = true;
            this.idUsuarioCrea.Visible = false;
            // 
            // pedido
            // 
            this.pedido.HeaderText = "Pedido";
            this.pedido.Name = "pedido";
            this.pedido.ReadOnly = true;
            // 
            // fechaCrea
            // 
            this.fechaCrea.HeaderText = "Fecha Crea";
            this.fechaCrea.Name = "fechaCrea";
            this.fechaCrea.ReadOnly = true;
            // 
            // estilo
            // 
            this.estilo.HeaderText = "Estilo";
            this.estilo.Name = "estilo";
            this.estilo.ReadOnly = true;
            // 
            // programa
            // 
            this.programa.HeaderText = "Programa";
            this.programa.Name = "programa";
            this.programa.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // cbtnVer
            // 
            this.cbtnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnVer.HeaderText = "Ver";
            this.cbtnVer.Name = "cbtnVer";
            this.cbtnVer.ReadOnly = true;
            this.cbtnVer.Text = "Ver";
            this.cbtnVer.UseColumnTextForButtonValue = true;
            // 
            // cbtnEditar
            // 
            this.cbtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnEditar.HeaderText = "Editar";
            this.cbtnEditar.Name = "cbtnEditar";
            this.cbtnEditar.ReadOnly = true;
            this.cbtnEditar.Text = "Editar";
            this.cbtnEditar.UseColumnTextForButtonValue = true;
            // 
            // RegistroPedidosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(912, 394);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroPedidosView";
            this.Text = "Registro de Pedidos";
            this.Load += new System.EventHandler(this.RegistroPedidosView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosColor)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridView dgvPedidosColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEstilo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrograma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.Button btnBuscarEstilos;
        private System.Windows.Forms.Button btnBuscarProgramas;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button btnBuscarColor;
        private System.Windows.Forms.Button btnAgregarColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedidoColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn codColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadoColor;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrograma;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuarioCrea;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCrea;
        private System.Windows.Forms.DataGridViewTextBoxColumn estilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn programa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estado;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnVer;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEditar;
    }
}