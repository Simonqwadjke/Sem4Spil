using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ModelLayer {
    [DataContract]
    public class Upgrades {
        [DataMember]
        readonly int damageGrowth = 0;
        [DataMember]
        readonly int armorGrowth = 0;
        [DataMember]
        readonly int recourseGrowth = 0;
        [DataMember]
        public int DamageLevel {
            get;
            set;
        }
        [DataMember]
        public int ArmorLevel {
            get;
            set;
        }
        [DataMember]
        public int RecourseLevel {
            get;
            set;
        }
        [DataMember]
        public int RiflemanLevel {
            get;
            set;
        }
        [DataMember]
        public int TankLevel {
            get;
            set;
        }
        public Upgrades(int damageGrowth, int armorGrowth, int recourseGrowth) {
            this.damageGrowth = damageGrowth;
            this.armorGrowth = armorGrowth;
            this.recourseGrowth = recourseGrowth;
        }
    }
}
