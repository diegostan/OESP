using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Collections.Generic;
using OESP.Domain.Entities.ApplicationContext;
using System.Linq;
using OESP.Domain.Respositories;
using Microsoft.Extensions.DependencyInjection;
using OESP.API.Services;

namespace OESP.API.MonitorServer
{
    public class Monitor : IHostedService, IDisposable
    {
        IServiceProvider ServiceProvider { get; }
        Timer _timerMonitor;
        List<ApplicationContext> _listAllApplications;

        public Monitor(IServiceProvider services)
        {
            this.ServiceProvider = services;
        }
        
        public void Monitoring()
        {
            using (var scope = this.ServiceProvider.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<IApplicationRepository>();

                _listAllApplications = _repository.GetAllApplications().Result.ToList();

                foreach (var app in _listAllApplications)
                {
                    if (app.IsRunning && DateTime.Now.Subtract(app.EventDateTime) > TimeSpan.FromSeconds(30))
                    {
                        app.SetRunningToOff();
                        _repository.UpdateApplication(app);
                        new EventSourceService(this.ServiceProvider).InsertEventSource(app);
                    }
                }
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timerMonitor = new Timer(t => Monitoring(), null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(5));                      
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timerMonitor?.Dispose();
        }

    }
}