using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ApplicationServer;
using ServiceLibrary;

#region Temp
using ModelLayer;
using System.Threading;
using System.Windows.Forms;
#endregion

namespace Host {

    class Program {


        static void Main(string[] args) {
            new Program();
        }

        private Program() {
            ConvertFromUml form = new ConvertFromUml();
            bool running = true;
            do {
                header();
                String s = Console.ReadLine();
                switch(s) {
                    case "parser":
                        new Thread(() => Application.Run(new ConvertFromUml())).Start();

                        break;
                    case "user":
                        createUser();
                        break;
                    case "server":
                        using (ServiceHost host = new ServiceHost(typeof(ServiceLibrary.IServerService)))
                        {
                            Console.WriteLine("Might be running service now");
                            Console.ReadLine();
                        }
                        break;
                    case "close threads":
                        Application.Exit();
                        break;
                    case "exit":
                        Application.Exit();
                        running = false;
                        break;
                }
            } while(running);
        }

        private void header() {
            Console.Clear();
            Console.WriteLine("########################################################");
            Console.WriteLine("possible inputs:");
            Console.WriteLine("parser");
            Console.WriteLine("close threads");
            Console.WriteLine("exit");
            Console.WriteLine("########################################################");
        }

        private void userHeader() {
            Console.Clear();
            Console.WriteLine("########################################################");
            Console.WriteLine("");
            Console.WriteLine("########################################################");
        }

        private void createUser() {
            User user = new User(new SessionMannager().createSession());
            user.UserID = 1;
            bool running = true;
            do {
                String s = Console.ReadLine();
                String firstword = s.Split()[0];
                switch(firstword.ToLower()) {
                    case "name":
                        if(s.Split()[1] == "=" && s.Split().Length == 3) {
                            user.Name = s.Split()[2];
                        }
                        break;
                    case "username":
                        if(s.Split()[1] == "=" && s.Split().Length == 3) {
                            user.Username = s.Split()[2];
                        }
                        break;
                    case "password":
                        if(s.Split()[1] == "=" && s.Split().Length == 3) {
                            user.Password = s.Split()[2];
                        }
                        break;
                    case "email":
                        if(s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                    case "birthdate":
                        if(s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                    case "country":
                        if(s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                    case "ranking":
                        if(s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                    case "level":
                        if(s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                }
            } while(running);
        }
    }
}
