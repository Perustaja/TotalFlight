using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TotalFlight.Domain.Entities;

namespace TotalFlight.Infrastructure.EntityConfigs
{
    public class DiscrepancyPartEntityTypeConfiguration :
    IEntityTypeConfiguration<DiscrepancyPart>
    {
        public void Configure(EntityTypeBuilder<DiscrepancyPart> config)
        {
            // Create many-many join table
            config
                .HasKey(bc => new { bc.DiscrepancyId, bc.PartId });
            config
                .HasOne(bc => bc.Discrepancy)
                .WithMany(b => b.DiscrepancyParts)
                .HasForeignKey(bc => bc.DiscrepancyId);
            config
                .HasOne(bc => bc.Part)
                .WithMany(c => c.DiscrepancyParts)
                .HasForeignKey(bc => bc.PartId);
        }
    }
}