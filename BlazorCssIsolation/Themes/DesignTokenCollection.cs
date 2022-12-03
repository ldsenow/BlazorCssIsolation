namespace BlazorCssIsolation.Themes;

public class DesignTokenCollection : List<DesignToken>
{
    public DesignTokenCollection()
    {
    }

    public DesignTokenCollection(DesignToken[] tokens)
    {
        AddRange(tokens.ToList());
    }

    public IReadOnlyList<DesignToken> Tokens => this;
    public string? Prefix { get; set; }
    public DesignToken? this[string name] => Tokens?.SingleOrDefault(t => t.Name == name);

    public void Add(string name, object? value)
    {
        Add(new DesignToken(name, value));
    }
}

public record DesignToken(string Name, object? Value);
