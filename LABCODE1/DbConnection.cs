using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABCODE1
{
    public static class DbConnection
    {
        private static string server = "srv1153.hstgr.io";
        private static string uname = "u955379966_inv_labcode";
        private static string dbname = "u955379966_inv_labcode";
        private static string pass = "4=yyfZ*eM";

        public static MySqlConnection GetConnection()
        {
            string connectionString = $"server={server};database={dbname};username={uname};password={pass};";
            return new MySqlConnection(connectionString);
        }
    }
}
