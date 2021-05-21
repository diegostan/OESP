using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using OESP.Infra.Data;
using OESP.Domain.Respositories;
using OESP.Infra.Repositories;
using OESP.Domain.Handlers;
using OESP.Domain.Services.EmailService;
using OESP.Services.Services.Email;


namespace OESP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*cors SOMENTE em dev*/
            services.AddCors();

            services.AddControllers();
            services.AddMvc();
            /*Context*/
            services.AddDbContext<DataContext>(opt =>
             opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("data"));
            
            /*Serviços hospedados*/
            services.AddHostedService<MonitorServer.Monitor>();            

            /*Inversão de controle com DI*/
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            
            services.AddTransient<CreateApplicationHandler, CreateApplicationHandler>();
            services.AddTransient<UpdateApplicationStateHandler, UpdateApplicationStateHandler>();
            services.AddTransient<SendEmailHandler, SendEmailHandler>();
            services.AddTransient<CreateEventSourceHandler, CreateEventSourceHandler>();
            
            services.AddTransient<IEmailService, EmailService>();                        
            
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OESP.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OESP.API v1"));
            }

            app.UseHttpsRedirection();
            /*cors SOMENTE em dev*/
            app.UseCors(s => s.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
