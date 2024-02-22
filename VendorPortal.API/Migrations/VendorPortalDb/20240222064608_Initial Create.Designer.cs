﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendorPortal.API.Data;

#nullable disable

namespace VendorPortal.API.Migrations.VendorPortalDb
{
    [DbContext(typeof(VendorPortalDbContext))]
    [Migration("20240222064608_Initial Create")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VendorPortal.API.Models.Domain.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentList")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VendorPortal.API.Models.Domain.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectHeadId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectHeadName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("VendorPortal.API.Models.Domain.RFP", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Project")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("RFPs");
                });

            modelBuilder.Entity("VendorPortal.API.Models.Domain.VendorCategory", b =>
                {
                    b.Property<string>("VendorId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("VendorId", "CategoryId");

                    b.ToTable("VendorCategories");
                });

            modelBuilder.Entity("VendorPortal.API.Models.Domain.RFP", b =>
                {
                    b.HasOne("VendorPortal.API.Models.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}