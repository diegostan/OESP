using System;
using OESP.Domain.Entities.EmailContext;

namespace OESP.Domain.Entities.EmailContext
{
    public class EmailContext : EntityBase
    {
        
        public EmailContext(string emailAddress, string emailOrigin, string message, string body)
        {
            Hash = new Guid();
            EmailAddress = emailAddress;
            EmailOrigin = emailOrigin;
            Message = message;
            Body = body;
        }

        public Guid Hash { get; private set; }
        public string EmailAddress { get; private set; }
        public string EmailOrigin { get; private set; }
        public string Message { get; private set; }
        public string Body { get; private set; }
    }
}