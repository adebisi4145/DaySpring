using Microsoft.EntityFrameworkCore.Migrations;

namespace DaySpring.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$O4aVrz7XBWCygQS1mTDzS.zboUIXtHLbeLSq49TuBy8Ilc5ak7NES");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$nMfZSUKqgx08QA0kzGkfJuYO0KSw3.LZsdgVXopWYEeE./1YfuxIW");
        }
    }
}
