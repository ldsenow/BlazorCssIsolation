using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes.Algorithms;

public interface IThemeAlgorithm
{
    ThemeToken Derive(SeedToken seedToken, IThemeAlgorithm? derivedFrom = null);
}
