using System;
using System.Text;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationServer;
using ModelLayer;

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
            Assert.IsNotNull(new UserManager().Login(user), "No user returned");
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
