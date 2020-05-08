using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class AddKlientNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.CreateTable(
                name: "KlientNumberGenerator",
                columns: table => new
                {
                    KlientNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlientNumber", x => x.KlientNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropTable(
                name: "KlientNumberGenerator");
        }
    }
}
