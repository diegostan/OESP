using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using OESP.Domain.Entities.ApplicationContext;

namespace OESP.Domain.Queries
{
    public static class ApplicationQueries
    {
        public static Expression<Func<ApplicationContext, bool>> GetApplicationById(int id)
        {
            return (s => s.ID == id);
        }

        public static Expression<Func<ApplicationContext, bool>> GetApplicationByName(string name)
        {
            return (s => s.ApplicationName == name);
        }

    }
}