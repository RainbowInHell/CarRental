﻿// <auto-generated />
using System;
using CarRental.DLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarRental.DLL.Migrations
{
    [DbContext(typeof(CarRentalContext))]
    [Migration("20221216065704_BaseEntity added")]
    partial class BaseEntityadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Car_Rental.DLL.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("PickOffDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("PickUpDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("VehicleID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar");

                    b.Property<string>("DrivingLicenseNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRented")
                        .HasColumnType("boolean");

                    b.Property<int>("VehicleModelID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedYear")
                        .HasColumnType("integer");

                    b.Property<int>("ManufacturerID")
                        .HasColumnType("integer");

                    b.Property<int>("Mileage")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.Booking", b =>
                {
                    b.HasOne("Car_Rental.DLL.Entities.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.Vehicle", b =>
                {
                    b.HasOne("Car_Rental.DLL.Entities.Booking", "Booking")
                        .WithOne("Vehicle")
                        .HasForeignKey("Car_Rental.DLL.Entities.Vehicle", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car_Rental.DLL.Entities.VehicleModel", "VehicleModel")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.VehicleModel", b =>
                {
                    b.HasOne("Car_Rental.DLL.Entities.Manufacturer", "Manufacturer")
                        .WithMany("VehicleModels")
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.Booking", b =>
                {
                    b.Navigation("Vehicle")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.Manufacturer", b =>
                {
                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("Car_Rental.DLL.Entities.VehicleModel", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
