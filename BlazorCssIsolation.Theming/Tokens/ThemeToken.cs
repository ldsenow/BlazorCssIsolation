namespace BlazorCssIsolation.Theming.Tokens;

public record ThemeToken : AliasToken
{
    protected ThemeToken(AliasToken original) : base(original)
    {
    }
}
