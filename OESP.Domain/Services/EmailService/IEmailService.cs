using OESP.Domain.Entities.EmailContext;
using OESP.Domain.Services.Interfaces;

namespace OESP.Domain.Services.EmailService
{
    public interface IEmailService:IServiceBase
    {
         bool SendEmailService(EmailContext email);
    }
}