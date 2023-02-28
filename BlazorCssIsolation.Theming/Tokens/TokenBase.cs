using System.Text.RegularExpressions;
using System.Text;

namespace BlazorCssIsolation.Theming.Tokens;

public abstract record TokenBase
{
    public object? this[string name] => GetType().GetProperty(name)?.GetValue(this);

    public string VarPrefix { get; set; } = "ant";

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
                sb.Append($"--{VarPrefix}-{ToKebabCase(p.Name)}:{v};");
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
