using System;

namespace TotalFlight.Infrastructure.Tenancy
{
    public class Tenant
    {
        public Guid Id { get; private set; }
        public bool IsActive { get; private set; }
        public string ConnectionString { get; private set; }
        public Tenant() { }
    }
}