﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;

namespace Tilbake.Core.Context;

public partial class TilbakeDbContext : DbContext
{
    public TilbakeDbContext()
    {
    }

    public TilbakeDbContext(DbContextOptions<TilbakeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AllRisk> AllRisks { get; set; }

    public virtual DbSet<AllRiskSpecified> AllRiskSpecifieds { get; set; }

    public virtual DbSet<ApplicationSession> ApplicationSessions { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<AspnetUserPortfolio> AspnetUserPortfolios { get; set; }

    public virtual DbSet<Attorney> Attorneys { get; set; }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<BankAuditLog> BankAuditLogs { get; set; }

    public virtual DbSet<BankBranch> BankBranches { get; set; }

    public virtual DbSet<Beneficiary> Beneficiaries { get; set; }

    public virtual DbSet<BodyType> BodyTypes { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<BuildingCondition> BuildingConditions { get; set; }

    public virtual DbSet<Carrier> Carriers { get; set; }

    public virtual DbSet<ChartOfAccount> ChartOfAccounts { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<ClaimAttorney> ClaimAttorneys { get; set; }

    public virtual DbSet<ClaimDocument> ClaimDocuments { get; set; }

    public virtual DbSet<ClaimLossAdjuster> ClaimLossAdjusters { get; set; }

    public virtual DbSet<ClaimNumberGenerator> ClaimNumberGenerators { get; set; }

    public virtual DbSet<ClaimRepairer> ClaimRepairers { get; set; }

    public virtual DbSet<ClaimRoadsideAssist> ClaimRoadsideAssists { get; set; }

    public virtual DbSet<ClaimStatus> ClaimStatuses { get; set; }

    public virtual DbSet<ClaimThirdParty> ClaimThirdParties { get; set; }

    public virtual DbSet<ClaimTowTruck> ClaimTowTrucks { get; set; }

    public virtual DbSet<ClaimTracingAgent> ClaimTracingAgents { get; set; }

    public virtual DbSet<Claimant> Claimants { get; set; }

    public virtual DbSet<CommissionRate> CommissionRates { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyBankAccount> CompanyBankAccounts { get; set; }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<ContentContentItem> ContentContentItems { get; set; }

    public virtual DbSet<ContentGroupItem> ContentGroupItems { get; set; }

    public virtual DbSet<ContentItem> ContentItems { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CoverType> CoverTypes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerBankAccount> CustomerBankAccounts { get; set; }

    public virtual DbSet<CustomerBulk> CustomerBulks { get; set; }

    public virtual DbSet<CustomerCarrier> CustomerCarriers { get; set; }

    public virtual DbSet<CustomerDocument> CustomerDocuments { get; set; }

    public virtual DbSet<CustomerNumberGenerator> CustomerNumberGenerators { get; set; }

    public virtual DbSet<CustomerRisk> CustomerRisks { get; set; }

    public virtual DbSet<CustomerRiskDocument> CustomerRiskDocuments { get; set; }

    public virtual DbSet<CustomerStatus> CustomerStatuses { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriverType> DriverTypes { get; set; }

    public virtual DbSet<Eftfile> Eftfiles { get; set; }

    public virtual DbSet<ElectronicEquipment> ElectronicEquipments { get; set; }

    public virtual DbSet<EmailAddress> EmailAddresses { get; set; }

    public virtual DbSet<ExcessBuyBack> ExcessBuyBacks { get; set; }

    public virtual DbSet<Extension> Extensions { get; set; }

    public virtual DbSet<FileTemplate> FileTemplates { get; set; }

    public virtual DbSet<FileTemplateRecord> FileTemplateRecords { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Glass> Glasses { get; set; }

    public virtual DbSet<House> Houses { get; set; }

    public virtual DbSet<HouseCondition> HouseConditions { get; set; }

    public virtual DbSet<IdDocumentType> IdDocumentTypes { get; set; }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<IncidentAuditLog> IncidentAuditLogs { get; set; }

    public virtual DbSet<Insurer> Insurers { get; set; }

    public virtual DbSet<InsurerAuditLog> InsurerAuditLogs { get; set; }

    public virtual DbSet<InsurerBranch> InsurerBranches { get; set; }

    public virtual DbSet<InterMediate> InterMediates { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<InvoiceNumberGenerator> InvoiceNumberGenerators { get; set; }

    public virtual DbSet<InvoiceStatus> InvoiceStatuses { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Life> Lives { get; set; }

    public virtual DbSet<LossAdjuster> LossAdjusters { get; set; }

    public virtual DbSet<LossAdjusterAuthority> LossAdjusterAuthorities { get; set; }

    public virtual DbSet<LossAdjusterInstruction> LossAdjusterInstructions { get; set; }

    public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }

    public virtual DbSet<MobileNumber> MobileNumbers { get; set; }

    public virtual DbSet<Motor> Motors { get; set; }

    public virtual DbSet<MotorAccessory> MotorAccessories { get; set; }

    public virtual DbSet<MotorCycle> MotorCycles { get; set; }

    public virtual DbSet<MotorCycleType> MotorCycleTypes { get; set; }

    public virtual DbSet<MotorDriver> MotorDrivers { get; set; }

    public virtual DbSet<MotorImprovement> MotorImprovements { get; set; }

    public virtual DbSet<MotorMake> MotorMakes { get; set; }

    public virtual DbSet<MotorModel> MotorModels { get; set; }

    public virtual DbSet<MotorRadio> MotorRadios { get; set; }

    public virtual DbSet<Occupation> Occupations { get; set; }

    public virtual DbSet<Payable> Payables { get; set; }

    public virtual DbSet<PayableRequisition> PayableRequisitions { get; set; }

    public virtual DbSet<Payee> Payees { get; set; }

    public virtual DbSet<PayeeBankAccount> PayeeBankAccounts { get; set; }

    public virtual DbSet<PayeeType> PayeeTypes { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<PolicyBulk> PolicyBulks { get; set; }

    public virtual DbSet<PolicyNumberGenerator> PolicyNumberGenerators { get; set; }

    public virtual DbSet<PolicyRenewal> PolicyRenewals { get; set; }

    public virtual DbSet<PolicyRisk> PolicyRisks { get; set; }

    public virtual DbSet<PolicyRiskClaim> PolicyRiskClaims { get; set; }

    public virtual DbSet<PolicyRiskExtension> PolicyRiskExtensions { get; set; }

    public virtual DbSet<PolicyStatus> PolicyStatuses { get; set; }

    public virtual DbSet<PolicyType> PolicyTypes { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<PortfolioAdministrationFee> PortfolioAdministrationFees { get; set; }

    public virtual DbSet<PortfolioCustomer> PortfolioCustomers { get; set; }

    public virtual DbSet<PortfolioExcessBuyBack> PortfolioExcessBuyBacks { get; set; }

    public virtual DbSet<PortfolioPolicyFee> PortfolioPolicyFees { get; set; }

    public virtual DbSet<PortfolioRatingMotor> PortfolioRatingMotors { get; set; }

    public virtual DbSet<PortfolioRatingMotorDiscount> PortfolioRatingMotorDiscounts { get; set; }

    public virtual DbSet<PortfolioRatingMotorExcess> PortfolioRatingMotorExcesses { get; set; }

    public virtual DbSet<PortfolioRatingMotorPremium> PortfolioRatingMotorPremia { get; set; }

    public virtual DbSet<Premium> Premia { get; set; }

    public virtual DbSet<PremiumBulk> PremiumBulks { get; set; }

    public virtual DbSet<PremiumInstallment> PremiumInstallments { get; set; }

    public virtual DbSet<PremiumRefund> PremiumRefunds { get; set; }

    public virtual DbSet<PremiumRefundClaim> PremiumRefundClaims { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PublicLiability> PublicLiabilities { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<QuoteItem> QuoteItems { get; set; }

    public virtual DbSet<QuoteNumberGenerator> QuoteNumberGenerators { get; set; }

    public virtual DbSet<QuoteStatus> QuoteStatuses { get; set; }

    public virtual DbSet<RatingMotor> RatingMotors { get; set; }

    public virtual DbSet<RatingMotorDiscount> RatingMotorDiscounts { get; set; }

    public virtual DbSet<RatingMotorExcess> RatingMotorExcesses { get; set; }

    public virtual DbSet<RatingMotorPremium> RatingMotorPremia { get; set; }

    public virtual DbSet<Receivable> Receivables { get; set; }

    public virtual DbSet<ReceivableDocument> ReceivableDocuments { get; set; }

    public virtual DbSet<ReceivableInvoice> ReceivableInvoices { get; set; }

    public virtual DbSet<ReceivableQuote> ReceivableQuotes { get; set; }

    public virtual DbSet<Reconcilliation> Reconcilliations { get; set; }

    public virtual DbSet<RefundStatus> RefundStatuses { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RelationType> RelationTypes { get; set; }

    public virtual DbSet<Repairer> Repairers { get; set; }

    public virtual DbSet<Requisition> Requisitions { get; set; }

    public virtual DbSet<RequisitionNumberGenerator> RequisitionNumberGenerators { get; set; }

    public virtual DbSet<ResidenceType> ResidenceTypes { get; set; }

    public virtual DbSet<ResidenceUse> ResidenceUses { get; set; }

    public virtual DbSet<Risk> Risks { get; set; }

    public virtual DbSet<RiskItem> RiskItems { get; set; }

    public virtual DbSet<RoadsideAssist> RoadsideAssists { get; set; }

    public virtual DbSet<RoofType> RoofTypes { get; set; }

    public virtual DbSet<SalesType> SalesTypes { get; set; }

    public virtual DbSet<StatedBenefit> StatedBenefits { get; set; }

    public virtual DbSet<Tax> Taxes { get; set; }

    public virtual DbSet<ThirdParty> ThirdParties { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<TowTruck> TowTrucks { get; set; }

    public virtual DbSet<TracingAgent> TracingAgents { get; set; }

    public virtual DbSet<Trailer> Trailers { get; set; }

    public virtual DbSet<Travel> Travels { get; set; }

    public virtual DbSet<TravelMember> TravelMembers { get; set; }

    public virtual DbSet<ValuationFeeRefund> ValuationFeeRefunds { get; set; }

    public virtual DbSet<ValuationFeeRefundClaim> ValuationFeeRefundClaims { get; set; }

    public virtual DbSet<WallType> WallTypes { get; set; }

    public virtual DbSet<Withdrawal> Withdrawals { get; set; }

    public virtual DbSet<WorkmanCompensation> WorkmanCompensations { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Database=tilbake;User Id=tilbake;Password=Nt7H1wK3X5!~;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.PhysicalAddress).HasMaxLength(100);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);

            entity.HasOne(d => d.Attorney).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AttorneyId)
                .HasConstraintName("FK_Address_Attorney");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Address_City");

            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Address_Customer");

            entity.HasOne(d => d.LossAdjuster).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.LossAdjusterId)
                .HasConstraintName("FK_Address_LossAdjuster");

            entity.HasOne(d => d.Repairer).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.RepairerId)
                .HasConstraintName("FK_Address_Repairer");

            entity.HasOne(d => d.RoadsideAssist).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.RoadsideAssistId)
                .HasConstraintName("FK_Address_RoadsideAssist");

            entity.HasOne(d => d.ThirdParty).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ThirdPartyId)
                .HasConstraintName("FK_Address_ThirdParty");

            entity.HasOne(d => d.TowTruck).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.TowTruckId)
                .HasConstraintName("FK_Address_TowTruck");

            entity.HasOne(d => d.TracingAgent).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.TracingAgentId)
                .HasConstraintName("FK_Address_TracingAgent");
        });

        modelBuilder.Entity<AllRisk>(entity =>
        {
            entity.ToTable("AllRisk");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.RiskItem).WithMany(p => p.AllRisks)
                .HasForeignKey(d => d.RiskItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllRisk_RiskItem");
        });

        modelBuilder.Entity<AllRiskSpecified>(entity =>
        {
            entity.ToTable("AllRiskSpecified");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.SerialNumber).HasMaxLength(50);

            entity.HasOne(d => d.RiskItem).WithMany(p => p.AllRiskSpecifieds)
                .HasForeignKey(d => d.RiskItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllRiskSpecified_RiskItem");
        });

        modelBuilder.Entity<ApplicationSession>(entity =>
        {
            entity.ToTable("ApplicationSession");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Value).HasMaxLength(100);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AspNetRo__3214EC079DC5E294");

            entity.Property(e => e.Id).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.Property(e => e.RoleId).HasMaxLength(250);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.JobTitleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ManNumber).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__AspNetUs__AF2760ADEB228D7E");
                        j.ToTable("AspNetUserRoles");
                        j.IndexerProperty<string>("UserId").HasMaxLength(250);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(250);
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(250);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetUserClaims_AspNetUsers");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(250);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__AspNetUs__1788CC4CC42F81E2");

            entity.Property(e => e.UserId).HasMaxLength(250);
            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<AspnetUserPortfolio>(entity =>
        {
            entity.HasKey(e => new { e.AspNetUserId, e.PortfolioId });

            entity.ToTable("AspnetUserPortfolio");

            entity.Property(e => e.AspNetUserId).HasMaxLength(250);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.AspNetUser).WithMany(p => p.AspnetUserPortfolios)
                .HasForeignKey(d => d.AspNetUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspnetUserPortfolio_AspNetUsers");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.AspnetUserPortfolios)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspnetUserPortfolio_Portfolio");
        });

        modelBuilder.Entity<Attorney>(entity =>
        {
            entity.ToTable("Attorney");

            entity.HasIndex(e => e.IdNumber, "IX_Attorney").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.ToTable("Audit");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.PrimaryKey).HasMaxLength(250);
            entity.Property(e => e.TableName).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(250);
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.ToTable("Bank", tb => tb.HasTrigger("Tr_Bank_Audit_Timestamp"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.ToTable("BankAccount");

            entity.HasIndex(e => e.AccountNumber, "IX_BankAccount").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.BankBranch).WithMany(p => p.BankAccounts)
                .HasForeignKey(d => d.BankBranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BankAccount_BankBranch");
        });

        modelBuilder.Entity<BankAuditLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BankAuditLog");

            entity.Property(e => e.DmlCreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DmlTimestamp).HasColumnType("datetime");
            entity.Property(e => e.DmlType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NewRowData).HasMaxLength(1000);
            entity.Property(e => e.OldRowData).HasMaxLength(1000);
            entity.Property(e => e.TrxTimestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<BankBranch>(entity =>
        {
            entity.ToTable("BankBranch", tb => tb.HasTrigger("Tr_BankBranch_Audit_Timestamp"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SortCode).HasMaxLength(50);
            entity.Property(e => e.SwiftCode).HasMaxLength(50);

            entity.HasOne(d => d.Bank).WithMany(p => p.BankBranches)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BankBranch_Bank");
        });

        modelBuilder.Entity<Beneficiary>(entity =>
        {
            entity.ToTable("Beneficiary");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.PortfolioCustomer).WithMany(p => p.Beneficiaries)
                .HasForeignKey(d => d.PortfolioCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beneficiary_PortfolioCustomer");

            entity.HasOne(d => d.RelationType).WithMany(p => p.Beneficiaries)
                .HasForeignKey(d => d.RelationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beneficiary_RelationType");
        });

        modelBuilder.Entity<BodyType>(entity =>
        {
            entity.ToTable("BodyType", tb => tb.HasTrigger("Tr_BodyType_Audit_Timestamp"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.ToTable("Building");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ArmedResponseName).HasMaxLength(50);
            entity.Property(e => e.BondHolder).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.PhysicalAddress).HasMaxLength(150);
            entity.Property(e => e.UnoccupancyPeriod).HasMaxLength(50);

            entity.HasOne(d => d.BuildingCondition).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.BuildingConditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Building_BuildingCondition");

            entity.HasOne(d => d.ResidenceType).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.ResidenceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Building_ResidenceType");

            entity.HasOne(d => d.ResidenceUse).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.ResidenceUseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Building_ResidenceUse");

            entity.HasOne(d => d.RoofType).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.RoofTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Building_RoofType");

            entity.HasOne(d => d.WallType).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.WallTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Building_WallType");
        });

        modelBuilder.Entity<BuildingCondition>(entity =>
        {
            entity.ToTable("BuildingCondition");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.ToTable("Carrier", tb => tb.HasTrigger("Tr_Carrier_Audit_Timestamp"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ChartOfAccount>(entity =>
        {
            entity.HasIndex(e => e.Glcode, "IX_ChartOfAccounts").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Glcode)
                .HasMaxLength(5)
                .HasColumnName("GLCode");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City", tb => tb.HasTrigger("Tr_City_Audit_Timestamp"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Country");
        });

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.ToTable("Claim", tb => tb.HasTrigger("Tr_Claim_Number"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Comment).HasMaxLength(100);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.EstimateOd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("EstimateOD");
            entity.Property(e => e.EstimateTp)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("EstimateTP");
            entity.Property(e => e.Excess).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IncidentDate).HasColumnType("date");
            entity.Property(e => e.IncidentDetail).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasColumnType("date");
            entity.Property(e => e.ReportDate).HasColumnType("date");
            entity.Property(e => e.RevisedEstimateOd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("RevisedEstimateOD");
            entity.Property(e => e.RevisedEstimateTp)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("RevisedEstimateTP");

            entity.HasOne(d => d.ClaimStatus).WithMany(p => p.Claims)
                .HasForeignKey(d => d.ClaimStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Claim_ClaimStatus");

            entity.HasOne(d => d.Claimant).WithMany(p => p.Claims)
                .HasForeignKey(d => d.ClaimantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Claim_Claimant");

            entity.HasOne(d => d.Incident).WithMany(p => p.Claims)
                .HasForeignKey(d => d.IncidentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Claim_Incident");

            entity.HasOne(d => d.Region).WithMany(p => p.Claims)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Claim_Region");
        });

        modelBuilder.Entity<ClaimAttorney>(entity =>
        {
            entity.HasKey(e => new { e.ClaimNumber, e.AttorneyId });

            entity.ToTable("ClaimAttorney");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Attorney).WithMany(p => p.ClaimAttorneys)
                .HasForeignKey(d => d.AttorneyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimAttorney_Attorney");
        });

        modelBuilder.Entity<ClaimDocument>(entity =>
        {
            entity.HasKey(e => new { e.ClaimId, e.DocumentId });

            entity.ToTable("ClaimDocument");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimDocuments)
                .HasForeignKey(d => d.ClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimDocument_Claim");

            entity.HasOne(d => d.Document).WithMany(p => p.ClaimDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimDocument_Document");
        });

        modelBuilder.Entity<ClaimLossAdjuster>(entity =>
        {
            entity.HasKey(e => new { e.ClaimNumber, e.LossAdjusterId });

            entity.ToTable("ClaimLossAdjuster");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.LossAdjuster).WithMany(p => p.ClaimLossAdjusters)
                .HasForeignKey(d => d.LossAdjusterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimLossAdjuster_LossAdjuster");
        });

        modelBuilder.Entity<ClaimNumberGenerator>(entity =>
        {
            entity.ToTable("ClaimNumberGenerator");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
        });

        modelBuilder.Entity<ClaimRepairer>(entity =>
        {
            entity.HasKey(e => new { e.ClaimNumber, e.RepairerId });

            entity.ToTable("ClaimRepairer");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Repairer).WithMany(p => p.ClaimRepairers)
                .HasForeignKey(d => d.RepairerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimRepairer_Repairer");
        });

        modelBuilder.Entity<ClaimRoadsideAssist>(entity =>
        {
            entity.HasKey(e => new { e.ClaimNumber, e.RoadsideAssistId });

            entity.ToTable("ClaimRoadsideAssist");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.RoadsideAssist).WithMany(p => p.ClaimRoadsideAssists)
                .HasForeignKey(d => d.RoadsideAssistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimRoadsideAssist_RoadsideAssist");
        });

        modelBuilder.Entity<ClaimStatus>(entity =>
        {
            entity.ToTable("ClaimStatus");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ClaimThirdParty>(entity =>
        {
            entity.HasKey(e => new { e.ClaimNumber, e.ThirdPartyId });

            entity.ToTable("ClaimThirdParty");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.ThirdParty).WithMany(p => p.ClaimThirdParties)
                .HasForeignKey(d => d.ThirdPartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimThirdParty_ThirdParty");
        });

        modelBuilder.Entity<ClaimTowTruck>(entity =>
        {
            entity.HasKey(e => new { e.ClaimNumber, e.TowTruckId });

            entity.ToTable("ClaimTowTruck");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.TowTruck).WithMany(p => p.ClaimTowTrucks)
                .HasForeignKey(d => d.TowTruckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimTowTruck_TowTruck");
        });

        modelBuilder.Entity<ClaimTracingAgent>(entity =>
        {
            entity.HasKey(e => new { e.ClaimNumber, e.TracingAgentId });

            entity.ToTable("ClaimTracingAgent");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.TracingAgent).WithMany(p => p.ClaimTracingAgents)
                .HasForeignKey(d => d.TracingAgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimTracingAgent_TracingAgent");
        });

        modelBuilder.Entity<Claimant>(entity =>
        {
            entity.ToTable("Claimant");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CommissionRate>(entity =>
        {
            entity.ToTable("CommissionRate");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RiskName).HasMaxLength(50);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PhysicalAddress).HasMaxLength(100);
            entity.Property(e => e.PhysicalAddress1).HasMaxLength(100);
            entity.Property(e => e.PhysicalAddress2).HasMaxLength(100);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.TaxNumber).HasMaxLength(50);
            entity.Property(e => e.Website).HasMaxLength(100);
        });

        modelBuilder.Entity<CompanyBankAccount>(entity =>
        {
            entity.ToTable("CompanyBankAccount");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.BankAccount).WithMany(p => p.CompanyBankAccounts)
                .HasForeignKey(d => d.BankAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyBankAccount_BankAccount");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyBankAccounts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyBankAccount_Company");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.ToTable("Content");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ArmedResponseName).HasMaxLength(50);
            entity.Property(e => e.BondHolder).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.PhysicalAddress).HasMaxLength(50);
            entity.Property(e => e.UnoccupancyPeriod).HasMaxLength(50);

            entity.HasOne(d => d.BuildingCondition).WithMany(p => p.Contents)
                .HasForeignKey(d => d.BuildingConditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Content_BuildingCondition");

            entity.HasOne(d => d.ResidenceType).WithMany(p => p.Contents)
                .HasForeignKey(d => d.ResidenceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Content_ResidenceType");

            entity.HasOne(d => d.ResidenceUse).WithMany(p => p.Contents)
                .HasForeignKey(d => d.ResidenceUseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Content_ResidenceUse");

            entity.HasOne(d => d.RoofType).WithMany(p => p.Contents)
                .HasForeignKey(d => d.RoofTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Content_RoofType");

            entity.HasOne(d => d.WallType).WithMany(p => p.Contents)
                .HasForeignKey(d => d.WallTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Content_WallType");
        });

        modelBuilder.Entity<ContentContentItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ContentContentItem_1");

            entity.ToTable("ContentContentItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.SumInsured).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ContentGroupItem>(entity =>
        {
            entity.ToTable("ContentGroupItem");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ContentItem>(entity =>
        {
            entity.ToTable("ContentItem");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.ContentGroupItem).WithMany(p => p.ContentItems)
                .HasForeignKey(d => d.ContentGroupItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContentItem_ContentGroupItem");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DialingCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("((267))");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CoverType>(entity =>
        {
            entity.ToTable("CoverType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Customer");

            entity.ToTable("Customer", tb => tb.HasTrigger("Tr_Customer_Number"));

            entity.HasIndex(e => e.IdNumber, "IX_Customer").IsUnique();

            entity.HasIndex(e => e.CustomerNumber, "IX_Customer_CustomerNumber").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Country");

            entity.HasOne(d => d.CustomerStatus).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_CustomerStatus");

            entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_CustomerType");

            entity.HasOne(d => d.Gender).WithMany(p => p.Customers)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Gender");

            entity.HasOne(d => d.IdDocumentType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdDocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_IdDocumentType");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.Customers)
                .HasForeignKey(d => d.MaritalStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_MaritalStatus");

            entity.HasOne(d => d.Occupation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.OccupationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Occupation");

            entity.HasOne(d => d.Title).WithMany(p => p.Customers)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Title");
        });

        modelBuilder.Entity<CustomerBankAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerBankAccount");

            entity.ToTable("CustomerBankAccount");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.BankAccount).WithMany(p => p.CustomerBankAccounts)
                .HasForeignKey(d => d.BankAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerBankAccount_BankAccount");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerBankAccounts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerBankAccount_Customer");
        });

        modelBuilder.Entity<CustomerBulk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerBulk");

            entity.ToTable("CustomerBulk");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.IsExists).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerCarrier>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.CarrierId }).HasName("PK_CustomerCarrier");

            entity.ToTable("CustomerCarrier");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Carrier).WithMany(p => p.CustomerCarriers)
                .HasForeignKey(d => d.CarrierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerCarrier_Carrier");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerCarriers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerCarrier_Customer");
        });

        modelBuilder.Entity<CustomerDocument>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.DocumentId }).HasName("PK_CustomerDocument_1");

            entity.ToTable("CustomerDocument");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerDocuments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerDocument_Customer");

            entity.HasOne(d => d.Document).WithMany(p => p.CustomerDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerDocument_Document");
        });

        modelBuilder.Entity<CustomerNumberGenerator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerNumberGenerator");

            entity.ToTable("CustomerNumberGenerator");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
        });

        modelBuilder.Entity<CustomerRisk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerRisk");

            entity.ToTable("CustomerRisk");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerRisks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerRisk_Customer");

            entity.HasOne(d => d.Risk).WithMany(p => p.CustomerRisks)
                .HasForeignKey(d => d.RiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerRisk_Risk");
        });

        modelBuilder.Entity<CustomerRiskDocument>(entity =>
        {
            entity.HasKey(e => new { e.CustomerRiskId, e.DocumentId }).HasName("PK_CustomerRiskDocument_1");

            entity.ToTable("CustomerRiskDocument");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.CustomerRisk).WithMany(p => p.CustomerRiskDocuments)
                .HasForeignKey(d => d.CustomerRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerRiskDocument_CustomerRisk");

            entity.HasOne(d => d.Document).WithMany(p => p.CustomerRiskDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerRiskDocument_Document");
        });

        modelBuilder.Entity<CustomerStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerStatus");

            entity.ToTable("CustomerStatus");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.IsVisible).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerType");

            entity.ToTable("CustomerType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Document");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.DocumentDate).HasColumnType("date");
            entity.Property(e => e.DocumentPath).IsUnicode(false);
            entity.Property(e => e.Extension).HasMaxLength(50);
            entity.Property(e => e.FileType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_DocumentType");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.ToTable("DocumentType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.ToTable("Driver");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LicenceDate).HasColumnType("date");
            entity.Property(e => e.LicenceIssuePlace).HasMaxLength(50);
            entity.Property(e => e.LicenceNumber).HasMaxLength(50);

            entity.HasOne(d => d.Gender).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Driver_Gender");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.MaritalStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Driver_MaritalStatus");

            entity.HasOne(d => d.Occupation).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.OccupationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Driver_Occupation");
        });

        modelBuilder.Entity<DriverType>(entity =>
        {
            entity.ToTable("DriverType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Eftfile>(entity =>
        {
            entity.ToTable("EFTFile");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DocumentPath).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.RunDate).HasColumnType("date");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.Eftfiles)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EFTFile_Portfolio");
        });

        modelBuilder.Entity<ElectronicEquipment>(entity =>
        {
            entity.ToTable("ElectronicEquipment");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.RiskItem).WithMany(p => p.ElectronicEquipments)
                .HasForeignKey(d => d.RiskItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElectronicEquipment_RiskItem");
        });

        modelBuilder.Entity<EmailAddress>(entity =>
        {
            entity.ToTable("EmailAddress");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.EmailAddresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerEmailAddress_Customer");
        });

        modelBuilder.Entity<ExcessBuyBack>(entity =>
        {
            entity.ToTable("ExcessBuyBack");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Motor).WithMany(p => p.ExcessBuyBacks)
                .HasForeignKey(d => d.MotorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExcessBuyBack_Motor");
        });

        modelBuilder.Entity<Extension>(entity =>
        {
            entity.ToTable("Extension");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<FileTemplate>(entity =>
        {
            entity.ToTable("FileTemplate");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Delimiter).HasMaxLength(1);
            entity.Property(e => e.FileType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Portfolio).WithMany(p => p.FileTemplates)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FileTemplate_Portfolio");
        });

        modelBuilder.Entity<FileTemplateRecord>(entity =>
        {
            entity.ToTable("FileTemplateRecord");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.FieldLabel).HasMaxLength(50);
            entity.Property(e => e.FieldName).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(5);
            entity.Property(e => e.TableLabel).HasMaxLength(50);
            entity.Property(e => e.TableName).HasMaxLength(50);

            entity.HasOne(d => d.FileTemplate).WithMany(p => p.FileTemplateRecords)
                .HasForeignKey(d => d.FileTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FileTemplateRecord_FileTemplate");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Glass>(entity =>
        {
            entity.ToTable("Glass");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.RiskItem).WithMany(p => p.Glasses)
                .HasForeignKey(d => d.RiskItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Glass_RiskItem");
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.ToTable("House");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ArmedResponseName).HasMaxLength(50);
            entity.Property(e => e.BondHolder).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.PhysicalAddress).HasMaxLength(150);
            entity.Property(e => e.ResidenceUseId).HasDefaultValueSql("(N'37AD8F61-A247-49F6-A7B8-A3ADE763BEC2')");
            entity.Property(e => e.UnoccupancyPeriod).HasMaxLength(50);

            entity.HasOne(d => d.HouseCondition).WithMany(p => p.Houses)
                .HasForeignKey(d => d.HouseConditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_House_HouseCondition");

            entity.HasOne(d => d.ResidenceType).WithMany(p => p.Houses)
                .HasForeignKey(d => d.ResidenceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_House_ResidenceType");

            entity.HasOne(d => d.ResidenceUse).WithMany(p => p.Houses)
                .HasForeignKey(d => d.ResidenceUseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_House_ResidenceUse");

            entity.HasOne(d => d.RoofType).WithMany(p => p.Houses)
                .HasForeignKey(d => d.RoofTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_House_RoofType");

            entity.HasOne(d => d.WallType).WithMany(p => p.Houses)
                .HasForeignKey(d => d.WallTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_House_WallType");
        });

        modelBuilder.Entity<HouseCondition>(entity =>
        {
            entity.ToTable("HouseCondition");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<IdDocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_IDDocumentType");

            entity.ToTable("IdDocumentType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.ToTable("Incident");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<IncidentAuditLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IncidentAuditLog");

            entity.Property(e => e.DmlTimestamp).HasColumnType("datetime");
            entity.Property(e => e.DmlType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TrxTimestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Insurer>(entity =>
        {
            entity.ToTable("Insurer");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<InsurerAuditLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("InsurerAuditLog");

            entity.Property(e => e.DmlCreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DmlTimestamp).HasColumnType("datetime");
            entity.Property(e => e.DmlType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NewRowData).HasMaxLength(1000);
            entity.Property(e => e.OldRowData).HasMaxLength(1000);
            entity.Property(e => e.TrxTimestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<InsurerBranch>(entity =>
        {
            entity.ToTable("InsurerBranch");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PhysicalAddress).HasMaxLength(100);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);

            entity.HasOne(d => d.City).WithMany(p => p.InsurerBranches)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsurerBranch_City");

            entity.HasOne(d => d.Insurer).WithMany(p => p.InsurerBranches)
                .HasForeignKey(d => d.InsurerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsurerBranch_Insurer");
        });

        modelBuilder.Entity<InterMediate>(entity =>
        {
            entity.ToTable("InterMediate");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Flag).HasDefaultValueSql("((0))");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoice", tb => tb.HasTrigger("Tr_Invoice_Number"));

            entity.HasIndex(e => e.InvoiceNumber, "IX_Invoice").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.InvoiceDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReducingBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.InvoiceStatus).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.InvoiceStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_InvoiceStatus");

            entity.HasOne(d => d.Policy).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Policy");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.ToTable("InvoiceItem");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceItem_Invoice");

            entity.HasOne(d => d.PolicyRisk).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.PolicyRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceItem_PolicyRisk");
        });

        modelBuilder.Entity<InvoiceNumberGenerator>(entity =>
        {
            entity.ToTable("InvoiceNumberGenerator");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
        });

        modelBuilder.Entity<InvoiceStatus>(entity =>
        {
            entity.ToTable("InvoiceStatus");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.ToTable("JobTitle");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Life>(entity =>
        {
            entity.ToTable("Life");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.RiskItem).WithMany(p => p.Lives)
                .HasForeignKey(d => d.RiskItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Life_RiskItem");
        });

        modelBuilder.Entity<LossAdjuster>(entity =>
        {
            entity.ToTable("LossAdjuster");

            entity.HasIndex(e => e.IdNumber, "IX_LossAdjuster").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<LossAdjusterAuthority>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LossAdjusterAuthority");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AuthorisedDate).HasColumnType("date");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.InstructionDate).HasColumnType("date");
            entity.Property(e => e.IssuedDate).HasColumnType("date");
            entity.Property(e => e.Reference).HasMaxLength(50);
        });

        modelBuilder.Entity<LossAdjusterInstruction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LossAdjusterInstruction");

            entity.Property(e => e.AdditionalExcess).HasMaxLength(50);
            entity.Property(e => e.AuthorisedDate).HasColumnType("date");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Excess).HasMaxLength(50);
            entity.Property(e => e.InstructionDate).HasColumnType("date");
            entity.Property(e => e.IssueDate).HasColumnType("date");
        });

        modelBuilder.Entity<MaritalStatus>(entity =>
        {
            entity.ToTable("MaritalStatus");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MobileNumber>(entity =>
        {
            entity.ToTable("MobileNumber");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.MobileNumbers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerMobileNumber_Customer");
        });

        modelBuilder.Entity<Motor>(entity =>
        {
            entity.ToTable("Motor");

            entity.HasIndex(e => e.ChassisNumber, "IX_Motor_Chassis").IsUnique();

            entity.HasIndex(e => e.EngineNumber, "IX_Motor_Engine").IsUnique();

            entity.HasIndex(e => e.RegNumber, "IX_Motor_RegNumber").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ChassisNumber).HasMaxLength(50);
            entity.Property(e => e.Colour).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.EngineCapacity).HasMaxLength(50);
            entity.Property(e => e.EngineNumber).HasMaxLength(50);
            entity.Property(e => e.OtherParked).HasMaxLength(50);
            entity.Property(e => e.RegNumber).HasMaxLength(50);
            entity.Property(e => e.RegisteredOwner).HasMaxLength(50);
            entity.Property(e => e.TrackingDevice).HasMaxLength(50);

            entity.HasOne(d => d.BodyType).WithMany(p => p.Motors)
                .HasForeignKey(d => d.BodyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Motor_BodyType");

            entity.HasOne(d => d.DriverType).WithMany(p => p.Motors)
                .HasForeignKey(d => d.DriverTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Motor_DriverType");

            entity.HasOne(d => d.MotorModel).WithMany(p => p.Motors)
                .HasForeignKey(d => d.MotorModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Motor_MotorModel");
        });

        modelBuilder.Entity<MotorAccessory>(entity =>
        {
            entity.ToTable("MotorAccessory");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.PurchaseValue).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Motor).WithMany(p => p.MotorAccessories)
                .HasForeignKey(d => d.MotorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MotorAccessory_Motor");
        });

        modelBuilder.Entity<MotorCycle>(entity =>
        {
            entity.ToTable("MotorCycle");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.FinancialInterest).HasMaxLength(50);
            entity.Property(e => e.Make).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.RegistrationNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<MotorCycleType>(entity =>
        {
            entity.ToTable("MotorCycleType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MotorDriver>(entity =>
        {
            entity.HasKey(e => new { e.MotorId, e.DriverId });

            entity.ToTable("MotorDriver");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Driver).WithMany(p => p.MotorDrivers)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MotorDriver_Driver");

            entity.HasOne(d => d.Motor).WithMany(p => p.MotorDrivers)
                .HasForeignKey(d => d.MotorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MotorDriver_Motor");
        });

        modelBuilder.Entity<MotorImprovement>(entity =>
        {
            entity.ToTable("MotorImprovement");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.MakeModel).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PurchaseDate).HasColumnType("date");
            entity.Property(e => e.SerialNumber).HasMaxLength(50);
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Motor).WithMany(p => p.MotorImprovements)
                .HasForeignKey(d => d.MotorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MotorImprovement_Motor");
        });

        modelBuilder.Entity<MotorMake>(entity =>
        {
            entity.ToTable("MotorMake");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MotorModel>(entity =>
        {
            entity.ToTable("MotorModel");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.MotorMake).WithMany(p => p.MotorModels)
                .HasForeignKey(d => d.MotorMakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MotorModel_MotorMake");
        });

        modelBuilder.Entity<MotorRadio>(entity =>
        {
            entity.ToTable("MotorRadio");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Make).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.PurchaseValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SerialNumber).HasMaxLength(50);

            entity.HasOne(d => d.Motor).WithMany(p => p.MotorRadios)
                .HasForeignKey(d => d.MotorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MotorRadio_Motor");
        });

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.ToTable("Occupation");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Payable>(entity =>
        {
            entity.ToTable("Payable");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.BatchNumber).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.PayableDate).HasColumnType("date");
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.VoidReason).HasMaxLength(50);

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Payables)
                .HasForeignKey(d => d.PaymentTypeId)
                .HasConstraintName("FK_Payable_PaymentType");
        });

        modelBuilder.Entity<PayableRequisition>(entity =>
        {
            entity.HasKey(e => new { e.RequisitionId, e.PayableId });

            entity.ToTable("PayableRequisition");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Payable).WithMany(p => p.PayableRequisitions)
                .HasForeignKey(d => d.PayableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PayableRequisition_Payable");

            entity.HasOne(d => d.Requisition).WithMany(p => p.PayableRequisitions)
                .HasForeignKey(d => d.RequisitionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PayableRequisition_Requisition");
        });

        modelBuilder.Entity<Payee>(entity =>
        {
            entity.ToTable("Payee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.PayeeType).WithMany(p => p.Payees)
                .HasForeignKey(d => d.PayeeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payee_PayeeType");
        });

        modelBuilder.Entity<PayeeBankAccount>(entity =>
        {
            entity.HasKey(e => new { e.PayeeId, e.BankAccountId });

            entity.ToTable("PayeeBankAccount");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.BankAccount).WithMany(p => p.PayeeBankAccounts)
                .HasForeignKey(d => d.BankAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PayeeBankAccount_BankAccount");

            entity.HasOne(d => d.Payee).WithMany(p => p.PayeeBankAccounts)
                .HasForeignKey(d => d.PayeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PayeeBankAccount_Payee");
        });

        modelBuilder.Entity<PayeeType>(entity =>
        {
            entity.ToTable("PayeeType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PaymentMethod");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("PaymentType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.ToTable("Policy", tb => tb.HasTrigger("Tr_Policy_Number"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Comment).HasMaxLength(100);
            entity.Property(e => e.CoverEndDate).HasColumnType("date");
            entity.Property(e => e.CoverStartDate).HasColumnType("date");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.InceptionDate).HasColumnType("date");
            entity.Property(e => e.InsurerPolicyNumber).HasMaxLength(50);

            entity.HasOne(d => d.CustomerBankAccount).WithMany(p => p.Policies)
                .HasForeignKey(d => d.CustomerBankAccountId)
                .HasConstraintName("FK_Policy_CustomerBankAccount");

            entity.HasOne(d => d.InsurerBranch).WithMany(p => p.Policies)
                .HasForeignKey(d => d.InsurerBranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policy_InsurerBranch");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Policies)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policy_PaymentMethod");

            entity.HasOne(d => d.PolicyStatus).WithMany(p => p.Policies)
                .HasForeignKey(d => d.PolicyStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policy_PolicyStatus");

            entity.HasOne(d => d.PolicyType).WithMany(p => p.Policies)
                .HasForeignKey(d => d.PolicyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policy_PolicyType");

            entity.HasOne(d => d.PortfolioCustomer).WithMany(p => p.Policies)
                .HasForeignKey(d => d.PortfolioCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policy_PortfolioCustomer");

            entity.HasOne(d => d.SalesType).WithMany(p => p.Policies)
                .HasForeignKey(d => d.SalesTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policy_SalesType");
        });

        modelBuilder.Entity<PolicyBulk>(entity =>
        {
            entity.ToTable("PolicyBulk");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<PolicyNumberGenerator>(entity =>
        {
            entity.ToTable("PolicyNumberGenerator");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
        });

        modelBuilder.Entity<PolicyRenewal>(entity =>
        {
            entity.ToTable("PolicyRenewal");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.RenewalDateDue).HasColumnType("date");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyRenewals)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyRenewal_Policy");
        });

        modelBuilder.Entity<PolicyRisk>(entity =>
        {
            entity.ToTable("PolicyRisk");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DeactivateDate).HasColumnType("date");
            entity.Property(e => e.Excess).HasMaxLength(50);
            entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RiskDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.SumInsured).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CoverType).WithMany(p => p.PolicyRisks)
                .HasForeignKey(d => d.CoverTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyRisk_CoverType");

            entity.HasOne(d => d.CustomerRisk).WithMany(p => p.PolicyRisks)
                .HasForeignKey(d => d.CustomerRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyRisk_CustomerRisk");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyRisks)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyRisk_Policy");
        });

        modelBuilder.Entity<PolicyRiskClaim>(entity =>
        {
            entity.HasKey(e => new { e.PolicyRiskId, e.ClaimNumber });

            entity.ToTable("PolicyRiskClaim");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.PolicyRisk).WithMany(p => p.PolicyRiskClaims)
                .HasForeignKey(d => d.PolicyRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyRiskClaim_PolicyRisk");
        });

        modelBuilder.Entity<PolicyRiskExtension>(entity =>
        {
            entity.HasKey(e => new { e.PolicyRiskId, e.ExtensionId });

            entity.ToTable("PolicyRiskExtension");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Extension).WithMany(p => p.PolicyRiskExtensions)
                .HasForeignKey(d => d.ExtensionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyRiskExtension_Extension");

            entity.HasOne(d => d.PolicyRisk).WithMany(p => p.PolicyRiskExtensions)
                .HasForeignKey(d => d.PolicyRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyRiskExtension_PolicyRisk");
        });

        modelBuilder.Entity<PolicyStatus>(entity =>
        {
            entity.ToTable("PolicyStatus");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PolicyType>(entity =>
        {
            entity.ToTable("PolicyType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.ToTable("Portfolio");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PortfolioAdministrationFee>(entity =>
        {
            entity.ToTable("PortfolioAdministrationFee");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Fee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Insurer).WithMany(p => p.PortfolioAdministrationFees)
                .HasForeignKey(d => d.InsurerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioAdministrationFee_Insurer");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioAdministrationFees)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioAdministrationFee_Portfolio");
        });

        modelBuilder.Entity<PortfolioCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PortfolioCustomer");

            entity.ToTable("PortfolioCustomer");

            entity.HasIndex(e => new { e.PortfolioId, e.CustomerId }, "IX_PortfolioCustomer").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.PortfolioCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioCustomer_Customer");

            entity.HasOne(d => d.CustomerStatus).WithMany(p => p.PortfolioCustomers)
                .HasForeignKey(d => d.CustomerStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioCustomer_CustomerStatus");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioCustomers)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioCustomer_Portfolio");
        });

        modelBuilder.Entity<PortfolioExcessBuyBack>(entity =>
        {
            entity.ToTable("PortfolioExcessBuyBack");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BuyBackRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ExcessRate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Insurer).WithMany(p => p.PortfolioExcessBuyBacks)
                .HasForeignKey(d => d.InsurerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioExcessBuyBack_Insurer");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioExcessBuyBacks)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioExcessBuyBack_Portfolio");
        });

        modelBuilder.Entity<PortfolioPolicyFee>(entity =>
        {
            entity.ToTable("PortfolioPolicyFee");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Fee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Insurer).WithMany(p => p.PortfolioPolicyFees)
                .HasForeignKey(d => d.InsurerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioPolicyFee_Insurer");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioPolicyFees)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioPolicyFee_Portfolio");
        });

        modelBuilder.Entity<PortfolioRatingMotor>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.RatingMotorId });

            entity.ToTable("PortfolioRatingMotor");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioRatingMotors)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioRatingMotor_Portfolio");

            entity.HasOne(d => d.RatingMotor).WithMany(p => p.PortfolioRatingMotors)
                .HasForeignKey(d => d.RatingMotorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioRatingMotor_RatingMotor");
        });

        modelBuilder.Entity<PortfolioRatingMotorDiscount>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.RatingMotorDiscountId });

            entity.ToTable("PortfolioRatingMotorDiscount");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioRatingMotorDiscounts)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioRatingMotorDiscount_Portfolio");

            entity.HasOne(d => d.RatingMotorDiscount).WithMany(p => p.PortfolioRatingMotorDiscounts)
                .HasForeignKey(d => d.RatingMotorDiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioRatingMotorDiscount_RatingMotorDiscount");
        });

        modelBuilder.Entity<PortfolioRatingMotorExcess>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.RatingMotorExcessId });

            entity.ToTable("PortfolioRatingMotorExcess");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioRatingMotorExcesses)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioRatingMotorExcess_Portfolio");

            entity.HasOne(d => d.RatingMotorExcess).WithMany(p => p.PortfolioRatingMotorExcesses)
                .HasForeignKey(d => d.RatingMotorExcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioRatingMotorExcess_RatingMotorExcess");
        });

        modelBuilder.Entity<PortfolioRatingMotorPremium>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.RatingMotorPremiumId });

            entity.ToTable("PortfolioRatingMotorPremium");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioRatingMotorPremia)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioRatingMotorPremium_Portfolio");

            entity.HasOne(d => d.RatingMotorPremium).WithMany(p => p.PortfolioRatingMotorPremia)
                .HasForeignKey(d => d.RatingMotorPremiumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioRatingMotorPremium_RatingMotorPremium");
        });

        modelBuilder.Entity<Premium>(entity =>
        {
            entity.ToTable("Premium");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AdministrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Commission).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CommissionTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Motor).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MotorCommission).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NonMotor).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NonMotorCommission).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PolicyFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PremiumDate).HasColumnType("date");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Policy).WithMany(p => p.Premia)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Premium_Policy");
        });

        modelBuilder.Entity<PremiumBulk>(entity =>
        {
            entity.ToTable("PremiumBulk");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<PremiumInstallment>(entity =>
        {
            entity.ToTable("PremiumInstallment");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.InstallmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.Policy).WithMany(p => p.PremiumInstallments)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PremiumInstallment_Policy");
        });

        modelBuilder.Entity<PremiumRefund>(entity =>
        {
            entity.ToTable("PremiumRefund");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.ReferenceDate).HasColumnType("date");

            entity.HasOne(d => d.PolicyRisk).WithMany(p => p.PremiumRefunds)
                .HasForeignKey(d => d.PolicyRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PremiumRefund_PolicyRisk");

            entity.HasOne(d => d.RefundStatus).WithMany(p => p.PremiumRefunds)
                .HasForeignKey(d => d.RefundStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PremiumRefund_RefundStatus");
        });

        modelBuilder.Entity<PremiumRefundClaim>(entity =>
        {
            entity.HasKey(e => new { e.PremiumRefundId, e.ClaimNumber });

            entity.ToTable("PremiumRefundClaim");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.PremiumRefund).WithMany(p => p.PremiumRefundClaims)
                .HasForeignKey(d => d.PremiumRefundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PremiumRefundClaim_PremiumRefund");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PublicLiability>(entity =>
        {
            entity.ToTable("PublicLiability");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.RiskItem).WithMany(p => p.PublicLiabilities)
                .HasForeignKey(d => d.RiskItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PublicLiability_RiskItem");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.ToTable("Quote", tb => tb.HasTrigger("Tr_Quote_Number"));

            entity.HasIndex(e => e.QuoteNumber, "IX_Quote").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CustomerInfo).HasMaxLength(150);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.InternalInfo).HasMaxLength(150);
            entity.Property(e => e.Prorata).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.QuoteDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.CustomerBankAccount).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.CustomerBankAccountId)
                .HasConstraintName("FK_Quote_CustomerBankAccount");

            entity.HasOne(d => d.InsurerBranch).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.InsurerBranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Quote_InsurerBranch");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK_Quote_PaymentMethod");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.PaymentTypeId)
                .HasConstraintName("FK_Quote_PaymentType");

            entity.HasOne(d => d.PolicyType).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.PolicyTypeId)
                .HasConstraintName("FK_Quote_PolicyType");

            entity.HasOne(d => d.PortfolioCustomer).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.PortfolioCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Quote_PortfolioCustomer");

            entity.HasOne(d => d.QuoteStatus).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.QuoteStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Quote_QuoteStatus");
        });

        modelBuilder.Entity<QuoteItem>(entity =>
        {
            entity.ToTable("QuoteItem");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Excess).HasMaxLength(50);
            entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SumInsured).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CustomerRisk).WithMany(p => p.QuoteItems)
                .HasForeignKey(d => d.CustomerRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuoteItem_CustomerRisk");

            entity.HasOne(d => d.CoverType).WithMany(p => p.QuoteItems)
                .HasForeignKey(d => d.CoverTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuoteItem_CoverType");

            entity.HasOne(d => d.Quote).WithMany(p => p.QuoteItems)
                .HasForeignKey(d => d.QuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuoteItem_Quote");
        });

        modelBuilder.Entity<QuoteNumberGenerator>(entity =>
        {
            entity.ToTable("QuoteNumberGenerator");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
        });

        modelBuilder.Entity<QuoteStatus>(entity =>
        {
            entity.ToTable("QuoteStatus");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RatingMotor>(entity =>
        {
            entity.ToTable("RatingMotor");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.EndValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RateImport).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RateLocal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StartValue).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Insurer).WithMany(p => p.RatingMotors)
                .HasForeignKey(d => d.InsurerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RatingMotor_Insurer");
        });

        modelBuilder.Entity<RatingMotorDiscount>(entity =>
        {
            entity.ToTable("RatingMotorDiscount");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Insurer).WithMany(p => p.RatingMotorDiscounts)
                .HasForeignKey(d => d.InsurerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RatingMotorDiscount_Insurer");
        });

        modelBuilder.Entity<RatingMotorExcess>(entity =>
        {
            entity.ToTable("RatingMotorExcess");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.EndValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RateImport)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.RateLocal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.StartValue).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Insurer).WithMany(p => p.RatingMotorExcesses)
                .HasForeignKey(d => d.InsurerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RatingMotorExcess_Insurer");
        });

        modelBuilder.Entity<RatingMotorPremium>(entity =>
        {
            entity.ToTable("RatingMotorPremium");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.MinimumAnnual).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinimumAnnualThirdParty).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinimumMonthly).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Insurer).WithMany(p => p.RatingMotorPremia)
                .HasForeignKey(d => d.InsurerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RatingMotorPremium_Insurer");
        });

        modelBuilder.Entity<Receivable>(entity =>
        {
            entity.ToTable("Receivable");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BatchNumber).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ReceivableDate).HasColumnType("date");
            entity.Property(e => e.Reference).HasMaxLength(50);

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Receivables)
                .HasForeignKey(d => d.PaymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receivable_PaymentType");
        });

        modelBuilder.Entity<ReceivableDocument>(entity =>
        {
            entity.HasKey(e => new { e.ReceivableId, e.DocumentId }).HasName("PK_ReceivableDocument_1");

            entity.ToTable("ReceivableDocument");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Document).WithMany(p => p.ReceivableDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivableDocument_Document");

            entity.HasOne(d => d.Receivable).WithMany(p => p.ReceivableDocuments)
                .HasForeignKey(d => d.ReceivableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivableDocument_Receivable");
        });

        modelBuilder.Entity<ReceivableInvoice>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.ReceivableId });

            entity.ToTable("ReceivableInvoice");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ReceivableInvoices)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivableInvoice_Invoice");

            entity.HasOne(d => d.Receivable).WithMany(p => p.ReceivableInvoices)
                .HasForeignKey(d => d.ReceivableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivableInvoice_Receivable");
        });

        modelBuilder.Entity<ReceivableQuote>(entity =>
        {
            entity.HasKey(e => new { e.QuoteId, e.ReceivableId });

            entity.ToTable("ReceivableQuote");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Quote).WithMany(p => p.ReceivableQuotes)
                .HasForeignKey(d => d.QuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivableQuote_Quote");

            entity.HasOne(d => d.Receivable).WithMany(p => p.ReceivableQuotes)
                .HasForeignKey(d => d.ReceivableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivableQuote_Receivable");
        });

        modelBuilder.Entity<Reconcilliation>(entity =>
        {
            entity.ToTable("Reconcilliation");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Reconcilliations)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reconcilliation_Invoice");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Reconcilliations)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reconcilliation_PaymentMethod");
        });

        modelBuilder.Entity<RefundStatus>(entity =>
        {
            entity.ToTable("RefundStatus");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("Region");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RelationType>(entity =>
        {
            entity.ToTable("RelationType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Repairer>(entity =>
        {
            entity.ToTable("Repairer");

            entity.HasIndex(e => e.IdNumber, "IX_Repairer").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Requisition>(entity =>
        {
            entity.ToTable("Requisition", tb => tb.HasTrigger("Tr_Requisition_Number"));

            entity.HasIndex(e => e.RequisitionNumber, "IX_Requisition").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AuthorisedDate).HasColumnType("date");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.InvoiceDate).HasColumnType("date");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.NewEstimateOd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NewEstimateOD");
            entity.Property(e => e.NewEstimateTp)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NewEstimateTP");
            entity.Property(e => e.RequisitionDate).HasColumnType("date");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxableAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ChartOfAccounts).WithMany(p => p.Requisitions)
                .HasForeignKey(d => d.ChartOfAccountsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requisition_ChartOfAccounts");
        });

        modelBuilder.Entity<RequisitionNumberGenerator>(entity =>
        {
            entity.ToTable("RequisitionNumberGenerator");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
        });

        modelBuilder.Entity<ResidenceType>(entity =>
        {
            entity.ToTable("ResidenceType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ResidenceUse>(entity =>
        {
            entity.ToTable("ResidenceUse");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Risk>(entity =>
        {
            entity.ToTable("Risk");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.AllRisk).WithMany(p => p.Risks)
                .HasForeignKey(d => d.AllRiskId)
                .HasConstraintName("FK_Risk_AllRisk");

            entity.HasOne(d => d.AllRiskSpecified).WithMany(p => p.Risks)
                .HasForeignKey(d => d.AllRiskSpecifiedId)
                .HasConstraintName("FK_Risk_AllRiskSpecified");

            entity.HasOne(d => d.Building).WithMany(p => p.Risks)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK_Risk_Building");

            entity.HasOne(d => d.Content).WithMany(p => p.Risks)
                .HasForeignKey(d => d.ContentId)
                .HasConstraintName("FK_Risk_Content");

            entity.HasOne(d => d.ElectronicEquipment).WithMany(p => p.Risks)
                .HasForeignKey(d => d.ElectronicEquipmentId)
                .HasConstraintName("FK_Risk_ElectronicEquipment");

            entity.HasOne(d => d.ExcessBuyBack).WithMany(p => p.Risks)
                .HasForeignKey(d => d.ExcessBuyBackId)
                .HasConstraintName("FK_Risk_ExcessBuyBack");

            entity.HasOne(d => d.Glass).WithMany(p => p.Risks)
                .HasForeignKey(d => d.GlassId)
                .HasConstraintName("FK_Risk_Glass");

            entity.HasOne(d => d.House).WithMany(p => p.Risks)
                .HasForeignKey(d => d.HouseId)
                .HasConstraintName("FK_Risk_House");

            entity.HasOne(d => d.Life).WithMany(p => p.Risks)
                .HasForeignKey(d => d.LifeId)
                .HasConstraintName("FK_Risk_Life");

            entity.HasOne(d => d.MotorCycle).WithMany(p => p.Risks)
                .HasForeignKey(d => d.MotorCycleId)
                .HasConstraintName("FK_Risk_MotorCycle");

            entity.HasOne(d => d.Motor).WithMany(p => p.Risks)
                .HasForeignKey(d => d.MotorId)
                .HasConstraintName("FK_Risk_Motor");

            entity.HasOne(d => d.PublicLiability).WithMany(p => p.Risks)
                .HasForeignKey(d => d.PublicLiabilityId)
                .HasConstraintName("FK_Risk_PublicLiability");

            entity.HasOne(d => d.StatedBenefit).WithMany(p => p.Risks)
                .HasForeignKey(d => d.StatedBenefitId)
                .HasConstraintName("FK_Risk_StatedBenefit");

            entity.HasOne(d => d.Trailer).WithMany(p => p.Risks)
                .HasForeignKey(d => d.TrailerId)
                .HasConstraintName("FK_Risk_Trailer");

            entity.HasOne(d => d.Travel).WithMany(p => p.Risks)
                .HasForeignKey(d => d.TravelId)
                .HasConstraintName("FK_Risk_Travel");

            entity.HasOne(d => d.WorkmanCompensation).WithMany(p => p.Risks)
                .HasForeignKey(d => d.WorkmanCompensationId)
                .HasConstraintName("FK_Risk_WorkmanCompensation");
        });

        modelBuilder.Entity<RiskItem>(entity =>
        {
            entity.ToTable("RiskItem");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<RoadsideAssist>(entity =>
        {
            entity.ToTable("RoadsideAssist");

            entity.HasIndex(e => e.IdNumber, "IX_RoadsideAssist").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<RoofType>(entity =>
        {
            entity.ToTable("RoofType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SalesType>(entity =>
        {
            entity.ToTable("SalesType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StatedBenefit>(entity =>
        {
            entity.ToTable("StatedBenefit");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.RiskItem).WithMany(p => p.StatedBenefits)
                .HasForeignKey(d => d.RiskItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatedBenefit_RiskItem");
        });

        modelBuilder.Entity<Tax>(entity =>
        {
            entity.ToTable("Tax");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TaxDate).HasColumnType("date");
            entity.Property(e => e.TaxRate).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ThirdParty>(entity =>
        {
            entity.ToTable("ThirdParty");

            entity.HasIndex(e => e.IdNumber, "IX_ThirdParty").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.ToTable("Title");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TowTruck>(entity =>
        {
            entity.ToTable("TowTruck");

            entity.HasIndex(e => e.IdNumber, "IX_TowTruck").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TracingAgent>(entity =>
        {
            entity.ToTable("TracingAgent");

            entity.HasIndex(e => e.IdNumber, "IX_TracingAgent").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Trailer>(entity =>
        {
            entity.ToTable("Trailer");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Make).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.RegNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Travel>(entity =>
        {
            entity.ToTable("Travel");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Beneficiary).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DepartureDate).HasColumnType("date");
            entity.Property(e => e.Destination).HasMaxLength(100);
            entity.Property(e => e.DoctorName).HasMaxLength(50);
            entity.Property(e => e.DoctorPhone).HasMaxLength(50);
            entity.Property(e => e.PassportNumber).HasMaxLength(50);
            entity.Property(e => e.PersonVisited).HasMaxLength(50);
            entity.Property(e => e.ReturnDate).HasColumnType("date");

            entity.HasOne(d => d.PortfolioCustomer).WithMany(p => p.Travels)
                .HasForeignKey(d => d.PortfolioCustomerId)
                .HasConstraintName("FK_Travel_PortfolioCustomer");
        });

        modelBuilder.Entity<TravelMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TravelBeneficiary");

            entity.ToTable("TravelMember");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PassportNumber).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.TravelMembers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TravelMember_Country");

            entity.HasOne(d => d.Travel).WithMany(p => p.TravelMembers)
                .HasForeignKey(d => d.TravelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TravelMember_Travel");
        });

        modelBuilder.Entity<ValuationFeeRefund>(entity =>
        {
            entity.ToTable("ValuationFeeRefund");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.ReferenceDate).HasColumnType("date");

            entity.HasOne(d => d.PolicyRisk).WithMany(p => p.ValuationFeeRefunds)
                .HasForeignKey(d => d.PolicyRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ValuationFeeRefund_PolicyRisk");

            entity.HasOne(d => d.RefundStatus).WithMany(p => p.ValuationFeeRefunds)
                .HasForeignKey(d => d.RefundStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ValuationFeeRefund_RefundStatus");
        });

        modelBuilder.Entity<ValuationFeeRefundClaim>(entity =>
        {
            entity.HasKey(e => new { e.ValuationFeeRefundId, e.ClaimNumber });

            entity.ToTable("ValuationFeeRefundClaim");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.ValuationFeeRefund).WithMany(p => p.ValuationFeeRefundClaims)
                .HasForeignKey(d => d.ValuationFeeRefundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ValuationFeeRefundClaim_ValuationFeeRefund");
        });

        modelBuilder.Entity<WallType>(entity =>
        {
            entity.ToTable("WallType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Withdrawal>(entity =>
        {
            entity.ToTable("Withdrawal");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.ReferenceDate).HasColumnType("date");
            entity.Property(e => e.WithdrawalDate).HasColumnType("date");

            entity.HasOne(d => d.PortfolioCustomer).WithMany(p => p.Withdrawals)
                .HasForeignKey(d => d.PortfolioCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Withdrawal_PortfolioCustomer");
        });

        modelBuilder.Entity<WorkmanCompensation>(entity =>
        {
            entity.ToTable("WorkmanCompensation");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.RiskItem).WithMany(p => p.WorkmanCompensations)
                .HasForeignKey(d => d.RiskItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkmanCompensation_RiskItem");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
