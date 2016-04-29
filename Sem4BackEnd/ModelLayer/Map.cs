using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ModelLayer.Buildings;
using ModelLayer.Units;
using System.Drawing;

namespace ModelLayer {
    [DataContract]
    public class Map {
        public User Owner {
            get;
            set;
        }
        public List<Building> Buildinds {
            get;
            set;
        }
        public List<Group> Units {
            get;
            set;
        }
        public int wood {
            get;
            set;
        }
        public int iron {
            get;
            set;
        }
        /*
        public bool placeUnit(Group group, Point location) {
            return true; //if placement is valid;
        }

        public bool checkForBuilding(Point location) {
            bool value = false;
            foreach(Building building in buildings) {
                if(building.checkLocation(location)) {
                    value =  true;
                }
            }
            return value;
        }*/
    }
}
