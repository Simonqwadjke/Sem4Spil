using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataAccessLayer
{
    public interface IDBBuilding
    {
        bool GetUserBuildings(User user);
        bool SaveUserBuildings(User user);
        bool DeleteBuildings(int id);
    }
}
