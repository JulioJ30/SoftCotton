﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ServiceOrder
{
    public class SetOSTipoAprobParam
    {
        public int opcion { get; set; }
        public int idTipoAprobacion { get; set; }
        public int idTipoAprobacionUpdate { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public int nivelAprobacion { get; set; }
        public string usuarioReg { get; set; }

        public SetOSTipoAprobParam()
        {
            opcion = 0;
            idTipoAprobacion = 0;
            idTipoAprobacionUpdate = 0;
            descripcion = "";
            estado = false;
            nivelAprobacion = 0;
            usuarioReg = "";
        }
    }
}
