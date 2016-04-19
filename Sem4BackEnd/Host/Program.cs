using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Temp
using ModelLayer;
using System.Threading;
#endregion

namespace Host {

    class Program {
        static void Main(string[] args) {
            new Program();
        }

        private Program() {
            new Thread(() => new ConvertFromUml().ShowDialog()).Start();
            Console.ReadLine();
        }

    }
}
