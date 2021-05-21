using OESP.Domain.Entities.EmailContext;
using OESP.Domain.Services.EmailService;

namespace OESP.Test.Tests.Services
{
    public class EmailServiceFake : IEmailService
    {
        public bool SendEmailService(EmailContext email)
        {
            return true;
        }
    }
}