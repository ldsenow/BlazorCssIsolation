using BlazorCssIsolation.Theming.Themes;

namespace BlazorCssIsolation.Theming.Tokens;

public record ThemeTokenCollection : AliasToken
{
    public ThemeTokenCollection(AliasToken original) : base(original)
    {
    }

    public DesignTokenCollection DesignTokens => throw new NotImplementedException();
}
