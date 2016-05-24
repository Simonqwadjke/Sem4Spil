using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Buildings.Defense {
    [DataContract]
    public class Cannon : Defensive {
        [DataMember]
        public int SplashDamage {
            get;
            set;
        }
        [DataMember]
        public double SplashRadius {
            get;
            set;
        }
    }
}
