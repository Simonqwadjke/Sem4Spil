using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Buildings.Defense {
    [DataContract]
    [KnownType(typeof(Cannon))]
    [KnownType(typeof(GatlingTurret))]
    [KnownType(typeof(FlameThrower))]
    [KnownType(typeof(Wall))]
    public abstract class Defensive : Building{
        [DataMember]
        public int Damage {
            get;
            set;
        }
        [DataMember]
        public double Range {
            get;
            set;
        }
        [DataMember]
        public int AttackSpeed {
            get;
            set;
        }
    }
}
