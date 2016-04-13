using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Units {
    abstract class Unit {
        public int HitPoints {
            get;
            set;
        }
        public int Damage {
            get;
            set;
        }
        public int Armor {
            get;
            set;
        }
        public double Radius {
            get;
            set;
        }
        public double Speed {
            get;
            set;
        }
        public int UnitSize {
            get;
            set;
        }
    }
}
