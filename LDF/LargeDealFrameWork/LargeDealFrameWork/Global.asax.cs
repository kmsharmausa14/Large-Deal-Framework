using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;

namespace LargeDealFrameWork
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            string strLDFUrl = string.Empty;//"http://172.29.48.2/ldf/login/signInPage.aspx";
            string strHostName = System.Net.Dns.GetHostName();
            string ipaddress = "";
            ipaddress=System.Net.Dns.GetHostByName(strHostName).AddressList[0].ToString();
            //System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(strHostName);
            //System.Net.IPAddress[] iplist = ip.AddressList;
            //if (iplist[1] != null)
            //{
               // string ipaddress = iplist[1].ToString();
            
                Application["ipaddress"] = ipaddress;
                 strLDFUrl = "http://" + ipaddress + "/ldf/login/signInPage.aspx";
                Application["LDFURL"] = strLDFUrl;
            //}

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        // Get Forms Identity From Current User
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        // Get Forms Ticket From Identity object
                        FormsAuthenticationTicket ticket = id.Ticket;
                        // Retrieve stored user-data (our roles from db)
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        // Create a new Generic Principal Instance and assign to Current User
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }

    }
}
