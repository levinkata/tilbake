using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class NullRiskFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_AllRisk_AllRiskID",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Content_ContentID",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Glass_GlassID",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_House_HouseID",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Motor_MotorID",
                table: "Risk");

            migrationBuilder.AlterColumn<Guid>(
                name: "MotorID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "HouseID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GlassID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContentID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AllRiskID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_AllRisk_AllRiskID",
                table: "Risk",
                column: "AllRiskID",
                principalTable: "AllRisk",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Content_ContentID",
                table: "Risk",
                column: "ContentID",
                principalTable: "Content",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Glass_GlassID",
                table: "Risk",
                column: "GlassID",
                principalTable: "Glass",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_House_HouseID",
                table: "Risk",
                column: "HouseID",
                principalTable: "House",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Motor_MotorID",
                table: "Risk",
                column: "MotorID",
                principalTable: "Motor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_AllRisk_AllRiskID",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Content_ContentID",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Glass_GlassID",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_House_HouseID",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Motor_MotorID",
                table: "Risk");

            migrationBuilder.AlterColumn<Guid>(
                name: "MotorID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HouseID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GlassID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContentID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AllRiskID",
                table: "Risk",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_AllRisk_AllRiskID",
                table: "Risk",
                column: "AllRiskID",
                principalTable: "AllRisk",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Content_ContentID",
                table: "Risk",
                column: "ContentID",
                principalTable: "Content",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Glass_GlassID",
                table: "Risk",
                column: "GlassID",
                principalTable: "Glass",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_House_HouseID",
                table: "Risk",
                column: "HouseID",
                principalTable: "House",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Motor_MotorID",
                table: "Risk",
                column: "MotorID",
                principalTable: "Motor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
