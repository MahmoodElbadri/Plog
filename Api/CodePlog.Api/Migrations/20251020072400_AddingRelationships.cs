using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePlog.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddingRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryPost",
                columns: table => new
                {
                    CategoriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPost", x => new { x.CategoriesID, x.PostsID });
                    table.ForeignKey(
                        name: "FK_CategoryPost_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPost_Posts_PostsID",
                        column: x => x.PostsID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPost_PostsID",
                table: "CategoryPost",
                column: "PostsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPost");
        }
    }
}
