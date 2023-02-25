using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Theming.Themes;

public record Theme
{
    public Theme(string name, ThemeTokenCollection themeTokens)
    {
        Name = name;
        ThemeTokens = themeTokens;
    }

    public string Name { get; }
    public ThemeTokenCollection ThemeTokens { get; }

    public Theme Merge(Theme otherTheme)
    {
        throw new NotImplementedException();
    }
}
