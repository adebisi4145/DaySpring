using Microsoft.EntityFrameworkCore.Migrations;

namespace DaySpring.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sermons_Members_MemberId",
                table: "Sermons");

            migrationBuilder.DropForeignKey(
                name: "FK_Sermons_Preachers_PreacherId",
                table: "Sermons");

            migrationBuilder.AlterColumn<int>(
                name: "PreacherId",
                table: "Sermons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Sermons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Ga4ZVIdEVgJl2pOFrkjDd.zz4h24u6dtKgq49qD.jaQFjM2zlXHb6");

            migrationBuilder.AddForeignKey(
                name: "FK_Sermons_Members_MemberId",
                table: "Sermons",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sermons_Preachers_PreacherId",
                table: "Sermons",
                column: "PreacherId",
                principalTable: "Preachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sermons_Members_MemberId",
                table: "Sermons");

            migrationBuilder.DropForeignKey(
                name: "FK_Sermons_Preachers_PreacherId",
                table: "Sermons");

            migrationBuilder.AlterColumn<int>(
                name: "PreacherId",
                table: "Sermons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Sermons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$XAnMqCKFeQAOsPF4/ybQUutixvi46z9Mfstl/GezbCbZKgv9wnj8.");

            migrationBuilder.AddForeignKey(
                name: "FK_Sermons_Members_MemberId",
                table: "Sermons",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sermons_Preachers_PreacherId",
                table: "Sermons",
                column: "PreacherId",
                principalTable: "Preachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
