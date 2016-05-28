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
                string query = "";

                for (int i = 0; i < GroupNo.Count; i++)// "Select in" kan bruges her
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
            bool success = true;
            int maxGroupID = 0, maxUnitID = 0;
            string query = "";

            List<int> groupNo = GetGroupNo(user);

            for (int i = 0; i < groupNo.Count; i++)
            {
                query += " DELETE FROM Units WHERE GroupID = @GROUPID" + i
                       + " DELETE FROM Groups WHERE GroupID = @GROUPID" + i;
            }
            if (user.Garison.Count > 0)
            {
                maxGroupID = GetMax.GetMaxID("Group");
                maxUnitID = GetMax.GetMaxID("Unit");
                query += " INSERT INTO Groups(UserID, GroupID)";
                for (int i = 0; i < user.Garison.Count; i++)
                {
                    query += " VALUES(@GROUPVALUES" + i + ")";
                }
                query += " INSERT INTO Units(UnitID, GroupID, Type)";
                for (int i = 0; i < user.Garison.Count; i++)
                {
                    for (int j = 0; j < user.Garison[i].units.Count; i++)
                    {
                        query += " VALUES(@UNITVALUES" + i + j + ")";
                    }
                }
            }

            using (SqlCommand command = DataConnection.GetDbCommand(query))
            {
                for (int i = 0; i < groupNo.Count; i++)
                {
                    command.Parameters.AddWithValue("@GROUPID" + i, groupNo[i]);
                }
                if (user.Garison.Count > 0)
                {
                    for (int i = 0; i < user.Garison.Count; i++)
                    {
                        command.Parameters.AddWithValue("@GROUPVALUES" + i, user.UserID + ", " + maxGroupID++);

                        for (int j = 0; j < user.Garison[i].units.Count; j++)
                        {
                            command.Parameters.AddWithValue("@UNITVALUES" + i + j + ")", maxUnitID++ + ", " );
                        }
                    }
                }

                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            }

            return success;
        }

        private bool FillUserUnitGroups(User user, IDataReader reader)
        {
            bool success = false;
            if (user.Garison == null)
            {
                user.Garison = new List<Group>();
            }
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
                                Console.WriteLine("Error: DBUnit found an unknown unit type");
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
