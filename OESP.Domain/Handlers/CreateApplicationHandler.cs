using OESP.Domain.Commands;
using OESP.Domain.Commands.Interfaces;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Handlers.Interfaces;
using OESP.Domain.Respositories;

namespace OESP.Domain.Handlers
{
    public class CreateApplicationHandler : IHandlerBase<CreateApplicationCommand>
    {
        readonly IApplicationRepository _repository;

        public CreateApplicationHandler(IApplicationRepository repository)
        {
            _repository = repository;
        }
        public ICommandBase Handle(CreateApplicationCommand command)
        {
            if(!command.Validate())
                return new CommandResult(ok: false, propertyName:"UpdateApplicationStateCommand",
                message:"Falha na validação do comando", command.Notifications);
            
            var app = new ApplicationContext(applicationName:command.ApplicationName
            ,applicationDescription:command.ApplicationDescription, isRunning:false);
            
            _repository.CreateApplication(app);
            
            return new CommandResult(ok: true, propertyName:"UpdateApplicationStateCommand",
            message:"Comando executado com sucesso", null);
            
        }
        
        
    }
}