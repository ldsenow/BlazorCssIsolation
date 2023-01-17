using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes;

public class Theme
{
    public Theme(ThemeTokens themeTokens, IDictionary<string, DesignTokenCollection> designTokens)
    {
        ThemeTokens = themeTokens;
        DesignTokens = designTokens.AsReadOnly();
    }

    public ThemeTokens ThemeTokens { get; }
    public IReadOnlyDictionary<string, DesignTokenCollection> DesignTokens { get; }
}
