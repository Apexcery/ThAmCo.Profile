using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Profile.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    TownCity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Forename = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_ProfileAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ProfileAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AddressId",
                table: "Profiles",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ProfileAddress");
        }
    }
}
