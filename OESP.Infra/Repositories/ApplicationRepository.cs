using System.Collections.Generic;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Respositories;
using OESP.Infra.Data;
using OESP.Domain.Queries;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OESP.Infra.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
       readonly DataContext _repository;
       public ApplicationRepository(DataContext context)
       {
           _repository = context;
       }

        public void CreateApplication(ApplicationContext appContext)
        {
            _repository.Add(appContext);
            _repository.SaveChanges();
        }

        public async Task<IEnumerable<ApplicationContext>> GetAllApplications()
        {
            return await _repository.ApplicationContexts.AsNoTracking().ToListAsync();
        }

        public async Task<ApplicationContext> GetApplicationById(int id)
        {
            return await _repository.ApplicationContexts.AsNoTracking()
            .Where(ApplicationQueries.GetApplicationById(id))
            .FirstOrDefaultAsync();
        }

        public async Task<ApplicationContext> GetApplicationByName(string name)
        {
             return await _repository.ApplicationContexts.AsNoTracking()
            .Where(ApplicationQueries.GetApplicationByName(name))
            .FirstOrDefaultAsync();
        }

        public void UpdateApplication(ApplicationContext context)
        {
                                            
            _repository.Entry(context).State = EntityState.Modified;            
             _repository.SaveChanges();
        }
    }
}