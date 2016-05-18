using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Buildings.Defense {
    [DataContract]
    [KnownType(typeof(Defensive))]
    public class FlameThrower : Defensive {
        [DataMember]
        public int BurnTime {
            get;
            set;
        }
        [DataMember]
        public int BurnDamage {
            get;
            set;
        }
    }
}
