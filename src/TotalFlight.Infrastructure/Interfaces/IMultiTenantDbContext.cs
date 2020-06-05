using System;

namespace TotalFlight.Infrastructure.Interfaces
{
    public interface IMultiTenantDbContext
    {
        Guid TenantId { get; }
    }
}