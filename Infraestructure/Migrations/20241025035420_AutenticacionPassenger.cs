using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AutenticacionPassenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Users_DriverId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Schools_SchoolId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Travels_TravelId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Passengers");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TravelId",
                table: "Passengers",
                newName: "IX_Passengers_TravelId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SchoolId",
                table: "Passengers",
                newName: "IX_Passengers_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Schools_SchoolId",
                table: "Passengers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Travels_TravelId",
                table: "Passengers",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Drivers_DriverId",
                table: "Travels",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Schools_SchoolId",
                table: "Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Travels_TravelId",
                table: "Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Drivers_DriverId",
                table: "Travels");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_TravelId",
                table: "Users",
                newName: "IX_Users_TravelId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_SchoolId",
                table: "Users",
                newName: "IX_Users_SchoolId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Users_DriverId",
                table: "Travels",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Schools_SchoolId",
                table: "Users",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Travels_TravelId",
                table: "Users",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id");
        }
    }
}
