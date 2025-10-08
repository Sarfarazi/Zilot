using FluentValidation;
using Zelut.Application.Configuration.Mapper;
using Zelut.Application.Services;
using Zelut.Application.Validations;
using Zelut.Common.Helpers;
using Zelut.Infrastructure.Repository;
using Zelut.Infrastructure.Services;
using Zelute.Application.Repository;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
                .AddScoped<ISaleInfoService, SaleInfoService>()
                .AddScoped<ISmsService, SmsService>()
                .AddScoped<IDapperHelper, DapperHelper>();

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

    public static IServiceCollection RegisterHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient("asanak-sms", client =>
        {
            client.BaseAddress = new Uri(ApplicationConfig.SmsUrls.Asanak.Url);
        });
        return services;
    }
}