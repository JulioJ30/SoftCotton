namespace SoftCotton.Views.Movimientos
{
    partial class TransformacionTallas
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
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnBuscarTalla = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTalla = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.DgvIdTransformacionDetTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIdTransformacionDet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvCodTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvDescripcionTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvbtnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregarItem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.btnBuscarTalla);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTalla);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de Tallas";
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnAgregarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarItem.Location = new System.Drawing.Point(553, 73);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnAgregarItem.Size = new System.Drawing.Size(127, 33);
            this.btnAgregarItem.TabIndex = 62;
            this.btnAgregarItem.Text = "Agregar Item";
            this.btnAgregarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 61;
            this.label2.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(296, 45);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(384, 22);
            this.txtObservacion.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 59;
            this.label1.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(172, 45);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(118, 22);
            this.txtCantidad.TabIndex = 58;
            // 
            // btnBuscarTalla
            // 
            this.btnBuscarTalla.Image = global::SoftCotton.Properties.Resources.icon_buscar;
            this.btnBuscarTalla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarTalla.Location = new System.Drawing.Point(131, 40);
            this.btnBuscarTalla.Name = "btnBuscarTalla";
            this.btnBuscarTalla.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnBuscarTalla.Size = new System.Drawing.Size(35, 33);
            this.btnBuscarTalla.TabIndex = 57;
            this.btnBuscarTalla.UseVisualStyleBackColor = true;
            this.btnBuscarTalla.Click += new System.EventHandler(this.btnBuscarTalla_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Talla";
            // 
            // txtTalla
            // 
            this.txtTalla.Location = new System.Drawing.Point(17, 45);
            this.txtTalla.Name = "txtTalla";
            this.txtTalla.ReadOnly = true;
            this.txtTalla.Size = new System.Drawing.Size(108, 22);
            this.txtTalla.TabIndex = 55;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDatos);
            this.groupBox2.Location = new System.Drawing.Point(12, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 294);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle tallas";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvIdTransformacionDetTalla,
            this.DgvIdTransformacionDet,
            this.DgvCodTalla,
            this.DgvDescripcionTalla,
            this.DgvCantidad,
            this.DgvObservacion,
            this.DgvbtnEliminar});
            this.dgvDatos.Location = new System.Drawing.Point(6, 21);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(674, 267);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // DgvIdTransformacionDetTalla
            // 
            this.DgvIdTransformacionDetTalla.DataPropertyName = "IdTransformacionDetTalla";
            this.DgvIdTransformacionDetTalla.HeaderText = "IdTransformacionDetTalla";
            this.DgvIdTransformacionDetTalla.MinimumWidth = 6;
            this.DgvIdTransformacionDetTalla.Name = "DgvIdTransformacionDetTalla";
            this.DgvIdTransformacionDetTalla.ReadOnly = true;
            this.DgvIdTransformacionDetTalla.Visible = false;
            // 
            // DgvIdTransformacionDet
            // 
            this.DgvIdTransformacionDet.DataPropertyName = "IdTransformacionDet";
            this.DgvIdTransformacionDet.HeaderText = "IdTransformacionDet";
            this.DgvIdTransformacionDet.MinimumWidth = 6;
            this.DgvIdTransformacionDet.Name = "DgvIdTransformacionDet";
            this.DgvIdTransformacionDet.ReadOnly = true;
            this.DgvIdTransformacionDet.Visible = false;
            // 
            // DgvCodTalla
            // 
            this.DgvCodTalla.DataPropertyName = "CodTalla";
            this.DgvCodTalla.HeaderText = "Cod. Talla";
            this.DgvCodTalla.MinimumWidth = 6;
            this.DgvCodTalla.Name = "DgvCodTalla";
            this.DgvCodTalla.ReadOnly = true;
            // 
            // DgvDescripcionTalla
            // 
            this.DgvDescripcionTalla.DataPropertyName = "DescripcionTalla";
            this.DgvDescripcionTalla.HeaderText = "Desc. Talla";
            this.DgvDescripcionTalla.MinimumWidth = 6;
            this.DgvDescripcionTalla.Name = "DgvDescripcionTalla";
            this.DgvDescripcionTalla.ReadOnly = true;
            // 
            // DgvCantidad
            // 
            this.DgvCantidad.DataPropertyName = "Cantidad";
            this.DgvCantidad.HeaderText = "Cantidad";
            this.DgvCantidad.MinimumWidth = 6;
            this.DgvCantidad.Name = "DgvCantidad";
            this.DgvCantidad.ReadOnly = true;
            // 
            // DgvObservacion
            // 
            this.DgvObservacion.DataPropertyName = "Observacion";
            this.DgvObservacion.HeaderText = "Observacion";
            this.DgvObservacion.MinimumWidth = 6;
            this.DgvObservacion.Name = "DgvObservacion";
            this.DgvObservacion.ReadOnly = true;
            // 
            // DgvbtnEliminar
            // 
            this.DgvbtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DgvbtnEliminar.HeaderText = "Eliminar";
            this.DgvbtnEliminar.MinimumWidth = 6;
            this.DgvbtnEliminar.Name = "DgvbtnEliminar";
            this.DgvbtnEliminar.ReadOnly = true;
            this.DgvbtnEliminar.Text = "Eliminar";
            this.DgvbtnEliminar.UseColumnTextForButtonValue = true;
            // 
            // TransformacionTallas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TransformacionTallas";
            this.Text = "Transformacion de Tallas";
            this.Load += new System.EventHandler(this.TransformacionTallas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarTalla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTalla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIdTransformacionDetTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIdTransformacionDet;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvCodTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvDescripcionTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvObservacion;
        private System.Windows.Forms.DataGridViewButtonColumn DgvbtnEliminar;
    }
}