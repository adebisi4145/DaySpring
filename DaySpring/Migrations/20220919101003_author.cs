using Microsoft.EntityFrameworkCore.Migrations;

namespace DaySpring.Migrations
{
    public partial class author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorsImage",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$nMfZSUKqgx08QA0kzGkfJuYO0KSw3.LZsdgVXopWYEeE./1YfuxIW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorsImage",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$8F7/FTuBTm6IJKZfv8IQR.xlfYtG3v1V4/8PnmxAxaOSYrMBvHp52");
        }
    }
}
