using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DataAccessLayer;
using ModelLayer;

namespace ApplicationServer
{
    public class Manager
    {
        private MD5 md5 = MD5.Create();
        private SessionManager sessionmgr = SessionManager.getInstance();

        public User Login(User user)
        {
            MD5 md5 = MD5.Create();
            Console.WriteLine("Login Attempt for " + user.Username);
            user.Password = PasswordHashing(user.Password);
            user = new DBUser().Login(user, sessionmgr.createSession());
            if (user != null)
            {
                new DBUnit().GetUserUnits(user);
                new DBBattles().GetUserBattles(user);
                new DBUpgrade().GetUserUpgrades(user);
                new DBInvaders().GetUserInvaders(user);
                new DBBuilding().GetUserBuildings(user);
            }

            return user;
        }

        public bool SaveData(User user)
        {
            bool success = false, partSuccess = true;
            //TODO: Implement

            if (new DBUser().GetUser(user.Username) != null)
            {
                if (user.Garison != null)
                {
                    if (!new DBUnit().SaveUserUnits(user))
                    {
                        partSuccess = false;
                    }
                }
                if (user.Map != null)
                {
                    if (!new DBBuilding().SaveUserBuildings(user))
                    {
                        partSuccess = false;
                    }
                }
                if (user.Upgrades != null)
                {
                    if (!new DBUpgrade().SaveUserUpgrades(user))
                    {
                        partSuccess = false;
                    }
                }
                if (partSuccess)
                {
                    success = true;
                }
            }

            return success;
        }

        public bool SaveBattle(Battle battle)
        {
            bool success = false;

            if (new DBBattles().SaveBattle(battle))
            {
                success = true;
            }

            return success;
        }

        public Map FetchMap(User user)
        {
            Map map = null;

            if (new DBBuilding().GetUserBuildings(user))
            {
                map = user.Map;
            }

            return map;
        }

        private string PasswordHashing(string password)
        {
            Byte[] input = Encoding.ASCII.GetBytes(password);
            Byte[] hash = md5.ComputeHash(input);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
