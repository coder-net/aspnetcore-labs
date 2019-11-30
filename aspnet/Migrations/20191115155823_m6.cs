using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment<Topic>");

            migrationBuilder.RenameColumn(
                name: "TopicName",
                table: "TopicModels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "PostComments",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TopicModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TopicMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicMessages_TopicModels_TopicId",
                        column: x => x.TopicId,
                        principalTable: "TopicModels",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicMessages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicMessages_TopicId",
                table: "TopicMessages",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicMessages_UserId",
                table: "TopicMessages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicMessages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TopicModels");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TopicModels",
                newName: "TopicName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PostComments",
                newName: "CommentId");

            migrationBuilder.CreateTable(
                name: "Comment<Topic>",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    TopicId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment<Topic>", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment<Topic>_TopicModels_TopicId",
                        column: x => x.TopicId,
                        principalTable: "TopicModels",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment<Topic>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Topic>_TopicId",
                table: "Comment<Topic>",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment<Topic>_UserId",
                table: "Comment<Topic>",
                column: "UserId");
        }
    }
}
