using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alpha.Reservation.API.Migrations
{
    public partial class UpdateUser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5291d41f-c47c-400f-a465-f353358c9b39"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fba19436-c62c-4e45-8280-d7e76b28c0c0"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000000"), "Manager", "ManagerName", "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=", 1, "ManagerSurname" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("20000000-0000-0000-0000-000000000000"), "Employee", "EmployeeName", "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=", 2, "EmployeeSurname" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("5291d41f-c47c-400f-a465-f353358c9b39"), "Manager", "ManagerName", "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=", 1, "ManagerSurname" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { new Guid("fba19436-c62c-4e45-8280-d7e76b28c0c0"), "Employee", "EmployeeName", "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=", 2, "EmployeeSurname" });
        }
    }
}
