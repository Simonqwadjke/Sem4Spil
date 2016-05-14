using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Buildings.Defense {
    public class FlameThrower : Defensive {
        public int BurnTime {
            get;
            set;
        }
        public int BurnDamage {
            get;
            set;
        }
    }
}
