using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OESP.Domain.Commands;

namespace OESP.Test.Tests.Commands
{
    [TestClass]
    public class CreateEventSourceCommandTest
    {
        [TestMethod]
        public void ValidateFail()
        {
            var command = new CreateEventSourceCommand(name: "", description: ""
            , isActive: false);

            Assert.AreEqual(false, command.Validate());
        }

        [TestMethod]
        public void Validateok()
        {
            var command = new CreateEventSourceCommand(name: "Evento", description: "Descrição do evento"
            , isActive: false);

            Assert.AreEqual(true, command.Validate());
        }


    }
}