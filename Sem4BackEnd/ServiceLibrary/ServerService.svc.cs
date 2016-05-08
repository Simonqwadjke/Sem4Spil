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
        public User ReturnNumber()
        {
            Console.WriteLine("Success!");
            return new User("stuff");
        }

        public User Login(User user)
        {
            Console.WriteLine("Attempting Login for" + user.Username);
            return usermgr.Login(user);
        }
    }
}
