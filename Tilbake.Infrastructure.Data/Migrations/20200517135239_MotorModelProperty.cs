using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class MotorModelProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if(migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropForeignKey(
                name: "FK_MotorModel_MotorMake_MotorMakeID",
                table: "MotorModel");

            migrationBuilder.DropColumn(
                name: "MakeID",
                table: "MotorModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "MotorMakeID",
                table: "MotorModel",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MotorModel_MotorMake_MotorMakeID",
                table: "MotorModel",
                column: "MotorMakeID",
                principalTable: "MotorMake",
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
                name: "FK_MotorModel_MotorMake_MotorMakeID",
                table: "MotorModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "MotorMakeID",
                table: "MotorModel",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "MakeID",
                table: "MotorModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_MotorModel_MotorMake_MotorMakeID",
                table: "MotorModel",
                column: "MotorMakeID",
                principalTable: "MotorMake",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
