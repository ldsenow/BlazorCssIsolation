using BlazorCssIsolation.Theming.Themes.Algorithms;
using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes;

public interface IThemeGenerator
{
    Theme Generate(SeedToken seedToken, params IThemeAlgorithm[] algorithms);
}

public class DerivativeThemeGenerator : IThemeGenerator
{
    public Theme Generate(SeedToken seedToken, params IThemeAlgorithm[] algorithms)
    {
        if (algorithms == null || !algorithms.Any())
            throw new ArgumentNullException(nameof(algorithms));

        ThemeTokens? themeTokens = null;
        Dictionary<string, DesignTokenCollection> designTokens = new();

        foreach (var algorithm in algorithms)
        {
            var pair = algorithm.Derive(seedToken, themeTokens);

            themeTokens = pair.ThemeTokens;
            designTokens.Add(algorithm.Name, pair.DesignTokens);
        }

        return new Theme(themeTokens!, designTokens);
    }
}