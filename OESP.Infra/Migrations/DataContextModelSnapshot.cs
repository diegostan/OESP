﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OESP.Infra.Data;

namespace OESP.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OESP.Domain.Entities.ApplicationContext.ApplicationContext", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationDescription")
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("ApplicationName")
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRunning")
                        .HasColumnType("bit");

                    b.Property<string>("MessageResult")
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationName");

                    b.ToTable("ApplicationsEventSource");
                });

            modelBuilder.Entity("OESP.Domain.Entities.EventContext.EventContext", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MessageResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("ID");

                    b.HasIndex("Name");

                    b.ToTable("EventStore");
                });
#pragma warning restore 612, 618
        }
    }
}