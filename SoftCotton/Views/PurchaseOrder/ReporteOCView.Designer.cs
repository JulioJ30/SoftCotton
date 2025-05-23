﻿namespace SoftCotton.Views.PurchaseOrder
{
    partial class ReporteOCView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteOCView));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvidEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvidOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvfechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvfechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcodigoPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrazonsocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtipoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtipoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcondicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvestadooc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvusuCreacionReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvusuFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvobservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcodNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcodGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcodTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcodColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcodProductoGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcolor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvobs1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvobs2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvobs3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvobs4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvobs5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcodUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvigv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvprecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvidEmpresa,
            this.dgvidOC,
            this.dgvfechaEmision,
            this.dgvfechaEntrega,
            this.dgvcodigoPC,
            this.dgvrazonsocial,
            this.dgvtipoMoneda,
            this.dgvtipoCompra,
            this.dgvcondicion,
            this.dgvestadooc,
            this.dgvusuCreacionReg,
            this.dgvusuFechaReg,
            this.dgvobservacion,
            this.dgvcodNivel,
            this.dgvcodGrupo,
            this.dgvcodTalla,
            this.dgvcodColor,
            this.dgvcodProductoGeneral,
            this.dgvproducto,
            this.dgvcolor,
            this.dgvobs1,
            this.dgvobs2,
            this.dgvobs3,
            this.dgvobs4,
            this.dgvobs5,
            this.dgvcantidad,
            this.dgvcodUM,
            this.dgvigv,
            this.dgvprecioUnitario,
            this.dgvtotal,
            this.programa});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 82);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersWidth = 62;
            this.dgvListado.Size = new System.Drawing.Size(972, 426);
            this.dgvListado.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(972, 82);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por Fechas";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(818, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 46);
            this.panel2.TabIndex = 59;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SoftCotton.Properties.Resources.icon_excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(46, 11);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnExcel.Size = new System.Drawing.Size(92, 25);
            this.btnExcel.TabIndex = 58;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(414, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnBuscar.Size = new System.Drawing.Size(92, 25);
            this.btnBuscar.TabIndex = 57;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(276, 28);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(109, 29);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(86, 28);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(109, 29);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Fin: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio: ";
            // 
            // dgvidEmpresa
            // 
            this.dgvidEmpresa.HeaderText = "ID Empresa";
            this.dgvidEmpresa.MinimumWidth = 8;
            this.dgvidEmpresa.Name = "dgvidEmpresa";
            this.dgvidEmpresa.ReadOnly = true;
            this.dgvidEmpresa.Width = 150;
            // 
            // dgvidOC
            // 
            this.dgvidOC.HeaderText = "OC";
            this.dgvidOC.MinimumWidth = 8;
            this.dgvidOC.Name = "dgvidOC";
            this.dgvidOC.ReadOnly = true;
            this.dgvidOC.Width = 150;
            // 
            // dgvfechaEmision
            // 
            this.dgvfechaEmision.HeaderText = "Fecha Emisión";
            this.dgvfechaEmision.MinimumWidth = 8;
            this.dgvfechaEmision.Name = "dgvfechaEmision";
            this.dgvfechaEmision.ReadOnly = true;
            this.dgvfechaEmision.Width = 150;
            // 
            // dgvfechaEntrega
            // 
            this.dgvfechaEntrega.HeaderText = "Fecha Entrega";
            this.dgvfechaEntrega.MinimumWidth = 8;
            this.dgvfechaEntrega.Name = "dgvfechaEntrega";
            this.dgvfechaEntrega.ReadOnly = true;
            this.dgvfechaEntrega.Width = 150;
            // 
            // dgvcodigoPC
            // 
            this.dgvcodigoPC.HeaderText = "RUC";
            this.dgvcodigoPC.MinimumWidth = 8;
            this.dgvcodigoPC.Name = "dgvcodigoPC";
            this.dgvcodigoPC.ReadOnly = true;
            this.dgvcodigoPC.Width = 150;
            // 
            // dgvrazonsocial
            // 
            this.dgvrazonsocial.HeaderText = "Razon Social";
            this.dgvrazonsocial.MinimumWidth = 8;
            this.dgvrazonsocial.Name = "dgvrazonsocial";
            this.dgvrazonsocial.ReadOnly = true;
            this.dgvrazonsocial.Width = 150;
            // 
            // dgvtipoMoneda
            // 
            this.dgvtipoMoneda.HeaderText = "Moneda";
            this.dgvtipoMoneda.MinimumWidth = 8;
            this.dgvtipoMoneda.Name = "dgvtipoMoneda";
            this.dgvtipoMoneda.ReadOnly = true;
            this.dgvtipoMoneda.Width = 150;
            // 
            // dgvtipoCompra
            // 
            this.dgvtipoCompra.HeaderText = "Tipo Compra";
            this.dgvtipoCompra.MinimumWidth = 8;
            this.dgvtipoCompra.Name = "dgvtipoCompra";
            this.dgvtipoCompra.ReadOnly = true;
            this.dgvtipoCompra.Width = 150;
            // 
            // dgvcondicion
            // 
            this.dgvcondicion.HeaderText = "Condición Pago";
            this.dgvcondicion.MinimumWidth = 8;
            this.dgvcondicion.Name = "dgvcondicion";
            this.dgvcondicion.ReadOnly = true;
            this.dgvcondicion.Width = 150;
            // 
            // dgvestadooc
            // 
            this.dgvestadooc.HeaderText = "Estado OC";
            this.dgvestadooc.MinimumWidth = 8;
            this.dgvestadooc.Name = "dgvestadooc";
            this.dgvestadooc.ReadOnly = true;
            this.dgvestadooc.Width = 150;
            // 
            // dgvusuCreacionReg
            // 
            this.dgvusuCreacionReg.HeaderText = "Usuario Registro";
            this.dgvusuCreacionReg.MinimumWidth = 8;
            this.dgvusuCreacionReg.Name = "dgvusuCreacionReg";
            this.dgvusuCreacionReg.ReadOnly = true;
            this.dgvusuCreacionReg.Width = 150;
            // 
            // dgvusuFechaReg
            // 
            this.dgvusuFechaReg.HeaderText = "Fecha Registro OC";
            this.dgvusuFechaReg.MinimumWidth = 8;
            this.dgvusuFechaReg.Name = "dgvusuFechaReg";
            this.dgvusuFechaReg.ReadOnly = true;
            this.dgvusuFechaReg.Width = 150;
            // 
            // dgvobservacion
            // 
            this.dgvobservacion.HeaderText = "Observacion";
            this.dgvobservacion.MinimumWidth = 8;
            this.dgvobservacion.Name = "dgvobservacion";
            this.dgvobservacion.ReadOnly = true;
            this.dgvobservacion.Width = 150;
            // 
            // dgvcodNivel
            // 
            this.dgvcodNivel.HeaderText = "Cod. Nivel";
            this.dgvcodNivel.MinimumWidth = 8;
            this.dgvcodNivel.Name = "dgvcodNivel";
            this.dgvcodNivel.ReadOnly = true;
            this.dgvcodNivel.Width = 150;
            // 
            // dgvcodGrupo
            // 
            this.dgvcodGrupo.HeaderText = "Cod. Grupo";
            this.dgvcodGrupo.MinimumWidth = 8;
            this.dgvcodGrupo.Name = "dgvcodGrupo";
            this.dgvcodGrupo.ReadOnly = true;
            this.dgvcodGrupo.Width = 150;
            // 
            // dgvcodTalla
            // 
            this.dgvcodTalla.HeaderText = "Cod. Talla";
            this.dgvcodTalla.MinimumWidth = 8;
            this.dgvcodTalla.Name = "dgvcodTalla";
            this.dgvcodTalla.ReadOnly = true;
            this.dgvcodTalla.Width = 150;
            // 
            // dgvcodColor
            // 
            this.dgvcodColor.HeaderText = "Cod. Color";
            this.dgvcodColor.MinimumWidth = 8;
            this.dgvcodColor.Name = "dgvcodColor";
            this.dgvcodColor.ReadOnly = true;
            this.dgvcodColor.Width = 150;
            // 
            // dgvcodProductoGeneral
            // 
            this.dgvcodProductoGeneral.HeaderText = "Cod. Producto General";
            this.dgvcodProductoGeneral.MinimumWidth = 8;
            this.dgvcodProductoGeneral.Name = "dgvcodProductoGeneral";
            this.dgvcodProductoGeneral.ReadOnly = true;
            this.dgvcodProductoGeneral.Width = 150;
            // 
            // dgvproducto
            // 
            this.dgvproducto.HeaderText = "Producto";
            this.dgvproducto.MinimumWidth = 8;
            this.dgvproducto.Name = "dgvproducto";
            this.dgvproducto.ReadOnly = true;
            this.dgvproducto.Width = 150;
            // 
            // dgvcolor
            // 
            this.dgvcolor.HeaderText = "Color";
            this.dgvcolor.MinimumWidth = 8;
            this.dgvcolor.Name = "dgvcolor";
            this.dgvcolor.ReadOnly = true;
            this.dgvcolor.Width = 150;
            // 
            // dgvobs1
            // 
            this.dgvobs1.HeaderText = "Observacion 1";
            this.dgvobs1.MinimumWidth = 8;
            this.dgvobs1.Name = "dgvobs1";
            this.dgvobs1.ReadOnly = true;
            this.dgvobs1.Width = 150;
            // 
            // dgvobs2
            // 
            this.dgvobs2.HeaderText = "Observacion 2";
            this.dgvobs2.MinimumWidth = 8;
            this.dgvobs2.Name = "dgvobs2";
            this.dgvobs2.ReadOnly = true;
            this.dgvobs2.Width = 150;
            // 
            // dgvobs3
            // 
            this.dgvobs3.HeaderText = "Observacion 3";
            this.dgvobs3.MinimumWidth = 8;
            this.dgvobs3.Name = "dgvobs3";
            this.dgvobs3.ReadOnly = true;
            this.dgvobs3.Width = 150;
            // 
            // dgvobs4
            // 
            this.dgvobs4.HeaderText = "Observacion 4";
            this.dgvobs4.MinimumWidth = 8;
            this.dgvobs4.Name = "dgvobs4";
            this.dgvobs4.ReadOnly = true;
            this.dgvobs4.Width = 150;
            // 
            // dgvobs5
            // 
            this.dgvobs5.HeaderText = "Observacion 5";
            this.dgvobs5.MinimumWidth = 8;
            this.dgvobs5.Name = "dgvobs5";
            this.dgvobs5.ReadOnly = true;
            this.dgvobs5.Width = 150;
            // 
            // dgvcantidad
            // 
            this.dgvcantidad.HeaderText = "Cantidad";
            this.dgvcantidad.MinimumWidth = 8;
            this.dgvcantidad.Name = "dgvcantidad";
            this.dgvcantidad.ReadOnly = true;
            this.dgvcantidad.Width = 150;
            // 
            // dgvcodUM
            // 
            this.dgvcodUM.HeaderText = "Cod. UM";
            this.dgvcodUM.MinimumWidth = 8;
            this.dgvcodUM.Name = "dgvcodUM";
            this.dgvcodUM.ReadOnly = true;
            this.dgvcodUM.Width = 150;
            // 
            // dgvigv
            // 
            this.dgvigv.HeaderText = "IGV";
            this.dgvigv.MinimumWidth = 8;
            this.dgvigv.Name = "dgvigv";
            this.dgvigv.ReadOnly = true;
            this.dgvigv.Width = 150;
            // 
            // dgvprecioUnitario
            // 
            this.dgvprecioUnitario.HeaderText = "Precio Unitario";
            this.dgvprecioUnitario.MinimumWidth = 8;
            this.dgvprecioUnitario.Name = "dgvprecioUnitario";
            this.dgvprecioUnitario.ReadOnly = true;
            this.dgvprecioUnitario.Width = 150;
            // 
            // dgvtotal
            // 
            this.dgvtotal.HeaderText = "Total";
            this.dgvtotal.MinimumWidth = 8;
            this.dgvtotal.Name = "dgvtotal";
            this.dgvtotal.ReadOnly = true;
            this.dgvtotal.Width = 150;
            // 
            // programa
            // 
            this.programa.HeaderText = "Programa";
            this.programa.MinimumWidth = 8;
            this.programa.Name = "programa";
            this.programa.ReadOnly = true;
            this.programa.Width = 150;
            // 
            // ReporteOCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(972, 508);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteOCView";
            this.Text = "Reporte de Ordenes de Compra";
            this.Load += new System.EventHandler(this.ReporteOCView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvidEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvidOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvfechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvfechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcodigoPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvrazonsocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtipoMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtipoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcondicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvestadooc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvusuCreacionReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvusuFechaReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvobservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcodNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcodGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcodTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcodColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcodProductoGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcolor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvobs1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvobs2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvobs3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvobs4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvobs5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcodUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvigv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvprecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn programa;
    }
}