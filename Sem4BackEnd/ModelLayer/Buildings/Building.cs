using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace ModelLayer.Buildings {
    [DataContract]
    public abstract class Building {
        [DataMember]
        public int HitPoints {
            get;
            set;
        }
        [DataMember]
        public int Armor {
            get;
            set;
        }
        [DataMember]
        public int UnitSize {
            get;
            set;
        }
        [DataMember]
        public int Level {
            get;
            set;
        }
        [DataMember]
        public Point Location {
            get;
            set;
        }
        [DataMember]
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
