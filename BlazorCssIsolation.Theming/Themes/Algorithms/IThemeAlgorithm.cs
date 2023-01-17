using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes.Algorithms;

public interface IThemeAlgorithm
{
    string Name { get; }
    (ThemeTokens ThemeTokens, DesignTokenCollection DesignTokens) Derive(SeedToken seedToken, ThemeTokens? themeTokens);
}
