using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ModelLayer.Buildings {
    public class Building {
        private Building() {

        }
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
        public Point location {
            get;
            set;
        }

        public Size size {
            get;
            set;
        }

        public bool checkLocation(Point location) {
            if(location.X >= this.location.X && location.X <= this.location.X + size.Width && 
               location.Y >= this.location.Y && location.Y <= this.location.Y + size.Height) {
                return true;
            }
            return false;
        }
    }
}
