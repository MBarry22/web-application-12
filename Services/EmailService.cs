namespace WebApplication12.Services
{
    using Microsoft.Extensions.Configuration;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks;
    using WebApplication12.Models;

    namespace rolesDemoSSD.Data.Services
    {
        public class EmailService : IEmailService
        {
            private readonly IConfiguration _configuration;
            public EmailService(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public Task<Response> SendSingleEmail(ComposeEmailModel payload)
            {
                var apiKey = _configuration.GetSection("SendGrid")["ApiKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("MBarry22@my.bcit.ca", "Mason Porter");
                var subject = payload.Subject;
                var to = new EmailAddress(payload.Email
                , $"{payload.FirstName} {payload.LastName}");
                var textContent = payload.Body;
                var htmlContent = $"<strong>{payload.Body}</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject
                , textContent, htmlContent);
                var request = client.SendEmailAsync(msg);
                request.Wait();
                var result = request.Result;
                return request;
            }
        }
    }
}
