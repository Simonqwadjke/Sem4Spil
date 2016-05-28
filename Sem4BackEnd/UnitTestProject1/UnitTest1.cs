using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationServer;
using ModelLayer;
using ModelLayer.Units;
using DataAccessLayer;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTest()
        {
            User user = new User("");
            user.Password = PasswordHashing("pass");
            user.Username = "kanut";
            user = new UserManager().Login(user);
            Assert.IsNotNull(user, "No user returned");
            Assert.IsNotNull(user.Map, "Knud had no map");
            Assert.IsNotNull(user.Map.Buildinds[0], "Knud had no Building");
            Assert.IsNotNull(user.Garison, "Knud had no Garison");
            Assert.IsNotNull(user.Garison[0], "Knud had no Unit");
            Assert.IsNotNull(user.Battles, "No Battles found");
            Assert.IsNotNull(user.Upgrades, "No Upgrades found");
            Assert.IsNotNull(user.Invaders, "No Invaders found");
        }

        [TestMethod]
        public void SaveUnitsTest()
        {
            User user = new DBUser().GetUser("kanut");
            user.Garison = new List<Group>();
            user.Garison.Add(new Group());
            user.Garison.Add(new Group());
            user.Garison[0].units.Add(new Rifleman());
            user.Garison[0].units.Add(new Rifleman());
            user.Garison[1].units.Add(new Rifleman());
            user.Garison[1].units.Add(new Rifleman());

            Assert.IsTrue(new UserManager().SaveData(user), "Nope");
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
