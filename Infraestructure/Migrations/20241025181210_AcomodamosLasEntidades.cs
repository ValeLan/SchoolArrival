using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AcomodamosLasEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Schools_SchoolId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SchoolId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentAdress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "StudentDNI",
                table: "Users",
                newName: "DNI");

            migrationBuilder.RenameColumn(
                name: "StudentAdress",
                table: "Travels",
                newName: "Hour");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Travels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SchoolAdress",
                table: "Schools",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travels_SchoolId",
                table: "Travels",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Schools_SchoolId",
                table: "Travels",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Schools_SchoolId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_SchoolId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "SchoolAdress",
                table: "Schools");

            migrationBuilder.RenameColumn(
                name: "DNI",
                table: "Users",
                newName: "StudentDNI");

            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Travels",
                newName: "StudentAdress");

            migrationBuilder.AddColumn<string>(
                name: "Hour",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentAdress",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Travels",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolId",
                table: "Users",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Schools_SchoolId",
                table: "Users",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");
        }
    }
}
