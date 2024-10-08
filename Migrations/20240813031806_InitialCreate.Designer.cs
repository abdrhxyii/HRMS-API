﻿// <auto-generated />
using System;
using HumanResource.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HumanResource.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240813031806_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HumanResource.Modals.CityModal", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("HumanResource.Modals.DepartmentModal", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HumanResource.Modals.DocumentModal", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<string>("DocumentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentId");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("HumanResource.Modals.EmployeeContactModal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("GithubId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkypeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlackId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeID")
                        .IsUnique();

                    b.ToTable("EmployeeContacts");
                });

            modelBuilder.Entity("HumanResource.Modals.EmployeeModal", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeIdManual")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MaritalStatus")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("ZIPCode")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HumanResource.Modals.OfficeLocationModal", b =>
                {
                    b.Property<int>("OfficeLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfficeLocationId"));

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeLocationId");

                    b.ToTable("OfficeLocations");
                });

            modelBuilder.Entity("HumanResource.Modals.ProfessionalEmployeeDetailsModal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfficeLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingDays")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeID")
                        .IsUnique();

                    b.HasIndex("OfficeLocationId");

                    b.ToTable("ProfessionalEmployeeDetails");
                });

            modelBuilder.Entity("HumanResource.Modals.StateModal", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("HumanResource.Modals.UserModal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserModal");
                });

            modelBuilder.Entity("HumanResource.Modals.DocumentModal", b =>
                {
                    b.HasOne("HumanResource.Modals.EmployeeModal", "EmployeeModal")
                        .WithMany("documents")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EmployeeModal");
                });

            modelBuilder.Entity("HumanResource.Modals.EmployeeContactModal", b =>
                {
                    b.HasOne("HumanResource.Modals.EmployeeModal", "EmployeeModal")
                        .WithOne("EmployeeContactModal")
                        .HasForeignKey("HumanResource.Modals.EmployeeContactModal", "EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EmployeeModal");
                });

            modelBuilder.Entity("HumanResource.Modals.EmployeeModal", b =>
                {
                    b.HasOne("HumanResource.Modals.CityModal", "CityModal")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HumanResource.Modals.StateModal", "StateModal")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CityModal");

                    b.Navigation("StateModal");
                });

            modelBuilder.Entity("HumanResource.Modals.ProfessionalEmployeeDetailsModal", b =>
                {
                    b.HasOne("HumanResource.Modals.DepartmentModal", "DepartmentModal")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HumanResource.Modals.EmployeeModal", "EmployeeModal")
                        .WithOne("ProfessionalEmployeeDetailsModal")
                        .HasForeignKey("HumanResource.Modals.ProfessionalEmployeeDetailsModal", "EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HumanResource.Modals.OfficeLocationModal", "OfficeLocationModal")
                        .WithMany()
                        .HasForeignKey("OfficeLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DepartmentModal");

                    b.Navigation("EmployeeModal");

                    b.Navigation("OfficeLocationModal");
                });

            modelBuilder.Entity("HumanResource.Modals.EmployeeModal", b =>
                {
                    b.Navigation("EmployeeContactModal");

                    b.Navigation("ProfessionalEmployeeDetailsModal");

                    b.Navigation("documents");
                });
#pragma warning restore 612, 618
        }
    }
}
