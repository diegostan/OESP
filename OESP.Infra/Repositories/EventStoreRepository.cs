using Microsoft.EntityFrameworkCore;
using OESP.Domain.Entities.EventContext;
using OESP.Domain.Respositories;
using OESP.Infra.Data;

namespace OESP.Infra.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        readonly DataContext _repository;
        public EventStoreRepository(DataContext context)
        {
            _repository = context;
        }
        public void CreateEventSource(EventContext eventContext)
        {
            _repository.EventContexts.Add(eventContext);
            _repository.SaveChanges();
        }
    }
}