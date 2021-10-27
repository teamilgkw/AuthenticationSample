using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace AuthenticationSample.BackEnd.Web.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool SendMail(string receiverEmail,string subject, string body)
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress(_configuration["Email:Address"]);
            message.To.Add(receiverEmail);
            message.Subject = subject;
            message.Body = body;


            using SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_configuration["Email:Address"], _configuration["Email:Password"]);
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
            
        }
    }
}