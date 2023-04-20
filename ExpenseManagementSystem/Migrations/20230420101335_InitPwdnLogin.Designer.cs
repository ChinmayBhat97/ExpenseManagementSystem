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
    [Migration("20230420101335_InitPwdnLogin")]
    partial class InitPwdnLogin
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

                    b.Property<string>("claimStatus")
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

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeptID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<bool>("keepLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("passWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("accuntNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("billingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("claimAmount")
                        .HasColumnType("int");

                    b.Property<string>("claimantEmailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("claimantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("claimingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("managerEmailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("managerName")
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
