namespace SoftCotton.Views.Maintenance
{
    partial class BuscarPedidosColorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarPedidosColorView));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.idPedidoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCrea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVerDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColPermitirRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido:";
            // 
            // txtPedido
            // 
            this.txtPedido.Location = new System.Drawing.Point(371, 11);
            this.txtPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(379, 22);
            this.txtPedido.TabIndex = 5;
            this.txtPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPedido_KeyPress);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPedidoColor,
            this.idPedido,
            this.idEstilo,
            this.idPrograma,
            this.codColor,
            this.pedido,
            this.color,
            this.programa,
            this.estilo,
            this.estado,
            this.fechaCrea,
            this.codigoEstilo,
            this.btnVerDetalle,
            this.ColPermitirRegistro});
            this.dgvLista.Location = new System.Drawing.Point(5, 43);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.RowHeadersWidth = 51;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(745, 422);
            this.dgvLista.TabIndex = 6;
            this.dgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellContentClick);
            this.dgvLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLista_KeyDown);
            // 
            // idPedidoColor
            // 
            this.idPedidoColor.DataPropertyName = "idPedidoColor";
            this.idPedidoColor.HeaderText = "idPedidoColor";
            this.idPedidoColor.MinimumWidth = 6;
            this.idPedidoColor.Name = "idPedidoColor";
            this.idPedidoColor.ReadOnly = true;
            this.idPedidoColor.Visible = false;
            // 
            // idPedido
            // 
            this.idPedido.DataPropertyName = "idPedido";
            this.idPedido.HeaderText = "idPedido";
            this.idPedido.MinimumWidth = 6;
            this.idPedido.Name = "idPedido";
            this.idPedido.ReadOnly = true;
            this.idPedido.Visible = false;
            // 
            // idEstilo
            // 
            this.idEstilo.DataPropertyName = "idEstilo";
            this.idEstilo.HeaderText = "idEstilo";
            this.idEstilo.MinimumWidth = 6;
            this.idEstilo.Name = "idEstilo";
            this.idEstilo.ReadOnly = true;
            this.idEstilo.Visible = false;
            // 
            // idPrograma
            // 
            this.idPrograma.DataPropertyName = "idPrograma";
            this.idPrograma.HeaderText = "idPrograma";
            this.idPrograma.MinimumWidth = 6;
            this.idPrograma.Name = "idPrograma";
            this.idPrograma.ReadOnly = true;
            this.idPrograma.Visible = false;
            // 
            // codColor
            // 
            this.codColor.DataPropertyName = "codColor";
            this.codColor.HeaderText = "codColor";
            this.codColor.MinimumWidth = 6;
            this.codColor.Name = "codColor";
            this.codColor.ReadOnly = true;
            this.codColor.Visible = false;
            // 
            // pedido
            // 
            this.pedido.DataPropertyName = "pedido";
            this.pedido.HeaderText = "Pedido";
            this.pedido.MinimumWidth = 6;
            this.pedido.Name = "pedido";
            this.pedido.ReadOnly = true;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "Color";
            this.color.MinimumWidth = 6;
            this.color.Name = "color";
            this.color.ReadOnly = true;
            // 
            // programa
            // 
            this.programa.DataPropertyName = "programa";
            this.programa.HeaderText = "Programa";
            this.programa.MinimumWidth = 6;
            this.programa.Name = "programa";
            this.programa.ReadOnly = true;
            // 
            // estilo
            // 
            this.estilo.DataPropertyName = "estilo";
            this.estilo.HeaderText = "Estilo";
            this.estilo.MinimumWidth = 6;
            this.estilo.Name = "estilo";
            this.estilo.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            // 
            // fechaCrea
            // 
            this.fechaCrea.DataPropertyName = "fechaCrea";
            this.fechaCrea.HeaderText = "fechaCrea";
            this.fechaCrea.MinimumWidth = 6;
            this.fechaCrea.Name = "fechaCrea";
            this.fechaCrea.ReadOnly = true;
            this.fechaCrea.Visible = false;
            // 
            // codigoEstilo
            // 
            this.codigoEstilo.DataPropertyName = "codigoEstilo";
            this.codigoEstilo.HeaderText = "codigoEstilo";
            this.codigoEstilo.MinimumWidth = 6;
            this.codigoEstilo.Name = "codigoEstilo";
            this.codigoEstilo.ReadOnly = true;
            this.codigoEstilo.Visible = false;
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.HeaderText = "Detalle";
            this.btnVerDetalle.MinimumWidth = 6;
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.ReadOnly = true;
            this.btnVerDetalle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnVerDetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnVerDetalle.Text = "VER DETALLE";
            this.btnVerDetalle.UseColumnTextForButtonValue = true;
            // 
            // ColPermitirRegistro
            // 
            this.ColPermitirRegistro.DataPropertyName = "PermitirRegistro";
            this.ColPermitirRegistro.HeaderText = "PermitirRegistro";
            this.ColPermitirRegistro.MinimumWidth = 6;
            this.ColPermitirRegistro.Name = "ColPermitirRegistro";
            this.ColPermitirRegistro.ReadOnly = true;
            this.ColPermitirRegistro.Visible = false;
            // 
            // BuscarPedidosColorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 480);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BuscarPedidosColorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de Pedidos Color";
            this.Load += new System.EventHandler(this.BuscarPedidosColorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedidoColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrograma;
        private System.Windows.Forms.DataGridViewTextBoxColumn codColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn estilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCrea;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoEstilo;
        private System.Windows.Forms.DataGridViewButtonColumn btnVerDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPermitirRegistro;
    }
}