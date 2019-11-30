using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Migrations
{
    public partial class qweeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostModels_PostId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModels_AspNetUsers_UserId",
                table: "PostModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicMessages_AspNetUsers_UserId",
                table: "TopicMessages");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "TopicMessages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "PostComments",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostModels_PostId",
                table: "PostComments",
                column: "PostId",
                principalTable: "PostModels",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModels_AspNetUsers_UserId",
                table: "PostModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicMessages_AspNetUsers_UserId",
                table: "TopicMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostModels_PostId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModels_AspNetUsers_UserId",
                table: "PostModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicMessages_AspNetUsers_UserId",
                table: "TopicMessages");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "TopicMessages");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "PostComments");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostModels_PostId",
                table: "PostComments",
                column: "PostId",
                principalTable: "PostModels",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModels_AspNetUsers_UserId",
                table: "PostModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicMessages_AspNetUsers_UserId",
                table: "TopicMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
