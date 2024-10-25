﻿// <auto-generated />
using System;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(TravelArrivalDbContext))]
    [Migration("20241024225709_EmpezamosAutenticacion")]
    partial class EmpezamosAutenticacion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Domain.Entities.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Domain.Entities.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DriverId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentAdress")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Domain.Entities.Driver", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Driver");
                });

            modelBuilder.Entity("Domain.Entities.Passenger", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.Property<int?>("District")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hour")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentAdress")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentDNI")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TravelId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("SchoolId");

                    b.HasIndex("TravelId");

                    b.HasDiscriminator().HasValue("Passenger");
                });

            modelBuilder.Entity("Domain.Entities.Travel", b =>
                {
                    b.HasOne("Domain.Entities.Driver", "Driver")
                        .WithMany("Travels")
                        .HasForeignKey("DriverId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Domain.Entities.Passenger", b =>
                {
                    b.HasOne("Domain.Entities.School", null)
                        .WithMany("Passengers")
                        .HasForeignKey("SchoolId");

                    b.HasOne("Domain.Entities.Travel", null)
                        .WithMany("Passenger")
                        .HasForeignKey("TravelId");
                });

            modelBuilder.Entity("Domain.Entities.School", b =>
                {
                    b.Navigation("Passengers");
                });

            modelBuilder.Entity("Domain.Entities.Travel", b =>
                {
                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("Domain.Entities.Driver", b =>
                {
                    b.Navigation("Travels");
                });
#pragma warning restore 612, 618
        }
    }
}
