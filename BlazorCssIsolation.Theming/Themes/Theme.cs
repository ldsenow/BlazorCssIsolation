using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes;

public class Theme
{
    public Theme(ThemeToken themeTokens, IDictionary<string, DesignTokenCollection> designTokens)
    {
        ThemeTokens = themeTokens;
        DesignTokens = designTokens.AsReadOnly();
    }

    public ThemeToken ThemeTokens { get; }
    public IReadOnlyDictionary<string, DesignTokenCollection> DesignTokens { get; }
}
