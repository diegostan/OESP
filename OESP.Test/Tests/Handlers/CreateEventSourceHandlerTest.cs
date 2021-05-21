using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OESP.Domain.Commands;
using OESP.Domain.Handlers;
using OESP.Domain.Respositories;
using OESP.Test.Tests.Repositories;

namespace OESP.Test.Tests.Handlers
{

    [TestClass]
    public class CreateEventSourceHandlerTest
    {
        readonly IEventStoreRepository _repository;
        public CreateEventSourceHandlerTest()
        {
            _repository = new EventStoreRepositoryFake();
        }
        [TestMethod]
        public void ValidateFail()
        {
            var command = new CreateEventSourceCommand(name: "", description: ""
            , isActive: false);

            var handle = new CreateEventSourceHandler(_repository);

            var result = (CommandResult)handle.Handle(command);

            Assert.AreEqual(false, result.Ok);
        }

        [TestMethod]
        public void ValidateOk()
        {
            var command = new CreateEventSourceCommand(name: "Evento", description: "Descrição evento"
            , isActive: false);

            var handle = new CreateEventSourceHandler(_repository);

            var result = (CommandResult)handle.Handle(command);

            Assert.AreEqual(true, result.Ok);
        }
    }
}