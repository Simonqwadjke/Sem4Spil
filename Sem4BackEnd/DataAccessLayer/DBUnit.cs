using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ModelLayer.Units;
using ModelLayer;

namespace DataAccessLayer
{
    public class DBUnit : IDBUnit
    {
        public bool GetUserUnits(User user)
        {
            List<Unit> list = new List<Unit>();
            bool success = false;
            //TODO: fix SELECT
            string query = "SELECT * FROM Group, Unit"
                         + " WHERE Unit.GroupID = Group.GroupID AND Group.UserID = @USERID";

            try
            {
                using (SqlCommand command = DBConnection.GetDbCommand(query))
                {
                    command.Parameters.AddWithValue("@USERID", user.UserID);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error in GetUserUnits: " + e.Message);
            }

            return success;
        }

        public bool SaveUserUnits(User user)
        {
            //TODO: Implement
            throw new NotImplementedException();
        }
    }
}
