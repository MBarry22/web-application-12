namespace WebApplication12.Services
{
    using SendGrid;
    using System.Threading.Tasks;
    using WebApplication12.Models;

    namespace rolesDemoSSD.Data.Services
    {
        public interface IEmailService
        {
            Task<Response> SendSingleEmail(ComposeEmailModel payload);
        }
    }
}
