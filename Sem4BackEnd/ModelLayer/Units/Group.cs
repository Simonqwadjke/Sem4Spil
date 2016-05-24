using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Units {
    [DataContract]
    public class Group {
        [DataMember]
        public List<Unit> units {
            get;
            set;
        }
        [DataMember]
        public int unitCap {
            get;
            set;
        }
        public Group()
        {
            units = new List<Unit>();
        }
    }
}
