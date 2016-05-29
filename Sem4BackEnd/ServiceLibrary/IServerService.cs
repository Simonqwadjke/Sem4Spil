using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ModelLayer;

namespace ServiceLibrary {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServerService {

        [OperationContract]
        Map FetchMap(User user);
        [OperationContract]
        bool SaveBattle(Battle battle);
        [OperationContract]
        User Login(User user);
        [OperationContract]
        bool SaveData(User user);
    }
}
