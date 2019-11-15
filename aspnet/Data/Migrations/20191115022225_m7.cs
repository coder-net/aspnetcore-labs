using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Data.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment<Post>_PostModels_PostId",
                table: "Comment<Post>");

            migrationBuilder.DropIndex(
                name: "IX_Comment<Post>_PostId",
                table: "Comment<Post>");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comment<Post>");

            migrationBuilder.CreateTable(
                name: "PostComment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_PostComment_PostModels_PostId",
                        column: x => x.PostId,
                        principalTable: "PostModels",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_PostId",
                table: "PostComment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_UserId",
                table: "PostComment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostComment");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comment<Post>",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Post>_PostId",
                table: "Comment<Post>",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment<Post>_PostModels_PostId",
                table: "Comment<Post>",
                column: "PostId",
                principalTable: "PostModels",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
