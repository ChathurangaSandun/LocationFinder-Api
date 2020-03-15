using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationFinder.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nearme.deviceinformation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OsModel = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Uuid = table.Column<string>(nullable: true),
                    Osversion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearme.deviceinformation", x => x.Id);
                });

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
                name: "nearme.organizationdevice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<long>(nullable: false),
                    DeviceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearme.organizationdevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nearme.organizationdevice_nearme.deviceinformation_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "nearme.deviceinformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nearme.organizationdevice_nearme.organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "nearme.organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ImageUri = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "nearme.pointlocation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<float>(nullable: false),
                    Longtitude = table.Column<float>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    PersonId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearme.pointlocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nearme.pointlocation_nearme.person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "nearme.person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nearme.organizationdevice_DeviceId",
                table: "nearme.organizationdevice",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_nearme.organizationdevice_OrganizationId",
                table: "nearme.organizationdevice",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_nearme.person_OrganizationId",
                table: "nearme.person",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_nearme.pointlocation_PersonId",
                table: "nearme.pointlocation",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nearme.organizationdevice");

            migrationBuilder.DropTable(
                name: "nearme.pointlocation");

            migrationBuilder.DropTable(
                name: "nearme.deviceinformation");

            migrationBuilder.DropTable(
                name: "nearme.person");

            migrationBuilder.DropTable(
                name: "nearme.organization");
        }
    }
}
