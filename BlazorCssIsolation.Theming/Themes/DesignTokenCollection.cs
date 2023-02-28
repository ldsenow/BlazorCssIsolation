using System.Text;

namespace BlazorCssIsolation.Theming.Themes;

public class DesignTokenCollection : Dictionary<string, DesignToken>
{
    public DesignTokenCollection()
    {
    }

    public DesignTokenCollection(IEnumerable<KeyValuePair<string, DesignToken>> pairs) : base(pairs)
    {
    }

    public DesignTokenCollection(Dictionary<string, object?> pairs)
    {
        foreach (var p in pairs)
        {
            Set(p.Key, p.Value);
        }
    }

    public DesignTokenCollection(DesignToken[] tokens)
    {
        foreach (var t in tokens)
        {
            Set(t);
        }
    }

    public void Set(string name, object? value)
    {
        var token = new DesignToken(name, value);

        Set(token);
    }

    public void Set(DesignToken token)
    {
        if (token == null) return;

        if (ContainsKey(token.Name))
        {
            this[token.Name] = token;
        }
        else
        {
            Add(token.Name, token);
        }
    }
}

public record DesignToken(string Name, object? Value)
{
    public string ToCssVar(string prefix)
    {
        var varPrefix = string.IsNullOrEmpty(prefix) ? "--" : $"--{prefix}-";

        var name = ToKebabCase(Name, separator: "-");

        return $"{varPrefix}{name}:{Value ?? ""};";
    }

    //https://github.com/J0rgeSerran0/JsonNamingPolicy/blob/master/JsonKebabCaseNamingPolicy.cs
    private static string ToKebabCase(string name, string separator)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) return string.Empty;

        ReadOnlySpan<char> spanName = name.Trim();

        var stringBuilder = new StringBuilder();
        var addCharacter = true;
        var isNextLower = false;
        var isNextUpper = false;
        var isNextSpace = false;

        for (int position = 0; position < spanName.Length; position++)
        {
            if (position != 0)
            {
                bool isCurrentSpace = spanName[position] == 32;
                bool isPreviousSpace = spanName[position - 1] == 32;
                bool isPreviousSeparator = spanName[position - 1] == 95;

                if (position + 1 != spanName.Length)
                {
                    isNextLower = spanName[position + 1] > 96 && spanName[position + 1] < 123;
                    isNextUpper = spanName[position + 1] > 64 && spanName[position + 1] < 91;
                    isNextSpace = spanName[position + 1] == 32;
                }

                if (isCurrentSpace &&
                    (isPreviousSpace ||
                    isPreviousSeparator ||
                    isNextUpper ||
                    isNextSpace))
                {
                    addCharacter = false;
                }
                else
                {
                    var isCurrentUpper = spanName[position] > 64 && spanName[position] < 91;
                    var isPreviousLower = spanName[position - 1] > 96 && spanName[position - 1] < 123;
                    var isPreviousNumber = spanName[position - 1] > 47 && spanName[position - 1] < 58;

                    if (isCurrentUpper &&
                    (isPreviousLower ||
                    isPreviousNumber ||
                    isNextLower ||
                    isNextSpace ||
                    isNextLower && !isPreviousSpace))
                    {
                        _ = stringBuilder.Append(separator);
                    }
                    else
                    {
                        if (isCurrentSpace &&
                            !isPreviousSpace &&
                            !isNextSpace)
                        {
                            _ = stringBuilder.Append(separator);
                            addCharacter = false;
                        }
                    }
                }
            }

            if (addCharacter)
            {
                stringBuilder.Append(spanName[position]);
            }
            else
            {
                addCharacter = true;
            }
        }

        return stringBuilder.ToString().ToLower();
    }
}
