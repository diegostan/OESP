using OESP.Domain.Commands;
using OESP.Domain.Commands.Interfaces;
using OESP.Domain.Entities.EmailContext;
using OESP.Domain.Handlers.Interfaces;
using OESP.Domain.Services.EmailService;

namespace OESP.Domain.Handlers
{
    public class SendEmailHandler : IHandlerBase<SendEmailCommand>
    {
        readonly IEmailService _emailService;

        public SendEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public ICommandBase Handle(SendEmailCommand command)
        {
            var email = new EmailContext(emailAddress: command.EmailAddress, emailOrigin: command.EmailOrigin
            , message: command.Message, body: command.Body);

            if (!command.Validate())
                return new CommandResult(ok: false, propertyName: "SendEmailHandler"
                , message: "Não foi possível enviar o email", command.Notifications);

            if (!_emailService.SendEmailService(email))
                return new CommandResult(ok: false, propertyName: "SendEmailHandler"
                , message: "Falha no serviço Smtp, não foi possivel enviar o email", command.Notifications);

            return new CommandResult(ok: true, propertyName: "SendEmailHandler"
            , message: "Email enviado com sucesso", command.Notifications);

        }
    }
}