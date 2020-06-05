using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TotalFlight.Infrastructure.Data;
using TotalFlight.Infrastructure.Interfaces;
using TotalFlight.Infrastructure.Tenancy;

namespace TotalFlight.Api.Application.Queries.Tenancy
{
    /// <summary>
    /// Essentially acts as a repository for tenants
    /// </summary>
    public class TenantsProvider : ITenantSource
    {
        private readonly TenancyContext _tenancyContext;
        private readonly string _connectionString;
        public TenantsProvider(TenancyContext tenancyContext, string connString)
        {
            _tenancyContext = tenancyContext ?? throw new ArgumentNullException(nameof(tenancyContext));
            _connectionString = String.IsNullOrEmpty(connString) ? connString : throw new ArgumentNullException(nameof(connString));
        }

        public async Task<Tenant> GetTenantById(Guid id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var res = await conn.QueryFirstOrDefaultAsync<Tenant>(
                    @"SELECT *
                    FROM Tenants
                    WHERE Id = @id"
                    , new { id }
                );
                return res;
            }
        }
    }
}