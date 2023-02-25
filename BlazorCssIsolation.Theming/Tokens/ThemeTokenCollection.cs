using BlazorCssIsolation.Theming.Themes;
using System.Reflection;

namespace BlazorCssIsolation.Theming.Tokens;

public record ThemeTokenCollection : AliasToken
{
    public ThemeTokenCollection(AliasToken original) : base(original)
    {
    }

    public DesignTokenCollection GetDesignTokens()
    {
        var collection = new DesignTokenCollection();
        var props = GetSortedProperties<AliasToken>();

        foreach (var prop in props)
        {
            collection.Set(prop.Name, prop.GetValue(this));
        }

        return collection;
    }

    public ThemeTokenCollection Merge(ThemeTokenCollection other)
    {
        throw new NotImplementedException();
    }

    private static PropertyInfo[] GetSortedProperties<T>()
    {
        return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .OrderBy(x => x.Name)
            .ToArray();
    }
}
