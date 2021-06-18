using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Generators;

namespace Tilbake.Infrastructure.Persistence.EntityConfigurations
{
    public class InvoiceConfiguration  : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Invoices");

            builder.Property(m => m.InvoiceNumber)
                    .ValueGeneratedNever()
                    .HasValueGenerator((e, p) =>
                    new InvoiceGenerator());    
        }        
    }
}