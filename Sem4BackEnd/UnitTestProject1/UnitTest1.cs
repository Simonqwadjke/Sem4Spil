using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationServer;
using ModelLayer;
using ModelLayer.Units;
using ModelLayer.Buildings;
using ModelLayer.Buildings.Passive;
using DataAccessLayer;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Manager mgr = new Manager();

        [TestMethod]
        public void LoginTest()
        {
            User user = new User("");
            user.Password = PasswordHashing("pass");
            user.Username = "kanut";
            user = mgr.Login(user);
            Assert.IsNotNull(user, "No user returned");
            Assert.IsNotNull(user.Map, "Knud had no map");
            Assert.IsNotNull(user.Map.Buildinds[0], "Knud had no Building");
            Assert.IsNotNull(user.Garison, "Knud had no Garison");
            Assert.IsNotNull(user.Garison[0], "Knud had no Group");
            Assert.IsNotNull(user.Garison[0].units[0], "Knud had no Unit");
            Assert.IsNotNull(user.Garison[1], "Second Group missing");
            Assert.IsNotNull(user.Battles, "No Battles found");
            Assert.IsNotNull(user.Upgrades, "No Upgrades found");
            Assert.IsNotNull(user.Invaders, "No Invaders found");
        }

        [TestMethod]
        private void SaveUnitsTest()
        {
            User user = new DBUser().GetUser("kanut");
            user.Garison = new List<Group>();
            user.Garison.Add(new Group());
            user.Garison.Add(new Group());
            user.Garison[0].units.Add(new Rifleman());
            user.Garison[0].units.Add(new Rifleman());
            user.Garison[1].units.Add(new Rifleman());
            user.Garison[1].units.Add(new Rifleman());
            user.Upgrades = new Upgrades(0,0,0);
            user.Upgrades.ArmorLevel = 2;
            user.Map = new Map();
            user.Map.Buildinds = new List<Building>();
            user.Map.Buildinds.Add(new HeadQuarters());
            user.Map.Buildinds[0].Location = new Location(0, 0);
            user.Map.Buildinds.Add(new IronMine());
            user.Map.Buildinds[1].Location = new Location(5, 5);

            Assert.IsTrue(mgr.SaveData(user), "Nope");
        }

        [TestMethod]
        public void CreateUserTest()
        {
            User user = new User("");
            user.BirthDate = new DateTime(2011, 1, 1);
            user.Country = "Andet sted";
            user.Email = "nææh";
            user.Name = "ib";
            user.Password = PasswordHashing("ib");
            user.UserID = GetMax.GetMaxID("User");
            user.Username = "ib";

            Assert.IsNotNull(mgr.CreateUser(user), "no user returned");
        }

        [TestMethod]
        public void SaveUpgradesTest()
        {
            User user = new User("");
            user.UserID = 0;
            user.Upgrades = new Upgrades(0, 0, 0);

            new DBUpgrade().SaveUserUpgrades(user);
        }

        private string PasswordHashing(string password)
        {
            MD5 md5 = MD5.Create();
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
