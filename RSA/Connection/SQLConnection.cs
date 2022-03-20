using System.Data.SqlClient;

namespace RSA.Connection
{
    public class SQLConnection
    {
        public string SQLConnectionString()
        {
            return @"Server=THUNDERCLOUD\THUNDERCLOUD;Database=ZCELERO;User Id=Admin;Password=123456;";
        }
    }
}
