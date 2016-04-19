using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Buildings.Defense {
    public abstract class Defensive : Building{
        public int Damage {
            get;
            set;
        }
        public double Range {
            get;
            set;
        }
        public int AttackSpeed {
            get;
            set;
        }
    }
}
