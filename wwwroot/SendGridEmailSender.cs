using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;

namespace UDUSubApp2.wwwroot
{

    public class SendGridEmailSender : IEmailSender
     {

    public class SendGridEmailSender private readonly IConfiguration configuration;
    private readonly ILogger _logger;

    public SendGridEmailSender(IConfiguration configuration, ILogger<SendGridEmailSender> logger)
    {
        this.configuration = configuration;
        this._logger = logger;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var sendGridKey = @"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";
        return Execute(sendGridKey, subject, htmlMessage, email);
    }

    public Task Execute(string apiKey, string subject, string message, string email)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("kyle@udu.dk", "UDU"),
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

    
