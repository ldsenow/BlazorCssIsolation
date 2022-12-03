using BlazorCssIsolation.Tokens;

namespace BlazorCssIsolation.Themes;

public interface IThemeTokenGenerator
{
    DesignTokenCollection Generate(SeedToken seedToken);
}
