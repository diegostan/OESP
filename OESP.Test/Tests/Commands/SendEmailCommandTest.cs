using Microsoft.VisualStudio.TestTools.UnitTesting;
using OESP.Domain.Commands;

namespace OESP.Test.Tests.Commands
{
    [TestClass]
    public class SendEmailCommandTest
    {
        /*red green refactory*/
        [TestMethod]
        public void ValidateFail()
        {
            var command = new SendEmailCommand(emailAddress:"email", emailOrigin:"email"
            , message:"",body:"");

            Assert.AreEqual(false, command.Validate());
        }

        /*red green refactory*/
        [TestMethod]
        public void ValidateOk()
        {
            var command = new SendEmailCommand(emailAddress:"A@service.com", emailOrigin:"B@service.com"
            , message:"mensagem",body:"corpo");

            Assert.AreEqual(true, command.Validate());
        }
    }
}