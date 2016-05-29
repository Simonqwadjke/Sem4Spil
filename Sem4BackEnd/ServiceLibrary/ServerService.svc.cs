using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ApplicationServer;
using ModelLayer;

namespace ServiceLibrary {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServerService : IServerService {
        Manager mgr = new Manager();

        public Map FetchMap(User user)
        {
            return mgr.FetchMap(user);
        }

        public bool SaveBattle(Battle battle)
        {
            return mgr.SaveBattle(battle);
        }

        public User Login(User user)
        {
            return mgr.Login(user);
        }

        public bool SaveData(User user)
        {
            return mgr.SaveData(user);
        }
    }
}
