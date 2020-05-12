﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tilbake.Infrastructure.Data.Migrations
{
    public partial class MoreTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankBranchID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BankAccount_BankBranch_BankBranchID",
                        column: x => x.BankBranchID,
                        principalTable: "BankBranch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LandID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_Land_LandID",
                        column: x => x.LandID,
                        principalTable: "Land",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "DriverType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Extension",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extension", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KravStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KravStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MotorMake",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorMake", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MotorUse",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorUse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PolicyStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PolicyType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PremiumType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuoteStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResidenceType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidenceType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoofType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoofType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WallType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KlientBankAccount",
                columns: table => new
                {
                    KlientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlientBankAccount", x => new { x.BankAccountID, x.KlientID });
                    table.ForeignKey(
                        name: "FK_KlientBankAccount_BankAccount_BankAccountID",
                        column: x => x.BankAccountID,
                        principalTable: "BankAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KlientBankAccount_Klient_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhysicalAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adresse_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllRisk",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllRisk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AllRisk_Component_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Component",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Glass",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glass", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Glass_Component_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Component",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KlientDocument",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KlientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlientDocument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KlientDocument_DocumentType_DocumentTypeID",
                        column: x => x.DocumentTypeID,
                        principalTable: "DocumentType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KlientDocument_Klient_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceStatus_InvoiceStatusID",
                        column: x => x.InvoiceStatusID,
                        principalTable: "InvoiceStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MakeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotorMakeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MotorModel_MotorMake_MotorMakeID",
                        column: x => x.MotorMakeID,
                        principalTable: "MotorMake",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motor",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BodyTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MotorMakeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MotorModeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegYear = table.Column<int>(type: "int", nullable: false),
                    DriverTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineCapacity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotorUseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecurityFitting = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Motor_BodyType_BodyTypeID",
                        column: x => x.BodyTypeID,
                        principalTable: "BodyType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motor_DriverType_DriverTypeID",
                        column: x => x.DriverTypeID,
                        principalTable: "DriverType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motor_MotorMake_MotorMakeID",
                        column: x => x.MotorMakeID,
                        principalTable: "MotorMake",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motor_MotorUse_MotorUseID",
                        column: x => x.MotorUseID,
                        principalTable: "MotorUse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteNumber = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    QuoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuoteStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KlientInfo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    InternalInfo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Quotes_QuoteStatus_QuoteStatusID",
                        column: x => x.QuoteStatusID,
                        principalTable: "QuoteStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Politikk",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortfolioKlientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolitikkNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PolitikkTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsurerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InceptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolitikkStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Politikk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Politikk_Insurer_InsurerID",
                        column: x => x.InsurerID,
                        principalTable: "Insurer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Politikk_PolicyStatus_PolitikkStatusID",
                        column: x => x.PolitikkStatusID,
                        principalTable: "PolicyStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Politikk_PolicyType_PolitikkTypeID",
                        column: x => x.PolitikkTypeID,
                        principalTable: "PolicyType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Politikk_PortfolioKlient_PortfolioKlientID",
                        column: x => x.PortfolioKlientID,
                        principalTable: "PortfolioKlient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Politikk_SalesType_SalesTypeID",
                        column: x => x.SalesTypeID,
                        principalTable: "SalesType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RoofTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WallTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Content_RoofType_RoofTypeID",
                        column: x => x.RoofTypeID,
                        principalTable: "RoofType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content_WallType_WallTypeID",
                        column: x => x.WallTypeID,
                        principalTable: "WallType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ResidenceTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoofTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WallTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.ID);
                    table.ForeignKey(
                        name: "FK_House_ResidenceType_ResidenceTypeID",
                        column: x => x.ResidenceTypeID,
                        principalTable: "ResidenceType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_House_RoofType_RoofTypeID",
                        column: x => x.RoofTypeID,
                        principalTable: "RoofType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_House_WallType_WallTypeID",
                        column: x => x.WallTypeID,
                        principalTable: "WallType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorImprovement",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MotorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FactoryFitted = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    MakeModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorImprovement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MotorImprovement_Motor_MotorID",
                        column: x => x.MotorID,
                        principalTable: "Motor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Premium",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolitikkID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PremiumDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiumMonth = table.Column<int>(type: "int", nullable: false),
                    PremiumYear = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PremiumTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Premium_Politikk_PolitikkID",
                        column: x => x.PolitikkID,
                        principalTable: "Politikk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Premium_PremiumType_PremiumTypeID",
                        column: x => x.PremiumTypeID,
                        principalTable: "PremiumType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllRiskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlassID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MotorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Risk_AllRisk_AllRiskID",
                        column: x => x.AllRiskID,
                        principalTable: "AllRisk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Risk_Content_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Content",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Risk_Glass_GlassID",
                        column: x => x.GlassID,
                        principalTable: "Glass",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Risk_House_HouseID",
                        column: x => x.HouseID,
                        principalTable: "House",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Risk_Motor_MotorID",
                        column: x => x.MotorID,
                        principalTable: "Motor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KlientRisk",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KlientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlientRisk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KlientRisk_Klient_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KlientRisk_Risk_RiskID",
                        column: x => x.RiskID,
                        principalTable: "Risk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolitikkRisk",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolitikkID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KlientRiskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SumInsured = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Excess = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolitikkRisk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PolitikkRisk_CoverType_CoverTypeID",
                        column: x => x.CoverTypeID,
                        principalTable: "CoverType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolitikkRisk_KlientRisk_KlientRiskID",
                        column: x => x.KlientRiskID,
                        principalTable: "KlientRisk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolitikkRisk_Politikk_PolitikkID",
                        column: x => x.PolitikkID,
                        principalTable: "Politikk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuoteItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KlientRiskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsurerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SumInsured = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Excess = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuoteItems_CoverType_CoverTypeID",
                        column: x => x.CoverTypeID,
                        principalTable: "CoverType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteItems_Insurer_InsurerID",
                        column: x => x.InsurerID,
                        principalTable: "Insurer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteItems_KlientRisk_KlientRiskID",
                        column: x => x.KlientRiskID,
                        principalTable: "KlientRisk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteItems_Quotes_QuoteID",
                        column: x => x.QuoteID,
                        principalTable: "Quotes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolitikkRiskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_PolitikkRisk_PolitikkRiskID",
                        column: x => x.PolitikkRiskID,
                        principalTable: "PolitikkRisk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Krav",
                columns: table => new
                {
                    KravNumber = table.Column<int>(type: "int", nullable: false),
                    PolitikkRiskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Claimant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReserveInsured = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReserveThirdParty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReserveInsuredRevised = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReserveThirdPartyRevised = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Excess = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecoverFromThirdParty = table.Column<bool>(type: "bit", nullable: false),
                    IncidentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KravStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentDetail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Krav", x => x.KravNumber);
                    table.ForeignKey(
                        name: "FK_Krav_Incident_IncidentID",
                        column: x => x.IncidentID,
                        principalTable: "Incident",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Krav_KravStatus_KravStatusID",
                        column: x => x.KravStatusID,
                        principalTable: "KravStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Krav_PolitikkRisk_PolitikkRiskID",
                        column: x => x.PolitikkRiskID,
                        principalTable: "PolitikkRisk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Krav_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolitikkRiskExtension",
                columns: table => new
                {
                    PolitikkRiskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtensionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolitikkRiskExtension", x => new { x.PolitikkRiskID, x.ExtensionID });
                    table.ForeignKey(
                        name: "FK_PolitikkRiskExtension_Extension_ExtensionID",
                        column: x => x.ExtensionID,
                        principalTable: "Extension",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolitikkRiskExtension_PolitikkRisk_PolitikkRiskID",
                        column: x => x.PolitikkRiskID,
                        principalTable: "PolitikkRisk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_CityID",
                table: "Adresse",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_AllRisk_ComponentID",
                table: "AllRisk",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BankBranchID",
                table: "BankAccount",
                column: "BankBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_City_LandID",
                table: "City",
                column: "LandID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_RoofTypeID",
                table: "Content",
                column: "RoofTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_WallTypeID",
                table: "Content",
                column: "WallTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Glass_ComponentID",
                table: "Glass",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_House_ResidenceTypeID",
                table: "House",
                column: "ResidenceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_House_RoofTypeID",
                table: "House",
                column: "RoofTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_House_WallTypeID",
                table: "House",
                column: "WallTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceStatusID",
                table: "Invoice",
                column: "InvoiceStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceID",
                table: "InvoiceItem",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_PolitikkRiskID",
                table: "InvoiceItem",
                column: "PolitikkRiskID");

            migrationBuilder.CreateIndex(
                name: "IX_KlientBankAccount_KlientID",
                table: "KlientBankAccount",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_KlientDocument_DocumentTypeID",
                table: "KlientDocument",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_KlientDocument_KlientID",
                table: "KlientDocument",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_KlientRisk_KlientID",
                table: "KlientRisk",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_KlientRisk_RiskID",
                table: "KlientRisk",
                column: "RiskID");

            migrationBuilder.CreateIndex(
                name: "IX_Krav_IncidentID",
                table: "Krav",
                column: "IncidentID");

            migrationBuilder.CreateIndex(
                name: "IX_Krav_KravStatusID",
                table: "Krav",
                column: "KravStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Krav_PolitikkRiskID",
                table: "Krav",
                column: "PolitikkRiskID");

            migrationBuilder.CreateIndex(
                name: "IX_Krav_RegionID",
                table: "Krav",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_BodyTypeID",
                table: "Motor",
                column: "BodyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_DriverTypeID",
                table: "Motor",
                column: "DriverTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_MotorMakeID",
                table: "Motor",
                column: "MotorMakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_MotorUseID",
                table: "Motor",
                column: "MotorUseID");

            migrationBuilder.CreateIndex(
                name: "IX_MotorImprovement_MotorID",
                table: "MotorImprovement",
                column: "MotorID");

            migrationBuilder.CreateIndex(
                name: "IX_MotorModel_MotorMakeID",
                table: "MotorModel",
                column: "MotorMakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Politikk_InsurerID",
                table: "Politikk",
                column: "InsurerID");

            migrationBuilder.CreateIndex(
                name: "IX_Politikk_PolitikkStatusID",
                table: "Politikk",
                column: "PolitikkStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Politikk_PolitikkTypeID",
                table: "Politikk",
                column: "PolitikkTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Politikk_PortfolioKlientID",
                table: "Politikk",
                column: "PortfolioKlientID");

            migrationBuilder.CreateIndex(
                name: "IX_Politikk_SalesTypeID",
                table: "Politikk",
                column: "SalesTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PolitikkRisk_CoverTypeID",
                table: "PolitikkRisk",
                column: "CoverTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PolitikkRisk_KlientRiskID",
                table: "PolitikkRisk",
                column: "KlientRiskID");

            migrationBuilder.CreateIndex(
                name: "IX_PolitikkRisk_PolitikkID",
                table: "PolitikkRisk",
                column: "PolitikkID");

            migrationBuilder.CreateIndex(
                name: "IX_PolitikkRiskExtension_ExtensionID",
                table: "PolitikkRiskExtension",
                column: "ExtensionID");

            migrationBuilder.CreateIndex(
                name: "IX_Premium_PolitikkID",
                table: "Premium",
                column: "PolitikkID");

            migrationBuilder.CreateIndex(
                name: "IX_Premium_PremiumTypeID",
                table: "Premium",
                column: "PremiumTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_CoverTypeID",
                table: "QuoteItems",
                column: "CoverTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_InsurerID",
                table: "QuoteItems",
                column: "InsurerID");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_KlientRiskID",
                table: "QuoteItems",
                column: "KlientRiskID");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_QuoteID",
                table: "QuoteItems",
                column: "QuoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuoteStatusID",
                table: "Quotes",
                column: "QuoteStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_AllRiskID",
                table: "Risk",
                column: "AllRiskID");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_ContentID",
                table: "Risk",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_GlassID",
                table: "Risk",
                column: "GlassID");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_HouseID",
                table: "Risk",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_MotorID",
                table: "Risk",
                column: "MotorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "KlientBankAccount");

            migrationBuilder.DropTable(
                name: "KlientDocument");

            migrationBuilder.DropTable(
                name: "Krav");

            migrationBuilder.DropTable(
                name: "MotorImprovement");

            migrationBuilder.DropTable(
                name: "MotorModel");

            migrationBuilder.DropTable(
                name: "PolitikkRiskExtension");

            migrationBuilder.DropTable(
                name: "Premium");

            migrationBuilder.DropTable(
                name: "QuoteItems");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "KravStatus");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Extension");

            migrationBuilder.DropTable(
                name: "PolitikkRisk");

            migrationBuilder.DropTable(
                name: "PremiumType");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "InvoiceStatus");

            migrationBuilder.DropTable(
                name: "KlientRisk");

            migrationBuilder.DropTable(
                name: "Politikk");

            migrationBuilder.DropTable(
                name: "QuoteStatus");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "PolicyStatus");

            migrationBuilder.DropTable(
                name: "PolicyType");

            migrationBuilder.DropTable(
                name: "SalesType");

            migrationBuilder.DropTable(
                name: "AllRisk");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Glass");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Motor");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "ResidenceType");

            migrationBuilder.DropTable(
                name: "RoofType");

            migrationBuilder.DropTable(
                name: "WallType");

            migrationBuilder.DropTable(
                name: "DriverType");

            migrationBuilder.DropTable(
                name: "MotorMake");

            migrationBuilder.DropTable(
                name: "MotorUse");
        }
    }
}
