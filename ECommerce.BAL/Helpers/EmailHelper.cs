using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace ECommerce.BLL.Helpers
{


    public class EmailHelper
    {
        /// <summary>
        /// This helper class sends an email message using the System.Net.Mail namespace
        /// </summary>
        /// <param name="fromEmail">Sender email address</param>
        /// <param name="toEmail">Recipient email address</param>
        /// <param name="bcc">Blind carbon copy email address</param>
        /// <param name="cc">Carbon copy email address</param>
        /// <param name="subject">Subject of the email message</param>
        /// <param name="body">Body of the email message</param>
        /// <param name="attachment">File to attach</param>

        #region Static Members
        public static void SendMailMessage(string toEmail, string subject, string body, List<string> attachmentFullPath = null, string bcc = null, string cc = null, string fromEmail = null)
        {
            //create the MailMessage object
            MailMessage mMailMessage = new MailMessage();

            //set the sender address of the mail message
            if (!string.IsNullOrEmpty(fromEmail))
            {
                mMailMessage.From = new MailAddress(fromEmail);
            }

            //set the recipient address of the mail message
            mMailMessage.To.Add(new MailAddress(toEmail));

            //set the blind carbon copy address
            if (!string.IsNullOrEmpty(bcc))
            {
                mMailMessage.Bcc.Add(new MailAddress(bcc));
            }

            //set the carbon copy address
            if (!string.IsNullOrEmpty(cc))
            {
                mMailMessage.CC.Add(new MailAddress(cc));
            }

            //set the subject of the mail message
            if (!string.IsNullOrEmpty(subject))
            {
                mMailMessage.Subject = "Order Status";
            }
            else
            {
                mMailMessage.Subject = subject;
            }

            //set the body of the mail message
            mMailMessage.Body = body;

            //set the format of the mail message body
            mMailMessage.IsBodyHtml = false;

            //set the priority
            mMailMessage.Priority = MailPriority.Normal;

            //add any attachments from the filesystem
            foreach (var attachmentPath in attachmentFullPath)
            {
                Attachment mailAttachment = new Attachment(attachmentPath);
                mMailMessage.Attachments.Add(mailAttachment);
            }

            //create the SmtpClient instance
            SmtpClient mSmtpClient = new SmtpClient();

            //send the mail message
            mSmtpClient.Send(mMailMessage);
        }



        public static bool SendEmail(string reciepentEmailID, string subject, string message)
        {
            try
            {
                string email = "theja.singireddy1@gmail.com";
                string password = "fr2zUbra7_=P";

                var loginInfo = new NetworkCredential(email, password);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);

                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress("pranays53@gmail.com"));
                msg.Subject = "asfasfasf";
                msg.Body = "asfasfasfas";
                msg.IsBodyHtml = true;

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;

                smtpClient.Send(msg);

                return true;

            }
            catch (Exception ex)
            {
                //Errors.Add(ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message);
                return false;
            }
          ;
        }




        /// <summary>
        /// Determines whether an email address is valid.
        /// </summary>
        /// <param name="emailAddress">The email address to validate.</param>
        /// <returns>
        /// 	<c>true</c> if the email address is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEmailAddress(string emailAddress)
        {
            // An empty or null string is not valid
            if (String.IsNullOrEmpty(emailAddress))
            {
                return (false);
            }

            // Regular expression to match valid email address
            string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            // Match the email address using a regular expression
            Regex re = new Regex(emailRegex);
            if (re.IsMatch(emailAddress))
                return (true);
            else
                return (false);
        }

        #endregion
    }
}