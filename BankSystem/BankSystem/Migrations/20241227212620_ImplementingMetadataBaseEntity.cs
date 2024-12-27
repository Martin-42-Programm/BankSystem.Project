using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    /// <inheritdoc />
    public partial class ImplementingMetadataBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Transactions",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Transactions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Transactions",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Transactions",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Transactions",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Transactions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Offices",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Offices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Offices",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Offices",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Offices",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Offices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Currencies",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Currencies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Currencies",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Currencies",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Currencies",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Currencies",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Currencies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Cards",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Cards",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Cards",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Cards",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Cards",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Cards",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Accounts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Accounts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Accounts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Accounts",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Accounts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Accounts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreatedById",
                table: "Transactions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DeletedById",
                table: "Transactions",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ModifiedById",
                table: "Transactions",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CreatedById",
                table: "Offices",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_DeletedById",
                table: "Offices",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_ModifiedById",
                table: "Offices",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CreatedById",
                table: "Currencies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_DeletedById",
                table: "Currencies",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_ModifiedById",
                table: "Currencies",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CreatedById",
                table: "Cards",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeletedById",
                table: "Cards",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ModifiedById",
                table: "Cards",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreatedById",
                table: "Accounts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_DeletedById",
                table: "Accounts",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ModifiedById",
                table: "Accounts",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_CreatedById",
                table: "Accounts",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_DeletedById",
                table: "Accounts",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_ModifiedById",
                table: "Accounts",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_CreatedById",
                table: "Cards",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_DeletedById",
                table: "Cards",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_ModifiedById",
                table: "Cards",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_AspNetUsers_CreatedById",
                table: "Currencies",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_AspNetUsers_DeletedById",
                table: "Currencies",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_AspNetUsers_ModifiedById",
                table: "Currencies",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_AspNetUsers_CreatedById",
                table: "Offices",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_AspNetUsers_DeletedById",
                table: "Offices",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_AspNetUsers_ModifiedById",
                table: "Offices",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_CreatedById",
                table: "Transactions",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_DeletedById",
                table: "Transactions",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_ModifiedById",
                table: "Transactions",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_CreatedById",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_DeletedById",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_ModifiedById",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_CreatedById",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_DeletedById",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_ModifiedById",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_AspNetUsers_CreatedById",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_AspNetUsers_DeletedById",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_AspNetUsers_ModifiedById",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_AspNetUsers_CreatedById",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_AspNetUsers_DeletedById",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_AspNetUsers_ModifiedById",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_CreatedById",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_DeletedById",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_ModifiedById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CreatedById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DeletedById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ModifiedById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Offices_CreatedById",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Offices_DeletedById",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Offices_ModifiedById",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_CreatedById",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_DeletedById",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_ModifiedById",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CreatedById",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_DeletedById",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ModifiedById",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CreatedById",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_DeletedById",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ModifiedById",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Accounts");
        }
    }
}
