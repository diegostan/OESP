using Microsoft.VisualStudio.TestTools.UnitTesting;
using OESP.Domain.Commands;
using OESP.Domain.Handlers;
using OESP.Test.Tests.Repositories;

namespace OESP.Test.Tests.Handlers
{
    [TestClass]
    public class UpdateApplicationStateHandlerTest
    {
        readonly ApplicationRepositoryFake _repository;
        public UpdateApplicationStateHandlerTest()
        {
            _repository = new ApplicationRepositoryFake();
        }
        /*red green refactory*/
        [TestMethod]
        public void ValidateFail()
        {
            var command = new UpdateApplicationStateCommand(id: 1, applicationName: ""
            , applicationDescription: "", isRunning:false);

            var handle = new UpdateApplicationStateHandler(_repository);

            var result = (CommandResult)handle.Handle(command);

            Assert.AreEqual(false, result.Ok);

        }

        /*red green refactory*/
        [TestMethod]
        public void ValidateOk()
        {
            var command = new UpdateApplicationStateCommand(id: 1, applicationName: "Aplicação 1"
            , applicationDescription: "Aplicação teste 1", isRunning:false);

            var handle = new UpdateApplicationStateHandler(_repository);

            var result = (CommandResult)handle.Handle(command);

            Assert.AreEqual(true, result.Ok);

        }
    }
}