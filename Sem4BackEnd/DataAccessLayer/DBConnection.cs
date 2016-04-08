using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class DBConnection
    {
        public static readonly string connectionString =   "Data Source=kraka.ucn.dk;"
                                                         + "Initial Catalog=dmab0914_2sem_7;"
                                                         + "UID=dmab0914_2sem_7;"
                                                         + "Password=IsAllowed";
        public static readonly SqlConnection dbconn = new SqlConnection(connectionString);
        public static SqlTransaction transaction;
        private static SqlCommand dbCmd;

        private static void Open()
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                dbconn.Open();
        }

        public static void Close()
        {
            dbconn.Close();
        }

        public static SqlCommand GetDbCommand(string sql)
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                Open();
            if (dbCmd == null)
            {
                dbCmd = new SqlCommand(sql, dbconn);
            }
            else
            {
                dbCmd.Parameters.Clear();
            }

            dbCmd.CommandText = sql;
            return dbCmd;
        }
    }
}
