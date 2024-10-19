using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Cambiosenalgunasdelasrelacionesentreentidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentSchool",
                table: "Passengers");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Passengers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_SchoolId",
                table: "Passengers",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Schools_SchoolId",
                table: "Passengers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Schools_SchoolId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_SchoolId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Passengers");

            migrationBuilder.AddColumn<string>(
                name: "StudentSchool",
                table: "Passengers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
