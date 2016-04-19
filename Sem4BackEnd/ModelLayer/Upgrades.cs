using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer {
    public class Upgrades {
        readonly int damageGrowth = 0;
        readonly int armorGrowth = 0;
        readonly int recourseGrowth = 0;
        public int DamageLevel {
            get;
            set;
        }
        public int ArmorLevel {
            get;
            set;
        }
        public int RecourseLevel {
            get;
            set;
        }
        public int RiflemanLevel {
            get;
            set;
        }
        public int TankLevel {
            get;
            set;
        }
        public Upgrades(int damageGrowth, int armorGrowth, int recourseGrowth) {
            this.damageGrowth = damageGrowth;
            this.armorGrowth = armorGrowth;
            this.recourseGrowth = recourseGrowth;
        }
    }
}
