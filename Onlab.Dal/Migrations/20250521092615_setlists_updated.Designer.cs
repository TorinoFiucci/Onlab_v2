﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Onlab.Dal;

#nullable disable

namespace Onlab.Dal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250521092615_setlists_updated")]
    partial class setlists_updated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Onlab.Dal.Entities.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("Onlab.Dal.Entities.Concert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BandId")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("Onlab.Dal.Entities.Setlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Setlists");
                });

            modelBuilder.Entity("Onlab.Dal.Entities.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Onlab.Dal.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Onlab.Dal.Entities.Concert", b =>
                {
                    b.HasOne("Onlab.Dal.Entities.Band", "Band")
                        .WithMany()
                        .HasForeignKey("BandId");

                    b.Navigation("Band");
                });

            modelBuilder.Entity("Onlab.Dal.Entities.Setlist", b =>
                {
                    b.HasOne("Onlab.Dal.Entities.Band", "Band")
                        .WithMany()
                        .HasForeignKey("BandId");

                    b.Navigation("Band");
                });

            modelBuilder.Entity("Onlab.Dal.Entities.User", b =>
                {
                    b.HasOne("Onlab.Dal.Entities.Band", "Band")
                        .WithMany("Users")
                        .HasForeignKey("BandId");

                    b.Navigation("Band");
                });

            modelBuilder.Entity("Onlab.Dal.Entities.Band", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
