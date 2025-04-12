using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    /// <inheritdoc />
    public partial class NewTS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverBankAccountId",
                table: "Transactions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceiverBankAccountId",
                table: "Transactions",
                column: "ReceiverBankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_ReceiverBankAccountId",
                table: "Transactions",
                column: "ReceiverBankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_ReceiverBankAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ReceiverBankAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReceiverBankAccountId",
                table: "Transactions");
        }
    }
}
