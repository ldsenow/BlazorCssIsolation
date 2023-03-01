using BlazorCssIsolation.Theming.Themes;
using BlazorCssIsolation.Theming.Themes.Algorithms;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCssIsolation.Theming;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorCssIsolationTheming(this IServiceCollection services)
    {
        services.AddSingleton<IColorDerivative, ColorDerivative>();
        services.AddSingleton<IThemeGenerator, DerivativeThemeGenerator>();
        services.AddScoped<IThemeAlgorithm, DefaultThemeAlgorithm>();
        //TODO: Scan iherited
        services.AddScoped<DefaultThemeAlgorithm>();

        return services;
    }
}
