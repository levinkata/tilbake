using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tilbake.Core.Enums;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;
using Tilbake.Core.Models.Common;

namespace Tilbake.Core.Context
{
    public partial class TilbakeDbContext : DbContext
    {
        private readonly string _userId;

        public TilbakeDbContext(DbContextOptions<TilbakeDbContext> options, IGetClaimsProvider userData)
            : base(options)
        {
            _userId = userData.UserId;
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AllRisk> AllRisks { get; set; } = null!;
        public virtual DbSet<AllRiskSpecified> AllRiskSpecifieds { get; set; } = null!;
        public virtual DbSet<ApplicationSession> ApplicationSessions { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<AspnetUserPortfolio> AspnetUserPortfolios { get; set; } = null!;
        public virtual DbSet<Attorney> Attorneys { get; set; } = null!;
        public virtual DbSet<Audit> Audits { get; set; } = null!;
        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<BankAccount> BankAccounts { get; set; } = null!;
        public virtual DbSet<BankAuditLog> BankAuditLogs { get; set; } = null!;
        public virtual DbSet<BankBranch> BankBranches { get; set; } = null!;
        public virtual DbSet<Beneficiary> Beneficiaries { get; set; } = null!;
        public virtual DbSet<BodyType> BodyTypes { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<BuildingCondition> BuildingConditions { get; set; } = null!;
        public virtual DbSet<Carrier> Carriers { get; set; } = null!;
        public virtual DbSet<ChartOfAccount> ChartOfAccounts { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<ClaimAttorney> ClaimAttorneys { get; set; } = null!;
        public virtual DbSet<ClaimDocument> ClaimDocuments { get; set; } = null!;
        public virtual DbSet<ClaimLossAdjuster> ClaimLossAdjusters { get; set; } = null!;
        public virtual DbSet<ClaimNumberGenerator> ClaimNumberGenerators { get; set; } = null!;
        public virtual DbSet<ClaimRepairer> ClaimRepairers { get; set; } = null!;
        public virtual DbSet<ClaimRoadsideAssist> ClaimRoadsideAssists { get; set; } = null!;
        public virtual DbSet<ClaimStatus> ClaimStatuses { get; set; } = null!;
        public virtual DbSet<ClaimThirdParty> ClaimThirdParties { get; set; } = null!;
        public virtual DbSet<ClaimTowTruck> ClaimTowTrucks { get; set; } = null!;
        public virtual DbSet<ClaimTracingAgent> ClaimTracingAgents { get; set; } = null!;
        public virtual DbSet<Claimant> Claimants { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientBankAccount> ClientBankAccounts { get; set; } = null!;
        public virtual DbSet<ClientBulk> ClientBulks { get; set; } = null!;
        public virtual DbSet<ClientCarrier> ClientCarriers { get; set; } = null!;
        public virtual DbSet<ClientDocument> ClientDocuments { get; set; } = null!;
        public virtual DbSet<ClientNumberGenerator> ClientNumberGenerators { get; set; } = null!;
        public virtual DbSet<ClientRisk> ClientRisks { get; set; } = null!;
        public virtual DbSet<ClientRiskDocument> ClientRiskDocuments { get; set; } = null!;
        public virtual DbSet<ClientStatus> ClientStatuses { get; set; } = null!;
        public virtual DbSet<ClientType> ClientTypes { get; set; } = null!;
        public virtual DbSet<CommissionRate> CommissionRates { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CompanyBankAccount> CompanyBankAccounts { get; set; } = null!;
        public virtual DbSet<Content> Contents { get; set; } = null!;
        public virtual DbSet<ContentContentItem> ContentContentItems { get; set; } = null!;
        public virtual DbSet<ContentGroupItem> ContentGroupItems { get; set; } = null!;
        public virtual DbSet<ContentItem> ContentItems { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<CoverType> CoverTypes { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<DriverType> DriverTypes { get; set; } = null!;
        public virtual DbSet<Eftfile> Eftfiles { get; set; } = null!;
        public virtual DbSet<ElectronicEquipment> ElectronicEquipments { get; set; } = null!;
        public virtual DbSet<EmailAddress> EmailAddresses { get; set; } = null!;
        public virtual DbSet<ExcessBuyBack> ExcessBuyBacks { get; set; } = null!;
        public virtual DbSet<Extension> Extensions { get; set; } = null!;
        public virtual DbSet<FileTemplate> FileTemplates { get; set; } = null!;
        public virtual DbSet<FileTemplateRecord> FileTemplateRecords { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Glass> Glasses { get; set; } = null!;
        public virtual DbSet<House> Houses { get; set; } = null!;
        public virtual DbSet<HouseCondition> HouseConditions { get; set; } = null!;
        public virtual DbSet<IdDocumentType> IdDocumentTypes { get; set; } = null!;
        public virtual DbSet<Incident> Incidents { get; set; } = null!;
        public virtual DbSet<IncidentAuditLog> IncidentAuditLogs { get; set; } = null!;
        public virtual DbSet<Insurer> Insurers { get; set; } = null!;
        public virtual DbSet<InsurerAuditLog> InsurerAuditLogs { get; set; } = null!;
        public virtual DbSet<InsurerBranch> InsurerBranches { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;
        public virtual DbSet<InvoiceNumberGenerator> InvoiceNumberGenerators { get; set; } = null!;
        public virtual DbSet<InvoiceStatus> InvoiceStatuses { get; set; } = null!;
        public virtual DbSet<JobTitle> JobTitles { get; set; } = null!;
        public virtual DbSet<Life> Lives { get; set; } = null!;
        public virtual DbSet<LossAdjuster> LossAdjusters { get; set; } = null!;
        public virtual DbSet<LossAdjusterAuthority> LossAdjusterAuthorities { get; set; } = null!;
        public virtual DbSet<LossAdjusterInstruction> LossAdjusterInstructions { get; set; } = null!;
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; } = null!;
        public virtual DbSet<MobileNumber> MobileNumbers { get; set; } = null!;
        public virtual DbSet<Motor> Motors { get; set; } = null!;
        public virtual DbSet<MotorAccessory> MotorAccessories { get; set; } = null!;
        public virtual DbSet<MotorCycle> MotorCycles { get; set; } = null!;
        public virtual DbSet<MotorCycleType> MotorCycleTypes { get; set; } = null!;
        public virtual DbSet<MotorImprovement> MotorImprovements { get; set; } = null!;
        public virtual DbSet<MotorMake> MotorMakes { get; set; } = null!;
        public virtual DbSet<MotorModel> MotorModels { get; set; } = null!;
        public virtual DbSet<MotorRadio> MotorRadios { get; set; } = null!;
        public virtual DbSet<Occupation> Occupations { get; set; } = null!;
        public virtual DbSet<Payable> Payables { get; set; } = null!;
        public virtual DbSet<PayableRequisition> PayableRequisitions { get; set; } = null!;
        public virtual DbSet<Payee> Payees { get; set; } = null!;
        public virtual DbSet<PayeeBankAccount> PayeeBankAccounts { get; set; } = null!;
        public virtual DbSet<PayeeType> PayeeTypes { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<PaymentType> PaymentTypes { get; set; } = null!;
        public virtual DbSet<Policy> Policies { get; set; } = null!;
        public virtual DbSet<PolicyBulk> PolicyBulks { get; set; } = null!;
        public virtual DbSet<PolicyNumberGenerator> PolicyNumberGenerators { get; set; } = null!;
        public virtual DbSet<PolicyRenewal> PolicyRenewals { get; set; } = null!;
        public virtual DbSet<PolicyRisk> PolicyRisks { get; set; } = null!;
        public virtual DbSet<PolicyRiskClaim> PolicyRiskClaims { get; set; } = null!;
        public virtual DbSet<PolicyRiskExtension> PolicyRiskExtensions { get; set; } = null!;
        public virtual DbSet<PolicyStatus> PolicyStatuses { get; set; } = null!;
        public virtual DbSet<PolicyType> PolicyTypes { get; set; } = null!;
        public virtual DbSet<Portfolio> Portfolios { get; set; } = null!;
        public virtual DbSet<PortfolioAdministrationFee> PortfolioAdministrationFees { get; set; } = null!;
        public virtual DbSet<PortfolioClient> PortfolioClients { get; set; } = null!;
        public virtual DbSet<PortfolioExcessBuyBack> PortfolioExcessBuyBacks { get; set; } = null!;
        public virtual DbSet<PortfolioPolicyFee> PortfolioPolicyFees { get; set; } = null!;
        public virtual DbSet<PortfolioRatingMotor> PortfolioRatingMotors { get; set; } = null!;
        public virtual DbSet<PortfolioRatingMotorDiscount> PortfolioRatingMotorDiscounts { get; set; } = null!;
        public virtual DbSet<PortfolioRatingMotorExcess> PortfolioRatingMotorExcesses { get; set; } = null!;
        public virtual DbSet<PortfolioRatingMotorPremium> PortfolioRatingMotorPremia { get; set; } = null!;
        public virtual DbSet<Premium> Premia { get; set; } = null!;
        public virtual DbSet<PremiumBulk> PremiumBulks { get; set; } = null!;
        public virtual DbSet<PremiumRefund> PremiumRefunds { get; set; } = null!;
        public virtual DbSet<PremiumRefundClaim> PremiumRefundClaims { get; set; } = null!;
        public virtual DbSet<PublicLiability> PublicLiabilities { get; set; } = null!;
        public virtual DbSet<Quote> Quotes { get; set; } = null!;
        public virtual DbSet<QuoteItem> QuoteItems { get; set; } = null!;
        public virtual DbSet<QuoteNumberGenerator> QuoteNumberGenerators { get; set; } = null!;
        public virtual DbSet<QuoteStatus> QuoteStatuses { get; set; } = null!;
        public virtual DbSet<RatingMotor> RatingMotors { get; set; } = null!;
        public virtual DbSet<RatingMotorDiscount> RatingMotorDiscounts { get; set; } = null!;
        public virtual DbSet<RatingMotorExcess> RatingMotorExcesses { get; set; } = null!;
        public virtual DbSet<RatingMotorPremium> RatingMotorPremia { get; set; } = null!;
        public virtual DbSet<Receivable> Receivables { get; set; } = null!;
        public virtual DbSet<ReceivableDocument> ReceivableDocuments { get; set; } = null!;
        public virtual DbSet<ReceivableInvoice> ReceivableInvoices { get; set; } = null!;
        public virtual DbSet<ReceivableQuote> ReceivableQuotes { get; set; } = null!;
        public virtual DbSet<Reconcilliation> Reconcilliations { get; set; } = null!;
        public virtual DbSet<RefundStatus> RefundStatuses { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<RelationType> RelationTypes { get; set; } = null!;
        public virtual DbSet<Repairer> Repairers { get; set; } = null!;
        public virtual DbSet<Requisition> Requisitions { get; set; } = null!;
        public virtual DbSet<RequisitionNumberGenerator> RequisitionNumberGenerators { get; set; } = null!;
        public virtual DbSet<ResidenceType> ResidenceTypes { get; set; } = null!;
        public virtual DbSet<ResidenceUse> ResidenceUses { get; set; } = null!;
        public virtual DbSet<Risk> Risks { get; set; } = null!;
        public virtual DbSet<RiskItem> RiskItems { get; set; } = null!;
        public virtual DbSet<RoadsideAssist> RoadsideAssists { get; set; } = null!;
        public virtual DbSet<RoofType> RoofTypes { get; set; } = null!;
        public virtual DbSet<SalesType> SalesTypes { get; set; } = null!;
        public virtual DbSet<StatedBenefit> StatedBenefits { get; set; } = null!;
        public virtual DbSet<Tax> Taxes { get; set; } = null!;
        public virtual DbSet<ThirdParty> ThirdParties { get; set; } = null!;
        public virtual DbSet<Title> Titles { get; set; } = null!;
        public virtual DbSet<TowTruck> TowTrucks { get; set; } = null!;
        public virtual DbSet<TracingAgent> TracingAgents { get; set; } = null!;
        public virtual DbSet<Trailer> Trailers { get; set; } = null!;
        public virtual DbSet<Travel> Travels { get; set; } = null!;
        public virtual DbSet<TravelBeneficiary> TravelBeneficiaries { get; set; } = null!;
        public virtual DbSet<ValuationFeeRefund> ValuationFeeRefunds { get; set; } = null!;
        public virtual DbSet<ValuationFeeRefundClaim> ValuationFeeRefundClaims { get; set; } = null!;
        public virtual DbSet<WallType> WallTypes { get; set; } = null!;
        public virtual DbSet<Withdrawal> Withdrawals { get; set; } = null!;
        public virtual DbSet<WorkmanCompensation> WorkmanCompensations { get; set; } = null!;

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaveChanges(_userId);
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaveChanges(_userId);
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaveChanges(string userId = null)
        {
            ChangeTracker.DetectChanges();

            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry)
                {
                    TableName = entry.Entity.GetType().Name,
                    UserId = userId
                };
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;

                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                Audits.Add(auditEntry.ToAudit());
            }
        }

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

                entity.HasOne(d => d.Attorney)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AttorneyId)
                    .HasConstraintName("FK_Address_Attorney");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Address_City");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Address_Client");

                entity.HasOne(d => d.LossAdjuster)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.LossAdjusterId)
                    .HasConstraintName("FK_Address_LossAdjuster");

                entity.HasOne(d => d.Repairer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.RepairerId)
                    .HasConstraintName("FK_Address_Repairer");

                entity.HasOne(d => d.RoadsideAssist)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.RoadsideAssistId)
                    .HasConstraintName("FK_Address_RoadsideAssist");

                entity.HasOne(d => d.ThirdParty)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ThirdPartyId)
                    .HasConstraintName("FK_Address_ThirdParty");

                entity.HasOne(d => d.TowTruck)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TowTruckId)
                    .HasConstraintName("FK_Address_TowTruck");

                entity.HasOne(d => d.TracingAgent)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TracingAgentId)
                    .HasConstraintName("FK_Address_TracingAgent");
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

            modelBuilder.Entity<AllRiskSpecified>(entity =>
            {
                entity.ToTable("AllRiskSpecified");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.HasOne(d => d.RiskItem)
                    .WithMany(p => p.AllRiskSpecifieds)
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
                entity.Property(e => e.Id).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleId).HasMaxLength(250);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
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

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AspNetUserRoles_AspNetRoles"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AspNetUserRoles_AspNetUsers"),
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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
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
                entity.HasKey(e => e.UserId)
                    .HasName("PK__AspNetUs__1788CC4CC42F81E2");

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

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.AspnetUserPortfolios)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspnetUserPortfolio_AspNetUsers");

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.AspnetUserPortfolios)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspnetUserPortfolio_Portfolio");
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
                entity.ToTable("Bank");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("BankAccount");

