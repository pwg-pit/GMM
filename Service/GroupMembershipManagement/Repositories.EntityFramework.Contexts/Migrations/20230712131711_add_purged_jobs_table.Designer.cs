﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.EntityFramework.Contexts;

#nullable disable

namespace Repositories.EntityFramework.Contexts.Migrations
{
    [DbContext(typeof(GMMContext))]
    [Migration("20230712131711_add_purged_jobs_table")]
    partial class add_purged_jobs_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.PurgedSyncJob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("AllowEmptyDestination")
                        .HasColumnType("bit");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DryRunTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IgnoreThresholdOnce")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDryRunEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastRunTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastSuccessfulRunTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastSuccessfulStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurgedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Query")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requestor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RunId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TargetOfficeGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ThresholdPercentageForAdditions")
                        .HasColumnType("int");

                    b.Property<int>("ThresholdPercentageForRemovals")
                        .HasColumnType("int");

                    b.Property<int>("ThresholdViolations")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PurgedSyncJobs");
                });

            modelBuilder.Entity("Models.SyncJob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<bool>("AllowEmptyDestination")
                        .HasColumnType("bit");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DryRunTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IgnoreThresholdOnce")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDryRunEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastRunTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastSuccessfulRunTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastSuccessfulStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<string>("Query")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requestor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RunId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TargetOfficeGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ThresholdPercentageForAdditions")
                        .HasColumnType("int");

                    b.Property<int>("ThresholdPercentageForRemovals")
                        .HasColumnType("int");

                    b.Property<int>("ThresholdViolations")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SyncJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
