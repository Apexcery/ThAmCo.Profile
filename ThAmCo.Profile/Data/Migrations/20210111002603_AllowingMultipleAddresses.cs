using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Profile.Data.Migrations
{
    public partial class AllowingMultipleAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ProfileAddress_AddressId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_AddressId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Profiles");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileEntityId",
                table: "ProfileAddress",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AddressId",
                table: "Profiles",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AddressId",
                table: "Profiles",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ProfileAddress_AddressId",
                table: "Profiles",
                column: "AddressId",
                principalTable: "ProfileAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
