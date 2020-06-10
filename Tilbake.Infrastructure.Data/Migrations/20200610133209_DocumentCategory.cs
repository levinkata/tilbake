using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class DocumentCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropForeignKey(
                name: "FK_KlientDocument_DocumentType_DocumentTypeID",
                table: "KlientDocument");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropIndex(
                name: "IX_KlientDocument_DocumentTypeID",
                table: "KlientDocument");

            migrationBuilder.DropColumn(
                name: "DocumentTypeID",
                table: "KlientDocument");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentCategoryID",
                table: "KlientDocument",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DocumentCategory",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCategory", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KlientDocument_DocumentCategoryID",
                table: "KlientDocument",
                column: "DocumentCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_KlientDocument_DocumentCategory_DocumentCategoryID",
                table: "KlientDocument",
                column: "DocumentCategoryID",
                principalTable: "DocumentCategory",
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
                name: "FK_KlientDocument_DocumentCategory_DocumentCategoryID",
                table: "KlientDocument");

            migrationBuilder.DropTable(
                name: "DocumentCategory");

            migrationBuilder.DropIndex(
                name: "IX_KlientDocument_DocumentCategoryID",
                table: "KlientDocument");

            migrationBuilder.DropColumn(
                name: "DocumentCategoryID",
                table: "KlientDocument");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentTypeID",
                table: "KlientDocument",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KlientDocument_DocumentTypeID",
                table: "KlientDocument",
                column: "DocumentTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_KlientDocument_DocumentType_DocumentTypeID",
                table: "KlientDocument",
                column: "DocumentTypeID",
                principalTable: "DocumentType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
