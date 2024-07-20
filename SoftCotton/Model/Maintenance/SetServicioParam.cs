namespace SoftCotton.Model.Maintenance
{
    public class SetServicioParam
    {
        public int opcion { get; set; }
        public string codServicio { get; set; }
        public string codServicioUpdate { get; set; }
        public string nombreServicio { get; set; }
        public string usuarioReg { get; set; }
        public bool estado { get; set; }
        public SetServicioParam()
        {
            opcion = 0;
            codServicio = "";
            codServicioUpdate = "";
            nombreServicio = "";
            usuarioReg = "";
            estado = true;
        }
    }
}
