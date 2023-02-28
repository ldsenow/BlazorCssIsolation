using BlazorCssIsolation.Theming.Themes.Algorithms;
using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes;

public interface IThemeGenerator
{
    ThemeToken Generate(SeedToken seedToken, IThemeAlgorithm algorithm);
}

public class DerivativeThemeGenerator : IThemeGenerator
{
    public ThemeToken Generate(SeedToken seedToken, IThemeAlgorithm algorithm)
    {
        throw new NotImplementedException();
        //if (algorithms == null || !algorithms.Any())
        //    throw new ArgumentNullException(nameof(algorithms));

        //ThemeToken? themeTokens = null;
        //Dictionary<string, DesignTokenCollection> designTokens = new();

        //foreach (var algorithm in algorithms)
        //{
        //    var pair = algorithm.Derive(seedToken, themeTokens);

        //    themeTokens = pair.ThemeTokens;
        //    designTokens.Add(algorithm.Name, pair.DesignTokens);
        //}

        //return new Theme(themeTokens!, designTokens);
    }
}