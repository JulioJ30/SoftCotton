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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvIntIdEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvIntIdEmpresa,
            this.cbxSeleccionar,
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
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListado.Location = new System.Drawing.Point(4, 95);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersWidth = 62;
            this.dgvListado.Size = new System.Drawing.Size(915, 397);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::SoftCotton.Properties.Resources.icon_checked;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(764, 28);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Size = new System.Drawing.Size(145, 30);
            this.btnAgregar.TabIndex = 63;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(6, 28);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Size = new System.Drawing.Size(195, 30);
            this.btnNuevo.TabIndex = 62;
            this.btnNuevo.Text = "Seleccionar Todos";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvIntIdEmpresa
            // 
            this.dgvIntIdEmpresa.HeaderText = "ID Empresa";
            this.dgvIntIdEmpresa.MinimumWidth = 8;
            this.dgvIntIdEmpresa.Name = "dgvIntIdEmpresa";
            this.dgvIntIdEmpresa.ReadOnly = true;
            this.dgvIntIdEmpresa.Visible = false;
            this.dgvIntIdEmpresa.Width = 150;
            // 
            // cbxSeleccionar
            // 
            this.cbxSeleccionar.HeaderText = "X";
            this.cbxSeleccionar.MinimumWidth = 8;
            this.cbxSeleccionar.Name = "cbxSeleccionar";
            this.cbxSeleccionar.ReadOnly = true;
            this.cbxSeleccionar.Width = 50;
            // 
            // dgvTxtTipo
            // 
            this.dgvTxtTipo.HeaderText = "OC / OS";
            this.dgvTxtTipo.MinimumWidth = 8;
            this.dgvTxtTipo.Name = "dgvTxtTipo";
            this.dgvTxtTipo.ReadOnly = true;
            this.dgvTxtTipo.Width = 120;
            // 
            // dgvTxtSerie
            // 
            this.dgvTxtSerie.HeaderText = "GR - Serie";
            this.dgvTxtSerie.MinimumWidth = 8;
            this.dgvTxtSerie.Name = "dgvTxtSerie";
            this.dgvTxtSerie.ReadOnly = true;
            this.dgvTxtSerie.Width = 150;
            // 
            // dgvTxtNumero
            // 
            this.dgvTxtNumero.HeaderText = "GR - Numero";
            this.dgvTxtNumero.MinimumWidth = 8;
            this.dgvTxtNumero.Name = "dgvTxtNumero";
            this.dgvTxtNumero.ReadOnly = true;
            this.dgvTxtNumero.Width = 150;
            // 
            // dgvIntSecuencia
            // 
            this.dgvIntSecuencia.HeaderText = "GR - Secuencia ";
            this.dgvIntSecuencia.MinimumWidth = 8;
            this.dgvIntSecuencia.Name = "dgvIntSecuencia";
            this.dgvIntSecuencia.ReadOnly = true;
            this.dgvIntSecuencia.Width = 150;
            // 
            // dgvTxtFechaEmision
            // 
            this.dgvTxtFechaEmision.HeaderText = "GR - F. Emisión";
            this.dgvTxtFechaEmision.MinimumWidth = 8;
            this.dgvTxtFechaEmision.Name = "dgvTxtFechaEmision";
            this.dgvTxtFechaEmision.ReadOnly = true;
            this.dgvTxtFechaEmision.Width = 150;
            // 
            // dgvTxtDestCodigoPC
            // 
            this.dgvTxtDestCodigoPC.HeaderText = "RUC Destino";
            this.dgvTxtDestCodigoPC.MinimumWidth = 8;
            this.dgvTxtDestCodigoPC.Name = "dgvTxtDestCodigoPC";
            this.dgvTxtDestCodigoPC.ReadOnly = true;
            this.dgvTxtDestCodigoPC.Visible = false;
            this.dgvTxtDestCodigoPC.Width = 150;
            // 
            // dgvTxtRazonSocial
            // 
            this.dgvTxtRazonSocial.HeaderText = "Razón Social - Proveedor Destino";
            this.dgvTxtRazonSocial.MinimumWidth = 8;
            this.dgvTxtRazonSocial.Name = "dgvTxtRazonSocial";
            this.dgvTxtRazonSocial.ReadOnly = true;
            this.dgvTxtRazonSocial.Visible = false;
            this.dgvTxtRazonSocial.Width = 150;
            // 
            // dgvTxtProveedor
            // 
            this.dgvTxtProveedor.HeaderText = "GR - Proveedor Destino";
            this.dgvTxtProveedor.MinimumWidth = 8;
            this.dgvTxtProveedor.Name = "dgvTxtProveedor";
            this.dgvTxtProveedor.ReadOnly = true;
            this.dgvTxtProveedor.Width = 150;
            // 
            // dgvIntIdDet
            // 
            this.dgvIntIdDet.HeaderText = "Codigo";
            this.dgvIntIdDet.MinimumWidth = 8;
            this.dgvIntIdDet.Name = "dgvIntIdDet";
            this.dgvIntIdDet.ReadOnly = true;
            this.dgvIntIdDet.Width = 150;
            // 
            // dgvIntIdSecuenciaDet
            // 
            this.dgvIntIdSecuenciaDet.HeaderText = "Secuencia";
            this.dgvIntIdSecuenciaDet.MinimumWidth = 8;
            this.dgvIntIdSecuenciaDet.Name = "dgvIntIdSecuenciaDet";
            this.dgvIntIdSecuenciaDet.ReadOnly = true;
            this.dgvIntIdSecuenciaDet.Width = 150;
            // 
            // dgvTxtCodNivel
            // 
            this.dgvTxtCodNivel.HeaderText = "Cod. Nivel";
            this.dgvTxtCodNivel.MinimumWidth = 8;
            this.dgvTxtCodNivel.Name = "dgvTxtCodNivel";
            this.dgvTxtCodNivel.ReadOnly = true;
            this.dgvTxtCodNivel.Visible = false;
            this.dgvTxtCodNivel.Width = 150;
            // 
            // dgvTxtCodGrupo
            // 
            this.dgvTxtCodGrupo.HeaderText = "Cod. Grupo";
            this.dgvTxtCodGrupo.MinimumWidth = 8;
            this.dgvTxtCodGrupo.Name = "dgvTxtCodGrupo";
            this.dgvTxtCodGrupo.ReadOnly = true;
            this.dgvTxtCodGrupo.Visible = false;
            this.dgvTxtCodGrupo.Width = 150;
            // 
            // dgvTxtCodTalla
            // 
            this.dgvTxtCodTalla.HeaderText = "Cod. Talla";
            this.dgvTxtCodTalla.MinimumWidth = 8;
            this.dgvTxtCodTalla.Name = "dgvTxtCodTalla";
            this.dgvTxtCodTalla.ReadOnly = true;
            this.dgvTxtCodTalla.Visible = false;
            this.dgvTxtCodTalla.Width = 150;
            // 
            // dgvTxtCodColor
            // 
            this.dgvTxtCodColor.HeaderText = "Cod. Color";
            this.dgvTxtCodColor.MinimumWidth = 8;
            this.dgvTxtCodColor.Name = "dgvTxtCodColor";
            this.dgvTxtCodColor.ReadOnly = true;
            this.dgvTxtCodColor.Visible = false;
            this.dgvTxtCodColor.Width = 150;
            // 
            // dgvTxtCodProducto
            // 
            this.dgvTxtCodProducto.HeaderText = "Cod. Producto";
            this.dgvTxtCodProducto.MinimumWidth = 8;
            this.dgvTxtCodProducto.Name = "dgvTxtCodProducto";
            this.dgvTxtCodProducto.ReadOnly = true;
            this.dgvTxtCodProducto.Width = 150;
            // 
            // dgvTxtProducto
            // 
            this.dgvTxtProducto.HeaderText = "Producto";
            this.dgvTxtProducto.MinimumWidth = 8;
            this.dgvTxtProducto.Name = "dgvTxtProducto";
            this.dgvTxtProducto.ReadOnly = true;
            this.dgvTxtProducto.Width = 150;
            // 
            // dgvTxtCodUM
            // 
            this.dgvTxtCodUM.HeaderText = "UM";
            this.dgvTxtCodUM.MinimumWidth = 8;
            this.dgvTxtCodUM.Name = "dgvTxtCodUM";
            this.dgvTxtCodUM.ReadOnly = true;
            this.dgvTxtCodUM.Width = 150;
            // 
            // dgvTxtTipoMovimiento
            // 
            this.dgvTxtTipoMovimiento.HeaderText = "GR - Tipo Movimiento";
            this.dgvTxtTipoMovimiento.MinimumWidth = 8;
            this.dgvTxtTipoMovimiento.Name = "dgvTxtTipoMovimiento";
            this.dgvTxtTipoMovimiento.ReadOnly = true;
            this.dgvTxtTipoMovimiento.Width = 150;
            // 
            // dgvTxtGrTipo
            // 
            this.dgvTxtGrTipo.HeaderText = "TIPO OC/OS";
            this.dgvTxtGrTipo.MinimumWidth = 8;
            this.dgvTxtGrTipo.Name = "dgvTxtGrTipo";
            this.dgvTxtGrTipo.ReadOnly = true;
            this.dgvTxtGrTipo.Width = 150;
            // 
            // dgvDecCantidadIngresada
            // 
            this.dgvDecCantidadIngresada.HeaderText = "GR- Cant. Ingresada";
            this.dgvDecCantidadIngresada.MinimumWidth = 8;
            this.dgvDecCantidadIngresada.Name = "dgvDecCantidadIngresada";
            this.dgvDecCantidadIngresada.ReadOnly = true;
            this.dgvDecCantidadIngresada.Width = 150;
            // 
            // dgvDecPesoIngresado
            // 
            this.dgvDecPesoIngresado.HeaderText = "GR - Peso Ingresado";
            this.dgvDecPesoIngresado.MinimumWidth = 8;
            this.dgvDecPesoIngresado.Name = "dgvDecPesoIngresado";
            this.dgvDecPesoIngresado.ReadOnly = true;
            this.dgvDecPesoIngresado.Width = 150;
            // 
            // BuscarGuiaRemisionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(923, 496);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvListado);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "BuscarGuiaRemisionView";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Busqueda de Guía de Remisión";
            this.Load += new System.EventHandler(this.BuscarGuiaRemisionView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIntIdEmpresa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbxSeleccionar;
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