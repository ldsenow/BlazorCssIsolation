using BlazorCssIsolation.Themes;
using BlazorCssIsolation.Tokens;
using Microsoft.AspNetCore.Components;

namespace BlazorCssIsolation;

public partial class ConfigProvider
{
    public Theme Theme { get; set; }//=> Algorithms.Where(x => x.Name == "default");

    [Parameter]
    public Action<Theme>? ConfigTheme { get; set; }

    [Inject]
    public IEnumerable<IThemeTokenGenerator> Algorithms { get; set; } = Enumerable.Empty<IThemeTokenGenerator>();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}

public class Theme
{
    public string[] Algorithms { get; set; } = new[] { "default", "dark", "compact" };
    public BaseDesignTokens Base { get; set; } = new();
    public ButtonDesignTokens Button { get; set; } = new();
}

public record BaseDesignTokens : AliasToken
{
}
