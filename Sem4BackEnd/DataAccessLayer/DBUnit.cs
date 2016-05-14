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
            bool success = false;
            List<int> GroupNo = GetGroupNo(user);

            if (GroupNo.Count > 0)
            {
                //TODO: fix SELECT
                string query = "";

                for (int i = 0; i < GroupNo.Count; i++)
                {
                    query += " SELECT * FROM Unit, Group"
                           + " WHERE GroupID = " + GroupNo[i];
                }

                try
                {
                    using (SqlCommand command = DataConnection.GetDbCommand(query))
                    {
                        command.Parameters.AddWithValue("@USERID", user.UserID);

                        using (IDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FillUserUnitGroups(user, reader);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unknown error in GetUserUnits: " + e.Message);
                }
            }

            return success;
        }

        public bool SaveUserUnits(User user)
        {
            //TODO: Implement
            throw new NotImplementedException();
        }

        private bool FillUserUnitGroups(User user, IDataReader reader)
        {
            bool success = false;
            List<List<Unit>> groups = new List<List<Unit>>();
            try
            {
                do
                {
                    List<Unit> list = new List<Unit>();
                    while (reader.Read())
                    {
                        //TODO: make Units and add to List
                        Unit unit = null;

                        list.Add(unit);
                    }
                    groups.Add(list);
                } while (reader.NextResult());
            }
            //TODO: Add more exceptions
            catch (Exception e)
            {
                Console.WriteLine("Unknown error in FillUserGroups: " + e.Message);
            }

            return success;
        }

        private List<int> GetGroupNo(User user)
        {
            List<int> GroupNo = new List<int>();
            string query = "SELECT GroupID FROM Group, UserData"
                         + " WHERE Group.UserID = UserData.UserID AND UserData.UserID = @USERID";

            try
            {
                using (SqlCommand command = DataConnection.GetDbCommand(query))
                {
                    command.Parameters.AddWithValue("@USERID", user.UserID);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GroupNo.Add(Convert.ToInt32(reader["GroupID"]));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error at GetGroupNo: " + e.Message);
            }
            return GroupNo;
        }
    }
}
