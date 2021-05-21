using OESP.Domain.Notifications.Interfaces;

namespace OESP.Domain.Notifications
{
    public class Notification:INotificationBase
    {
        public Notification(string message, string propertyName)
        {
            Message = message;
            PropertyName = propertyName;
        }

        public string Message{get; private set;}
        public string PropertyName{get; private set;}
    }
}