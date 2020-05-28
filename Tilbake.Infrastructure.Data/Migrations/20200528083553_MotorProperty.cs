using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class MotorProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motor_MotorMake_MotorMakeID",
                table: "Motor");

            migrationBuilder.DropIndex(
                name: "IX_Motor_MotorMakeID",
                table: "Motor");

            migrationBuilder.DropColumn(
                name: "MotorMakeID",
                table: "Motor");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_MotorModelID",
                table: "Motor",
                column: "MotorModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Motor_MotorModel_MotorModelID",
                table: "Motor",
                column: "MotorModelID",
                principalTable: "MotorModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motor_MotorModel_MotorModelID",
                table: "Motor");

            migrationBuilder.DropIndex(
                name: "IX_Motor_MotorModelID",
                table: "Motor");

            migrationBuilder.AddColumn<Guid>(
                name: "MotorMakeID",
                table: "Motor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Motor_MotorMakeID",
                table: "Motor",
                column: "MotorMakeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Motor_MotorMake_MotorMakeID",
                table: "Motor",
                column: "MotorMakeID",
                principalTable: "MotorMake",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
