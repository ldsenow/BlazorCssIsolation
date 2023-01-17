using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes;

//TODO: get a better name
public interface IThemeTokenGenerator
{
    string Name { get; }
    DesignTokenCollection Generate(SeedToken seedToken);
}
