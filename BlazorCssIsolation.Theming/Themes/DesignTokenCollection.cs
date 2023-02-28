using System.Text;

namespace BlazorCssIsolation.Theming.Themes;

public class DesignTokenCollection : Dictionary<string, DesignToken>
{
    public void Set(string name, object? value)
    {
        var token = new DesignToken(name, value);

        Set(token);
    }

    public void Set(DesignToken? token)
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

        var name = ToKebabCase(Name, separator: '-');

        return $"{varPrefix}{name}: {Value ?? ""};";
    }

    //https://stackoverflow.com/questions/37301287/how-do-i-convert-pascalcase-to-kebab-case-with-c
    private static string ToKebabCase(string name, char separator = '-')
    {
        if (name is null) return string.Empty;

        if (name.Length == 0) return string.Empty;

        StringBuilder builder = new();

        for (var i = 0; i < name.Length; i++)
        {
            var currentChar = name[i];

            if (i == 0) // if current char is the first char
            {
                builder.Append(char.ToLower(currentChar));
            }
            else if (char.IsLower(currentChar)) // if current char is lower
            {
                builder.Append(currentChar);
            }
            else if (char.IsUpper(currentChar)) // if current char is upper 
            {
                if (char.IsLower(name[i - 1]) || char.IsDigit(name[i - 1])) // and previous char is lower or is a number
                {
                    builder.Append(separator);
                }

                builder.Append(char.ToLower(currentChar));
            }
            else if (char.IsDigit(currentChar)) // if current char is a number
            {
                if (!char.IsDigit(name[i - 1])) // and previous char is not a number
                {
                    builder.Append(separator);
                }

                builder.Append(currentChar);
            }
            else // if current char is a symbol or punctuation etc.
            {
                builder.Append(currentChar);
            }
        }

        return builder.ToString();
    }
}
