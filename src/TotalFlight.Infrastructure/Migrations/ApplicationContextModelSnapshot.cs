﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TotalFlight.Infrastructure.Data;

namespace TotalFlight.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TotalFlight.Domain.Entities.AircraftAggregate.Aircraft", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Eng1SerialNum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Eng2SerialNum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EngModel")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageThumbPath")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDispatched")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsGrounded")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Model")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Places")
                        .HasColumnType("int");

                    b.Property<string>("Prop1SerialNum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Prop2SerialNum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PropModel")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SerialNum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.AircraftAggregate.AircraftOptions", b =>
                {
                    b.Property<string>("AircraftId")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<bool>("HasElecHobbs")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsGrounded")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSimulator")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsTailWheel")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsTwin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TracksAirtime")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TracksCycles")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AircraftId");

                    b.ToTable("AircraftOptions");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.AircraftAggregate.AircraftTimes", b =>
                {
                    b.Property<string>("AircraftId")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<decimal>("AircraftTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("AircraftTotalTgt")
                        .HasColumnType("int");

                    b.Property<decimal?>("AirtimeCurrent")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("AirtimeTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("Cycles")
                        .HasColumnType("int");

                    b.Property<decimal?>("ElectricalHobbs")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Engine1Current")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Engine1Total")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("Engine2Current")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("Engine2Total")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Prop1Total")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("Prop2Total")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("AircraftId");

                    b.ToTable("AircraftTimes");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.DeadlineAggregate.Deadline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AircraftId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("DateInit")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DateIntervalInDays")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateLastCompl")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TargetCurr")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("TargetInit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("TargetInterval")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("TargetLastCompl")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(75) CHARACTER SET utf8mb4")
                        .HasMaxLength(75);

                    b.HasKey("Id");

                    b.ToTable("Deadlines");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.DeadlineAggregate.DeadlineOptions", b =>
                {
                    b.Property<Guid>("DeadlineId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsRecurring")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Target")
                        .HasColumnType("int");

                    b.Property<bool>("TracksDate")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TracksTarget")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("WarningDateThreshInDays")
                        .HasColumnType("int");

                    b.Property<decimal>("WarningTgtThresh")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("DeadlineId");

                    b.ToTable("DeadlineOptions");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.Discrepancy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AircraftId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateFinalized")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Resolution")
                        .HasColumnType("varchar(600) CHARACTER SET utf8mb4")
                        .HasMaxLength(600);

                    b.Property<Guid?>("SquawkId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<Guid>("WorkOrderId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Discrepancies");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.DiscrepancyPart", b =>
                {
                    b.Property<Guid>("DiscrepancyId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PartId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("DiscrepancyId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("DiscrepancyParts");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.DiscrepancyTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(75) CHARACTER SET utf8mb4")
                        .HasMaxLength(75);

                    b.Property<string>("Resolution")
                        .HasColumnType("varchar(600) CHARACTER SET utf8mb4")
                        .HasMaxLength(600);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("DiscrepancyTemplates");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.DiscrepancyTemplatePart", b =>
                {
                    b.Property<Guid>("DiscrepancyTemplateId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PartId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("DiscrepancyTemplateId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("DiscrepancyTemplateParts");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.LaborRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DatePerformed")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DiscrepancyId")
                        .HasColumnType("char(36)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("LaborInHours")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("LaborRecords");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.Part", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CataloguePn")
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<int>("CurrentStock")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageThumbPath")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ManufacturersPn")
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<int>("MinStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("Vendor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.Squawk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AircraftId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateResolved")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<bool>("IsGroundable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Resolution")
                        .HasColumnType("varchar(600) CHARACTER SET utf8mb4")
                        .HasMaxLength(600);

                    b.HasKey("Id");

                    b.ToTable("Squawks");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.WorkOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AircraftId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateFinalized")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.WorkOrderTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("WorkOrderTemplates");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.WorkOrderTemplateDiscrepancyTemplate", b =>
                {
                    b.Property<Guid>("WorkOrderTemplateId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DiscrepancyTemplateId")
                        .HasColumnType("char(36)");

                    b.HasKey("WorkOrderTemplateId", "DiscrepancyTemplateId");

                    b.HasIndex("DiscrepancyTemplateId");

                    b.ToTable("WorkOrderTemplateDiscrepancyTemplates");
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.AircraftAggregate.AircraftOptions", b =>
                {
                    b.HasOne("TotalFlight.Domain.Entities.AircraftAggregate.Aircraft", null)
                        .WithOne("Options")
                        .HasForeignKey("TotalFlight.Domain.Entities.AircraftAggregate.AircraftOptions", "AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.AircraftAggregate.AircraftTimes", b =>
                {
                    b.HasOne("TotalFlight.Domain.Entities.AircraftAggregate.Aircraft", null)
                        .WithOne("Times")
                        .HasForeignKey("TotalFlight.Domain.Entities.AircraftAggregate.AircraftTimes", "AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.DeadlineAggregate.DeadlineOptions", b =>
                {
                    b.HasOne("TotalFlight.Domain.Entities.DeadlineAggregate.Deadline", null)
                        .WithOne("DeadlineOptions")
                        .HasForeignKey("TotalFlight.Domain.Entities.DeadlineAggregate.DeadlineOptions", "DeadlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.DiscrepancyPart", b =>
                {
                    b.HasOne("TotalFlight.Domain.Entities.Discrepancy", "Discrepancy")
                        .WithMany("DiscrepancyParts")
                        .HasForeignKey("DiscrepancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TotalFlight.Domain.Entities.Part", "Part")
                        .WithMany("DiscrepancyParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.DiscrepancyTemplatePart", b =>
                {
                    b.HasOne("TotalFlight.Domain.Entities.DiscrepancyTemplate", "DiscrepancyTemplate")
                        .WithMany("DiscrepancyTemplateParts")
                        .HasForeignKey("DiscrepancyTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TotalFlight.Domain.Entities.Part", "Part")
                        .WithMany("DiscrepancyTemplateParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TotalFlight.Domain.Entities.WorkOrderTemplateDiscrepancyTemplate", b =>
                {
                    b.HasOne("TotalFlight.Domain.Entities.DiscrepancyTemplate", "DiscrepancyTemplate")
                        .WithMany("WorkOrderTemplateDiscrepancyTemplates")
                        .HasForeignKey("DiscrepancyTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TotalFlight.Domain.Entities.WorkOrderTemplate", "WorkOrderTemplate")
                        .WithMany("WorkOrderTemplateDiscrepancyTemplates")
                        .HasForeignKey("WorkOrderTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
