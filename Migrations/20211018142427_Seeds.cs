using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gttgBackend.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventList",
                columns: new[] { "EventDataID", "Date", "EventName", "Location", "Price", "TripDataID" },
                values: new object[] { 1, new DateTime(2054, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Party hat trading convention", "Asteroid 9484643", 250f, null });

            migrationBuilder.InsertData(
                table: "LodgingList",
                columns: new[] { "LodgingDataID", "Location", "Name", "PlanetID", "Price", "Rating" },
                values: new object[] { 1, "Middle of nowhere", "Costa Cafe", 1, 49.99f, 4 });

            migrationBuilder.InsertData(
                table: "TravelTypeList",
                columns: new[] { "TravelTypeID", "Name", "Price", "Speed" },
                values: new object[] { 1, "SpaceBus", 25.5f, 7f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventList",
                keyColumn: "EventDataID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LodgingList",
                keyColumn: "LodgingDataID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TravelTypeList",
                keyColumn: "TravelTypeID",
                keyValue: 1);
        }
    }
}
