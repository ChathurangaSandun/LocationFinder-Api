using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationFinder.Api.Migrations
{
    public partial class adddeviceinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceInformations",
                table: "DeviceInformations");

            migrationBuilder.RenameTable(
                name: "DeviceInformations",
                newName: "nearme.deviceinformation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_nearme.deviceinformation",
                table: "nearme.deviceinformation",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_nearme.organizationdevice_DeviceId",
                table: "nearme.organizationdevice",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_nearme.organizationdevice_OrganizationId",
                table: "nearme.organizationdevice",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nearme.organizationdevice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_nearme.deviceinformation",
                table: "nearme.deviceinformation");

            migrationBuilder.RenameTable(
                name: "nearme.deviceinformation",
                newName: "DeviceInformations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceInformations",
                table: "DeviceInformations",
                column: "Id");
        }
    }
}
