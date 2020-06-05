using System;
using System.Threading.Tasks;
using TotalFlight.Infrastructure.Tenancy;

namespace TotalFlight.Infrastructure.Interfaces
{
    /// <summary>
    /// Acts like a repository for the Tenants database.
    /// </summary>
    public interface ITenantSource
    {
        Task<Tenant> GetTenantById(Guid id);
    }
}