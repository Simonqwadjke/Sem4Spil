using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ModelLayer;

namespace DataAccessLayer
{
    public class DBUpgrade : IDBUpgrade
    {

        public bool GetUserUpgrades(User user)
        {
            bool success = false;
            string query = "SELECT * FROM Upgrades"
                         + " WHERE UserID = @USERID";
            using (SqlCommand command = DBConnection.GetDbCommand(query))
            {

            }


            return success;
        }

        public bool SaveUserUpgrades(User user)
        {
            throw new NotImplementedException();
        }
    }
}
