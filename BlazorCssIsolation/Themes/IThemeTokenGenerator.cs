using BlazorCssIsolation.Tokens;

namespace BlazorCssIsolation.Themes;

//TODO: get a better name
public interface IThemeTokenGenerator
{
    string Name { get; }
    DesignTokenCollection Generate(SeedToken seedToken);
}
