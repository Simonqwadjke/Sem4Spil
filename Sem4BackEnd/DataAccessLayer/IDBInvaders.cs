using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataAccessLayer
{
    public interface IDBInvaders
    {
        bool GetUserInvaders(User user);
        bool SaveUserInvaders(User user);
    }
}
