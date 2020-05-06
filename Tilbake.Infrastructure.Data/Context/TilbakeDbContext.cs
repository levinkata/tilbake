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


        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Insurer> Insurers { get; set; }
        public DbSet<Klient> Klients { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioKlient> PortfolioKlients { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            };

            builder.Entity<Bank>().ToTable("Bank");
            builder.Entity<BankBranch>().ToTable("BankBranch");
            builder.Entity<BodyType>().ToTable("BodyType");
            builder.Entity<CoverType>().ToTable("CoverType");
            builder.Entity<Insurer>().ToTable("Insurer");
            builder.Entity<Klient>().ToTable("Klient");
            builder.Entity<Land>().ToTable("Land");
            builder.Entity<Occupation>().ToTable("Occupation");
            builder.Entity<Portfolio>().ToTable("Portfolio");
            builder.Entity<PortfolioKlient>().ToTable("PortfolioKlient");
            builder.Entity<Title>().ToTable("Title");
        }
    }
}
