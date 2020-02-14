using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alpha.Reservation.API.Migrations
{
    public partial class RoomsInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Board", "Description", "Name", "Projector", "Seat" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000000"), true, "Small room", "Room 402", true, 10 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Board", "Description", "Name", "Projector", "Seat" },
                values: new object[] { new Guid("20000000-0000-0000-0000-000000000000"), false, "Medium room", "Room 112", false, 30 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Board", "Description", "Name", "Projector", "Seat" },
                values: new object[] { new Guid("30000000-0000-0000-0000-000000000000"), false, "Large room", "Room 54", true, 50 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"));
        }
    }
}
