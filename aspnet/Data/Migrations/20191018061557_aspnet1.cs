using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Data.Migrations
{
    public partial class aspnet1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel<PostModel>_PostModels_TId",
                table: "CommentModel<PostModel>");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel<TopicModel>_TopicModels_TId",
                table: "CommentModel<TopicModel>");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel<TopicModel>_TId",
                table: "CommentModel<TopicModel>");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel<PostModel>_TId",
                table: "CommentModel<PostModel>");

            migrationBuilder.DropColumn(
                name: "TId",
                table: "CommentModel<TopicModel>");

            migrationBuilder.DropColumn(
                name: "TId",
                table: "CommentModel<PostModel>");

            migrationBuilder.AddColumn<int>(
                name: "ParentTopicId",
                table: "CommentModel<TopicModel>",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentPostId",
                table: "CommentModel<PostModel>",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel<TopicModel>_ParentTopicId",
                table: "CommentModel<TopicModel>",
                column: "ParentTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel<PostModel>_ParentPostId",
                table: "CommentModel<PostModel>",
                column: "ParentPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel<PostModel>_PostModels_ParentPostId",
                table: "CommentModel<PostModel>",
                column: "ParentPostId",
                principalTable: "PostModels",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel<TopicModel>_TopicModels_ParentTopicId",
                table: "CommentModel<TopicModel>",
                column: "ParentTopicId",
                principalTable: "TopicModels",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel<PostModel>_PostModels_ParentPostId",
                table: "CommentModel<PostModel>");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel<TopicModel>_TopicModels_ParentTopicId",
                table: "CommentModel<TopicModel>");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel<TopicModel>_ParentTopicId",
                table: "CommentModel<TopicModel>");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel<PostModel>_ParentPostId",
                table: "CommentModel<PostModel>");

            migrationBuilder.DropColumn(
                name: "ParentTopicId",
                table: "CommentModel<TopicModel>");

            migrationBuilder.DropColumn(
                name: "ParentPostId",
                table: "CommentModel<PostModel>");

            migrationBuilder.AddColumn<int>(
                name: "TId",
                table: "CommentModel<TopicModel>",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TId",
                table: "CommentModel<PostModel>",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel<TopicModel>_TId",
                table: "CommentModel<TopicModel>",
                column: "TId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel<PostModel>_TId",
                table: "CommentModel<PostModel>",
                column: "TId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel<PostModel>_PostModels_TId",
                table: "CommentModel<PostModel>",
                column: "TId",
                principalTable: "PostModels",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel<TopicModel>_TopicModels_TId",
                table: "CommentModel<TopicModel>",
                column: "TId",
                principalTable: "TopicModels",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
