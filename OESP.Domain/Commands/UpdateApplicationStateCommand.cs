using System;
using OESP.Domain.Commands.Interfaces;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Notifications;

namespace OESP.Domain.Commands
{
    public class UpdateApplicationStateCommand: EntityBase, ICommandBase
    {
        public UpdateApplicationStateCommand(int id, string applicationName, string applicationDescription, bool isRunning)
        {
            ApplicationName = applicationName;
            ApplicationDescription = applicationDescription;
            IsRunning = isRunning;
        }
        public int IdPointer{get;set;}
        public string ApplicationName { get; set; }
        public string ApplicationDescription { get; set; }   
        public bool IsRunning{get;set;}     
        
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