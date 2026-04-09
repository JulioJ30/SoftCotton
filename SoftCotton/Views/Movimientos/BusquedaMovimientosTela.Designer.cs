namespace SoftCotton.Views.Movimientos
{
    partial class BusquedaMovimientosTela
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
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.IdMovimientoCabecera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionTipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.AllowUserToResizeRows = false;
            this.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMovimientoCabecera,
            this.IdTipoMovimiento,
            this.DescripcionTipoMovimiento,
            this.FechaMovimiento,
            this.Comentario,
            this.CantidadMovimiento,
            this.Usuario});
            this.dgvItem.Location = new System.Drawing.Point(14, 12);
            this.dgvItem.MultiSelect = false;
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.RowHeadersWidth = 51;
            this.dgvItem.RowTemplate.Height = 24;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(774, 426);
            this.dgvItem.TabIndex = 1;
            this.dgvItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItem_KeyDown);
            // 
            // IdMovimientoCabecera
            // 
            this.IdMovimientoCabecera.DataPropertyName = "IdMovimientoCabecera";
            this.IdMovimientoCabecera.HeaderText = "Codigo Movimiento";
            this.IdMovimientoCabecera.MinimumWidth = 6;
            this.IdMovimientoCabecera.Name = "IdMovimientoCabecera";
            this.IdMovimientoCabecera.ReadOnly = true;
            // 
            // IdTipoMovimiento
            // 
            this.IdTipoMovimiento.DataPropertyName = "IdTipoMovimiento";
            this.IdTipoMovimiento.HeaderText = "IdTipoMovimiento";
            this.IdTipoMovimiento.MinimumWidth = 6;
            this.IdTipoMovimiento.Name = "IdTipoMovimiento";
            this.IdTipoMovimiento.ReadOnly = true;
            this.IdTipoMovimiento.Visible = false;
            // 
            // DescripcionTipoMovimiento
            // 
            this.DescripcionTipoMovimiento.DataPropertyName = "DescripcionTipoMovimiento";
            this.DescripcionTipoMovimiento.HeaderText = "Tipo Movimiento";
            this.DescripcionTipoMovimiento.MinimumWidth = 6;
            this.DescripcionTipoMovimiento.Name = "DescripcionTipoMovimiento";
            this.DescripcionTipoMovimiento.ReadOnly = true;
            // 
            // FechaMovimiento
            // 
            this.FechaMovimiento.DataPropertyName = "FechaMovimiento";
            this.FechaMovimiento.HeaderText = "Fecha Movimiento";
            this.FechaMovimiento.MinimumWidth = 6;
            this.FechaMovimiento.Name = "FechaMovimiento";
            this.FechaMovimiento.ReadOnly = true;
            // 
            // Comentario
            // 
            this.Comentario.DataPropertyName = "Comentario";
            this.Comentario.HeaderText = "Comentario";
            this.Comentario.MinimumWidth = 6;
            this.Comentario.Name = "Comentario";
            this.Comentario.ReadOnly = true;
            // 
            // CantidadMovimiento
            // 
            this.CantidadMovimiento.DataPropertyName = "CantidadMovimiento";
            this.CantidadMovimiento.HeaderText = "Cant. Movimiento";
            this.CantidadMovimiento.MinimumWidth = 6;
            this.CantidadMovimiento.Name = "CantidadMovimiento";
            this.CantidadMovimiento.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MinimumWidth = 6;
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // BusquedaMovimientosTela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvItem);
            this.Name = "BusquedaMovimientosTela";
            this.Text = "Busqueda de movimientos de tela";
            this.Load += new System.EventHandler(this.BusquedaMovimientosTela_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMovimientoCabecera;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionTipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
    }
}