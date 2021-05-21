using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Entities.EventContext;

namespace OESP.Infra.Data
{
    [Table("ApplicationsEventSource")]
    public class DataContext : DbContext
    {
        public DataContext(){}
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ApplicationContext> ApplicationContexts{get;set;}
        public DbSet<EventContext> EventContexts{get;set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Application context model builder*/
            modelBuilder.Entity<ApplicationContext>().ToTable("ApplicationsEventSource");
            modelBuilder.Entity<ApplicationContext>().HasKey(s =>s.ID);
            modelBuilder.Entity<ApplicationContext>().HasIndex(s=>s.ApplicationName);
            modelBuilder.Entity<ApplicationContext>().Property(s=>s.ApplicationName).HasColumnType("nvarchar(32)");
            modelBuilder.Entity<ApplicationContext>().Property(s=>s.ApplicationDescription).HasColumnType("nvarchar(64)");
            modelBuilder.Entity<ApplicationContext>().Property(s=>s.MessageResult).HasColumnType("nvarchar(128)");
            modelBuilder.Entity<ApplicationContext>().Property(s=>s.IsRunning).HasColumnType("bit");
            modelBuilder.Entity<ApplicationContext>().Property(s=>s.EventDateTime);
            modelBuilder.Entity<ApplicationContext>().Ignore(s => s.Notifications);

            /*Event context model builder*/
             modelBuilder.Entity<EventContext>().ToTable("EventStore");
            modelBuilder.Entity<EventContext>().HasKey(s =>s.ID);
            modelBuilder.Entity<EventContext>().HasIndex(s=>s.Name);
            modelBuilder.Entity<EventContext>().Property(s=>s.Name).HasColumnType("nvarchar(32)");
            modelBuilder.Entity<EventContext>().Property(s=>s.Description).HasColumnType("nvarchar(32)");
            modelBuilder.Entity<EventContext>().Property(s=>s.EventDateTime);
            modelBuilder.Entity<EventContext>().Property(s=>s.IsActive).HasColumnType("bit");
            modelBuilder.Entity<EventContext>().Ignore(s => s.Notifications);
            
            
        }
    }
}