using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Application.Services
{
    public class EmailSender : IEmailSender
    {
        //  Our private configuration variables
        private readonly string host;
        private readonly int port;
        private readonly bool enableSSL;
        private readonly string username;
        private readonly string password;

        public EmailSender(string host,int port, bool enableSSL, string username, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.username = username;
            this.password = password;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email, email));
                message.From = new MailAddress(username, "Tilbake");
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient(host, port))
                {
                    client.Port = port;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(username, password);
                    client.EnableSsl = enableSSL;
                    client.Send(message);
                }
            }
            return Task.CompletedTask;
        }
    }
}
