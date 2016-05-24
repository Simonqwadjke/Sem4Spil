using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Buildings.Defense {
    [DataContract]
    public class Wall : Defensive {
        [DataMember]
        public int DefensiveFactor {
            get;
            set;
        }
    }
}
