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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido:";
            // 
            // txtPedido
            // 
            this.txtPedido.Location = new System.Drawing.Point(278, 9);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(285, 20);
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
            this.codigoEstilo});
            this.dgvLista.Location = new System.Drawing.Point(4, 35);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(559, 343);
            this.dgvLista.TabIndex = 6;
            this.dgvLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLista_KeyDown);
            // 
            // idPedidoColor
            // 
            this.idPedidoColor.DataPropertyName = "idPedidoColor";
            this.idPedidoColor.HeaderText = "idPedidoColor";
            this.idPedidoColor.Name = "idPedidoColor";
            this.idPedidoColor.ReadOnly = true;
            this.idPedidoColor.Visible = false;
            // 
            // idPedido
            // 
            this.idPedido.DataPropertyName = "idPedido";
            this.idPedido.HeaderText = "idPedido";
            this.idPedido.Name = "idPedido";
            this.idPedido.ReadOnly = true;
            this.idPedido.Visible = false;
            // 
            // idEstilo
            // 
            this.idEstilo.DataPropertyName = "idEstilo";
            this.idEstilo.HeaderText = "idEstilo";
            this.idEstilo.Name = "idEstilo";
            this.idEstilo.ReadOnly = true;
            this.idEstilo.Visible = false;
            // 
            // idPrograma
            // 
            this.idPrograma.DataPropertyName = "idPrograma";
            this.idPrograma.HeaderText = "idPrograma";
            this.idPrograma.Name = "idPrograma";
            this.idPrograma.ReadOnly = true;
            this.idPrograma.Visible = false;
            // 
            // codColor
            // 
            this.codColor.DataPropertyName = "codColor";
            this.codColor.HeaderText = "codColor";
            this.codColor.Name = "codColor";
            this.codColor.ReadOnly = true;
            this.codColor.Visible = false;
            // 
            // pedido
            // 
            this.pedido.DataPropertyName = "pedido";
            this.pedido.HeaderText = "Pedido";
            this.pedido.Name = "pedido";
            this.pedido.ReadOnly = true;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "Color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            // 
            // programa
            // 
            this.programa.DataPropertyName = "programa";
            this.programa.HeaderText = "Programa";
            this.programa.Name = "programa";
            this.programa.ReadOnly = true;
            // 
            // estilo
            // 
            this.estilo.DataPropertyName = "estilo";
            this.estilo.HeaderText = "Estilo";
            this.estilo.Name = "estilo";
            this.estilo.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            // 
            // fechaCrea
            // 
            this.fechaCrea.DataPropertyName = "fechaCrea";
            this.fechaCrea.HeaderText = "fechaCrea";
            this.fechaCrea.Name = "fechaCrea";
            this.fechaCrea.ReadOnly = true;
            this.fechaCrea.Visible = false;
            // 
            // codigoEstilo
            // 
            this.codigoEstilo.DataPropertyName = "codigoEstilo";
            this.codigoEstilo.HeaderText = "codigoEstilo";
            this.codigoEstilo.Name = "codigoEstilo";
            this.codigoEstilo.ReadOnly = true;
            this.codigoEstilo.Visible = false;
            // 
            // BuscarPedidosColorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 390);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}