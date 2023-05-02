using Microsoft.EntityFrameworkCore.Migrations;

namespace DaySpring.Migrations
{
    public partial class count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$TLNHJ6qGbn3P2Ey.uIFGPOENOlOlAcmopOWZOu50oKLlVabkkoh7a");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Vtz5cFSB1tudw1zgRgYLEuT9NbW2GQU2YE4YP/t4KeoFuUvhpzZXu");
        }
    }
}
