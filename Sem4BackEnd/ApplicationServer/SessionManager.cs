using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLayer;


namespace ApplicationServer {
    public class SessionManager {
        List<Session> sessions;
        Timer cleaner;
        Random r;

        public SessionManager() {
            sessions = new List<Session>();
            r = new Random();
            cleaner = new Timer();
            cleaner.Tick += new EventHandler(cleanUp);
            cleaner.Interval = TimeSpan.FromHours(1).Milliseconds;
            cleaner.Start();
        }
        public String createSession() {
            String resource = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            String sessionString;
            bool result;

            do {
                result = true;
                sessionString = "";

                for(int i = 0; i < 10; i++) { //create new session string
                    sessionString += resource[r.Next(61)];
                }

                foreach(Session ses in sessions) { //test for duplicate
                    if(ses.SessionString.Equals(sessionString)) result = false;
                }
            } while(!result);

            Session session = new Session(sessionString, DateTime.Now);
            sessions.Add(session);

            return sessionString;
        }
        public bool checkSession(String sessionString) {
            //baseline
            bool result = false; 
            DateTime now = DateTime.Now;

            foreach(Session session in sessions) {
                if(session.SessionString.Equals(sessionString)) {//if session string is found
                    if(session.Expired - now < TimeSpan.FromMinutes(15)) {//if session is stil valid
                        session.Expired = now;//update session time
                        result = true; //return valid session
                        break;
                    }
                }
            }
            return result;
        }
        public void cleanUp(object sender, EventArgs args){
            DateTime now = DateTime.Now;
            for(int i = 0; i < sessions.Count; i++ ) {
                if(sessions[1].Expired - now > TimeSpan.FromMinutes(15)){
                    sessions.RemoveAt(i);
                }
            }
        }
    }
}
