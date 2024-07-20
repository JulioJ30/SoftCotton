namespace SoftCotton.Views.ReferralGuide
{
    partial class BuscarOCGRView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarOCGRView));
            this.dgvOrdenCompra = new System.Windows.Forms.DataGridView();
            this.dgvIntIdEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtTipoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIntId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIntSecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCodCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDescripcionCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIntCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecCantidadEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecCantidadSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIntCantidadSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrdenCompra
            // 
            this.dgvOrdenCompra.AllowUserToAddRows = false;
            this.dgvOrdenCompra.AllowUserToDeleteRows = false;
            this.dgvOrdenCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdenCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvIntIdEmpresa,
            this.dgvTxtTipo,
            this.dgvTxtTipoId,
            this.dgvIntId,
            this.dgvTxtCodPC,
            this.dgvTxtPC,
            this.dgvIntSecuencia,
            this.dgvTxtCodNivel,
            this.dgvTxtCodGrupo,
            this.dgvTxtCodTalla,
            this.dgvTxtCodColor,
            this.dgvCodigoProducto,
            this.dgvTxtProducto,
            this.dgvCodCuenta,
            this.dgvDescripcionCta,
            this.dgvIntCantidad,
            this.dgvDecCantidadEntrada,
            this.dgvDecCantidadSalida,
            this.dgvIntCantidadSaldo,
            this.dgvTxtCodUM,
            this.dgvDecPrecioUnitario,
            this.dgvDecTotal});
            this.dgvOrdenCompra.Location = new System.Drawing.Point(7, 40);
            this.dgvOrdenCompra.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvOrdenCompra.MultiSelect = false;
            this.dgvOrdenCompra.Name = "dgvOrdenCompra";
            this.dgvOrdenCompra.ReadOnly = true;
            this.dgvOrdenCompra.RowHeadersVisible = false;
            this.dgvOrdenCompra.RowHeadersWidth = 51;
            this.dgvOrdenCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenCompra.Size = new System.Drawing.Size(972, 407);
            this.dgvOrdenCompra.TabIndex = 5;
            this.dgvOrdenCompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOrdenCompra_KeyDown);
            // 
            // dgvIntIdEmpresa
            // 
            this.dgvIntIdEmpresa.HeaderText = "ID Empresa";
            this.dgvIntIdEmpresa.MinimumWidth = 6;
            this.dgvIntIdEmpresa.Name = "dgvIntIdEmpresa";
            this.dgvIntIdEmpresa.ReadOnly = true;
            this.dgvIntIdEmpresa.Visible = false;
            this.dgvIntIdEmpresa.Width = 80;
            // 
            // dgvTxtTipo
            // 
            this.dgvTxtTipo.HeaderText = "Tipo de Orden";
            this.dgvTxtTipo.MinimumWidth = 6;
            this.dgvTxtTipo.Name = "dgvTxtTipo";
            this.dgvTxtTipo.ReadOnly = true;
            this.dgvTxtTipo.Width = 125;
            // 
            // dgvTxtTipoId
            // 
            this.dgvTxtTipoId.HeaderText = "Tipo Orden ID";
            this.dgvTxtTipoId.MinimumWidth = 6;
            this.dgvTxtTipoId.Name = "dgvTxtTipoId";
            this.dgvTxtTipoId.ReadOnly = true;
            this.dgvTxtTipoId.Visible = false;
            this.dgvTxtTipoId.Width = 125;
            // 
            // dgvIntId
            // 
            this.dgvIntId.HeaderText = "Código";
            this.dgvIntId.MinimumWidth = 6;
            this.dgvIntId.Name = "dgvIntId";
            this.dgvIntId.ReadOnly = true;
            this.dgvIntId.Width = 50;
            // 
            // dgvTxtCodPC
            // 
            this.dgvTxtCodPC.HeaderText = "Cod. ProvClientes";
            this.dgvTxtCodPC.MinimumWidth = 6;
            this.dgvTxtCodPC.Name = "dgvTxtCodPC";
            this.dgvTxtCodPC.ReadOnly = true;
            this.dgvTxtCodPC.Visible = false;
            this.dgvTxtCodPC.Width = 125;
            // 
            // dgvTxtPC
            // 
            this.dgvTxtPC.HeaderText = "Proveedor";
            this.dgvTxtPC.MinimumWidth = 6;
            this.dgvTxtPC.Name = "dgvTxtPC";
            this.dgvTxtPC.ReadOnly = true;
            this.dgvTxtPC.Width = 220;
            // 
            // dgvIntSecuencia
            // 
            this.dgvIntSecuencia.HeaderText = "Secuencia";
            this.dgvIntSecuencia.MinimumWidth = 6;
            this.dgvIntSecuencia.Name = "dgvIntSecuencia";
            this.dgvIntSecuencia.ReadOnly = true;
            this.dgvIntSecuencia.Width = 60;
            // 
            // dgvTxtCodNivel
            // 
            this.dgvTxtCodNivel.HeaderText = "Cod. Nivel";
            this.dgvTxtCodNivel.MinimumWidth = 6;
            this.dgvTxtCodNivel.Name = "dgvTxtCodNivel";
            this.dgvTxtCodNivel.ReadOnly = true;
            this.dgvTxtCodNivel.Visible = false;
            this.dgvTxtCodNivel.Width = 80;
            // 
            // dgvTxtCodGrupo
            // 
            this.dgvTxtCodGrupo.HeaderText = "Cod. Grupo";
            this.dgvTxtCodGrupo.MinimumWidth = 6;
            this.dgvTxtCodGrupo.Name = "dgvTxtCodGrupo";
            this.dgvTxtCodGrupo.ReadOnly = true;
            this.dgvTxtCodGrupo.Visible = false;
            this.dgvTxtCodGrupo.Width = 85;
            // 
            // dgvTxtCodTalla
            // 
            this.dgvTxtCodTalla.HeaderText = "Cod. Talla";
            this.dgvTxtCodTalla.MinimumWidth = 6;
            this.dgvTxtCodTalla.Name = "dgvTxtCodTalla";
            this.dgvTxtCodTalla.ReadOnly = true;
            this.dgvTxtCodTalla.Visible = false;
            this.dgvTxtCodTalla.Width = 70;
            // 
            // dgvTxtCodColor
            // 
            this.dgvTxtCodColor.HeaderText = "Cod. Color";
            this.dgvTxtCodColor.MinimumWidth = 6;
            this.dgvTxtCodColor.Name = "dgvTxtCodColor";
            this.dgvTxtCodColor.ReadOnly = true;
            this.dgvTxtCodColor.Visible = false;
            this.dgvTxtCodColor.Width = 75;
            // 
            // dgvCodigoProducto
            // 
            this.dgvCodigoProducto.HeaderText = "Codigo Producto";
            this.dgvCodigoProducto.MinimumWidth = 6;
            this.dgvCodigoProducto.Name = "dgvCodigoProducto";
            this.dgvCodigoProducto.ReadOnly = true;
            this.dgvCodigoProducto.Width = 125;
            // 
            // dgvTxtProducto
            // 
            this.dgvTxtProducto.HeaderText = "Producto";
            this.dgvTxtProducto.MinimumWidth = 6;
            this.dgvTxtProducto.Name = "dgvTxtProducto";
            this.dgvTxtProducto.ReadOnly = true;
            // 
            // dgvCodCuenta
            // 
            this.dgvCodCuenta.HeaderText = "Cta Contable";
            this.dgvCodCuenta.MinimumWidth = 6;
            this.dgvCodCuenta.Name = "dgvCodCuenta";
            this.dgvCodCuenta.ReadOnly = true;
            this.dgvCodCuenta.Width = 90;
            // 
            // dgvDescripcionCta
            // 
            this.dgvDescripcionCta.HeaderText = "Descripcion Cta";
            this.dgvDescripcionCta.MinimumWidth = 6;
            this.dgvDescripcionCta.Name = "dgvDescripcionCta";
            this.dgvDescripcionCta.ReadOnly = true;
            this.dgvDescripcionCta.Width = 125;
            // 
            // dgvIntCantidad
            // 
            this.dgvIntCantidad.HeaderText = "Cantidad";
            this.dgvIntCantidad.MinimumWidth = 6;
            this.dgvIntCantidad.Name = "dgvIntCantidad";
            this.dgvIntCantidad.ReadOnly = true;
            this.dgvIntCantidad.Width = 50;
            // 
            // dgvDecCantidadEntrada
            // 
            this.dgvDecCantidadEntrada.HeaderText = "Entrada";
            this.dgvDecCantidadEntrada.Name = "dgvDecCantidadEntrada";
            this.dgvDecCantidadEntrada.ReadOnly = true;
            // 
            // dgvDecCantidadSalida
            // 
            this.dgvDecCantidadSalida.HeaderText = "Salida";
            this.dgvDecCantidadSalida.Name = "dgvDecCantidadSalida";
            this.dgvDecCantidadSalida.ReadOnly = true;
            // 
            // dgvIntCantidadSaldo
            // 
            this.dgvIntCantidadSaldo.HeaderText = "Cantidad Saldo";
            this.dgvIntCantidadSaldo.MinimumWidth = 6;
            this.dgvIntCantidadSaldo.Name = "dgvIntCantidadSaldo";
            this.dgvIntCantidadSaldo.ReadOnly = true;
            this.dgvIntCantidadSaldo.Width = 125;
            // 
            // dgvTxtCodUM
            // 
            this.dgvTxtCodUM.HeaderText = "UM";
            this.dgvTxtCodUM.MinimumWidth = 6;
            this.dgvTxtCodUM.Name = "dgvTxtCodUM";
            this.dgvTxtCodUM.ReadOnly = true;
            this.dgvTxtCodUM.Width = 38;
            // 
            // dgvDecPrecioUnitario
            // 
            this.dgvDecPrecioUnitario.HeaderText = "P. Unitario";
            this.dgvDecPrecioUnitario.MinimumWidth = 6;
            this.dgvDecPrecioUnitario.Name = "dgvDecPrecioUnitario";
            this.dgvDecPrecioUnitario.ReadOnly = true;
            this.dgvDecPrecioUnitario.Width = 70;
            // 
            // dgvDecTotal
            // 
            this.dgvDecTotal.HeaderText = "Total";
            this.dgvDecTotal.MinimumWidth = 6;
            this.dgvDecTotal.Name = "dgvDecTotal";
            this.dgvDecTotal.ReadOnly = true;
            this.dgvDecTotal.Width = 60;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(7, 7);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Size = new System.Drawing.Size(145, 30);
            this.btnNuevo.TabIndex = 60;
            this.btnNuevo.Text = "Seleccionar Todos";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // BuscarOCGRView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(987, 456);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvOrdenCompra);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "BuscarOCGRView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Orden de Compra";
            this.Load += new System.EventHandler(this.BuscarOCGRView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BuscarOCGRView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdenCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntIdEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtTipoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntSecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCodCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDescripcionCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecCantidadEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecCantidadSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntCantidadSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecTotal;
        private System.Windows.Forms.Button btnNuevo;
    }
}