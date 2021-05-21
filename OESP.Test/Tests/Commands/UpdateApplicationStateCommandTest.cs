using Microsoft.VisualStudio.TestTools.UnitTesting;
using OESP.Domain.Commands;

namespace OESP.Test.Tests.Commands
{
    [TestClass]
    public class UpdateApplicationStateCommandTest
    {
        /*red green refactory*/
        [TestMethod]
        public void ValidateFail()
        {
            var command = new UpdateApplicationStateCommand(id: 1, applicationName: ""
            , applicationDescription: "", isRunning:false);

            Assert.AreEqual(false, command.Validate());
        }

        /*red green refactory*/
        [TestMethod]
        public void ValidateOk()
        {
            var command = new UpdateApplicationStateCommand(id: 1, applicationName: "Aplicação 1"
            , applicationDescription: "Descrição aplicação 1", isRunning:false);

            Assert.AreEqual(true, command.Validate());
        }
    }
}