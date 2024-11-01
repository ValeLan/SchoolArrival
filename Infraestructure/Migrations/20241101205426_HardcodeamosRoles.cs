using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class HardcodeamosRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name", "SchoolAdress" },
                values: new object[,]
                {
                    { 1, "Manuel Belgrano", "Callao 1120" },
                    { 2, "Santa María", "Jujuy 1212" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DNI", "District", "Email", "FullName", "IsActive", "Password", "PhoneNumber", "Role", "TravelId" },
                values: new object[,]
                {
                    { 1, "30304066", null, "admin@admin.com", "Admin", true, "123", "432495959", 0, null },
                    { 2, "54209454", null, "driver@driver.com", "Driver", true, "123", "34445004", 2, null },
                    { 3, "540967454", null, "driver@driver2.com", "Driver Dos", true, "123", "34456704", 2, null },
                    { 4, "762376879", 0, "passenger@passenger.com", "Passenger", true, "123", "32843295", 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
