using BlazorCssIsolation.Themes.Default;
using BlazorCssIsolation.Theming.Themes;
using BlazorCssIsolation.Theming.Tokens;
using Microsoft.AspNetCore.Components;

namespace BlazorCssIsolation;

public partial class ConfigProvider
{
    public Theme? Theme { get; set; }//=> Algorithms.Where(x => x.Name == "default");

    public DesignTokenCollection ThemeDesignTokens { get; set; }

    [Parameter]
    public Action<Theme>? ConfigTheme { get; set; }

    [Inject]
    public IEnumerable<IThemeTokenGenerator> Algorithms { get; set; } = Enumerable.Empty<IThemeTokenGenerator>();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public ConfigProvider()
    {
        ThemeDesignTokens = new DefaultThemeTokenGenerator(new ColorDerivative())
                .Generate(SeedToken.Default);
    }
}

public class Theme
{
    public string[] Algorithms { get; set; } = new[] { "default", "dark", "compact" };
    public ThemeTokenCollection Base { get; set; } = default!;
    public ButtonDesignTokens Button { get; set; } = new();
}
