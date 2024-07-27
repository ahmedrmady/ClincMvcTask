﻿// <auto-generated />
using System;
using Clinc.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinc.Repository.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240727125055_initalCreate")]
    partial class initalCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clinic.Core.Entities.Appointment", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("From")
                        .HasColumnType("float");

                    b.Property<DateTime>("PatientBD")
                        .HasColumnType("datetime2");

                    b.Property<double>("To")
                        .HasColumnType("float");

                    b.HasKey("DoctorId", "PatientName", "Date");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Clinic.Core.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Clinic.Core.Entities.Schedule", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("DayID")
                        .HasColumnType("int");

                    b.Property<double>("From")
                        .HasColumnType("float");

                    b.Property<double>("To")
                        .HasColumnType("float");

                    b.HasKey("DoctorId", "DayID");

                    b.HasIndex("DayID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Clinic.Core.Entities.WeekDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WeekDays");
                });

            modelBuilder.Entity("Clinic.Core.Entities.Appointment", b =>
                {
                    b.HasOne("Clinic.Core.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Clinic.Core.Entities.Schedule", b =>
                {
                    b.HasOne("Clinic.Core.Entities.WeekDay", "Day")
                        .WithMany("Schedules")
                        .HasForeignKey("DayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Core.Entities.Doctor", "Doctor")
                        .WithMany("Schedules")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Clinic.Core.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Clinic.Core.Entities.WeekDay", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
