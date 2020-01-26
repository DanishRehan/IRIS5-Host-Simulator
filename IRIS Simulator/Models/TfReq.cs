namespace IRIS_Simulator.Controllers
{
    public class TfReq
    {
        public string accountIMD { get; set; }
        public string Iban { get; set; }
        public string accountNumber { get; set; }
        public string accountType { get; set; }
        public string accountCurrency { get; set; }
        public string cardAccepTermId { get; set; }
        public string relationshipId { get; set; }
        public string transmissionDate { get; set; }
        public string transmissionTime { get; set; }
        public string stan { get; set; }
        public string rrn { get; set; }
        public string timeLocalTran { get; set; }
        public string dateLocalTran { get; set; }
        public string acqInstCode { get; set; }
        public string pinData { get; set; }
    }
}