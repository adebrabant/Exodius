using Microsoft.Extensions.DependencyInjection;
using Mock.SwagLabs.Configurations;
using Mock.SwagLabs.Configurations.Models;

namespace Mock.SwagLabs.Registrations;

public static class ConfigurationServiceExtensions
{
    public static IServiceCollection AddApplicationSettingServices(this IServiceCollection services)
    {
        services
            .AddSingleton(AppsettingConfigurationReader.Read())
            .AddSingleton<TestSettings>();

        return services;
    }
}
