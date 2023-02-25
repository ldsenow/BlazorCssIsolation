using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes.Algorithms;

public interface IThemeAlgorithm
{
    string Name { get; }
    ThemeTokenCollection Derive(SeedToken seedToken);
}
