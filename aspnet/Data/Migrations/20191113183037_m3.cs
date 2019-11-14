using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Data.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Post>_PostModels_ParentPostId",
                table: "Comment<Post>");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Post>_AspNetUsers_UserId",
                table: "Comment<Post>");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Topic>_TopicModels_ParentTopicId",
                table: "Comment<Topic>");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Topic>_AspNetUsers_UserId",
                table: "Comment<Topic>");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModels_AspNetUsers_UserId",
                table: "PostModels");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Post>_PostModels_ParentPostId",
                table: "Comment<Post>",
                column: "ParentPostId",
                principalTable: "PostModels",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Post>_AspNetUsers_UserId",
                table: "Comment<Post>",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Topic>_TopicModels_ParentTopicId",
                table: "Comment<Topic>",
                column: "ParentTopicId",
                principalTable: "TopicModels",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Topic>_AspNetUsers_UserId",
                table: "Comment<Topic>",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModels_AspNetUsers_UserId",
                table: "PostModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Post>_PostModels_ParentPostId",
                table: "Comment<Post>");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Post>_AspNetUsers_UserId",
                table: "Comment<Post>");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Topic>_TopicModels_ParentTopicId",
                table: "Comment<Topic>");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Topic>_AspNetUsers_UserId",
                table: "Comment<Topic>");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModels_AspNetUsers_UserId",
                table: "PostModels");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Post>_PostModels_ParentPostId",
                table: "Comment<Post>",
                column: "ParentPostId",
                principalTable: "PostModels",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Post>_AspNetUsers_UserId",
                table: "Comment<Post>",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Topic>_TopicModels_ParentTopicId",
                table: "Comment<Topic>",
                column: "ParentTopicId",
                principalTable: "TopicModels",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Topic>_AspNetUsers_UserId",
                table: "Comment<Topic>",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModels_AspNetUsers_UserId",
                table: "PostModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
