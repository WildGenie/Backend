using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GelecekBilimde.Backend.Migrations
{
    public partial class AddArticleBookmarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserArticleBookmarks",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ArticleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserArticleBookmarks", x => new { x.UserId, x.ArticleId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserArticleBookmarks");
        }
    }
}
