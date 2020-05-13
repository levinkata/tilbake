using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class MotorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItems_CoverType_CoverTypeID",
                table: "QuoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItems_Insurer_InsurerID",
                table: "QuoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItems_KlientRisk_KlientRiskID",
                table: "QuoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItems_Quotes_QuoteID",
                table: "QuoteItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteItems",
                table: "QuoteItems");

            migrationBuilder.RenameTable(
                name: "QuoteItems",
                newName: "QuoteItem");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItems_QuoteID",
                table: "QuoteItem",
                newName: "IX_QuoteItem_QuoteID");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItems_KlientRiskID",
                table: "QuoteItem",
                newName: "IX_QuoteItem_KlientRiskID");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItems_InsurerID",
                table: "QuoteItem",
                newName: "IX_QuoteItem_InsurerID");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItems_CoverTypeID",
                table: "QuoteItem",
                newName: "IX_QuoteItem_CoverTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteItem",
                table: "QuoteItem",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "InvoiceNumberGenerator",
                columns: table => new
                {
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNumber", x => x.InvoiceNumber);
                });

            migrationBuilder.CreateTable(
                name: "QuoteNumberGenerator",
                columns: table => new
                {
                    QuoteNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteNumber", x => x.QuoteNumber);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItem_CoverType_CoverTypeID",
                table: "QuoteItem",
                column: "CoverTypeID",
                principalTable: "CoverType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItem_Insurer_InsurerID",
                table: "QuoteItem",
                column: "InsurerID",
                principalTable: "Insurer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItem_KlientRisk_KlientRiskID",
                table: "QuoteItem",
                column: "KlientRiskID",
                principalTable: "KlientRisk",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItem_Quotes_QuoteID",
                table: "QuoteItem",
                column: "QuoteID",
                principalTable: "Quotes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItem_CoverType_CoverTypeID",
                table: "QuoteItem");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItem_Insurer_InsurerID",
                table: "QuoteItem");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItem_KlientRisk_KlientRiskID",
                table: "QuoteItem");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItem_Quotes_QuoteID",
                table: "QuoteItem");

            migrationBuilder.DropTable(
                name: "InvoiceNumberGenerator");

            migrationBuilder.DropTable(
                name: "QuoteNumberGenerator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteItem",
                table: "QuoteItem");

            migrationBuilder.RenameTable(
                name: "QuoteItem",
                newName: "QuoteItems");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItem_QuoteID",
                table: "QuoteItems",
                newName: "IX_QuoteItems_QuoteID");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItem_KlientRiskID",
                table: "QuoteItems",
                newName: "IX_QuoteItems_KlientRiskID");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItem_InsurerID",
                table: "QuoteItems",
                newName: "IX_QuoteItems_InsurerID");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItem_CoverTypeID",
                table: "QuoteItems",
                newName: "IX_QuoteItems_CoverTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteItems",
                table: "QuoteItems",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItems_CoverType_CoverTypeID",
                table: "QuoteItems",
                column: "CoverTypeID",
                principalTable: "CoverType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItems_Insurer_InsurerID",
                table: "QuoteItems",
                column: "InsurerID",
                principalTable: "Insurer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItems_KlientRisk_KlientRiskID",
                table: "QuoteItems",
                column: "KlientRiskID",
                principalTable: "KlientRisk",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItems_Quotes_QuoteID",
                table: "QuoteItems",
                column: "QuoteID",
                principalTable: "Quotes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
