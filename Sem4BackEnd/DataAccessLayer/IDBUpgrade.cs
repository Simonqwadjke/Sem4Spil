using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataAccessLayer
{
    public interface IDBUpgrade
    {
        bool GetUserUpgrades(User user);
        bool SaveUserUpgrades(User user);

    }
}
