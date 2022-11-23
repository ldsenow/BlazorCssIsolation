using BlazorCssIsolation.Tokens;
using System.Text;
using System.Text.RegularExpressions;

namespace BlazorCssIsolation.Themes;

public abstract record DesignTokens
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