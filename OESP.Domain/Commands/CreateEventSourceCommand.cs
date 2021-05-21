using System;
using OESP.Domain.Commands.Interfaces;
using OESP.Domain.Entities.EventContext;
using OESP.Domain.Notifications;

namespace OESP.Domain.Commands
{
    public class CreateEventSourceCommand : EntityBase, ICommandBase
    {
        public CreateEventSourceCommand(string name, string description, bool isActive, string message)
        {
            Name = name;
            Description = description;            
            IsActive = isActive;
            MessageResult = message;
        }
        public CreateEventSourceCommand(string name, string description, bool isActive)
        {
            Name = name;
            Description = description;            
            IsActive = isActive;
        }

        public string Name { get; set; }
        public string Description { get; set; }        
        public bool IsActive { get; set; }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddNotification(new Notification(message: "O nome do evento não pode estar em branco"
                , propertyName: "Name"));

            if (string.IsNullOrEmpty(Description))
                AddNotification(new Notification(message: "A descrição do evento não pode estar em branco"
                , propertyName: "Description"));

            return (Notifications.Count == 0 ? true : false);

        }
    }
}