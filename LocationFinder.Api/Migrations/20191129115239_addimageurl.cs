using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationFinder.Api.Migrations
{
    public partial class addimageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "nearme.person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "nearme.person");
        }
    }
}
