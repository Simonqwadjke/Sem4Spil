using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ModelLayer.Units {
    public abstract class Unit {
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
        public double Range {
            get;
            set;
        }
        public double Speed {
            get;
            set;
        }
        public int AttackSpeed {
            get;
            set;
        }
        public int UnitSize {
            get;
            set;
        }
        public Point Loaction {
            get;
            set;
        }
    }
}
