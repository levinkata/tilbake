using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class KravNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Glass_ComponentID",
                table: "Glass");

            migrationBuilder.DropIndex(
                name: "IX_AllRisk_ComponentID",
                table: "AllRisk");

            migrationBuilder.DropColumn(
                name: "ComponentID",
                table: "Glass");

            migrationBuilder.DropColumn(
                name: "ComponentID",
                table: "AllRisk");

            migrationBuilder.AddColumn<Guid>(
                name: "RiskItemID",
                table: "Glass",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RiskItemID",
                table: "AllRisk",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "KravNumberGenerator",
                columns: table => new
                {
                    KravNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KravNumber", x => x.KravNumber);
                });

            migrationBuilder.CreateTable(
                name: "PolitikkNumberGenerator",
                columns: table => new
                {
                    PolitikkNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolitikkNumber", x => x.PolitikkNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Glass_RiskItemID",
                table: "Glass",
                column: "RiskItemID");

            migrationBuilder.CreateIndex(
                name: "IX_AllRisk_RiskItemID",
                table: "AllRisk",
                column: "RiskItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_AllRisk_RiskItem_RiskItemID",
                table: "AllRisk",
                column: "RiskItemID",
                principalTable: "RiskItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Glass_RiskItem_RiskItemID",
                table: "Glass",
                column: "RiskItemID",
                principalTable: "RiskItem",
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
                name: "FK_AllRisk_RiskItem_RiskItemID",
                table: "AllRisk");

            migrationBuilder.DropForeignKey(
                name: "FK_Glass_RiskItem_RiskItemID",
                table: "Glass");

            migrationBuilder.DropTable(
                name: "KravNumberGenerator");

            migrationBuilder.DropTable(
                name: "PolitikkNumberGenerator");

            migrationBuilder.DropIndex(
                name: "IX_Glass_RiskItemID",
                table: "Glass");

            migrationBuilder.DropIndex(
                name: "IX_AllRisk_RiskItemID",
                table: "AllRisk");

            migrationBuilder.DropColumn(
                name: "RiskItemID",
                table: "Glass");

            migrationBuilder.DropColumn(
                name: "RiskItemID",
                table: "AllRisk");

            migrationBuilder.AddColumn<Guid>(
                name: "ComponentID",
                table: "Glass",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ComponentID",
                table: "AllRisk",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Glass_ComponentID",
                table: "Glass",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_AllRisk_ComponentID",
                table: "AllRisk",
                column: "ComponentID");

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
        }
    }
}
