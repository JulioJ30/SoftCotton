﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.DTO.Security
{
    public class LoginDTO
    {
        public int idEmpresa { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }
}
