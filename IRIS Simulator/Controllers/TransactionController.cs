using IRIS_Simulator.Models;
using NLog;
using System;
using System.Data.OracleClient;
using System.Web.Http;
using System.Web.Mvc;

namespace IRIS_Simulator.Controllers
{
    public class TransactionController : Controller
    {
        private string output;
        private readonly string Dummy = System.Configuration.ConfigurationManager.AppSettings["Dummy"].ToString();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private OracleConnection con = new OracleConnection(System.Configuration.ConfigurationManager.AppSettings["ConnString"].ToString());

        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        public string GetString()
        {
            return "IRIS 5 Simulator by Danish Rehan.";
        }

        public string Token()
        {
            //"token_type", "access_token"
            Token T = new Token(System.Configuration.ConfigurationManager.AppSettings["token_type"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["access_token"].ToString());
            string myJson = Newtonsoft.Json.JsonConvert.SerializeObject(T);
            return myJson;
        }

        public string OpenAccountBalanceInquiry()
        {
            //"responseCode", "authIdResponse", "transactionLogId", "availableBalance", "actualBalance"
            OpenBalanceInquiry BI = new OpenBalanceInquiry(System.Configuration.ConfigurationManager.AppSettings["responseCode"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["authIdResponse"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["transactionLogId"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["availableBalance"].ToString(),
                 System.Configuration.ConfigurationManager.AppSettings["actualBalance"].ToString());
            string myJson = Newtonsoft.Json.JsonConvert.SerializeObject(BI);
            return myJson;
        }

        public string TitleFetch([FromBody]TfReq req)
        {
            //"responseCode", "authIdResponse", "transactionLogId", "accountTitle", "benificiaryIBAN"

            /*AsyncManager.OutstandingOperations.Increment();
            new Timer((state) => {
                AsyncManager.Parameters["responseCode"] = "responseCode";
                AsyncManager.OutstandingOperations.Decrement();
            }, null, 10000, 0);*/
            logger.Trace(Request.RawUrl);
            logger.Trace("ApiTransactions::TitleFetch   |" + "Request Json [{\"accountIMD\":\"" + req.accountIMD +
                "\",\"Iban\":\"" + req.Iban + "\",\"accountNumber\":\"" + req.accountNumber +
                "\",\"accountType\":\"" + req.accountType + "\",\"accountCurrency\":\" " + req.accountCurrency +
                "\",\"cardAccepTermId\":\"" + req.cardAccepTermId + "\",\"relationshipId\":\" " + req.relationshipId +
                "\",\"transmissionDate\":\"" + req.transmissionDate + "\",\"transmissionTime\":\" " + req.transmissionTime +
                "\",\"stan\":\"" + req.stan + "\",\"rrn\":\" " + req.rrn +
                "\",\"timeLocalTran\":\"" + req.timeLocalTran + "\",\"dateLocalTran\":\" " + req.dateLocalTran +
                "\",\"acqInstCode\":\"" + req.acqInstCode + "\",\"pinData\":\"" + req.pinData + "\"}]");

            if (Dummy.Equals("0"))
            {
                logger.Trace("DummyMode [NO]");
                /*"CREATE TABLE "IRGATEWAY"."HOSTSIMULATOR"
                 ("ACCOUNTNUMBER" VARCHAR2(40 BYTE),
                  "ACCOUNTTITLE" VARCHAR2(100 BYTE),
                  "AMOUNT" VARCHAR2(20 BYTE)
                 );"*/
                try
                {
                    OracleCommand query = new OracleCommand("SELECT accounttitle FROM hostsimulator WHERE accountnumber = " + req.accountNumber);
                    query.Connection = con;
                    con.Open(); //oracle connection object
                    OracleDataReader reader = query.ExecuteReader();
                    reader.Read();
                    output = reader.GetString(0);
                    con.Close();
                }
                catch (Exception ex)
                {
                    logger.Trace(ex.ToString());
                }

                TitleFetch TF = new TitleFetch(System.Configuration.ConfigurationManager.AppSettings["responseCode"].ToString(),
                            System.Configuration.ConfigurationManager.AppSettings["authIdResponse"].ToString(),
                            System.Configuration.ConfigurationManager.AppSettings["transactionLogId"].ToString(),
                            output,
                            System.Configuration.ConfigurationManager.AppSettings["benificiaryIBAN"].ToString());

                logger.Trace("ApiTransactions::TitleFetch   |" + "Response Json [{\"responseCode\":\"" + System.Configuration.ConfigurationManager.AppSettings["responseCode"].ToString() +
                    "\",\"authIdResponse\":\"" + System.Configuration.ConfigurationManager.AppSettings["authIdResponse"].ToString() +
                    "\",\"transactionLogId\":\"" + System.Configuration.ConfigurationManager.AppSettings["transactionLogId"].ToString() +
                    "\",\"accountTitle\":\"" + output +
                    "\",\"benificiaryIBAN\":\"" + System.Configuration.ConfigurationManager.AppSettings["benificiaryIBAN"].ToString() + "\"}]");
                string myJson = Newtonsoft.Json.JsonConvert.SerializeObject(TF);
                return myJson;
            }
            else
            {
                logger.Trace("DummyMode [YES]");
                TitleFetch TF = new TitleFetch(System.Configuration.ConfigurationManager.AppSettings["responseCode"].ToString(),
                            System.Configuration.ConfigurationManager.AppSettings["authIdResponse"].ToString(),
                            System.Configuration.ConfigurationManager.AppSettings["transactionLogId"].ToString(),
                            "Danish Rehan",
                            System.Configuration.ConfigurationManager.AppSettings["benificiaryIBAN"].ToString());

                logger.Trace("ApiTransactions::TitleFetch   |" + "Response Json [{\"responseCode\":\"" + System.Configuration.ConfigurationManager.AppSettings["responseCode"].ToString() +
                    "\",\"authIdResponse\":\"" + System.Configuration.ConfigurationManager.AppSettings["authIdResponse"].ToString() +
                    "\",\"transactionLogId\":\"" + System.Configuration.ConfigurationManager.AppSettings["transactionLogId"].ToString() +
                    "\",\"accountTitle\":\"" + System.Configuration.ConfigurationManager.AppSettings["accountTitle"].ToString() +
                    "\",\"benificiaryIBAN\":\"" + System.Configuration.ConfigurationManager.AppSettings["benificiaryIBAN"].ToString() + "\"}]");
                string myJson = Newtonsoft.Json.JsonConvert.SerializeObject(TF);
                return myJson;
            }
        }

        public string OpenAccountFundsTransfer()
        {
            //"responseCode", "authIdResponse", "transactionLogId"
            //System.Threading.Thread.Sleep(60000);
            OpenAccountFundsTransfer FT = new OpenAccountFundsTransfer(System.Configuration.ConfigurationManager.AppSettings["responseCode"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["authIdResponse"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["transactionLogId"].ToString());
            string myJson = Newtonsoft.Json.JsonConvert.SerializeObject(FT);
            return myJson;
        }

        public string OpenIBFT()
        {
            //"responseCode", "authIdResponse", "transactionLogId"
            OpenIBFT IBFT = new OpenIBFT(System.Configuration.ConfigurationManager.AppSettings["responseCode"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["authIdResponse"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["transactionLogId"].ToString());
            string myJson = Newtonsoft.Json.JsonConvert.SerializeObject(IBFT);
            return myJson;
        }

        public string OpenAccountStatusInquiry()
        {
            //"responseCode", "authIdResponse", "transactionLogId"
            OpenAccountStatusInquiry SI = new OpenAccountStatusInquiry(System.Configuration.ConfigurationManager.AppSettings["responseCode"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["authIdResponse"].ToString());
            string myJson = Newtonsoft.Json.JsonConvert.SerializeObject(SI);
            return myJson;
        }
    }
}