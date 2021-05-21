using System.Collections.Generic;
using System.Threading.Tasks;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Respositories;

namespace OESP.Test.Tests.Repositories
{
    public class ApplicationRepositoryFake : IApplicationRepository
    {
        public Task<IEnumerable<ApplicationContext>> GetAllApplications()
        {
            throw new System.NotImplementedException();
        }

        public Task<ApplicationContext> GetApplicationById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApplicationContext> GetApplicationByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateApplication(ApplicationContext context)
        {
            
        }
    }
}