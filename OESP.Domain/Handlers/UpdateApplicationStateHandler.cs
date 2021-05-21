using OESP.Domain.Commands;
using OESP.Domain.Commands.Interfaces;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Handlers.Interfaces;
using OESP.Domain.Respositories;

namespace OESP.Domain.Handlers
{
    public class UpdateApplicationStateHandler : IHandlerBase<UpdateApplicationStateCommand>
    {
        readonly IApplicationRepository _repository;

        public UpdateApplicationStateHandler(IApplicationRepository repository)
        {
            _repository = repository;
        }
        public ICommandBase Handle(UpdateApplicationStateCommand command)
        {
            if(!command.Validate())
                return new CommandResult(ok: false, propertyName:"UpdateApplicationStateCommand",
                message:"Falha na validação do comando", command.Notifications);
            
            var res = new CommandResult(ok: true, propertyName:"UpdateApplicationStateCommand",
            message:"Comando executado com sucesso", null);
            
            

            _repository.UpdateApplication(new ApplicationContext(applicationDescription: command.ApplicationDescription
            , applicationName: command.ApplicationName, id: command.IdPointer, isRunning:command.IsRunning
            , message: res.Message));
            
            return res;
            
        }
        
        
    }
}