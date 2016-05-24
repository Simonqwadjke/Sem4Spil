using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
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
            //TODO: Implement
            throw new NotImplementedException();
        }

        public bool DeleteBuildings(int id)
        {
            //TODO: Implement
            throw new NotImplementedException();
        }

        private bool FillUserBuildings(User user, IDataReader reader)
        {
            bool success = false;
            if (user.Map != null)
            {
                List<Building> list = new List<Building>();
                do
                {
                    Building building = null;
                    int x = Convert.ToInt32(reader["Xlocation"]);
                    int y = Convert.ToInt32(reader["Ylocation"]);
                    Location location = new Location(x, y);
                    switch (reader["type"].ToString())
                    {
                        case "Cannon":
                            building = new Cannon();
                            building.Location = location;
                            break;
                        case "FlameThrower":
                            building = new FlameThrower();
                            building.Location = location;
                            break;
                        case "GattlingTurret":
                            building = new GatlingTurret();
                            building.Location = location;
                            break;
                        case "Wall":
                            building = new Wall();
                            building.Location = location;
                            break;
                        case "HeadQuaters":
                            building = new HeadQuarters();
                            building.Location = location;
                            break;
                        case "Labratory":
                            building = new Labratory();
                            building.Location = location;
                            break;
                        case "SawMill":
                            building = new SawMill();
                            building.Location = location;
                            break;
                        case "IronMine":
                            building = new IronMine();
                            building.Location = location;
                            break;
                        default:
                            Console.WriteLine("Error: found unknown building type");
                            break;
                    }
                    list.Add(building);
                } while (reader.Read());

                user.Map.Buildinds = list;
                success = true;
            }

            return success;
        }
    }
}
