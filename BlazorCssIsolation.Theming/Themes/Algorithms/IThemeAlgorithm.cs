using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes.Algorithms;

public interface IThemeAlgorithm
{
    string Name { get; }
    ThemeToken Derive(SeedToken seedToken, ThemeToken? derivedFrom = null);
}
