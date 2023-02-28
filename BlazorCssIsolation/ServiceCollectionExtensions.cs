using BlazorCssIsolation.Theming;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorCssIsolationComponents(this IServiceCollection services)
    {
        services.AddTheming();

        return services;
    }
}
