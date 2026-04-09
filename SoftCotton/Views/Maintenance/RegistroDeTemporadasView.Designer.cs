namespace SoftCotton.Views.Maintenance
{
    partial class RegistroDeTemporadasView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroDeTemporadasView));
            this.gbRegistro = new System.Windows.Forms.GroupBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTemporada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.IdTemporada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temporada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemporadaDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoListado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbRegistro.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRegistro
            // 
            this.gbRegistro.Controls.Add(this.txtAnio);
            this.gbRegistro.Controls.Add(this.label3);
            this.gbRegistro.Controls.Add(this.txtDescripcion);
            this.gbRegistro.Controls.Add(this.label2);
            this.gbRegistro.Controls.Add(this.txtTemporada);
            this.gbRegistro.Controls.Add(this.label1);
            this.gbRegistro.Enabled = false;
            this.gbRegistro.Location = new System.Drawing.Point(12, 12);
            this.gbRegistro.Name = "gbRegistro";
            this.gbRegistro.Size = new System.Drawing.Size(230, 385);
            this.gbRegistro.TabIndex = 0;
            this.gbRegistro.TabStop = false;
            this.gbRegistro.Text = "Registro";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(9, 135);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(215, 22);
            this.txtAnio.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Año:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(9, 91);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(215, 22);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción:";
            // 
            // txtTemporada
            // 
            this.txtTemporada.Location = new System.Drawing.Point(9, 47);
            this.txtTemporada.Name = "txtTemporada";
            this.txtTemporada.Size = new System.Drawing.Size(215, 22);
            this.txtTemporada.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Temporada:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvData);
            this.groupBox2.Location = new System.Drawing.Point(248, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(933, 385);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTemporada,
            this.Anio,
            this.Temporada,
            this.TemporadaDescripcion,
            this.EstadoListado,
            this.Estado,
            this.Accion});
            this.dgvData.Location = new System.Drawing.Point(6, 37);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(918, 332);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.btnNuevo);
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Location = new System.Drawing.Point(12, 397);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1169, 54);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SoftCotton.Properties.Resources.icon_nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(902, 16);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(112, 33);
            this.btnNuevo.TabIndex = 51;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(1020, 15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(140, 33);
            this.btnGuardar.TabIndex = 41;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SoftCotton.Properties.Resources.icon_eliminar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(784, 16);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnCancelar.Size = new System.Drawing.Size(112, 33);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // IdTemporada
            // 
            this.IdTemporada.HeaderText = "IdTemporada";
            this.IdTemporada.MinimumWidth = 6;
            this.IdTemporada.Name = "IdTemporada";
            this.IdTemporada.ReadOnly = true;
            this.IdTemporada.Visible = false;
            // 
            // Anio
            // 
            this.Anio.HeaderText = "Anio";
            this.Anio.MinimumWidth = 6;
            this.Anio.Name = "Anio";
            this.Anio.ReadOnly = true;
            // 
            // Temporada
            // 
            this.Temporada.HeaderText = "Temporada";
            this.Temporada.MinimumWidth = 6;
            this.Temporada.Name = "Temporada";
            this.Temporada.ReadOnly = true;
            // 
            // TemporadaDescripcion
            // 
            this.TemporadaDescripcion.HeaderText = "Descripcion";
            this.TemporadaDescripcion.MinimumWidth = 6;
            this.TemporadaDescripcion.Name = "TemporadaDescripcion";
            this.TemporadaDescripcion.ReadOnly = true;
            // 
            // EstadoListado
            // 
            this.EstadoListado.HeaderText = "Estado";
            this.EstadoListado.MinimumWidth = 6;
            this.EstadoListado.Name = "EstadoListado";
            this.EstadoListado.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Estado.HeaderText = "Cambio Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Estado.Text = "Cambio Estado";
            this.Estado.UseColumnTextForButtonValue = true;
            // 
            // Accion
            // 
            this.Accion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Accion.HeaderText = "Accion";
            this.Accion.MinimumWidth = 6;
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Accion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Accion.Text = "Editar";
            this.Accion.UseColumnTextForButtonValue = true;
            // 
            // RegistroDeTemporadasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 456);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbRegistro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroDeTemporadasView";
            this.Text = "Registro De Temporadas";
            this.Load += new System.EventHandler(this.RegistroDeTemporadasView_Load);
            this.gbRegistro.ResumeLayout(false);
            this.gbRegistro.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRegistro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTemporada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTemporada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temporada;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemporadaDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoListado;
        private System.Windows.Forms.DataGridViewButtonColumn Estado;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
    }
}