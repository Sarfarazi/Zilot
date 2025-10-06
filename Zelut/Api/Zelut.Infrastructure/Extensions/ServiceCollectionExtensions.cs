using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterSqlServer(this IServiceCollection services)
    {
        services.AddDbContext<ZelutDbContext>(options => options.UseSqlServer(ApplicationConfig.SqlServer.CrmTestConnectionString));

        return services;
    }
}