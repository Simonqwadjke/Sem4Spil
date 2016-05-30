using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ModelLayer;


namespace ApplicationServer
{
    public class SessionManager
    {
        List<Session> sessions;
        Timer cleaner;
        Random r;
        static SessionManager instance;

        SessionManager()
        {
            sessions = new List<Session>();
            r = new Random();
            cleaner = new Timer(new TimerCallback(cleanUp));
            cleaner.Change(10000, (int)TimeSpan.FromHours(1).TotalMilliseconds);

            #region WinForms Timer
            //Timer cleaner = Timer(10000);
            //cleaner.Tick += new EventHandler(cleanUp);
            //cleaner.Interval = 10000;//(int)TimeSpan.FromHours(1).TotalMilliseconds;
            //cleaner.Start();
            #endregion
        }
        public static SessionManager getInstance()
        {
            if (instance == null)
            {
                instance = new SessionManager();
            }
            return instance;
        }
        public String createSession()
        {
            String resource = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            String sessionString;
            bool result;

            do
            {
                result = true;
                sessionString = "";

                for (int i = 0; i < 10; i++)
                { //create new session string
                    sessionString += resource[r.Next(61)];
                }

                foreach (Session ses in sessions)
                { //test for duplicate
                    if (ses.SessionString.Equals(sessionString)) result = false;
                }
            } while (!result);

            Session session = new Session(sessionString, DateTime.Now);
            sessions.Add(session);

            return sessionString;
        }
        public bool checkSession(String sessionString)
        {
            //baseline
            bool result = false;
            DateTime now = DateTime.Now;

            foreach (Session session in sessions)
            {
                if (session.SessionString.Equals(sessionString))
                {//if session string is found
                    if (session.Expired - now < TimeSpan.FromMinutes(15))
                    {//if session is stil valid
                        session.Expired = now;//update session time
                        result = true; //return valid session
                        break;
                    }
                }
            }
            return result;
        }
        public void cleanUp(object state)//(object sender, EventArgs args)
        {
            int removedSessions = 0;
            DateTime now = DateTime.Now;
            for (int i = 0; i < sessions.Count; i++)
            {
                if (now - sessions[i].Expired > TimeSpan.FromMinutes(15))
                {
                    sessions.RemoveAt(i);
                    removedSessions++;
                }
            }
            Console.WriteLine("\nCleanup run at: " + now);
            if (removedSessions > 1)
            {
                Console.WriteLine("    " + removedSessions + " Sessions were removed");
            }
            else if (removedSessions == 1)
            {
                Console.WriteLine("    1 Session was removed");
            }
            else if (removedSessions == 0)
            {
                Console.WriteLine("    No Sessions revomed");
            }
            else
            {
                Console.WriteLine("    Potential Error: " + removedSessions + " Sessions were removed");
            }
        }
    }
}
