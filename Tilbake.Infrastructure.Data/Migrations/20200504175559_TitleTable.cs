using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class TitleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.CreateTable(
                name: "Land",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KlientNumber = table.Column<int>(type: "int", nullable: false),
                    KlientType = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IDNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Carrier = table.Column<int>(type: "int", nullable: false),
                    OccupationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LandID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BulkNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.ID);
                    table.CheckConstraint("CK_Klient_Carrier_Enum_Constraint", "[Carrier] IN(1, 2, 3)");
                    table.CheckConstraint("CK_Klient_Gender_Enum_Constraint", "[Gender] IN(1, 2, 3)");
                    table.CheckConstraint("CK_Klient_KlientType_Enum_Constraint", "[KlientType] IN(1, 2)");
                    table.ForeignKey(
                        name: "FK_Klient_Land_LandID",
                        column: x => x.LandID,
                        principalTable: "Land",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klient_Occupation_OccupationID",
                        column: x => x.OccupationID,
                        principalTable: "Occupation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klient_Title_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Title",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klient_LandID",
                table: "Klient",
                column: "LandID");

            migrationBuilder.CreateIndex(
                name: "IX_Klient_OccupationID",
                table: "Klient",
                column: "OccupationID");

            migrationBuilder.CreateIndex(
                name: "IX_Klient_TitleID",
                table: "Klient",
                column: "TitleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Land");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
