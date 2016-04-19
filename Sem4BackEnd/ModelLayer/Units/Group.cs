using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Units {
    public class Group {
        public List<Unit> units {
            get;
            set;
        }
        public int unitCap {
            get;
            set;
        }
    }
}
