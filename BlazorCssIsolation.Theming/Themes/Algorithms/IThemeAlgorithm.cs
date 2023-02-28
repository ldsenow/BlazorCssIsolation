using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes.Algorithms;

public interface IThemeAlgorithm
{
    IThemeAlgorithm? DerivedFrom { get; set; }

    ThemeToken Derive(SeedToken seedToken);
}
