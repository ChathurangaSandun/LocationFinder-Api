using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationFinder.Api.Migrations
{
    public partial class secondone3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nearme.organization",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearme.organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nearme.pointlocation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<float>(nullable: false),
                    Longtitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearme.pointlocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nearme.person",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PointLocatioId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearme.person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nearme.person_nearme.organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "nearme.organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nearme.person_nearme.pointlocation_PointLocatioId",
                        column: x => x.PointLocatioId,
                        principalTable: "nearme.pointlocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nearme.person_OrganizationId",
                table: "nearme.person",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_nearme.person_PointLocatioId",
                table: "nearme.person",
                column: "PointLocatioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nearme.person");

            migrationBuilder.DropTable(
                name: "nearme.organization");

            migrationBuilder.DropTable(
                name: "nearme.pointlocation");
        }
    }
}
