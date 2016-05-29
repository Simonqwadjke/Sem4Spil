using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace ModelLayer.Units {
    [DataContract]
    [KnownType(typeof(Rifleman))]
    [KnownType(typeof(Tank))]
    public abstract class Unit {
        [DataMember]
        public int HitPoints {
            get;
            set;
        }
        [DataMember]
        public int Damage {
            get;
            set;
        }
        [DataMember]
        public int Armor {
            get;
            set;
        }
        [DataMember]
        public double Range {
            get;
            set;
        }
        [DataMember]
        public double Speed {
            get;
            set;
        }
        [DataMember]
        public int AttackSpeed {
            get;
            set;
        }
        [DataMember]
        public int UnitSize {
            get;
            set;
        }
        [DataMember]
        public Location Loaction {
            get;
            set;
        }
    }
}
