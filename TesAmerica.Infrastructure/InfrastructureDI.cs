using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using TesAmerica.Domain.Contracts;
using TesAmerica.Infrastructure.DbConnections;

namespace TesAmerica.Infrastructure
{
    public static class InfrastructureDI
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection<SqlConnection, SqlTransaction>, SqlServerConnection>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
