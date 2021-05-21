using OESP.Domain.Commands.Interfaces;
using OESP.Domain.Commands;

namespace OESP.Domain.Handlers.Interfaces
{
    public interface IHandlerBase<T> where T : ICommandBase
    {
         ICommandBase Handle(T command);
    }
}