﻿// <auto-generated />
using System;
using Locator.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Locator.Data.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Locator.Business.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TypeOfUse")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("YearOfManufacture")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("Locator.Business.Models.Characteristic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Motorization")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TransportLoadCapacity")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Characteristics", (string)null);
                });

            modelBuilder.Entity("Locator.Business.Models.Optional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Abs")
                        .HasColumnType("bit");

                    b.Property<bool>("AirBag")
                        .HasColumnType("bit");

                    b.Property<bool>("AirConditioning")
                        .HasColumnType("bit");

                    b.Property<bool>("AutomaticTransmission")
                        .HasColumnType("bit");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ElectricWindow")
                        .HasColumnType("bit");

                    b.Property<bool>("EletricLock")
                        .HasColumnType("bit");

                    b.Property<bool>("HydraulicSteering")
                        .HasColumnType("bit");

                    b.Property<int>("QuantitiesOfBags")
                        .HasColumnType("int");

                    b.Property<int>("QuantitiesOfDoorserty")
                        .HasColumnType("int");

                    b.Property<int>("QuantitiesOfPeople")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Optionals", (string)null);
                });

            modelBuilder.Entity("Locator.Business.Models.Characteristic", b =>
                {
                    b.HasOne("Locator.Business.Models.Car", "Car")
                        .WithOne("Characteristics")
                        .HasForeignKey("Locator.Business.Models.Characteristic", "CarId")
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Locator.Business.Models.Optional", b =>
                {
                    b.HasOne("Locator.Business.Models.Car", "Car")
                        .WithOne("Optional")
                        .HasForeignKey("Locator.Business.Models.Optional", "CarId")
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Locator.Business.Models.Car", b =>
                {
                    b.Navigation("Characteristics")
                        .IsRequired();

                    b.Navigation("Optional")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}