using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Entities;
using TotalFlight.Domain.Entities.DeadlineAggregate;
using System.Threading;
using MediatR;
using System;
using TotalFlight.Infrastructure.EntityConfigs;

namespace TotalFlight.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
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

        // Functionality
        private readonly IMediator _mediator;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IMediator mediator)
            : base (options)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure join tables
            modelBuilder.ApplyConfiguration(new DiscrepancyPartEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DiscrepancyTemplatePartEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkOrderTemplateDiscrepancyTemplateEntityTypeConfiguration());
            // Soft delete filters
            modelBuilder.Entity<Part>().HasQueryFilter(p => !p.IsSoftDeleted);
        }

        /// <summary>
        /// Dispatches all domain events before saving changes. Returns false on failure.
        /// </summary>
        public async Task<bool> SaveEntitiesAsync(CancellationToken token = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this); // Include all domain event behavior in this commit
            await base.SaveChangesAsync();
            return true; // Domain events dispatched without exception
        }
    }
}