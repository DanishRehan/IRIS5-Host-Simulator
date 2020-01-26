using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRIS_Simulator.Models
{
    public class OpenAccountStatusInquiry
    {
        public string responseCode { get; set; }
        public string authIdResponse { get; set; }
        public OpenAccountStatusInquiry(string res, string auth)
        {
            this.responseCode = res;
            this.authIdResponse = auth;
        }
    }
}