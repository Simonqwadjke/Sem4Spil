using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer {
    public class Battle {
        public int DefenderID {
            get;
            set;
        }
        public int AttackerID {
            get;
            set;
        }
        public String Outcome {
            get;
            set;
        }
        public int PlunderedWood {
            get;
            set;
        }
        public int PlunderedIron {
            get;
            set;
        }
    }
}
