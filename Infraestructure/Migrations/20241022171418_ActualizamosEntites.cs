using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizamosEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Admins_AdminId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Admins_AdminId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Drivers_DriverId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Schools_AdminId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Districts_AdminId",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Districts");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Travels",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
                name: "FK_Travels_Drivers_DriverId",
                table: "Travels");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Travels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Schools",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Districts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_AdminId",
                table: "Schools",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_AdminId",
                table: "Districts",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Admins_AdminId",
                table: "Districts",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Admins_AdminId",
                table: "Schools",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Drivers_DriverId",
                table: "Travels",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
