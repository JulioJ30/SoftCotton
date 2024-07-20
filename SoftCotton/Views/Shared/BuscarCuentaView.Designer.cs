namespace SoftCotton.Views.Shared
{
    partial class BuscarCuentaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarCuentaView));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.dgvtxtCodCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCuentaBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtCodCuenta,
            this.dgvtxtCuenta});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListado.Location = new System.Drawing.Point(0, 37);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(495, 303);
            this.dgvListado.TabIndex = 5;
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // dgvtxtCodCuenta
            // 
            this.dgvtxtCodCuenta.HeaderText = "Cod. Cuenta";
            this.dgvtxtCodCuenta.Name = "dgvtxtCodCuenta";
            this.dgvtxtCodCuenta.ReadOnly = true;
            // 
            // dgvtxtCuenta
            // 
            this.dgvtxtCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvtxtCuenta.HeaderText = "Nombre de Cuenta";
            this.dgvtxtCuenta.Name = "dgvtxtCuenta";
            this.dgvtxtCuenta.ReadOnly = true;
            // 
            // txtCuentaBuscar
            // 
            this.txtCuentaBuscar.Location = new System.Drawing.Point(101, 9);
            this.txtCuentaBuscar.Name = "txtCuentaBuscar";
            this.txtCuentaBuscar.Size = new System.Drawing.Size(381, 22);
            this.txtCuentaBuscar.TabIndex = 4;
            this.txtCuentaBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuentaBuscar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar Cuenta:";
            // 
            // BuscarCuentaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 340);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.txtCuentaBuscar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "BuscarCuentaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Cuenta Contable";
            this.Load += new System.EventHandler(this.BuscarCuentaView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.TextBox txtCuentaBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtCodCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtCuenta;
    }
}