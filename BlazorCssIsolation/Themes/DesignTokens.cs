using BlazorCssIsolation.Tokens;
using System.Text;
using System.Text.RegularExpressions;

namespace BlazorCssIsolation.Themes;

public interface ISeedTokens : IPresetColors
{
    // Color
    string ColorPrimary { get; set; }
    string ColorSuccess { get; set; }
    string ColorWarning { get; set; }
    string ColorError { get; set; }
    string ColorInfo { get; set; }
    string ColorTextBase { get; set; }

    /** Base component background color. Will derivative container background color with this */
    string ColorBgBase { get; set; }

    // Font
    string FontFamily { get; set; }
    int FontSize { get; set; }

    // Line
    /** Border width of base components */
    int LineWidth { get; set; }
    string LineType { get; set; }

    // Motion
    int MotionUnit { get; set; }
    int MotionBase { get; set; }
    string MotionEaseOutCirc { get; set; }
    string MotionEaseInOutCirc { get; set; }
    string MotionEaseInOut { get; set; }
    string MotionEaseOutBack { get; set; }
    string MotionEaseInBack { get; set; }
    string MotionEaseInQuint { get; set; }
    string MotionEaseOutQuint { get; set; }
    string MotionEaseOut { get; set; }

    // Radius
    int BorderRadius { get; set; }

    // Size
    int SizeUnit { get; set; }
    int SizeStep { get; set; }
    int SizePopupArrow { get; set; }

    // Control Base
    int ControlHeight { get; set; }

    // zIndex
    /** Base zIndex of component like BackTop, Affix which can be cover by large popup */
    int ZIndexBase { get; set; }
    /** Base popup component zIndex */
    int ZIndexPopupBase { get; set; }

    // Image
    /** Define default Image opacity. Useful when in dark-like theme */
    double OpacityImage { get; set; }

    // Wireframe
    bool Wireframe { get; set; }
}

public abstract record DesignTokens : AliasToken
{
    private const string VAR_PREFIX = "--ant";

    public string ToCssStyle()
    {
        var sb = new StringBuilder();

        var props = GetType().GetProperties(
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.Public);

        foreach (var p in props)
        {
            var v = p.GetValue(this);
            if (v != null)
                sb.Append($"{VAR_PREFIX}-{ToKebabCase(p.Name)}: {v};");
        }

        return sb.ToString();
    }

    private static readonly Regex KebabCaseRegex = new("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z0-9])", RegexOptions.Compiled);
    private static string ToKebabCase(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        return KebabCaseRegex.Replace(name, "-$1").ToLower().Trim();
    }
}