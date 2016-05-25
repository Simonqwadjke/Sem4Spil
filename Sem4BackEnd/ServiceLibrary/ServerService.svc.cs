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
        UserManager usermgr = new UserManager();

        public Map Update()
        {
            return new Map();
        }

        public User Login(User user)
        {
            return usermgr.Login(user);
        }

        public bool SaveData(User user)
        {
            //TODO: Implement
            return false;
        }
    }
}
