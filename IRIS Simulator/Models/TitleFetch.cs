namespace IRIS_Simulator.Models
{
    public class TitleFetch
    {
        public string responseCode { get; set; }
        public string authIdResponse { get; set; }
        public string transactionLogId { get; set; }
        public string accountTitle { get; set; }
        public string benificiaryIBAN { get; set; }

        public TitleFetch(string res, string auth, string log, string acc, string iban)
        {
            this.responseCode = res;
            this.authIdResponse = auth;
            this.transactionLogId = log;
            this.accountTitle = acc;
            this.benificiaryIBAN = iban;
        }
    }
}