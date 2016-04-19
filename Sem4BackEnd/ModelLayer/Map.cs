using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Buildings;
using ModelLayer.Units;
using System.Drawing;

namespace ModelLayer{
    public class Map {
        private List<Building> buildings;
        private List<Unit> units;

        public int owner {
            get;
            private set;
        }

        public Map(int owner, List<Building> buildings) {
            this.buildings = buildings;
            this.owner = owner;
        }

        public bool placeUnit(Group group, int x, int y) {
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
        }
    }
}
