using FluentValidation;
using Zelut.Application.Configuration.Mapper;
using Zelut.Application.Validations;
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

    public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config => config.AddProfile(typeof(MapperProfile)));
        return services;
    }

    public static IServiceCollection RegisterFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ZelutBuyerRequestDtoValidtor>();
        return services;
    }
}