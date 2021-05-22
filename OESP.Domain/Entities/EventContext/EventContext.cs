using System;

namespace OESP.Domain.Entities.EventContext
{
    public class EventContext:EntityBase
    {
        
        public EventContext(string name, string description, bool isActive)
        {
           
            Name = name;
            Description = description;
            EventDateTime = DateTime.Now;
            IsActive = isActive;
            
        }
        public EventContext(string name, string description, bool isActive, string message)
        {
            
            Name = name;
            Description = description;
            EventDateTime = DateTime.Now;
            IsActive = isActive;
            MessageResult = message;
        }
        
        public string Name{get;private set;}
        public string Description{get;private set;}
        public DateTime EventDateTime{get; private set;}
        public bool IsActive{get;private set;}
    }
}