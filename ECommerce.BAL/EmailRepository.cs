using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace ECommerce.BLL
{
    public class EmailRepository : IEmailRepository
    {

        public bool SendEmail(string reciepentEmailID, string subject, string message)
        {

            //try
            //{
            //    string email = "fromemail";
            //    string password = "password";

            //    var loginInfo = new NetworkCredential(email, password);
            //    var msg = new MailMessage();
            //    var smtpClient = new SmtpClient("smtp.gmail.com", 587);

            //    msg.From = new MailAddress(email);
            //    msg.To.Add(new MailAddress(reciepentEmailID));
            //    msg.Subject = subject;
            //    msg.Body = message;
            //    msg.IsBodyHtml = true;

            //    smtpClient.EnableSsl = true;
            //    smtpClient.UseDefaultCredentials = false;
            //    smtpClient.Credentials = loginInfo;

            //    smtpClient.Send(msg);

            //    return true;

            //}
            //catch (Exception ex)
            //{

            //    return false;
            //}

            return true;
        }
    }
}