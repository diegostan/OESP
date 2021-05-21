using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OESP.Domain.Commands;

namespace OESP.Test.Tests.Commands
{
    [TestClass]
    public class CreateApplicationCommandTest
    {
        /*red green refactory*/
        [TestMethod]
        public void ValidateFail()
        {
            var command = new CreateApplicationCommand(applicationDescription: "",
            applicationName: "");

            Assert.AreEqual(false, command.Validate());
        }
        
        /*red green refactory*/
        [TestMethod]
        public void ValidateOk()
        {
            var command = new CreateApplicationCommand(applicationDescription: "Aplicação de teste",
            applicationName: "Aplicaçao");
            
            Assert.AreEqual(true, command.Validate());
        }
    }
}