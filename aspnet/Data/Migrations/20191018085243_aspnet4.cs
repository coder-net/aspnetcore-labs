using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Data.Migrations
{
    public partial class aspnet4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentModel<PostModel>");

            migrationBuilder.DropTable(
                name: "CommentModel<TopicModel>");

            migrationBuilder.CreateTable(
                name: "Comment<Post>",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ParentPostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment<Post>", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment<Post>_PostModels_ParentPostId",
                        column: x => x.ParentPostId,
                        principalTable: "PostModels",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment<Post>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment<Topic>",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ParentTopicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment<Topic>", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment<Topic>_TopicModels_ParentTopicId",
                        column: x => x.ParentTopicId,
                        principalTable: "TopicModels",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment<Topic>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Post>_ParentPostId",
                table: "Comment<Post>",
                column: "ParentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Post>_UserId",
                table: "Comment<Post>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Topic>_ParentTopicId",
                table: "Comment<Topic>",
                column: "ParentTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Topic>_UserId",
                table: "Comment<Topic>",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment<Post>");

            migrationBuilder.DropTable(
                name: "Comment<Topic>");

            migrationBuilder.CreateTable(
                name: "CommentModel<PostModel>",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ParentPostId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentModel<PostModel>", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentModel<PostModel>_PostModels_ParentPostId",
                        column: x => x.ParentPostId,
                        principalTable: "PostModels",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentModel<PostModel>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentModel<TopicModel>",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ParentTopicId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentModel<TopicModel>", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentModel<TopicModel>_TopicModels_ParentTopicId",
                        column: x => x.ParentTopicId,
                        principalTable: "TopicModels",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentModel<TopicModel>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel<PostModel>_ParentPostId",
                table: "CommentModel<PostModel>",
                column: "ParentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel<PostModel>_UserId",
                table: "CommentModel<PostModel>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel<TopicModel>_ParentTopicId",
                table: "CommentModel<TopicModel>",
                column: "ParentTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel<TopicModel>_UserId",
                table: "CommentModel<TopicModel>",
                column: "UserId");
        }
    }
}
