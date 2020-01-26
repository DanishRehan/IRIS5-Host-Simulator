using NLog;
using Oracle.DataAccess.Client;
using System;

namespace IRIS_Simulator.Models
{
    public class MyOracleConnection
    {
        static OracleConnection con;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        string conString = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 192.168.4.164)" +
            "(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = MMBLRELEASE)));" +
            "User ID=irgateway;Password=tpstps;Unicode=True";
        public void Connect()
        {
            try
            {
                con = new OracleConnection();
                //con.ConnectionString = "User Id=<irgateway>;Password=<tpstps>;Data Source=<datasource>";
                con.ConnectionString = conString;
                con.Open();
                logger.Trace("Connected to Oracle" + con.ServerVersion);
            } catch (Exception ex)
            {
                logger.Trace(ex.ToString());
            }

        }

        public void Close()
        {
            con.Close();
            con.Dispose();
        }

        static void Main()
        {
            MyOracleConnection ot = new MyOracleConnection();
            ot.Connect();
            ot.Close();
        }
    }
}