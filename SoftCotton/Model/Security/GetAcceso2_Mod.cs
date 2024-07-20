using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Security
{
    public class GetAcceso2_Mod
    {
        public int idModulo { get; set; }
        public string modulo { get; set; }

        public List<GetAcceso3_SubMod> subModulos { get; set;}
    }
}
