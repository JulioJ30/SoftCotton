namespace SoftCotton.Util
{
    /// <summary>
    /// Ítem genérico valor/texto para ComboBox (DisplayMember = "Texto", ValueMember = "Valor").
    /// </summary>
    public class OpcionCombo
    {
        public string Valor { get; set; }
        public string Texto { get; set; }

        public OpcionCombo(string valor, string texto)
        {
            Valor = valor;
            Texto = texto;
        }

        public override string ToString()
        {
            return Texto;
        }
    }
}
