using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Demo
{
    class DBUtils
    {
         public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3311;
            string database = "user7_db";
            string username = "user7";
            string password = "1234";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
