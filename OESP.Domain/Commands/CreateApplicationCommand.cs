using System;
using OESP.Domain.Commands.Interfaces;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Notifications;

namespace OESP.Domain.Commands
{
    public class CreateApplicationCommand: EntityBase, ICommandBase
    {
        protected CreateApplicationCommand(){}
        public CreateApplicationCommand(string applicationName, string applicationDescription)
        {
            ApplicationName = applicationName;
            ApplicationDescription = applicationDescription;            
        }

        public string ApplicationName { get; set; }
        public string ApplicationDescription { get; set; }


        public bool Validate()
        {
            if(string.IsNullOrEmpty(ApplicationName))
                AddNotification(new Notification(message:"O nome da aplicação não pode estar em branco"
                , "ApplicationName"));

            if(string.IsNullOrEmpty(ApplicationDescription))
                AddNotification(new Notification(message:"A descrição da aplicação não pode estar em branco"
                , "ApplicationDescription"));

            return (Notifications.Count == 0)? true:false;
        }

    }


}