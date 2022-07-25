using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User_API.Migrations
{
    public partial class Aya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_userssId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "userssId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_userssId",
                table: "Posts",
                column: "userssId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_userssId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "userssId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_userssId",
                table: "Posts",
                column: "userssId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
