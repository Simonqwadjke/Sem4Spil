using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer {
    [DataContract]
    public class Battle {
        [DataMember]
        public int InvatedID {
            get;
            set;
        }
        [DataMember]
        public int InvaterID {
            get;
            set;
        }
        [DataMember]
        public String Outcome {
            get;
            set;
        }
        [DataMember]
        public int PlunderedWood {
            get;
            set;
        }
        [DataMember]
        public int PlunderedIron {
            get;
            set;
        }
    }
}
