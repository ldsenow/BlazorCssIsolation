using BlazorCssIsolation.Theming.Themes;
using BlazorCssIsolation.Theming.Themes.Algorithms;
using BlazorCssIsolation.Theming.Tokens;
using Microsoft.AspNetCore.Components;

namespace BlazorCssIsolation;

//TODO: We may support cascade ConfigProvider
public partial class ConfigProvider
{
    [Inject]
    private IThemeGenerator ThemeGenerator { get; set; } = default!;

    [Parameter]
    public IThemeAlgorithm ThemeAlgorithm { get; set; } = new DefaultThemeAlgorithm(new ColorDerivative());

    [Parameter]
    public SeedToken SeedToken { get; set; } = SeedToken.Default;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public Func<ThemeToken, ThemeToken>? Customize { get; set; }

    public ThemeToken ThemeToken { get; private set; } = default!;

    public IReadOnlyCollection<string> DesignTokenChanges { get; private set; } = new List<string>();

    private string ComponentPrefix => ThemeToken.VarPrefix;

    //TODO: What if it is multiple algorithms?
    private string ComponentCssClass => $"{ComponentPrefix} {ComponentPrefix}-{ThemeAlgorithm.Name}";

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ThemeToken = ThemeGenerator.Generate(SeedToken, ThemeAlgorithm);

        var customizedThemeToken = Customize?.Invoke(ThemeToken);
        if (customizedThemeToken is not null)
        {
            DesignTokenChanges = ThemeToken.CompareChanges(customizedThemeToken)
                .Where(x => x.Status == ChangeStatus.Modified || x.Status == ChangeStatus.Added)
                .Select(x => (x.TargetValue ?? new DesignToken(x.Key, null)).ToCssVar(SeedToken.VarPrefix))
                .ToList()
                .AsReadOnly();

            ThemeToken = customizedThemeToken;
        }
    }

    //TODO: monitor props changes
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
    }
}
