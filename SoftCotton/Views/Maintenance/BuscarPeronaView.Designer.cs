
namespace SoftCotton.Views.Maintenance
{
    partial class BuscarPeronaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarPeronaView));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.ctxtNumDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCodTipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtTipoDocCorta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtNumDoc,
            this.ctxtCodTipoDoc,
            this.ctxtTipoDocCorta,
            this.ctxtNombres,
            this.ctxtApellidoPaterno,
            this.ctxtApellidoMaterno});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(714, 316);
            this.dgvListado.TabIndex = 1;
            this.dgvListado.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentDoubleClick);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // ctxtNumDoc
            // 
            this.ctxtNumDoc.HeaderText = "N° Documento";
            this.ctxtNumDoc.Name = "ctxtNumDoc";
            this.ctxtNumDoc.ReadOnly = true;
            this.ctxtNumDoc.Width = 120;
            // 
            // ctxtCodTipoDoc
            // 
            this.ctxtCodTipoDoc.HeaderText = "Cod. Tipo Doc.";
            this.ctxtCodTipoDoc.Name = "ctxtCodTipoDoc";
            this.ctxtCodTipoDoc.ReadOnly = true;
            this.ctxtCodTipoDoc.Width = 120;
            // 
            // ctxtTipoDocCorta
            // 
            this.ctxtTipoDocCorta.HeaderText = "Tipo Documento";
            this.ctxtTipoDocCorta.Name = "ctxtTipoDocCorta";
            this.ctxtTipoDocCorta.ReadOnly = true;
            this.ctxtTipoDocCorta.Width = 150;
            // 
            // ctxtNombres
            // 
            this.ctxtNombres.HeaderText = "Nombres";
            this.ctxtNombres.Name = "ctxtNombres";
            this.ctxtNombres.ReadOnly = true;
            // 
            // ctxtApellidoPaterno
            // 
            this.ctxtApellidoPaterno.HeaderText = "Apellido Pat.";
            this.ctxtApellidoPaterno.Name = "ctxtApellidoPaterno";
            this.ctxtApellidoPaterno.ReadOnly = true;
            // 
            // ctxtApellidoMaterno
            // 
            this.ctxtApellidoMaterno.HeaderText = "Apellido Mat.";
            this.ctxtApellidoMaterno.Name = "ctxtApellidoMaterno";
            this.ctxtApellidoMaterno.ReadOnly = true;
            this.ctxtApellidoMaterno.Width = 120;
            // 
            // BuscarPeronaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 316);
            this.Controls.Add(this.dgvListado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BuscarPeronaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Personas";
            this.Load += new System.EventHandler(this.BuscarPeronaView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtNumDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCodTipoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtTipoDocCorta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtApellidoMaterno;
    }
}