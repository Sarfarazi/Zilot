using Zelute.Application.Repository;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<ISaleInfoService, SaleInfoService>();
        return services;
    }

    public static IServiceCollection RegisterHttpContextAccessor(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        return services;
    }
}