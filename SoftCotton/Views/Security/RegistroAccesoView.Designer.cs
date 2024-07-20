namespace SoftCotton.Views.Security
{
    partial class RegistroAccesoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroAccesoView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dgvListadoUsuarios = new System.Windows.Forms.DataGridView();
            this.cbxSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctxtIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblUsuarioSeleccionado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.cIntIdModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIntIdSubModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtSubModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtRutaForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccbxActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoUsuarios)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(239, 397);
            this.panel1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel10);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(229, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro ";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dgvListadoUsuarios);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(5, 20);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(219, 362);
            this.panel10.TabIndex = 20;
            // 
            // dgvListadoUsuarios
            // 
            this.dgvListadoUsuarios.AllowUserToAddRows = false;
            this.dgvListadoUsuarios.AllowUserToDeleteRows = false;
            this.dgvListadoUsuarios.AllowUserToResizeRows = false;
            this.dgvListadoUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbxSeleccionar,
            this.ctxtIdUsuario,
            this.ctxtUsuario});
            this.dgvListadoUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoUsuarios.Location = new System.Drawing.Point(0, 0);
            this.dgvListadoUsuarios.Name = "dgvListadoUsuarios";
            this.dgvListadoUsuarios.ReadOnly = true;
            this.dgvListadoUsuarios.RowHeadersVisible = false;
            this.dgvListadoUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListadoUsuarios.Size = new System.Drawing.Size(219, 362);
            this.dgvListadoUsuarios.TabIndex = 18;
            this.dgvListadoUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoUsuarios_CellClick);
            // 
            // cbxSeleccionar
            // 
            this.cbxSeleccionar.HeaderText = "X";
            this.cbxSeleccionar.Name = "cbxSeleccionar";
            this.cbxSeleccionar.ReadOnly = true;
            this.cbxSeleccionar.Width = 25;
            // 
            // ctxtIdUsuario
            // 
            this.ctxtIdUsuario.HeaderText = "IdUsuario";
            this.ctxtIdUsuario.Name = "ctxtIdUsuario";
            this.ctxtIdUsuario.ReadOnly = true;
            this.ctxtIdUsuario.Visible = false;
            // 
            // ctxtUsuario
            // 
            this.ctxtUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ctxtUsuario.HeaderText = "Usuario";
            this.ctxtUsuario.Name = "ctxtUsuario";
            this.ctxtUsuario.ReadOnly = true;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(28, 17);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(13, 13);
            this.lblIdUsuario.TabIndex = 15;
            this.lblIdUsuario.Text = "0";
            this.lblIdUsuario.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(471, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(184, 31);
            this.panel8.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(655, 31);
            this.panel3.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblUsuarioSeleccionado);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(465, 31);
            this.panel9.TabIndex = 19;
            // 
            // lblUsuarioSeleccionado
            // 
            this.lblUsuarioSeleccionado.AutoSize = true;
            this.lblUsuarioSeleccionado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioSeleccionado.Location = new System.Drawing.Point(179, 6);
            this.lblUsuarioSeleccionado.Name = "lblUsuarioSeleccionado";
            this.lblUsuarioSeleccionado.Size = new System.Drawing.Size(13, 17);
            this.lblUsuarioSeleccionado.TabIndex = 19;
            this.lblUsuarioSeleccionado.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Colaborador Seleccionado:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.lblIdUsuario);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 397);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(910, 46);
            this.panel5.TabIndex = 9;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnGuardar);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(732, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(178, 46);
            this.panel7.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SoftCotton.Properties.Resources.icon_guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(23, 7);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(143, 33);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIntIdModulo,
            this.ctxtModulo,
            this.cIntIdSubModulo,
            this.ctxtSubModulo,
            this.ctxtRutaForm,
            this.ccbxActivo});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListado.Size = new System.Drawing.Size(655, 335);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            // 
            // cIntIdModulo
            // 
            this.cIntIdModulo.HeaderText = "IdModulo";
            this.cIntIdModulo.Name = "cIntIdModulo";
            this.cIntIdModulo.ReadOnly = true;
            this.cIntIdModulo.Visible = false;
            // 
            // ctxtModulo
            // 
            this.ctxtModulo.HeaderText = "Modulo";
            this.ctxtModulo.Name = "ctxtModulo";
            this.ctxtModulo.ReadOnly = true;
            // 
            // cIntIdSubModulo
            // 
            this.cIntIdSubModulo.HeaderText = "IdSubModulo";
            this.cIntIdSubModulo.Name = "cIntIdSubModulo";
            this.cIntIdSubModulo.ReadOnly = true;
            this.cIntIdSubModulo.Visible = false;
            // 
            // ctxtSubModulo
            // 
            this.ctxtSubModulo.HeaderText = "SubMódulo";
            this.ctxtSubModulo.Name = "ctxtSubModulo";
            this.ctxtSubModulo.ReadOnly = true;
            this.ctxtSubModulo.Width = 170;
            // 
            // ctxtRutaForm
            // 
            this.ctxtRutaForm.HeaderText = "Formulario";
            this.ctxtRutaForm.Name = "ctxtRutaForm";
            this.ctxtRutaForm.ReadOnly = true;
            this.ctxtRutaForm.Width = 200;
            // 
            // ccbxActivo
            // 
            this.ccbxActivo.HeaderText = "Activo";
            this.ccbxActivo.Name = "ccbxActivo";
            this.ccbxActivo.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 387);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvListado);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 49);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(655, 335);
            this.panel6.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(239, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(671, 397);
            this.panel2.TabIndex = 11;
            // 
            // RegistroAccesoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(910, 443);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroAccesoView";
            this.Text = "Registro de Acceso";
            this.Load += new System.EventHandler(this.RegistroAccesoView_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoUsuarios)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvListadoUsuarios;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbxSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUsuario;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuarioSeleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIntIdModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIntIdSubModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtSubModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtRutaForm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ccbxActivo;
    }
}