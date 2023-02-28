namespace BlazorCssIsolation.Theming.Tokens;

public abstract record TokenBase
{
    public object? this[string name] => GetType().GetProperty(name)?.GetValue(this);

    public string VarPrefix = "ant";
}
