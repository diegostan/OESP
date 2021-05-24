using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using OESP.Domain.Entities.ApplicationContext;
using Microsoft.Extensions.DependencyInjection;
using OESP.Domain.Handlers;
using OESP.Domain.Commands;

namespace OESP.API.Services
{
    public class EventSourceService
    {
        IServiceProvider ServiceProvider { get; }
        CreateEventSourceHandler _createEvent;
        SendEmailHandler _sendEmail;
        public EventSourceService(IServiceProvider service)
        {
            ServiceProvider = service;
        }
        public void InsertEventSource(ApplicationContext app)
        {
            var commandEvent = new CreateEventSourceCommand(name: app.ApplicationName
            , description: app.ApplicationDescription, isActive: app.IsRunning
            , message: $"A aplicação {app.ApplicationName} foi encerrada.");

            using (var serviceScope = this.ServiceProvider.CreateScope())
            {
                _createEvent = serviceScope.ServiceProvider.GetRequiredService<CreateEventSourceHandler>();
                _createEvent.Handle(commandEvent);
            }

            SendMail(app, commandEvent);
        }

        public void SendMail(ApplicationContext app, CreateEventSourceCommand commandEvent)
        {
            string bodyMessage = $"A aplicação {app.ApplicationName} parou de funcionar às {app.EventDateTime} " +
            ", email enviado automaticamente.";            
            string emailMessage = $"OESP {app.ApplicationName}";
            
            var command = new SendEmailCommand(emailAddress: EmailConfig.EmailAddress
            , emailOrigin: EmailConfig.EmailOrigin, message: emailMessage, body: bodyMessage);
                        

            using (var scope = this.ServiceProvider.CreateScope())
            {
                _sendEmail = scope.ServiceProvider.GetRequiredService<SendEmailHandler>();
                var result = (CommandResult)_sendEmail.Handle(command);


                if (result.Ok)
                {

                    InsertEmailEventSource(app, command, true);
                }
                else
                {
                    InsertEmailEventSource(app, command, false);
                }
            }
        }

        public void InsertEmailEventSource(ApplicationContext app, SendEmailCommand emailCommand, bool ok)
        {
            var commandOk = new CreateEventSourceCommand(name: app.ApplicationName
            , description: app.ApplicationDescription, isActive: true
            , message: $"Um email foi disparado para {emailCommand.EmailAddress} às {app.EventDateTime}.");

            var commandFail = new CreateEventSourceCommand(name: app.ApplicationName
            , description: app.ApplicationDescription, isActive: false
            , message: $"Houve uma falha ao disparar um email para {emailCommand.EmailAddress} às {app.EventDateTime}.");

            using (var serviceScope = this.ServiceProvider.CreateScope())
            {
                _createEvent = serviceScope.ServiceProvider.GetRequiredService<CreateEventSourceHandler>();
                if (ok)
                {
                    _createEvent.Handle(commandOk);
                }
                else
                {
                    _createEvent.Handle(commandFail);
                }
            }

        }


    }
}