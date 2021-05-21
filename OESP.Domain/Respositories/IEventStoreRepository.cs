using OESP.Domain.Entities.EventContext;
using OESP.Domain.Respositories.Interfaces;

namespace OESP.Domain.Respositories
{
    public interface IEventStoreRepository : IRepositoryBase
    {
        void CreateEventSource(EventContext eventContext);
    }
}