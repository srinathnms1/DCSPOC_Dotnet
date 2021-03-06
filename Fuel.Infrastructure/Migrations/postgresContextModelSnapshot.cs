﻿// <auto-generated />
using System;
using System.Collections;
using Fuel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fuel.Infrastructure.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Fuel.Domain.DcsDriverMaster", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'', '1', '', '100000', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DriverMobile")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("DriverId");

                    b.ToTable("DCS_DriverMaster");
                });

            modelBuilder.Entity("Fuel.Domain.DcsDriverService", b =>
                {
                    b.Property<int>("DriverServiceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double?>("DistanceTravelled")
                        .HasColumnType("double precision");

                    b.Property<int>("DriverVehicleId")
                        .HasColumnType("integer");

                    b.Property<double?>("DrivingTimeHours")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double?>("RestTimeHours")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("RestingEndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("RestingStartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("VehicleEndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("VehicleStartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double?>("WorkTimeHours")
                        .HasColumnType("double precision");

                    b.HasKey("DriverServiceId");

                    b.HasIndex("DriverVehicleId")
                        .HasName("fkIdx_171");

                    b.ToTable("DCS_DriverService");
                });

            modelBuilder.Entity("Fuel.Domain.DcsDriverVehicle", b =>
                {
                    b.Property<int>("DriverVehicleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("DriverVehicleId");

                    b.HasIndex("DriverId")
                        .HasName("fkIdx_159");

                    b.HasIndex("VehicleId")
                        .HasName("fkIdx_156");

                    b.ToTable("DCS_DriverVehicle");
                });

            modelBuilder.Entity("Fuel.Domain.DcsFuelInfo", b =>
                {
                    b.Property<int>("FuelInfoId")
                        .HasColumnType("integer");

                    b.Property<double>("CurrentVolume")
                        .HasColumnType("double precision");

                    b.Property<int>("DriverVehicleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PacketTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("RefuelVolume")
                        .HasColumnType("double precision");

                    b.HasKey("FuelInfoId");

                    b.HasIndex("DriverVehicleId")
                        .HasName("fkIdx_192");

                    b.ToTable("DCS_FuelInfo");
                });

            modelBuilder.Entity("Fuel.Domain.DcsLocation", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<int>("VehicleRealTimeInfoId")
                        .HasColumnType("integer");

                    b.HasKey("LocationId");

                    b.HasIndex("VehicleRealTimeInfoId");

                    b.ToTable("DCS_Location");
                });

            modelBuilder.Entity("Fuel.Domain.DcsLogs", b =>
                {
                    b.Property<string>("Exception")
                        .HasColumnName("exception")
                        .HasColumnType("text");

                    b.Property<int?>("Level")
                        .HasColumnName("level")
                        .HasColumnType("integer");

                    b.Property<string>("LogEvent")
                        .HasColumnName("log_event")
                        .HasColumnType("jsonb");

                    b.Property<string>("Message")
                        .HasColumnName("message")
                        .HasColumnType("text");

                    b.Property<string>("MessageTemplate")
                        .HasColumnName("message_template")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnName("timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.ToTable("dcs_logs");
                });

            modelBuilder.Entity("Fuel.Domain.DcsVehicleMaster", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double?>("TankCapacity")
                        .HasColumnType("double precision");

                    b.Property<string>("VehicleLicenseNo")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("VehicleName")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("VehicleId");

                    b.ToTable("DCS_VehicleMaster");
                });

            modelBuilder.Entity("Fuel.Domain.DcsVehicleRealTimeInfo", b =>
                {
                    b.Property<int>("VehicleRealTimeInfoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DriverVehicleId")
                        .HasColumnType("integer");

                    b.Property<int?>("HarshBreaking")
                        .HasColumnType("integer");

                    b.Property<int?>("HarshTurning")
                        .HasColumnType("integer");

                    b.Property<BitArray>("IgnitionStatus")
                        .HasColumnType("bit(1)");

                    b.Property<double?>("LoadVolume")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("PacketTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double?>("VehicleSpeed")
                        .HasColumnType("double precision");

                    b.HasKey("VehicleRealTimeInfoId");

                    b.HasIndex("DriverVehicleId")
                        .HasName("fkIdx_184");

                    b.ToTable("DCS_VehicleRealTimeInfo");
                });

            modelBuilder.Entity("Fuel.Domain.DcsDriverService", b =>
                {
                    b.HasOne("Fuel.Domain.DcsDriverVehicle", "DriverVehicle")
                        .WithMany("DcsDriverService")
                        .HasForeignKey("DriverVehicleId")
                        .HasConstraintName("FK_171")
                        .IsRequired();
                });

            modelBuilder.Entity("Fuel.Domain.DcsDriverVehicle", b =>
                {
                    b.HasOne("Fuel.Domain.DcsDriverMaster", "Driver")
                        .WithMany("DcsDriverVehicle")
                        .HasForeignKey("DriverId")
                        .HasConstraintName("FK_159")
                        .IsRequired();

                    b.HasOne("Fuel.Domain.DcsVehicleMaster", "Vehicle")
                        .WithMany("DcsDriverVehicle")
                        .HasForeignKey("VehicleId")
                        .HasConstraintName("FK_156")
                        .IsRequired();
                });

            modelBuilder.Entity("Fuel.Domain.DcsFuelInfo", b =>
                {
                    b.HasOne("Fuel.Domain.DcsDriverVehicle", "DriverVehicle")
                        .WithMany("DcsFuelInfo")
                        .HasForeignKey("DriverVehicleId")
                        .HasConstraintName("FK_192")
                        .IsRequired();
                });

            modelBuilder.Entity("Fuel.Domain.DcsLocation", b =>
                {
                    b.HasOne("Fuel.Domain.DcsVehicleRealTimeInfo", "VehicleRealTimeInfo")
                        .WithMany("DcsLocation")
                        .HasForeignKey("VehicleRealTimeInfoId")
                        .HasConstraintName("FK_191")
                        .IsRequired();
                });

            modelBuilder.Entity("Fuel.Domain.DcsVehicleRealTimeInfo", b =>
                {
                    b.HasOne("Fuel.Domain.DcsDriverVehicle", "DriverVehicle")
                        .WithMany("DcsVehicleRealTimeInfo")
                        .HasForeignKey("DriverVehicleId")
                        .HasConstraintName("FK_184")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
