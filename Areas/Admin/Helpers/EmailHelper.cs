using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using EduHome.Models;

namespace EduHome.Areas.Admin.Helpers
{
    public static class EmailHelper
    {
        public static void SendEmail(List<string> Receivers, string sub, string body)
        {

            var message = new MailMessage();

            foreach (var receiver in Receivers)
            {
                message.To.Add(receiver);
            }


            message.From = new MailAddress("mm.aleskerov93@gmail.com", "Edu Home");
            message.Subject = sub;
            message.Body = body;

            var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("mm.aleskerov93@gmail.com", "niyazi0502106331")
            };
            smtp.Send(message);
                  
        }
    }
}
