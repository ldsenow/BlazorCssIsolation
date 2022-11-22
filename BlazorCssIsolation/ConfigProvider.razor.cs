using BlazorCssIsolation.Themes;
using Microsoft.AspNetCore.Components;

namespace BlazorCssIsolation;

public partial class ConfigProvider
{
    [Parameter]
    public Theme Theme { get; set; } = new();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}

public class Theme
{
    public BaseDesignTokens Base { get; set; } = new();
    public ButtonDesignTokens Button { get; set; } = new();
}

public record BaseDesignTokens : DesignTokens
{
    public string? Primary { get; set; }
}
