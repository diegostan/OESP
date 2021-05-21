using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Queries;
using System.Linq;

namespace OESP.Test.Tests.Queries
{
    [TestClass]
    public class ApplicationQueriesTest
    {
        IList<ApplicationContext> _listApps;       

        /*red green refactory*/
        [TestMethod]
        public void ValidateFailGetApplicationById()
        {
            int id = 1;
            var result = _listApps.AsQueryable()
            .Where(ApplicationQueries.GetApplicationById(id))
            .ToList();

            Assert.AreEqual(0, result.Count());
        }


        /*red green refactory*/
        [TestMethod]
        public void ValidateFailGetApplicationByName()
        {
            string name = "Aplicação 4";
            var result = _listApps.AsQueryable()
            .Where(ApplicationQueries.GetApplicationByName(name))
            .ToList();

            Assert.AreEqual(0, result.Count());
        }

      public ApplicationQueriesTest()
        {
            _listApps = new List<ApplicationContext>();
            
            _listApps.Add(new ApplicationContext(applicationName:"Aplicação 1"
            ,applicationDescription:"Descrição aplicação 1", isRunning:false));

            _listApps.Add(new ApplicationContext(applicationName:"Aplicação 2"
            ,applicationDescription:"Descrição aplicação 2", isRunning:false));

            _listApps.Add(new ApplicationContext(applicationName:"Aplicação 3"
            ,applicationDescription:"Descrição aplicação 3", isRunning:false));
        }

    }
}