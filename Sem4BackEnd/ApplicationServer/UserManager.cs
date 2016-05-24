﻿using System;
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
            IDBBuilding dbBuilding = new DBBuilding();
            IDBUnit dbUnit = new DBUnit();
            IDBUpgrade dbUpgrade= new DBUpgrade();

            user.Password = PasswordHashing(user.Password);
            rtnUser = dbUser.Login(user, sessionmgr.createSession());

            rtnUser.Map = new Map();
            dbBuilding.GetUserBuildings(rtnUser);
            dbUnit.GetUserUnits(rtnUser);
            dbUpgrade.GetUserUpgrades(user);

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
