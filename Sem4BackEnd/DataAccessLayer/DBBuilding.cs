using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ModelLayer;
using ModelLayer.Buildings;
using ModelLayer.Buildings.Defense;
using ModelLayer.Buildings.Passive;

namespace DataAccessLayer
{
    public class DBBuilding : IDBBuilding
    {
        public bool GetUserBuildings(User user)
        {
            //TODO: Implement
            bool success = false;
            string query = "SELECT XLocation, YLocation, type, Level FROM Buildings"
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
                            if (FillUserBuildings(user, reader))
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
                Console.WriteLine("Unknown Error in GetUserBuildings: " + e.Message);
            }


            return success;
        }

        public bool SaveUserBuildings(User user)
        {
            bool success = false;
            if (user.Map.Buildinds.Count > 0)
            {
                int maxID = GetMax.GetMaxID("Building");
                string query = " DELETE FROM Buildings WHERE UserID = @USERID"
                             + " INSERT INTO Buildings(BuildingID, UserID, Xlocation, Ylocation, Type, Level)"
                             + " VALUES";

                for (int i = 0; i < user.Map.Buildinds.Count; i++)
                {
                    query += "(@BUILDINGID" + i + ", @USERID, @X" + i + ", @Y" + i + ", @TYPE" + i + ", @LEVEL" + i + ")";
                    if (i < user.Map.Buildinds.Count - 1)
                    {
                        query += ", ";
                    }
                }

                using (SqlCommand command = DataConnection.GetDbCommand(query))
                {
                    command.Parameters.AddWithValue("@USERID", user.UserID);
                    for (int i = 0; i < user.Map.Buildinds.Count; i++)
                    {
                        command.Parameters.AddWithValue("@BUILDINGID" + i, maxID++);
                        command.Parameters.AddWithValue("@X" + i, user.Map.Buildinds[i].Location.X);
                        command.Parameters.AddWithValue("@Y" + i, user.Map.Buildinds[i].Location.Y);
                        command.Parameters.AddWithValue("@TYPE" + i, user.Map.Buildinds[i].GetType().Name);
                        command.Parameters.AddWithValue("@LEVEL" + i, user.Map.Buildinds[i].Level);
                    }


                    if (command.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }

        private bool FillUserBuildings(User user, IDataReader reader)
        {
            bool success = false;
            if (user.Map == null)
            {
                user.Map = new Map();
            }
            List<Building> list = new List<Building>();
            do
            {
                Building building = null;

                int x = Convert.ToInt32(reader["Xlocation"]);
                int y = Convert.ToInt32(reader["Ylocation"]);
                Location location = new Location(x, y);

                int level = Convert.ToInt32(reader["Level"]);

                switch (reader["type"].ToString())
                {
                    case "Cannon":
                        building = new Cannon();
                        building.Location = location;
                        building.Size = new Size(3, 3);
                        building.Level = level;
                        building.Armor = 10;
                        building.HitPoints = 500;
                        break;
                    case "FlameThrower":
                        building = new FlameThrower();
                        building.Location = location;
                        building.Size = new Size(3, 3);
                        building.Level = level;
                        building.Armor = 6;
                        building.HitPoints = 400;
                        break;
                    case "GatlingTurret":
                        building = new GatlingTurret();
                        building.Location = location;
                        building.Size = new Size(3, 3);
                        building.Level = level;
                        building.Armor = 8;
                        building.HitPoints = 350;
                        break;
                    case "Wall":
                        building = new Wall();
                        building.Location = location;
                        building.Size = new Size(1, 1);
                        building.Level = level;
                        building.Armor = 20;
                        building.HitPoints = 150;
                        break;
                    case "HeadQuarters":
                        building = new HeadQuarters();
                        building.Location = location;
                        building.Size = new Size(5, 5);
                        building.Level = level;
                        building.Armor = 5;
                        building.HitPoints = 800;
                        break;
                    case "Labratory":
                        building = new Labratory();
                        building.Location = location;
                        building.Size = new Size(4, 4);
                        building.Level = level;
                        building.Armor = 2;
                        building.HitPoints = 400;
                        break;
                    case "SawMill":
                        building = new SawMill();
                        building.Location = location;
                        building.Size = new Size(5, 5);
                        building.Level = level;
                        building.Armor = 3;
                        building.HitPoints = 200;
                        break;
                    case "IronMine":
                        building = new IronMine();
                        building.Location = location;
                        building.Size = new Size(5, 5);
                        building.Level = level;
                        building.Armor = 3;
                        building.HitPoints = 200;
                        break;
                    default:
                        Console.WriteLine("Error: found unknown building type: " + reader["type"].ToString());
                        break;
                }
                list.Add(building);
            } while (reader.Read());

            user.Map.Buildinds = list;
            success = true;

            return success;
        }
    }
}
