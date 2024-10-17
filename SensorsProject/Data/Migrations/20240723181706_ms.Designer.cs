﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SensorsProject.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240723181706_ms")]
    partial class ms
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SensorsProject.Models.DataModels.ECData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Ec")
                        .HasColumnType("float");

                    b.Property<string>("EcSensorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EcSensorId");

                    b.ToTable("ECData");
                });

            modelBuilder.Entity("SensorsProject.Models.DataModels.PhData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Ph")
                        .HasColumnType("float");

                    b.Property<string>("PhSensorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PhSensorId");

                    b.ToTable("PhData");
                });

            modelBuilder.Entity("SensorsProject.Models.Pump", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("pumpName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pumpType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("timeOff")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("timeOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pump");
                });

            modelBuilder.Entity("SensorsProject.Models.Sensor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SensorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SensorType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("Sensors");

                    b.HasDiscriminator<string>("SensorType").HasValue("Sensor");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SensorsProject.Models.ECSensor", b =>
                {
                    b.HasBaseType("SensorsProject.Models.Sensor");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Sensors", t =>
                        {
                            t.Property("Position")
                                .HasColumnName("ECSensor_Position");
                        });

                    b.HasDiscriminator().HasValue("EC");
                });

            modelBuilder.Entity("SensorsProject.Models.PhSensor", b =>
                {
                    b.HasBaseType("SensorsProject.Models.Sensor");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Ph");
                });

            modelBuilder.Entity("SensorsProject.Models.TempSensor", b =>
                {
                    b.HasBaseType("SensorsProject.Models.Sensor");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Sensors", t =>
                        {
                            t.Property("Position")
                                .HasColumnName("TempSensor_Position");
                        });

                    b.HasDiscriminator().HasValue("Temp");
                });

            modelBuilder.Entity("SensorsProject.Models.DataModels.TempData", b =>
                {
                    b.HasBaseType("SensorsProject.Models.TempSensor");

                    b.Property<double>("Temp")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.ToTable("Sensors", t =>
                        {
                            t.Property("Position")
                                .HasColumnName("TempSensor_Position");
                        });

                    b.HasDiscriminator().HasValue("TempData");
                });

            modelBuilder.Entity("SensorsProject.Models.DataModels.ECData", b =>
                {
                    b.HasOne("SensorsProject.Models.ECSensor", "ECSensor")
                        .WithMany("ECData")
                        .HasForeignKey("EcSensorId");

                    b.Navigation("ECSensor");
                });

            modelBuilder.Entity("SensorsProject.Models.DataModels.PhData", b =>
                {
                    b.HasOne("SensorsProject.Models.PhSensor", "PhSensor")
                        .WithMany("PhData")
                        .HasForeignKey("PhSensorId");

                    b.Navigation("PhSensor");
                });

            modelBuilder.Entity("SensorsProject.Models.DataModels.TempData", b =>
                {
                    b.HasOne("SensorsProject.Models.TempSensor", null)
                        .WithOne("TempData")
                        .HasForeignKey("SensorsProject.Models.DataModels.TempData", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SensorsProject.Models.ECSensor", b =>
                {
                    b.Navigation("ECData");
                });

            modelBuilder.Entity("SensorsProject.Models.PhSensor", b =>
                {
                    b.Navigation("PhData");
                });

            modelBuilder.Entity("SensorsProject.Models.TempSensor", b =>
                {
                    b.Navigation("TempData");
                });
#pragma warning restore 612, 618
        }
    }
}
