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
            string query = "SELECT Damage, Armor, Resource, Rilfeman, Tank FROM Upgrades"
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
                            if (FillUpgradesObj(user, reader))
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
                Console.WriteLine("Unknown error at GetUserUpgrades: " + e.Message);
            }


            return success;
        }

        public bool SaveUserUpgrades(User user)
        {
            bool success = false;
            Upgrades upgrades = user.Upgrades;
            string query = "UPDATE Upgrades SET"
                         + " Damage = @DAMAGE"
                         + " Armor = @ARMOR"
                         + " Resource = @RESOURCE"
                         + " Rifleman = @RIFLEMAN"
                         + " Tank = @TANK";

            try
            {
                using (SqlCommand command = DataConnection.GetDbCommand(query))
                {
                    command.Parameters.AddWithValue("@DAMAGE", upgrades.DamageLevel);
                    command.Parameters.AddWithValue("@ARMOR", upgrades.ArmorLevel);
                    command.Parameters.AddWithValue("@RESOURCE", upgrades.RecourseLevel);
                    command.Parameters.AddWithValue("@RIFLEMAN", upgrades.RiflemanLevel);
                    command.Parameters.AddWithValue("@TANK", upgrades.TankLevel);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    }
                }
            }
                //TODO: Add more Exceptions
            catch (Exception e)
            {
                Console.WriteLine("Unknown error in SaveUserUpgrades: " + e.Message);
            }

            return success;
        }

        private bool FillUpgradesObj(User user, IDataReader reader)
        {
            bool success = false;
            Upgrades upgrades = user.Upgrades;
            if (upgrades != null)
            {
                try
                {
                    upgrades.ArmorLevel = Convert.ToInt32(reader["Armor"]);
                    upgrades.DamageLevel = Convert.ToInt32(reader["Damage"]);
                    upgrades.RecourseLevel = Convert.ToInt32(reader["Resource"]);
                    upgrades.RiflemanLevel = Convert.ToInt32(reader["Rifleman"]);
                    upgrades.TankLevel = Convert.ToInt32(reader["Tank"]); 
                    success = true;
                }
                //TODO: Add more Exceptions
                catch (Exception e)
                {
                    Console.WriteLine("Unknown error in FillUpgradesObj: " + e.Message);
                }
            }
            else
            {
                throw new Exception("UserUpgrades null in FillUpgradesObj");
            }

            return success;
        }
    }
}
