using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Data.Migrations
{
    public partial class aspnet3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostModels_User_UserId",
                table: "PostModels");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PostModels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PostModels_User_UserId",
                table: "PostModels",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostModels_User_UserId",
                table: "PostModels");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PostModels",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModels_User_UserId",
                table: "PostModels",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
