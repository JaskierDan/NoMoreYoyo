﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoMoreYoyo.Models;

namespace NoMoreYoyo.Migrations
{
    [DbContext(typeof(NoMoreYoyoContext))]
    [Migration("20220302204451_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Hungarian_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NoMoreYoyo.Models.BodyAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("MeasurementTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(6,0)");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("BodyAttributes");
                });

            modelBuilder.Entity("NoMoreYoyo.Models.Calory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(6,0)");

                    b.Property<decimal?>("Carbohydrates")
                        .HasColumnType("decimal(6,0)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Fats")
                        .HasColumnType("decimal(6,0)");

                    b.Property<decimal?>("Proteins")
                        .HasColumnType("decimal(6,0)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Calories");
                });

            modelBuilder.Entity("NoMoreYoyo.Models.MeasurementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Metric")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MeasurementType");
                });

            modelBuilder.Entity("NoMoreYoyo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(6,0)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(6,0)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NoMoreYoyo.Models.BodyAttribute", b =>
                {
                    b.HasOne("NoMoreYoyo.Models.MeasurementType", "MeasurementType")
                        .WithMany("BodyAttributes")
                        .HasForeignKey("MeasurementTypeId")
                        .HasConstraintName("FK__BodyAttri__Measu__2A4B4B5E")
                        .IsRequired();

                    b.HasOne("NoMoreYoyo.Models.User", "User")
                        .WithMany("BodyAttributes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__BodyAttri__UserI__2B3F6F97")
                        .IsRequired();

                    b.Navigation("MeasurementType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoMoreYoyo.Models.Calory", b =>
                {
                    b.HasOne("NoMoreYoyo.Models.User", "User")
                        .WithMany("Calories")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Calories__UserId__2C3393D0")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoMoreYoyo.Models.MeasurementType", b =>
                {
                    b.Navigation("BodyAttributes");
                });

            modelBuilder.Entity("NoMoreYoyo.Models.User", b =>
                {
                    b.Navigation("BodyAttributes");

                    b.Navigation("Calories");
                });
#pragma warning restore 612, 618
        }
    }
}
