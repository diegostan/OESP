using System.Net;
using System.Net.Mail;
using OESP.Domain.Entities.EmailContext;
using OESP.Domain.Services.EmailService;
using OESP.Domain.Services.Interfaces;
using OESP.Services.Services.Email.Keys;

namespace OESP.Services.Services.Email
{
    public class EmailService : IEmailService, IServiceBase
    {
        MailMessage _mail;
        SmtpService _smtpService;
        NetworkCredential _credential;
     
        public bool SendEmailService(EmailContext email)
        {            
            _mail = new MailMessage(from:email.EmailOrigin, to:email.EmailAddress
            ,body:email.Body, subject:email.Message);

            _smtpService = new SmtpService();
            _credential = new NetworkCredential(email.EmailOrigin, EmailKey.GetEmailKey());

            return _smtpService.SendEmail(_mail, _credential);            
        }
    }
}