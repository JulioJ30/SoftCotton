namespace SoftCotton.Views.Shared
{
    partial class BuscarGuiaRemisionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarGuiaRemisionView));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.dgvIntIdEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIntSecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtFechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtDestCodigoPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIntIdDet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIntIdSecuenciaDet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCodUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtTipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtGrTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecCantidadIngresada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecPesoIngresado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvIntIdEmpresa,
            this.dgvTxtTipo,
            this.dgvTxtSerie,
            this.dgvTxtNumero,
            this.dgvIntSecuencia,
            this.dgvTxtFechaEmision,
            this.dgvTxtDestCodigoPC,
            this.dgvTxtRazonSocial,
            this.dgvTxtProveedor,
            this.dgvIntIdDet,
            this.dgvIntIdSecuenciaDet,
            this.dgvTxtCodNivel,
            this.dgvTxtCodGrupo,
            this.dgvTxtCodTalla,
            this.dgvTxtCodColor,
            this.dgvTxtCodProducto,
            this.dgvTxtProducto,
            this.dgvTxtCodUM,
            this.dgvTxtTipoMovimiento,
            this.dgvTxtGrTipo,
            this.dgvDecCantidadIngresada,
            this.dgvDecPesoIngresado});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(4, 4);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(891, 397);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // dgvIntIdEmpresa
            // 
            this.dgvIntIdEmpresa.HeaderText = "ID Empresa";
            this.dgvIntIdEmpresa.Name = "dgvIntIdEmpresa";
            this.dgvIntIdEmpresa.ReadOnly = true;
            this.dgvIntIdEmpresa.Visible = false;
            // 
            // dgvTxtTipo
            // 
            this.dgvTxtTipo.HeaderText = "OC / OS";
            this.dgvTxtTipo.Name = "dgvTxtTipo";
            this.dgvTxtTipo.ReadOnly = true;
            this.dgvTxtTipo.Width = 120;
            // 
            // dgvTxtSerie
            // 
            this.dgvTxtSerie.HeaderText = "GR - Serie";
            this.dgvTxtSerie.Name = "dgvTxtSerie";
            this.dgvTxtSerie.ReadOnly = true;
            // 
            // dgvTxtNumero
            // 
            this.dgvTxtNumero.HeaderText = "GR - Numero";
            this.dgvTxtNumero.Name = "dgvTxtNumero";
            this.dgvTxtNumero.ReadOnly = true;
            // 
            // dgvIntSecuencia
            // 
            this.dgvIntSecuencia.HeaderText = "GR - Secuencia ";
            this.dgvIntSecuencia.Name = "dgvIntSecuencia";
            this.dgvIntSecuencia.ReadOnly = true;
            // 
            // dgvTxtFechaEmision
            // 
            this.dgvTxtFechaEmision.HeaderText = "GR - F. Emisión";
            this.dgvTxtFechaEmision.Name = "dgvTxtFechaEmision";
            this.dgvTxtFechaEmision.ReadOnly = true;
            // 
            // dgvTxtDestCodigoPC
            // 
            this.dgvTxtDestCodigoPC.HeaderText = "RUC Destino";
            this.dgvTxtDestCodigoPC.Name = "dgvTxtDestCodigoPC";
            this.dgvTxtDestCodigoPC.ReadOnly = true;
            this.dgvTxtDestCodigoPC.Visible = false;
            // 
            // dgvTxtRazonSocial
            // 
            this.dgvTxtRazonSocial.HeaderText = "Razón Social - Proveedor Destino";
            this.dgvTxtRazonSocial.Name = "dgvTxtRazonSocial";
            this.dgvTxtRazonSocial.ReadOnly = true;
            this.dgvTxtRazonSocial.Visible = false;
            // 
            // dgvTxtProveedor
            // 
            this.dgvTxtProveedor.HeaderText = "GR - Proveedor Destino";
            this.dgvTxtProveedor.Name = "dgvTxtProveedor";
            this.dgvTxtProveedor.ReadOnly = true;
            // 
            // dgvIntIdDet
            // 
            this.dgvIntIdDet.HeaderText = "Codigo";
            this.dgvIntIdDet.Name = "dgvIntIdDet";
            this.dgvIntIdDet.ReadOnly = true;
            // 
            // dgvIntIdSecuenciaDet
            // 
            this.dgvIntIdSecuenciaDet.HeaderText = "Secuencia";
            this.dgvIntIdSecuenciaDet.Name = "dgvIntIdSecuenciaDet";
            this.dgvIntIdSecuenciaDet.ReadOnly = true;
            // 
            // dgvTxtCodNivel
            // 
            this.dgvTxtCodNivel.HeaderText = "Cod. Nivel";
            this.dgvTxtCodNivel.Name = "dgvTxtCodNivel";
            this.dgvTxtCodNivel.ReadOnly = true;
            this.dgvTxtCodNivel.Visible = false;
            // 
            // dgvTxtCodGrupo
            // 
            this.dgvTxtCodGrupo.HeaderText = "Cod. Grupo";
            this.dgvTxtCodGrupo.Name = "dgvTxtCodGrupo";
            this.dgvTxtCodGrupo.ReadOnly = true;
            this.dgvTxtCodGrupo.Visible = false;
            // 
            // dgvTxtCodTalla
            // 
            this.dgvTxtCodTalla.HeaderText = "Cod. Talla";
            this.dgvTxtCodTalla.Name = "dgvTxtCodTalla";
            this.dgvTxtCodTalla.ReadOnly = true;
            this.dgvTxtCodTalla.Visible = false;
            // 
            // dgvTxtCodColor
            // 
            this.dgvTxtCodColor.HeaderText = "Cod. Color";
            this.dgvTxtCodColor.Name = "dgvTxtCodColor";
            this.dgvTxtCodColor.ReadOnly = true;
            this.dgvTxtCodColor.Visible = false;
            // 
            // dgvTxtCodProducto
            // 
            this.dgvTxtCodProducto.HeaderText = "Cod. Producto";
            this.dgvTxtCodProducto.Name = "dgvTxtCodProducto";
            this.dgvTxtCodProducto.ReadOnly = true;
            // 
            // dgvTxtProducto
            // 
            this.dgvTxtProducto.HeaderText = "Producto";
            this.dgvTxtProducto.Name = "dgvTxtProducto";
            this.dgvTxtProducto.ReadOnly = true;
            // 
            // dgvTxtCodUM
            // 
            this.dgvTxtCodUM.HeaderText = "UM";
            this.dgvTxtCodUM.Name = "dgvTxtCodUM";
            this.dgvTxtCodUM.ReadOnly = true;
            // 
            // dgvTxtTipoMovimiento
            // 
            this.dgvTxtTipoMovimiento.HeaderText = "GR - Tipo Movimiento";
            this.dgvTxtTipoMovimiento.Name = "dgvTxtTipoMovimiento";
            this.dgvTxtTipoMovimiento.ReadOnly = true;
            // 
            // dgvTxtGrTipo
            // 
            this.dgvTxtGrTipo.HeaderText = "TIPO OC/OS";
            this.dgvTxtGrTipo.Name = "dgvTxtGrTipo";
            this.dgvTxtGrTipo.ReadOnly = true;
            // 
            // dgvDecCantidadIngresada
            // 
            this.dgvDecCantidadIngresada.HeaderText = "GR- Cant. Ingresada";
            this.dgvDecCantidadIngresada.Name = "dgvDecCantidadIngresada";
            this.dgvDecCantidadIngresada.ReadOnly = true;
            // 
            // dgvDecPesoIngresado
            // 
            this.dgvDecPesoIngresado.HeaderText = "GR - Peso Ingresado";
            this.dgvDecPesoIngresado.Name = "dgvDecPesoIngresado";
            this.dgvDecPesoIngresado.ReadOnly = true;
            // 
            // BuscarGuiaRemisionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(899, 405);
            this.Controls.Add(this.dgvListado);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "BuscarGuiaRemisionView";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Busqueda de Guía de Remisión";
            this.Load += new System.EventHandler(this.BuscarGuiaRemisionView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntIdEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntSecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtFechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtDestCodigoPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntIdDet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntIdSecuenciaDet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCodUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtTipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtGrTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecCantidadIngresada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecPesoIngresado;
    }
}