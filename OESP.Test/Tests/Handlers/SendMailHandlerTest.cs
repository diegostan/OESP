using Microsoft.VisualStudio.TestTools.UnitTesting;
using OESP.Domain.Commands;
using OESP.Domain.Handlers;
using OESP.Test.Tests.Repositories;
using OESP.Test.Tests.Services;

namespace OESP.Test.Tests.Handlers
{
    [TestClass]
    public class SendMailHandlerTest
    {
        readonly EmailServiceFake _service;
        
        public SendMailHandlerTest()
        {
            _service = new EmailServiceFake();
        }

        /*red green refactory*/
        [TestMethod]
        public void ValidateFail()
        {
             var command = new SendEmailCommand(emailAddress:"email", emailOrigin:"email"
            , message:"",body:"");

            var handle = new SendEmailHandler(_service);

            var result = (CommandResult)handle.Handle(command);

            Assert.AreEqual(false, result.Ok);
        }

        /*red green refactory*/
        [TestMethod]
        public void ValidateOk()
        {
             var command = new SendEmailCommand(emailAddress:"email@service.com", emailOrigin:"email@service.com"
            , message:"mensagem",body:"corpo");

            var handle = new SendEmailHandler(_service);

            var result = (CommandResult)handle.Handle(command);

            Assert.AreEqual(true, result.Ok);
        }
        
    }
}