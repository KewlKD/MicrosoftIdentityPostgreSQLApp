using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net.Mail;

namespace UDUSubApp2
{
        public class SendGridEmailSender : IEmailSender
        {

            private readonly IConfiguration configuration;
            private readonly ILogger _logger;

            public SendGridEmailSender(IConfiguration configuration, ILogger<SendGridEmailSender> logger)
            {
                this.configuration = configuration;
                this._logger = logger;
            }

            public Task SendEmailAsync(string email, string subject, string htmlMessage)
            {
                var sendGridKey = @"";
                return Execute(sendGridKey, subject, htmlMessage, email);
            }

            public Task Execute(string apiKey, string subject, string message, string email)
            {
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("kyle@cp.dk", "Company"),
                    Subject = subject,
                    PlainTextContent = message,
                    HtmlContent = message
                };
                msg.AddTo(new EmailAddress(email));

                // Disable click tracking.
                // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
                msg.SetClickTracking(false, false);

                return client.SendEmailAsync(msg);
            }
        }
    }

