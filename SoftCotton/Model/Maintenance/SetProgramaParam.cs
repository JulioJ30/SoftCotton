namespace SoftCotton.Model.Maintenance
{
    public class SetProgramaParam
    {
        public int opcion { get; set; }
        public int idPrograma { get; set; }
        public string programa { get; set; }
        public int idUsuarioCrea { get; set; }


        public string codPrograma { get; set; }
        public string codProgamaUpdate { get; set; }
        public string nombrePrograma { get; set; }
        public string usuarioReg { get; set; }
        public string pedido { get; set; }
        public string estilo { get; set; }
        public string nombre { get; set; }

        public string codColor { get; set; }

        public bool estado { get; set; }
        public SetProgramaParam()
        {
            opcion = 0;
            codPrograma = "";
            codProgamaUpdate = "";
            nombrePrograma = "";
            usuarioReg = "";
            estado = true;
            pedido = "";
            estilo = "";
            nombre = "";
            codColor = "";
            idPrograma = 0;
            programa = "";
            idUsuarioCrea = 0;

        }
    }
}
