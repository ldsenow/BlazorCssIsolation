using BlazorCssIsolation.Theming.Tokens;
using Microsoft.AspNetCore.Components;

namespace BlazorCssIsolation;

public partial class Button
{
    [CascadingParameter]
    public ThemeToken ThemeToken { get; set; } = default!;

    [Parameter]
    public string Type { get; set; } = "primary";

    [Parameter]
    public string? Text { get; set; }

    private string ComponentPrefix => ThemeToken.VarPrefix;

    private string GetCssClass()
    {
        return $"{ComponentPrefix}-btn --{Type}";
    }
}

public record ButtonDesignToken : TokenBase
{
    public string? ButtonPrimaryBorderColor { get; set; }
}