﻿// <auto-generated />
using System;
using DeveloperTest.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeveloperTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210422091117_customer_tables")]
    partial class customer_tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeveloperTest.Database.Models.Customer", b =>
            {
                b.Property<int>("CustomerId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("CustomerName")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("CustomerTypeId")
                    .HasColumnType("int");

                b.HasKey("CustomerId");

                b.HasIndex("CustomerTypeId");

                b.ToTable("Customers");
            });

            modelBuilder.Entity("DeveloperTest.Database.Models.CustomerType", b =>
            {
                b.Property<int>("CustomerTypeId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("CustomerTypeId");

                b.ToTable("CustomerTypes");

                b.HasData(
                    new
                    {
                        CustomerTypeId = 1,
                        Description = "Large"
                    },
                    new
                    {
                        CustomerTypeId = 2,
                        Description = "Small"
                    });
            });

            modelBuilder.Entity("DeveloperTest.Database.Models.Job", b =>
            {
                b.Property<int>("JobId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int?>("CustomerId")
                    .HasColumnType("int");

                b.Property<string>("Engineer")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("When")
                    .HasColumnType("datetime2");

                b.HasKey("JobId");

                b.HasIndex("CustomerId");

                b.ToTable("Jobs");

                b.HasData(
                    new
                    {
                        JobId = 1,
                        Engineer = "Test",
                        When = new DateTime(2021, 4, 22, 9, 11, 16, 945, DateTimeKind.Local).AddTicks(4008)
                    });
            });

            modelBuilder.Entity("DeveloperTest.Database.Models.Customer", b =>
            {
                b.HasOne("DeveloperTest.Database.Models.CustomerType", "CustomerType")
                    .WithMany()
                    .HasForeignKey("CustomerTypeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("DeveloperTest.Database.Models.Job", b =>
            {
                b.HasOne("DeveloperTest.Database.Models.Customer", "Customer")
                    .WithMany("Jobs")
                    .HasForeignKey("CustomerId");
            });
#pragma warning restore 612, 618
        }
    }
}