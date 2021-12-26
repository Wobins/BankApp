using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerAccountCustomerID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CustomerAccountCustomerID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CustomerAccountCustomerID",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerID",
                table: "Accounts",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerID",
                table: "Accounts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CustomerID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountCustomerID",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerAccountCustomerID",
                table: "Accounts",
                column: "CustomerAccountCustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerAccountCustomerID",
                table: "Accounts",
                column: "CustomerAccountCustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
