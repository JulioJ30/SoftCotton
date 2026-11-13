using System.Drawing;
using System.Windows.Forms;

namespace SoftCotton.Util
{
    /// <summary>
    /// Paleta y estilos comunes para las pantallas nuevas (aplicados en tiempo de ejecución
    /// para no ensuciar los .Designer.cs).
    /// </summary>
    public static class EstiloVisual
    {
        public static readonly Color Primario = Color.FromArgb(31, 95, 158);
        public static readonly Color PrimarioHover = Color.FromArgb(24, 78, 132);
        public static readonly Color Fondo = Color.FromArgb(243, 245, 248);
        public static readonly Color Superficie = Color.White;
        public static readonly Color Borde = Color.FromArgb(218, 223, 230);
        public static readonly Color Texto = Color.FromArgb(33, 37, 41);
        public static readonly Color TextoSecundario = Color.FromArgb(108, 117, 125);
        public static readonly Color TextoSobrePrimario = Color.FromArgb(214, 228, 243);
        public static readonly Color Exito = Color.FromArgb(25, 135, 84);
        public static readonly Color Peligro = Color.FromArgb(192, 41, 41);
        public static readonly Color PeligroSuave = Color.FromArgb(253, 236, 236);
        public static readonly Color Alerta = Color.FromArgb(255, 243, 205);
        public static readonly Color AlertaTexto = Color.FromArgb(133, 100, 4);
        public static readonly Color FilaAlterna = Color.FromArgb(248, 250, 252);
        public static readonly Color Seleccion = Color.FromArgb(207, 226, 246);
        public static readonly Color Anulado = Color.FromArgb(160, 165, 170);

        public static readonly Font Fuente = new Font("Segoe UI", 9F);
        public static readonly Font FuenteNegrita = new Font("Segoe UI Semibold", 9F);
        public static readonly Font FuenteTitulo = new Font("Segoe UI Semibold", 15F);
        public static readonly Font FuenteSeccion = new Font("Segoe UI Semibold", 10F);
        public static readonly Font FuenteNumeroGrande = new Font("Segoe UI Semibold", 16F);
        public static readonly Font FuenteTachada = new Font("Segoe UI", 9F, FontStyle.Strikeout);

        public static void AplicarGrilla(DataGridView grilla, bool soloLectura = true)
        {
            grilla.BackgroundColor = Superficie;
            grilla.BorderStyle = BorderStyle.None;
            grilla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grilla.GridColor = Borde;
            grilla.RowHeadersVisible = false;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToDeleteRows = false;
            grilla.AllowUserToResizeRows = false;
            grilla.ReadOnly = soloLectura;
            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grilla.AutoGenerateColumns = false;
            grilla.EnableHeadersVisualStyles = false;
            grilla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grilla.ColumnHeadersHeight = 34;
            grilla.RowTemplate.Height = 30;

            grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(233, 238, 245);
            grilla.ColumnHeadersDefaultCellStyle.ForeColor = Texto;
            grilla.ColumnHeadersDefaultCellStyle.Font = FuenteNegrita;
            grilla.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(233, 238, 245);
            grilla.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 0, 4, 0);

            grilla.DefaultCellStyle.Font = Fuente;
            grilla.DefaultCellStyle.ForeColor = Texto;
            grilla.DefaultCellStyle.BackColor = Superficie;
            grilla.DefaultCellStyle.SelectionBackColor = Seleccion;
            grilla.DefaultCellStyle.SelectionForeColor = Texto;
            grilla.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            grilla.AlternatingRowsDefaultCellStyle.BackColor = FilaAlterna;

            HabilitarDobleBuffer(grilla);
        }

        public static void ColumnaNumero(DataGridViewColumn columna, string formato = "N3")
        {
            columna.DefaultCellStyle.Format = formato;
            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public static void ColumnaCentrada(DataGridViewColumn columna)
        {
            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public static void BotonPrimario(Button boton)
        {
            BotonPlano(boton, Primario, Color.White, Primario);
            boton.FlatAppearance.MouseOverBackColor = PrimarioHover;
        }

        public static void BotonSecundario(Button boton)
        {
            BotonPlano(boton, Superficie, Primario, Borde);
            boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(236, 242, 249);
        }

        public static void BotonPeligro(Button boton)
        {
            BotonPlano(boton, Superficie, Peligro, Color.FromArgb(236, 190, 190));
            boton.FlatAppearance.MouseOverBackColor = PeligroSuave;
        }

        public static void BotonPeligroLleno(Button boton)
        {
            BotonPlano(boton, Peligro, Color.White, Peligro);
            boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 30, 30);
        }

        private static void BotonPlano(Button boton, Color fondo, Color texto, Color borde)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.BackColor = fondo;
            boton.ForeColor = texto;
            boton.Font = FuenteNegrita;
            boton.FlatAppearance.BorderColor = borde;
            boton.FlatAppearance.BorderSize = 1;
            boton.Cursor = Cursors.Hand;
            boton.UseVisualStyleBackColor = false;
        }

        private static void HabilitarDobleBuffer(Control control)
        {
            // Evita el parpadeo al desplazar grillas grandes (propiedad protegida)
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(control, true, null);
        }
    }
}
