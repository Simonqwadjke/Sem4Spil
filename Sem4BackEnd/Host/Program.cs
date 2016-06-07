using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data.SqlClient;
using ApplicationServer;
using ServiceLibrary;
using DataAccessLayer;

#region Temp
using ModelLayer;
using ModelLayer.Units;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
#endregion

namespace Host
{

    class Program
    {

        static void Main(string[] args)
        {
                try
                {
                    using (ServiceHost host = new ServiceHost(typeof(ServiceLibrary.ServerService)))
                    {
                        host.Open();
                        DataConnection.GetDbCommand("");
                        SessionManager mgr = SessionManager.getInstance();
                        while (host.State.ToString().Equals("Opened"))
                        {
                            Console.Clear();
                            Console.WriteLine("Service is open");
                            Console.WriteLine("Number of ChannelDispatchers: " + host.ChannelDispatchers.Count);
                            Console.WriteLine("BaseAddress: " + host.BaseAddresses[0].ToString());
                            Console.WriteLine("Press enter to refresh: last refresh at " + DateTime.Now);
                            if (Console.ReadLine().Equals("exit"))
                            {
                                host.Close();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.Clear();
                    Console.WriteLine("Unable to connect to database\n please check internet connection or database availability");
                    Console.WriteLine("  enter 'exit' to shutdown, any other input will retry");
                    if (!Console.ReadLine().Equals("exit"))
                    {
                        Application.Restart();
                    }
                }
                catch (CommunicationObjectFaultedException e)
                {
                    Console.Clear();
                    Console.WriteLine("Please start the server application as administrator");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                }
            //new Program();
        }

        private static string TestHashing(string input)
        {
            MD5 md5 = MD5.Create();
            Byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
            #region Other way of doing it
            //string outputstring = "";
            //if (input.Length > 0)
            //{
            //    Random r = new Random();
            //    string resource = "abcdefghijklmnopqrstuvxyz";
            //    for (int i = 0; i < 10; i++)
            //    {
            //        outputstring += resource[r.Next(24)];
            //    }
            //}
            //else
            //{
            //    outputstring = input;
            //}
            #endregion
        }

        private Program()
        {
            ConvertFromUml form = new ConvertFromUml();
            bool running = true;
            do
            {
                header();
                String s = Console.ReadLine();
                switch (s)
                {
                    case "parser":
                        new Thread(() => Application.Run(new ConvertFromUml())).Start();

                        break;
                    case "user":
                        createUser();
                        break;
                    case "server":
                        break;
                    case "close threads":
                        Application.Exit();
                        break;
                    case "exit":
                        Application.Exit();
                        running = false;
                        break;
                }
            } while (running);
        }

        private void header()
        {
            Console.Clear();
            Console.WriteLine("########################################################");
            Console.WriteLine("possible inputs:");
            Console.WriteLine("parser");
            Console.WriteLine("close threads");
            Console.WriteLine("exit");
            Console.WriteLine("########################################################");
        }

        private void userHeader()
        {
            Console.Clear();
            Console.WriteLine("########################################################");
            Console.WriteLine("");
            Console.WriteLine("########################################################");
        }

        private void createUser()
        {
            User user = new User(SessionManager.getInstance().createSession());
            user.UserID = 1;
            bool running = true;
            do
            {
                String s = Console.ReadLine();
                String firstword = s.Split()[0];
                switch (firstword.ToLower())
                {
                    case "name":
                        if (s.Split()[1] == "=" && s.Split().Length == 3)
                        {
                            user.Name = s.Split()[2];
                        }
                        break;
                    case "username":
                        if (s.Split()[1] == "=" && s.Split().Length == 3)
                        {
                            user.Username = s.Split()[2];
                        }
                        break;
                    case "password":
                        if (s.Split()[1] == "=" && s.Split().Length == 3)
                        {
                            user.Password = s.Split()[2];
                        }
                        break;
                    case "email":
                        if (s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                    case "birthdate":
                        if (s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                    case "country":
                        if (s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                    case "ranking":
                        if (s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                    case "level":
                        if (s.Split()[1] == "=" && s.Split().Length == 3) { }
                        break;
                }
            } while (running);
        }
    }
}
