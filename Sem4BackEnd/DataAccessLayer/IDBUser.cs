using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataAccessLayer
{
    public interface IDBUser
    {
        User GetUser(string username);
        User Login(User user, string sessionstring);
        bool CreateUser(User user);
    }
}
