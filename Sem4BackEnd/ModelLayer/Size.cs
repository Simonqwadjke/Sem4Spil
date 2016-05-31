using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Size
    {
        [DataMember]
        public float Height
        {
            get;
            set;
        }
        [DataMember]
        public float Width
        {
            get;
            set;
        }

        public Size(float height, float width)
        {
            Height = height;
            Width = width;
        }
    }
}
