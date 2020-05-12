using Microsoft.EntityFrameworkCore;
using System;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Data.Context
{
    public class TilbakeDbContext : DbContext
    {
        public TilbakeDbContext(DbContextOptions<TilbakeDbContext> options) : base(options)
        {

        }

        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<AllRisk> AllRisks { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Glass> Glasses { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Insurer> Insurers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<Klient> Klients { get; set; }
        public DbSet<KlientBankAccount> KlientBankAccounts { get; set; }
        public DbSet<KlientDocument> KlientDocuments { get; set; }
        public DbSet<KlientNumberGenerator> KlientNumberGenerators { get; set; }
        public DbSet<KlientRisk> KlientRisk { get; set; }
        public DbSet<Krav> Kravs { get; set; }
        public DbSet<KravStatus> KravStatuses { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<Motor> Motors { get; set; }
        public DbSet<MotorImprovement> MotorImprovements { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PolitikkStatus> PolicyStatuses { get; set; }
        public DbSet<Politikk> Politikks { get; set; }
        public DbSet<PolitikkRisk> PolitikkRisks { get; set; }
        public DbSet<PolitikkRiskExtension> PolitikkRiskExtensions { get; set; }
        public DbSet<PolitikkType> PolicyTypes { get; set; }
        public DbSet<PortfolioKlient> PortfolioKlients { get; set; }
        public DbSet<Premium> Premiums { get; set; }
        public DbSet<PremiumType> PremiumTypes { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }
        public DbSet<QuoteStatus> QuoteStatuses { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Risk> Risks { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            };

            builder.Entity<Adresse>().ToTable("Adresse");
            builder.Entity<AllRisk>().ToTable("AllRisk");
            builder.Entity<Bank>().ToTable("Bank");
            builder.Entity<BankAccount>().ToTable("BankAccount");
            builder.Entity<BankBranch>().ToTable("BankBranch");
            builder.Entity<BodyType>().ToTable("BodyType");
            builder.Entity<City>().ToTable("City");
            builder.Entity<Component>().ToTable("Component");
            builder.Entity<Content>().ToTable("Content");
            builder.Entity<CoverType>().ToTable("CoverType");
            builder.Entity<Glass>().ToTable("Glass");
            builder.Entity<Incident>().ToTable("Incident");
            builder.Entity<Insurer>().ToTable("Insurer");
            builder.Entity<Invoice>().ToTable("Invoice");
            builder.Entity<InvoiceItem>().ToTable("InvoiceItem");
            builder.Entity<InvoiceStatus>().ToTable("InvoiceStatus");
            builder.Entity<Klient>().ToTable("Klient");
            
            builder.Entity<KlientBankAccount>(p =>
            {
                p.ToTable("KlientBankAccount");
                p.HasKey(r => new { r.BankAccountID, r.KlientID}).HasName("PK_KlientBankAccount");
            });

            builder.Entity<KlientDocument>().ToTable("KlientDocument");

            builder.Entity<KlientNumberGenerator>(p =>
            {
                p.ToTable("KlientNumberGenerator");
                p.HasKey(r => r.KlientNumber).HasName("PK_KlientNumber");
            });

            builder.Entity<KlientRisk>().ToTable("KlientRisk");
            
            builder.Entity<Krav>(p =>
            {
                p.ToTable("Krav");
                p.HasKey(r => r.KravNumber).HasName("PK_Krav");
            });

            builder.Entity<KravStatus>().ToTable("KravStatus");
            builder.Entity<Land>().ToTable("Land");
            builder.Entity<Motor>().ToTable("Motor");
            builder.Entity<MotorImprovement>().ToTable("MotorImprovement");
            builder.Entity<Occupation>().ToTable("Occupation");
            builder.Entity<PolitikkStatus>().ToTable("PolicyStatus");
            builder.Entity<Politikk>().ToTable("Politikk");
            builder.Entity<PolitikkRisk>().ToTable("PolitikkRisk");
            
            builder.Entity<PolitikkRiskExtension>(p =>
            {
                p.ToTable("PolitikkRiskExtension");
                p.HasKey(r => new { r.PolitikkRiskID, r.ExtensionID }).HasName("PK_PolitikkRiskExtension");
            });

            builder.Entity<PolitikkType>().ToTable("PolicyType");
            builder.Entity<Portfolio>().ToTable("Portfolio");
            builder.Entity<PortfolioKlient>().ToTable("PortfolioKlient");
            builder.Entity<Premium>().ToTable("Premium");
            builder.Entity<PremiumType>().ToTable("PremiumType");
            builder.Entity<QuoteStatus>().ToTable("QuoteStatus");
            builder.Entity<Region>().ToTable("Region");
            builder.Entity<Risk>().ToTable("Risk");
            builder.Entity<Title>().ToTable("Title");
        }
    }
}
