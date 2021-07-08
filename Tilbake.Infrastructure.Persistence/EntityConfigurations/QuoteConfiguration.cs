using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Generators;

namespace Tilbake.Infrastructure.Persistence.EntityConfigurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Quote");

            builder.Property(m => m.QuoteNumber)
                    .ValueGeneratedNever()
                    .HasValueGenerator((e, p) =>
                    new QuoteGenerator());    
        }        
    }
}