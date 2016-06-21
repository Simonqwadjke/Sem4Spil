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
                int x = Convert.ToInt32(reader["Xlocation"]);
                int y = Convert.ToInt32(reader["Ylocation"]);
                Location location = new Location(x, y);

                int level = Convert.ToInt32(reader["Level"]);

                switch (reader["type"].ToString())
                {
                    case "Cannon":
                        Cannon cannon = new Cannon();
                        cannon.Armor = 10;
                        cannon.AttackSpeed = 2250;
                        cannon.Damage = 110;
                        cannon.HitPoints = 500;
                        cannon.Level = level;
                        cannon.Location = location;
                        cannon.Range = 7;
                        cannon.Size = new Size(3, 3);
                        cannon.SplashDamage = 50;
                        cannon.SplashRadius = 1.5;
                        list.Add(cannon);
                        break;
                    case "FlameThrower":
                        FlameThrower flame = new FlameThrower();
                        flame.Armor = 6;
                        flame.AttackSpeed = 200;
                        flame.BurnDamage = 5;
                        flame.BurnTime = 5;
                        flame.Damage = 18;
                        flame.HitPoints = 400;
                        flame.Level = level;
                        flame.Location = location;
                        flame.Range = 4;
                        flame.Size = new Size(3, 3);
                        list.Add(flame);
                        break;
                    case "GatlingTurret":
                        GatlingTurret gatling = new GatlingTurret();
                        gatling.Accuracy = 85;
                        gatling.Armor = 8;
                        gatling.AttackSpeed = 500;
                        gatling.Damage = 30;
                        gatling.HitPoints = 350;
                        gatling.Level = level;
                        gatling.Location = location;
                        gatling.Range = 5;
                        gatling.Size = new Size(3, 3);
                        list.Add(gatling);
                        break;
                    case "Wall":
                        Wall wall = new Wall();
                        wall.Armor = 20;
                        wall.AttackSpeed = 0;
                        wall.Damage = 0;
                        wall.DefensiveFactor = 10;
                        wall.HitPoints = 150;
                        wall.Level = level;
                        wall.Location = location;
                        wall.Range = 0;
                        wall.Size = new Size(1, 1);
                        list.Add(wall);
                        break;
                    case "HeadQuarters":
                        HeadQuarters head = new HeadQuarters();
                        head.Armor = 5;
                        head.HitPoints = 800;
                        head.Level = level;
                        head.Location = location;
                        head.Size = new Size(5, 5);
                        list.Add(head);
                        break;
                    case "Labratory":
                        Labratory lab = new Labratory();
                        lab.Armor = 2;
                        lab.HitPoints = 400;
                        lab.Level = level;
                        lab.Location = location;
                        lab.Size = new Size(4, 4);
                        list.Add(lab);
                        break;
                    case "SawMill":
                        SawMill saw = new SawMill();
                        saw.Armor = 3;
                        saw.HitPoints = 200;
                        saw.Level = level;
                        saw.Location = location;
                        saw.prodductionHour = 200;
                        saw.Size = new Size(5, 5);
                        list.Add(saw);
                        break;
                    case "IronMine":
                        IronMine mine= new IronMine();
                        mine.Armor = 3;
                        mine.HitPoints = 200;
                        mine.Level = level;
                        mine.Location = location;
                        mine.prodductionHour = 200;
                        mine.Size = new Size(5, 5);
                        list.Add(mine);
                        break;
                    default:
                        Console.WriteLine("Error: found unknown building type: " + reader["type"].ToString());
                        break;
                }
            } while (reader.Read());

            user.Map.Buildinds = list;
            success = true;

            return success;
        }
    }
}
