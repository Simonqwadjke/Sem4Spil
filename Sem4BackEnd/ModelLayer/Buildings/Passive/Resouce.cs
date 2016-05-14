using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Buildings.Passive {
    public abstract class Resouce : Building {
        public int prodductionHour {
            get;
            set;
        }
    }
}
