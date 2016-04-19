using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Units {
    class Tank : Unit{
        public int SplashDamage {
            get;
            set;
        }
        public double SplashRadius {
            get;
            set;
        }
    }
}
