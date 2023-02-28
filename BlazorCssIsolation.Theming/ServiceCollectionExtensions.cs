using BlazorCssIsolation.Theming.Themes;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCssIsolation.Theming;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTheming(this IServiceCollection services)
    {
        services.AddSingleton<IColorDerivative, ColorDerivative>();
        services.AddSingleton<IThemeGenerator, DerivativeThemeGenerator>();

        return services;
    }
}
