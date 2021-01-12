using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Profile.Data.Migrations
{
    public partial class RenamedAddressesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAddress_Profiles_ProfileId",
                table: "ProfileAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileAddress",
                table: "ProfileAddress");

            migrationBuilder.RenameTable(
                name: "ProfileAddress",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileAddress_ProfileId",
                table: "Addresses",
                newName: "IX_Addresses_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Profiles_ProfileId",
                table: "Addresses",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Profiles_ProfileId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "ProfileAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_ProfileId",
                table: "ProfileAddress",
                newName: "IX_ProfileAddress_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileAddress",
                table: "ProfileAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAddress_Profiles_ProfileId",
                table: "ProfileAddress",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
