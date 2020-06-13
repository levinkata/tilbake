using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class UniqueContraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if(migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.CreateIndex(
                name: "IX_ChassisNumber",
                table: "Motor",
                column: "ChassisNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EngineNumber",
                table: "Motor",
                column: "EngineNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegNumber",
                table: "Motor",
                column: "RegNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_IDNumber",
                table: "Klient",
                column: "IDNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if(migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropIndex(
                name: "IX_ChassisNumber",
                table: "Motor");

            migrationBuilder.DropIndex(
                name: "IX_EngineNumber",
                table: "Motor");

            migrationBuilder.DropIndex(
                name: "IX_RegNumber",
                table: "Motor");

            migrationBuilder.DropIndex(
                name: "UQ_IDNumber",
                table: "Klient");
        }
    }
}
