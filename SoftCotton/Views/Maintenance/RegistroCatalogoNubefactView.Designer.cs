namespace SoftCotton.Views.Maintenance
{
    partial class RegistroCatalogoNubefactView
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
            this.panelRegistro = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.codigoInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCategoria = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.codUm = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.codMoneda = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.descripcionCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ventaValorUnitarioSinIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ventaPrecioUnitarioIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compraValorUnitarioSinIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compraPrecioUnitarioIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destacado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tipoAfectacionIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codProductoSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockActualDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelCargarRegistros = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPaginacion = new System.Windows.Forms.ComboBox();
            this.txtde = new System.Windows.Forms.TextBox();
            this.txtnumero = new System.Windows.Forms.TextBox();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panelCargarRegistros.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRegistro
            // 
            this.panelRegistro.Controls.Add(this.btnBuscar);
            this.panelRegistro.Controls.Add(this.label5);
            this.panelRegistro.Controls.Add(this.txtFiltro);
            this.panelRegistro.Controls.Add(this.label1);
            this.panelRegistro.Controls.Add(this.dgvLista);
            this.panelRegistro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistro.Location = new System.Drawing.Point(0, 0);
            this.panelRegistro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRegistro.Name = "panelRegistro";
            this.panelRegistro.Size = new System.Drawing.Size(746, 501);
            this.panelRegistro.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catalogo Nubefact";
            // 
            // dgvLista
            // 
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoInterno,
            this.idCategoria,
            this.codUm,
            this.codMoneda,
            this.descripcionCatalogo,
            this.ventaValorUnitarioSinIgv,
            this.ventaPrecioUnitarioIgv,
            this.compraValorUnitarioSinIgv,
            this.compraPrecioUnitarioIgv,
            this.destacado,
            this.tipoAfectacionIgv,
            this.codProductoSunat,
            this.stockActualDisponible});
            this.dgvLista.Location = new System.Drawing.Point(2, 80);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.RowTemplate.Height = 28;
            this.dgvLista.Size = new System.Drawing.Size(742, 370);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_RowLeave);
            // 
            // codigoInterno
            // 
            this.codigoInterno.HeaderText = "Codigo Interno";
            this.codigoInterno.Name = "codigoInterno";
            this.codigoInterno.Width = 93;
            // 
            // idCategoria
            // 
            this.idCategoria.HeaderText = "Categoria";
            this.idCategoria.Name = "idCategoria";
            this.idCategoria.Width = 58;
            // 
            // codUm
            // 
            this.codUm.HeaderText = "Unidad Medida";
            this.codUm.Name = "codUm";
            this.codUm.Width = 77;
            // 
            // codMoneda
            // 
            this.codMoneda.HeaderText = "Moneda";
            this.codMoneda.Items.AddRange(new object[] {
            "1-SOLES",
            "2-DOLARES",
            "3-EUROS"});
            this.codMoneda.Name = "codMoneda";
            this.codMoneda.Width = 52;
            // 
            // descripcionCatalogo
            // 
            this.descripcionCatalogo.HeaderText = "Descripcion Catalogo";
            this.descripcionCatalogo.Name = "descripcionCatalogo";
            this.descripcionCatalogo.Width = 122;
            // 
            // ventaValorUnitarioSinIgv
            // 
            this.ventaValorUnitarioSinIgv.HeaderText = "Venta Valor Unitario Sin IGV";
            this.ventaValorUnitarioSinIgv.Name = "ventaValorUnitarioSinIgv";
            this.ventaValorUnitarioSinIgv.Width = 118;
            // 
            // ventaPrecioUnitarioIgv
            // 
            this.ventaPrecioUnitarioIgv.HeaderText = "Venta Precio Unitario Con IGV";
            this.ventaPrecioUnitarioIgv.Name = "ventaPrecioUnitarioIgv";
            this.ventaPrecioUnitarioIgv.Width = 123;
            // 
            // compraValorUnitarioSinIgv
            // 
            this.compraValorUnitarioSinIgv.HeaderText = "Compra Valor Unitario Sin IGV";
            this.compraValorUnitarioSinIgv.Name = "compraValorUnitarioSinIgv";
            this.compraValorUnitarioSinIgv.Width = 125;
            // 
            // compraPrecioUnitarioIgv
            // 
            this.compraPrecioUnitarioIgv.HeaderText = "Compra Precio Unitario Con IGV";
            this.compraPrecioUnitarioIgv.Name = "compraPrecioUnitarioIgv";
            this.compraPrecioUnitarioIgv.Width = 131;
            // 
            // destacado
            // 
            this.destacado.HeaderText = "Destacado";
            this.destacado.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.destacado.Name = "destacado";
            this.destacado.Width = 65;
            // 
            // tipoAfectacionIgv
            // 
            this.tipoAfectacionIgv.HeaderText = "Tipo Afectacion IGV";
            this.tipoAfectacionIgv.Name = "tipoAfectacionIgv";
            this.tipoAfectacionIgv.Width = 117;
            // 
            // codProductoSunat
            // 
            this.codProductoSunat.HeaderText = "Codigo Producto Sunat";
            this.codProductoSunat.Name = "codProductoSunat";
            this.codProductoSunat.Width = 130;
            // 
            // stockActualDisponible
            // 
            this.stockActualDisponible.HeaderText = "Stock Actual Disponible";
            this.stockActualDisponible.Name = "stockActualDisponible";
            this.stockActualDisponible.Width = 132;
            // 
            // panelCargarRegistros
            // 
            this.panelCargarRegistros.Controls.Add(this.label4);
            this.panelCargarRegistros.Controls.Add(this.label3);
            this.panelCargarRegistros.Controls.Add(this.label2);
            this.panelCargarRegistros.Controls.Add(this.cboPaginacion);
            this.panelCargarRegistros.Controls.Add(this.txtde);
            this.panelCargarRegistros.Controls.Add(this.txtnumero);
            this.panelCargarRegistros.Controls.Add(this.btnCargarArchivo);
            this.panelCargarRegistros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCargarRegistros.Location = new System.Drawing.Point(0, 454);
            this.panelCargarRegistros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCargarRegistros.Name = "panelCargarRegistros";
            this.panelCargarRegistros.Size = new System.Drawing.Size(746, 47);
            this.panelCargarRegistros.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "de:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Paginación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nro:";
            // 
            // cboPaginacion
            // 
            this.cboPaginacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaginacion.FormattingEnabled = true;
            this.cboPaginacion.Location = new System.Drawing.Point(277, 15);
            this.cboPaginacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboPaginacion.Name = "cboPaginacion";
            this.cboPaginacion.Size = new System.Drawing.Size(129, 21);
            this.cboPaginacion.TabIndex = 3;
            this.cboPaginacion.SelectedIndexChanged += new System.EventHandler(this.cboPaginacion_SelectedIndexChanged);
            this.cboPaginacion.SelectionChangeCommitted += new System.EventHandler(this.cboPaginacion_SelectionChangeCommitted);
            // 
            // txtde
            // 
            this.txtde.Location = new System.Drawing.Point(497, 15);
            this.txtde.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtde.Name = "txtde";
            this.txtde.Size = new System.Drawing.Size(68, 20);
            this.txtde.TabIndex = 2;
            // 
            // txtnumero
            // 
            this.txtnumero.Location = new System.Drawing.Point(80, 16);
            this.txtnumero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtnumero.Name = "txtnumero";
            this.txtnumero.ReadOnly = true;
            this.txtnumero.Size = new System.Drawing.Size(68, 20);
            this.txtnumero.TabIndex = 1;
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Location = new System.Drawing.Point(599, 8);
            this.btnCargarArchivo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(137, 31);
            this.btnCargarArchivo.TabIndex = 0;
            this.btnCargarArchivo.Text = "Cargar Archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(3, 52);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(174, 20);
            this.txtFiltro.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Filtro";
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(186, 52);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 21);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // RegistroCatalogoNubefactView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 501);
            this.Controls.Add(this.panelCargarRegistros);
            this.Controls.Add(this.panelRegistro);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegistroCatalogoNubefactView";
            this.Text = "Registro Catalogo Nubefact";
            this.Load += new System.EventHandler(this.RegistroCatalogoNubefactView_Load);
            this.panelRegistro.ResumeLayout(false);
            this.panelRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panelCargarRegistros.ResumeLayout(false);
            this.panelCargarRegistros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRegistro;
        private System.Windows.Forms.Panel panelCargarRegistros;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoInterno;
        private System.Windows.Forms.DataGridViewComboBoxColumn idCategoria;
        private System.Windows.Forms.DataGridViewComboBoxColumn codUm;
        private System.Windows.Forms.DataGridViewComboBoxColumn codMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ventaValorUnitarioSinIgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ventaPrecioUnitarioIgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn compraValorUnitarioSinIgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn compraPrecioUnitarioIgv;
        private System.Windows.Forms.DataGridViewComboBoxColumn destacado;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoAfectacionIgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProductoSunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActualDisponible;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPaginacion;
        private System.Windows.Forms.TextBox txtde;
        private System.Windows.Forms.TextBox txtnumero;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFiltro;
    }
}