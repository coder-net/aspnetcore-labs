using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Data.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Post>_AspNetUsers_UserId",
                table: "Comment<Post>");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Post>_AspNetUsers_UserId",
                table: "Comment<Post>",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Post>_AspNetUsers_UserId",
                table: "Comment<Post>");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Post>_AspNetUsers_UserId",
                table: "Comment<Post>",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
