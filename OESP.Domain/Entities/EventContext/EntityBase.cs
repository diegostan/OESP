using System;
using System.Collections.Generic;
using OESP.Domain.Notifications;

namespace OESP.Domain.Entities.EventContext
{
    public abstract class EntityBase
    {
        List<Notification> _notifications;
        
        public EntityBase()
        {
            _notifications = new List<Notification>();
             ID = new Guid();
        }
         public Guid ID{get; protected set;}         

         public string MessageResult {get; protected set;}
         public IReadOnlyList<Notification> Notifications => _notifications;

         public void AddNotification(Notification notification)
         {
             _notifications.Add(notification);
         }

       
    }
}