                entity.HasIndex(e => e.AccountNumber, "IX_BankAccount")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

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

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SortCode).HasMaxLength(50);

                entity.Property(e => e.SwiftCode).HasMaxLength(50);

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

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.PortfolioClient)
                    .WithMany(p => p.Beneficiaries)
                    .HasForeignKey(d => d.PortfolioClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beneficiary_PortfolioClient");

                entity.HasOne(d => d.RelationType)
                    .WithMany(p => p.Beneficiaries)
                    .HasForeignKey(d => d.RelationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beneficiary_RelationType");
            });

            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.ToTable("BodyType");

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

                entity.HasOne(d => d.BuildingCondition)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.BuildingConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Building_BuildingCondition");

                entity.HasOne(d => d.ResidenceType)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.ResidenceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Building_ResidenceType");

                entity.HasOne(d => d.ResidenceUse)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.ResidenceUseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Building_ResidenceUse");

                entity.HasOne(d => d.RoofType)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.RoofTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Building_RoofType");

                entity.HasOne(d => d.WallType)
                    .WithMany(p => p.Buildings)
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
                entity.ToTable("Carrier");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ChartOfAccount>(entity =>
            {
                entity.HasIndex(e => e.Glcode, "IX_ChartOfAccounts")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Glcode)
                    .HasMaxLength(5)
                    .HasColumnName("GLCode");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("Claim");

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
            });

            modelBuilder.Entity<ClaimDocument>(entity =>
            {
                entity.ToTable("ClaimDocument");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DocumentDate).HasColumnType("date");

                entity.Property(e => e.Extension).HasMaxLength(50);

                entity.Property(e => e.FileType).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

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

                entity.HasOne(d => d.LossAdjuster)
                    .WithMany(p => p.ClaimLossAdjusters)
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

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ClaimThirdParty>(entity =>
            {
                entity.HasKey(e => new { e.ClaimNumber, e.ThirdPartyId });

                entity.ToTable("ClaimThirdParty");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

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

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.IdNumber, "IX_Client")
                    .IsUnique();

                entity.HasIndex(e => e.ClientNumber, "IX_Client_ClientNumber")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdNumber).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

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

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Gender");

                entity.HasOne(d => d.IdDocumentType)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdDocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_IdDocumentType");

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
                entity.ToTable("ClientBankAccount");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

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

            modelBuilder.Entity<ClientBulk>(entity =>
            {
                entity.ToTable("ClientBulk");

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

            modelBuilder.Entity<ClientCarrier>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.CarrierId });

                entity.ToTable("ClientCarrier");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.ClientCarriers)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientCarrier_Carrier");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientCarriers)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientCarrier_Client");
            });

            modelBuilder.Entity<ClientDocument>(entity =>
            {
                entity.ToTable("ClientDocument");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DocumentDate).HasColumnType("date");

                entity.Property(e => e.DocumentPath).IsUnicode(false);

                entity.Property(e => e.Extension).HasMaxLength(50);

                entity.Property(e => e.FileType).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

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
                entity.ToTable("ClientNumberGenerator");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

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

            modelBuilder.Entity<ClientRiskDocument>(entity =>
            {
                entity.ToTable("ClientRiskDocument");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DocumentDate).HasColumnType("date");

                entity.Property(e => e.DocumentPath).IsUnicode(false);

                entity.Property(e => e.Extension).HasMaxLength(50);

                entity.Property(e => e.FileType).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.ClientRisk)
                    .WithMany(p => p.ClientRiskDocuments)
                    .HasForeignKey(d => d.ClientRiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientRiskDocument_ClientRisk");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ClientRiskDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientRiskDocument_DocumentType");
            });

            modelBuilder.Entity<ClientStatus>(entity =>
            {
                entity.ToTable("ClientStatus");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ClientType>(entity =>
            {
                entity.ToTable("ClientType");

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

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PhysicalAddress).HasMaxLength(100);

                entity.Property(e => e.PostalAddress).HasMaxLength(50);

                entity.Property(e => e.TaxNumber).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(100);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_City");
            });

            modelBuilder.Entity<CompanyBankAccount>(entity =>
            {
                entity.ToTable("CompanyBankAccount");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.BankAccount)
                    .WithMany(p => p.CompanyBankAccounts)
                    .HasForeignKey(d => d.BankAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyBankAccount_BankAccount");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyBankAccounts)
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

                entity.HasOne(d => d.BuildingCondition)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.BuildingConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Content_BuildingCondition");

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

            modelBuilder.Entity<ContentContentItem>(entity =>
            {
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

                entity.HasOne(d => d.ContentGroupItem)
                    .WithMany(p => p.ContentItems)
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

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.Eftfiles)
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

                entity.HasOne(d => d.RiskItem)
                    .WithMany(p => p.ElectronicEquipments)
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

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.EmailAddresses)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmailAddress_Client");
            });

            modelBuilder.Entity<ExcessBuyBack>(entity =>
            {
                entity.ToTable("ExcessBuyBack");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Motor)
                    .WithMany(p => p.ExcessBuyBacks)
                    .HasForeignKey(d => d.MotorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExcessBuyBack_Motor");

                entity.HasOne(d => d.ParentPolicy)
                    .WithMany(p => p.ExcessBuyBacks)
                    .HasForeignKey(d => d.ParentPolicyId)
                    .HasConstraintName("FK_ExcessBuyBack_Policy");

                entity.HasOne(d => d.ParentQuote)
                    .WithMany(p => p.ExcessBuyBacks)
                    .HasForeignKey(d => d.ParentQuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExcessBuyBack_Quote");
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

                entity.Property(e => e.FieldLabel).HasMaxLength(50);

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(5);

                entity.Property(e => e.TableLabel).HasMaxLength(50);

                entity.Property(e => e.TableName).HasMaxLength(50);

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

                entity.Property(e => e.Name).HasMaxLength(50);
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

                entity.Property(e => e.PhysicalAddress).HasMaxLength(150);

                entity.HasOne(d => d.HouseCondition)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.HouseConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_HouseCondition");

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
                entity.HasNoKey();

                entity.ToTable("IncidentAuditLog");

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
                entity.HasNoKey();

                entity.ToTable("InsurerAuditLog");

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

                entity.HasOne(d => d.City)
                    .WithMany(p => p.InsurerBranches)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InsurerBranch_City");

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.InsurerBranches)
                    .HasForeignKey(d => d.InsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InsurerBranch_Insurer");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.HasIndex(e => e.InvoiceNumber, "IX_Invoice")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.InstallmentAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReducingBalance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxRate).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.InvoiceStatus)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoiceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_InvoiceStatus");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Invoices)
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

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceItem_Invoice");

                entity.HasOne(d => d.PolicyRisk)
                    .WithMany(p => p.InvoiceItems)
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

                entity.HasOne(d => d.RiskItem)
                    .WithMany(p => p.Lives)
                    .HasForeignKey(d => d.RiskItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Life_RiskItem");
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

                entity.Property(e => e.IdNumber).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

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

                entity.Property(e => e.Reference).HasMaxLength(50);
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

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MobileNumber>(entity =>
            {
                entity.ToTable("MobileNumber");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.MobileNumbers)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MobileNumber_Client");
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

                entity.Property(e => e.ChassisNumber).HasMaxLength(50);

                entity.Property(e => e.Colour).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.EngineCapacity).HasMaxLength(50);

                entity.Property(e => e.EngineNumber).HasMaxLength(50);

                entity.Property(e => e.FinancialInterest).HasMaxLength(50);

                entity.Property(e => e.RegNumber).HasMaxLength(50);

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.Motors)
                    .HasForeignKey(d => d.BodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motor_BodyType");

                entity.HasOne(d => d.DriverType)
                    .WithMany(p => p.Motors)
                    .HasForeignKey(d => d.DriverTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motor_DriverType");

                entity.HasOne(d => d.MotorModel)
                    .WithMany(p => p.Motors)
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

                entity.HasOne(d => d.Motor)
                    .WithMany(p => p.MotorAccessories)
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

                entity.HasOne(d => d.Motor)
                    .WithMany(p => p.MotorImprovements)
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

                entity.HasOne(d => d.MotorMake)
                    .WithMany(p => p.MotorModels)
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

                entity.HasOne(d => d.Motor)
                    .WithMany(p => p.MotorRadios)
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
                entity.ToTable("Policy");

                entity.HasIndex(e => e.PolicyNumber, "IX_Policy")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.CoverEndDate).HasColumnType("date");

                entity.Property(e => e.CoverStartDate).HasColumnType("date");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.InceptionDate).HasColumnType("date");

                entity.Property(e => e.InsurerPolicyNumber).HasMaxLength(50);

                entity.HasOne(d => d.ClientBankAccount)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.ClientBankAccountId)
                    .HasConstraintName("FK_Policy_ClientBankAccount");

                entity.HasOne(d => d.InsurerBranch)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.InsurerBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policy_InsurerBranch");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policy_PaymentMethod");

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

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policy_Quote");

                entity.HasOne(d => d.SalesType)
                    .WithMany(p => p.Policies)
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

                entity.Property(e => e.Excess).HasMaxLength(50);

                entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RiskDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SumInsured).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxRate).HasColumnType("decimal(18, 2)");

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

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.PortfolioAdministrationFees)
                    .HasForeignKey(d => d.InsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioAdministrationFee_Insurer");

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.PortfolioAdministrationFees)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioAdministrationFee_Portfolio");
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

                entity.HasOne(d => d.ClientStatus)
                    .WithMany(p => p.PortfolioClients)
                    .HasForeignKey(d => d.ClientStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioClient_ClientStatus");

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.PortfolioClients)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioClient_Portfolio");
            });

            modelBuilder.Entity<PortfolioExcessBuyBack>(entity =>
            {
                entity.ToTable("PortfolioExcessBuyBack");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BuyBackRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.ExcessRate).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.PortfolioExcessBuyBacks)
                    .HasForeignKey(d => d.InsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioExcessBuyBack_Insurer");

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.PortfolioExcessBuyBacks)
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

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.PortfolioPolicyFees)
                    .HasForeignKey(d => d.InsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioPolicyFee_Insurer");

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.PortfolioPolicyFees)
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

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.PortfolioRatingMotors)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioRatingMotor_Portfolio");

                entity.HasOne(d => d.RatingMotor)
                    .WithMany(p => p.PortfolioRatingMotors)
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

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.PortfolioRatingMotorDiscounts)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioRatingMotorDiscount_Portfolio");

                entity.HasOne(d => d.RatingMotorDiscount)
                    .WithMany(p => p.PortfolioRatingMotorDiscounts)
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

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.PortfolioRatingMotorExcesses)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioRatingMotorExcess_Portfolio");

                entity.HasOne(d => d.RatingMotorExcess)
                    .WithMany(p => p.PortfolioRatingMotorExcesses)
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

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.PortfolioRatingMotorPremia)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioRatingMotorPremium_Portfolio");

                entity.HasOne(d => d.RatingMotorPremium)
                    .WithMany(p => p.PortfolioRatingMotorPremia)
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

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.PolicyFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PremiumDate).HasColumnType("date");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Premia)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Premium_Policy");
            });

            modelBuilder.Entity<PremiumBulk>(entity =>
            {
                entity.ToTable("PremiumBulk");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdNumber).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(100);
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

                entity.HasOne(d => d.PremiumRefund)
                    .WithMany(p => p.PremiumRefundClaims)
                    .HasForeignKey(d => d.PremiumRefundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PremiumRefundClaim_PremiumRefund");
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

                entity.HasIndex(e => e.QuoteNumber, "IX_Quote")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientInfo).HasMaxLength(150);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.InternalInfo).HasMaxLength(150);

                entity.Property(e => e.PaymentTypeId).HasDefaultValueSql("(N'70d0d854-75b6-4f61-a039-8a21acd2c3d0')");

                entity.Property(e => e.QuoteDate).HasColumnType("date");

                entity.HasOne(d => d.InsurerBranch)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.InsurerBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_InsurerBranch");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_Quote_PaymentMethod");

                entity.HasOne(d => d.PolicyType)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.PolicyTypeId)
                    .HasConstraintName("FK_Quote_PolicyType");

                entity.HasOne(d => d.PortfolioClient)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.PortfolioClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_PortfolioClient");

                entity.HasOne(d => d.QuoteStatus)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.QuoteStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_QuoteStatus");

                entity.HasOne(d => d.SalesType)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.SalesTypeId)
                    .HasConstraintName("FK_Quote_SalesType");
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

                entity.Property(e => e.TaxRate).HasColumnType("decimal(18, 2)");

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

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.QuoteItems)
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

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.RatingMotors)
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

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.RatingMotorDiscounts)
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

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.RatingMotorExcesses)
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

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.RatingMotorPremia)
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

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Receivables)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receivable_PaymentType");
            });

            modelBuilder.Entity<ReceivableDocument>(entity =>
            {
                entity.ToTable("ReceivableDocument");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DocumentDate).HasColumnType("date");

                entity.Property(e => e.Extension).HasMaxLength(50);

                entity.Property(e => e.FileType).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ReceivableDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceivableDocument_DocumentType");

                entity.HasOne(d => d.Receivable)
                    .WithMany(p => p.ReceivableDocuments)
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

            modelBuilder.Entity<ReceivableQuote>(entity =>
            {
                entity.HasKey(e => new { e.QuoteId, e.ReceivableId });

                entity.ToTable("ReceivableQuote");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.ReceivableQuotes)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceivableQuote_Quote");

                entity.HasOne(d => d.Receivable)
                    .WithMany(p => p.ReceivableQuotes)
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

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Reconcilliations)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reconcilliation_Invoice");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Reconcilliations)
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

                entity.HasIndex(e => e.IdNumber, "IX_Repairer")
                    .IsUnique();

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
                entity.ToTable("Requisition");

                entity.HasIndex(e => e.RequisitionNumber, "IX_Requisition")
                    .IsUnique();

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

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requisition_Tax");
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

                entity.HasOne(d => d.AllRisk)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.AllRiskId)
                    .HasConstraintName("FK_Risk_AllRisk");

                entity.HasOne(d => d.AllRiskSpecified)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.AllRiskSpecifiedId)
                    .HasConstraintName("FK_Risk_AllRiskSpecified");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_Risk_Building");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK_Risk_Content");

                entity.HasOne(d => d.ElectronicEquipment)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.ElectronicEquipmentId)
                    .HasConstraintName("FK_Risk_ElectronicEquipment");

                entity.HasOne(d => d.ExcessBuyBack)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.ExcessBuyBackId)
                    .HasConstraintName("FK_Risk_ExcessBuyBack");

                entity.HasOne(d => d.Glass)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.GlassId)
                    .HasConstraintName("FK_Risk_Glass");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_Risk_House");

                entity.HasOne(d => d.Life)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.LifeId)
                    .HasConstraintName("FK_Risk_Life");

                entity.HasOne(d => d.MotorCycle)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.MotorCycleId)
                    .HasConstraintName("FK_Risk_MotorCycle");

                entity.HasOne(d => d.Motor)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.MotorId)
                    .HasConstraintName("FK_Risk_Motor");

                entity.HasOne(d => d.PublicLiability)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.PublicLiabilityId)
                    .HasConstraintName("FK_Risk_PublicLiability");

                entity.HasOne(d => d.StatedBenefit)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.StatedBenefitId)
                    .HasConstraintName("FK_Risk_StatedBenefit");

                entity.HasOne(d => d.Trailer)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.TrailerId)
                    .HasConstraintName("FK_Risk_Trailer");

                entity.HasOne(d => d.Travel)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(d => d.TravelId)
                    .HasConstraintName("FK_Risk_Travel");

                entity.HasOne(d => d.WorkmanCompensation)
                    .WithMany(p => p.Risks)
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

                entity.HasIndex(e => e.IdNumber, "IX_RoadsideAssist")
                    .IsUnique();

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

                entity.HasOne(d => d.RiskItem)
                    .WithMany(p => p.StatedBenefits)
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

                entity.HasIndex(e => e.IdNumber, "IX_ThirdParty")
                    .IsUnique();

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

                entity.HasIndex(e => e.IdNumber, "IX_TowTruck")
                    .IsUnique();

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

                entity.HasIndex(e => e.IdNumber, "IX_TracingAgent")
                    .IsUnique();

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

                entity.HasOne(d => d.PortfolioClient)
                    .WithMany(p => p.Travels)
                    .HasForeignKey(d => d.PortfolioClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Travel_PortfolioClient");
            });

            modelBuilder.Entity<TravelBeneficiary>(entity =>
            {
                entity.ToTable("TravelBeneficiary");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PassportNumber).HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TravelBeneficiaries)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelBeneficiary_Country");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TravelBeneficiaries)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelBeneficiary_Title");

                entity.HasOne(d => d.Travel)
                    .WithMany(p => p.TravelBeneficiaries)
                    .HasForeignKey(d => d.TravelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelBeneficiary_Travel");
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

                entity.HasOne(d => d.PortfolioClient)
                    .WithMany(p => p.Withdrawals)
                    .HasForeignKey(d => d.PortfolioClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Withdrawal_PortfolioClient");
            });

            modelBuilder.Entity<WorkmanCompensation>(entity =>
            {
                entity.ToTable("WorkmanCompensation");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.RiskItem)
                    .WithMany(p => p.WorkmanCompensations)
                    .HasForeignKey(d => d.RiskItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkmanCompensation_RiskItem");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
