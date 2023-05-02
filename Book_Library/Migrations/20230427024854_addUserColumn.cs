using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Library.Migrations
{
    public partial class addUserColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookUserId",
                table: "Book",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookUserId",
                table: "Book");
        }
    }
}
