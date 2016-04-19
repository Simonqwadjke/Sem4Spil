using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Units;

namespace ModelLayer {
    public class User {
        public Map Mad {
            get;
            set;
        }
        public Upgrades Upgrades {
            get;
            set;
        }
        public List<Group> Garison {
            get;
            set;
        }
        public List<Battle> Battles {
            get;
            set;
        }
        public List<User> Invaders {
            get;
            set;
        }
        public int UserID {
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
        public DateTime BirthDate {
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
        public String Session {
            get;
            private set;

        }
        public User(String session) {
            this.Session = session;
        }
    }
}
