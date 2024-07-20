using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Util
{
    public class ResponseGeneral
    {
        public bool state { get; set; }
        public string message { get; set; }
        public object result { get; set; }

        public ResponseGeneral(bool state, string message, object result)
        {
            this.state = state;
            this.message = message;
            this.result = result;
        }

    }
}
