using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebAppDemo.ClassLibrary
{
    /// <summary>
    /// This class handles mail sending
    /// </summary>
    public static class Email
    {
        public static void sendEmail(string todo) {
            //setup data
            string fromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
            string fromEmailPassword = System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"];
            string emailHost = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
            int emailPort = int.Parse(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
            //SMTP and mail methods and setup
            MailMessage mail = new MailMessage();
            mail.To.Add(fromEmail);
            mail.From = new MailAddress(fromEmail);
            mail.Subject = "ASP email test.";
            string Body = todo;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(emailHost, emailPort);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(fromEmail, fromEmailPassword);
            smtp.Send(mail);
        }
    }
}