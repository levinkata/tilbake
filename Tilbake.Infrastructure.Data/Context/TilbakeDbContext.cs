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

        public DbSet<Insurer> Insurers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            };

            builder.Entity<Insurer>().ToTable("Insurer");
        }
    }
}
