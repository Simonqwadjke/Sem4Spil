using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Units {
    [DataContract]
    [KnownType(typeof(Unit))]
    public class Rifleman : Unit {
        [DataMember]
        public int Accuricy {
            get;
            set;
        }
    }
}
