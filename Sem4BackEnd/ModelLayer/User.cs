using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Units;

namespace ModelLayer {
    public class User {
        public Map map { get; set; }
        public Upgrades upgrades {
            get;
            set;
        }
        public List<Group> groups {
            get;
            set;
        }
        public int ID {
            get;
            set;
        }
        public String Name {
            get;
            set;
        }
        public String Username {
            get;
            set;
        }
        public String Password {
            get;
            set;
        }
        public String Email {
            get;
            set;
        }
        public int Age {
            get;
            set;
        }
        public String Country {
            get;
            set;
        }
        public int Ranking {
            get;
            set;
        }
        public int Level {
            get;
            set;
        }
        private String Session {
            get;
            set;
        }

        public User() { }
    }
}
