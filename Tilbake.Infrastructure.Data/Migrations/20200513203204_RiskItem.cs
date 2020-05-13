using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class RiskItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropForeignKey(
                name: "FK_AllRisk_Component_ComponentID",
                table: "AllRisk");

            migrationBuilder.DropForeignKey(
                name: "FK_Glass_Component_ComponentID",
                table: "Glass");

            migrationBuilder.DropForeignKey(
                name: "FK_Politikk_PolicyStatus_PolitikkStatusID",
                table: "Politikk");

            migrationBuilder.DropForeignKey(
                name: "FK_Politikk_PolicyType_PolitikkTypeID",
                table: "Politikk");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolicyType",
                table: "PolicyType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolicyStatus",
                table: "PolicyStatus");

            migrationBuilder.RenameTable(
                name: "PolicyType",
                newName: "PolitikkType");

            migrationBuilder.RenameTable(
                name: "PolicyStatus",
                newName: "PolitikkStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolitikkType",
                table: "PolitikkType",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolitikkStatus",
                table: "PolitikkStatus",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "RiskItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskItem", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AllRisk_RiskItem_ComponentID",
                table: "AllRisk",
                column: "ComponentID",
                principalTable: "RiskItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Glass_RiskItem_ComponentID",
                table: "Glass",
                column: "ComponentID",
                principalTable: "RiskItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Politikk_PolitikkStatus_PolitikkStatusID",
                table: "Politikk",
                column: "PolitikkStatusID",
                principalTable: "PolitikkStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Politikk_PolitikkType_PolitikkTypeID",
                table: "Politikk",
                column: "PolitikkTypeID",
                principalTable: "PolitikkType",
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
                name: "FK_AllRisk_RiskItem_ComponentID",
                table: "AllRisk");

            migrationBuilder.DropForeignKey(
                name: "FK_Glass_RiskItem_ComponentID",
                table: "Glass");

            migrationBuilder.DropForeignKey(
                name: "FK_Politikk_PolitikkStatus_PolitikkStatusID",
                table: "Politikk");

            migrationBuilder.DropForeignKey(
                name: "FK_Politikk_PolitikkType_PolitikkTypeID",
                table: "Politikk");

            migrationBuilder.DropTable(
                name: "RiskItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolitikkType",
                table: "PolitikkType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolitikkStatus",
                table: "PolitikkStatus");

            migrationBuilder.RenameTable(
                name: "PolitikkType",
                newName: "PolicyType");

            migrationBuilder.RenameTable(
                name: "PolitikkStatus",
                newName: "PolicyStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolicyType",
                table: "PolicyType",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolicyStatus",
                table: "PolicyStatus",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AllRisk_Component_ComponentID",
                table: "AllRisk",
                column: "ComponentID",
                principalTable: "Component",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Glass_Component_ComponentID",
                table: "Glass",
                column: "ComponentID",
                principalTable: "Component",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Politikk_PolicyStatus_PolitikkStatusID",
                table: "Politikk",
                column: "PolitikkStatusID",
                principalTable: "PolicyStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Politikk_PolicyType_PolitikkTypeID",
                table: "Politikk",
                column: "PolitikkTypeID",
                principalTable: "PolicyType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
