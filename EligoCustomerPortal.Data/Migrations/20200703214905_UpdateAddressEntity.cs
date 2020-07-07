using Microsoft.EntityFrameworkCore.Migrations;

namespace EligoCustomerPortal.Data.Migrations
{
    public partial class UpdateAddressEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Addresses_AddressID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AddressID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AddressID",
                table: "Accounts",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Addresses_AddressID",
                table: "Accounts",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
