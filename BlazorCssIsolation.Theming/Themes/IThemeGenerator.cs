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
        if (seedToken is null)
            throw new ArgumentNullException(nameof(seedToken));

        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));

        return algorithm.Derive(seedToken);
    }
}