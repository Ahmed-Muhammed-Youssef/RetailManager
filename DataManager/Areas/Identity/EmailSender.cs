using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace DataManager.Areas.Identity
{
    public class EmailSender : IEmailSender
    {
        private string apiKey;
        private string fromName;
        private string fromEmail;

        public EmailSender(IConfiguration configuration)
        {
            apiKey = configuration["SendGrid:ApiKey"];
            fromName = configuration["SendGrid:FromName"];
            fromEmail = configuration["SendGrid:FromEmail"];
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = subject,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);
            await client.SendEmailAsync(msg);
        }
       
    }
}
