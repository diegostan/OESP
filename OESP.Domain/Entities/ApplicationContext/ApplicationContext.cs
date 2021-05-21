using System;

namespace OESP.Domain.Entities.ApplicationContext
{
    public class ApplicationContext : EntityBase
    {
        public ApplicationContext(string applicationName, string applicationDescription, bool isRunning)
        {
            this.ApplicationName = applicationName;
            this.ApplicationDescription = applicationDescription;
            this.EventDateTime = DateTime.Now;
            IsRunning = isRunning;
        }
        public ApplicationContext(int id, string applicationName, string applicationDescription, string message, bool isRunning)
        {
            ID = id;
            MessageResult = message;
            this.ApplicationName = applicationName;
            this.ApplicationDescription = applicationDescription;
            this.EventDateTime = DateTime.Now;
            IsRunning = isRunning;
        }

        public string ApplicationName { get; private set; }
        public string ApplicationDescription { get; private set; }
        public DateTime EventDateTime { get; private set; }
        public bool IsRunning{get;private set;}

        public void SetRunningToOff()
        {
            IsRunning = false;
        }

       

       
        
    }
}