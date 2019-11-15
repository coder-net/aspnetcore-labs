using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Data.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Post>_PostModels_ParentPostId",
                table: "Comment<Post>");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Topic>_TopicModels_ParentTopicId",
                table: "Comment<Topic>");

            migrationBuilder.RenameColumn(
                name: "ParentTopicId",
                table: "Comment<Topic>",
                newName: "TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment<Topic>_ParentTopicId",
                table: "Comment<Topic>",
                newName: "IX_Comment<Topic>_TopicId");

            migrationBuilder.RenameColumn(
                name: "ParentPostId",
                table: "Comment<Post>",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment<Post>_ParentPostId",
                table: "Comment<Post>",
                newName: "IX_Comment<Post>_PostId");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Comment<Topic>",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Comment<Post>",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Post>_PostModels_PostId",
                table: "Comment<Post>",
                column: "PostId",
                principalTable: "PostModels",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Topic>_TopicModels_TopicId",
                table: "Comment<Topic>",
                column: "TopicId",
                principalTable: "TopicModels",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Post>_PostModels_PostId",
                table: "Comment<Post>");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Topic>_TopicModels_TopicId",
                table: "Comment<Topic>");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comment<Topic>");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comment<Post>");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Comment<Topic>",
                newName: "ParentTopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment<Topic>_TopicId",
                table: "Comment<Topic>",
                newName: "IX_Comment<Topic>_ParentTopicId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comment<Post>",
                newName: "ParentPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment<Post>_PostId",
                table: "Comment<Post>",
                newName: "IX_Comment<Post>_ParentPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Post>_PostModels_ParentPostId",
                table: "Comment<Post>",
                column: "ParentPostId",
                principalTable: "PostModels",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Topic>_TopicModels_ParentTopicId",
                table: "Comment<Topic>",
                column: "ParentTopicId",
                principalTable: "TopicModels",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
