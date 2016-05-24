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
                    query += " SELECT Type FROM Units"
                           + " WHERE GroupID = " + GroupNo[i];
                }

                try
                {
                    using (SqlCommand command = DataConnection.GetDbCommand(query))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (FillUserUnitGroups(user, reader))
                                {
                                    success = true;
                                }
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
            try
            {
                do
                {
                    Group group = new Group();
                    do
                    {
                        //TODO: make Units and add to List
                        Unit unit = null;
                        switch (reader["Type"].ToString())
                        {
                            case "Rifleman":
                                unit = new Rifleman();
                                break;
                            case "Tank":
                                unit = new Tank();
                                break;
                            default:
                                Console.WriteLine("Error: UnitDB found an unknown unit type");
                                break;
                        }

                        group.units.Add(unit);
                    } while (reader.Read());
                    user.Garison.Add(group);
                    success = true;
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
            string query = "SELECT GroupID FROM Groups"
                         + " WHERE UserID = @USERID";

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
