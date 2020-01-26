using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRIS_Simulator.Models
{
    public class OpenAccountFundsTransfer
    {
        public string responseCode { get; set; }
        public string authIdResponse { get; set; }
        public string transactionLogId { get; set; }
        public OpenAccountFundsTransfer(string res, string auth, string log)
        {
            this.responseCode = res;
            this.authIdResponse = auth;
            this.transactionLogId = log;
        }
    }
}