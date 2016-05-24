using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Buildings.Passive {
    [DataContract]
    [KnownType(typeof(SawMill))]
    [KnownType(typeof(IronMine))]
    public abstract class Resouce : Building {
        [DataMember]
        public int prodductionHour {
            get;
            set;
        }
    }
}
