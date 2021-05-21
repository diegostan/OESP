using OESP.Domain.Commands;
using OESP.Domain.Commands.Interfaces;
using OESP.Domain.Entities.EventContext;
using OESP.Domain.Handlers.Interfaces;
using OESP.Domain.Respositories;

namespace OESP.Domain.Handlers
{
    public class CreateEventSourceHandler : IHandlerBase<CreateEventSourceCommand>
    {
        readonly IEventStoreRepository _repository;

        public CreateEventSourceHandler(IEventStoreRepository repository)
        {
            _repository = repository;
        }
        public ICommandBase Handle(CreateEventSourceCommand command)
        {

            if (!command.Validate())
                return new CommandResult(ok: false, propertyName: "CreateEventSourceCommand"
                , message: "Falha na validação do comando", command.Notifications);



            var ret = new CommandResult(ok: true, propertyName: "CreateEventSourceCommand"
               , message: "Comando executado com sucesso", null);

            var eventContext = new EventContext(name: command.Name, description: command.Description
             , isActive: command.IsActive, message: command.MessageResult);

            _repository.CreateEventSource(eventContext);


            return ret;
        }
    }
}