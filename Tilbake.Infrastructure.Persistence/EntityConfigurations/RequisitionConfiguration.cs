using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Generators;

namespace Tilbake.Infrastructure.Persistence.EntityConfigurations
{
    public class RequisitionConfiguration  : IEntityTypeConfiguration<Requisition>
    {
        public void Configure(EntityTypeBuilder<Requisition> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Requisitions");

            builder.Property(m => m.RequisitionNumber)
                    .ValueGeneratedNever()
                    .HasValueGenerator((e, p) =>
                    new RequisitionGenerator());    
        }        
    }
}