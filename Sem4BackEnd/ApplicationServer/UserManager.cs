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
        public User Login(User user)
        {
            MD5 md5 = MD5.Create();
            IDBUser dbuser = new DBUser();
            Byte[] inputBytes = Encoding.ASCII.GetBytes(user.Password);
            Byte[] hash = md5.ComputeHash(inputBytes);
            user.Password = hash.ToString();
            return null;// dbuser.Login(user.Username, user.Password);
        }
    }
}
