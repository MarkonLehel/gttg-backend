using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gttgBackend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LodgingList",
                columns: table => new
                {
                    LodgingDataID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanetID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LodgingList", x => x.LodgingDataID);
                });

            migrationBuilder.CreateTable(
                name: "PLanetList",
                columns: table => new
                {
                    PlanetDataID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanetDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLanetList", x => x.PlanetDataID);
                });

            migrationBuilder.CreateTable(
                name: "TravelTypeList",
                columns: table => new
                {
                    TravelTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelTypeList", x => x.TravelTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TripList",
                columns: table => new
                {
                    TripDataID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistanceBetweenDestinations = table.Column<float>(type: "real", nullable: false),
                    StartingPlanetPlanetDataID = table.Column<int>(type: "int", nullable: true),
                    DestinationPlanetPlanetDataID = table.Column<int>(type: "int", nullable: true),
                    TotalEventPrice = table.Column<float>(type: "real", nullable: false),
                    CurrentlySelectedLodgingLodgingDataID = table.Column<int>(type: "int", nullable: true),
                    LodgingBookedFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LodgingBookedUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LodgingPrice = table.Column<float>(type: "real", nullable: false),
                    TravelTime = table.Column<float>(type: "real", nullable: false),
                    TravelTypeID = table.Column<int>(type: "int", nullable: true),
                    TotalTravelPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripList", x => x.TripDataID);
                    table.ForeignKey(
                        name: "FK_TripList_LodgingList_CurrentlySelectedLodgingLodgingDataID",
                        column: x => x.CurrentlySelectedLodgingLodgingDataID,
                        principalTable: "LodgingList",
                        principalColumn: "LodgingDataID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripList_PLanetList_DestinationPlanetPlanetDataID",
                        column: x => x.DestinationPlanetPlanetDataID,
                        principalTable: "PLanetList",
                        principalColumn: "PlanetDataID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripList_PLanetList_StartingPlanetPlanetDataID",
                        column: x => x.StartingPlanetPlanetDataID,
                        principalTable: "PLanetList",
                        principalColumn: "PlanetDataID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripList_TravelTypeList_TravelTypeID",
                        column: x => x.TravelTypeID,
                        principalTable: "TravelTypeList",
                        principalColumn: "TravelTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventList",
                columns: table => new
                {
                    EventDataID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripDataID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventList", x => x.EventDataID);
                    table.ForeignKey(
                        name: "FK_EventList_TripList_TripDataID",
                        column: x => x.TripDataID,
                        principalTable: "TripList",
                        principalColumn: "TripDataID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PLanetList",
                columns: new[] { "PlanetDataID", "ImageName", "PlanetDescription", "PlanetName", "Population", "Race", "X", "Y" },
                values: new object[] { 1, "Anonym", "First planet in DB", "Planet1", 2, "F1", 10, 50 });

            migrationBuilder.CreateIndex(
                name: "IX_EventList_TripDataID",
                table: "EventList",
                column: "TripDataID");

            migrationBuilder.CreateIndex(
                name: "IX_TripList_CurrentlySelectedLodgingLodgingDataID",
                table: "TripList",
                column: "CurrentlySelectedLodgingLodgingDataID");

            migrationBuilder.CreateIndex(
                name: "IX_TripList_DestinationPlanetPlanetDataID",
                table: "TripList",
                column: "DestinationPlanetPlanetDataID");

            migrationBuilder.CreateIndex(
                name: "IX_TripList_StartingPlanetPlanetDataID",
                table: "TripList",
                column: "StartingPlanetPlanetDataID");

            migrationBuilder.CreateIndex(
                name: "IX_TripList_TravelTypeID",
                table: "TripList",
                column: "TravelTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventList");

            migrationBuilder.DropTable(
                name: "TripList");

            migrationBuilder.DropTable(
                name: "LodgingList");

            migrationBuilder.DropTable(
                name: "PLanetList");

            migrationBuilder.DropTable(
                name: "TravelTypeList");
        }
    }
}
