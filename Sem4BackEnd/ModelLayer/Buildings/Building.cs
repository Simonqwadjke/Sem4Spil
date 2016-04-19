using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ModelLayer.Buildings {
    public abstract class Building {
        public int HitPoints {
            get;
            set;
        }
        public int Armor {
            get;
            set;
        }
        public int UnitSize {
            get;
            set;
        }
        public int Level {
            get;
            set;
        }
        public Point Location {
            get;
            set;
        }
        public Size Size {
            get;
            set;
        }

        public bool checkLocation(Point location) {
            if(location.X >= this.Location.X && location.X <= this.Location.X + Size.Width && 
               location.Y >= this.Location.Y && location.Y <= this.Location.Y + Size.Height) {
                return true;
            }
            return false;
        }
    }
}
