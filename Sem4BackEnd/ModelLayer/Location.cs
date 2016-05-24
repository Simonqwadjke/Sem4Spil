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
