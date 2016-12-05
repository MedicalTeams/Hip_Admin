using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.SessionObject
{
    public partial class SessionData
    {
        // private constructor     
        private SessionData()
        {
        }

        // Gets the current session.     
        public static SessionData Current
        {
            // partially following singleton pattern where only one instance of session exists and if it disappears it will reinstantiate itself
            get
            {
                SessionData session = (SessionData)HttpContext.Current.Session["MTIHealthInformationProgramSessionData"];
                if (session == null)
                {
                    session = new SessionData();
                    HttpContext.Current.Session["MTIHealthInformationProgramSessionData"] = session;
                }

                return session;
            }
        }

        public static void Reset()
        {
            SessionData session = (SessionData)HttpContext.Current.Session["MTIHealthInformationProgramSessionData"];
            if (session == null)
            {
                session = new SessionData();
                HttpContext.Current.Session["MTIHealthInformationProgramSessionData"] = null;
            }
        }
    }
}