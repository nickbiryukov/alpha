using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alpha.Reservation.API.Migrations
{
    public partial class UpdateUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9467b271-bb8e-4f3c-9691-abdffec61ef9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c3893ca-864f-4c7e-9b2d-d83007321250"));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("5291d41f-c47c-400f-a465-f353358c9b39"), "Manager", "ManagerName", "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=", 1, "ManagerSurname" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("fba19436-c62c-4e45-8280-d7e76b28c0c0"), "Employee", "EmployeeName", "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=", 2, "EmployeeSurname" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5291d41f-c47c-400f-a465-f353358c9b39"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fba19436-c62c-4e45-8280-d7e76b28c0c0"));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("9467b271-bb8e-4f3c-9691-abdffec61ef9"), "Manager", "ManagerName", "test", 1, "ManagerSurname" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("9c3893ca-864f-4c7e-9b2d-d83007321250"), "Employee", "EmployeeName", "test", 2, "EmployeeSurname" });
        }
    }
}
