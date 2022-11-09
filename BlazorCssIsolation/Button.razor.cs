using Microsoft.AspNetCore.Components;
using System.Text;

namespace BlazorCssIsolation;

public record ButtonDesignTokens : DesignTokens
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