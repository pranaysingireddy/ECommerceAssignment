using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace ECommerce.BLL
{
    public interface IEmailRepository
    {
        bool SendEmail(string reciepentEmailID, string subject, string message);
    }
}