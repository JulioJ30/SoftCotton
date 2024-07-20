namespace SoftCotton.Model.Maintenance
{
    public class SetProvClientesParam
    {
        public int opcion { get; set; }
        public string codigo { get; set; }
        public string codigoUpdate { get; set; }
        public string codTipoDoc { get; set; }
        public string razonSocial { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string codTipoPC { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }
        public string contacto { get; set; }
        public string email { get; set; }
        public string iddistrito { get; set; }


        public SetProvClientesParam()
        {
            opcion = 0;
            codigo = "";
            codigoUpdate = "";
            codTipoDoc = "";
            razonSocial = "";
            nombre1 = "";
            nombre2 = "";
            apellido1 = "";
            apellido2 = "";
            codTipoPC = "";
            telefono = "";
            direccion = "";
            usuarioReg = "";
            estado = false;
            contacto = "";
            email = "";
            iddistrito = "";

        }
    }
}
