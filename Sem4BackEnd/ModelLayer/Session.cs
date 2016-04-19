using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer {
    public class Session {

        readonly private String sessionString;

        public String SessionString {
            get {
                return sessionString;
            }
        }
        public DateTime Expired {
            get;
            set;
        }

        public Session(String sessionString, DateTime expired) {
            this.sessionString = sessionString;
        }
    }
}