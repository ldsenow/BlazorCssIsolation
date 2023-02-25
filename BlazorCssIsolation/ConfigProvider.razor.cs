using BlazorCssIsolation.Theming.Themes;
using BlazorCssIsolation.Theming.Themes.Algorithms;
using BlazorCssIsolation.Theming.Tokens;
using Microsoft.AspNetCore.Components;

namespace BlazorCssIsolation;

public partial class ConfigProvider
{
    [Inject]
    public IThemeGenerator ThemeGenerator { get; set; } = default!;

    [Inject]
    public IThemeAlgorithm[] AvailableAlgorithms { get; set; } = Array.Empty<IThemeAlgorithm>();

    [Parameter]
    public IThemeAlgorithm[] AppliedAlgorithms { get; set; } = Array.Empty<IThemeAlgorithm>();

    [Parameter]
    public SeedToken SeedToken { get; set; } = SeedToken.Default;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public ThemeTokenCollection ThemeToken { get; private set; }

    public ConfigProvider()
    {
        AppliedAlgorithms = AvailableAlgorithms.Any()
            ? new[] { AvailableAlgorithms.First() }
            : Array.Empty<IThemeAlgorithm>();

        ThemeToken = ThemeGenerator.Generate(seedToken: SeedToken, AppliedAlgorithms);
    }
}

//public class ThemeOptions
//{
//    public Type[] Algorithms { get; set; } = new[] { typeof(DefaultThemeAlgorithm) };
//    public ThemeTokenCollection Base { get; set; } = default!;
//    public ButtonDesignTokens Button { get; set; } = new();
//}
