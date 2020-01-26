using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRIS_Simulator.Models
{
    public class Token
    {
        public string token_type { get; set; }
        public string access_token { get; set; }

        public Token(string tt, string at)
        {
            this.token_type = tt;
            this.access_token = at;
        }
    }
}