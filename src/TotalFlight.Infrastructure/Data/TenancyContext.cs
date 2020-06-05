using Microsoft.EntityFrameworkCore;
using System;
using TotalFlight.Infrastructure.Tenancy;
using TotalFlight.Infrastructure.Interfaces;

namespace TotalFlight.Infrastructure.Data
{
    public class TenancyContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        public TenancyContext(DbContextOptions<TenancyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}