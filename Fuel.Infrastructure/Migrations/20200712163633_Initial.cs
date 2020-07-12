using System;
using System.Collections;
using Fuel.Infrastructure.Functions;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fuel.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DCS_DriverMaster",
                columns: table => new
                {
                    DriverId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'', '1', '', '100000', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    DriverName = table.Column<string>(maxLength: 50, nullable: false),
                    DriverMobile = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCS_DriverMaster", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "dcs_logs",
                columns: table => new
                {
                    message = table.Column<string>(nullable: true),
                    message_template = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: true),
                    timestamp = table.Column<DateTime>(nullable: true),
                    exception = table.Column<string>(nullable: true),
                    log_event = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DCS_VehicleMaster",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    VehicleLicenseNo = table.Column<string>(maxLength: 50, nullable: false),
                    VehicleName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    TankCapacity = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCS_VehicleMaster", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "DCS_DriverVehicle",
                columns: table => new
                {
                    DriverVehicleId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCS_DriverVehicle", x => x.DriverVehicleId);
                    table.ForeignKey(
                        name: "FK_159",
                        column: x => x.DriverId,
                        principalTable: "DCS_DriverMaster",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_156",
                        column: x => x.VehicleId,
                        principalTable: "DCS_VehicleMaster",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DCS_DriverService",
                columns: table => new
                {
                    DriverServiceId = table.Column<int>(nullable: false),
                    DriverVehicleId = table.Column<int>(nullable: false),
                    VehicleStartTime = table.Column<DateTime>(nullable: true),
                    VehicleEndTime = table.Column<DateTime>(nullable: true),
                    RestingStartTime = table.Column<DateTime>(nullable: true),
                    RestingEndTime = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    RestTimeHours = table.Column<double>(nullable: true),
                    DrivingTimeHours = table.Column<double>(nullable: true),
                    WorkTimeHours = table.Column<double>(nullable: true),
                    DistanceTravelled = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCS_DriverService", x => x.DriverServiceId);
                    table.ForeignKey(
                        name: "FK_171",
                        column: x => x.DriverVehicleId,
                        principalTable: "DCS_DriverVehicle",
                        principalColumn: "DriverVehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DCS_FuelInfo",
                columns: table => new
                {
                    FuelInfoId = table.Column<int>(nullable: false),
                    DriverVehicleId = table.Column<int>(nullable: false),
                    CurrentVolume = table.Column<double>(nullable: false),
                    RefuelVolume = table.Column<double>(nullable: false),
                    PacketTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCS_FuelInfo", x => x.FuelInfoId);
                    table.ForeignKey(
                        name: "FK_192",
                        column: x => x.DriverVehicleId,
                        principalTable: "DCS_DriverVehicle",
                        principalColumn: "DriverVehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DCS_VehicleRealTimeInfo",
                columns: table => new
                {
                    VehicleRealTimeInfoId = table.Column<int>(nullable: false),
                    DriverVehicleId = table.Column<int>(nullable: false),
                    PacketTime = table.Column<DateTime>(nullable: false),
                    VehicleSpeed = table.Column<double>(nullable: true),
                    HarshTurning = table.Column<int>(nullable: true),
                    HarshBreaking = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IgnitionStatus = table.Column<BitArray>(type: "bit(1)", nullable: true),
                    LoadVolume = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCS_VehicleRealTimeInfo", x => x.VehicleRealTimeInfoId);
                    table.ForeignKey(
                        name: "FK_184",
                        column: x => x.DriverVehicleId,
                        principalTable: "DCS_DriverVehicle",
                        principalColumn: "DriverVehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DCS_Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    VehicleRealTimeInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCS_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_191",
                        column: x => x.VehicleRealTimeInfoId,
                        principalTable: "DCS_VehicleRealTimeInfo",
                        principalColumn: "VehicleRealTimeInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fkIdx_171",
                table: "DCS_DriverService",
                column: "DriverVehicleId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_159",
                table: "DCS_DriverVehicle",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_156",
                table: "DCS_DriverVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_192",
                table: "DCS_FuelInfo",
                column: "DriverVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DCS_Location_VehicleRealTimeInfoId",
                table: "DCS_Location",
                column: "VehicleRealTimeInfoId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_184",
                table: "DCS_VehicleRealTimeInfo",
                column: "DriverVehicleId");

            migrationBuilder.Sql(DcsCoreFunctions.GetRandom);
            migrationBuilder.Sql(DcsCoreFunctions.GetRandomLicenseNo);
            migrationBuilder.Sql(DcsCoreFunctions.GetRandomPhoneNumber);
            migrationBuilder.Sql(DcsCoreFunctions.GetRandomWithNumeric);
            migrationBuilder.Sql(DcsDriverFunctions.PopulateDrivers);
            migrationBuilder.Sql(DcsVehicleFunctions.PopulateVehicles);
            migrationBuilder.Sql(DcsDriverVehicleFunctions.PopulateDriverVehicle);
            migrationBuilder.Sql(DcsDataPopulationFunctions.PopulateData);
            migrationBuilder.Sql(DcsFuelFunctions.GetTankCapacity);
            migrationBuilder.Sql(DcsLocationFunctions.GetMapRandomSoureAndDestination);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DCS_DriverService");

            migrationBuilder.DropTable(
                name: "DCS_FuelInfo");

            migrationBuilder.DropTable(
                name: "DCS_Location");

            migrationBuilder.DropTable(
                name: "dcs_logs");

            migrationBuilder.DropTable(
                name: "DCS_VehicleRealTimeInfo");

            migrationBuilder.DropTable(
                name: "DCS_DriverVehicle");

            migrationBuilder.DropTable(
                name: "DCS_DriverMaster");

            migrationBuilder.DropTable(
                name: "DCS_VehicleMaster");

            migrationBuilder.Sql(DcsCoreFunctions.RemoveGetRandom);
            migrationBuilder.Sql(DcsCoreFunctions.RemoveGetRandomPhoneNumber);
            migrationBuilder.Sql(DcsCoreFunctions.RemoveGetRandomWithNumeric);
            migrationBuilder.Sql(DcsCoreFunctions.ReomveGetRandomLicenseNo);
            migrationBuilder.Sql(DcsDriverFunctions.RemovePopulateDrivers);
            migrationBuilder.Sql(DcsVehicleFunctions.RemovePopulateVehicles);
            migrationBuilder.Sql(DcsDriverVehicleFunctions.RemovePopulateDriverVehicle);
            migrationBuilder.Sql(DcsDataPopulationFunctions.RemovePopulateData);
            migrationBuilder.Sql(DcsFuelFunctions.RemoveGetTankCapacity);
            migrationBuilder.Sql(DcsLocationFunctions.RemoveGetMapRandomSoureAndDestination);
        }
    }
}
