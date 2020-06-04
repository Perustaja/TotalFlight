using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TotalFlight.Domain.Entities;

namespace TotalFlight.Infrastructure.EntityConfigs
{
    public class DiscrepancyTemplatePartEntityTypeConfiguration :
    IEntityTypeConfiguration<DiscrepancyTemplatePart>
    {
        public void Configure(EntityTypeBuilder<DiscrepancyTemplatePart> config)
        {
            // Create many-many join table
            config
                .HasKey(bc => new { bc.DiscrepancyTemplateId, bc.PartId });
            config
                .HasOne(bc => bc.DiscrepancyTemplate)
                .WithMany(b => b.DiscrepancyTemplateParts)
                .HasForeignKey(bc => bc.DiscrepancyTemplateId);
            config
                .HasOne(bc => bc.Part)
                .WithMany(c => c.DiscrepancyTemplateParts)
                .HasForeignKey(bc => bc.PartId);
        }
    }
}