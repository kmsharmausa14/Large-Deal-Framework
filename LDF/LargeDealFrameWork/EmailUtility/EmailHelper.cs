using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Configuration;
using BO;
using System.Net.Mail;
using System.Net;



namespace Utitlity
{
    public class EmailHelper
    {
        public EmailHelper()
        {
        }

        public void SendEmail(EmailType emailtype, UserEmailBO eobj)
        {
            //UserEmailBO eobj=null;
            if (emailtype == EmailType.NotificationtoDeliveryManager)
            {
                eobj = PopulateEmailNotificationDeliveryManager(eobj);
                SendEmailToUSer(eobj);

            }
            else if (emailtype == EmailType.NotificationtoBUHead)
            {
               
            }
          
           
        }


        protected void SendEmailToUSer(UserEmailBO emailbo)
        {
            var fromAddress = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["EmailFrom"],
                 "Global Service Desk");

            //var toAddress = new MailAddress(emailbo.EmailTo, "");
            var toAddress = new MailAddress("Amol_Shinde@TSYNTELORG.COM", "");

            string username = System.Web.Configuration.WebConfigurationManager.AppSettings["username"].ToString();
            string Password = System.Web.Configuration.WebConfigurationManager.AppSettings["Password"];

            string subject = emailbo.Subject;
            string body = emailbo.Body;
            string cc = emailbo.BidManagerEmailId;

            var smtp = new SmtpClient
            {
                Host = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPSERVER"],
                Port = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Port"]),
                //EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                //Credentials = new NetworkCredential(username, fromPassword)
                Credentials = new NetworkCredential(username, Password)

            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
               
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }



        protected UserEmailBO PopulateEmailNotificationDeliveryManager(UserEmailBO emailbo)
        {
          
            string EmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + emailbo.ToEmailId + " ";
            EmailBody += "</br>";
            EmailBody += "</br>";
            EmailBody += "<p style='colr:red;'>Opportunity Qualification is Pending from </p> " + emailbo.ToEmailId + " ";
            EmailBody += "</br>";
            EmailBody += "To Access the LDF Application Please Click on Link below";
            EmailBody += "</br>";
            EmailBody += "</br>";
            EmailBody += "</br>";
            EmailBody += "Thanks,";
            EmailBody += "</br>";
            EmailBody += "LDF Team";
            EmailBody += "</br>";
            EmailBody += "</br>";
            EmailBody += "[Note: This is an system generated email. Please do not reply]";
            EmailBody += "</br>";
            EmailBody += "-------------------------------------------------------------- </div></body></html>";

            emailbo.Subject = "Opportunity Details to be filled";
            emailbo.Body = EmailBody;
            return emailbo;
        }

        protected UserEmailBO PopulateEmailNotification(UserEmailBO emailBO)
        {

            return emailBO;
        }


    }
    public enum EmailType
    {
       NotificationtoDeliveryManager,
       NotificationtoBUHead
    }



}

