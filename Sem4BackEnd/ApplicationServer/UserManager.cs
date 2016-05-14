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
            MD5 md5 = MD5.Create();
            IDBUser dbuser = new DBUser();
            user.Password = PasswordHashing(user.Password);
            return dbuser.Login(user, sessionmgr.createSession());
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
