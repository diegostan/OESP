using OESP.Domain.Handlers;
using OESP.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OESP.Test.Tests.Repositories;

namespace OESP.Test.Tests.Handlers
{
    [TestClass]
    public class CreateApplicationHandlerTest
    {
        readonly ApplicationRepositoryFake _repository;

        public CreateApplicationHandlerTest()
        {
            _repository = new ApplicationRepositoryFake();
        }

        /*red green refactory*/
        [TestMethod]
        public void ValidateFail()
        {
            var command = new CreateApplicationCommand(applicationDescription: "",
            applicationName: "");

            var handle = new CreateApplicationHandler(_repository);

            var result = (CommandResult)handle.Handle(command);

            Assert.AreEqual(false, result.Ok);
        }
        
        /*red green refactory*/
        [TestMethod]
        public void ValidateOk()
        {
             var command = new CreateApplicationCommand(applicationDescription: "Descrição aplicação",
            applicationName: "Aplicação");

            var handle = new CreateApplicationHandler(_repository);

            var result = (CommandResult)handle.Handle(command);

            Assert.AreEqual(true, result.Ok);
        }
    }
}