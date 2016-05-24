using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Location
    {
        public Location(float x, float y)
        {
            X = x;
            Y = y;
        }

        [DataMember]
        public float X
        {
            get;
            set;
        }
        [DataMember]
        public float Y
        {
            get;
            set;
        }
    }
}
