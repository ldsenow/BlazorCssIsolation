using BlazorCssIsolation.Themes;
using BlazorCssIsolation.Tokens;
using Microsoft.AspNetCore.Components;

namespace BlazorCssIsolation;

public record ButtonDesignTokens : TokenBase
{
    public string? ButtonPrimaryBorderColor { get; set; }
}

public partial class Button
{
    [CascadingParameter]
    public Theme Theme { get; set; } = default!;

    [Parameter]
    public string Type { get; set; } = "primary";

    [Parameter]
    public string? Text { get; set; }

    private string GetCssClass()
    {
        return $"ant-btn --{Type}";
    }
}