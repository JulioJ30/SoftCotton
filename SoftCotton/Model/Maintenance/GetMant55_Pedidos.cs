﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Maintenance
{
    public class GetMant55_Pedidos
    {
        public int idPedido { get; set; }
        public int idEstilo { get; set; }
        public int idPrograma { get; set; }
        public int idUsuarioCrea { get; set; }
        public string pedido { get; set; }
        public string programa { get; set; }
        public string fechaCrea { get; set; }
        public string estilo { get; set; }

        public bool estado { get; set; }
        public string usuario { get; set; }
    }
}