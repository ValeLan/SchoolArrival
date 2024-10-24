using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregamoslaentidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Passengers",
                newName: "FullName");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Passengers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_ClientId",
                table: "Passengers",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Client_ClientId",
                table: "Passengers",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Client_ClientId",
                table: "Passengers");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_ClientId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Passengers",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Passengers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
