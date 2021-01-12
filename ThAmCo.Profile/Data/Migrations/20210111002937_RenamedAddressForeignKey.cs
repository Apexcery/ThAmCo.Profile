using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Profile.Data.Migrations
{
    public partial class RenamedAddressForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAddress_Profiles_ProfileEntityId",
                table: "ProfileAddress");

            migrationBuilder.DropIndex(
                name: "IX_ProfileAddress_ProfileEntityId",
                table: "ProfileAddress");

            migrationBuilder.DropColumn(
                name: "ProfileEntityId",
                table: "ProfileAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "ProfileAddress",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileAddress_ProfileId",
                table: "ProfileAddress",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAddress_Profiles_ProfileId",
                table: "ProfileAddress",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAddress_Profiles_ProfileId",
                table: "ProfileAddress");

            migrationBuilder.DropIndex(
                name: "IX_ProfileAddress_ProfileId",
                table: "ProfileAddress");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "ProfileAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileEntityId",
                table: "ProfileAddress",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileAddress_ProfileEntityId",
                table: "ProfileAddress",
                column: "ProfileEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAddress_Profiles_ProfileEntityId",
                table: "ProfileAddress",
                column: "ProfileEntityId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
