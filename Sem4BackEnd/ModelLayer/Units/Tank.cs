﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ModelLayer.Units {
    [DataContract]
    public class Tank : Unit {
        [DataMember]
        public int SplashDamage {
            get;
            set;
        }
        [DataMember]
        public double SplashRadius {
            get;
            set;
        }
    }
}
