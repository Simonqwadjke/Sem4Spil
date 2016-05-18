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
    public class DBBattles : IDBBattles
    {
        public bool GetBattles(User user)
        {
            //TODO: Implement
            bool success = false;
            string query = "SELECT BattleOutcome, PlunderedWood, PlunderedIron FROM Battles"
                         + " WHERE AttackerID = @USERID OR DefenderID = @USERID";

            using (SqlCommand command = DataConnection.GetDbCommand(query))
            {
                command.Parameters.AddWithValue("@USERID", user.UserID);

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.Battles = CreateBattlesObj(reader);
                    }
                }
            }

            return success;
        }

        public bool SaveBattle()
        {
            //TODO: Implement
            throw new NotImplementedException();
        }

        public bool SaveBattle(Battle battle)
        {
            //TODO: Implement
            bool success = false;
            int battleid = GetMax.GetMaxID("Battle");
            string query = "INSERT INTO Battles(BattleID, DefenderID, AttackerID, BattleOutcome, PlunderedWood, PlunderedIron)"
                         + " VALUES(@BATTLEID, @DEFENDERID, @ATTACKERID, @BATTLEOUTCOME, @PLUNDEREDWOOD, @PLUNDEREDIRON)";

            using (SqlCommand command = DataConnection.GetDbCommand(query))
            {
                command.Parameters.AddWithValue("@BATTLEID", battleid);
                command.Parameters.AddWithValue("@DEFENDERID", battle.DefenderID);
                command.Parameters.AddWithValue("@ATTACkerID", battle.AttackerID);
                command.Parameters.AddWithValue("@BATTLEOUTCOME", battle.Outcome);
                command.Parameters.AddWithValue("@PLUNDEREDWOOD", battle.PlunderedWood);
                command.Parameters.AddWithValue("@PLUNDEREDIRON", battle.PlunderedIron);

                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            }

            return success;
        }

        private List<Battle> CreateBattlesObj(IDataReader reader)
        {
            List<Battle> list = new List<Battle>();

            try
            {
                do
                {
                    Battle battle = new Battle();
                    battle.Outcome = reader["BattleOutcome"].ToString();
                    battle.PlunderedWood = Convert.ToInt32(reader["PlunderedWood"]);
                    battle.PlunderedIron = Convert.ToInt32(reader["plunderedIron"]);
                } while (reader.Read());
                
            }
            //TODO add more exceptions
            catch (Exception e)
            {
                Console.WriteLine("Unknown error in CreateBattlesObj " + e.Message);
            }

            return list;
        }
    }
}
