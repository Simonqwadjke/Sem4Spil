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
    public class DBInvaders : IDBInvaders
    {
        public bool GetUserInvaders(User user)
        {
            bool success = false;
            string query = "SELECT UserID, InvaderID FROM Invaders"
                         + " WHERE UserID = @USERID";

            try
            {
                using (SqlCommand command = DataConnection.GetDbCommand(query))
                {
                    command.Parameters.AddWithValue("@USERID", user.UserID);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (FillUserInvaders(user, reader))
                            {
                                success = true;
                            }
                        }
                    }
                }
            }
            //TODO: Add more Exceptions
            catch (Exception e)
            {
                Console.WriteLine("Unknown Error in GetUserInvaders: " + e.Message);
            }

            return success;
        }

        public bool SaveUserInvaders(User user)
        {

            //TODO: Implement
            bool success = false;

            return success;
        }

        private bool FillUserInvaders(User user, IDataReader reader)
        {
            bool success = false;
            List<User> list = new List<User>();

            try
            {
                do
                {
                    User invader = new User("");
                    invader.UserID = Convert.ToInt32(reader["InvaderID"]);
                    list.Add(invader);
                } while (reader.Read());

                user.Invaders = list;
                success = true;
            }
            //TODO: Add more Exceptions
            catch (Exception e)
            {
                Console.WriteLine("Unknown Error in FillUserInvaders: " + e.Message);
            }

            return success;
        }
    }
}
