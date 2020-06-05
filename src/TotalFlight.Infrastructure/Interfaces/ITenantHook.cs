using TotalFlight.Infrastructure.Tenancy;

namespace TotalFlight.Infrastructure.Interfaces
{
    /// <summary>
    /// Grabs the tenant information from a user's information in a request.
    /// </summary>
    public interface ITenantHook
    {
        Tenant GetTenant();
    }
}