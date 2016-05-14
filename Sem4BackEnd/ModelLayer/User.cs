using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ModelLayer.Units;

namespace ModelLayer
{
    [DataContract]
    public class User
    {
        [DataMember]
        public Map Map
        {
            get;
            set;
        }
        [DataMember]
        public Upgrades Upgrades
        {
            get;
            set;
        }
        [DataMember]
        public List<Group> Garison
        {
            get;
            set;
        }
        [DataMember]
        public List<Battle> Battles
        {
            get;
            set;
        }
        [DataMember]
        public List<User> Invaders
        {
            get;
            set;
        }
        [DataMember]
        public int UserID
        {
            get;
            set;
        }
        [DataMember]
        public String Name
        {
            get;
            set;
        }
        [DataMember]
        public String Username
        {
            get;
            set;
        }
        [DataMember]
        public String Password
        {
            get;
            set;
        }
        [DataMember]
        public String Email
        {
            get;
            set;
        }
        [DataMember]
        public DateTime BirthDate
        {
            get;
            set;
        }
        [DataMember]
        public String Country
        {
            get;
            set;
        }
        [DataMember]
        public int Ranking
        {
            get;
            set;
        }
        [DataMember]
        public int Level
        {
            get;
            set;
        }
        [DataMember]
        public DateTime LastLogin
        {
            get;
            set;
        }
        [DataMember]
        public String Session
        {
            get;
            private set;

        }
        public User(String session)
        {
            this.Session = session;
        }
    }
}
