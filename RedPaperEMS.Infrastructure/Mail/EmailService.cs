using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RedPaperEMS.Application.Contracts.Infrastructure;
using RedPaperEMS.Application.Models.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Threading.Tasks;

namespace RedPaperEMS.Infrastructure.Mail
{
    public class EmailService:IEmailService
    {
        private ILogger<EmailService> _logger { get; }
        public EmailSettings _emailSettings { get; }
        public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger)
        {
            _logger = logger;
            _emailSettings = mailSettings.Value;
        }


        public async Task<bool> SendMail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);

            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);

            var response = await client.SendEmailAsync(sendGridMessage);

            _logger.LogInformation("Mail Sent");

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
                return true;

            _logger.LogError("Email sending failed");
            return false;
        }
    }
}
