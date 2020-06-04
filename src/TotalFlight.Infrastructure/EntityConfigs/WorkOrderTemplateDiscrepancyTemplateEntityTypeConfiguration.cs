using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TotalFlight.Domain.Entities;

namespace TotalFlight.Infrastructure.EntityConfigs
{
    public class WorkOrderTemplateDiscrepancyTemplateEntityTypeConfiguration :
    IEntityTypeConfiguration<WorkOrderTemplateDiscrepancyTemplate>
    {
        public void Configure(EntityTypeBuilder<WorkOrderTemplateDiscrepancyTemplate> config)
        {
            // Create many-many join table
            config
                .HasKey(bc => new { bc.WorkOrderTemplateId, bc.DiscrepancyTemplateId });
            config
                .HasOne(bc => bc.WorkOrderTemplate)
                .WithMany(b => b.WorkOrderTemplateDiscrepancyTemplates)
                .HasForeignKey(bc => bc.WorkOrderTemplateId);
            config
                .HasOne(bc => bc.DiscrepancyTemplate)
                .WithMany(c => c.WorkOrderTemplateDiscrepancyTemplates)
                .HasForeignKey(bc => bc.DiscrepancyTemplateId);
        }
    }
}