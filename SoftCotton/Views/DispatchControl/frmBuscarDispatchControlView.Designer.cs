namespace SoftCotton.Views.DispatchControl
{
    partial class frmBuscarDispatchControlView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarDispatchControlView));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.txtPedidoBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProcesoControl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProcesoControlDespachoCab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPedidoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pedido,
            this.color,
            this.idProcesoControl,
            this.proceso,
            this.idProcesoControlDespachoCab,
            this.idPrograma,
            this.programa,
            this.idEstilo,
            this.estilo,
            this.idPedidoColor,
            this.cliente,
            this.idProveedor,
            this.proveedor});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListado.Location = new System.Drawing.Point(0, 33);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(741, 227);
            this.dgvListado.TabIndex = 8;
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // txtPedidoBuscar
            // 
            this.txtPedidoBuscar.Location = new System.Drawing.Point(100, 5);
            this.txtPedidoBuscar.Name = "txtPedidoBuscar";
            this.txtPedidoBuscar.Size = new System.Drawing.Size(629, 22);
            this.txtPedidoBuscar.TabIndex = 7;
            this.txtPedidoBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPedidoBuscar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar Pedido:";
            // 
            // pedido
            // 
            this.pedido.DataPropertyName = "pedido";
            this.pedido.HeaderText = "Pedido";
            this.pedido.Name = "pedido";
            this.pedido.ReadOnly = true;
            this.pedido.Width = 68;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "Color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Width = 60;
            // 
            // idProcesoControl
            // 
            this.idProcesoControl.DataPropertyName = "idProcesoControl";
            this.idProcesoControl.HeaderText = "idProcesoControl";
            this.idProcesoControl.Name = "idProcesoControl";
            this.idProcesoControl.ReadOnly = true;
            this.idProcesoControl.Visible = false;
            this.idProcesoControl.Width = 121;
            // 
            // proceso
            // 
            this.proceso.DataPropertyName = "proceso";
            this.proceso.HeaderText = "proceso";
            this.proceso.Name = "proceso";
            this.proceso.ReadOnly = true;
            this.proceso.Visible = false;
            this.proceso.Width = 73;
            // 
            // idProcesoControlDespachoCab
            // 
            this.idProcesoControlDespachoCab.DataPropertyName = "idProcesoControlDespachoCab";
            this.idProcesoControlDespachoCab.HeaderText = "idProcesoControlDespachoCab";
            this.idProcesoControlDespachoCab.Name = "idProcesoControlDespachoCab";
            this.idProcesoControlDespachoCab.ReadOnly = true;
            this.idProcesoControlDespachoCab.Visible = false;
            this.idProcesoControlDespachoCab.Width = 192;
            // 
            // idPrograma
            // 
            this.idPrograma.DataPropertyName = "idPrograma";
            this.idPrograma.HeaderText = "idPrograma";
            this.idPrograma.Name = "idPrograma";
            this.idPrograma.ReadOnly = true;
            this.idPrograma.Visible = false;
            this.idPrograma.Width = 91;
            // 
            // programa
            // 
            this.programa.DataPropertyName = "programa";
            this.programa.HeaderText = "Programa";
            this.programa.Name = "programa";
            this.programa.ReadOnly = true;
            this.programa.Width = 81;
            // 
            // idEstilo
            // 
            this.idEstilo.DataPropertyName = "idEstilo";
            this.idEstilo.HeaderText = "idEstilo";
            this.idEstilo.Name = "idEstilo";
            this.idEstilo.ReadOnly = true;
            this.idEstilo.Visible = false;
            this.idEstilo.Width = 70;
            // 
            // estilo
            // 
            this.estilo.DataPropertyName = "estilo";
            this.estilo.HeaderText = "Estilo";
            this.estilo.Name = "estilo";
            this.estilo.ReadOnly = true;
            this.estilo.Width = 60;
            // 
            // idPedidoColor
            // 
            this.idPedidoColor.DataPropertyName = "idPedidoColor";
            this.idPedidoColor.HeaderText = "idPedidoColor";
            this.idPedidoColor.Name = "idPedidoColor";
            this.idPedidoColor.ReadOnly = true;
            this.idPedidoColor.Visible = false;
            this.idPedidoColor.Width = 106;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "cliente";
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 68;
            // 
            // idProveedor
            // 
            this.idProveedor.DataPropertyName = "idProveedor";
            this.idProveedor.HeaderText = "idProveedor";
            this.idProveedor.Name = "idProveedor";
            this.idProveedor.ReadOnly = true;
            this.idProveedor.Visible = false;
            this.idProveedor.Width = 94;
            // 
            // proveedor
            // 
            this.proveedor.DataPropertyName = "proveedor";
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            this.proveedor.Width = 84;
            // 
            // frmBuscarDispatchControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 260);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.txtPedidoBuscar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBuscarDispatchControlView";
            this.Text = "Buscar Control de Despacho";
            this.Load += new System.EventHandler(this.frmBuscarDispatchControlView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.TextBox txtPedidoBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoControlDespachoCab;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrograma;
        private System.Windows.Forms.DataGridViewTextBoxColumn programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedidoColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
    }
}