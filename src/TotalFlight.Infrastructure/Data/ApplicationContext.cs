using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Entities;
using TotalFlight.Domain.Entities.DeadlineAggregate;
using System.Threading;

namespace TotalFlight.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<AircraftOptions> AircraftOptions { get; set; }
        public DbSet<AircraftTimes> AircraftTimes { get; set; }
        public DbSet<Deadline> Deadlines { get; set; }
        public DbSet<Discrepancy> Discrepancies { get; set; }
        public DbSet<DiscrepancyPart> DiscrepancyParts { get; set; }
        public DbSet<DiscrepancyTemplate> DiscrepancyTemplates { get; set; }
        public DbSet<DiscrepancyTemplatePart> DiscrepancyTemplateParts { get; set; }
        public DbSet<LaborRecord> LaborRecords { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Squawk> Squawks { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderTemplate> WorkOrderTemplates { get; set; }
        public DbSet<WorkOrderTemplateDiscrepancyTemplate> WorkOrderTemplateDiscrepancyTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many relationship between Discrepancy and Part
            modelBuilder.Entity<DiscrepancyPart>()
                .HasKey(bc => new { bc.DiscrepancyId, bc.PartId });
            modelBuilder.Entity<DiscrepancyPart>()
                .HasOne(bc => bc.Discrepancy)
                .WithMany(b => b.DiscrepancyParts)
                .HasForeignKey(bc => bc.DiscrepancyId);
            modelBuilder.Entity<DiscrepancyPart>()
                .HasOne(bc => bc.Part)
                .WithMany(c => c.DiscrepancyParts)
                .HasForeignKey(bc => bc.PartId);
            // Many-to-many relationship between DiscrepancyTemplate and Part
            modelBuilder.Entity<DiscrepancyTemplatePart>()
                .HasKey(bc => new { bc.DiscrepancyTemplateId, bc.PartId });
            modelBuilder.Entity<DiscrepancyTemplatePart>()
                .HasOne(bc => bc.DiscrepancyTemplate)
                .WithMany(b => b.DiscrepancyTemplateParts)
                .HasForeignKey(bc => bc.DiscrepancyTemplateId);
            modelBuilder.Entity<DiscrepancyTemplatePart>()
                .HasOne(bc => bc.Part)
                .WithMany(c => c.DiscrepancyTemplateParts)
                .HasForeignKey(bc => bc.PartId);
            // Many-to-many relationship between WorkOrderTemplate and DiscrepancyTemplate
            modelBuilder.Entity<WorkOrderTemplateDiscrepancyTemplate>()
                .HasKey(bc => new { bc.WorkOrderTemplateId, bc.DiscrepancyTemplateId });
            modelBuilder.Entity<WorkOrderTemplateDiscrepancyTemplate>()
                .HasOne(bc => bc.WorkOrderTemplate)
                .WithMany(b => b.WorkOrderTemplateDiscrepancyTemplates)
                .HasForeignKey(bc => bc.WorkOrderTemplateId);
            modelBuilder.Entity<WorkOrderTemplateDiscrepancyTemplate>()
                .HasOne(bc => bc.DiscrepancyTemplate)
                .WithMany(c => c.WorkOrderTemplateDiscrepancyTemplates)
                .HasForeignKey(bc => bc.DiscrepancyTemplateId);
            // Soft delete filters
            modelBuilder.Entity<Part>().HasQueryFilter(p => !p.IsSoftDeleted);
            modelBuilder.Entity<Part>().HasQueryFilter(p => !p.IsSoftDeleted);
        }
        /// <summary>
        /// Dispatches all domain events before saving changes.
        /// </summary>
        public async Task<bool> SaveEntitiesAsync(CancellationToken token = default(CancellationToken))
        {
            await _mediator.DispatchDomainEvents(this);
            return await base.SaveChangesAsync();
        }
    }
}