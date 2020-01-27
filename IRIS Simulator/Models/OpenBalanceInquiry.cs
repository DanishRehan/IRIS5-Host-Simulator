namespace IRIS_Simulator.Models
{
    public class OpenBalanceInquiry
    {
        public string responseCode { get; set; }
        public string authIdResponse { get; set; }
        public string transactionLogId { get; set; }
        public string availableBalance { get; set; }
        public string actualBalance { get; set; }

        public OpenBalanceInquiry(string res, string auth, string log, string bal, string abal)
        {
            this.responseCode = res;
            this.authIdResponse = auth;
            this.transactionLogId = log;
            this.availableBalance = bal;
            this.actualBalance = abal;
        }
    }
}