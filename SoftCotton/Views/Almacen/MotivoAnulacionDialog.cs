using SoftCotton.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoftCotton.Views.Almacen
{
    /// <summary>
    /// Diálogo para confirmar una anulación pidiendo el motivo (obligatorio).
    /// </summary>
    internal sealed class MotivoAnulacionDialog : Form
    {
        private readonly TextBox _txtMotivo;
        private readonly Button _btnAnular;

        private MotivoAnulacionDialog(string titulo, string descripcion)
        {
            Text = "Confirmar anulación";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            Font = EstiloVisual.Fuente;
            BackColor = EstiloVisual.Superficie;
            ClientSize = new Size(480, 270);
            Padding = new Padding(20, 16, 20, 16);

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = EstiloVisual.FuenteSeccion,
                ForeColor = EstiloVisual.Peligro,
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 26
            };

            var lblDescripcion = new Label
            {
                Text = descripcion,
                ForeColor = EstiloVisual.TextoSecundario,
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 50
            };

            var lblMotivo = new Label
            {
                Text = "Motivo de la anulación *",
                Font = EstiloVisual.FuenteNegrita,
                Dock = DockStyle.Top,
                Height = 22
            };

            _txtMotivo = new TextBox
            {
                Multiline = true,
                MaxLength = 250,
                Dock = DockStyle.Top,
                Height = 70,
                ScrollBars = ScrollBars.Vertical
            };
            _txtMotivo.TextChanged += (s, e) => _btnAnular.Enabled = _txtMotivo.Text.Trim().Length >= 5;

            var pie = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 44,
                Padding = new Padding(0, 8, 0, 0)
            };

            _btnAnular = new Button { Text = "Anular", Size = new Size(110, 32), Enabled = false, DialogResult = DialogResult.OK };
            var btnCancelar = new Button { Text = "Cancelar", Size = new Size(110, 32), DialogResult = DialogResult.Cancel };
            EstiloVisual.BotonPeligroLleno(_btnAnular);
            EstiloVisual.BotonSecundario(btnCancelar);
            pie.Controls.Add(_btnAnular);
            pie.Controls.Add(btnCancelar);

            Controls.Add(_txtMotivo);
            Controls.Add(lblMotivo);
            Controls.Add(lblDescripcion);
            Controls.Add(lblTitulo);
            Controls.Add(pie);

            AcceptButton = null; // el motivo es multilínea: Enter agrega salto de línea
            CancelButton = btnCancelar;
        }

        /// <summary>Devuelve el motivo ingresado, o null si el usuario canceló.</summary>
        public static string Pedir(IWin32Window owner, string titulo, string descripcion)
        {
            using (var dialogo = new MotivoAnulacionDialog(titulo, descripcion))
            {
                return dialogo.ShowDialog(owner) == DialogResult.OK ? dialogo._txtMotivo.Text.Trim() : null;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _txtMotivo.Focus();
        }
    }
}
