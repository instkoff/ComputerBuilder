﻿// <auto-generated />
using System;
using ComputerBuilder.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ComputerBuilder.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200302081854_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.CompatibilityPropertyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("HardwareItemId")
                        .HasColumnType("integer");

                    b.Property<string>("PropertyName")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PropertyType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HardwareItemId");

                    b.ToTable("CompatibilityProperties");
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.ComputerBuildEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BuildDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("TotalCost")
                        .HasColumnType("double precision");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("ComputerBuilds");
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.ComputerBuildHardwareItem", b =>
                {
                    b.Property<int>("ComputerBuildId")
                        .HasColumnType("integer");

                    b.Property<int>("HardwareItemId")
                        .HasColumnType("integer");

                    b.HasKey("ComputerBuildId", "HardwareItemId");

                    b.HasIndex("HardwareItemId");

                    b.ToTable("ComputerBuildHardwareItem");
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.HardwareItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<string>("Description")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("HardwareTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("HardwareTypeId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("HardwareItems");
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.HardwareTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HardwareTypes");
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.ManufacturerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.CompatibilityPropertyEntity", b =>
                {
                    b.HasOne("ComputerBuilder.DAL.Entities.HardwareItemEntity", "HardwareItem")
                        .WithMany("PropertyList")
                        .HasForeignKey("HardwareItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.ComputerBuildEntity", b =>
                {
                    b.HasOne("ComputerBuilder.DAL.Entities.UserEntity", null)
                        .WithMany("ComputerBuildCollection")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.ComputerBuildHardwareItem", b =>
                {
                    b.HasOne("ComputerBuilder.DAL.Entities.ComputerBuildEntity", "ComputerBuild")
                        .WithMany("BuildItems")
                        .HasForeignKey("ComputerBuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerBuilder.DAL.Entities.HardwareItemEntity", "HardwareItem")
                        .WithMany("BuildItems")
                        .HasForeignKey("HardwareItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerBuilder.DAL.Entities.HardwareItemEntity", b =>
                {
                    b.HasOne("ComputerBuilder.DAL.Entities.HardwareTypeEntity", "HardwareType")
                        .WithMany("HardwareList")
                        .HasForeignKey("HardwareTypeId");

                    b.HasOne("ComputerBuilder.DAL.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("HardwareList")
                        .HasForeignKey("ManufacturerId");
                });
#pragma warning restore 612, 618
        }
    }
}
