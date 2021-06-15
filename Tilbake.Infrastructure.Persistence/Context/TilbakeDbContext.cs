﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tilbake.Domain.Models;

#nullable disable

namespace Tilbake.Infrastructure.Persistence.Context
{
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
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<AspnetUserScheme> AspnetUserSchemes { get; set; }
        public virtual DbSet<Attorney> Attorneys { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<BankAuditLog> BankAuditLogs { get; set; }
        public virtual DbSet<BankBranch> BankBranches { get; set; }
        public virtual DbSet<Beneficiary> Beneficiaries { get; set; }
        public virtual DbSet<BodyType> BodyTypes { get; set; }
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
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientBankAccount> ClientBankAccounts { get; set; }
        public virtual DbSet<ClientDocument> ClientDocuments { get; set; }
        public virtual DbSet<ClientNumberGenerator> ClientNumberGenerators { get; set; }
        public virtual DbSet<ClientRisk> ClientRisks { get; set; }
        public virtual DbSet<ClientType> ClientTypes { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CoverType> CoverTypes { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverType> DriverTypes { get; set; }
        public virtual DbSet<ElectronicEquipment> ElectronicEquipments { get; set; }
        public virtual DbSet<Extension> Extensions { get; set; }
        public virtual DbSet<FileTemplate> FileTemplates { get; set; }
        public virtual DbSet<FileTemplateRecord> FileTemplateRecords { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Glass> Glasses { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<IncidentAuditLog> IncidentAuditLogs { get; set; }
        public virtual DbSet<Insurer> Insurers { get; set; }
        public virtual DbSet<InsurerAuditLog> InsurerAuditLogs { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<InvoiceNumberGenerator> InvoiceNumberGenerators { get; set; }
        public virtual DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<LossAdjuster> LossAdjusters { get; set; }
        public virtual DbSet<LossAdjusterAuthority> LossAdjusterAuthorities { get; set; }
        public virtual DbSet<LossAdjusterInstruction> LossAdjusterInstructions { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<Motor> Motors { get; set; }
        public virtual DbSet<MotorCycleType> MotorCycleTypes { get; set; }
        public virtual DbSet<MotorImprovement> MotorImprovements { get; set; }
        public virtual DbSet<MotorMake> MotorMakes { get; set; }
        public virtual DbSet<MotorModel> MotorModels { get; set; }
        public virtual DbSet<MotorUse> MotorUses { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<Payable> Payables { get; set; }
        public virtual DbSet<PayableRequisition> PayableRequisitions { get; set; }
        public virtual DbSet<Payee> Payees { get; set; }
        public virtual DbSet<PayeeBankAccount> PayeeBankAccounts { get; set; }
        public virtual DbSet<PayeeType> PayeeTypes { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyNumberGenerator> PolicyNumberGenerators { get; set; }
        public virtual DbSet<PolicyRenewal> PolicyRenewals { get; set; }
        public virtual DbSet<PolicyRisk> PolicyRisks { get; set; }
        public virtual DbSet<PolicyRiskClaim> PolicyRiskClaims { get; set; }
        public virtual DbSet<PolicyRiskExtension> PolicyRiskExtensions { get; set; }
        public virtual DbSet<PolicyStatus> PolicyStatuses { get; set; }
        public virtual DbSet<PolicyType> PolicyTypes { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<PortfolioClient> PortfolioClients { get; set; }
        public virtual DbSet<Premium> Premia { get; set; }
        public virtual DbSet<PremiumRefund> PremiumRefunds { get; set; }
        public virtual DbSet<PremiumRefundClaim> PremiumRefundClaims { get; set; }
        public virtual DbSet<PremiumType> PremiumTypes { get; set; }
        public virtual DbSet<PublicLiability> PublicLiabilities { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<QuoteItem> QuoteItems { get; set; }
        public virtual DbSet<QuoteNumberGenerator> QuoteNumberGenerators { get; set; }
        public virtual DbSet<QuoteStatus> QuoteStatuses { get; set; }
        public virtual DbSet<Receivable> Receivables { get; set; }
        public virtual DbSet<ReceivableInvoice> ReceivableInvoices { get; set; }
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
        public virtual DbSet<Scheme> Schemes { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<ThirdParty> ThirdParties { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<TowTruck> TowTrucks { get; set; }
        public virtual DbSet<TracingAgent> TracingAgents { get; set; }
        public virtual DbSet<ValuationFeeRefund> ValuationFeeRefunds { get; set; }
        public virtual DbSet<ValuationFeeRefundClaim> ValuationFeeRefundClaims { get; set; }
        public virtual DbSet<WallType> WallTypes { get; set; }
        public virtual DbSet<Withdrawal> Withdrawals { get; set; }

/*         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Database=tilbake;User Id=tilbake;Password=Nt7H1wK3X5!~;");
            }
        } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.PhysicalAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PostalAddress).HasMaxLength(50);
            });

            modelBuilder.Entity<AllRisk>(entity =>
            {
                entity.ToTable("AllRisk");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.RiskItem)
                    .WithMany(p => p.AllRisks)
                    .HasForeignKey(d => d.RiskItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllRisk_RiskItem");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IdNumber).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ManNumber).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProviderKey)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<AspnetUserScheme>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AspnetUserScheme");

                entity.Property(e => e.AspNetUserId)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<Attorney>(entity =>
            {
                entity.ToTable("Attorney");

                entity.HasIndex(e => e.IdNumber, "IX_Attorney")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("BankAccount");

                entity.HasIndex(e => e.AccountNumber, "IX_BankAccount")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.BankBranch)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.BankBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankAccount_BankBranch");
            });

            modelBuilder.Entity<BankAuditLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BankAuditLog");

                entity.Property(e => e.DmlCreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DmlTimestamp).HasColumnType("datetime");

                entity.Property(e => e.DmlType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NewRowData).HasMaxLength(1000);

                entity.Property(e => e.OldRowData).HasMaxLength(1000);

                entity.Property(e => e.TrxTimestamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<BankBranch>(entity =>
            {
                entity.ToTable("BankBranch");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SortCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SwiftCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.BankBranches)
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

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.ToTable("BodyType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.ToTable("Carrier");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ChartOfAccount>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Glcode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("GLCode");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasKey(e => e.ClaimNumber);

                entity.ToTable("Claim");

                entity.Property(e => e.ClaimNumber).ValueGeneratedNever();

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

                entity.HasOne(d => d.ClaimStatus)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.ClaimStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Claim_ClaimStatus");

                entity.HasOne(d => d.Claimant)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.ClaimantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Claim_Claimant");

                entity.HasOne(d => d.Incident)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.IncidentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Claim_Incident");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Claims)
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

                entity.HasOne(d => d.Attorney)
                    .WithMany(p => p.ClaimAttorneys)
                    .HasForeignKey(d => d.AttorneyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimAttorney_Attorney");

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.ClaimAttorneys)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimAttorney_Claim");
            });

            modelBuilder.Entity<ClaimDocument>(entity =>
            {
                entity.ToTable("ClaimDocument");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DocumentDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.ClaimDocuments)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimDocument_Claim");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ClaimDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimDocument_DocumentType");
            });

            modelBuilder.Entity<ClaimLossAdjuster>(entity =>
            {
                entity.HasKey(e => new { e.ClaimNumber, e.LossAdjusterId });

                entity.ToTable("ClaimLossAdjuster");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.ClaimLossAdjusters)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimLossAdjuster_Claim");

                entity.HasOne(d => d.LossAdjuster)
                    .WithMany(p => p.ClaimLossAdjusters)
                    .HasForeignKey(d => d.LossAdjusterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimLossAdjuster_LossAdjuster");
            });

            modelBuilder.Entity<ClaimNumberGenerator>(entity =>
            {
                entity.HasKey(e => e.ClaimNumber);

                entity.ToTable("ClaimNumberGenerator");

                entity.Property(e => e.ClaimNumber).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<ClaimRepairer>(entity =>
            {
                entity.HasKey(e => new { e.ClaimNumber, e.RepairerId });

                entity.ToTable("ClaimRepairer");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.ClaimRepairers)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimRepairer_Claim");

                entity.HasOne(d => d.Repairer)
                    .WithMany(p => p.ClaimRepairers)
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

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.ClaimRoadsideAssists)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimRoadsideAssist_Claim");

                entity.HasOne(d => d.RoadsideAssist)
                    .WithMany(p => p.ClaimRoadsideAssists)
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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClaimThirdParty>(entity =>
            {
                entity.HasKey(e => new { e.ClaimNumber, e.ThirdPartyId });

                entity.ToTable("ClaimThirdParty");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.ClaimThirdParties)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimThirdParty_Claim");

                entity.HasOne(d => d.ThirdParty)
                    .WithMany(p => p.ClaimThirdParties)
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

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.ClaimTowTrucks)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimTowTruck_Claim");

                entity.HasOne(d => d.TowTruck)
                    .WithMany(p => p.ClaimTowTrucks)
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

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.ClaimTracingAgents)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimTracingAgent_Claim");

                entity.HasOne(d => d.TracingAgent)
                    .WithMany(p => p.ClaimTracingAgents)
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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.IdNumber, "IX_Client")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Carrier");

                entity.HasOne(d => d.ClientType)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_ClientType");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Country");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_MaritalStatus");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Occupation");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Title");
            });

            modelBuilder.Entity<ClientBankAccount>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.BankAccountId });

                entity.ToTable("ClientBankAccount");

                entity.HasOne(d => d.BankAccount)
                    .WithMany(p => p.ClientBankAccounts)
                    .HasForeignKey(d => d.BankAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientBankAccount_BankAccount");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientBankAccounts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientBankAccount_Client");
            });

            modelBuilder.Entity<ClientDocument>(entity =>
            {
                entity.ToTable("ClientDocument");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DocumentPath).IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientDocuments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientDocument_Client");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ClientDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientDocument_DocumentType");
            });

            modelBuilder.Entity<ClientNumberGenerator>(entity =>
            {
                entity.HasKey(e => e.ClientNumber);

                entity.ToTable("ClientNumberGenerator");

                entity.Property(e => e.ClientNumber).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<ClientRisk>(entity =>
            {
                entity.ToTable("ClientRisk");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientRisks)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientRisk_Client");

                entity.HasOne(d => d.Risk)
                    .WithMany(p => p.ClientRisks)
                    .HasForeignKey(d => d.RiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientRisk_Risk");
            });

            modelBuilder.Entity<ClientType>(entity =>
            {
                entity.ToTable("ClientType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("Content");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhysicalAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ResidenceType)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.ResidenceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Content_ResidenceType");

                entity.HasOne(d => d.ResidenceUse)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.ResidenceUseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Content_ResidenceUse");

                entity.HasOne(d => d.RoofType)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.RoofTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Content_RoofType");

                entity.HasOne(d => d.WallType)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.WallTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Content_WallType");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CoverType>(entity =>
            {
                entity.ToTable("CoverType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
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

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LicenceDate).HasColumnType("date");

                entity.Property(e => e.LicenceIssuePlace)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LicenceNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_Gender");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_MaritalStatus");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_Occupation");
            });

            modelBuilder.Entity<DriverType>(entity =>
            {
                entity.ToTable("DriverType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ElectronicEquipment>(entity =>
            {
                entity.ToTable("ElectronicEquipment");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.RiskItem)
                    .WithMany(p => p.ElectronicEquipments)
                    .HasForeignKey(d => d.RiskItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElectronicEquipment_RiskItem");
            });

            modelBuilder.Entity<Extension>(entity =>
            {
                entity.ToTable("Extension");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FileTemplate>(entity =>
            {
                entity.ToTable("FileTemplate");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Delimiter).HasMaxLength(1);

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.FileTemplates)
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

                entity.Property(e => e.FieldLabel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.TableLabel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FileTemplate)
                    .WithMany(p => p.FileTemplateRecords)
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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Glass>(entity =>
            {
                entity.ToTable("Glass");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.RiskItem)
                    .WithMany(p => p.Glasses)
                    .HasForeignKey(d => d.RiskItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Glass_RiskItem");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.ToTable("House");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.PhysicalAddress)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.ResidenceType)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.ResidenceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_ResidenceType");

                entity.HasOne(d => d.RoofType)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.RoofTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_RoofType");

                entity.HasOne(d => d.WallType)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.WallTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_WallType");
            });

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.ToTable("Incident");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IncidentAuditLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IncidentAuditLog");

                entity.Property(e => e.DmlTimestamp).HasColumnType("datetime");

                entity.Property(e => e.DmlType)
                    .IsRequired()
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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InsurerAuditLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("InsurerAuditLog");

                entity.Property(e => e.DmlCreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DmlTimestamp).HasColumnType("datetime");

                entity.Property(e => e.DmlType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NewRowData).HasMaxLength(1000);

                entity.Property(e => e.OldRowData).HasMaxLength(1000);

                entity.Property(e => e.TrxTimestamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.HasOne(d => d.InvoiceStatus)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoiceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_InvoiceStatus");
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.ToTable("InvoiceItem");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvoiceNumberGenerator>(entity =>
            {
                entity.HasKey(e => e.InvoiceNumber);

                entity.ToTable("InvoiceNumberGenerator");

                entity.Property(e => e.InvoiceNumber).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvoiceStatus>(entity =>
            {
                entity.ToTable("InvoiceStatus");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.ToTable("JobTitle");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LossAdjuster>(entity =>
            {
                entity.ToTable("LossAdjuster");

                entity.HasIndex(e => e.IdNumber, "IX_LossAdjuster")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<LossAdjusterAuthority>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LossAdjusterAuthority");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AuthorisedDate).HasColumnType("date");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.InstructionDate).HasColumnType("date");

                entity.Property(e => e.IssuedDate).HasColumnType("date");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LossAdjusterInstruction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LossAdjusterInstruction");

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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Motor>(entity =>
            {
                entity.ToTable("Motor");

                entity.HasIndex(e => e.ChassisNumber, "IX_Motor_Chassis")
                    .IsUnique();

                entity.HasIndex(e => e.EngineNumber, "IX_Motor_Engine")
                    .IsUnique();

                entity.HasIndex(e => e.RegNumber, "IX_Motor_RegNumber")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ChassisNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Colour)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.EngineCapacity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EngineNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MotorCycleType>(entity =>
            {
                entity.ToTable("MotorCycleType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MotorImprovement>(entity =>
            {
                entity.ToTable("MotorImprovement");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MakeModel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MotorMake>(entity =>
            {
                entity.ToTable("MotorMake");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MotorModel>(entity =>
            {
                entity.ToTable("MotorModel");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MotorMake)
                    .WithMany(p => p.MotorModels)
                    .HasForeignKey(d => d.MotorMakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MotorModel_MotorMake");
            });

            modelBuilder.Entity<MotorUse>(entity =>
            {
                entity.ToTable("MotorUse");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.ToTable("Occupation");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
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

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VoidReason).HasMaxLength(50);

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Payables)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK_Payable_PaymentType");
            });

            modelBuilder.Entity<PayableRequisition>(entity =>
            {
                entity.HasKey(e => new { e.RequisitionId, e.PayableId });

                entity.ToTable("PayableRequisition");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Payable)
                    .WithMany(p => p.PayableRequisitions)
                    .HasForeignKey(d => d.PayableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayableRequisition_Payable");

                entity.HasOne(d => d.Requisition)
                    .WithMany(p => p.PayableRequisitions)
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

                entity.HasOne(d => d.PayeeType)
                    .WithMany(p => p.Payees)
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

                entity.HasOne(d => d.BankAccount)
                    .WithMany(p => p.PayeeBankAccounts)
                    .HasForeignKey(d => d.BankAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayeeBankAccount_BankAccount");

                entity.HasOne(d => d.Payee)
                    .WithMany(p => p.PayeeBankAccounts)
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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("Policy");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.CoverEndDate).HasColumnType("date");

                entity.Property(e => e.CoverStartDate).HasColumnType("date");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.InceptionDate).HasColumnType("date");

                entity.Property(e => e.PolicyNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.InsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policy_Insurer");

                entity.HasOne(d => d.PolicyStatus)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PolicyStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policy_PolicyStatus");

                entity.HasOne(d => d.PolicyType)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PolicyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policy_PolicyType");

                entity.HasOne(d => d.PortfolioClient)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PortfolioClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policy_PortfolioClient");

                entity.HasOne(d => d.SalesType)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.SalesTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policy_SalesType");
            });

            modelBuilder.Entity<PolicyNumberGenerator>(entity =>
            {
                entity.HasKey(e => e.PolicyNumber);

                entity.ToTable("PolicyNumberGenerator");

                entity.Property(e => e.PolicyNumber).ValueGeneratedNever();

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

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyRenewals)
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

                entity.Property(e => e.Excess)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SumInsured).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ClientRisk)
                    .WithMany(p => p.PolicyRisks)
                    .HasForeignKey(d => d.ClientRiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyRisk_ClientRisk");

                entity.HasOne(d => d.CoverType)
                    .WithMany(p => p.PolicyRisks)
                    .HasForeignKey(d => d.CoverTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyRisk_CoverType");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyRisks)
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

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.PolicyRiskClaims)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyRiskClaim_Claim");

                entity.HasOne(d => d.PolicyRisk)
                    .WithMany(p => p.PolicyRiskClaims)
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

                entity.HasOne(d => d.Extension)
                    .WithMany(p => p.PolicyRiskExtensions)
                    .HasForeignKey(d => d.ExtensionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyRiskExtension_Extension");

                entity.HasOne(d => d.PolicyRisk)
                    .WithMany(p => p.PolicyRiskExtensions)
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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PolicyType>(entity =>
            {
                entity.ToTable("PolicyType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.ToTable("Portfolio");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PortfolioClient>(entity =>
            {
                entity.ToTable("PortfolioClient");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PortfolioClients)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioClient_Client");

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.PortfolioClients)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioClient_Portfolio");
            });

            modelBuilder.Entity<Premium>(entity =>
            {
                entity.ToTable("Premium");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.PremiumDate).HasColumnType("date");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Premia)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Premium_Policy");

                entity.HasOne(d => d.PremiumType)
                    .WithMany(p => p.Premia)
                    .HasForeignKey(d => d.PremiumTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Premium_PremiumType");
            });

            modelBuilder.Entity<PremiumRefund>(entity =>
            {
                entity.ToTable("PremiumRefund");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Reason).IsRequired();

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReferenceDate).HasColumnType("date");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PremiumRefunds)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PremiumRefund_Policy");
            });

            modelBuilder.Entity<PremiumRefundClaim>(entity =>
            {
                entity.HasKey(e => new { e.PremiumRefundId, e.ClaimNumber });

                entity.ToTable("PremiumRefundClaim");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.PremiumRefundClaims)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PremiumRefundClaim_Claim");

                entity.HasOne(d => d.PremiumRefund)
                    .WithMany(p => p.PremiumRefundClaims)
                    .HasForeignKey(d => d.PremiumRefundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PremiumRefundClaim_PremiumRefund");
            });

            modelBuilder.Entity<PremiumType>(entity =>
            {
                entity.ToTable("PremiumType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PublicLiability>(entity =>
            {
                entity.ToTable("PublicLiability");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.RiskItem)
                    .WithMany(p => p.PublicLiabilities)
                    .HasForeignKey(d => d.RiskItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublicLiability_RiskItem");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("Quote");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientInfo).HasMaxLength(150);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.InternalInfo).HasMaxLength(150);

                entity.Property(e => e.QuoteDate).HasColumnType("date");

                entity.HasOne(d => d.QuoteStatus)
                    .WithMany(p => p.Quotes)
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

                entity.Property(e => e.Excess)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SumInsured).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ClientRisk)
                    .WithMany(p => p.QuoteItems)
                    .HasForeignKey(d => d.ClientRiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuoteItem_ClientRisk");

                entity.HasOne(d => d.CoverType)
                    .WithMany(p => p.QuoteItems)
                    .HasForeignKey(d => d.CoverTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuoteItem_CoverType");

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.QuoteItems)
                    .HasForeignKey(d => d.InsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuoteItem_Insurer");

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.QuoteItems)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuoteItem_Quote");
            });

            modelBuilder.Entity<QuoteNumberGenerator>(entity =>
            {
                entity.HasKey(e => e.QuoteNumber);

                entity.ToTable("QuoteNumberGenerator");

                entity.Property(e => e.QuoteNumber).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<QuoteStatus>(entity =>
            {
                entity.ToTable("QuoteStatus");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
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

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Receivables)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receivable_PaymentType");
            });

            modelBuilder.Entity<ReceivableInvoice>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceId, e.ReceivableId });

                entity.ToTable("ReceivableInvoice");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.ReceivableInvoices)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceivableInvoice_Invoice");

                entity.HasOne(d => d.Receivable)
                    .WithMany(p => p.ReceivableInvoices)
                    .HasForeignKey(d => d.ReceivableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceivableInvoice_Receivable");
            });

            modelBuilder.Entity<RefundStatus>(entity =>
            {
                entity.ToTable("RefundStatus");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RelationType>(entity =>
            {
                entity.ToTable("RelationType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Repairer>(entity =>
            {
                entity.ToTable("Repairer");

                entity.HasIndex(e => e.IdNumber, "IX_Repairer")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Requisition>(entity =>
            {
                entity.ToTable("Requisition");

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

                entity.HasOne(d => d.ChartOfAccounts)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.ChartOfAccountsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requisition_ChartOfAccounts");

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requisition_Claim");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requisition_Tax");
            });

            modelBuilder.Entity<RequisitionNumberGenerator>(entity =>
            {
                entity.HasKey(e => e.RequisitionNumber);

                entity.ToTable("RequisitionNumberGenerator");

                entity.Property(e => e.RequisitionNumber).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<ResidenceType>(entity =>
            {
                entity.ToTable("ResidenceType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ResidenceUse>(entity =>
            {
                entity.ToTable("ResidenceUse");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Risk>(entity =>
            {
                entity.ToTable("Risk");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.AllRisk)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.AllRiskId)
                    .HasConstraintName("FK_Risk_AllRisk");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK_Risk_Content");

                entity.HasOne(d => d.ElectronicEquipment)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.ElectronicEquipmentId)
                    .HasConstraintName("FK_Risk_ElectronicEquipment");

                entity.HasOne(d => d.Glass)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.GlassId)
                    .HasConstraintName("FK_Risk_Glass");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_Risk_House");

                entity.HasOne(d => d.Motor)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.MotorId)
                    .HasConstraintName("FK_Risk_Motor");

                entity.HasOne(d => d.PublicLiability)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.PublicLiabilityId)
                    .HasConstraintName("FK_Risk_PublicLiability");
            });

            modelBuilder.Entity<RiskItem>(entity =>
            {
                entity.ToTable("RiskItem");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RoadsideAssist>(entity =>
            {
                entity.ToTable("RoadsideAssist");

                entity.HasIndex(e => e.IdNumber, "IX_RoadsideAssist")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<RoofType>(entity =>
            {
                entity.ToTable("RoofType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SalesType>(entity =>
            {
                entity.ToTable("SalesType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Scheme>(entity =>
            {
                entity.ToTable("Scheme");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.ToTable("Tax");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TaxDate).HasColumnType("date");

                entity.Property(e => e.TaxRate).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ThirdParty>(entity =>
            {
                entity.ToTable("ThirdParty");

                entity.HasIndex(e => e.IdNumber, "IX_ThirdParty")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("Title");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TowTruck>(entity =>
            {
                entity.ToTable("TowTruck");

                entity.HasIndex(e => e.IdNumber, "IX_TowTruck")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<TracingAgent>(entity =>
            {
                entity.ToTable("TracingAgent");

                entity.HasIndex(e => e.IdNumber, "IX_TracingAgent")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<ValuationFeeRefund>(entity =>
            {
                entity.ToTable("ValuationFeeRefund");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReferenceDate).HasColumnType("date");

                entity.HasOne(d => d.PolicyRisk)
                    .WithMany(p => p.ValuationFeeRefunds)
                    .HasForeignKey(d => d.PolicyRiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ValuationFeeRefund_PolicyRisk");

                entity.HasOne(d => d.RefundStatus)
                    .WithMany(p => p.ValuationFeeRefunds)
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

                entity.HasOne(d => d.ClaimNumberNavigation)
                    .WithMany(p => p.ValuationFeeRefundClaims)
                    .HasForeignKey(d => d.ClaimNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ValuationFeeRefundClaim_Claim");

                entity.HasOne(d => d.ValuationFeeRefund)
                    .WithMany(p => p.ValuationFeeRefundClaims)
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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Withdrawal>(entity =>
            {
                entity.ToTable("Withdrawal");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReferenceDate).HasColumnType("date");

                entity.Property(e => e.WithdrawalDate).HasColumnType("date");

                entity.HasOne(d => d.PortfolioClient)
                    .WithMany(p => p.Withdrawals)
                    .HasForeignKey(d => d.PortfolioClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Withdrawal_PortfolioClient");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}