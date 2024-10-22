using MimeKit;
using QLKyTucXa.Controller.Interfaces;

namespace QLKyTucXa.Controller.Services
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;

        public EmailService(string smtpServer, int smtpPort, string smtpUser, string smtpPass)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUser = smtpUser;
            _smtpPass = smtpPass;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("YourAppName", _smtpUser));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            // Sử dụng MailKit.Net.Smtp.SmtpClient
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_smtpServer, _smtpPort, true);
                client.Authenticate(_smtpUser, _smtpPass);
                await client.SendAsync(message);
                client.Disconnect(true);
            }
        }
    }
}
