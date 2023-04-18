﻿// <auto-generated />
using System;
using ExpenseManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230418065228_InitForEmployees")]
    partial class InitForEmployees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExpenseManagementSystem.Models.ClaimStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClaimStatuses");
                });

            modelBuilder.Entity("ExpenseManagementSystem.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("departmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ExpenseManagementSystem.Models.Employee", b =>
                {
                    b.Property<int>("empID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("empID"), 1L, 1);

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeptID")
                        .HasColumnType("int");

                    b.Property<decimal>("adhaarCardNum")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empEmailID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("empPhoneNum")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("empUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gendID")
                        .HasColumnType("int");

                    b.HasKey("empID");

                    b.HasIndex("DeptID");

                    b.HasIndex("gendID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ExpenseManagementSystem.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("empGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("ExpenseManagementSystem.Models.PersonalClaim", b =>
                {
                    b.Property<int>("claimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("claimID"), 1L, 1);

                    b.Property<int>("DeptID")
                        .HasColumnType("int");

                    b.Property<string>("IFSC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("accuntNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("billingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("claimantEmailID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("claimantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("claimingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("managerEmailID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("managerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stusID")
                        .HasColumnType("int");

                    b.HasKey("claimID");

                    b.HasIndex("DeptID");

                    b.HasIndex("stusID");

                    b.ToTable("PersonalClaims");
                });

            modelBuilder.Entity("ExpenseManagementSystem.Models.Employee", b =>
                {
                    b.HasOne("ExpenseManagementSystem.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DeptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpenseManagementSystem.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("gendID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("ExpenseManagementSystem.Models.PersonalClaim", b =>
                {
                    b.HasOne("ExpenseManagementSystem.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DeptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpenseManagementSystem.Models.ClaimStatus", "ClaimStatus")
                        .WithMany()
                        .HasForeignKey("stusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClaimStatus");

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
