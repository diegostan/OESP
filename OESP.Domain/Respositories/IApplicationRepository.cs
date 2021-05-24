using System.Collections.Generic;
using System.Threading.Tasks;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Respositories.Interfaces;

namespace OESP.Domain.Respositories
{
    public interface IApplicationRepository : IRepositoryBase
    {
        void CreateApplication(ApplicationContext appContext);
        void UpdateApplication(ApplicationContext appContext);
        Task<IEnumerable<ApplicationContext>> GetAllApplications();
        Task<ApplicationContext> GetApplicationByName(string name);
        Task<ApplicationContext> GetApplicationById(int id);
    }
}