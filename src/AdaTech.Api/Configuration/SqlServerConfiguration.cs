using AdaTech.Infrastructure.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AdaTech.Api.Configuration
{
    public static class SqlServerConfiguration
    {
        public static IServiceCollection AddAdaSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Ada");

            services.AddDbContext<AdaTechContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    x => x.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null));
            });

            return services;
        }
    }
}
