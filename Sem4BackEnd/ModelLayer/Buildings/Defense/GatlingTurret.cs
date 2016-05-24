using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Buildings.Defense {
    [DataContract]
    public class GatlingTurret : Defensive {
        [DataMember]
        public double Accuracy {
            get;
            set;
        }
    }
}
