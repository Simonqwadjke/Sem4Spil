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
    public class UserManager
    {
        private MD5 md5 = MD5.Create();
        private SessionManager sessionmgr = new SessionManager();
        public User Login(User user)
        {
            User rtnUser = null;
            MD5 md5 = MD5.Create();
            IDBUser dbUser = new DBUser();
            IDBUnit dbUnit = new DBUnit();
            IDBBattles dbBattle = new DBBattles();
            IDBUpgrade dbUpgrade = new DBUpgrade();
            IDBInvaders dbInvader = new DBInvaders();
            IDBBuilding dbBuilding = new DBBuilding();

            user.Password = PasswordHashing(user.Password);
            rtnUser = dbUser.Login(user, sessionmgr.createSession());

            rtnUser.Map = new Map();
            rtnUser.Upgrades = new Upgrades(0,0,0); //TODO: Correct values
            dbUnit.GetUserUnits(rtnUser);
            dbBattle.GetUserBattles(rtnUser);
            dbUpgrade.GetUserUpgrades(rtnUser);
            dbInvader.GetUserInvaders(rtnUser);
            dbBuilding.GetUserBuildings(rtnUser);


            return rtnUser;
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
