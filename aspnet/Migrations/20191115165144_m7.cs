using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "TopicModels",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TopicModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TopicModels_UserId",
                table: "TopicModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicModels_AspNetUsers_UserId",
                table: "TopicModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicModels_AspNetUsers_UserId",
                table: "TopicModels");

            migrationBuilder.DropIndex(
                name: "IX_TopicModels_UserId",
                table: "TopicModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TopicModels");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TopicModels",
                newName: "TopicId");
        }
    }
}
