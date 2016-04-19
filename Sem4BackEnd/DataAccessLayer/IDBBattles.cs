using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataAccessLayer
{
    public interface IDBBattles
    {
        bool GetBattles(User user);
        bool SaveBattle(Battle battle);

    }
}
