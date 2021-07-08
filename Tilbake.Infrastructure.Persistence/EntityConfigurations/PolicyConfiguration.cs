using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Generators;

namespace Tilbake.Infrastructure.Persistence.EntityConfigurations
{
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Policy");

            builder.Property(m => m.PolicyNumber)
                    .ValueGeneratedNever()
                    .HasValueGenerator((e, p) =>
                    new PolicyGenerator());    
        }        
    }
}