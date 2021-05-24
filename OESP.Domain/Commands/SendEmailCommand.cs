using System;
using OESP.Domain.Commands.Interfaces;
using OESP.Domain.Entities.EmailContext;
using OESP.Domain.Notifications;
using OESP.Domain.Validates;

namespace OESP.Domain.Commands
{
    public class SendEmailCommand:EntityBase, ICommandBase
    {
        public SendEmailCommand(string emailAddress, string emailOrigin, string message, string body)
        {            
            EmailAddress = emailAddress;
            EmailOrigin = emailOrigin;
            Message = message;
            Body = body;            
        }        
        public string EmailAddress{get; set;}
        public string EmailOrigin{get; set;}
        public string Message{get; set;}
        public string Body{get; set;}

        public bool Validate()
        {
            if(!EmailValidate.EmailIsValid(EmailAddress))
                AddNotification(new Notification(message:"Formato de email inválido"
                , propertyName:"EmailAddress"));
            
            if(!EmailValidate.EmailIsValid(EmailOrigin))
                AddNotification(new Notification(message:"Formato de email inválido"
                , propertyName:"EmailOrigin"));

            if(string.IsNullOrEmpty(Message))
                AddNotification(new Notification(message:"A mensagem não pode estar em branco"
                , propertyName:"Message"));

            if(string.IsNullOrEmpty(Body))
                AddNotification(new Notification(message:"O corpo do email não pode estar em branco"
                , propertyName:"Body"));
            
            
            return (Notifications.Count==0? true:false);
        }
    }
}