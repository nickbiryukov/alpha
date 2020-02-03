using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alpha.Reservation.API.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c1b459a7-ad4a-4f1c-8063-464fce436856"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dcbac25a-1160-4f34-beb7-b80300af27af"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("9467b271-bb8e-4f3c-9691-abdffec61ef9"), "Manager", "ManagerName", "test", 1, "ManagerSurname" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("9c3893ca-864f-4c7e-9b2d-d83007321250"), "Employee", "EmployeeName", "test", 2, "EmployeeSurname" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9467b271-bb8e-4f3c-9691-abdffec61ef9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c3893ca-864f-4c7e-9b2d-d83007321250"));

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "RoleId", "Surname" },
                values: new object[] { new Guid("dcbac25a-1160-4f34-beb7-b80300af27af"), "Manager", "ManagerName", "test", 1, "ManagerSurname" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "RoleId", "Surname" },
                values: new object[] { new Guid("c1b459a7-ad4a-4f1c-8063-464fce436856"), "Employee", "EmployeeName", "test", 2, "EmployeeSurname" });
        }
    }
}
