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
    public class DBUser : IDBUser
    {
        public User GetUser(string username)
        {
            string query = "SELECT Name, Email, Age, Country, Ranking, Level, LastLogin"
                         + " FROM UserData"
                         + " WHERE Username = '@USERNAME'";

            User user = null;

            try
            {
                using (SqlCommand command = DBConnection.GetDbCommand(query))
                {
                    command.Parameters.AddWithValue("@USERNAME", username);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = CreateUserObject(reader);
                        }
                    }
                }
            }
            //TODO: Add more Exceptions
            catch (Exception e)
            {
                Console.WriteLine("Unknown error in GetUser: " + e.Message);
            }

            return user;
        }

        public User Login(string username, string password)
        {
            //TODO: Implement
            string query = "SELECT Name, Email, Age, Country, Ranking, Level, Lastlogin FROM UserData"
                         + " WHERE Username = '@USERNAME' AND Password = '@PASSWORD'";
            User user = null;

            using (SqlCommand command = DBConnection.GetDbCommand(query))
            {
                command.Parameters.AddWithValue("@USERNAME", username);
                command.Parameters.AddWithValue("@PASSWORD", password);

                using (IDataReader reader = command.ExecuteReader())
                {
                    CreateUserObject(reader);
                }
            }

            return user;
        }

        public bool CreateUser(User user)
        {
            user.UserID = GetMax.GetMaxID("User");
            bool success = false;
            string query = "INSERT INTO UserData(UserID,Name,Username,Password,Email,Age,Country,Ranking,Level)"
                         + " VALUES(@USERID, @NAME, @USERNAME, @PASSWORD, @EMAIL, @AGE, @COUNTRY, @RANKING, @LEVEL)";
            try
            {
                using (SqlCommand command = DBConnection.GetDbCommand(query))
                {
                    //TODO: Fix Age naming
                    command.Parameters.AddWithValue("@USERID", user.UserID);
                    command.Parameters.AddWithValue("@NAME", user.Name);
                    command.Parameters.AddWithValue("@USERNAME", user.Username);
                    command.Parameters.AddWithValue("@PASSWORD", user.Password);
                    command.Parameters.AddWithValue("@EMAIL", user.Email);
                    command.Parameters.AddWithValue("@AGE", user.BirthDate);
                    command.Parameters.AddWithValue("@COUNTRY", user.Country);
                    command.Parameters.AddWithValue("@RANKING", user.Ranking);
                    command.Parameters.AddWithValue("@LEVEL", user.Level);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    }
                }
            }
            //TODO: Add more Exceptions
            catch (Exception e)
            {
                Console.WriteLine("Unknown error in CreateUser: " + e.Message);
            }

            return success;
        }

        private User CreateUserObject(IDataReader reader)
        {
            User user = new User("");
            try
            {
                user.Name = reader["Name"].ToString();
                user.Username = reader["Username"].ToString();
                user.BirthDate = Convert.ToDateTime(reader["Age"]);
                user.Email = reader["Email"].ToString();
                user.Country = reader["Country"].ToString();
                user.Ranking = Convert.ToInt32(reader["Ranking"]);
                user.Level = Convert.ToInt32(reader["Level"]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unkown error in CreateUserObject: " + e.Message);
                user = null;
            }
            return user;
        }

    }
}
