﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class GetOC6_TipoAnulado
    {
        public int idTipoAnulado { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }
    }
}